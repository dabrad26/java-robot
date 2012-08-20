using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

//Capstone Project, Spring 2012, David Bradshaw, Gregory Fincher, Kelvin Hawkins, Brandon McNutt
//C Sharp Code Behind for Windows Application

namespace Java_Robot_Controller
{

    public partial class Form1 : Form
    {

  
        public Form1()
        {
            InitializeComponent();
            dpadButton.Enabled = false;
            trackButton.Enabled = false;
        }

        //Create Socket Variables
        public NetworkStream toRobot;
        public string fromRobot;
        
        //Create Global Variables
        int rightValue = 50;
        int leftValue = 50;


        //Connect button Pressed
        public void button5_Click(object sender, EventArgs e)
        {
            //Try to connect
            try
            {
                System.Net.Sockets.TcpClient socket = new System.Net.Sockets.TcpClient();
                String IP_address = IP_Address.Text;
                byte[] inStream = new byte[10025];
                int port_number = Int32.Parse(Port_Number.Text);
                socket.Connect(IP_address, port_number);
                ConnectButton.Enabled = false;
                trackButton.Enabled = true;
                dpadGroup.Enabled = true;

                toRobot = socket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Connected!");
                toRobot.Write(outStream, 0, outStream.Length);
                toRobot.Flush();

                
                toRobot.Read(inStream, 0, (int)socket.ReceiveBufferSize);
                fromRobot = System.Text.Encoding.ASCII.GetString(inStream);

            }
                //Unable to connect, show error Message
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
                ConnectButton.Enabled = true;
            }
        }

        //Forward Released, Stop Robot
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)51;
                
                toRobot.Write(command, 0, 1);


            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)51;
                toRobot.Write(command, 0, 1);

            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        //Stop Robot
        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)51;
                toRobot.Write(command, 0, 1);
            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        //Stop Robot
        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)51;
                toRobot.Write(command, 0, 1);
            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        //Forward Down, Robot go Forward
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)49;
                toRobot.Write(command, 0, 1);
  
            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        //Robot Needs to Move
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)52;
                toRobot.Write(command, 0, 1);
  
            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        //Robot needs to move
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)53;
                toRobot.Write(command, 0, 1);

            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }
        
        //Robot Needs to move
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)50;
                toRobot.Write(command, 0, 1);

            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        //Exit Pressed, Kill Application
        private void button6_Click(object sender, EventArgs e)
        {
            //Attempt to Disconnect then Close
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)51;
                toRobot.Write(command, 0, 1);
                toRobot.Close();
                Application.Exit();
            }
            catch
            {
                Application.Exit();
                
            }
        }

        //Dance
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)51;
                toRobot.Write(command, 0, 1); 
            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        //Right Stick changed, convert to match wheel schema
        private void rightControl_ValueChanged(object sender, EventArgs e)
        {
            int correctedValue = 0;
            if (rightControl.Value > 50)
            {
                correctedValue = 50 - (rightControl.Value - 50);
            }
            else if (rightControl.Value < 50)
            {
                correctedValue = 50 + (50 - rightControl.Value);
            }
            else
            {
                correctedValue = rightControl.Value;
            }
            rightSpeed.Text = rightControl.Value.ToString();
            rightValue = correctedValue;
            sendCommands();
        }

        //Left Stick changed
        private void leftControl_ValueChanged(object sender, EventArgs e)
        {
            leftSpeed.Text = leftControl.Value.ToString();
            leftValue = leftControl.Value;
            sendCommands();
        }
        
        //Send commands
        public void sendCommands()
        {
            byte[] command = new byte[3];
            command[0] = (byte)64;
            command[1] = (byte)leftValue;
            command[2] = (byte)rightValue;
            toRobot.Write(command, 0, 3);
        }

        //Center Value changed convert both
        private void MasterControl_ValueChanged(object sender, EventArgs e)
        {
            leftControl.Value = MasterControl.Value;
            rightControl.Value = MasterControl.Value;
        }

        //Switch to Stick Controls
        private void trackButton_Click(object sender, EventArgs e)
        {
            dpadGroup.Visible = false;
            trackGroup.Visible = true;
            trackButton.Enabled = false;
            dpadButton.Enabled = true;
        }

        //Switch to DPAD controls
        private void dpadButton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)51;
                toRobot.Write(command, 0, 1);
            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }

            trackGroup.Visible = false;
            dpadGroup.Visible = true;
            dpadButton.Enabled = false;
            trackButton.Enabled = true;
        }

        //Dance Pressed
        private void dance_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)54;
                toRobot.Write(command, 0, 1);
            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }

        //Stop Dancing
        private void dance_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                byte[] command = new byte[1];
                command[0] = (byte)51;
                toRobot.Write(command, 0, 1);
            }
            catch
            {
                MessageBox.Show("The IP Address or Port Could not be found!\nPlease Make sure it is valid and Online!");
            }
        }


    }
}
