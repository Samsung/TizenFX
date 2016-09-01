using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public class PopupItem : ItemObject
    {
        internal PopupItem(string text, EvasObject icon) : base(IntPtr.Zero)
        {
            Text = text;
            Icon = icon;
        }

        public string Text { get; internal set; }
        public EvasObject Icon { get; internal set; }
    }
}
