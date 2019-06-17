using System;

namespace Tizen.NUI.Binding
{
    internal abstract class ModalEventArgs : EventArgs
    {
        protected ModalEventArgs(Page modal)
        {
            Modal = modal;
        }

        public Page Modal { get; private set; }
    }
}