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
        internal static partial class ActorProperty
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_INHERIT_LAYOUT_DIRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InheritLayoutDirectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_LAYOUT_DIRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LayoutDirectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_SIBLING_ORDER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SiblingOrderGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_OPACITY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OpacityGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_SCREEN_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScreenPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_POSITION_USES_ANCHOR_POINT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PositionUsesAnchorPointGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_PARENT_ORIGIN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ParentOriginGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_PARENT_ORIGIN_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ParentOriginXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_PARENT_ORIGIN_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ParentOriginYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_PARENT_ORIGIN_Z_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ParentOriginZGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_ANCHOR_POINT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AnchorPointGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_ANCHOR_POINT_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AnchorPointXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_ANCHOR_POINT_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AnchorPointYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_ANCHOR_POINT_Z_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AnchorPointZGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SIZE_WIDTH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SizeWidthGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SIZE_HEIGHT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SizeHeightGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SIZE_DEPTH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SizeDepthGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_POSITION_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PositionXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_POSITION_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PositionYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_POSITION_Z_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PositionZGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WORLD_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WORLD_POSITION_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldPositionXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WORLD_POSITION_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldPositionYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WORLD_POSITION_Z_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldPositionZGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_ORIENTATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int OrientationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WORLD_ORIENTATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldOrientationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SCALE_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScaleXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SCALE_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScaleYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SCALE_Z_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScaleZGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WORLD_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_VISIBLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VisibleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_COLOR_RED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ColorRedGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_COLOR_GREEN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ColorGreenGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_COLOR_BLUE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ColorBlueGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WORLD_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WORLD_MATRIX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldMatrixGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_NAME_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int NameGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SENSITIVE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SensitiveGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_USER_INTERACTION_ENABLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UserInteractionEnabledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_LEAVE_REQUIRED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LeaveRequiredGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_INHERIT_ORIENTATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InheritOrientationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_INHERIT_SCALE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InheritScaleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_DRAW_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DrawModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SIZE_MODE_FACTOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SizeModeFactorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WIDTH_RESIZE_POLICY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WidthResizePolicyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_HEIGHT_RESIZE_POLICY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int HeightResizePolicyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_SIZE_SCALE_POLICY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SizeScalePolicyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_WIDTH_FOR_HEIGHT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WidthForHeightGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_HEIGHT_FOR_WIDTH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int HeightForWidthGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_MINIMUM_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MinimumSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_MAXIMUM_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MaximumSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_INHERIT_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InheritPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_CLIPPING_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ClippingModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_CAPTURE_ALL_TOUCH_AFTER_START_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CaptureAllTouchAfterStartGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_ALLOW_ONLY_OWN_TOUCH_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AllowOnlyOwnTouchGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_BLEND_EQUATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendEquationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_CULLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CulledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_Property_UPDATE_AREA_HINT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UpdateAreaHintGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_DISPATCH_TOUCH_MOTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DispatchTouchMotionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_DISPATCH_HOVER_MOTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DispatchHoverMotionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_CHILDREN_DEPTH_INDEX_POLICY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildrenDepthIndexPolicyGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_IGNORED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int IgnoredGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Actor_Property_WORLD_IGNORED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WorldIgnoredGet();
        }
    }
}





