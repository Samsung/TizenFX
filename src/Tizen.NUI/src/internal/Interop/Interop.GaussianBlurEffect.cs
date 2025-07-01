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
        internal static class GaussianBlurEffect
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_New__SWIG_1")]
            public static extern IntPtr New(uint blurRadius);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_SetBlurOnce")]
            public static extern void SetBlurOnce(HandleRef effect, bool blurRadius);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_GetBlurOnce")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool GetBlurOnce(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_SetBlurRadius")]
            public static extern void SetBlurRadius(HandleRef effect, uint blurRadius);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_GetBlurRadius")]
            public static extern uint GetBlurRadius(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_SetBlurDownscaleFactor")]
            public static extern void SetBlurDownscaleFactor(HandleRef effect, float blurDownscaleFactor);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_GetBlurDownscaleFactor")]
            public static extern float GetBlurDownscaleFactor(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_AddBlurStrengthAnimation")]
            public static extern void AddBlurStrengthAnimation(HandleRef effect, HandleRef animation, HandleRef alphaFunction, HandleRef timePeriod, float fromValue, float toValue);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GaussianBlurEffect_AddBlurOpacityAnimation")]
            public static extern void AddBlurOpacityAnimation(HandleRef effect, HandleRef animation, HandleRef alphaFunction, HandleRef timePeriod, float fromValue, float toValue);
        }
    }
}
