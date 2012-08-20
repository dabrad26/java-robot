using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;

//Capstone Project, Spring 2012, David Bradshaw, Gregory Fincher, Kelvin Hawkins, Brandon McNutt
//C Sharp Code Behind File for Silverlight Application for Windows Phone 7

namespace Java_Robot_Controller_for_WP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        //Values for Use in entire application
        int rightValue = 50;
        int leftValue = 50;

        //Socket Values for entire application
        private Socket socketConnection;
        private string server;
        private int serverPort;
        public string callerOfHelp = ""; 

        //Create Connection, Method to create Connection to Robot
        public void CreateConnection(string serverAddress, int port)
        {
            try
            {
                this.socketConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.server = serverAddress;
                this.serverPort = port;
                var connectionOperation = new SocketAsyncEventArgs { RemoteEndPoint = new DnsEndPoint(this.server, this.serverPort) };
                this.socketConnection.ConnectAsync(connectionOperation);
            }

                //If unable to connect show error
            catch
            {
                errorMessage();
            }
        }

        //Method to Send Array of Bytes to Robot
        public void SendToRobot(byte[] toRobot)
        {
            try
            {
                var asyncEvent = new SocketAsyncEventArgs { RemoteEndPoint = new DnsEndPoint(server, serverPort) };

                
                asyncEvent.SetBuffer(toRobot, 0, toRobot.Length);

                socketConnection.SendAsync(asyncEvent);
            }
                //If cannot send, then something is wrong, show error
            catch
            {
                errorMessage();
            }
        }

        //When User Hits connect take IP/PORT and start Socket
        private void connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateConnection(ip_address.Text, int.Parse(port_number.Text));
                connection.Visibility = Visibility.Collapsed;
                dpad.Visibility = Visibility.Visible;
            }
                //If value cannot be converted to INT throw error
            catch
            {
                errorMessage();
            }
        }

        //User Resets Screen, clear out input
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            ip_address.Text = "";
            port_number.Text = "";
        }

        //Disconnect Socket when on DPAD
        private void dpad_disconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] payload = Encoding.UTF8.GetBytes("3");
                SendToRobot(payload);
                Thread.Sleep(100);
                socketConnection.Close();
                socketConnection.Dispose();
                dpad.Visibility = Visibility.Collapsed;
                connection.Visibility = Visibility.Visible;
            }
                //Could not disconnect, maybe it was not connected?
            catch
            {
                dpad.Visibility = Visibility.Collapsed;
                connection.Visibility = Visibility.Visible;
            }
        }

        //Change to Stick controls from DPAD
        private void stick_change_Click(object sender, RoutedEventArgs e)
        {
            dpad.Visibility = Visibility.Collapsed;
            stick.Visibility = Visibility.Visible;
        }

        //Show Help
        private void dpad_help_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            callerOfHelp = "dpad";
            dpad.Visibility = Visibility.Collapsed;
            help.Visibility = Visibility.Visible;
        }

        //Close Help, callerOFHelp shows what window to return to
        private void help_close_Click(object sender, RoutedEventArgs e)
        {
            if (callerOfHelp == "dpad")
            {
                help.Visibility = Visibility.Collapsed;
                dpad.Visibility = Visibility.Visible;
            }
            else if (callerOfHelp == "stick")
            {
                help.Visibility = Visibility.Collapsed;
                stick.Visibility = Visibility.Visible;
            }
            else if (callerOfHelp == "connector")
            {
                help.Visibility = Visibility.Collapsed;
                connection.Visibility = Visibility.Visible;
            }
            else
            {
                help.Visibility = Visibility.Collapsed;
            }

        }

        //Show Help
        private void connect_help_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            callerOfHelp = "connector";
            connection.Visibility = Visibility.Collapsed;
            help.Visibility = Visibility.Visible;
        }

        //Change to DPAD from Stick
        private void dpad_change_Click(object sender, RoutedEventArgs e)
        {
            left_slider.Value = 50;
            right_slider.Value = 50;
            center_slider.Value = 50;
            byte[] payload = Encoding.UTF8.GetBytes("3");
            SendToRobot(payload);
            stick.Visibility = Visibility.Collapsed;
            dpad.Visibility = Visibility.Visible;
        }

        //Disconnect
        private void stick_disconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] payload = Encoding.UTF8.GetBytes("3");
                SendToRobot(payload);
                Thread.Sleep(100);
                socketConnection.Close();
                socketConnection.Dispose();
                stick.Visibility = Visibility.Collapsed;
                connection.Visibility = Visibility.Visible;
            }
                //Cannot close socket, maybe it was not connected?
            catch
            {
                stick.Visibility = Visibility.Collapsed;
                connection.Visibility = Visibility.Visible;
            }
            
        }

        //Show Help
        private void stick_help_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            callerOfHelp = "stick";
            stick.Visibility = Visibility.Collapsed;
            help.Visibility = Visibility.Visible;
        }

        //Left Slider was changed
        private void left_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                left_value.Text = ((int)left_slider.Value).ToString();
                leftValue = (int)left_slider.Value;
                sendCommands();
            }
            catch (NullReferenceException)
            { }
        }

        //Right Slider was Changed
        private void right_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                //Convert to make robot drive right but show user 0-100
                int correctedValue = 0;
                int rightValueChange = (int)right_slider.Value;
                if (right_slider.Value < 50)
                {
                    correctedValue = 50 - (rightValueChange - 50);
                }
                else if (right_slider.Value > 50)
                {
                    correctedValue = 50 + (50 - rightValueChange);
                }
                else
                {
                    correctedValue = rightValueChange;
                }

                right_value.Text = correctedValue.ToString();
                rightValue = (int)right_slider.Value;
                sendCommands();

            }
            catch (NullReferenceException)
            { }
        }

        //Send commands from Slider
        public void sendCommands()
        {
            byte[] payload = new byte[3];
            payload[0] = (byte)64;
            payload[1] = (byte)leftValue;
            payload[2] = (byte)rightValue;
            SendToRobot(payload);
        }

        //Center Slider changed, change LEFT/RIGHT Sliders
        private void center_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                int correctedValue = 0;
                int centerValue = (int)center_slider.Value;
                if (centerValue > 50)
                {
                    correctedValue = 50 - (centerValue - 50);
                }
                else if (centerValue < 50)
                {
                    correctedValue = 50 + (50 - centerValue);
                }
                else
                {
                    correctedValue = centerValue;
                }

                left_slider.Value = centerValue;
                right_slider.Value = correctedValue;
            }
            catch (NullReferenceException)
            { }
        }

        //OK Pressed Close Window
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            stick.Visibility = Visibility.Collapsed;
            dpad.Visibility = Visibility.Collapsed;
            error.Visibility = Visibility.Collapsed;
            connection.Visibility = Visibility.Visible;
        }

        //Show Error Window
        public void errorMessage()
        {
            stick.Visibility = Visibility.Collapsed;
            dpad.Visibility = Visibility.Collapsed;
            connection.Visibility = Visibility.Collapsed;
            error.Visibility = Visibility.Visible;
        }

        //Up Button Clicked, Robot Forward
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            byte[] payload = Encoding.UTF8.GetBytes("1");
            SendToRobot(payload);
        }

        //Left Button clicked, Robot Left
        private void left_Click(object sender, RoutedEventArgs e)
        {
            byte[] payload = Encoding.UTF8.GetBytes("4");
            SendToRobot(payload);
        }

        //Down Button Clicked, Robot Backwards
        private void down_Click(object sender, RoutedEventArgs e)
        {
            byte[] payload = Encoding.UTF8.GetBytes("2");
            SendToRobot(payload);
        }

        //Right Button Clicked, Robot Right
        private void right_Click(object sender, RoutedEventArgs e)
        {
            byte[] payload = Encoding.UTF8.GetBytes("5");
            SendToRobot(payload);
        }

        //Stop Button clicked, Stop Robot
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            byte[] payload = Encoding.UTF8.GetBytes("3");
            SendToRobot(payload);
        }

        //Make Robot Dance
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            byte[] payload = Encoding.UTF8.GetBytes("6");
            SendToRobot(payload);
            Thread.Sleep(100);
            byte[] payload2 = Encoding.UTF8.GetBytes("3");
            SendToRobot(payload2);
        }


    }
}