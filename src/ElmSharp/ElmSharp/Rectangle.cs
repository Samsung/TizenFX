// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Diagnostics;

namespace ElmSharp
{
    /// <summary>
    /// A view used to draw a solid colored rectangle.
    /// </summary>
    public class Rectangle : EvasObject
    {
        /// <summary>
        /// Create a new BoxView widget.
        /// </summary>
        public Rectangle(EvasObject parent) : base(parent)
        {
            Interop.Evas.evas_object_size_hint_weight_set(Handle, 1.0, 1.0);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr evas = Interop.Evas.evas_object_evas_get(parent.Handle);
            return Interop.Evas.evas_object_rectangle_add(evas);
        }
    }
}
