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
    public class Table : Container
    {
        int _paddingX = 0;
        int _paddingY = 0;

        public Table(EvasObject parent) : base(parent)
        {
        }

        public bool Homogeneous
        {
            get
            {
                return Interop.Elementary.elm_table_homogeneous_get(GetRealHandle(Handle));
            }
            set
            {
                Interop.Elementary.elm_table_homogeneous_set(GetRealHandle(Handle), value);
            }
        }

        public int PaddingX
        {
            get
            {
                return _paddingX;
            }
            set
            {
                _paddingX = value;
                Interop.Elementary.elm_table_padding_set(GetRealHandle(Handle), _paddingX, _paddingY);
            }
        }

        public int PaddingY
        {
            get
            {
                return _paddingY;
            }
            set
            {
                _paddingY = value;
                Interop.Elementary.elm_table_padding_set(GetRealHandle(Handle), _paddingX, _paddingY);
            }
        }

        public void Pack(EvasObject obj, int col, int row, int colspan, int rowspan)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Interop.Elementary.elm_table_pack(GetRealHandle(Handle), obj, col, row, colspan, rowspan);
            AddChild(obj);
        }

        public void Unpack(EvasObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Interop.Elementary.elm_table_unpack(GetRealHandle(Handle), obj);
            RemoveChild(obj);
        }

        public void Clear()
        {
            Interop.Elementary.elm_table_clear(GetRealHandle(Handle), false);
            ClearChildren();
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "background", "default");

            IntPtr realHandle = Interop.Elementary.elm_table_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", realHandle);

            return handle;
        }
    }
}
