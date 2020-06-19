using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pove.TouchKeyboard
{
    public class IRow
    {
        public IRow()
        {
            keys = new List<IKey>();
        }

        public IRow(List<IKey> pKeys)
        {
            keys = pKeys;
        }

        private List<IKey> keys;
        public List<IKey> Keys
        {
            get { return keys; }
            set { keys = value; }
        }
    }
}
