using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public class ListItem : ItemObject
    {
        internal ListItem(string text, EvasObject leftIcon, EvasObject rightIcon) : base(IntPtr.Zero)
        {
            Text = text;
            LeftIcon = LeftIcon;
            RightIcon = RightIcon;
        }

        public string Text { get; internal set; }
        public EvasObject LeftIcon { get; internal set; }
        public EvasObject RightIcon { get; internal set; }
    }
}
