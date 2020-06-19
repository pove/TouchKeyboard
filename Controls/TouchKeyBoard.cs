using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pove.TouchKeyboard
{
    public partial class TouchKeyBoard : UserControl
    {
        public class TouchKeyClickEventArgs : EventArgs
        {
            public IKey KeyClicked { get; set; }
            public string StringSended { get; set; }

            public TouchKeyClickEventArgs(IKey keyClicked, string stringSended)
            {
                KeyClicked = keyClicked;
                StringSended = stringSended;
            }
        }

        public delegate void TouchKeyClickEventHandler(object sender, TouchKeyClickEventArgs e);

        [Category("Action")]
        [Description("Fires when the value is changed")]
        public event EventHandler<TouchKeyClickEventArgs> TouchKeyClicked;

        protected virtual void OnTouchKeyClicked(IKey keyClicked, string stringSended)
        {
            TouchKeyClicked?.Invoke(this, new TouchKeyClickEventArgs(keyClicked, stringSended));
        }

        public TouchKeyBoard()
        {
            IKeyboard.setKeys(showArrowsSigns);
            IKeyboard.setKeysNumpad(showArrowsSigns);

            InitializeComponent();
            Initialize();
        }

        public TouchKeyBoard(bool bShowArrowsSigns)
        {
            showArrowsSigns = bShowArrowsSigns;

            IKeyboard.setKeys(showArrowsSigns);
            IKeyboard.setKeysNumpad(showArrowsSigns);

            InitializeComponent();
            Initialize();
        }

        public TouchKeyBoard(Pove.TouchKeyboard.IKeyboard.KBType pKeyBoardType, bool bShowArrowsSigns)
        {
            showArrowsSigns = bShowArrowsSigns;
            keyBoardType = pKeyBoardType;

            IKeyboard.setKeys(showArrowsSigns);
            IKeyboard.setKeysNumpad(showArrowsSigns);

            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {            
            setKeyBoard();

            setMayus();

            this.ResumeLayout(false);
        }

        private bool showArrowsSigns = true;
        [Category("TouchKeyboard")]
        [Description("Gets or sets if arrow signs must show.")]
        public bool ShowArrowsSigns
        {
            get { return showArrowsSigns; }
            set
            {
                if (showArrowsSigns == value)
                    return;

                showArrowsSigns = value;
                resetKeyBoard();

                IKeyboard.Rows = null;
                IKeyboard.setKeys(showArrowsSigns);
                IKeyboard.RowsNumPad = null;
                IKeyboard.setKeysNumpad(showArrowsSigns);

                Initialize();
            }
        }

        private Pove.TouchKeyboard.IKeyboard.KBType keyBoardType = IKeyboard.KBType.OnlyKeyBoard;
        [Category("TouchKeyboard")]
        [Description("Gets or sets keyboard type.")]
        public Pove.TouchKeyboard.IKeyboard.KBType KeyBoardType
        {
            get { return keyBoardType; }
            set 
            {
                if (keyBoardType == value)
                    return;

                keyBoardType = value;
                resetKeyBoard();
                Initialize();
            }
        }

        private Font keyFont = IKeyboard.keyFont;
        [Category("TouchKeyboard")]
        [Description("Gets or sets keys font.")]
        public Font KeyFont
        {
            get { return keyFont; }
            set
            {
                if (keyFont == value)
                    return;

                keyFont = value;
                resetKeyBoard();
                Initialize();
            }
        }

        public void setCapsLock(bool bCapsLock)
        {
            IKeyboard.CapsLock = bCapsLock;
            IKeyboard.Upper = bCapsLock;

            setMayus();
        }

        private void setKeyBoard()
        {
            switch (KeyBoardType)
            {
                case IKeyboard.KBType.OnlyKeyBoard:
                    IKeyboard.ShowNumPad = false;
                    setKeyBoardOrNumPad(false);
                    setKeyBoardOrNumPad(true);
                    break;
                case IKeyboard.KBType.KeyboardAndNumPad:
                    IKeyboard.ShowNumPad = true;
                    setKeyBoardOrNumPad(false);
                    setKeyBoardOrNumPad(true);
                    break;
                case IKeyboard.KBType.OnlyNumPad:
                    setKeyBoardOrNumPad(true);
                    break;
            }
        }

        private void setKeyBoardOrNumPad(bool bNumPad)
        {
            List<IRow> Rows;

            if (!bNumPad)
                Rows = IKeyboard.Rows;
            else
                Rows = IKeyboard.RowsNumPad;

            TableLayoutPanel layoutKeyBoard = new TableLayoutPanel();
            layoutKeyBoard.RowCount = Rows.Count;
            layoutKeyBoard.ColumnCount = 1;
            layoutKeyBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutKeyBoard.Name = "layoutKeyBoard";

            for (int iRow = 0; iRow < Rows.Count; iRow++)
            {
                layoutKeyBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / Rows.Count));
                TableLayoutPanel layoutRow = new TableLayoutPanel();
                layoutRow.RowCount = 1;
                layoutRow.ColumnCount = Rows[iRow].Keys.Count;
                layoutRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                layoutRow.Margin = new System.Windows.Forms.Padding(0);
                layoutRow.Name = "layoutRow" + iRow;

                for (int iCol = 0; iCol < Rows[iRow].Keys.Count; iCol++)
                {
                    layoutRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (100 / Rows[iRow].Keys.Count) * Rows[iRow].Keys[iCol].AdditionalWidth));
                    Pove.TouchKeyboard.TouchKey k = new Pove.TouchKeyboard.TouchKey(Rows[iRow].Keys[iCol], keyFont);
                    k.Name = "key" + iCol;                  
                    k.Dock = DockStyle.Fill;
                    k.Click += new EventHandler(k_Click);
                    k.MouseUp += new MouseEventHandler(k_MouseUp);
                    layoutRow.Controls.Add(k, iCol, 0);
                }            
            
                layoutRow.Dock = DockStyle.Fill;
                layoutRow.Size = this.Size;
                layoutKeyBoard.Controls.Add(layoutRow, 0, iRow);
            }

            layoutKeyBoard.Dock = DockStyle.Fill;

            if (!bNumPad)
            {
                layoutKeyBoard.Size = this.Size;
                layoutFondo.ColumnStyles[1] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0);
                layoutFondo.Controls.Add(layoutKeyBoard, 0, 0);
            }
            else
            {
                layoutKeyBoard.Height = this.Height;
                layoutKeyBoard.Width = Convert.ToInt32(this.Width * 0.20);

                showHideNumpad();

                if (keyBoardType == IKeyboard.KBType.OnlyNumPad)
                    layoutFondo.ColumnStyles[0] = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0);

                layoutFondo.Controls.Add(layoutKeyBoard, 1, 0);
            }
        }

        void k_MouseUp(object sender, MouseEventArgs e)
        {
            bKeyPressed = false;
        }

        private void k_Click(object sender, EventArgs e)
        {
            TouchKey tk = sender as TouchKey;

            OnTouchKeyClicked(tk.tKey, tk.sSendedKey);

            if (tk.bShowNumPadPressed)
            {
                showHideNumpad();

                return;
            }

            if (tk.bHidePressed)
            {
                this.Focus();
                this.Visible = false;
                return;
            }

            setMayus();

            if (IKeyboard.AllowMaintainKeyPressed && !bRepeating && !bKeyPressed)
            {
                timerRepeatKey.Enabled = false;
                sKeyRepeat = tk.sSendedKey;
                bKeyPressed = true;
                timerRepeatKey.Enabled = true;
            }
        }

        private void showHideNumpad()
        {
            if (IKeyboard.ShowNumPad)
            {
                layoutFondo.ColumnStyles[1] =
                    new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F);
            }
            else
            {
                layoutFondo.ColumnStyles[1] =
                    new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0);
            }
        }

        private void setMayus()
        {
            var cAll = GetAll(this, typeof(TouchKey));

            foreach (TouchKey c in cAll)
            {
                c.setMayus(IKeyboard.Upper);
            }
        }

        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void resetKeyBoard()
        {
            this.SuspendLayout();

            for (int i = 0; i < layoutFondo.Controls.Count; i++)
            {
                layoutFondo.Controls[0].Dispose();
            }
        }

        private void TouchKeyBoard_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                setMayus();
                showHideNumpad();
            }
        }

        bool bKeyPressed = false, bRepeating = false;
        string sKeyRepeat = "";

        private void timerRepeatKey_Tick(object sender, EventArgs e)
        {
            if (bKeyPressed)
            {
                timerRepeatKey.Interval = 50;
                bRepeating = true;
                SendKeys.SendWait(sKeyRepeat);
            }
            else
            {
                timerRepeatKey.Enabled = false;
                bRepeating = false;
                timerRepeatKey.Interval = 1000;
                sKeyRepeat = "";
            }
        }
    }
}
