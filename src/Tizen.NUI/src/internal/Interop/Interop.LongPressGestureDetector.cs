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
        internal static partial class LongPressGestureDetector
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(uint jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_New__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(uint jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_LongPressGestureDetector", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteLongPressGestureDetector(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_LongPressGestureDetector__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewLongPressGestureDetector(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_SetTouchesRequired__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTouchesRequired(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_SetTouchesRequired__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTouchesRequired(IntPtr jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_GetMinimumTouchesRequired", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetMinimumTouchesRequired(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_GetMaximumTouchesRequired", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetMaximumTouchesRequired(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_DetectedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DetectedSignal(IntPtr jarg1);
        }
    }
}





