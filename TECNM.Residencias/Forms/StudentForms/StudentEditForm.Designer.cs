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
            gb_GeneralInfo = new System.Windows.Forms.GroupBox();
            mtb_StudentPhone = new System.Windows.Forms.MaskedTextBox();
            mtb_StudentId = new System.Windows.Forms.MaskedTextBox();
            label8 = new System.Windows.Forms.Label();
            cb_StudentGender = new System.Windows.Forms.ComboBox();
            cb_StudentSpecialty = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            cb_StudentCareer = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            tb_StudentEmail = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            tb_StudentLastName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tb_StudentFirstName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            gb_ProjectInfo = new System.Windows.Forms.GroupBox();
            btn_RemoveReviewerAdvisor = new System.Windows.Forms.Button();
            btn_RemoveExternalAdvisor = new System.Windows.Forms.Button();
            btn_RemoveInternalAdvisor = new System.Windows.Forms.Button();
            tb_StudentReviewerAdvisor = new System.Windows.Forms.TextBox();
            tb_StudentExternalAdvisor = new System.Windows.Forms.TextBox();
            tb_StudentInternalAdvisor = new System.Windows.Forms.TextBox();
            button6 = new System.Windows.Forms.Button();
            btn_ChoseExternalAdvisor = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            label18 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
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
            chk_StudentEnabled = new System.Windows.Forms.CheckBox();
            gb_Notes = new System.Windows.Forms.GroupBox();
            tb_StudentNotes = new System.Windows.Forms.TextBox();
            gb_Documents = new System.Windows.Forms.GroupBox();
            button3 = new System.Windows.Forms.Button();
            flp_Documents = new System.Windows.Forms.FlowLayoutPanel();
            button5 = new System.Windows.Forms.Button();
            btn_DeleteStudent = new System.Windows.Forms.Button();
            gb_GeneralInfo.SuspendLayout();
            gb_ProjectInfo.SuspendLayout();
            gb_Notes.SuspendLayout();
            gb_Documents.SuspendLayout();
            SuspendLayout();
            // 
            // btn_CancelEdit
            // 
            btn_CancelEdit.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_CancelEdit.Location = new System.Drawing.Point(960, 530);
            btn_CancelEdit.Name = "btn_CancelEdit";
            btn_CancelEdit.Size = new System.Drawing.Size(100, 23);
            btn_CancelEdit.TabIndex = 21;
            btn_CancelEdit.Text = "Cancelar";
            btn_CancelEdit.UseVisualStyleBackColor = true;
            // 
            // gb_GeneralInfo
            // 
            gb_GeneralInfo.Controls.Add(mtb_StudentPhone);
            gb_GeneralInfo.Controls.Add(mtb_StudentId);
            gb_GeneralInfo.Controls.Add(label8);
            gb_GeneralInfo.Controls.Add(cb_StudentGender);
            gb_GeneralInfo.Controls.Add(cb_StudentSpecialty);
            gb_GeneralInfo.Controls.Add(label7);
            gb_GeneralInfo.Controls.Add(cb_StudentCareer);
            gb_GeneralInfo.Controls.Add(label6);
            gb_GeneralInfo.Controls.Add(label5);
            gb_GeneralInfo.Controls.Add(tb_StudentEmail);
            gb_GeneralInfo.Controls.Add(label4);
            gb_GeneralInfo.Controls.Add(tb_StudentLastName);
            gb_GeneralInfo.Controls.Add(label3);
            gb_GeneralInfo.Controls.Add(label2);
            gb_GeneralInfo.Controls.Add(tb_StudentFirstName);
            gb_GeneralInfo.Controls.Add(label1);
            gb_GeneralInfo.Location = new System.Drawing.Point(12, 12);
            gb_GeneralInfo.Name = "gb_GeneralInfo";
            gb_GeneralInfo.Size = new System.Drawing.Size(588, 162);
            gb_GeneralInfo.TabIndex = 0;
            gb_GeneralInfo.TabStop = false;
            gb_GeneralInfo.Text = "Información general";
            // 
            // mtb_StudentPhone
            // 
            mtb_StudentPhone.Location = new System.Drawing.Point(365, 86);
            mtb_StudentPhone.Mask = "000-000-0000";
            mtb_StudentPhone.Name = "mtb_StudentPhone";
            mtb_StudentPhone.Size = new System.Drawing.Size(217, 23);
            mtb_StudentPhone.TabIndex = 6;
            mtb_StudentPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtb_StudentId
            // 
            mtb_StudentId.Location = new System.Drawing.Point(6, 42);
            mtb_StudentId.Mask = "00\\070000";
            mtb_StudentId.Name = "mtb_StudentId";
            mtb_StudentId.Size = new System.Drawing.Size(64, 23);
            mtb_StudentId.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 68);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 15);
            label8.TabIndex = 0;
            label8.Text = "Sexo*";
            // 
            // cb_StudentGender
            // 
            cb_StudentGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentGender.FormattingEnabled = true;
            cb_StudentGender.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            cb_StudentGender.Location = new System.Drawing.Point(6, 86);
            cb_StudentGender.Name = "cb_StudentGender";
            cb_StudentGender.Size = new System.Drawing.Size(97, 23);
            cb_StudentGender.TabIndex = 4;
            // 
            // cb_StudentSpecialty
            // 
            cb_StudentSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentSpecialty.FormattingEnabled = true;
            cb_StudentSpecialty.Location = new System.Drawing.Point(310, 130);
            cb_StudentSpecialty.Name = "cb_StudentSpecialty";
            cb_StudentSpecialty.Size = new System.Drawing.Size(272, 23);
            cb_StudentSpecialty.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(310, 112);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(72, 15);
            label7.TabIndex = 0;
            label7.Text = "Especialidad";
            // 
            // cb_StudentCareer
            // 
            cb_StudentCareer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentCareer.FormattingEnabled = true;
            cb_StudentCareer.Location = new System.Drawing.Point(6, 130);
            cb_StudentCareer.Name = "cb_StudentCareer";
            cb_StudentCareer.Size = new System.Drawing.Size(272, 23);
            cb_StudentCareer.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 112);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 15);
            label6.TabIndex = 0;
            label6.Text = "Carrera";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(365, 68);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(52, 15);
            label5.TabIndex = 0;
            label5.Text = "Teléfono";
            // 
            // tb_StudentEmail
            // 
            tb_StudentEmail.Location = new System.Drawing.Point(109, 86);
            tb_StudentEmail.Name = "tb_StudentEmail";
            tb_StudentEmail.Size = new System.Drawing.Size(250, 23);
            tb_StudentEmail.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(109, 68);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 15);
            label4.TabIndex = 0;
            label4.Text = "Correo";
            // 
            // tb_StudentLastName
            // 
            tb_StudentLastName.Location = new System.Drawing.Point(332, 42);
            tb_StudentLastName.Name = "tb_StudentLastName";
            tb_StudentLastName.Size = new System.Drawing.Size(250, 23);
            tb_StudentLastName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(332, 24);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(61, 15);
            label3.TabIndex = 0;
            label3.Text = "Apellidos*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(76, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 0;
            label2.Text = "Nombre*";
            // 
            // tb_StudentFirstName
            // 
            tb_StudentFirstName.Location = new System.Drawing.Point(76, 42);
            tb_StudentFirstName.Name = "tb_StudentFirstName";
            tb_StudentFirstName.Size = new System.Drawing.Size(250, 23);
            tb_StudentFirstName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "N° Control*";
            // 
            // button1
            // 
            button1.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button1.Location = new System.Drawing.Point(12, 530);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(100, 23);
            button1.TabIndex = 1;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveEdit_Click;
            // 
            // gb_ProjectInfo
            // 
            gb_ProjectInfo.Controls.Add(btn_RemoveReviewerAdvisor);
            gb_ProjectInfo.Controls.Add(btn_RemoveExternalAdvisor);
            gb_ProjectInfo.Controls.Add(btn_RemoveInternalAdvisor);
            gb_ProjectInfo.Controls.Add(tb_StudentReviewerAdvisor);
            gb_ProjectInfo.Controls.Add(tb_StudentExternalAdvisor);
            gb_ProjectInfo.Controls.Add(tb_StudentInternalAdvisor);
            gb_ProjectInfo.Controls.Add(button6);
            gb_ProjectInfo.Controls.Add(btn_ChoseExternalAdvisor);
            gb_ProjectInfo.Controls.Add(button4);
            gb_ProjectInfo.Controls.Add(label18);
            gb_ProjectInfo.Controls.Add(label17);
            gb_ProjectInfo.Controls.Add(label16);
            gb_ProjectInfo.Controls.Add(dtp_StudentEndDate);
            gb_ProjectInfo.Controls.Add(label15);
            gb_ProjectInfo.Controls.Add(dtp_StudentStartDate);
            gb_ProjectInfo.Controls.Add(label14);
            gb_ProjectInfo.Controls.Add(cb_StudentSemester);
            gb_ProjectInfo.Controls.Add(label13);
            gb_ProjectInfo.Controls.Add(tb_StudentSchedule);
            gb_ProjectInfo.Controls.Add(label12);
            gb_ProjectInfo.Controls.Add(tb_StudentDepartment);
            gb_ProjectInfo.Controls.Add(label11);
            gb_ProjectInfo.Controls.Add(tb_StudentCompany);
            gb_ProjectInfo.Controls.Add(label10);
            gb_ProjectInfo.Controls.Add(tb_StudentProjectName);
            gb_ProjectInfo.Controls.Add(label9);
            gb_ProjectInfo.Controls.Add(button2);
            gb_ProjectInfo.Location = new System.Drawing.Point(12, 180);
            gb_ProjectInfo.Name = "gb_ProjectInfo";
            gb_ProjectInfo.Size = new System.Drawing.Size(588, 344);
            gb_ProjectInfo.TabIndex = 1;
            gb_ProjectInfo.TabStop = false;
            gb_ProjectInfo.Text = "Proyecto";
            // 
            // btn_RemoveReviewerAdvisor
            // 
            btn_RemoveReviewerAdvisor.Enabled = false;
            btn_RemoveReviewerAdvisor.Location = new System.Drawing.Point(556, 305);
            btn_RemoveReviewerAdvisor.Name = "btn_RemoveReviewerAdvisor";
            btn_RemoveReviewerAdvisor.Size = new System.Drawing.Size(26, 24);
            btn_RemoveReviewerAdvisor.TabIndex = 0;
            btn_RemoveReviewerAdvisor.TabStop = false;
            btn_RemoveReviewerAdvisor.Text = "X";
            btn_RemoveReviewerAdvisor.UseVisualStyleBackColor = true;
            btn_RemoveReviewerAdvisor.Click += RemoveReviewerAdvisor_Click;
            // 
            // btn_RemoveExternalAdvisor
            // 
            btn_RemoveExternalAdvisor.Enabled = false;
            btn_RemoveExternalAdvisor.Location = new System.Drawing.Point(556, 261);
            btn_RemoveExternalAdvisor.Name = "btn_RemoveExternalAdvisor";
            btn_RemoveExternalAdvisor.Size = new System.Drawing.Size(26, 24);
            btn_RemoveExternalAdvisor.TabIndex = 0;
            btn_RemoveExternalAdvisor.TabStop = false;
            btn_RemoveExternalAdvisor.Text = "X";
            btn_RemoveExternalAdvisor.UseVisualStyleBackColor = true;
            btn_RemoveExternalAdvisor.Click += RemoveExternalAdvisor_Click;
            // 
            // btn_RemoveInternalAdvisor
            // 
            btn_RemoveInternalAdvisor.Enabled = false;
            btn_RemoveInternalAdvisor.Location = new System.Drawing.Point(556, 217);
            btn_RemoveInternalAdvisor.Name = "btn_RemoveInternalAdvisor";
            btn_RemoveInternalAdvisor.Size = new System.Drawing.Size(26, 24);
            btn_RemoveInternalAdvisor.TabIndex = 0;
            btn_RemoveInternalAdvisor.TabStop = false;
            btn_RemoveInternalAdvisor.Text = "X";
            btn_RemoveInternalAdvisor.UseVisualStyleBackColor = true;
            btn_RemoveInternalAdvisor.Click += RemoveInternalAdvisor_Click;
            // 
            // tb_StudentReviewerAdvisor
            // 
            tb_StudentReviewerAdvisor.Enabled = false;
            tb_StudentReviewerAdvisor.Location = new System.Drawing.Point(87, 306);
            tb_StudentReviewerAdvisor.Name = "tb_StudentReviewerAdvisor";
            tb_StudentReviewerAdvisor.Size = new System.Drawing.Size(463, 23);
            tb_StudentReviewerAdvisor.TabIndex = 0;
            tb_StudentReviewerAdvisor.Text = "SIN ASIGNAR";
            // 
            // tb_StudentExternalAdvisor
            // 
            tb_StudentExternalAdvisor.Enabled = false;
            tb_StudentExternalAdvisor.Location = new System.Drawing.Point(87, 262);
            tb_StudentExternalAdvisor.Name = "tb_StudentExternalAdvisor";
            tb_StudentExternalAdvisor.Size = new System.Drawing.Size(463, 23);
            tb_StudentExternalAdvisor.TabIndex = 0;
            tb_StudentExternalAdvisor.Text = "SIN ASIGNAR";
            // 
            // tb_StudentInternalAdvisor
            // 
            tb_StudentInternalAdvisor.Enabled = false;
            tb_StudentInternalAdvisor.Location = new System.Drawing.Point(87, 218);
            tb_StudentInternalAdvisor.Name = "tb_StudentInternalAdvisor";
            tb_StudentInternalAdvisor.Size = new System.Drawing.Size(463, 23);
            tb_StudentInternalAdvisor.TabIndex = 0;
            tb_StudentInternalAdvisor.Text = "SIN ASIGNAR";
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(6, 306);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(75, 23);
            button6.TabIndex = 0;
            button6.TabStop = false;
            button6.Text = "Seleccionar";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ChoseReviewerAdvisor_Click;
            // 
            // btn_ChoseExternalAdvisor
            // 
            btn_ChoseExternalAdvisor.Enabled = false;
            btn_ChoseExternalAdvisor.Location = new System.Drawing.Point(6, 262);
            btn_ChoseExternalAdvisor.Name = "btn_ChoseExternalAdvisor";
            btn_ChoseExternalAdvisor.Size = new System.Drawing.Size(75, 23);
            btn_ChoseExternalAdvisor.TabIndex = 0;
            btn_ChoseExternalAdvisor.TabStop = false;
            btn_ChoseExternalAdvisor.Text = "Seleccionar";
            btn_ChoseExternalAdvisor.UseVisualStyleBackColor = true;
            btn_ChoseExternalAdvisor.Click += ChoseExternalAdvisor_Click;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(6, 218);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(75, 23);
            button4.TabIndex = 0;
            button4.TabStop = false;
            button4.Text = "Seleccionar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ChoseInternalAdvisor_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(6, 288);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(45, 15);
            label18.TabIndex = 0;
            label18.Text = "Revisor";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(6, 244);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(85, 15);
            label17.TabIndex = 0;
            label17.Text = "Asesor externo";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(6, 200);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(83, 15);
            label16.TabIndex = 0;
            label16.Text = "Asesor interno";
            // 
            // dtp_StudentEndDate
            // 
            dtp_StudentEndDate.CustomFormat = "dd / MMM / yyyy";
            dtp_StudentEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtp_StudentEndDate.Location = new System.Drawing.Point(382, 174);
            dtp_StudentEndDate.Name = "dtp_StudentEndDate";
            dtp_StudentEndDate.Size = new System.Drawing.Size(200, 23);
            dtp_StudentEndDate.TabIndex = 6;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(382, 156);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(91, 15);
            label15.TabIndex = 0;
            label15.Text = "Fecha de cierre*";
            // 
            // dtp_StudentStartDate
            // 
            dtp_StudentStartDate.CustomFormat = "dd / MMM / yyyy";
            dtp_StudentStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtp_StudentStartDate.Location = new System.Drawing.Point(176, 174);
            dtp_StudentStartDate.Name = "dtp_StudentStartDate";
            dtp_StudentStartDate.Size = new System.Drawing.Size(200, 23);
            dtp_StudentStartDate.TabIndex = 5;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(176, 156);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(91, 15);
            label14.TabIndex = 0;
            label14.Text = "Fecha de inicio*";
            // 
            // cb_StudentSemester
            // 
            cb_StudentSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_StudentSemester.FormattingEnabled = true;
            cb_StudentSemester.Items.AddRange(new object[] { "ENE-JUN", "AGO-DIC" });
            cb_StudentSemester.Location = new System.Drawing.Point(6, 174);
            cb_StudentSemester.Name = "cb_StudentSemester";
            cb_StudentSemester.Size = new System.Drawing.Size(146, 23);
            cb_StudentSemester.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(6, 156);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(60, 15);
            label13.TabIndex = 0;
            label13.Text = "Semestre*";
            // 
            // tb_StudentSchedule
            // 
            tb_StudentSchedule.Location = new System.Drawing.Point(432, 130);
            tb_StudentSchedule.Name = "tb_StudentSchedule";
            tb_StudentSchedule.Size = new System.Drawing.Size(150, 23);
            tb_StudentSchedule.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(432, 112);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(47, 15);
            label12.TabIndex = 0;
            label12.Text = "Horario";
            // 
            // tb_StudentDepartment
            // 
            tb_StudentDepartment.Location = new System.Drawing.Point(6, 130);
            tb_StudentDepartment.Name = "tb_StudentDepartment";
            tb_StudentDepartment.Size = new System.Drawing.Size(420, 23);
            tb_StudentDepartment.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(6, 112);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(83, 15);
            label11.TabIndex = 0;
            label11.Text = "Departamento";
            // 
            // tb_StudentCompany
            // 
            tb_StudentCompany.Enabled = false;
            tb_StudentCompany.Location = new System.Drawing.Point(87, 86);
            tb_StudentCompany.Name = "tb_StudentCompany";
            tb_StudentCompany.Size = new System.Drawing.Size(495, 23);
            tb_StudentCompany.TabIndex = 0;
            tb_StudentCompany.Text = "SIN ASIGNAR";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(6, 68);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(52, 15);
            label10.TabIndex = 0;
            label10.Text = "Empresa";
            // 
            // tb_StudentProjectName
            // 
            tb_StudentProjectName.Location = new System.Drawing.Point(6, 42);
            tb_StudentProjectName.Name = "tb_StudentProjectName";
            tb_StudentProjectName.Size = new System.Drawing.Size(576, 23);
            tb_StudentProjectName.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 24);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(125, 15);
            label9.TabIndex = 0;
            label9.Text = "Nombre del proyecto*";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(6, 86);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 0;
            button2.TabStop = false;
            button2.Text = "Seleccionar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ChoseCompany_Click;
            // 
            // chk_StudentEnabled
            // 
            chk_StudentEnabled.AutoSize = true;
            chk_StudentEnabled.Location = new System.Drawing.Point(308, 533);
            chk_StudentEnabled.Name = "chk_StudentEnabled";
            chk_StudentEnabled.Size = new System.Drawing.Size(127, 19);
            chk_StudentEnabled.TabIndex = 18;
            chk_StudentEnabled.Text = "Expediente cerrado";
            chk_StudentEnabled.UseVisualStyleBackColor = true;
            chk_StudentEnabled.CheckedChanged += StudentEnabled_CheckedChanged;
            // 
            // gb_Notes
            // 
            gb_Notes.Controls.Add(tb_StudentNotes);
            gb_Notes.Location = new System.Drawing.Point(606, 383);
            gb_Notes.Name = "gb_Notes";
            gb_Notes.Size = new System.Drawing.Size(453, 141);
            gb_Notes.TabIndex = 3;
            gb_Notes.TabStop = false;
            gb_Notes.Text = "Observaciones";
            // 
            // tb_StudentNotes
            // 
            tb_StudentNotes.BackColor = System.Drawing.SystemColors.Window;
            tb_StudentNotes.Location = new System.Drawing.Point(6, 22);
            tb_StudentNotes.Multiline = true;
            tb_StudentNotes.Name = "tb_StudentNotes";
            tb_StudentNotes.Size = new System.Drawing.Size(441, 113);
            tb_StudentNotes.TabIndex = 1;
            // 
            // gb_Documents
            // 
            gb_Documents.Controls.Add(button3);
            gb_Documents.Controls.Add(flp_Documents);
            gb_Documents.Location = new System.Drawing.Point(606, 12);
            gb_Documents.Name = "gb_Documents";
            gb_Documents.Size = new System.Drawing.Size(454, 365);
            gb_Documents.TabIndex = 2;
            gb_Documents.TabStop = false;
            gb_Documents.Text = "Documentos";
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
            // button5
            // 
            button5.Location = new System.Drawing.Point(188, 530);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(114, 23);
            button5.TabIndex = 22;
            button5.Text = "Asignar extras";
            button5.UseVisualStyleBackColor = true;
            button5.Click += OpenExtrasDialog_Click;
            // 
            // btn_DeleteStudent
            // 
            btn_DeleteStudent.Location = new System.Drawing.Point(828, 530);
            btn_DeleteStudent.Name = "btn_DeleteStudent";
            btn_DeleteStudent.Size = new System.Drawing.Size(126, 23);
            btn_DeleteStudent.TabIndex = 23;
            btn_DeleteStudent.Text = "Eliminar expediente";
            btn_DeleteStudent.UseVisualStyleBackColor = true;
            btn_DeleteStudent.Click += btn_DeleteStudent_Click;
            // 
            // StudentEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_CancelEdit;
            ClientSize = new System.Drawing.Size(1072, 565);
            ControlBox = false;
            Controls.Add(btn_DeleteStudent);
            Controls.Add(button5);
            Controls.Add(gb_Documents);
            Controls.Add(gb_Notes);
            Controls.Add(gb_ProjectInfo);
            Controls.Add(button1);
            Controls.Add(gb_GeneralInfo);
            Controls.Add(chk_StudentEnabled);
            Controls.Add(btn_CancelEdit);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "StudentEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar información";
            Load += StudentEditForm_Load;
            gb_GeneralInfo.ResumeLayout(false);
            gb_GeneralInfo.PerformLayout();
            gb_ProjectInfo.ResumeLayout(false);
            gb_ProjectInfo.PerformLayout();
            gb_Notes.ResumeLayout(false);
            gb_Notes.PerformLayout();
            gb_Documents.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_CancelEdit;
        private System.Windows.Forms.GroupBox gb_GeneralInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_StudentLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_StudentFirstName;
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
        private System.Windows.Forms.GroupBox gb_ProjectInfo;
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gb_Notes;
        private System.Windows.Forms.TextBox tb_StudentNotes;
        private System.Windows.Forms.CheckBox chk_StudentEnabled;
        private System.Windows.Forms.GroupBox gb_Documents;
        private System.Windows.Forms.FlowLayoutPanel flp_Documents;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_ChoseExternalAdvisor;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tb_StudentReviewerAdvisor;
        private System.Windows.Forms.TextBox tb_StudentExternalAdvisor;
        private System.Windows.Forms.TextBox tb_StudentInternalAdvisor;
        private System.Windows.Forms.Button btn_RemoveInternalAdvisor;
        private System.Windows.Forms.Button btn_RemoveReviewerAdvisor;
        private System.Windows.Forms.Button btn_RemoveExternalAdvisor;
        private System.Windows.Forms.MaskedTextBox mtb_StudentId;
        private System.Windows.Forms.MaskedTextBox mtb_StudentPhone;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_DeleteStudent;
    }
}
