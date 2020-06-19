using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pove.TouchKeyboard
{
    public class IKeyboard
    {
        public static bool CapsLock = false;
        public static bool Shift = false;
        public static bool AltGr = false;
        public static bool Ctrl = false;
        public static bool Upper = false;
        public static bool NumLock = true;
        public static bool ShowNumPad = true;

        public static bool HideOnEscape = false;
        public static bool AllowChangeNumLock = true;
        public static bool AllowChangeCapsLock = true;
        public static bool AllowChangeShift = true;
        public static bool AllowChangeAltGr = true;
        public static bool AllowChangeNumPad = true;
        public static bool AllowChangeCtrl = true;
        public static bool AllowMaintainKeyPressed = false;

        public static readonly System.Drawing.Color ColorDarkGrey = System.Drawing.Color.FromArgb(29, 28, 33);
        public static readonly System.Drawing.Color ColorGrey = System.Drawing.Color.FromArgb(47, 46, 54);
        public static readonly System.Drawing.Color ColorLightGrey = System.Drawing.Color.FromArgb(69, 68, 76);
        public static readonly System.Drawing.Color ColorDarkWhite = System.Drawing.Color.FromArgb(129, 128, 133);

        public static System.Drawing.Font keyFont = new System.Drawing.Font("Arial", 15);
        public static System.Drawing.Color KeyBackColor = ColorDarkGrey;
        public static System.Drawing.Color AltGrKeysForeColor = ColorDarkWhite;

        public enum KBType { OnlyKeyBoard, KeyboardAndNumPad, OnlyNumPad };
        public enum KBClickEvent { OnMouseDown, OnClick, OnMouseUp, Default };

        public static List<IRow> Rows;
        public static List<IRow> RowsNumPad;

        public static KBClickEvent KeyClickEvent = KBClickEvent.OnMouseDown;

        public static void setKeys(bool bShowArrowsSigns)
        {
            string sUpArrow = "↑ ", sLeftArrow = "← ";
            if (!bShowArrowsSigns)
            {
                sUpArrow = "";
                sLeftArrow = "";
            }

            IRow row1 = new IRow();
            row1.Keys.Add(new IKey("Esc", "{ESCAPE}", 1.3F));
            row1.Keys.Add(new IKey("º", "ª", "\\"));
            row1.Keys.Add(new IKey("1", "!", "|"));
            row1.Keys.Add(new IKey("2", "\"", "@"));
            row1.Keys.Add(new IKey("3", "·", "#"));
            row1.Keys.Add(new IKey("4", "$"));
            row1.Keys.Add(new IKey("5", "%", "€"));
            row1.Keys.Add(new IKey("6", "&&", "¬"));
            row1.Keys.Add(new IKey("7", "/"));
            row1.Keys.Add(new IKey("8", "("));
            row1.Keys.Add(new IKey("9", ")"));
            row1.Keys.Add(new IKey("0", "="));
            row1.Keys.Add(new IKey("'", "?"));
            row1.Keys.Add(new IKey("¡", "¿"));
            row1.Keys.Add(new IKey(sLeftArrow + "Retr", "{BACKSPACE}", 1.6F));

            IRow row2 = new IRow();
            row2.Keys.Add(new IKey("Tab", "{TAB}", 1.6F));
            row2.Keys.Add(new IKey("q"));
            row2.Keys.Add(new IKey("w"));
            row2.Keys.Add(new IKey("e", "", "€"));
            row2.Keys.Add(new IKey("r"));
            row2.Keys.Add(new IKey("t"));
            row2.Keys.Add(new IKey("y"));
            row2.Keys.Add(new IKey("u"));
            row2.Keys.Add(new IKey("i"));
            row2.Keys.Add(new IKey("o"));
            row2.Keys.Add(new IKey("p"));
            row2.Keys.Add(new IKey("`", "^", "["));
            IKey key1 = new IKey("+", "*", "]");
            key1.IsSpecial = true;
            key1.Special = "{+}";
            row2.Keys.Add(key1);
            row2.Keys.Add(new IKey("NumPad", "{NUMPAD}", 2.3F));

            IRow row3 = new IRow();
            row3.Keys.Add(new IKey("Bloq Mayús", "{CAPS}", 1.9F));
            row3.Keys.Add(new IKey("a"));
            row3.Keys.Add(new IKey("s"));
            row3.Keys.Add(new IKey("d"));
            row3.Keys.Add(new IKey("f"));
            row3.Keys.Add(new IKey("g"));
            row3.Keys.Add(new IKey("h"));
            row3.Keys.Add(new IKey("j"));
            row3.Keys.Add(new IKey("k"));
            row3.Keys.Add(new IKey("l"));
            row3.Keys.Add(new IKey("ñ"));
            row3.Keys.Add(new IKey("´", "¨", "{{}"));
            row3.Keys.Add(new IKey("ç", "", "{}}"));
            row3.Keys.Add(new IKey("Entrar", "{ENTER}", 2.0F));

            IRow row4 = new IRow();
            row4.Keys.Add(new IKey(sUpArrow + "Mayús", "{SHIFT}", 1.3F));
            row4.Keys.Add(new IKey("<"));
            row4.Keys.Add(new IKey("z"));
            row4.Keys.Add(new IKey("x"));
            row4.Keys.Add(new IKey("c"));
            row4.Keys.Add(new IKey("v"));
            row4.Keys.Add(new IKey("b"));
            row4.Keys.Add(new IKey("n"));
            row4.Keys.Add(new IKey("m"));
            row4.Keys.Add(new IKey(",", ";"));
            row4.Keys.Add(new IKey(".", ":"));
            row4.Keys.Add(new IKey("-", "_"));
            row4.Keys.Add(new IKey(sUpArrow + "Mayús", "{SHIFT}", 3.2F));

            IRow row5 = new IRow();
            row5.Keys.Add(new IKey("Ctrl", "{CTRL}", 1.0F));
            row5.Keys.Add(new IKey("Win", "^({ESC}E)", 1.0F, KBClickEvent.OnMouseUp));
            row5.Keys.Add(new IKey("", " ", 6.0F));
            row5.Keys.Add(new IKey("Alt Gr", "{ALTGR}", 1.0F));
            row5.Keys.Add(new IKey("Ctrl", "{CTRL}", 1.0F));

            //Copyright
            //IRow row6 = new IRow();
            //row6.Keys.Add(new IKey("www.pove.es", "COPYRIGHT", 1.0F));

            Rows = new List<IRow>();
            Rows.Add(row1);
            Rows.Add(row2);
            Rows.Add(row3);
            Rows.Add(row4);
            Rows.Add(row5);
            //Rows.Add(row6);
        }

        public static void setKeysNumpad(bool bShowArrowsSigns)
        {
            string sUpArrow = "↑", sLeftArrow = "←", sRightArrow = "→", sDownArrow = "↓";
            if (!bShowArrowsSigns)
            {
                sUpArrow = "Arriba";
                sLeftArrow = "Izq.";
                sRightArrow = "Dcha.";
                sDownArrow = "Abajo";
            }

            IRow row1 = new IRow();
            row1.Keys.Add(new IKey("7", "Inicio", "{HOME}", true));
            row1.Keys.Add(new IKey("8", sUpArrow, "{UP}", true));
            row1.Keys.Add(new IKey("9", "Repág", "{PGUP}", true));
            row1.Keys.Add(new IKey("/"));

            IRow row2 = new IRow();
            row2.Keys.Add(new IKey("4", sLeftArrow, "{LEFT}", true));
            row2.Keys.Add(new IKey("5"));
            row2.Keys.Add(new IKey("6", sRightArrow, "{RIGHT}", true));
            row2.Keys.Add(new IKey("*"));

            IRow row3 = new IRow();
            row3.Keys.Add(new IKey("1", "Fin", "{END}", true));
            row3.Keys.Add(new IKey("2", sDownArrow, "{DOWN}", true));
            row3.Keys.Add(new IKey("3", "Avpág", "{PGDN}", true));
            row3.Keys.Add(new IKey("-"));

            IRow row4 = new IRow();
            IKey key0 = new IKey("0", "Ins", "{INS}", true);
            key0.AdditionalWidth = 2.0F;
            row4.Keys.Add(key0);
            row4.Keys.Add(new IKey(".", "Supr", "{DEL}", true));
            IKey key1 = new IKey("+");
            key1.IsSpecial = true;
            key1.Special = "{+}";
            row4.Keys.Add(key1);
            
            if (!bShowArrowsSigns)
            {
                sLeftArrow = "";
            }

            IRow row5 = new IRow();
            row5.Keys.Add(new IKey("Entrar", "{ENTER}", 2.0F));
            row5.Keys.Add(new IKey(sLeftArrow + "Retr", "{BACKSPACE}", 1.0F));
            row5.Keys.Add(new IKey("Bloq\r\nNum", "{NUMLOCK}", 1.0F));

            //Copyright
            //IRow row6 = new IRow();
            //row6.Keys.Add(new IKey("www.pove.es", "COPYRIGHT", 1.0F));

            RowsNumPad = new List<IRow>();
            RowsNumPad.Add(row1);
            RowsNumPad.Add(row2);
            RowsNumPad.Add(row3);
            RowsNumPad.Add(row4);
            RowsNumPad.Add(row5);
            //RowsNumPad.Add(row6);
        }

    }
}
