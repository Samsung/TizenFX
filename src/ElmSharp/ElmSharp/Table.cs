// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
