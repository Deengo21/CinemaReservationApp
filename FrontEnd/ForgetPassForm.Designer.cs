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
            this.fMailLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fMailBox = new System.Windows.Forms.TextBox();
            this.fLoginBox = new System.Windows.Forms.TextBox();
            this.forgetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fMailLabel
            // 
            this.fMailLabel.AutoSize = true;
            this.fMailLabel.Location = new System.Drawing.Point(64, 72);
            this.fMailLabel.Name = "fMailLabel";
            this.fMailLabel.Size = new System.Drawing.Size(74, 15);
            this.fMailLabel.TabIndex = 0;
            this.fMailLabel.Text = "Podaj e-mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Podaj login";
            // 
            // fMailBox
            // 
            this.fMailBox.Location = new System.Drawing.Point(188, 64);
            this.fMailBox.Name = "fMailBox";
            this.fMailBox.Size = new System.Drawing.Size(100, 23);
            this.fMailBox.TabIndex = 2;
            this.fMailBox.TextChanged += new System.EventHandler(this.fMailBox_TextChanged);
            // 
            // fLoginBox
            // 
            this.fLoginBox.Location = new System.Drawing.Point(188, 113);
            this.fLoginBox.Name = "fLoginBox";
            this.fLoginBox.Size = new System.Drawing.Size(100, 23);
            this.fLoginBox.TabIndex = 3;
            // 
            // forgetButton
            // 
            this.forgetButton.Location = new System.Drawing.Point(120, 169);
            this.forgetButton.Name = "forgetButton";
            this.forgetButton.Size = new System.Drawing.Size(112, 23);
            this.forgetButton.TabIndex = 4;
            this.forgetButton.Text = "Zrestartuj hasło";
            this.forgetButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Aby zrestartować hasło, podaj dane użytkownika.";
            // 
            // ForgetPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 238);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.forgetButton);
            this.Controls.Add(this.fLoginBox);
            this.Controls.Add(this.fMailBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fMailLabel);
            this.Name = "ForgetPassForm";
            this.Text = "Zrestartuj hasło";
            this.ResumeLayout(false);
            this.PerformLayout();

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