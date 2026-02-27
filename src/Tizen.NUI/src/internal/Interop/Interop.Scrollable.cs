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
        internal static partial class Scrollable
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_OVERSHOOT_EFFECT_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OvershootEffectColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_OVERSHOOT_ANIMATION_SPEED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OvershootAnimationSpeedGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_OVERSHOOT_ENABLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OvershootEnabledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_OVERSHOOT_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OvershootSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_TO_ALPHA_FUNCTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollToAlphaFunctionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_RELATIVE_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollRelativePositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionMinGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionMinXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionMinYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionMaxGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionMaxXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionMaxYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_CAN_SCROLL_VERTICAL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CanScrollVerticalGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_Property_CAN_SCROLL_HORIZONTAL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CanScrollHorizontalGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Scrollable__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewScrollable();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Scrollable", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteScrollable(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_IsOvershootEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsOvershootEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_SetOvershootEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOvershootEnabled(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_SetOvershootEffectColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOvershootEffectColor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_GetOvershootEffectColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetOvershootEffectColor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_SetOvershootAnimationSpeed", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOvershootAnimationSpeed(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_GetOvershootAnimationSpeed", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetOvershootAnimationSpeed(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_ScrollStartedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScrollStartedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_ScrollUpdatedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScrollUpdatedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Scrollable_ScrollCompletedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScrollCompletedSignal(IntPtr jarg1);
        }
    }
}





