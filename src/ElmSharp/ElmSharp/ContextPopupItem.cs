using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public class ContextPopupItem : ItemObject
    {
        internal ContextPopupItem(string text, EvasObject icon) : base(IntPtr.Zero)
        {
            Text = text;
            Icon = icon;
        }

        public string Text { get; internal set; }
        public EvasObject Icon { get; internal set; }
        public event EventHandler Selected;

        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }
    }
}
