/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp
{
    public class HoverselItemEventArgs : EventArgs
    {
        public HoverselItem Item { get; set; }

        internal static HoverselItemEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            HoverselItem item = ItemObject.GetItemByHandle(info) as HoverselItem;
            return new HoverselItemEventArgs() { Item = item };
        }
    }

    public class Hoversel : Layout
    {
        SmartEvent<HoverselItemEventArgs> _selected;
        Interop.Evas.SmartCallback _onItemSelected;

        public Hoversel(EvasObject parent) : base(parent)
        {
            _selected = new SmartEvent<HoverselItemEventArgs>(this, RealHandle, "selected", HoverselItemEventArgs.CreateFromSmartEvent);
            _selected.On += (s, e) =>
            {
                if (e.Item != null) ItemSelected?.Invoke(this, e);
            };
            _onItemSelected = (data, obj, info) =>
            {
                HoverselItem item = ItemObject.GetItemById((int)data) as HoverselItem;
                item?.SendItemSelected();
            };
        }

        public event EventHandler<HoverselItemEventArgs> ItemSelected;

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_hoversel_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_hoversel_horizontal_set(RealHandle, value);
            }
        }

        public IntPtr HoverParent
        {
            get
            {
                return Interop.Elementary.elm_hoversel_hover_parent_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_hoversel_hover_parent_set(RealHandle, value);
            }
        }

        public bool IsExpanded
        {
            get
            {
                return Interop.Elementary.elm_hoversel_expanded_get(RealHandle);
            }
        }

        public bool AutoUpdate
        {
            get
            {
                return Interop.Elementary.elm_hoversel_auto_update_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_hoversel_auto_update_set(RealHandle, value);
            }
        }

        public void HoverBegin()
        {
            Interop.Elementary.elm_hoversel_hover_begin(RealHandle);
        }

        public void HoverEnd()
        {
            Interop.Elementary.elm_hoversel_hover_end(RealHandle);
        }

        public void Clear()
        {
            Interop.Elementary.elm_hoversel_clear(RealHandle);
        }

        public HoverselItem AddItem(string label)
        {
            HoverselItem item = new HoverselItem();
            item.Label = label;
            item.Handle = Interop.Elementary.elm_hoversel_item_add(RealHandle, label, null, 0, _onItemSelected, (IntPtr)item.Id);
            return item;
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "background", "default");

            RealHandle = Interop.Elementary.elm_hoversel_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
