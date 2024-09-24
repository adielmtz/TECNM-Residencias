namespace TECNM.Residencias.Forms.AdvisorForms
{
    partial class AdvisorQuickSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvisorQuickSearchForm));
            label1 = new System.Windows.Forms.Label();
            tb_SearchQuery = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            dgv_ListView = new System.Windows.Forms.DataGridView();
            ListAdvisorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ListAdvisorAction = new System.Windows.Forms.DataGridViewButtonColumn();
            button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // tb_SearchQuery
            // 
            tb_SearchQuery.Location = new System.Drawing.Point(69, 6);
            tb_SearchQuery.Name = "tb_SearchQuery";
            tb_SearchQuery.Size = new System.Drawing.Size(386, 23);
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
            dgv_ListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ListAdvisorName, ListAdvisorAction });
            dgv_ListView.Location = new System.Drawing.Point(12, 35);
            dgv_ListView.Name = "dgv_ListView";
            dgv_ListView.ReadOnly = true;
            dgv_ListView.RowHeadersVisible = false;
            dgv_ListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv_ListView.Size = new System.Drawing.Size(524, 374);
            dgv_ListView.TabIndex = 3;
            dgv_ListView.CellContentClick += ListView_CellContentClick;
            // 
            // ListAdvisorName
            // 
            ListAdvisorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            ListAdvisorName.HeaderText = "Nombre";
            ListAdvisorName.Name = "ListAdvisorName";
            ListAdvisorName.ReadOnly = true;
            // 
            // ListAdvisorAction
            // 
            ListAdvisorAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            ListAdvisorAction.HeaderText = "Acción";
            ListAdvisorAction.Name = "ListAdvisorAction";
            ListAdvisorAction.ReadOnly = true;
            ListAdvisorAction.Text = "Seleccionar";
            ListAdvisorAction.UseColumnTextForButtonValue = true;
            ListAdvisorAction.Width = 50;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(421, 415);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(115, 24);
            button2.TabIndex = 4;
            button2.Text = "Añadir nuevo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += QuickAddAdvisor_Click;
            // 
            // AdvisorQuickSearchForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(548, 451);
            Controls.Add(button2);
            Controls.Add(dgv_ListView);
            Controls.Add(button1);
            Controls.Add(tb_SearchQuery);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "AdvisorQuickSearchForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Buscar asesor";
            ((System.ComponentModel.ISupportInitialize) dgv_ListView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SearchQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_ListView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListAdvisorName;
        private System.Windows.Forms.DataGridViewButtonColumn ListAdvisorAction;
        private System.Windows.Forms.Button button2;
    }
}
