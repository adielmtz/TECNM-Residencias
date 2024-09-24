namespace TECNM.Residencias.Controls
{
    partial class DocumentListItemControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            cb_DocumentType = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            lbl_OriginalName = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Tipo";
            // 
            // cb_DocumentType
            // 
            cb_DocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_DocumentType.FormattingEnabled = true;
            cb_DocumentType.Location = new System.Drawing.Point(36, 3);
            cb_DocumentType.Name = "cb_DocumentType";
            cb_DocumentType.Size = new System.Drawing.Size(200, 23);
            cb_DocumentType.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(242, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Abrir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OpenFile_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(323, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DeleteFile_Click;
            // 
            // lbl_OriginalName
            // 
            lbl_OriginalName.AutoSize = true;
            lbl_OriginalName.Location = new System.Drawing.Point(36, 29);
            lbl_OriginalName.Name = "lbl_OriginalName";
            lbl_OriginalName.Size = new System.Drawing.Size(105, 15);
            lbl_OriginalName.TabIndex = 4;
            lbl_OriginalName.Text = "[ORIGINAL NAME]";
            // 
            // DocumentListItemControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lbl_OriginalName);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(cb_DocumentType);
            Controls.Add(label1);
            Name = "DocumentListItemControl";
            Size = new System.Drawing.Size(400, 45);
            Load += DocumentListItemControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_DocumentType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_OriginalName;
    }
}
