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
    public enum IconLookupOrder
    {
        FreeDesktopFirst = 0,
        ThemeFirst,
        FreeDesktopOnly,
        ThemeOnly
    }
    public class Icon : Image
    {
        public Icon(EvasObject parent) : base(parent)
        {
        }

        public string StandardIconName
        {
            get
            {
                return Interop.Elementary.elm_icon_standard_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_icon_standard_set(Handle, value);
            }
        }

        public IconLookupOrder IconLookupOrder
        {
            get
            {
                return (IconLookupOrder)Interop.Elementary.elm_icon_order_lookup_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_icon_order_lookup_set(Handle, (int)value);
            }
        }

        public void SetThumb(string file, string group)
        {
            Interop.Elementary.elm_icon_thumb_set(Handle, file, group);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_icon_add(parent);
        }
    }
}
