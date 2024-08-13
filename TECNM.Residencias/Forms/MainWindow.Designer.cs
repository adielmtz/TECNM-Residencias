namespace TECNM.Residencias.Forms
{
    partial class MainWindow
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
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            button4 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(415, 138);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(99, 87);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "Carreras";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ShowCareers_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(117, 138);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(99, 87);
            button2.TabIndex = 1;
            button2.TabStop = false;
            button2.Text = "Empresas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ShowCompanies_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(12, 138);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(99, 87);
            button3.TabIndex = 2;
            button3.TabStop = false;
            button3.Text = "Residentes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ShowStudents_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Corbel", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,  0);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(502, 59);
            label1.TabIndex = 3;
            label1.Text = "Panel de administración";
            // 
            // button4
            // 
            button4.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button4.Location = new System.Drawing.Point(1131, 635);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(121, 34);
            button4.TabIndex = 4;
            button4.TabStop = false;
            button4.Text = "Configuración";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ShowSettings_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "MainWindow";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += MainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
    }
}