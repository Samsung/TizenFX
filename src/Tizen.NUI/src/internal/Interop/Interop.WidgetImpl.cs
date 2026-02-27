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
        internal static partial class WidgetImpl
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SetContentInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetContentInfo(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SetUsingKeyEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetUsingKeyEvent(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_director_connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DirectorConnect(IntPtr jarg1, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_0 delegate0, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_1 delegate1,
                Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_2 delegate2, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_3 delegate3, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_4 delegate4, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_5 delegate5,
                Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_6 delegate6, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_7 delegate7);
        }
    }
}





