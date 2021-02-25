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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Scrollable
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_OVERSHOOT_EFFECT_COLOR_get")]
            public static extern int OvershootEffectColorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_OVERSHOOT_ANIMATION_SPEED_get")]
            public static extern int OvershootAnimationSpeedGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_OVERSHOOT_ENABLED_get")]
            public static extern int OvershootEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_OVERSHOOT_SIZE_get")]
            public static extern int OvershootSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_TO_ALPHA_FUNCTION_get")]
            public static extern int ScrollToAlphaFunctionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_RELATIVE_POSITION_get")]
            public static extern int ScrollRelativePositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_get")]
            public static extern int ScrollPositionMinGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_X_get")]
            public static extern int ScrollPositionMinXGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_Y_get")]
            public static extern int ScrollPositionMinYGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_get")]
            public static extern int ScrollPositionMaxGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_X_get")]
            public static extern int ScrollPositionMaxXGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_Y_get")]
            public static extern int ScrollPositionMaxYGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_CAN_SCROLL_VERTICAL_get")]
            public static extern int CanScrollVerticalGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_CAN_SCROLL_HORIZONTAL_get")]
            public static extern int CanScrollHorizontalGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Scrollable_Property")]
            public static extern global::System.IntPtr NewScrollableProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Scrollable_Property")]
            public static extern void DeleteScrollableProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Scrollable__SWIG_0")]
            public static extern global::System.IntPtr NewScrollable();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Scrollable__SWIG_1")]
            public static extern global::System.IntPtr NewScrollable(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Scrollable")]
            public static extern void DeleteScrollable(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_IsOvershootEnabled")]
            public static extern bool IsOvershootEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_SetOvershootEnabled")]
            public static extern void SetOvershootEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_SetOvershootEffectColor")]
            public static extern void SetOvershootEffectColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_GetOvershootEffectColor")]
            public static extern global::System.IntPtr GetOvershootEffectColor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_SetOvershootAnimationSpeed")]
            public static extern void SetOvershootAnimationSpeed(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_GetOvershootAnimationSpeed")]
            public static extern float GetOvershootAnimationSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_ScrollStartedSignal")]
            public static extern global::System.IntPtr ScrollStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_ScrollUpdatedSignal")]
            public static extern global::System.IntPtr ScrollUpdatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_ScrollCompletedSignal")]
            public static extern global::System.IntPtr ScrollCompletedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
