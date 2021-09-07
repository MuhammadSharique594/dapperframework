namespace DapperModels
{
    partial class DapperModelCreator
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
            this.label1 = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DatabasesDropDown = new System.Windows.Forms.ComboBox();
            this.Start = new System.Windows.Forms.Button();
            this.OutputPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Testing = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name:";
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(28, 57);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(413, 20);
            this.ServerName.TabIndex = 1;
            this.ServerName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Password);
            this.groupBox1.Controls.Add(this.UserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(28, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log on to the server";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(98, 65);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(292, 20);
            this.Password.TabIndex = 5;
            this.Password.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(98, 33);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(292, 20);
            this.UserName.TabIndex = 3;
            this.UserName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DatabasesDropDown);
            this.groupBox2.Location = new System.Drawing.Point(28, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 61);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connect to a database";
            // 
            // DatabasesDropDown
            // 
            this.DatabasesDropDown.FormattingEnabled = true;
            this.DatabasesDropDown.Location = new System.Drawing.Point(7, 23);
            this.DatabasesDropDown.Name = "DatabasesDropDown";
            this.DatabasesDropDown.Size = new System.Drawing.Size(400, 21);
            this.DatabasesDropDown.TabIndex = 0;
            this.DatabasesDropDown.SelectedValueChanged += new System.EventHandler(this.DatabasesDropDown_SelectedValueChanged);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(332, 26);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 7;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // OutputPath
            // 
            this.OutputPath.Location = new System.Drawing.Point(7, 28);
            this.OutputPath.Name = "OutputPath";
            this.OutputPath.Size = new System.Drawing.Size(317, 20);
            this.OutputPath.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OutputPath);
            this.groupBox3.Controls.Add(this.Start);
            this.groupBox3.Location = new System.Drawing.Point(28, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(413, 61);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Start Generating";
            // 
            // Testing
            // 
            this.Testing.Location = new System.Drawing.Point(28, 394);
            this.Testing.Name = "Testing";
            this.Testing.Size = new System.Drawing.Size(413, 23);
            this.Testing.TabIndex = 9;
            this.Testing.Text = "Test";
            this.Testing.UseVisualStyleBackColor = true;
            this.Testing.Click += new System.EventHandler(this.Testing_Click);
            // 
            // DapperModelCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 559);
            this.Controls.Add(this.Testing);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(484, 598);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(484, 598);
            this.Name = "DapperModelCreator";
            this.Text = "DapperModelCreator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox DatabasesDropDown;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox OutputPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Testing;
    }
}

