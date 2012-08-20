namespace Java_Robot_Controller
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ForwardButton = new System.Windows.Forms.Button();
            this.BackwardButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.IP_Address = new System.Windows.Forms.TextBox();
            this.IP_Label = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.Port_Label = new System.Windows.Forms.Label();
            this.Port_Number = new System.Windows.Forms.TextBox();
            this.ReleaseButton = new System.Windows.Forms.Button();
            this.dpadGroup = new System.Windows.Forms.GroupBox();
            this.dance = new System.Windows.Forms.Button();
            this.trackGroup = new System.Windows.Forms.GroupBox();
            this.rightSpeed = new System.Windows.Forms.Label();
            this.leftSpeed = new System.Windows.Forms.Label();
            this.MasterControl = new System.Windows.Forms.TrackBar();
            this.rightControl = new System.Windows.Forms.TrackBar();
            this.leftControl = new System.Windows.Forms.TrackBar();
            this.dpadButton = new System.Windows.Forms.Button();
            this.trackButton = new System.Windows.Forms.Button();
            this.dpadGroup.SuspendLayout();
            this.trackGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MasterControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ForwardButton
            // 
            this.ForwardButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForwardButton.Location = new System.Drawing.Point(155, 47);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(121, 93);
            this.ForwardButton.TabIndex = 4;
            this.ForwardButton.Text = "Forward";
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.ForwardButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // BackwardButton
            // 
            this.BackwardButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BackwardButton.Location = new System.Drawing.Point(155, 228);
            this.BackwardButton.Name = "BackwardButton";
            this.BackwardButton.Size = new System.Drawing.Size(121, 93);
            this.BackwardButton.TabIndex = 8;
            this.BackwardButton.Text = "Backward";
            this.BackwardButton.UseVisualStyleBackColor = true;
            this.BackwardButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.BackwardButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button2_MouseUp);
            // 
            // RightButton
            // 
            this.RightButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RightButton.Location = new System.Drawing.Point(273, 138);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(121, 93);
            this.RightButton.TabIndex = 7;
            this.RightButton.Text = "Right";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button3_MouseDown);
            this.RightButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button3_MouseUp);
            // 
            // LeftButton
            // 
            this.LeftButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LeftButton.Location = new System.Drawing.Point(37, 138);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(121, 93);
            this.LeftButton.TabIndex = 5;
            this.LeftButton.Text = "Left";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button4_MouseDown);
            this.LeftButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button4_MouseUp);
            // 
            // IP_Address
            // 
            this.IP_Address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IP_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP_Address.Location = new System.Drawing.Point(16, 30);
            this.IP_Address.Name = "IP_Address";
            this.IP_Address.Size = new System.Drawing.Size(159, 30);
            this.IP_Address.TabIndex = 0;
            // 
            // IP_Label
            // 
            this.IP_Label.AutoSize = true;
            this.IP_Label.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.IP_Label.Location = new System.Drawing.Point(13, 14);
            this.IP_Label.Name = "IP_Label";
            this.IP_Label.Size = new System.Drawing.Size(102, 13);
            this.IP_Label.TabIndex = 9;
            this.IP_Label.Text = "IP Address of Robot";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConnectButton.Location = new System.Drawing.Point(358, 30);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(82, 30);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // Port_Label
            // 
            this.Port_Label.AutoSize = true;
            this.Port_Label.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Port_Label.Location = new System.Drawing.Point(190, 14);
            this.Port_Label.Name = "Port_Label";
            this.Port_Label.Size = new System.Drawing.Size(110, 13);
            this.Port_Label.TabIndex = 10;
            this.Port_Label.Text = "Port Number of Robot";
            // 
            // Port_Number
            // 
            this.Port_Number.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Port_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port_Number.Location = new System.Drawing.Point(193, 30);
            this.Port_Number.Name = "Port_Number";
            this.Port_Number.Size = new System.Drawing.Size(159, 30);
            this.Port_Number.TabIndex = 1;
            // 
            // ReleaseButton
            // 
            this.ReleaseButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ReleaseButton.Location = new System.Drawing.Point(446, 30);
            this.ReleaseButton.Name = "ReleaseButton";
            this.ReleaseButton.Size = new System.Drawing.Size(81, 30);
            this.ReleaseButton.TabIndex = 3;
            this.ReleaseButton.Text = "Exit";
            this.ReleaseButton.UseVisualStyleBackColor = true;
            this.ReleaseButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // dpadGroup
            // 
            this.dpadGroup.Controls.Add(this.dance);
            this.dpadGroup.Controls.Add(this.RightButton);
            this.dpadGroup.Controls.Add(this.ForwardButton);
            this.dpadGroup.Controls.Add(this.BackwardButton);
            this.dpadGroup.Controls.Add(this.LeftButton);
            this.dpadGroup.Enabled = false;
            this.dpadGroup.Location = new System.Drawing.Point(165, 114);
            this.dpadGroup.Name = "dpadGroup";
            this.dpadGroup.Size = new System.Drawing.Size(432, 368);
            this.dpadGroup.TabIndex = 13;
            this.dpadGroup.TabStop = false;
            this.dpadGroup.Text = "Directional Pad Controls";
            // 
            // dance
            // 
            this.dance.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dance.Location = new System.Drawing.Point(155, 137);
            this.dance.Name = "dance";
            this.dance.Size = new System.Drawing.Size(121, 93);
            this.dance.TabIndex = 9;
            this.dance.Text = "Dance!";
            this.dance.UseVisualStyleBackColor = true;
            this.dance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dance_MouseDown);
            this.dance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dance_MouseUp);
            // 
            // trackGroup
            // 
            this.trackGroup.Controls.Add(this.rightSpeed);
            this.trackGroup.Controls.Add(this.leftSpeed);
            this.trackGroup.Controls.Add(this.MasterControl);
            this.trackGroup.Controls.Add(this.rightControl);
            this.trackGroup.Controls.Add(this.leftControl);
            this.trackGroup.Location = new System.Drawing.Point(165, 114);
            this.trackGroup.Name = "trackGroup";
            this.trackGroup.Size = new System.Drawing.Size(432, 368);
            this.trackGroup.TabIndex = 14;
            this.trackGroup.TabStop = false;
            this.trackGroup.Text = "Track Controls";
            this.trackGroup.Visible = false;
            // 
            // rightSpeed
            // 
            this.rightSpeed.AutoSize = true;
            this.rightSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightSpeed.Location = new System.Drawing.Point(291, 169);
            this.rightSpeed.Name = "rightSpeed";
            this.rightSpeed.Size = new System.Drawing.Size(0, 25);
            this.rightSpeed.TabIndex = 8;
            // 
            // leftSpeed
            // 
            this.leftSpeed.AutoSize = true;
            this.leftSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftSpeed.Location = new System.Drawing.Point(88, 169);
            this.leftSpeed.Name = "leftSpeed";
            this.leftSpeed.Size = new System.Drawing.Size(0, 25);
            this.leftSpeed.TabIndex = 7;
            // 
            // MasterControl
            // 
            this.MasterControl.LargeChange = 1;
            this.MasterControl.Location = new System.Drawing.Point(198, 34);
            this.MasterControl.Maximum = 100;
            this.MasterControl.Name = "MasterControl";
            this.MasterControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.MasterControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MasterControl.Size = new System.Drawing.Size(45, 312);
            this.MasterControl.TabIndex = 6;
            this.MasterControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MasterControl.Value = 50;
            this.MasterControl.ValueChanged += new System.EventHandler(this.MasterControl_ValueChanged);
            // 
            // rightControl
            // 
            this.rightControl.LargeChange = 1;
            this.rightControl.Location = new System.Drawing.Point(359, 34);
            this.rightControl.Maximum = 100;
            this.rightControl.Name = "rightControl";
            this.rightControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.rightControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rightControl.Size = new System.Drawing.Size(45, 312);
            this.rightControl.TabIndex = 5;
            this.rightControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rightControl.Value = 50;
            this.rightControl.ValueChanged += new System.EventHandler(this.rightControl_ValueChanged);
            // 
            // leftControl
            // 
            this.leftControl.LargeChange = 1;
            this.leftControl.Location = new System.Drawing.Point(37, 34);
            this.leftControl.Maximum = 100;
            this.leftControl.Name = "leftControl";
            this.leftControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.leftControl.Size = new System.Drawing.Size(45, 312);
            this.leftControl.TabIndex = 4;
            this.leftControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.leftControl.Value = 50;
            this.leftControl.ValueChanged += new System.EventHandler(this.leftControl_ValueChanged);
            // 
            // dpadButton
            // 
            this.dpadButton.Location = new System.Drawing.Point(26, 224);
            this.dpadButton.Name = "dpadButton";
            this.dpadButton.Size = new System.Drawing.Size(99, 27);
            this.dpadButton.TabIndex = 15;
            this.dpadButton.Text = "Directional Pad";
            this.dpadButton.UseVisualStyleBackColor = true;
            this.dpadButton.Click += new System.EventHandler(this.dpadButton_Click);
            // 
            // trackButton
            // 
            this.trackButton.Location = new System.Drawing.Point(26, 313);
            this.trackButton.Name = "trackButton";
            this.trackButton.Size = new System.Drawing.Size(99, 27);
            this.trackButton.TabIndex = 16;
            this.trackButton.Text = "Track Controls";
            this.trackButton.UseVisualStyleBackColor = true;
            this.trackButton.Click += new System.EventHandler(this.trackButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 532);
            this.Controls.Add(this.trackButton);
            this.Controls.Add(this.dpadButton);
            this.Controls.Add(this.ReleaseButton);
            this.Controls.Add(this.Port_Label);
            this.Controls.Add(this.Port_Number);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.IP_Label);
            this.Controls.Add(this.IP_Address);
            this.Controls.Add(this.dpadGroup);
            this.Controls.Add(this.trackGroup);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.Text = "Java Robot Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dpadGroup.ResumeLayout(false);
            this.trackGroup.ResumeLayout(false);
            this.trackGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MasterControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button BackwardButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.TextBox IP_Address;
        private System.Windows.Forms.Label IP_Label;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label Port_Label;
        private System.Windows.Forms.TextBox Port_Number;
        private System.Windows.Forms.Button ReleaseButton;
        private System.Windows.Forms.GroupBox dpadGroup;
        private System.Windows.Forms.GroupBox trackGroup;
        private System.Windows.Forms.TrackBar MasterControl;
        private System.Windows.Forms.TrackBar rightControl;
        private System.Windows.Forms.TrackBar leftControl;
        private System.Windows.Forms.Button dpadButton;
        private System.Windows.Forms.Button trackButton;
        private System.Windows.Forms.Label rightSpeed;
        private System.Windows.Forms.Label leftSpeed;
        private System.Windows.Forms.Button dance;
    }
}

