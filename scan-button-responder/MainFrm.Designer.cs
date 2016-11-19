namespace scan_button_responder
{
    partial class MainFrm
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbDevice = new System.Windows.Forms.Label();
            this.lbEvent = new System.Windows.Forms.Label();
            this.tbEventName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbProfiles = new System.Windows.Forms.ComboBox();
            this.lbFileName = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save Event";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbDevice
            // 
            this.lbDevice.AutoSize = true;
            this.lbDevice.Location = new System.Drawing.Point(24, 61);
            this.lbDevice.Name = "lbDevice";
            this.lbDevice.Size = new System.Drawing.Size(49, 13);
            this.lbDevice.TabIndex = 1;
            this.lbDevice.Text = "lbDevice";
            // 
            // lbEvent
            // 
            this.lbEvent.AutoSize = true;
            this.lbEvent.Location = new System.Drawing.Point(24, 85);
            this.lbEvent.Name = "lbEvent";
            this.lbEvent.Size = new System.Drawing.Size(43, 13);
            this.lbEvent.TabIndex = 2;
            this.lbEvent.Text = "lbEvent";
            // 
            // tbEventName
            // 
            this.tbEventName.Location = new System.Drawing.Point(12, 112);
            this.tbEventName.Name = "tbEventName";
            this.tbEventName.Size = new System.Drawing.Size(100, 20);
            this.tbEventName.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(289, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Scan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbProfiles
            // 
            this.cbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfiles.FormattingEnabled = true;
            this.cbProfiles.Location = new System.Drawing.Point(118, 111);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Size = new System.Drawing.Size(165, 21);
            this.cbProfiles.TabIndex = 6;
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(12, 154);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(59, 13);
            this.lbFileName.TabIndex = 7;
            this.lbFileName.Text = "lbFileName";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(15, 208);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(268, 20);
            this.tbFileName.TabIndex = 8;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 340);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.cbProfiles);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbEventName);
            this.Controls.Add(this.lbEvent);
            this.Controls.Add(this.lbDevice);
            this.Controls.Add(this.button1);
            this.Name = "MainFrm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbDevice;
        private System.Windows.Forms.Label lbEvent;
        private System.Windows.Forms.TextBox tbEventName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.TextBox tbFileName;
    }
}

