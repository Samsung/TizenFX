/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Rectangle
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rectangle__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRectangle();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rectangle__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRectangle(int jarg1, int jarg2, int jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_Set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Set(IntPtr jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_IsEmpty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_Left", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int Left(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_Right", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int Right(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_Top", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int Top(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_Bottom", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int Bottom(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_Area", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int Area(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_Intersects", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Intersects(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_Contains", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Contains(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_x_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void XSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_x_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int XGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_left_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LeftSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_left_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LeftGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_y_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void YSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int YGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_right_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RightSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_right_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_width_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WidthSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_width_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WidthGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_bottom_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void BottomSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_bottom_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BottomGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_height_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HeightSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_height_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int HeightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_top_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TopSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rectangle_top_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TopGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Rectangle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRectangle(IntPtr jarg1);
        }
    }
}





