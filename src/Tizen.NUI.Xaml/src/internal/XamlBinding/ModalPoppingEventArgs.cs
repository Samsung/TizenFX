namespace Tizen.NUI.Binding
{
    internal class ModalPoppingEventArgs : ModalEventArgs
    {
        public ModalPoppingEventArgs(Xaml.Page modal) : base(modal)
        {
        }

        public bool Cancel { get; set; }
    }
}