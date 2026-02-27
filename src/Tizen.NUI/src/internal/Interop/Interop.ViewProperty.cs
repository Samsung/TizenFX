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
        internal static partial class ViewProperty
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_STYLE_NAME_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StyleNameGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_KEY_INPUT_FOCUS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int KeyInputFocusGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BACKGROUND_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BackgroundGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_MARGIN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MarginGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_PADDING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PaddingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_TOOLTIP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TooltipGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_STATE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StateGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_SUB_STATE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SubStateGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_LEFT_FOCUSABLE_ACTOR_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LeftFocusableActorIdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RightFocusableActorIdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_UP_FOCUSABLE_ACTOR_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UpFocusableActorIdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_DOWN_FOCUSABLE_ACTOR_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DownFocusableActorIdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_CLOCKWISE_FOCUSABLE_ACTOR_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ClockwiseFocusableActorIdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_View_Property_COUNTER_CLOCKWISE_FOCUSABLE_ACTOR_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CounterClockwiseFocusableActorIdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_SHADOW_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ShadowGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_NAME_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityNameGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_DESCRIPTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityDescriptionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_TRANSLATION_DOMAIN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityTranslationDomainGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_ROLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityRoleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_HIGHLIGHTABLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityHighlightableGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_ATTRIBUTES_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityAttributesGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_DISPATCH_KEY_EVENTS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DispatchKeyEventsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_HIDDEN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityHiddenGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_AUTOMATION_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AutomationIdGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_STATES_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityStateGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_IS_MODAL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityIsModalGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACESSIBILITY_VALUE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityValueGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_ACCESSIBILITY_SCROLLABLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AccessibilityScrollableGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_OFFSCREEN_RENDERING_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OffScreenRenderingGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_INNER_SHADOW_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InnerShadowGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BORDERLINE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BorderlineGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_CORNER_RADIUS_POLICY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CornerRadiusPolicyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_CORNER_RADIUS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CornerRadiusGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_CORNER_SQUARENESS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CornerSquarenessGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BORDERLINE_WIDTH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BorderlineWidthGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BORDERLINE_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BorderlineColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_Property_BORDERLINE_OFFSET_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BorderlineOffsetGet();
        }
    }
}





