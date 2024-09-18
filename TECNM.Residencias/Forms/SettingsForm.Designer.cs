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
            lbl_AppVersion = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox6 = new System.Windows.Forms.GroupBox();
            cb_StudentCareer = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            cb_CompanyType = new System.Windows.Forms.ComboBox();
            button4 = new System.Windows.Forms.Button();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            cb_AdvisorType = new System.Windows.Forms.ComboBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_SqliteVersion
            // 
            lbl_SqliteVersion.AutoSize = true;
            lbl_SqliteVersion.Location = new System.Drawing.Point(6, 106);
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
            groupBox1.Controls.Add(lbl_SqliteVersion);
            groupBox1.Location = new System.Drawing.Point(541, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(247, 128);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Base de datos";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(6, 80);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(235, 23);
            button3.TabIndex = 3;
            button3.Text = "Copia de seguridad";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DatabaseBackup_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(6, 51);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(235, 23);
            button2.TabIndex = 2;
            button2.Text = "Verificar integridad";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DatabaseCheckIntegrity_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(6, 22);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(235, 23);
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
            groupBox2.Location = new System.Drawing.Point(541, 353);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(247, 70);
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
            // lbl_AppVersion
            // 
            lbl_AppVersion.AutoSize = true;
            lbl_AppVersion.Location = new System.Drawing.Point(541, 426);
            lbl_AppVersion.Name = "lbl_AppVersion";
            lbl_AppVersion.Size = new System.Drawing.Size(87, 15);
            lbl_AppVersion.TabIndex = 6;
            lbl_AppVersion.Text = "[APP VERSION]";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new System.Drawing.Point(705, 426);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(83, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Código fuente";
            linkLabel1.LinkClicked += SourceCodeGitHub_LinkClicked;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox6);
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Location = new System.Drawing.Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(523, 426);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Configuración";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(checkBox1);
            groupBox6.Controls.Add(cb_StudentCareer);
            groupBox6.Controls.Add(label6);
            groupBox6.Location = new System.Drawing.Point(6, 138);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(511, 142);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Residentes";
            // 
            // cb_StudentCareer
            // 
            cb_StudentCareer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentCareer.FormattingEnabled = true;
            cb_StudentCareer.Location = new System.Drawing.Point(121, 16);
            cb_StudentCareer.Name = "cb_StudentCareer";
            cb_StudentCareer.Size = new System.Drawing.Size(272, 23);
            cb_StudentCareer.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 19);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(109, 15);
            label6.TabIndex = 0;
            label6.Text = "Carrera por defecto";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(cb_CompanyType);
            groupBox5.Location = new System.Drawing.Point(6, 80);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(511, 52);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Empresas";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 19);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(93, 15);
            label5.TabIndex = 3;
            label5.Text = "Giro por defecto";
            // 
            // cb_CompanyType
            // 
            cb_CompanyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_CompanyType.FormattingEnabled = true;
            cb_CompanyType.Items.AddRange(new object[] { "Ninguno", "Pública", "Privada", "Industrial" });
            cb_CompanyType.Location = new System.Drawing.Point(121, 16);
            cb_CompanyType.Name = "cb_CompanyType";
            cb_CompanyType.Size = new System.Drawing.Size(118, 23);
            cb_CompanyType.TabIndex = 2;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(6, 395);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "Guardar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += SaveAppSettings_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(cb_AdvisorType);
            groupBox4.Location = new System.Drawing.Point(6, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(511, 52);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Asesores";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 19);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(94, 15);
            label4.TabIndex = 3;
            label4.Text = "Tipo por defecto";
            // 
            // cb_AdvisorType
            // 
            cb_AdvisorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_AdvisorType.FormattingEnabled = true;
            cb_AdvisorType.Items.AddRange(new object[] { "Ninguno", "Interno", "Externo" });
            cb_AdvisorType.Location = new System.Drawing.Point(121, 16);
            cb_AdvisorType.Name = "cb_AdvisorType";
            cb_AdvisorType.Size = new System.Drawing.Size(118, 23);
            cb_AdvisorType.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(6, 45);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(168, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Mostrar carreras liquidadas";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(lbl_AppVersion);
            Controls.Add(groupBox3);
            Controls.Add(linkLabel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_AdvisorType;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cb_CompanyType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cb_StudentCareer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_AppVersion;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
