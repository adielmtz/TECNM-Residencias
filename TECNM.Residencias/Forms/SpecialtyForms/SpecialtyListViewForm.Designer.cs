namespace TECNM.Residencias.Forms.SpecialtyForms
{
    partial class SpecialtyListViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialtyListViewForm));
            dgv_ListView = new System.Windows.Forms.DataGridView();
            SpecialtyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SpecialtyEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            SpecialtyUpdatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SpecialtyCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SpecialtyEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            button1 = new System.Windows.Forms.Button();
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
            dgv_ListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { SpecialtyName, SpecialtyEnabled, SpecialtyUpdatedOn, SpecialtyCreatedOn, SpecialtyEdit });
            dgv_ListView.Location = new System.Drawing.Point(12, 12);
            dgv_ListView.MultiSelect = false;
            dgv_ListView.Name = "dgv_ListView";
            dgv_ListView.ReadOnly = true;
            dgv_ListView.RowHeadersVisible = false;
            dgv_ListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_ListView.Size = new System.Drawing.Size(814, 379);
            dgv_ListView.TabIndex = 0;
            dgv_ListView.CellContentClick += ListView_CellContentClick;
            // 
            // SpecialtyName
            // 
            SpecialtyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            SpecialtyName.HeaderText = "Nombre";
            SpecialtyName.Name = "SpecialtyName";
            SpecialtyName.ReadOnly = true;
            // 
            // SpecialtyEnabled
            // 
            SpecialtyEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            SpecialtyEnabled.HeaderText = "Habilitada";
            SpecialtyEnabled.Name = "SpecialtyEnabled";
            SpecialtyEnabled.ReadOnly = true;
            SpecialtyEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            SpecialtyEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            SpecialtyEnabled.Width = 86;
            // 
            // SpecialtyUpdatedOn
            // 
            SpecialtyUpdatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            SpecialtyUpdatedOn.HeaderText = "Última modificación";
            SpecialtyUpdatedOn.Name = "SpecialtyUpdatedOn";
            SpecialtyUpdatedOn.ReadOnly = true;
            SpecialtyUpdatedOn.Width = 128;
            // 
            // SpecialtyCreatedOn
            // 
            SpecialtyCreatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            SpecialtyCreatedOn.HeaderText = "Fecha de registro";
            SpecialtyCreatedOn.Name = "SpecialtyCreatedOn";
            SpecialtyCreatedOn.ReadOnly = true;
            SpecialtyCreatedOn.Width = 112;
            // 
            // SpecialtyEdit
            // 
            SpecialtyEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            SpecialtyEdit.HeaderText = "Acciones";
            SpecialtyEdit.Name = "SpecialtyEdit";
            SpecialtyEdit.ReadOnly = true;
            SpecialtyEdit.Text = "Editar";
            SpecialtyEdit.UseColumnTextForButtonValue = true;
            SpecialtyEdit.Width = 61;
            // 
            // button1
            // 
            button1.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(705, 397);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(121, 32);
            button1.TabIndex = 1;
            button1.Text = "Añadir nueva";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddNewSpecialty_Click;
            // 
            // lbl_StatusLabel
            // 
            lbl_StatusLabel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbl_StatusLabel.AutoSize = true;
            lbl_StatusLabel.Location = new System.Drawing.Point(12, 406);
            lbl_StatusLabel.Name = "lbl_StatusLabel";
            lbl_StatusLabel.Size = new System.Drawing.Size(53, 15);
            lbl_StatusLabel.TabIndex = 2;
            lbl_StatusLabel.Text = "[STATUS]";
            // 
            // SpecialtyListViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(838, 441);
            Controls.Add(lbl_StatusLabel);
            Controls.Add(button1);
            Controls.Add(dgv_ListView);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "SpecialtyListViewForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SpecialtyListViewForm";
            Load += SpecialtyListViewForm_Load;
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialtyName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SpecialtyEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialtyUpdatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialtyCreatedOn;
        private System.Windows.Forms.DataGridViewButtonColumn SpecialtyEdit;
        private System.Windows.Forms.Label lbl_StatusLabel;
    }
}