// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Evas
    {
        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_file_set(IntPtr obj, string file, string key);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_alpha_set(IntPtr obj, bool has_alpha);

        [DllImport(Libraries.Evas)]
        internal static extern bool evas_object_image_alpha_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern LoadError evas_object_image_load_error_get(IntPtr obj);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, IntPtr x, out int y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, out int x, IntPtr y);

        [DllImport(Libraries.Evas)]
        internal static extern void evas_object_image_size_get(IntPtr obj, out int x, out int y);

        internal enum LoadError
        {
            None = 0,
            Generic = 1,
            DoesNotExist = 2,
            PermissionDenied = 3,
            ResourceAllocationFailed = 4,
            CorruptFile = 5,
            UnknownFormat = 6,
        }
    }
}
