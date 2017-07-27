
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElmSharp.Wearable
{
    public class MoreOption : Layout
    {

        public IList<MoreOptionItem> Items { get; private set; }

        public event EventHandler<MoreOptionItemEventArgs> Selected;
        public event EventHandler<MoreOptionItemEventArgs> Clicked;
        public event EventHandler Opened;
        public event EventHandler Closed;

        SmartEvent<PointerEventArgs> _selectedEvent;
        SmartEvent<PointerEventArgs> _clickedEvent;
        SmartEvent _openedEvent;
        SmartEvent _closedEvent;

        public MoreOption(EvasObject parent) : base(parent)
        {
            Items = new MoreOptionList(this);

            _selectedEvent = new SmartEvent<PointerEventArgs>(this, "item,selected", (d, o, info) => new PointerEventArgs { Pointer = info });
            _clickedEvent = new SmartEvent<PointerEventArgs>(this, "item,clicked", (d, o, info) => new PointerEventArgs { Pointer = info });
            _openedEvent = new SmartEvent(this, "more,option,opened");
            _closedEvent = new SmartEvent(this, "more,option,closed");

            _selectedEvent.On += (s, e) =>
            {
                MoreOptionItem selected = Items.FirstOrDefault(i => i.Handle == e.Pointer);
                Selected?.Invoke(this, new MoreOptionItemEventArgs() { Item = selected });
            };

            _clickedEvent.On += (s, e) =>
            {
                MoreOptionItem selected = Items.FirstOrDefault(i => i.Handle == e.Pointer);
                Clicked?.Invoke(this, new MoreOptionItemEventArgs() { Item = selected });
            };

            _openedEvent.On += (s, e) => Opened?.Invoke(this, EventArgs.Empty);
            _closedEvent.On += (s, e) => Closed?.Invoke(this, EventArgs.Empty);

        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Eext.eext_more_option_add(parent);
        }

        public MoreOptionDirection Direction
        {
            get
            {
                int dir = Interop.Eext.eext_more_option_direction_get(this);
                return (MoreOptionDirection)dir;
            }

            set
            {
                Interop.Eext.eext_more_option_direction_set(this, (int)value);
            }
        }

        public bool IsOpened
        {
            get
            {
                return Interop.Eext.eext_more_option_opened_get(this);
            }

            set
            {
                Interop.Eext.eext_more_option_opened_set(this, value);
            }
        }
    }

    public enum MoreOptionDirection
    {
        Top,
        Bottom,
        Left,
        Right
    }
}
