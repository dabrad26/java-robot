package javaRobot.Controller;

//Java Robot Controller for Android
//David Bradshaw, Kelvin Hawkins, Brandon McNutt, Greg Fincher
//Capstone Project, Spring 2012

import java.io.DataOutputStream;
import java.net.Socket;
import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RelativeLayout;


public class Java_Robot_ControllerActivity extends Activity {
	
	Socket socketConnection;
	DataOutputStream toRobot = null;
	
	RelativeLayout connection;
	RelativeLayout dpadWindow;
	RelativeLayout errorWindow;
	
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
    	connection = (RelativeLayout)findViewById(R.id.connector);
        dpadWindow = (RelativeLayout)findViewById(R.id.dPad);
    	errorWindow = (RelativeLayout)findViewById(R.id.errorMsg);
        
        connection .setVisibility(View.VISIBLE);
        dpadWindow.setVisibility(View.GONE);
        errorWindow.setVisibility(View.GONE);
    
    final Button buttonReset = (Button) findViewById(R.id.resetBtn);
    buttonReset.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {
        	final EditText ipBox = (EditText) findViewById(R.id.ipText);
        	final EditText portBox = (EditText) findViewById(R.id.portText);
        	
        	ipBox.setText("");
        	portBox.setText("");
        }
    });
    
    final Button buttonConnect = (Button) findViewById(R.id.connectBtn);
    buttonConnect.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {
        	final EditText ipBox = (EditText) findViewById(R.id.ipText);
        	final EditText portBox = (EditText) findViewById(R.id.portText);
        	
        	try
        	{
        	String ipAddress = ipBox.getText().toString().trim();
        	int portNumber = Integer.parseInt(portBox.getText().toString().trim());
        	connectToRobot(ipAddress, portNumber);
        	}
        	catch(Exception ex)
        	{
        		errorMSG();
        	}
        }
    });
    
    final Button buttonUp = (Button) findViewById(R.id.up_button);
    buttonUp.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {

        	sendMessage("1");
        }
    });
    
    final Button buttonDown = (Button) findViewById(R.id.down_button);
    buttonDown.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {

        	sendMessage("2");
        }
    });
    
    final Button buttonLeft = (Button) findViewById(R.id.left_button);
    buttonLeft.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {

        	sendMessage("4");
        }
    });
    
    final Button buttonRight = (Button) findViewById(R.id.right_button);
    buttonRight.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {

        	sendMessage("5");
        }
    });
    
    final Button buttonStop = (Button) findViewById(R.id.stop_button);
    buttonStop.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {

        	sendMessage("3");
        }
    });
    
    final Button buttonDance = (Button) findViewById(R.id.dance_button);
    buttonDance.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {

        	sendMessage("6");
        }
    });
    
    
    final Button buttonDisconnectDPAD = (Button) findViewById(R.id.dpad_disconnect);
    buttonDisconnectDPAD.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {

        	disconnect();
        }
    });
    
    
    final Button errorButton = (Button) findViewById(R.id.errorOK);
    errorButton.setOnClickListener(new View.OnClickListener() {
        public void onClick(View v) {

            connection .setVisibility(View.VISIBLE);
            dpadWindow.setVisibility(View.GONE);
            errorWindow.setVisibility(View.GONE);
        }
    });
    
    
    }
    
    public void connectToRobot(String ipAddress, int portNumber)
    {
    	try{
    	socketConnection = new Socket(ipAddress, portNumber);
    	//toRobot = socketConnection.getOutputStream(); 
    	//output = new PrintWriter(toRobot);
    	toRobot = new DataOutputStream(socketConnection.getOutputStream());
    	
    	
        connection .setVisibility(View.GONE);
        dpadWindow.setVisibility(View.VISIBLE);
        errorWindow.setVisibility(View.GONE);
         
    	}
    	catch (Exception ex)
    	{
    		errorMSG();
    	}
    	}
    
    void sendMessage(String msg)
	{
		try{
			toRobot.writeBytes(msg);
		}
		catch(Exception ex){
			errorMSG();
		}
	}
    
    void disconnect()
    {
    	try{
            connection .setVisibility(View.VISIBLE);
            dpadWindow.setVisibility(View.GONE);
            errorWindow.setVisibility(View.GONE);
			toRobot.flush();
			toRobot.close();
			socketConnection.close();
		}
		catch(Exception ex){
	        connection .setVisibility(View.VISIBLE);
	        dpadWindow.setVisibility(View.GONE);
	        errorWindow.setVisibility(View.GONE);
		}
    	
    }
    
    
    
    public void errorMSG()
    {
        connection .setVisibility(View.GONE);
        dpadWindow.setVisibility(View.GONE);
        errorWindow.setVisibility(View.VISIBLE);
    }
}