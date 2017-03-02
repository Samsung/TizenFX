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
    public enum GenListSelectionMode
    {
        Default,
        Always,
        None,
        DisplayOnly
    }

    [Flags]
    public enum GenListItemFieldType
    {
        All = 0,
        Text = (1 << 0),
        Content = (1 << 1),
        State = (1 << 2),
        None = (1 << 3)
    };

    public class GenListItem : GenItem
    {
        internal GenListItem(object data, GenItemClass itemClass)
            : base(data, itemClass)
        {
        }

        public override bool IsSelected
        {
            get
            {
                return Interop.Elementary.elm_genlist_item_selected_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_selected_set(Handle, value);
            }
        }

        public override void Update()
        {
            Interop.Elementary.elm_genlist_item_update(Handle);
        }

        public void UpdateField(string part, GenListItemFieldType type)
        {
            Interop.Elementary.elm_genlist_item_fields_update(Handle, part, (uint)type);
        }

        public GenListSelectionMode SelectionMode
        {
            get
            {
                return (GenListSelectionMode)Interop.Elementary.elm_genlist_item_select_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_genlist_item_select_mode_set(Handle, (Interop.Elementary.Elm_Object_Select_Mode)value);
            }
        }

        public GenListItem Next
        {
            get
            {
                IntPtr next = Interop.Elementary.elm_genlist_item_next_get(Handle);
                if (next == IntPtr.Zero)
                    return null;
                else
                    return GetItemByHandle(next) as GenListItem;
            }
        }

        public GenListItem Previous
        {
            get
            {
                IntPtr prev = Interop.Elementary.elm_genlist_item_prev_get(Handle);
                if (prev == IntPtr.Zero)
                    return null;
                else
                    return GetItemByHandle(prev) as GenListItem;
            }
        }

        public void UpdateItemClass(GenItemClass itemClass, object data)
        {
            Data = data;
            ItemClass = itemClass;
            Interop.Elementary.elm_genlist_item_item_class_update((IntPtr)Handle, itemClass.UnmanagedPtr);
        }
    }
}
