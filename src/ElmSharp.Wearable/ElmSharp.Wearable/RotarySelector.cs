using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElmSharp.Wearable
{
    public class RotarySelector : Layout
    {
        const string IconPartName = "selector,icon";
        const string ContentPartName = "selector,content";
        const string BgPartName = "selector,bg_image";

        const string ItemSelectedEventName = "item,selected";
        const string ItemClickedEventName = "item,clicked";

        public event EventHandler<RotarySelectorItemEventArgs> Selected;
        public event EventHandler<RotarySelectorItemEventArgs> Clicked;

        SmartEvent<PointerEventArgs> _selectedEvent;
        SmartEvent<PointerEventArgs> _clickedEvent;
        Image _normalBgImage;

        public IList<RotarySelectorItem> Items { get; private set; }

        public RotarySelector(EvasObject parent) : base(parent)
        {
            Items = new RotarySelectorList(this);

            _selectedEvent = new SmartEvent<PointerEventArgs>(this, "item,selected", (d, o, info) => new PointerEventArgs { Pointer = info });
            _clickedEvent = new SmartEvent<PointerEventArgs>(this, "item,clicked", (d, o, info) => new PointerEventArgs { Pointer = info });
            _selectedEvent.On += (s, e) =>
            {
                RotarySelectorItem selected = Items.FirstOrDefault(i => i.Handle == e.Pointer);
                Selected?.Invoke(this, new RotarySelectorItemEventArgs { Item = selected });
            };

            _clickedEvent.On += (s, e) =>
            {
                RotarySelectorItem selected = Items.FirstOrDefault(i => i.Handle == e.Pointer);
                Clicked?.Invoke(this, new RotarySelectorItemEventArgs { Item = selected });
            };
        }

        public RotarySelectorItem SelectedItem
        {
            get
            {
                IntPtr selectedPtr = Interop.Eext.eext_rotary_selector_selected_item_get(this);
                if (selectedPtr == IntPtr.Zero) return null;
                RotarySelectorItem item = Items.FirstOrDefault(i => i.Handle == selectedPtr);
                return item;
            }

            set
            {
                if (!Items.Contains(value)) return;
                Interop.Eext.eext_rotary_selector_selected_item_set(this, value.Handle);
            }
        }

        void setPart(ref Image prop, string partName, State state, Image img)
        {
            if (prop == img) return;
            prop = img;
            if (this != null)
            {
                Interop.Eext.eext_rotary_selector_part_content_set(this, partName, (int)state, prop);
            }
        }
        void setPart(ref Color prop, string partName, State state, Color color)
        {
            if (prop == color) return;
            if (this != null)
            {
                Interop.Eext.eext_rotary_selector_part_color_set(this, partName, (int)state, color.R, color.G, color.B, color.A);
            }
        }

        public Image BackgroundImage { set => setPart(ref _normalBgImage, BgPartName, State.Normal, value); get => _normalBgImage; }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr ptr = Interop.Eext.eext_rotary_selector_add(parent);
            Interop.Eext.eext_rotary_object_event_activated_set(ptr, true);
            return ptr;
        }

        internal enum State
        {
            Normal,
            Pressed
        }
    }
}
