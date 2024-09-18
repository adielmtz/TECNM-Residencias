namespace TECNM.Residencias.Forms.CompanyForms
{
    partial class CompanyQuickSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyQuickSearchForm));
            label1 = new System.Windows.Forms.Label();
            tb_SearchQuery = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            dgv_ListView = new System.Windows.Forms.DataGridView();
            ListCompanyRfc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListCompanySelect = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre o RFC";
            //
            // tb_SearchQuery
            //
            tb_SearchQuery.Location = new System.Drawing.Point(103, 6);
            tb_SearchQuery.Name = "tb_SearchQuery";
            tb_SearchQuery.Size = new System.Drawing.Size(352, 23);
            tb_SearchQuery.TabIndex = 1;
            tb_SearchQuery.KeyPress += SearchQuery_KeyPress;
            //
            // button1
            //
            button1.Location = new System.Drawing.Point(461, 6);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += RunSearch_Click;
            //
            // dgv_ListView
            //
            dgv_ListView.AllowUserToAddRows = false;
            dgv_ListView.AllowUserToDeleteRows = false;
            dgv_ListView.AllowUserToResizeRows = false;
            dgv_ListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ListCompanyRfc, ListCompanyName, ListCompanySelect });
            dgv_ListView.Location = new System.Drawing.Point(12, 35);
            dgv_ListView.Name = "dgv_ListView";
            dgv_ListView.ReadOnly = true;
            dgv_ListView.RowHeadersVisible = false;
            dgv_ListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_ListView.Size = new System.Drawing.Size(524, 404);
            dgv_ListView.TabIndex = 3;
            dgv_ListView.CellContentClick += ListView_CellContentClick;
            //
            // ListCompanyRfc
            //
            ListCompanyRfc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanyRfc.HeaderText = "RFC";
            ListCompanyRfc.Name = "ListCompanyRfc";
            ListCompanyRfc.ReadOnly = true;
            ListCompanyRfc.Width = 53;
            //
            // ListCompanyName
            //
            ListCompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            ListCompanyName.HeaderText = "Nombre";
            ListCompanyName.Name = "ListCompanyName";
            ListCompanyName.ReadOnly = true;
            //
            // ListCompanySelect
            //
            ListCompanySelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListCompanySelect.HeaderText = "Acción";
            ListCompanySelect.Name = "ListCompanySelect";
            ListCompanySelect.ReadOnly = true;
            ListCompanySelect.Text = "Seleccionar";
            ListCompanySelect.UseColumnTextForButtonValue = true;
            ListCompanySelect.Width = 50;
            //
            // CompanyQuickSearchForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(548, 451);
            Controls.Add(dgv_ListView);
            Controls.Add(button1);
            Controls.Add(tb_SearchQuery);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "CompanyQuickSearchForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Buscar empresa";
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SearchQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_ListView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyRfc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListCompanyName;
        private System.Windows.Forms.DataGridViewButtonColumn ListCompanySelect;
    }
}
