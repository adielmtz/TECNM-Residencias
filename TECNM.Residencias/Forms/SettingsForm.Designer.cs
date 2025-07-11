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
            btn_UpdateCheck = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lbl_AppVersion = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            button2 = new System.Windows.Forms.Button();
            groupBox6 = new System.Windows.Forms.GroupBox();
            chk_EnableEmailAutocomplete = new System.Windows.Forms.CheckBox();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            cb_DefaultSemesterFilter = new System.Windows.Forms.ComboBox();
            cb_StudentCareer = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            cb_CompanyType = new System.Windows.Forms.ComboBox();
            button4 = new System.Windows.Forms.Button();
            groupBox4 = new System.Windows.Forms.GroupBox();
            cb_FullBackup = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            cb_DbBackup = new System.Windows.Forms.ComboBox();
            button6 = new System.Windows.Forms.Button();
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
            lbl_SqliteVersion.Location = new System.Drawing.Point(597, 426);
            lbl_SqliteVersion.Name = "lbl_SqliteVersion";
            lbl_SqliteVersion.Size = new System.Drawing.Size(102, 15);
            lbl_SqliteVersion.TabIndex = 0;
            lbl_SqliteVersion.Text = "[SQLITE VERSION]";
            lbl_SqliteVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_UpdateCheck);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new System.Drawing.Point(504, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(284, 110);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Avanzado";
            // 
            // btn_UpdateCheck
            // 
            btn_UpdateCheck.Location = new System.Drawing.Point(6, 80);
            btn_UpdateCheck.Name = "btn_UpdateCheck";
            btn_UpdateCheck.Size = new System.Drawing.Size(272, 23);
            btn_UpdateCheck.TabIndex = 8;
            btn_UpdateCheck.TabStop = false;
            btn_UpdateCheck.Text = "Buscar actualizaciones";
            btn_UpdateCheck.UseVisualStyleBackColor = true;
            btn_UpdateCheck.Click += DoUpdatesCheck_Click;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(6, 51);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(272, 23);
            button5.TabIndex = 7;
            button5.TabStop = false;
            button5.Text = "Comprobar integridad";
            button5.UseVisualStyleBackColor = true;
            button5.Click += OpenIntegrityCheckDialog_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(6, 22);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(272, 23);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "Optimizar base de datos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DatabaseOptimize_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(6, 23);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(272, 23);
            button3.TabIndex = 3;
            button3.TabStop = false;
            button3.Text = "Crear copia de seguridad";
            button3.UseVisualStyleBackColor = true;
            button3.Click += CreateBackup_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new System.Drawing.Point(504, 350);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(284, 73);
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
            lbl_AppVersion.Location = new System.Drawing.Point(504, 426);
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
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(groupBox6);
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(button4);
            groupBox3.Location = new System.Drawing.Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(486, 429);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Configuración";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(350, 400);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(130, 23);
            button2.TabIndex = 8;
            button2.Text = "Reestablecer valores";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ResetDefaults_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(chk_EnableEmailAutocomplete);
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(label4);
            groupBox6.Controls.Add(cb_DefaultSemesterFilter);
            groupBox6.Controls.Add(cb_StudentCareer);
            groupBox6.Controls.Add(label6);
            groupBox6.Location = new System.Drawing.Point(6, 80);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(474, 125);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Residentes";
            // 
            // chk_EnableEmailAutocomplete
            // 
            chk_EnableEmailAutocomplete.AutoSize = true;
            chk_EnableEmailAutocomplete.Location = new System.Drawing.Point(121, 92);
            chk_EnableEmailAutocomplete.Name = "chk_EnableEmailAutocomplete";
            chk_EnableEmailAutocomplete.Size = new System.Drawing.Size(15, 14);
            chk_EnableEmailAutocomplete.TabIndex = 7;
            chk_EnableEmailAutocomplete.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.Location = new System.Drawing.Point(6, 85);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(109, 33);
            label7.TabIndex = 6;
            label7.Text = "Autocompletar dirección de email";
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(6, 45);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(100, 30);
            label4.TabIndex = 5;
            label4.Text = "Filtro de semestre predeterminado";
            // 
            // cb_DefaultSemesterFilter
            // 
            cb_DefaultSemesterFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_DefaultSemesterFilter.FormattingEnabled = true;
            cb_DefaultSemesterFilter.Items.AddRange(new object[] { "Automático", "Todos", "ENE-JUN", "AGO-DIC" });
            cb_DefaultSemesterFilter.Location = new System.Drawing.Point(121, 50);
            cb_DefaultSemesterFilter.Name = "cb_DefaultSemesterFilter";
            cb_DefaultSemesterFilter.Size = new System.Drawing.Size(90, 23);
            cb_DefaultSemesterFilter.TabIndex = 4;
            // 
            // cb_StudentCareer
            // 
            cb_StudentCareer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentCareer.FormattingEnabled = true;
            cb_StudentCareer.Location = new System.Drawing.Point(121, 16);
            cb_StudentCareer.Name = "cb_StudentCareer";
            cb_StudentCareer.Size = new System.Drawing.Size(272, 23);
            cb_StudentCareer.TabIndex = 3;
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
            groupBox5.Location = new System.Drawing.Point(6, 22);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(474, 52);
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
            cb_CompanyType.Location = new System.Drawing.Point(121, 16);
            cb_CompanyType.Name = "cb_CompanyType";
            cb_CompanyType.Size = new System.Drawing.Size(118, 23);
            cb_CompanyType.TabIndex = 2;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(6, 400);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(75, 23);
            button4.TabIndex = 0;
            button4.TabStop = false;
            button4.Text = "Guardar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += SaveAppSettings_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cb_FullBackup);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(cb_DbBackup);
            groupBox4.Controls.Add(button6);
            groupBox4.Controls.Add(button3);
            groupBox4.Location = new System.Drawing.Point(504, 128);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(284, 148);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Respaldo y restauración";
            // 
            // cb_FullBackup
            // 
            cb_FullBackup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_FullBackup.FormattingEnabled = true;
            cb_FullBackup.Location = new System.Drawing.Point(157, 113);
            cb_FullBackup.Name = "cb_FullBackup";
            cb_FullBackup.Size = new System.Drawing.Size(121, 23);
            cb_FullBackup.TabIndex = 8;
            // 
            // label9
            // 
            label9.Location = new System.Drawing.Point(6, 109);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(145, 34);
            label9.TabIndex = 7;
            label9.Text = "Recordatorio de copia de seguridad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 83);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(145, 15);
            label8.TabIndex = 6;
            label8.Text = "Respaldar la base de datos";
            // 
            // cb_DbBackup
            // 
            cb_DbBackup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_DbBackup.FormattingEnabled = true;
            cb_DbBackup.Location = new System.Drawing.Point(157, 80);
            cb_DbBackup.Name = "cb_DbBackup";
            cb_DbBackup.Size = new System.Drawing.Size(121, 23);
            cb_DbBackup.TabIndex = 5;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(6, 52);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(272, 23);
            button6.TabIndex = 4;
            button6.TabStop = false;
            button6.Text = "Restaurar copia de seguridad";
            button6.UseVisualStyleBackColor = true;
            button6.Click += RestoreBackup_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(groupBox4);
            Controls.Add(lbl_AppVersion);
            Controls.Add(lbl_SqliteVersion);
            Controls.Add(groupBox3);
            Controls.Add(linkLabel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cb_CompanyType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cb_StudentCareer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_AppVersion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_DefaultSemesterFilter;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox chk_EnableEmailAutocomplete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_UpdateCheck;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_DbBackup;
        private System.Windows.Forms.ComboBox cb_FullBackup;
        private System.Windows.Forms.Label label9;
    }
}
