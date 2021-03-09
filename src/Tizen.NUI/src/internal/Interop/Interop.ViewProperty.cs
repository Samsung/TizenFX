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
        internal static partial class ViewProperty
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_STYLE_NAME_get")]
            public static extern int StyleNameGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_KEY_INPUT_FOCUS_get")]
            public static extern int KeyInputFocusGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BACKGROUND_get")]
            public static extern int BackgroundGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_MARGIN_get")]
            public static extern int MarginGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_PADDING_get")]
            public static extern int PaddingGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_View_Property")]
            public static extern global::System.IntPtr NewViewProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_View_Property")]
            public static extern void DeleteViewProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_TOOLTIP_get")]
            public static extern int TooltipGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_STATE_get")]
            public static extern int StateGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_SUB_STATE_get")]
            public static extern int SubStateGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_LEFT_FOCUSABLE_ACTOR_ID_get")]
            public static extern int LeftFocusableActorIdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get")]
            public static extern int RightFocusableActorIdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_UP_FOCUSABLE_ACTOR_ID_get")]
            public static extern int UpFocusableActorIdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_DOWN_FOCUSABLE_ACTOR_ID_get")]
            public static extern int DownFocusableActorIdGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_UPDATE_SIZE_HINT_get")]
            public static extern int UpdateSizeHintGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_SHADOW_get")]
            public static extern int ShadowGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_NAME_get")]
            public static extern int AccessibilityNameGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_DESCRIPTION_get")]
            public static extern int AccessibilityDescriptionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_TRANSLATION_DOMAIN_get")]
            public static extern int AccessibilityTranslationDomainGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_ROLE_get")]
            public static extern int AccessibilityRoleGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_HIGHLIGHTABLE_get")]
            public static extern int AccessibilityHighlightableGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_ATTRIBUTES_get")]
            public static extern int AccessibilityAttributesGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_ANIMATED_get")]
            public static extern int AccessibilityAnimatedGet();
        }
    }
}
