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
        internal static partial class GaussianBlurView
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GaussianBlurView__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewGaussianBlurView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GaussianBlurView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteGaussianBlurView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(uint jarg1, float jarg2, int jarg3, float jarg4, float jarg5, [MarshalAs(UnmanagedType.U1)] bool jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_Activate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Activate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_ActivateOnce", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ActivateOnce(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_Deactivate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Deactivate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_SetUserImageAndOutputRenderTarget", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetUserImageAndOutputRenderTarget(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_GetBlurStrengthPropertyIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetBlurStrengthPropertyIndex(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_SetBackgroundColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBackgroundColor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_GetBackgroundColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetBackgroundColor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurView_FinishedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FinishedSignal(IntPtr jarg1);
        }
    }
}





