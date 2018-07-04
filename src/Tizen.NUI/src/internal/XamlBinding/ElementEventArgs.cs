using System;

namespace Tizen.NUI.Binding
{
    internal class ElementEventArgs : EventArgs
    {
        public ElementEventArgs(Element element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            Element = element;
        }

        public Element Element { get; private set; }
    }
}
