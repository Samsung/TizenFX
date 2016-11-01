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
                return Interop.Elementary.elm_table_homogeneous_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_table_homogeneous_set(Handle, value);
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
                Interop.Elementary.elm_table_padding_set(Handle, _paddingX, _paddingY);
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
                Interop.Elementary.elm_table_padding_set(Handle, _paddingX, _paddingY);
            }
        }

        public void Pack(EvasObject obj, int col, int row, int colspan, int rowspan)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Interop.Elementary.elm_table_pack(Handle, obj, col, row, colspan, rowspan);
            AddChild(obj);
        }

        public void Unpack(EvasObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Interop.Elementary.elm_table_unpack(Handle, obj);
            RemoveChild(obj);
        }

        public void Clear()
        {
            Interop.Elementary.elm_table_clear(Handle, false);
            ClearChildren();
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_table_add(parent);
        }
    }
}
