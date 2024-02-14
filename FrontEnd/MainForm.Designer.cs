namespace WinForms
{
    partial class MainForm
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
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Tytuł = new DataGridViewTextBoxColumn();
            Godzina = new DataGridViewTextBoxColumn();
            Miejsca = new DataGridViewTextBoxColumn();
            Szczegóły = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(174, 30);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Tytuł, Godzina, Miejsca, Szczegóły });
            dataGridView1.Location = new Point(-5, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(544, 301);
            dataGridView1.TabIndex = 1;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // Tytuł
            // 
            Tytuł.HeaderText = "Tytuł";
            Tytuł.Name = "Tytuł";
            // 
            // Godzina
            // 
            Godzina.HeaderText = "Godzina";
            Godzina.Name = "Godzina";
            // 
            // Miejsca
            // 
            Miejsca.HeaderText = "Miejsca";
            Miejsca.Name = "Miejsca";
            // 
            // Szczegóły
            // 
            Szczegóły.HeaderText = "Szczegóły";
            Szczegóły.Name = "Szczegóły";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 359);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker1);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Tytuł;
        private DataGridViewTextBoxColumn Godzina;
        private DataGridViewTextBoxColumn Miejsca;
        private DataGridViewTextBoxColumn Szczegóły;
    }
}