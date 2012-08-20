#!/bin/sh

#  RobotController.sh
#  Created by David Bradshaw, Greg Fincher, Kelvin Hawkins, Brandon McNutt
#  for Capstone Project, Spring 2012
#  Designed for UNIX/LINUX systems, including Macintosh

echo "  +-------------------------------------------------------------------+"
echo "  | Hello, Welcome to the Java Robot Controller Application!          |"
echo "  | You can remotely control the Java Robot from Terminal!            |"
echo "  +-------------------------------------------------------------------+"
#Retrieve IP Address from User
printf "To start, please tell me the IP Address of the Robot: "
read ip_address
#Retrieve Port number from User
printf "Thanks!  Now I need the port number: "
read port_num
echo "Awesome!  Let me try to connect to $ip_address on port $port_num\n"
echo "-----------------------------------------------------------------------\n"
echo "While I try to connect, here are some instructions to help you out:\n"
echo "  +-------------------------------------------------------------------+"
echo "  | For Ease of use you can use the D-Pad group of characters below:  |"
echo "  | 'e' to go Forward, 'c' to go Backwards, 's' to go left,           |"
echo "  | 'f' to go Right, 'd' to Stop, and 'r' to Dance!                   |"
echo "  |                                                                   |"
echo "  |             Please ensure that Caps Lock is OFF                   |"
echo "  |                                                                   |"
echo "  | Type in your command, and hit enter to perform action.            |"
echo "  | At any time you can hit CTRL + ], to Exit the program             |"
echo "  | and CTRL + C to close your connection with the robot.             |"
echo "  +-------------------------------------------------------------------+\n"
echo "Please wait until you see the HELLO Message, before starting!\n"
#Start Telnet client
exec telnet $ip_address $port_num