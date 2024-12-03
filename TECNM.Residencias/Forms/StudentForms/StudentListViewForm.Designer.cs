namespace TECNM.Residencias.Forms.StudentForms
{
    partial class StudentListViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentListViewForm));
            dgv_ListView = new System.Windows.Forms.DataGridView();
            StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentSpecialty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentSemester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentInternalAdvisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentExternalAdvisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentReviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentSchedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentClosed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            StudentNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentUpdatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            StudentCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListStudentEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            label1 = new System.Windows.Forms.Label();
            tb_SearchQuery = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            lbl_StatusLabel = new System.Windows.Forms.Label();
            cb_FilterYear = new System.Windows.Forms.ComboBox();
            cb_FilterSemester = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).BeginInit();
            SuspendLayout();
            // 
            // dgv_ListView
            // 
            dgv_ListView.AllowUserToAddRows = false;
            dgv_ListView.AllowUserToDeleteRows = false;
            dgv_ListView.AllowUserToResizeRows = false;
            dgv_ListView.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgv_ListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { StudentId, StudentName, StudentGender, StudentEmail, StudentSpecialty, StudentSemester, StudentStartDate, StudentEndDate, StudentInternalAdvisor, StudentExternalAdvisor, StudentReviewer, StudentCompany, StudentDepartment, StudentSchedule, StudentClosed, StudentNotes, StudentUpdatedOn, StudentCreatedOn, ListStudentEdit });
            dgv_ListView.Location = new System.Drawing.Point(12, 35);
            dgv_ListView.MultiSelect = false;
            dgv_ListView.Name = "dgv_ListView";
            dgv_ListView.ReadOnly = true;
            dgv_ListView.RowHeadersVisible = false;
            dgv_ListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_ListView.Size = new System.Drawing.Size(1240, 596);
            dgv_ListView.TabIndex = 0;
            dgv_ListView.CellContentClick += ListView_CellContentClick;
            dgv_ListView.CellDoubleClick += ListView_CellDoubleClick;
            // 
            // StudentId
            // 
            StudentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            StudentId.HeaderText = "N° Control";
            StudentId.Name = "StudentId";
            StudentId.ReadOnly = true;
            StudentId.Width = 82;
            // 
            // StudentName
            // 
            StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentName.HeaderText = "Nombre";
            StudentName.Name = "StudentName";
            StudentName.ReadOnly = true;
            StudentName.Width = 76;
            // 
            // StudentGender
            // 
            StudentGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            StudentGender.HeaderText = "Sexo";
            StudentGender.Name = "StudentGender";
            StudentGender.ReadOnly = true;
            StudentGender.Width = 57;
            // 
            // StudentEmail
            // 
            StudentEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentEmail.HeaderText = "Correo";
            StudentEmail.Name = "StudentEmail";
            StudentEmail.ReadOnly = true;
            StudentEmail.Width = 68;
            // 
            // StudentSpecialty
            // 
            StudentSpecialty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentSpecialty.HeaderText = "Especialidad";
            StudentSpecialty.Name = "StudentSpecialty";
            StudentSpecialty.ReadOnly = true;
            StudentSpecialty.Width = 97;
            // 
            // StudentSemester
            // 
            StudentSemester.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentSemester.HeaderText = "Semestre";
            StudentSemester.Name = "StudentSemester";
            StudentSemester.ReadOnly = true;
            StudentSemester.Width = 80;
            // 
            // StudentStartDate
            // 
            StudentStartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentStartDate.HeaderText = "Fecha de inicio";
            StudentStartDate.Name = "StudentStartDate";
            StudentStartDate.ReadOnly = true;
            StudentStartDate.Width = 102;
            // 
            // StudentEndDate
            // 
            StudentEndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentEndDate.HeaderText = "Fecha de finalización";
            StudentEndDate.Name = "StudentEndDate";
            StudentEndDate.ReadOnly = true;
            StudentEndDate.Width = 130;
            // 
            // StudentInternalAdvisor
            // 
            StudentInternalAdvisor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentInternalAdvisor.HeaderText = "Asesor interno";
            StudentInternalAdvisor.Name = "StudentInternalAdvisor";
            StudentInternalAdvisor.ReadOnly = true;
            StudentInternalAdvisor.Width = 99;
            // 
            // StudentExternalAdvisor
            // 
            StudentExternalAdvisor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentExternalAdvisor.HeaderText = "Asesor externo";
            StudentExternalAdvisor.Name = "StudentExternalAdvisor";
            StudentExternalAdvisor.ReadOnly = true;
            StudentExternalAdvisor.Width = 101;
            // 
            // StudentReviewer
            // 
            StudentReviewer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentReviewer.HeaderText = "Revisor";
            StudentReviewer.Name = "StudentReviewer";
            StudentReviewer.ReadOnly = true;
            StudentReviewer.Width = 70;
            // 
            // StudentCompany
            // 
            StudentCompany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentCompany.HeaderText = "Empresa";
            StudentCompany.Name = "StudentCompany";
            StudentCompany.ReadOnly = true;
            StudentCompany.Width = 77;
            // 
            // StudentDepartment
            // 
            StudentDepartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentDepartment.HeaderText = "Departamento";
            StudentDepartment.Name = "StudentDepartment";
            StudentDepartment.ReadOnly = true;
            StudentDepartment.Width = 108;
            // 
            // StudentSchedule
            // 
            StudentSchedule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentSchedule.HeaderText = "Horario";
            StudentSchedule.Name = "StudentSchedule";
            StudentSchedule.ReadOnly = true;
            StudentSchedule.Width = 72;
            // 
            // StudentClosed
            // 
            StudentClosed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            StudentClosed.HeaderText = "Expediente cerrado";
            StudentClosed.Name = "StudentClosed";
            StudentClosed.ReadOnly = true;
            StudentClosed.Width = 103;
            // 
            // StudentNotes
            // 
            StudentNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentNotes.HeaderText = "Notas";
            StudentNotes.Name = "StudentNotes";
            StudentNotes.ReadOnly = true;
            StudentNotes.Width = 63;
            // 
            // StudentUpdatedOn
            // 
            StudentUpdatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentUpdatedOn.HeaderText = "Última actualización";
            StudentUpdatedOn.Name = "StudentUpdatedOn";
            StudentUpdatedOn.ReadOnly = true;
            StudentUpdatedOn.Width = 127;
            // 
            // StudentCreatedOn
            // 
            StudentCreatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            StudentCreatedOn.HeaderText = "Fecha de registro";
            StudentCreatedOn.Name = "StudentCreatedOn";
            StudentCreatedOn.ReadOnly = true;
            StudentCreatedOn.Width = 112;
            // 
            // ListStudentEdit
            // 
            ListStudentEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            ListStudentEdit.HeaderText = "Acciones";
            ListStudentEdit.Name = "ListStudentEdit";
            ListStudentEdit.ReadOnly = true;
            ListStudentEdit.Text = "Editar";
            ListStudentEdit.UseColumnTextForButtonValue = true;
            ListStudentEdit.Width = 61;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 15);
            label1.TabIndex = 1;
            label1.Text = "Buscar residente";
            // 
            // tb_SearchQuery
            // 
            tb_SearchQuery.Location = new System.Drawing.Point(111, 6);
            tb_SearchQuery.Name = "tb_SearchQuery";
            tb_SearchQuery.Size = new System.Drawing.Size(370, 23);
            tb_SearchQuery.TabIndex = 2;
            tb_SearchQuery.KeyPress += SearchQuery_KeyPress;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(487, 6);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += RunQuerySearch_Click;
            // 
            // button2
            // 
            button2.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(1156, 6);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(96, 23);
            button2.TabIndex = 4;
            button2.Text = "Aplicar filtro";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ApplyFilters_Click;
            // 
            // button3
            // 
            button3.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button3.Location = new System.Drawing.Point(1131, 637);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(121, 32);
            button3.TabIndex = 7;
            button3.Text = "Registrar nuevo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += AddNewCompany_Click;
            // 
            // lbl_StatusLabel
            // 
            lbl_StatusLabel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbl_StatusLabel.AutoSize = true;
            lbl_StatusLabel.Location = new System.Drawing.Point(12, 646);
            lbl_StatusLabel.Name = "lbl_StatusLabel";
            lbl_StatusLabel.Size = new System.Drawing.Size(53, 15);
            lbl_StatusLabel.TabIndex = 8;
            lbl_StatusLabel.Text = "[STATUS]";
            // 
            // cb_FilterYear
            // 
            cb_FilterYear.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cb_FilterYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_FilterYear.FormattingEnabled = true;
            cb_FilterYear.Location = new System.Drawing.Point(953, 6);
            cb_FilterYear.Name = "cb_FilterYear";
            cb_FilterYear.Size = new System.Drawing.Size(55, 23);
            cb_FilterYear.TabIndex = 9;
            // 
            // cb_FilterSemester
            // 
            cb_FilterSemester.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cb_FilterSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_FilterSemester.FormattingEnabled = true;
            cb_FilterSemester.Items.AddRange(new object[] { "Todos", "ENE-JUN", "AGO-DIC" });
            cb_FilterSemester.Location = new System.Drawing.Point(1075, 6);
            cb_FilterSemester.Name = "cb_FilterSemester";
            cb_FilterSemester.Size = new System.Drawing.Size(75, 23);
            cb_FilterSemester.TabIndex = 10;
            // 
            // label2
            // 
            label2.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(918, 10);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(29, 15);
            label2.TabIndex = 11;
            label2.Text = "Año";
            // 
            // label3
            // 
            label3.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(1014, 10);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 15);
            label3.TabIndex = 12;
            label3.Text = "Semestre";
            // 
            // StudentListViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cb_FilterSemester);
            Controls.Add(cb_FilterYear);
            Controls.Add(lbl_StatusLabel);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tb_SearchQuery);
            Controls.Add(label1);
            Controls.Add(dgv_ListView);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "StudentListViewForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "StudentListViewForm";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SearchQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentSpecialty;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentSemester;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentInternalAdvisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentExternalAdvisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentReviewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentSchedule;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StudentClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentUpdatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentCreatedOn;
        private System.Windows.Forms.DataGridViewButtonColumn ListStudentEdit;
        private System.Windows.Forms.Label lbl_StatusLabel;
        private System.Windows.Forms.ComboBox cb_FilterYear;
        private System.Windows.Forms.ComboBox cb_FilterSemester;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
