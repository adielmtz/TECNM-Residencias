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
            dgv_ListView = new System.Windows.Forms.DataGridView();
            button1 = new System.Windows.Forms.Button();
            CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyRfc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyLocality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyPostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            CompanyUpdatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CompanyEdit = new System.Windows.Forms.DataGridViewButtonColumn();
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
            dgv_ListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { CompanyName, CompanyRfc, CompanyType, CompanyEmail, CompanyPhone, CompanyAddress, CompanyLocality, CompanyPostalCode, CompanyCity, CompanyEnabled, CompanyUpdatedOn, CompanyCreatedOn, CompanyEdit });
            dgv_ListView.Location = new System.Drawing.Point(12, 12);
            dgv_ListView.MultiSelect = false;
            dgv_ListView.Name = "dgv_ListView";
            dgv_ListView.ReadOnly = true;
            dgv_ListView.RowHeadersVisible = false;
            dgv_ListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_ListView.Size = new System.Drawing.Size(1240, 619);
            dgv_ListView.TabIndex = 0;
            dgv_ListView.CellContentClick += ListView_CellContentClick;
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
            // CompanyName
            // 
            CompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            CompanyName.HeaderText = "Nombre";
            CompanyName.Name = "CompanyName";
            CompanyName.ReadOnly = true;
            // 
            // CompanyRfc
            // 
            CompanyRfc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyRfc.HeaderText = "RFC";
            CompanyRfc.Name = "CompanyRfc";
            CompanyRfc.ReadOnly = true;
            CompanyRfc.Width = 53;
            // 
            // CompanyType
            // 
            CompanyType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyType.HeaderText = "Giro";
            CompanyType.Name = "CompanyType";
            CompanyType.ReadOnly = true;
            CompanyType.Width = 54;
            // 
            // CompanyEmail
            // 
            CompanyEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyEmail.HeaderText = "Correo";
            CompanyEmail.Name = "CompanyEmail";
            CompanyEmail.ReadOnly = true;
            CompanyEmail.Width = 68;
            // 
            // CompanyPhone
            // 
            CompanyPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyPhone.HeaderText = "Teléfono";
            CompanyPhone.Name = "CompanyPhone";
            CompanyPhone.ReadOnly = true;
            CompanyPhone.Width = 77;
            // 
            // CompanyAddress
            // 
            CompanyAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyAddress.HeaderText = "Dirección";
            CompanyAddress.Name = "CompanyAddress";
            CompanyAddress.ReadOnly = true;
            CompanyAddress.Width = 82;
            // 
            // CompanyLocality
            // 
            CompanyLocality.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyLocality.HeaderText = "Colonia";
            CompanyLocality.Name = "CompanyLocality";
            CompanyLocality.ReadOnly = true;
            CompanyLocality.Width = 73;
            // 
            // CompanyPostalCode
            // 
            CompanyPostalCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            CompanyPostalCode.HeaderText = "Código Postal";
            CompanyPostalCode.Name = "CompanyPostalCode";
            CompanyPostalCode.ReadOnly = true;
            CompanyPostalCode.Width = 106;
            // 
            // CompanyCity
            // 
            CompanyCity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyCity.HeaderText = "Ubicación";
            CompanyCity.Name = "CompanyCity";
            CompanyCity.ReadOnly = true;
            CompanyCity.Width = 85;
            // 
            // CompanyEnabled
            // 
            CompanyEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            CompanyEnabled.HeaderText = "Habilitada";
            CompanyEnabled.Name = "CompanyEnabled";
            CompanyEnabled.ReadOnly = true;
            CompanyEnabled.Width = 67;
            // 
            // CompanyUpdatedOn
            // 
            CompanyUpdatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyUpdatedOn.HeaderText = "Última modificación";
            CompanyUpdatedOn.Name = "CompanyUpdatedOn";
            CompanyUpdatedOn.ReadOnly = true;
            CompanyUpdatedOn.Width = 128;
            // 
            // CompanyCreatedOn
            // 
            CompanyCreatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyCreatedOn.HeaderText = "Fecha de registro";
            CompanyCreatedOn.Name = "CompanyCreatedOn";
            CompanyCreatedOn.ReadOnly = true;
            CompanyCreatedOn.Width = 112;
            // 
            // CompanyEdit
            // 
            CompanyEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CompanyEdit.HeaderText = "Acciones";
            CompanyEdit.Name = "CompanyEdit";
            CompanyEdit.ReadOnly = true;
            CompanyEdit.Text = "Editar";
            CompanyEdit.UseColumnTextForButtonValue = true;
            CompanyEdit.Width = 61;
            // 
            // CompanyListViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(button1);
            Controls.Add(dgv_ListView);
            Name = "CompanyListViewForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CompanyListViewForm";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += CompanyListViewForm_Load;
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRfc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyLocality;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyPostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CompanyEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyUpdatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCreatedOn;
        private System.Windows.Forms.DataGridViewButtonColumn CompanyEdit;
    }
}