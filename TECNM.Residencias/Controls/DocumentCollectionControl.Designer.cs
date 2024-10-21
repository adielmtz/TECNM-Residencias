namespace TECNM.Residencias.Controls
{
    partial class DocumentCollectionControl
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
            flp_ControlContainer = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            // 
            // flp_ControlContainer
            // 
            flp_ControlContainer.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flp_ControlContainer.AutoScroll = true;
            flp_ControlContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flp_ControlContainer.Location = new System.Drawing.Point(3, 3);
            flp_ControlContainer.Name = "flp_ControlContainer";
            flp_ControlContainer.Size = new System.Drawing.Size(436, 302);
            flp_ControlContainer.TabIndex = 0;
            flp_ControlContainer.WrapContents = false;
            // 
            // DocumentCollectionControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(flp_ControlContainer);
            DoubleBuffered = true;
            Name = "DocumentCollectionControl";
            Size = new System.Drawing.Size(442, 308);
            Load += DocumentCollectionControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_ControlContainer;
    }
}
