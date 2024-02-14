namespace WinForms
{
    partial class RegisterForm
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
            rLoginLabel = new Label();
            rPassLabel = new Label();
            rPassLabel2 = new Label();
            rMailLabel = new Label();
            rLoginBox = new TextBox();
            rMailBox = new TextBox();
            rPassBox = new TextBox();
            rPass2Box = new TextBox();
            RegisterButton = new Button();
            rulesBox = new CheckBox();
            SuspendLayout();
            // 
            // rLoginLabel
            // 
            rLoginLabel.AutoSize = true;
            rLoginLabel.Location = new Point(67, 28);
            rLoginLabel.Name = "rLoginLabel";
            rLoginLabel.Size = new Size(70, 15);
            rLoginLabel.TabIndex = 0;
            rLoginLabel.Text = "Podaj login:";
            rLoginLabel.Click += label1_Click;
            // 
            // rPassLabel
            // 
            rPassLabel.AutoSize = true;
            rPassLabel.Location = new Point(67, 95);
            rPassLabel.Name = "rPassLabel";
            rPassLabel.Size = new Size(71, 15);
            rPassLabel.TabIndex = 1;
            rPassLabel.Text = "Podaj hasło:";
            // 
            // rPassLabel2
            // 
            rPassLabel2.AutoSize = true;
            rPassLabel2.Location = new Point(67, 126);
            rPassLabel2.Name = "rPassLabel2";
            rPassLabel2.Size = new Size(84, 15);
            rPassLabel2.TabIndex = 2;
            rPassLabel2.Text = "Powtórz hasło:";
            rPassLabel2.Click += label1_Click_1;
            // 
            // rMailLabel
            // 
            rMailLabel.AutoSize = true;
            rMailLabel.Location = new Point(67, 62);
            rMailLabel.Name = "rMailLabel";
            rMailLabel.Size = new Size(108, 15);
            rMailLabel.TabIndex = 3;
            rMailLabel.Text = "Podaj adres e-mail:";
            // 
            // rLoginBox
            // 
            rLoginBox.Location = new Point(184, 20);
            rLoginBox.Name = "rLoginBox";
            rLoginBox.Size = new Size(100, 23);
            rLoginBox.TabIndex = 4;
            rLoginBox.TextChanged += rLoginBox_TextChanged;
            // 
            // rMailBox
            // 
            rMailBox.Location = new Point(184, 54);
            rMailBox.Name = "rMailBox";
            rMailBox.Size = new Size(100, 23);
            rMailBox.TabIndex = 5;
            // 
            // rPassBox
            // 
            rPassBox.Location = new Point(184, 87);
            rPassBox.Name = "rPassBox";
            rPassBox.Size = new Size(100, 23);
            rPassBox.TabIndex = 6;
            // 
            // rPass2Box
            // 
            rPass2Box.Location = new Point(184, 118);
            rPass2Box.Name = "rPass2Box";
            rPass2Box.Size = new Size(100, 23);
            rPass2Box.TabIndex = 7;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(193, 194);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(75, 23);
            RegisterButton.TabIndex = 8;
            RegisterButton.Text = "Zarejestruj";
            RegisterButton.UseVisualStyleBackColor = true;
            // 
            // rulesBox
            // 
            rulesBox.AutoSize = true;
            rulesBox.Location = new Point(67, 158);
            rulesBox.Name = "rulesBox";
            rulesBox.Size = new Size(139, 19);
            rulesBox.TabIndex = 9;
            rulesBox.Text = "Akceptuję Regulamin";
            rulesBox.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(424, 252);
            Controls.Add(rulesBox);
            Controls.Add(RegisterButton);
            Controls.Add(rPass2Box);
            Controls.Add(rPassBox);
            Controls.Add(rMailBox);
            Controls.Add(rLoginBox);
            Controls.Add(rMailLabel);
            Controls.Add(rPassLabel2);
            Controls.Add(rPassLabel);
            Controls.Add(rLoginLabel);
            MinimizeBox = false;
            Name = "RegisterForm";
            Text = "Rejestracja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label rLoginLabel;
        private Label rPassLabel;
        private Label rPassLabel2;
        private Label rMailLabel;
        private TextBox rLoginBox;
        private TextBox rMailBox;
        private TextBox rPassBox;
        private TextBox rPass2Box;
        private Button RegisterButton;
        private CheckBox rulesBox;
    }
}