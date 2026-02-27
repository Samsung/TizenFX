/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
        internal static class BackgroundBlurEffect
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New(uint blurRadius);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetBlurOnce", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBlurOnce(IntPtr effect, [MarshalAs(UnmanagedType.U1)] bool blurRadius);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_GetBlurOnce", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool GetBlurOnce(IntPtr effect);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetBlurRadius", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBlurRadius(IntPtr effect, uint blurRadius);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_GetBlurRadius", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetBlurRadius(IntPtr effect);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetBlurDownscaleFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetBlurDownscaleFactor(IntPtr effect, float blurDownscaleFactor);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_GetBlurDownscaleFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetBlurDownscaleFactor(IntPtr effect);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_AddBlurStrengthAnimation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddBlurStrengthAnimation(IntPtr effect, IntPtr animation, IntPtr alphaFunction, IntPtr timePeriod, float fromValue, float toValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_AddBlurOpacityAnimation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddBlurOpacityAnimation(IntPtr effect, IntPtr animation, IntPtr alphaFunction, IntPtr timePeriod, float fromValue, float toValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetSourceActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSourceView(IntPtr effect, IntPtr sourceView);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetStopperActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetStopperView(IntPtr effect, IntPtr stopperView);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_FinishedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FinishedSignalConnect(IntPtr effect, IntPtr callback);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_FinishedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FinishedSignalDisconnect(IntPtr effect, IntPtr callback);
        }
    }
}



