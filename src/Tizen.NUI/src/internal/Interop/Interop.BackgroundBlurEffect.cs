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
namespace Tizen.NUI
{
    using global::System;
    using global::System.Runtime.InteropServices;

    internal static partial class Interop
    {
        internal static class BackgroundBlurEffect
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_New__SWIG_1")]
            public static extern IntPtr New(uint blurRadius);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetBlurOnce")]
            public static extern void SetBlurOnce(HandleRef effect, bool blurRadius);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_GetBlurOnce")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool GetBlurOnce(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetBlurRadius")]
            public static extern void SetBlurRadius(HandleRef effect, uint blurRadius);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_GetBlurRadius")]
            public static extern uint GetBlurRadius(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetBlurDownscaleFactor")]
            public static extern void SetBlurDownscaleFactor(HandleRef effect, float blurDownscaleFactor);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_GetBlurDownscaleFactor")]
            public static extern float GetBlurDownscaleFactor(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_AddBlurStrengthAnimation")]
            public static extern void AddBlurStrengthAnimation(HandleRef effect, HandleRef animation, HandleRef alphaFunction, HandleRef timePeriod, float fromValue, float toValue);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_AddBlurOpacityAnimation")]
            public static extern void AddBlurOpacityAnimation(HandleRef effect, HandleRef animation, HandleRef alphaFunction, HandleRef timePeriod, float fromValue, float toValue);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetSourceActor")]
            public static extern void SetSourceView(HandleRef effect, HandleRef sourceView);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_SetStopperActor")]
            public static extern void SetStopperView(HandleRef effect, HandleRef stopperView);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_FinishedSignal_Connect")]
            public static extern void FinishedSignalConnect(HandleRef effect, HandleRef callback);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BackgroundBlurEffect_FinishedSignal_Disconnect")]
            public static extern void FinishedSignalDisconnect(HandleRef effect, HandleRef callback);
        }
    }
}
