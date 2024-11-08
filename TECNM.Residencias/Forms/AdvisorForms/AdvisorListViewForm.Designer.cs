namespace TECNM.Residencias.Forms.AdvisorForms
{
    partial class AdvisorListViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvisorListViewForm));
            dgv_ListView = new System.Windows.Forms.DataGridView();
            button1 = new System.Windows.Forms.Button();
            lbl_StatusLabel = new System.Windows.Forms.Label();
            ListAdvisorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorPhoneExt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ListAdvisorUpdatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorActions = new System.Windows.Forms.DataGridViewButtonColumn();
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
            dgv_ListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ListAdvisorName, ListAdvisorSection, ListAdvisorRole, ListAdvisorEmail, ListAdvisorPhone, ListAdvisorPhoneExt, ListAdvisorEnabled, ListAdvisorUpdatedOn, ListAdvisorCreatedOn, ListAdvisorActions });
            dgv_ListView.Location = new System.Drawing.Point(12, 12);
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
            button1.Text = "Añadir nuevo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddNewAdvisor_Click;
            // 
            // lbl_StatusLabel
            // 
            lbl_StatusLabel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbl_StatusLabel.AutoSize = true;
            lbl_StatusLabel.Location = new System.Drawing.Point(12, 646);
            lbl_StatusLabel.Name = "lbl_StatusLabel";
            lbl_StatusLabel.Size = new System.Drawing.Size(53, 15);
            lbl_StatusLabel.TabIndex = 2;
            lbl_StatusLabel.Text = "[STATUS]";
            // 
            // ListAdvisorName
            // 
            ListAdvisorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorName.HeaderText = "Nombre";
            ListAdvisorName.Name = "ListAdvisorName";
            ListAdvisorName.ReadOnly = true;
            ListAdvisorName.Width = 76;
            // 
            // ListAdvisorSection
            // 
            ListAdvisorSection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorSection.HeaderText = "Departamento";
            ListAdvisorSection.Name = "ListAdvisorSection";
            ListAdvisorSection.ReadOnly = true;
            ListAdvisorSection.Width = 108;
            // 
            // ListAdvisorRole
            // 
            ListAdvisorRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorRole.HeaderText = "Puesto";
            ListAdvisorRole.Name = "ListAdvisorRole";
            ListAdvisorRole.ReadOnly = true;
            ListAdvisorRole.Width = 68;
            // 
            // ListAdvisorEmail
            // 
            ListAdvisorEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorEmail.HeaderText = "Correo";
            ListAdvisorEmail.Name = "ListAdvisorEmail";
            ListAdvisorEmail.ReadOnly = true;
            ListAdvisorEmail.Width = 68;
            // 
            // ListAdvisorPhone
            // 
            ListAdvisorPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorPhone.HeaderText = "Teléfono";
            ListAdvisorPhone.Name = "ListAdvisorPhone";
            ListAdvisorPhone.ReadOnly = true;
            ListAdvisorPhone.Width = 77;
            // 
            // ListAdvisorPhoneExt
            // 
            ListAdvisorPhoneExt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorPhoneExt.HeaderText = "Extension";
            ListAdvisorPhoneExt.Name = "ListAdvisorPhoneExt";
            ListAdvisorPhoneExt.ReadOnly = true;
            ListAdvisorPhoneExt.Width = 83;
            // 
            // ListAdvisorEnabled
            // 
            ListAdvisorEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            ListAdvisorEnabled.HeaderText = "Habilitado";
            ListAdvisorEnabled.Name = "ListAdvisorEnabled";
            ListAdvisorEnabled.ReadOnly = true;
            ListAdvisorEnabled.Width = 68;
            // 
            // ListAdvisorUpdatedOn
            // 
            ListAdvisorUpdatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorUpdatedOn.HeaderText = "Última modificación";
            ListAdvisorUpdatedOn.Name = "ListAdvisorUpdatedOn";
            ListAdvisorUpdatedOn.ReadOnly = true;
            ListAdvisorUpdatedOn.Width = 128;
            // 
            // ListAdvisorCreatedOn
            // 
            ListAdvisorCreatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorCreatedOn.HeaderText = "Fecha de registro";
            ListAdvisorCreatedOn.Name = "ListAdvisorCreatedOn";
            ListAdvisorCreatedOn.ReadOnly = true;
            ListAdvisorCreatedOn.Width = 112;
            // 
            // ListAdvisorActions
            // 
            ListAdvisorActions.HeaderText = "Acciones";
            ListAdvisorActions.Name = "ListAdvisorActions";
            ListAdvisorActions.ReadOnly = true;
            ListAdvisorActions.Text = "Editar";
            ListAdvisorActions.UseColumnTextForButtonValue = true;
            // 
            // AdvisorListViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(lbl_StatusLabel);
            Controls.Add(button1);
            Controls.Add(dgv_ListView);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "AdvisorListViewForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "AdvisorListViewForm";
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_StatusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorPhoneExt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ListAdvisorEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorUpdatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorCreatedOn;
        private System.Windows.Forms.DataGridViewButtonColumn ListAdvisorActions;
    }
}
