using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.XamlBinding
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