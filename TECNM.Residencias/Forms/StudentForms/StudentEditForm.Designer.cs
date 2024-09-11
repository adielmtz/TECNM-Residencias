namespace TECNM.Residencias.Forms.StudentForms
{
    partial class StudentEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentEditForm));
            btn_CancelEdit = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            cb_StudentGender = new System.Windows.Forms.ComboBox();
            cb_StudentSpecialty = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            cb_StudentCareer = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            tb_StudentPhone = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tb_StudentEmail = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tb_StudentLastName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tb_StudentFirstName = new System.Windows.Forms.TextBox();
            tb_StudentId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            chk_StudentEnabled = new System.Windows.Forms.CheckBox();
            cb_StudentReviewerAdvisor = new System.Windows.Forms.ComboBox();
            label18 = new System.Windows.Forms.Label();
            cb_StudentExternalAdvisor = new System.Windows.Forms.ComboBox();
            label17 = new System.Windows.Forms.Label();
            cb_StudentInternalAdvisor = new System.Windows.Forms.ComboBox();
            label16 = new System.Windows.Forms.Label();
            dtp_StudentEndDate = new System.Windows.Forms.DateTimePicker();
            label15 = new System.Windows.Forms.Label();
            dtp_StudentStartDate = new System.Windows.Forms.DateTimePicker();
            label14 = new System.Windows.Forms.Label();
            cb_StudentSemester = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            tb_StudentSchedule = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            tb_StudentDepartment = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            tb_StudentCompany = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            tb_StudentProjectName = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            groupBox9 = new System.Windows.Forms.GroupBox();
            tb_StudentNotes = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            button3 = new System.Windows.Forms.Button();
            flp_Documents = new System.Windows.Forms.FlowLayoutPanel();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_CancelEdit
            // 
            btn_CancelEdit.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_CancelEdit.Location = new System.Drawing.Point(960, 530);
            btn_CancelEdit.Name = "btn_CancelEdit";
            btn_CancelEdit.Size = new System.Drawing.Size(100, 23);
            btn_CancelEdit.TabIndex = 5;
            btn_CancelEdit.Text = "Cancelar";
            btn_CancelEdit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(cb_StudentGender);
            groupBox1.Controls.Add(cb_StudentSpecialty);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cb_StudentCareer);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tb_StudentPhone);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tb_StudentEmail);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tb_StudentLastName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tb_StudentFirstName);
            groupBox1.Controls.Add(tb_StudentId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(588, 162);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información general";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 68);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(32, 15);
            label8.TabIndex = 15;
            label8.Text = "Sexo";
            // 
            // cb_StudentGender
            // 
            cb_StudentGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentGender.FormattingEnabled = true;
            cb_StudentGender.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            cb_StudentGender.Location = new System.Drawing.Point(6, 86);
            cb_StudentGender.Name = "cb_StudentGender";
            cb_StudentGender.Size = new System.Drawing.Size(97, 23);
            cb_StudentGender.TabIndex = 14;
            // 
            // cb_StudentSpecialty
            // 
            cb_StudentSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentSpecialty.FormattingEnabled = true;
            cb_StudentSpecialty.Location = new System.Drawing.Point(310, 130);
            cb_StudentSpecialty.Name = "cb_StudentSpecialty";
            cb_StudentSpecialty.Size = new System.Drawing.Size(272, 23);
            cb_StudentSpecialty.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(310, 112);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(72, 15);
            label7.TabIndex = 12;
            label7.Text = "Especialidad";
            // 
            // cb_StudentCareer
            // 
            cb_StudentCareer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentCareer.FormattingEnabled = true;
            cb_StudentCareer.Location = new System.Drawing.Point(6, 130);
            cb_StudentCareer.Name = "cb_StudentCareer";
            cb_StudentCareer.Size = new System.Drawing.Size(272, 23);
            cb_StudentCareer.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 112);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 15);
            label6.TabIndex = 10;
            label6.Text = "Carrera";
            // 
            // tb_StudentPhone
            // 
            tb_StudentPhone.Location = new System.Drawing.Point(365, 86);
            tb_StudentPhone.Name = "tb_StudentPhone";
            tb_StudentPhone.Size = new System.Drawing.Size(217, 23);
            tb_StudentPhone.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(365, 68);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(52, 15);
            label5.TabIndex = 8;
            label5.Text = "Teléfono";
            // 
            // tb_StudentEmail
            // 
            tb_StudentEmail.Location = new System.Drawing.Point(109, 86);
            tb_StudentEmail.Name = "tb_StudentEmail";
            tb_StudentEmail.Size = new System.Drawing.Size(250, 23);
            tb_StudentEmail.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(109, 68);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 15);
            label4.TabIndex = 6;
            label4.Text = "Correo";
            // 
            // tb_StudentLastName
            // 
            tb_StudentLastName.Location = new System.Drawing.Point(332, 42);
            tb_StudentLastName.Name = "tb_StudentLastName";
            tb_StudentLastName.Size = new System.Drawing.Size(250, 23);
            tb_StudentLastName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(332, 24);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 15);
            label3.TabIndex = 4;
            label3.Text = "Apellidos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(76, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // tb_StudentFirstName
            // 
            tb_StudentFirstName.Location = new System.Drawing.Point(76, 42);
            tb_StudentFirstName.Name = "tb_StudentFirstName";
            tb_StudentFirstName.Size = new System.Drawing.Size(250, 23);
            tb_StudentFirstName.TabIndex = 2;
            // 
            // tb_StudentId
            // 
            tb_StudentId.Location = new System.Drawing.Point(6, 42);
            tb_StudentId.Name = "tb_StudentId";
            tb_StudentId.Size = new System.Drawing.Size(64, 23);
            tb_StudentId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "N° Control";
            // 
            // button1
            // 
            button1.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button1.Location = new System.Drawing.Point(12, 530);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(100, 23);
            button1.TabIndex = 8;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveEdit_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chk_StudentEnabled);
            groupBox3.Controls.Add(cb_StudentReviewerAdvisor);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(cb_StudentExternalAdvisor);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(cb_StudentInternalAdvisor);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(dtp_StudentEndDate);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(dtp_StudentStartDate);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(cb_StudentSemester);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(tb_StudentSchedule);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(tb_StudentDepartment);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(tb_StudentCompany);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(tb_StudentProjectName);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(button2);
            groupBox3.Location = new System.Drawing.Point(12, 180);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(588, 344);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Proyecto";
            // 
            // chk_StudentEnabled
            // 
            chk_StudentEnabled.AutoSize = true;
            chk_StudentEnabled.Location = new System.Drawing.Point(432, 264);
            chk_StudentEnabled.Name = "chk_StudentEnabled";
            chk_StudentEnabled.Size = new System.Drawing.Size(127, 19);
            chk_StudentEnabled.TabIndex = 21;
            chk_StudentEnabled.Text = "Expediente cerrado";
            chk_StudentEnabled.UseVisualStyleBackColor = true;
            // 
            // cb_StudentReviewerAdvisor
            // 
            cb_StudentReviewerAdvisor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cb_StudentReviewerAdvisor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cb_StudentReviewerAdvisor.FormattingEnabled = true;
            cb_StudentReviewerAdvisor.Location = new System.Drawing.Point(6, 306);
            cb_StudentReviewerAdvisor.Name = "cb_StudentReviewerAdvisor";
            cb_StudentReviewerAdvisor.Size = new System.Drawing.Size(370, 23);
            cb_StudentReviewerAdvisor.TabIndex = 20;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(6, 288);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(45, 15);
            label18.TabIndex = 19;
            label18.Text = "Revisor";
            // 
            // cb_StudentExternalAdvisor
            // 
            cb_StudentExternalAdvisor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cb_StudentExternalAdvisor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cb_StudentExternalAdvisor.Enabled = false;
            cb_StudentExternalAdvisor.FormattingEnabled = true;
            cb_StudentExternalAdvisor.Location = new System.Drawing.Point(6, 262);
            cb_StudentExternalAdvisor.Name = "cb_StudentExternalAdvisor";
            cb_StudentExternalAdvisor.Size = new System.Drawing.Size(370, 23);
            cb_StudentExternalAdvisor.TabIndex = 18;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(6, 244);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(85, 15);
            label17.TabIndex = 17;
            label17.Text = "Asesor externo";
            // 
            // cb_StudentInternalAdvisor
            // 
            cb_StudentInternalAdvisor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cb_StudentInternalAdvisor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cb_StudentInternalAdvisor.FormattingEnabled = true;
            cb_StudentInternalAdvisor.Location = new System.Drawing.Point(6, 218);
            cb_StudentInternalAdvisor.Name = "cb_StudentInternalAdvisor";
            cb_StudentInternalAdvisor.Size = new System.Drawing.Size(370, 23);
            cb_StudentInternalAdvisor.TabIndex = 16;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(6, 200);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(83, 15);
            label16.TabIndex = 15;
            label16.Text = "Asesor interno";
            // 
            // dtp_StudentEndDate
            // 
            dtp_StudentEndDate.CustomFormat = "dd/MM/yyyy";
            dtp_StudentEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtp_StudentEndDate.Location = new System.Drawing.Point(382, 174);
            dtp_StudentEndDate.Name = "dtp_StudentEndDate";
            dtp_StudentEndDate.Size = new System.Drawing.Size(200, 23);
            dtp_StudentEndDate.TabIndex = 14;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(382, 156);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(86, 15);
            label15.TabIndex = 13;
            label15.Text = "Fecha de cierre";
            // 
            // dtp_StudentStartDate
            // 
            dtp_StudentStartDate.CustomFormat = "dd/MM/yyyy";
            dtp_StudentStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtp_StudentStartDate.Location = new System.Drawing.Point(176, 174);
            dtp_StudentStartDate.Name = "dtp_StudentStartDate";
            dtp_StudentStartDate.Size = new System.Drawing.Size(200, 23);
            dtp_StudentStartDate.TabIndex = 12;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(176, 156);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(86, 15);
            label14.TabIndex = 11;
            label14.Text = "Fecha de inicio";
            // 
            // cb_StudentSemester
            // 
            cb_StudentSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentSemester.FormattingEnabled = true;
            cb_StudentSemester.Items.AddRange(new object[] { "ENE-JUN", "AGO-DIC" });
            cb_StudentSemester.Location = new System.Drawing.Point(6, 174);
            cb_StudentSemester.Name = "cb_StudentSemester";
            cb_StudentSemester.Size = new System.Drawing.Size(146, 23);
            cb_StudentSemester.TabIndex = 10;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(6, 156);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(55, 15);
            label13.TabIndex = 9;
            label13.Text = "Semestre";
            // 
            // tb_StudentSchedule
            // 
            tb_StudentSchedule.Location = new System.Drawing.Point(432, 130);
            tb_StudentSchedule.Name = "tb_StudentSchedule";
            tb_StudentSchedule.Size = new System.Drawing.Size(150, 23);
            tb_StudentSchedule.TabIndex = 8;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(432, 112);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(47, 15);
            label12.TabIndex = 7;
            label12.Text = "Horario";
            // 
            // tb_StudentDepartment
            // 
            tb_StudentDepartment.Location = new System.Drawing.Point(6, 130);
            tb_StudentDepartment.Name = "tb_StudentDepartment";
            tb_StudentDepartment.Size = new System.Drawing.Size(420, 23);
            tb_StudentDepartment.TabIndex = 6;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(6, 112);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(83, 15);
            label11.TabIndex = 5;
            label11.Text = "Departamento";
            // 
            // tb_StudentCompany
            // 
            tb_StudentCompany.Enabled = false;
            tb_StudentCompany.Location = new System.Drawing.Point(87, 86);
            tb_StudentCompany.Name = "tb_StudentCompany";
            tb_StudentCompany.Size = new System.Drawing.Size(495, 23);
            tb_StudentCompany.TabIndex = 4;
            tb_StudentCompany.Text = "SIN ASIGNAR";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(6, 68);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(52, 15);
            label10.TabIndex = 3;
            label10.Text = "Empresa";
            // 
            // tb_StudentProjectName
            // 
            tb_StudentProjectName.Location = new System.Drawing.Point(6, 42);
            tb_StudentProjectName.Name = "tb_StudentProjectName";
            tb_StudentProjectName.Size = new System.Drawing.Size(576, 23);
            tb_StudentProjectName.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 24);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(120, 15);
            label9.TabIndex = 1;
            label9.Text = "Nombre del proyecto";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(6, 86);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 0;
            button2.Text = "Seleccionar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ChoseCompany_Click;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(tb_StudentNotes);
            groupBox9.Location = new System.Drawing.Point(606, 383);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new System.Drawing.Size(453, 141);
            groupBox9.TabIndex = 11;
            groupBox9.TabStop = false;
            groupBox9.Text = "Observaciones";
            // 
            // tb_StudentNotes
            // 
            tb_StudentNotes.BackColor = System.Drawing.SystemColors.Window;
            tb_StudentNotes.Location = new System.Drawing.Point(6, 22);
            tb_StudentNotes.Multiline = true;
            tb_StudentNotes.Name = "tb_StudentNotes";
            tb_StudentNotes.Size = new System.Drawing.Size(441, 113);
            tb_StudentNotes.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(flp_Documents);
            groupBox2.Location = new System.Drawing.Point(606, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(454, 365);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Documentos";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(6, 336);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(442, 23);
            button3.TabIndex = 1;
            button3.Text = "Añadir documento";
            button3.UseVisualStyleBackColor = true;
            button3.Click += AddStudentDocument_Click;
            // 
            // flp_Documents
            // 
            flp_Documents.AutoScroll = true;
            flp_Documents.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp_Documents.Location = new System.Drawing.Point(6, 22);
            flp_Documents.Name = "flp_Documents";
            flp_Documents.Size = new System.Drawing.Size(442, 308);
            flp_Documents.TabIndex = 0;
            flp_Documents.WrapContents = false;
            // 
            // StudentEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_CancelEdit;
            ClientSize = new System.Drawing.Size(1072, 565);
            ControlBox = false;
            Controls.Add(groupBox2);
            Controls.Add(groupBox9);
            Controls.Add(groupBox3);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(btn_CancelEdit);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "StudentEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar información";
            Load += StudentEditForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_CancelEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_StudentId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_StudentLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_StudentFirstName;
        private System.Windows.Forms.TextBox tb_StudentPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_StudentEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_StudentCareer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_StudentSpecialty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_StudentGender;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_StudentCompany;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_StudentProjectName;
        private System.Windows.Forms.TextBox tb_StudentSchedule;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_StudentDepartment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtp_StudentEndDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtp_StudentStartDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cb_StudentSemester;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cb_StudentInternalAdvisor;
        private System.Windows.Forms.ComboBox cb_StudentExternalAdvisor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cb_StudentReviewerAdvisor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tb_StudentNotes;
        private System.Windows.Forms.CheckBox chk_StudentEnabled;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flp_Documents;
        private System.Windows.Forms.Button button3;
    }
}
