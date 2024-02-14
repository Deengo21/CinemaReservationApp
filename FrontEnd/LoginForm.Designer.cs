namespace WinForms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            passwordBox = new TextBox();
            label2 = new Label();
            loginBox = new TextBox();
            passForgetLabel = new LinkLabel();
            Cinema = new GroupBox();
            groupBox1 = new GroupBox();
            registerLabel = new LinkLabel();
            loginButton = new Button();
            Cinema.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 36);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(134, 75);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(100, 23);
            passwordBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 78);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "Hasło";
            label2.Click += label2_Click;
            // 
            // loginBox
            // 
            loginBox.Location = new Point(134, 33);
            loginBox.Name = "loginBox";
            loginBox.Size = new Size(100, 23);
            loginBox.TabIndex = 3;
            // 
            // passForgetLabel
            // 
            passForgetLabel.AutoSize = true;
            passForgetLabel.Location = new Point(16, 123);
            passForgetLabel.Name = "passForgetLabel";
            passForgetLabel.Size = new Size(110, 15);
            passForgetLabel.TabIndex = 5;
            passForgetLabel.TabStop = true;
            passForgetLabel.Text = "Zapomniałeś hasła?";
            passForgetLabel.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Cinema
            // 
            Cinema.Controls.Add(loginButton);
            Cinema.Controls.Add(loginBox);
            Cinema.Controls.Add(passForgetLabel);
            Cinema.Controls.Add(label1);
            Cinema.Controls.Add(label2);
            Cinema.Controls.Add(passwordBox);
            Cinema.Location = new Point(38, 26);
            Cinema.Name = "Cinema";
            Cinema.Size = new Size(263, 179);
            Cinema.TabIndex = 6;
            Cinema.TabStop = false;
            Cinema.Text = "Logowanie";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(registerLabel);
            groupBox1.Location = new Point(347, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(138, 93);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nie masz konta?";
            // 
            // registerLabel
            // 
            registerLabel.AutoSize = true;
            registerLabel.Location = new Point(29, 37);
            registerLabel.Name = "registerLabel";
            registerLabel.Size = new Size(62, 15);
            registerLabel.TabIndex = 0;
            registerLabel.TabStop = true;
            registerLabel.Text = "Zarejestruj";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(159, 119);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 6;
            loginButton.Text = "Zaloguj";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 232);
            Controls.Add(groupBox1);
            Controls.Add(Cinema);
            Name = "LoginForm";
            Text = "Kino";
            Cinema.ResumeLayout(false);
            Cinema.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox passwordBox;
        private Label label2;
        private TextBox loginBox;
        private LinkLabel passForgetLabel;
        private GroupBox Cinema;
        private GroupBox groupBox1;
        private LinkLabel registerLabel;
        private Button loginButton;
    }
}
