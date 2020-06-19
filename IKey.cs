using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pove.TouchKeyboard
{
    public class IKey
    {
        public IKey()
        {
        }

        public IKey(string pNormal)
        {
            normal = pNormal;
        }

        public IKey(string pNormal, string pShift)
        {
            normal = pNormal;
            shift = pShift;
        }

        public IKey(string pNormal, string pShift, string pAlt)
        {
            normal = pNormal;
            shift = pShift;
            alt = pAlt;
        }

        public IKey(string pNormal, string pNumlock, string pSpecial, bool pCanNumLock)
        {
            normal = pNormal;
            alt = pNumlock;
            special = pSpecial;
            canNumLock = pCanNumLock;
        }

        public IKey(string pNormal, string pSpecial, float pAdditionalWidth, IKeyboard.KBClickEvent pClickEvent = IKeyboard.KBClickEvent.Default)
        {
            normal = pNormal;
            isSpecial = true;
            special = pSpecial;
            additionalWidth = pAdditionalWidth;
            clickEvent = pClickEvent;
        }

        private string normal;
        public string Normal
        {
            get { return normal; }
            set { normal = value; }
        }

        private string shift;
        public string Shift
        {
            get { return shift; }
            set { shift = value; }
        }

        private string alt;
        public string Alt
        {
            get { return alt; }
            set { alt = value; }
        }

        private bool isSpecial = false;
        public bool IsSpecial
        {
            get { return isSpecial; }
            set { isSpecial = value; }
        }

        private bool canNumLock = false;
        public bool CanNumlock
        {
            get { return canNumLock; }
            set { canNumLock = value; }
        }

        private string special;
        public string Special
        {
            get { return special; }
            set { special = value; }
        }

        private float additionalWidth = 1;
        public float AdditionalWidth
        {
            get { return additionalWidth; }
            set { additionalWidth = value; }
        }

        private IKeyboard.KBClickEvent clickEvent = IKeyboard.KBClickEvent.Default;
        public IKeyboard.KBClickEvent ClickEvent
        {
            get { return clickEvent; }
            set { clickEvent = value; }
        }
    }
}
