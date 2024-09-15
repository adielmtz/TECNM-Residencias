namespace TECNM.Residencias.Forms.CompanyForms
{
    partial class CompanyListViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyListViewForm));
            dgv_ListView = new System.Windows.Forms.DataGridView();
            ListCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyRfc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyLocality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyPostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ListCompanyUpdatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            ListCompanyAdvisors = new System.Windows.Forms.DataGridViewButtonColumn();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            tb_SearchQuery = new System.Windows.Forms.TextBox();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            btn_PagePrev = new System.Windows.Forms.Button();
            btn_PageNext = new System.Windows.Forms.Button();
            lbl_StatusLabel = new System.Windows.Forms.Label();
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
            dgv_ListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ListCompanyName, ListCompanyRfc, ListCompanyType, ListCompanyEmail, ListCompanyPhone, ListCompanyAddress, ListCompanyLocality, ListCompanyPostalCode, ListCompanyCity, ListCompanyEnabled, ListCompanyUpdatedOn, ListCompanyCreatedOn, ListCompanyEdit, ListCompanyAdvisors });
            dgv_ListView.Location = new System.Drawing.Point(12, 35);
            dgv_ListView.MultiSelect = false;
            dgv_ListView.Name = "dgv_ListView";
            dgv_ListView.ReadOnly = true;
            dgv_ListView.RowHeadersVisible = false;
            dgv_ListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_ListView.Size = new System.Drawing.Size(1240, 596);
            dgv_ListView.TabIndex = 0;
            dgv_ListView.CellContentClick += ListView_CellContentClick;
            // 
            // ListCompanyName
            // 
            ListCompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            ListCompanyName.HeaderText = "Nombre";
            ListCompanyName.Name = "ListCompanyName";
            ListCompanyName.ReadOnly = true;
            // 
            // ListCompanyRfc
            // 
            ListCompanyRfc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyRfc.HeaderText = "RFC";
            ListCompanyRfc.Name = "ListCompanyRfc";
            ListCompanyRfc.ReadOnly = true;
            ListCompanyRfc.Width = 53;
            // 
            // ListCompanyType
            // 
            ListCompanyType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyType.HeaderText = "Giro";
            ListCompanyType.Name = "ListCompanyType";
            ListCompanyType.ReadOnly = true;
            ListCompanyType.Width = 54;
            // 
            // ListCompanyEmail
            // 
            ListCompanyEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyEmail.HeaderText = "Correo";
            ListCompanyEmail.Name = "ListCompanyEmail";
            ListCompanyEmail.ReadOnly = true;
            ListCompanyEmail.Width = 68;
            // 
            // ListCompanyPhone
            // 
            ListCompanyPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyPhone.HeaderText = "Teléfono";
            ListCompanyPhone.Name = "ListCompanyPhone";
            ListCompanyPhone.ReadOnly = true;
            ListCompanyPhone.Width = 77;
            // 
            // ListCompanyAddress
            // 
            ListCompanyAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyAddress.HeaderText = "Dirección";
            ListCompanyAddress.Name = "ListCompanyAddress";
            ListCompanyAddress.ReadOnly = true;
            ListCompanyAddress.Width = 82;
            // 
            // ListCompanyLocality
            // 
            ListCompanyLocality.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyLocality.HeaderText = "Colonia";
            ListCompanyLocality.Name = "ListCompanyLocality";
            ListCompanyLocality.ReadOnly = true;
            ListCompanyLocality.Width = 73;
            // 
            // ListCompanyPostalCode
            // 
            ListCompanyPostalCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            ListCompanyPostalCode.HeaderText = "Código Postal";
            ListCompanyPostalCode.Name = "ListCompanyPostalCode";
            ListCompanyPostalCode.ReadOnly = true;
            ListCompanyPostalCode.Width = 97;
            // 
            // ListCompanyCity
            // 
            ListCompanyCity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyCity.HeaderText = "Ubicación";
            ListCompanyCity.Name = "ListCompanyCity";
            ListCompanyCity.ReadOnly = true;
            ListCompanyCity.Width = 85;
            // 
            // ListCompanyEnabled
            // 
            ListCompanyEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            ListCompanyEnabled.HeaderText = "Habilitada";
            ListCompanyEnabled.Name = "ListCompanyEnabled";
            ListCompanyEnabled.ReadOnly = true;
            ListCompanyEnabled.Width = 67;
            // 
            // ListCompanyUpdatedOn
            // 
            ListCompanyUpdatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyUpdatedOn.HeaderText = "Última modificación";
            ListCompanyUpdatedOn.Name = "ListCompanyUpdatedOn";
            ListCompanyUpdatedOn.ReadOnly = true;
            ListCompanyUpdatedOn.Width = 128;
            // 
            // ListCompanyCreatedOn
            // 
            ListCompanyCreatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyCreatedOn.HeaderText = "Fecha de registro";
            ListCompanyCreatedOn.Name = "ListCompanyCreatedOn";
            ListCompanyCreatedOn.ReadOnly = true;
            ListCompanyCreatedOn.Width = 112;
            // 
            // ListCompanyEdit
            // 
            ListCompanyEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyEdit.HeaderText = "Acciones";
            ListCompanyEdit.Name = "ListCompanyEdit";
            ListCompanyEdit.ReadOnly = true;
            ListCompanyEdit.Text = "Editar";
            ListCompanyEdit.UseColumnTextForButtonValue = true;
            ListCompanyEdit.Width = 61;
            // 
            // ListCompanyAdvisors
            // 
            ListCompanyAdvisors.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyAdvisors.HeaderText = "Asesores";
            ListCompanyAdvisors.Name = "ListCompanyAdvisors";
            ListCompanyAdvisors.ReadOnly = true;
            ListCompanyAdvisors.Text = "Ver asesores";
            ListCompanyAdvisors.UseColumnTextForButtonValue = true;
            ListCompanyAdvisors.Width = 59;
            // 
            // button1
            // 
            button1.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(1131, 637);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(121, 32);
            button1.TabIndex = 1;
            button1.Text = "Añadir nueva";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddNewCompany_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(170, 15);
            label1.TabIndex = 2;
            label1.Text = "Buscar empresa (nombre o rfc)";
            // 
            // tb_SearchQuery
            // 
            tb_SearchQuery.Location = new System.Drawing.Point(188, 6);
            tb_SearchQuery.Name = "tb_SearchQuery";
            tb_SearchQuery.Size = new System.Drawing.Size(360, 23);
            tb_SearchQuery.TabIndex = 3;
            tb_SearchQuery.KeyPress += SearchQuery_KeyPress;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(554, 6);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Buscar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += RunQuerySearch_Click;
            // 
            // button3
            // 
            button3.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button3.Location = new System.Drawing.Point(1132, 6);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(120, 23);
            button3.TabIndex = 5;
            button3.Text = "Mostrar todo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ResetSearch_Click;
            // 
            // btn_PagePrev
            // 
            btn_PagePrev.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_PagePrev.Location = new System.Drawing.Point(12, 637);
            btn_PagePrev.Name = "btn_PagePrev";
            btn_PagePrev.Size = new System.Drawing.Size(32, 32);
            btn_PagePrev.TabIndex = 6;
            btn_PagePrev.Text = "<";
            btn_PagePrev.UseVisualStyleBackColor = true;
            btn_PagePrev.Click += PagePrev_Click;
            // 
            // btn_PageNext
            // 
            btn_PageNext.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_PageNext.Location = new System.Drawing.Point(50, 637);
            btn_PageNext.Name = "btn_PageNext";
            btn_PageNext.Size = new System.Drawing.Size(32, 32);
            btn_PageNext.TabIndex = 7;
            btn_PageNext.Text = ">";
            btn_PageNext.UseVisualStyleBackColor = true;
            btn_PageNext.Click += PageNext_Click;
            // 
            // lbl_StatusLabel
            // 
            lbl_StatusLabel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbl_StatusLabel.AutoSize = true;
            lbl_StatusLabel.Location = new System.Drawing.Point(88, 646);
            lbl_StatusLabel.Name = "lbl_StatusLabel";
            lbl_StatusLabel.Size = new System.Drawing.Size(53, 15);
            lbl_StatusLabel.TabIndex = 8;
            lbl_StatusLabel.Text = "[STATUS]";
            // 
            // CompanyListViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(lbl_StatusLabel);
            Controls.Add(btn_PageNext);
            Controls.Add(btn_PagePrev);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(tb_SearchQuery);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dgv_ListView);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "CompanyListViewForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CompanyListViewForm";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += CompanyListViewForm_Load;
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SearchQuery;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_PagePrev;
        private System.Windows.Forms.Button btn_PageNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyRfc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyLocality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyPostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyCity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ListCompanyEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyUpdatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyCreatedOn;
        private System.Windows.Forms.DataGridViewButtonColumn ListCompanyEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ListCompanyAdvisors;
        private System.Windows.Forms.Label lbl_StatusLabel;
    }
}