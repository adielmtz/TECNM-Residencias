namespace TECNM.Residencias.Forms
{
    partial class SettingsForm
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
            lbl_SqliteVersion = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_SqliteVersion
            // 
            lbl_SqliteVersion.AutoSize = true;
            lbl_SqliteVersion.Location = new System.Drawing.Point(12, 426);
            lbl_SqliteVersion.Name = "lbl_SqliteVersion";
            lbl_SqliteVersion.Size = new System.Drawing.Size(101, 15);
            lbl_SqliteVersion.TabIndex = 0;
            lbl_SqliteVersion.Text = "[SQLITE VERSION]";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(236, 59);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Base de datos";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(87, 22);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(143, 23);
            button2.TabIndex = 2;
            button2.Text = "Verificar integridad";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DatabaseCheckIntegrity_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(6, 22);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Optimizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DatabaseOptimize_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(lbl_SqliteVersion);
            Name = "SettingsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_SqliteVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}