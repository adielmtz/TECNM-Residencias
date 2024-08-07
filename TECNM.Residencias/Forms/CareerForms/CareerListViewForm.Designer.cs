namespace TECNM.Residencias.Forms.CareerForms
{
    partial class CareerListViewForm
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
            CareerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CareerEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            CareerUpdatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CareerCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CareerEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            CareerViewSpecialties = new System.Windows.Forms.DataGridViewButtonColumn();
            button1 = new System.Windows.Forms.Button();
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
            dgv_ListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { CareerName, CareerEnabled, CareerUpdatedOn, CareerCreatedOn, CareerEdit, CareerViewSpecialties });
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
            // CareerName
            // 
            CareerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            CareerName.HeaderText = "Nombre";
            CareerName.Name = "CareerName";
            CareerName.ReadOnly = true;
            // 
            // CareerEnabled
            // 
            CareerEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            CareerEnabled.HeaderText = "Habilitada";
            CareerEnabled.Name = "CareerEnabled";
            CareerEnabled.ReadOnly = true;
            CareerEnabled.Width = 67;
            // 
            // CareerUpdatedOn
            // 
            CareerUpdatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CareerUpdatedOn.HeaderText = "Última modificación";
            CareerUpdatedOn.Name = "CareerUpdatedOn";
            CareerUpdatedOn.ReadOnly = true;
            CareerUpdatedOn.Width = 128;
            // 
            // CareerCreatedOn
            // 
            CareerCreatedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            CareerCreatedOn.HeaderText = "Fecha de registro";
            CareerCreatedOn.Name = "CareerCreatedOn";
            CareerCreatedOn.ReadOnly = true;
            CareerCreatedOn.Width = 112;
            // 
            // CareerEdit
            // 
            CareerEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            CareerEdit.HeaderText = "Acciones";
            CareerEdit.Name = "CareerEdit";
            CareerEdit.ReadOnly = true;
            CareerEdit.Text = "Editar";
            CareerEdit.UseColumnTextForButtonValue = true;
            CareerEdit.Width = 61;
            // 
            // CareerViewSpecialties
            // 
            CareerViewSpecialties.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            CareerViewSpecialties.HeaderText = "Especialidades";
            CareerViewSpecialties.Name = "CareerViewSpecialties";
            CareerViewSpecialties.ReadOnly = true;
            CareerViewSpecialties.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            CareerViewSpecialties.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            CareerViewSpecialties.Text = "Ver especialidades";
            CareerViewSpecialties.UseColumnTextForButtonValue = true;
            CareerViewSpecialties.Width = 108;
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
            button1.Click += AddNewCareer_Click;
            // 
            // CareerListViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(838, 441);
            Controls.Add(button1);
            Controls.Add(dgv_ListView);
            Name = "CareerListViewForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CareerListViewForm";
            Load += CareerListViewForm_Load;
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ListView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CareerEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerUpdatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerCreatedOn;
        private System.Windows.Forms.DataGridViewButtonColumn CareerEdit;
        private System.Windows.Forms.DataGridViewButtonColumn CareerViewSpecialties;
        private System.Windows.Forms.Button button1;
    }
}
