using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pove.TouchKeyboard
{
    public partial class TouchKey : Control
    {
        const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_NOACTIVATE;
                return param;
            }
        }

        public IKey tKey;
        public bool bHidePressed = false, bShowNumPadPressed = false;
        public TouchKey(IKey pKey, Font pFont)
        {
            tKey = pKey;

            InitializeComponent();

            this.Font = pFont;
            setKey();

            this.pnKey.ResumeLayout(false);
            this.pnKey.PerformLayout();
            this.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void setKey()
        {
            if (IKeyboard.KeyClickEvent == IKeyboard.KBClickEvent.OnClick)
            {
                pnKey.Click += new EventHandler(pnKey_Click);
                laUp.Click += new EventHandler(pnKey_Click);
                laDown.Click += new EventHandler(pnKey_Click);
            }

            pnKey.BackColor = IKeyboard.KeyBackColor;

            if (String.IsNullOrEmpty(tKey.Shift))
            {
                laUp.Text = tKey.Normal;
                laDown.Visible = false;
            }
            else
            {
                laUp.Text = tKey.Shift;

                laDown.Text = tKey.Normal;
                laDown.Font = new System.Drawing.Font(this.Font.Name, this.Font.Size * 0.90F);
                laDown.Location = new System.Drawing.Point(2, pnKey.Height - laDown.Height - 3);
                laDown.Size = new System.Drawing.Size(laDown.Font.Height, laDown.Font.Height);
                laDown.BringToFront();
            }

            if (isSpecial())
            {
                laUp.Font = new System.Drawing.Font(this.Font.Name, this.Font.Size * 0.80F);
            }
            else if (!String.IsNullOrEmpty(tKey.Shift))
            {
                laUp.Font = new System.Drawing.Font(this.Font.Name, this.Font.Size * 0.80F);
            }
            else
            {
                laUp.Font = this.Font;
            }

            laUp.Size = new System.Drawing.Size(laUp.Font.Height, laUp.Font.Height);

            if (!String.IsNullOrEmpty(tKey.Alt))
            {
                laAlt.ForeColor = IKeyboard.AltGrKeysForeColor;

                if (tKey.CanNumlock)
                    laAlt.Font = new System.Drawing.Font(this.Font.Name, this.Font.Size * 0.60F);
                else
                    laAlt.Font = new System.Drawing.Font(this.Font.Name, this.Font.Size * 0.80F);

                laAlt.Size = new System.Drawing.Size(laAlt.Font.Height * tKey.Alt.Length + 5, laAlt.Font.Height + 5);
                laAlt.Location = new System.Drawing.Point(pnKey.Width - laAlt.Width, pnKey.Height - laAlt.Height - 2);
                switch (tKey.Alt)
                {
                    case "{{}": laAlt.Text = "{"; break;
                    case "{}}": laAlt.Text = "}"; break;
                    default: laAlt.Text = tKey.Alt; break;
                }

                if (IKeyboard.KeyClickEvent == IKeyboard.KBClickEvent.OnClick)
                {
                    laAlt.Click += new System.EventHandler(this.pnKey_Click);
                }
                laAlt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnKey_MouseDown);
                laAlt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnKey_MouseUp);
                pnKey.Controls.Add(laAlt);
            }

        }

        public string getKey()
        {
            if (isSpecial())
                return tKey.Special;

            string sRet = string.Empty;

            if (IKeyboard.AltGr && !String.IsNullOrEmpty(tKey.Alt) && !tKey.CanNumlock)
            {
                sRet = tKey.Alt;
            }
            else
            {
                if (IKeyboard.Ctrl)
                    sRet = "^";

                if (IKeyboard.Shift)
                    sRet = "+";

                if ((!IKeyboard.NumLock && tKey.CanNumlock) || tKey.IsSpecial)
                {
                    sRet += tKey.Special;

                    if (sRet == "+{+}")
                        sRet = "*";
                }
                else
                {
                    sRet += tKey.Normal;

                if (IKeyboard.CapsLock)
                    sRet = "{CAPSLOCK}" + sRet + "{CAPSLOCK}";
                }
            }
                        
            if (IKeyboard.CapsLock)
                IKeyboard.Upper = true;
            else if (IKeyboard.Shift)
                IKeyboard.Upper = !IKeyboard.Shift;
            else
                IKeyboard.Upper = false;

            IKeyboard.Shift = false;
            IKeyboard.AltGr = false;
            IKeyboard.Ctrl = false;

            return sRet;
        }

        public void setMayus(bool bMayus)
        {
            if (isSpecial())
            {
                setSpecial();
                return;
            }

            if (bMayus)
            {
                laUp.Text = laUp.Text.ToUpper();
            }
            else
            {
                laUp.Text = laUp.Text.ToLower();
            }

            setColorNormal();
        }

        private void setSpecial()
        {
            switch (tKey.Special.ToUpper())
            {
                case "{SHIFT}":
                    pnKey.Enabled = IKeyboard.AllowChangeShift;
                    if (IKeyboard.Shift)
                        laUp.ForeColor = Color.DeepSkyBlue;
                    else
                        laUp.ForeColor = Color.White;
                    break;
                case "{CAPS}":
                    pnKey.Enabled = IKeyboard.AllowChangeCapsLock;
                    if (!IKeyboard.AllowChangeCapsLock)
                        break;
                    if (IKeyboard.CapsLock)
                        laUp.ForeColor = Color.DeepSkyBlue;
                    else
                        laUp.ForeColor = Color.White;
                    break;
                case "{CTRL}":
                    pnKey.Enabled = IKeyboard.AllowChangeCtrl;
                    if (IKeyboard.Ctrl)
                        laUp.ForeColor = Color.DeepSkyBlue;
                    else
                        laUp.ForeColor = Color.White;
                    break;
                case "{ALTGR}":
                    pnKey.Enabled = IKeyboard.AllowChangeAltGr;
                    if (IKeyboard.AltGr)
                        laUp.ForeColor = Color.DeepSkyBlue;
                    else
                        laUp.ForeColor = Color.White;
                    break;
                case "{NUMLOCK}":
                    pnKey.Enabled = IKeyboard.AllowChangeNumLock;
                    if (IKeyboard.NumLock)
                        laUp.ForeColor = Color.DeepSkyBlue;
                    else
                        laUp.ForeColor = Color.White;
                    break;
                case "{NUMPAD}":
                    pnKey.Enabled = IKeyboard.AllowChangeNumPad;
                    if (IKeyboard.ShowNumPad)
                        laUp.ForeColor = Color.DeepSkyBlue;
                    else
                        laUp.ForeColor = Color.White;
                    break;
                default: laUp.ForeColor = Color.White; break;
            }
        }

        private void pnKey_Click(object sender, EventArgs e)
        {
            DoClick();
        }

        private bool isSpecial()
        {
            if (tKey.IsSpecial && string.IsNullOrEmpty(tKey.Alt) && string.IsNullOrEmpty(tKey.Shift))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DoClick()
        {
            try
            {
                if (isSpecial())
                {
                    switch (tKey.Special.ToUpper())
                    {
                        case "{SHIFT}":
                            IKeyboard.Shift = !IKeyboard.Shift;
                            IKeyboard.Upper = !IKeyboard.Upper;
                            break;
                        case "{CAPS}":
                            IKeyboard.CapsLock = !IKeyboard.CapsLock;
                            IKeyboard.Upper = IKeyboard.CapsLock;
                            break;
                        case "{CTRL}": IKeyboard.Ctrl = !IKeyboard.Ctrl; break;
                        case "{ALTGR}": IKeyboard.AltGr = !IKeyboard.AltGr; break;
                        case "{ESCAPE}":
                            if (IKeyboard.HideOnEscape)
                                bHidePressed = true;
                            else
                                sendKey("{ESCAPE}");
                            break;
                        case "{NUMLOCK}": IKeyboard.NumLock = !IKeyboard.NumLock; break;
                        case "{NUMPAD}":
                            IKeyboard.ShowNumPad = !IKeyboard.ShowNumPad;
                            bShowNumPadPressed = true;
                            break;
                        case "COPYRIGHT":
                            System.Diagnostics.Process.Start("http://www.pove.es");
                            break;
                        default: sendKey(getKey()); break;
                    }
                }
                else
                {
                    sendKey(getKey());
                }

                this.InvokeOnClick(this, new EventArgs());

                bHidePressed = false;
                bShowNumPadPressed = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string sSendedKey = "";
        private void sendKey(string sStringToSend)
        {
            sSendedKey = sStringToSend;
            SendKeys.SendWait(sStringToSend);
        }

        private void pnKey_MouseDown(object sender, MouseEventArgs e)
        {
            bool bAltGr = IKeyboard.AltGr, bCanNumLock = tKey.CanNumlock, bNumLock = IKeyboard.NumLock, bShift = IKeyboard.Shift;
            if ((IKeyboard.KeyClickEvent == IKeyboard.KBClickEvent.OnMouseDown && tKey.ClickEvent == IKeyboard.KBClickEvent.Default) || 
                tKey.ClickEvent == IKeyboard.KBClickEvent.OnMouseDown)
                DoClick();

            if ((bAltGr || (tKey.CanNumlock && !bNumLock)) && !String.IsNullOrEmpty(tKey.Alt))
            {
                laAlt.ForeColor = Color.DeepSkyBlue;
            }
            else
            {
                if (bShift || String.IsNullOrEmpty(tKey.Shift))
                    laUp.ForeColor = Color.DeepSkyBlue;
                else
                    laDown.ForeColor = Color.DeepSkyBlue;
            }
        }

        private void pnKey_MouseUp(object sender, MouseEventArgs e)
        {
            if ((IKeyboard.KeyClickEvent == IKeyboard.KBClickEvent.OnMouseUp && tKey.ClickEvent == IKeyboard.KBClickEvent.Default) || 
                tKey.ClickEvent == IKeyboard.KBClickEvent.OnMouseUp)
                DoClick();

            setColorNormal();

            this.OnMouseUp(e);
        }

        private void setColorNormal()
        {
            if (isSpecial())
            {
                setSpecial();
            }
            else
            {
                if (IKeyboard.AltGr && !String.IsNullOrEmpty(tKey.Alt) && !tKey.CanNumlock)
                {
                    laAlt.ForeColor = Color.White;
                    laUp.ForeColor = System.Drawing.Color.FromArgb(129, 128, 133);
                    laDown.ForeColor = System.Drawing.Color.FromArgb(129, 128, 133);
                }
                else if (tKey.CanNumlock && !IKeyboard.NumLock && !String.IsNullOrEmpty(tKey.Alt))
                {
                    laAlt.ForeColor = Color.White;
                    laUp.ForeColor = System.Drawing.Color.FromArgb(129, 128, 133);
                    laDown.ForeColor = System.Drawing.Color.FromArgb(129, 128, 133);
                }
                else if (IKeyboard.Shift || String.IsNullOrEmpty(tKey.Shift))
                {
                    laAlt.ForeColor = System.Drawing.Color.FromArgb(129, 128, 133);
                    laUp.ForeColor = Color.White;
                    laDown.ForeColor = System.Drawing.Color.FromArgb(129, 128, 133);
                }
                else
                {
                    laAlt.ForeColor = System.Drawing.Color.FromArgb(129, 128, 133);
                    laUp.ForeColor = System.Drawing.Color.FromArgb(129, 128, 133);
                    laDown.ForeColor = Color.White;
                }
            } 
        }
    }
}
