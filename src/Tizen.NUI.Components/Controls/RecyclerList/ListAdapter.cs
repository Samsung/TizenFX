using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;


namespace Tizen.NUI.Components
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ListAdapter
    {
        private List<object> mData = new List<object>();
        public ListAdapter()
        {
        }

        public virtual ListItem CreateListItem()
        {
            return new ListItem();
        }

        public virtual void BindData(ListItem item)
        {

        }

        public void Notify()
        {
            OnDataChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler<EventArgs> OnDataChanged;

        public List<object> Data{
            get
            {
                return mData;
            }
            set
            {
                mData = value;
                Notify();
            }
        }
        
    }
}