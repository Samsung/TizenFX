using System;

namespace Tizen.NUI.XamlBinding
{
    internal class ToolbarItemEventArgs : EventArgs
    {
        public ToolbarItemEventArgs(ToolbarItem item)
        {
            ToolbarItem = item;
        }

        public ToolbarItem ToolbarItem { get; private set; }
    }
}