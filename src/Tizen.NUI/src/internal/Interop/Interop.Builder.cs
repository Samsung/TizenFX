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
        internal static partial class Builder
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Builder", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteBuilder(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_LoadFromString__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LoadFromString(IntPtr jarg1, string jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_LoadFromString__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LoadFromString(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_AddConstants", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddConstants(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_AddConstant", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddConstant(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_GetConstants", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetConstants(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_GetConstant", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetConstant(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_CreateAnimation__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateAnimation(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_CreateAnimation__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateAnimationWithPropertyMap(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_CreateAnimation__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateAnimationWithView(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_CreateAnimation__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateAnimation(IntPtr jarg1, string jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_Create__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Create(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_Create__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Create(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_CreateFromJson", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateFromJson(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_ApplyStyle", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ApplyStyle(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_ApplyFromJson", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ApplyFromJson(IntPtr jarg1, IntPtr jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_AddActors__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddActors(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_AddActors__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddActors(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_CreateRenderTask", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CreateRenderTask(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_GetPath", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPath(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_GetPathConstrainer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPathConstrainer(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_GetLinearConstrainer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetLinearConstrainer(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_QuitSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr QuitConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Builder_QuitSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr QuitDisconnect(IntPtr jarg1, IntPtr jarg2);
        }
    }
}





