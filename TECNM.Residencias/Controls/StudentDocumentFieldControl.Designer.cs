namespace TECNM.Residencias.Controls
{
    partial class StudentDocumentFieldControl
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
            lbl_DocumentName = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            cb_DocumentType = new System.Windows.Forms.ComboBox();
            button3 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lbl_DocumentName
            // 
            lbl_DocumentName.AutoSize = true;
            lbl_DocumentName.Location = new System.Drawing.Point(39, 40);
            lbl_DocumentName.Name = "lbl_DocumentName";
            lbl_DocumentName.Size = new System.Drawing.Size(105, 15);
            lbl_DocumentName.TabIndex = 0;
            lbl_DocumentName.Text = "NO HAY ARCHIVO";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(351, 8);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Abrir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OpenFile_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(235, 8);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(110, 23);
            button2.TabIndex = 2;
            button2.Text = "Cargar archivo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += UploadFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(30, 15);
            label1.TabIndex = 3;
            label1.Text = "Tipo";
            // 
            // cb_DocumentType
            // 
            cb_DocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_DocumentType.FormattingEnabled = true;
            cb_DocumentType.Location = new System.Drawing.Point(39, 8);
            cb_DocumentType.Name = "cb_DocumentType";
            cb_DocumentType.Size = new System.Drawing.Size(190, 23);
            cb_DocumentType.TabIndex = 4;
            cb_DocumentType.SelectedIndexChanged += DocumentType_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(351, 36);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += RemoveDocument_Click;
            // 
            // StudentDocumentFieldControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            BackColor = System.Drawing.SystemColors.Control;
            Controls.Add(button3);
            Controls.Add(cb_DocumentType);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lbl_DocumentName);
            Name = "StudentDocumentFieldControl";
            Size = new System.Drawing.Size(433, 64);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_DocumentName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_DocumentType;
        private System.Windows.Forms.Button button3;
    }
}
