namespace Pove.TouchKeyboard
{
    partial class TouchKey
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnKey = new System.Windows.Forms.Panel();
            this.laUp = new System.Windows.Forms.Label();
            this.laDown = new System.Windows.Forms.Label();
            this.laAlt = new System.Windows.Forms.Label();
            this.pnKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnKey
            // 
            this.pnKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.pnKey.Controls.Add(this.laUp);
            this.pnKey.Controls.Add(this.laDown);
            this.pnKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnKey.ForeColor = System.Drawing.Color.White;
            this.pnKey.Location = new System.Drawing.Point(0, 0);
            this.pnKey.Name = "pnKey";
            this.pnKey.Size = new System.Drawing.Size(75, 75);
            this.pnKey.TabIndex = 0;
            this.pnKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnKey_MouseDown);
            this.pnKey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnKey_MouseUp);
            // 
            // laUp
            // 
            this.laUp.AutoSize = true;
            this.laUp.Location = new System.Drawing.Point(2, 2);
            this.laUp.Name = "laUp";
            this.laUp.Size = new System.Drawing.Size(10, 13);
            this.laUp.TabIndex = 1;
            this.laUp.Text = ":";
            this.laUp.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.laUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnKey_MouseDown);
            this.laUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnKey_MouseUp);
            // 
            // laDown
            // 
            this.laDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.laDown.AutoSize = true;
            this.laDown.Location = new System.Drawing.Point(0, 45);
            this.laDown.Name = "laDown";
            this.laDown.Size = new System.Drawing.Size(10, 13);
            this.laDown.TabIndex = 2;
            this.laDown.Text = ".";
            this.laDown.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.laDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnKey_MouseDown);
            this.laDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnKey_MouseUp);
            // 
            // laAlt
            // 
            this.laAlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.laAlt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(128)))), ((int)(((byte)(133)))));
            this.laAlt.Location = new System.Drawing.Point(0, 0);
            this.laAlt.Name = "laAlt";
            this.laAlt.Size = new System.Drawing.Size(100, 23);
            this.laAlt.TabIndex = 0;
            this.laAlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TouchKey
            // 
            this.Controls.Add(this.pnKey);
            this.Size = new System.Drawing.Size(75, 75);
            this.pnKey.ResumeLayout(false);
            this.pnKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnKey;
        private System.Windows.Forms.Label laUp;
        private System.Windows.Forms.Label laDown;
        private System.Windows.Forms.Label laAlt;
    }
}
