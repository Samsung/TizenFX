using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public class Radio : Layout
    {
        Interop.SmartEvent _changed;

        public Radio(EvasObject parent) : base(parent)
        {
            _changed = new Interop.SmartEvent(this, Handle, "changed");
            _changed.On += (s, e) => ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ValueChanged;

        public int StateValue
        {
            get
            {
                return Interop.Elementary.elm_radio_state_value_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_radio_state_value_set(Handle, value);
            }
        }

        public int GroupValue
        {
            get
            {
                return Interop.Elementary.elm_radio_value_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_radio_value_set(Handle, value);
            }
        }

        public void SetGroup(Radio group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            Interop.Elementary.elm_radio_group_add(Handle, group.Handle);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_radio_add(parent);
        }
    }
}
