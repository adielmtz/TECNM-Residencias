namespace TECNM.Residencias.Forms.ReportForms
{
    partial class ReportMainPanelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportMainPanelForm));
            cb_Semester = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            cb_Year = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // cb_Semester
            // 
            cb_Semester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_Semester.FormattingEnabled = true;
            cb_Semester.Items.AddRange(new object[] { "Todo", "ENE-JUN", "AGO-DIC" });
            cb_Semester.Location = new System.Drawing.Point(12, 27);
            cb_Semester.Name = "cb_Semester";
            cb_Semester.Size = new System.Drawing.Size(146, 23);
            cb_Semester.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 15);
            label1.TabIndex = 6;
            label1.Text = "Semestre";
            // 
            // cb_Year
            // 
            cb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_Year.FormattingEnabled = true;
            cb_Year.Location = new System.Drawing.Point(164, 27);
            cb_Year.Name = "cb_Year";
            cb_Year.Size = new System.Drawing.Size(121, 23);
            cb_Year.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(164, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(32, 15);
            label2.TabIndex = 8;
            label2.Text = "Año:";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 56);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Generar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += GenerateStats_Click;
            // 
            // ReportMainPanelForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(cb_Year);
            Controls.Add(label1);
            Controls.Add(cb_Semester);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "ReportMainPanelForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ReportMainPanelForm";
            Load += ReportMainPanelForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Semester;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
