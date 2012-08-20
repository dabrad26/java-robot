//David Bradshaw, Gregory Fincher, Kelvin Hawkins, Brandon McNutt
//Captsone Project, CSCI 4940, Spring 2012

import com.ridgesoft.io.Display;
import com.ridgesoft.intellibrain.IntelliBrain;
import com.ridgesoft.robotics.PulseInput;
import com.ridgesoft.robotics.Servo;
import com.ridgesoft.robotics.PushButton;
import com.ridgesoft.robotics.RangeFinder;
import com.ridgesoft.robotics.sensors.SharpGP2D12;
import com.ridgesoft.robotics.sensors.ParallaxPing;
import javax.comm.CommPort;
import javax.comm.SerialPort;
import java.io.*;
import java.util.*;
import java.lang.Thread;

public class Capstone {

    //Create Global Variables
    static Servo leftServo = IntelliBrain.getServo(1);
    static Servo rightServo = IntelliBrain.getServo(2);
    static Display display = IntelliBrain.getLcdDisplay();
    static PushButton startButton = IntelliBrain.getStartButton();
    static PushButton stopButton = IntelliBrain.getStopButton();
    static RangeFinder rangeFinderIR = new SharpGP2D12(IntelliBrain.getAnalogInput(1), null);
    static RangeFinder rangeFinderIR2 = new SharpGP2D12(IntelliBrain.getAnalogInput(2), null);
    static RangeFinder rangeFinderSONAR = new ParallaxPing(IntelliBrain.getDigitalIO(3));
    static int command = 1;
    static InputStream inputStream;
    static OutputStream outputStream;
    static int collide = 0;
    static int checkIt = 0;
    static int rightStick = 50;
    static int leftStick = 50;
    static int joy = 0;
    static int joyCrash = 0;

    public static void main(String args[]) {

        //Create Streams
        try {
            SerialPort comPort = IntelliBrain.getCom1();
            comPort.setSerialPortParams(115200, SerialPort.DATABITS_8,
                    SerialPort.STOPBITS_1, SerialPort.PARITY_NONE);
            inputStream = comPort.getInputStream();
            outputStream = comPort.getOutputStream();
        } catch (Throwable t) {
            t.printStackTrace();
        }

        //Check for new commands
        while (true) {
            try {

                //Avoid Blocking
                if (inputStream.available() > 0) {
                    command = inputStream.read();
                

                    //Catch Joystick Packets, start with @ sign
                    if (command == 64) {
                        
                        int tempLeft = inputStream.read();
                        int tempRight = inputStream.read();
                        
                        if ((joyCrash == 1) && (tempLeft > 50) && (tempRight < 50))
                        {
                            leftStick = 50;
                            rightStick = 50;
                        }
                        else if ((joyCrash == 2) && (tempLeft < 50) && (tempRight > 50))
                        {
                            leftStick = 50;
                            rightStick = 50;
                        }
                        else
                        {
                            joy = 1;
                            joyCrash = 0;
                            leftStick = tempLeft;
                            rightStick = tempRight;
                        }
                }
                }

                //Joystick Controls called
                if (joy == 1) {
                    if ((leftStick > 50) && (rightStick < 50)) {
                        checkIt = 1;
                    } else if ((leftStick < 50) && (rightStick > 50)) {
                        checkIt = 2;
                    }
                    joystick(leftStick, rightStick);
                }

                //Drive Forward Command
                if ((command == 49) || (command == 101)) {
                    joy = 0;
                    joyCrash = 0;
                    collide = 0;
                    checkIt = 1;
                    forward_go();
                }

                //Drive Backward Command
                if ((command == 50) || (command == 99)) {
                    joy = 0;
                    joyCrash = 0;
                    collide = 0;
                    checkIt = 2;
                    backwards_go();
                }

                //Stop Robot Command
                if ((command == 51) || (command == 100)) {
                    joy = 0;
                    joyCrash = 0;
                    collide = 0;
                    checkIt = 0;
                    stop();
                }

                //Turn Left Command
                if ((command == 52) || (command == 115)) {
                    joy = 0;
                    joyCrash = 0;
                    collide = 0;
                    checkIt = 0;
                    turn_left();
                }

                //Turn Right Command
                if ((command == 53) || (command == 102)) {
                    joy = 0;
                    joyCrash = 0;
                    collide = 0;
                    checkIt = 0;
                    turn_right();
                }

                //Dance!
                if ((command == 54) || (command == 114)) {
                    joy = 0;
                    joyCrash = 0;
                    collide = 0;
                    checkIt = 0;
                    dance();
                }

                //If called, start sonar detection while driving
                if (checkIt == 1) {
                    check_sonar();
                }

                //If called, start IR detection while drving
                if (checkIt == 2) {
                    check_IR();
                }

                //Crash Detected, stop!
                if (collide == 2) {
                    command = 0;
                    leftStick = 50;
                    rightStick = 50;
                    stop();
                    display.print(0, "Danger of");
                    display.print(1, "Crashing...");
                    
                    //Crash Caused by Joystick, prevent second
                    if (joy == 1)
                    {
                        if (checkIt == 1)
                        {
                            joyCrash = 1;
                        }
                        else if (checkIt == 2)
                        {
                            joyCrash = 2;
                        }
                    }
                    
                    try {
                        byte[] error = "Danger of Crashing\n".getBytes();
                        outputStream.write(error);

                    } catch (Throwable t) {
                        t.printStackTrace();
                    }
                    checkIt = 0;
                    collide = 0;
                }

                //Sleep (to avoid over use of processor, reset command
                Thread.sleep(50);
                command = 0;

            } catch (Throwable t) {
                t.printStackTrace();
            }
        }

    }

