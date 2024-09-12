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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            lbl_SqliteVersion = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(236, 83);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Base de datos";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(6, 51);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(132, 23);
            button3.TabIndex = 3;
            button3.Text = "Copia de seguridad";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DatabaseBackup_Click;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new System.Drawing.Point(541, 366);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(247, 72);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Créditos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 34);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(184, 15);
            label3.TabIndex = 5;
            label3.Text = "20070517 : Rafael García Mendoza";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 49);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(179, 15);
            label2.TabIndex = 4;
            label2.Text = "20070525 : Samuel Alva Segundo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(232, 15);
            label1.TabIndex = 3;
            label1.Text = "18070602 : Luis Adiel Jesús Martínez Garcés";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(705, 348);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(83, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Código fuente";
            linkLabel1.LinkClicked += SourceCodeGitHub_LinkClicked;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lbl_SqliteVersion);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_SqliteVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
