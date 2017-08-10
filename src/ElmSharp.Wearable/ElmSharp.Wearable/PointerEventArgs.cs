using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Wearable
{
    class PointerEventArgs : EventArgs
    {
        public IntPtr Pointer { get; set; }
    }
}
