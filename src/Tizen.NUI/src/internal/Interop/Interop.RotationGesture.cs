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
        internal static partial class RotationGesture
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGestureDetector_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RotationGestureDetectorNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RotationGestureDetector", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRotationGestureDetector(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RotationGestureDetector__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRotationGestureDetector(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGestureDetector_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RotationGestureDetectorAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGestureDetector_DetectedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RotationGestureDetectorDetectedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGesture_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RotationGesture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRotationGesture(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGesture_rotation_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RotationGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGesture_screenCenterPoint_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScreenCenterPointGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGesture_localCenterPoint_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr LocalCenterPointGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGestureDetectedSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RotationGestureDetectedSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGestureDetectedSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint RotationGestureDetectedSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGestureDetectedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RotationGestureDetectedSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGestureDetectedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RotationGestureDetectedSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RotationGestureDetectedSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RotationGestureDetectedSignalEmit(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RotationGestureDetectedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRotationGestureDetectedSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RotationGestureDetectedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRotationGestureDetectedSignal(IntPtr jarg1);
        }
    }
}