    //Check Sonar as driving
    public static void check_sonar() {
        rangeFinderSONAR.ping();
        try {
            Thread.sleep(50);

        } catch (Throwable t) {
            t.printStackTrace();
        }
        float distanceSONAR = rangeFinderSONAR.getDistanceInches();

        if ((distanceSONAR < 6.0f) && (distanceSONAR > 0.0f)) {
            collide = 2;
        }

    }

    //Check IR as driving
    public static void check_IR() {
        rangeFinderIR.ping();
        rangeFinderIR2.ping();
        float distanceIR = rangeFinderIR.getDistanceInches();
        float distanceIR2 = rangeFinderIR2.getDistanceInches();

        if (((distanceIR < 8.0) && (distanceIR > 0.0))) {
            collide = 2;
        } else if (((distanceIR2 < 8.0) && (distanceIR2 > 0.0))) {

            collide = 2;
        }
    }

    //Dance Command, Random Dance
    public static void dance() {

        Random generator = new Random();
        for (int n = 1; n < 50; n++) {
            leftServo.setPosition(generator.nextInt());
            rightServo.setPosition(generator.nextInt());
            try {
                Thread.sleep(100);
            } catch (Throwable t) {
                t.printStackTrace();
            }
        }
        stop();
    }

    //Turn Wheels forward at full Speed
    public static void forward_go() {
        display.print(0, "Driving Forward");
        display.print(1, "      Driving...");
        leftServo.setPosition(100);
        rightServo.setPosition(0);


        try {
            byte[] msg = "Driving Forward\n".getBytes();
            outputStream.write(msg);

        } catch (Throwable t) {
            t.printStackTrace();
        }


    }

    //Allow intermediate speeds through Joystick
    public static void joystick(int left, int right) {
        display.print(0, "Joystick Control");
        display.print(1, "      Driving...");

        leftServo.setPosition(left);
        rightServo.setPosition(right);


        try {
            byte[] msg = "Joystick Control\n".getBytes();
            outputStream.write(msg);

        } catch (Throwable t) {
            t.printStackTrace();
        }


    }

    //Stop Wheels
    public static void stop() {
        display.print(0, "Sitting Still");
        display.print(1, "      Waiting...");
        leftServo.off();
        rightServo.off();
        try {
            byte[] msg = "Sitting Still\n".getBytes();
            outputStream.write(msg);

        } catch (Throwable t) {
            t.printStackTrace();
        }
    }

    //Turn wheels opposite directions at full speed to go right
    public static void turn_right() {
        display.print(0, "Turning Right");
        display.print(1, "      Turning...");
        leftServo.setPosition(100);
        rightServo.setPosition(100);
        try {
            byte[] msg = "Turning Right\n".getBytes();
            outputStream.write(msg);

        } catch (Throwable t) {
            t.printStackTrace();
        }
    }
    //Turn wheels opposite directions at full speed to go left

    public static void turn_left() {
        display.print(0, "Turning Left");
        display.print(1, "      Turning...");
        leftServo.setPosition(0);
        rightServo.setPosition(0);
        try {
            byte[] msg = "Turning Left\n".getBytes();
            outputStream.write(msg);

        } catch (Throwable t) {
            t.printStackTrace();
        }
    }

    //Both wheels full power backwards
    public static void backwards_go() {
        display.print(0, "Driving Backwards");
        display.print(1, "      Driving...");
        leftServo.setPosition(0);
        rightServo.setPosition(100);

        try {
            byte[] msg = "Driving Backwards\n".getBytes();
            outputStream.write(msg);

        } catch (Throwable t) {
            t.printStackTrace();
        }


    }
}
