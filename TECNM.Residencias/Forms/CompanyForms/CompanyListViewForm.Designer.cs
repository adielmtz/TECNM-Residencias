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
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            tb_SearchQuery = new System.Windows.Forms.TextBox();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            btn_PagePrev = new System.Windows.Forms.Button();
            btn_PageNext = new System.Windows.Forms.Button();
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
            CompanyPostalCode.Width = 97;
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
            tb_SearchQuery.Size = new System.Drawing.Size(363, 23);
            tb_SearchQuery.TabIndex = 3;
            tb_SearchQuery.KeyPress += SearchQuery_KeyPress;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(557, 6);
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
            button3.Location = new System.Drawing.Point(1131, 5);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(121, 23);
            button3.TabIndex = 5;
            button3.Text = "Mostrar todo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ShowAllRows_Click;
            // 
            // btn_PagePrev
            // 
            btn_PagePrev.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_PagePrev.Location = new System.Drawing.Point(12, 646);
            btn_PagePrev.Name = "btn_PagePrev";
            btn_PagePrev.Size = new System.Drawing.Size(23, 23);
            btn_PagePrev.TabIndex = 6;
            btn_PagePrev.Text = "<";
            btn_PagePrev.UseVisualStyleBackColor = true;
            btn_PagePrev.Click += PagePrev_Click;
            // 
            // btn_PageNext
            // 
            btn_PageNext.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_PageNext.Location = new System.Drawing.Point(41, 646);
            btn_PageNext.Name = "btn_PageNext";
            btn_PageNext.Size = new System.Drawing.Size(23, 23);
            btn_PageNext.TabIndex = 7;
            btn_PageNext.Text = ">";
            btn_PageNext.UseVisualStyleBackColor = true;
            btn_PageNext.Click += PageNext_Click;
            // 
            // CompanyListViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(btn_PageNext);
            Controls.Add(btn_PagePrev);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(tb_SearchQuery);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dgv_ListView);
            DoubleBuffered = true;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SearchQuery;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_PagePrev;
        private System.Windows.Forms.Button btn_PageNext;
    }
}