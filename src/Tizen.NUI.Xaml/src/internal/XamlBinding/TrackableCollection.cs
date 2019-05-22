using System;
using System.Collections.ObjectModel;

namespace Tizen.NUI.Binding
{
    internal class TrackableCollection<T> : ObservableCollection<T>
    {
        public event EventHandler Clearing;

        protected override void ClearItems()
        {
            Clearing?.Invoke(this, EventArgs.Empty);
            base.ClearItems();
        }
    }
}
