namespace FrontEnd
{
    partial class ForgetPassForm
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
            fMailLabel = new Label();
            label2 = new Label();
            fMailBox = new TextBox();
            fLoginBox = new TextBox();
            forgetButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // fMailLabel
            // 
            fMailLabel.AutoSize = true;
            fMailLabel.Location = new Point(64, 72);
            fMailLabel.Name = "fMailLabel";
            fMailLabel.Size = new Size(74, 15);
            fMailLabel.TabIndex = 0;
            fMailLabel.Text = "Podaj e-mail";
            fMailLabel.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 116);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Podaj login";
            // 
            // fMailBox
            // 
            fMailBox.Location = new Point(188, 64);
            fMailBox.Name = "fMailBox";
            fMailBox.Size = new Size(100, 23);
            fMailBox.TabIndex = 2;
            // 
            // fLoginBox
            // 
            fLoginBox.Location = new Point(188, 113);
            fLoginBox.Name = "fLoginBox";
            fLoginBox.Size = new Size(100, 23);
            fLoginBox.TabIndex = 3;
            // 
            // forgetButton
            // 
            forgetButton.Location = new Point(120, 169);
            forgetButton.Name = "forgetButton";
            forgetButton.Size = new Size(112, 23);
            forgetButton.TabIndex = 4;
            forgetButton.Text = "Zrestartuj hasło";
            forgetButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 25);
            label1.Name = "label1";
            label1.Size = new Size(265, 15);
            label1.TabIndex = 5;
            label1.Text = "Aby zrestartować hasło, podaj dane użytkownika.";
            // 
            // ForgetPassForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 238);
            Controls.Add(label1);
            Controls.Add(forgetButton);
            Controls.Add(fLoginBox);
            Controls.Add(fMailBox);
            Controls.Add(label2);
            Controls.Add(fMailLabel);
            Name = "ForgetPassForm";
            Text = "Zrestartuj hasło";
            Load += ForgetPassForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label fMailLabel;
        private Label label2;
        private TextBox fMailBox;
        private TextBox fLoginBox;
        private Button forgetButton;
        private Label label1;
    }
}