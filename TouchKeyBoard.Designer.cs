namespace Pove.TouchKeyboard
{
    partial class TouchKeyBoard
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
            this.layoutFondo = new System.Windows.Forms.TableLayoutPanel();
            this.timerRepeatKey = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // layoutFondo
            // 
            this.layoutFondo.ColumnCount = 2;
            this.layoutFondo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.layoutFondo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutFondo.Location = new System.Drawing.Point(0, 0);
            this.layoutFondo.Margin = new System.Windows.Forms.Padding(0);
            this.layoutFondo.Name = "layoutFondo";
            this.layoutFondo.RowCount = 1;
            this.layoutFondo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFondo.Size = new System.Drawing.Size(607, 336);
            this.layoutFondo.TabIndex = 0;
            // 
            // timerRepeatKey
            // 
            this.timerRepeatKey.Interval = 1000;
            this.timerRepeatKey.Tick += new System.EventHandler(this.timerRepeatKey_Tick);
            // 
            // TouchKeyBoard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.layoutFondo);
            this.Name = "TouchKeyBoard";
            this.Size = new System.Drawing.Size(607, 336);
            this.VisibleChanged += new System.EventHandler(this.TouchKeyBoard_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutFondo;
        private System.Windows.Forms.Timer timerRepeatKey;


    }
}
