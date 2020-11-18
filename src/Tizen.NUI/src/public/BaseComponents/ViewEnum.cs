/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The View layout Direction type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ViewLayoutDirectionType
    {
        /// <summary>
        /// Left to right.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        LTR,
        /// <summary>
        /// Right to left.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        RTL
    }

    /// <summary>
    /// [Draft] Available policies for layout parameters
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class LayoutParamPolicies
    {
        /// <summary>
        /// Constant which indicates child size should match parent size
        /// </summary>
       /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
       [EditorBrowsable(EditorBrowsableState.Never)]
        public const int MatchParent = -1;
        /// <summary>
        /// Constant which indicates parent should take the smallest size possible to wrap it's children with their desired size
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int WrapContent = -2;
    }

    internal enum ResourceLoadingStatusType
    {
        Invalid = -1,
        Preparing = 0,
        Ready,
        Failed,
    }

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        /// <summary>
        /// Enumeration for describing the states of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum States
        {
            /// <summary>
            /// The normal state.
            /// </summary>
            [Description("NORMAL")]
            Normal,
            /// <summary>
            /// The focused state.
            /// </summary>
            [Description("FOCUSED")]
            Focused,
            /// <summary>
            /// The disabled state.
            /// </summary>
            [Description("DISABLED")]
            Disabled
        }

        /// <summary>
        /// Describes the direction to move the focus towards.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum FocusDirection
        {
            /// <summary>
            /// Move keyboard focus towards the left direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Left,
            /// <summary>
            /// Move keyboard focus towards the right direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Right,
            /// <summary>
            /// Move keyboard focus towards the up direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Up,
            /// <summary>
            /// Move keyboard focus towards the down direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Down,
            /// <summary>
            /// Move keyboard focus towards the previous page direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            PageUp,
            /// <summary>
            /// Move keyboard focus towards the next page direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            PageDown
        }

        internal enum PropertyRange
        {
            PROPERTY_START_INDEX = PropertyRanges.PROPERTY_REGISTRATION_START_INDEX,
            CONTROL_PROPERTY_START_INDEX = PROPERTY_START_INDEX,
            CONTROL_PROPERTY_END_INDEX = CONTROL_PROPERTY_START_INDEX + 1000
        }

        internal class Property
        {
            internal static readonly int TOOLTIP = Interop.ViewProperty.View_Property_TOOLTIP_get();
            internal static readonly int STATE = Interop.ViewProperty.View_Property_STATE_get();
            internal static readonly int SUB_STATE = Interop.ViewProperty.View_Property_SUB_STATE_get();
            internal static readonly int LEFT_FOCUSABLE_VIEW_ID = Interop.ViewProperty.View_Property_LEFT_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int RIGHT_FOCUSABLE_VIEW_ID = Interop.ViewProperty.View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int UP_FOCUSABLE_VIEW_ID = Interop.ViewProperty.View_Property_UP_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int DOWN_FOCUSABLE_VIEW_ID = Interop.ViewProperty.View_Property_DOWN_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int STYLE_NAME = Interop.ViewProperty.View_Property_STYLE_NAME_get();
            internal static readonly int KEY_INPUT_FOCUS = Interop.ViewProperty.View_Property_KEY_INPUT_FOCUS_get();
            internal static readonly int BACKGROUND = Interop.ViewProperty.View_Property_BACKGROUND_get();
            internal static readonly int SIBLING_ORDER = Interop.ActorProperty.ActorPropertySiblingOrderGet();
            internal static readonly int OPACITY = Interop.ActorProperty.ActorPropertyOpacityGet();
            internal static readonly int SCREEN_POSITION = Interop.ActorProperty.ActorPropertyScreenPositionGet();
            internal static readonly int POSITION_USES_ANCHOR_POINT = Interop.ActorProperty.ActorPropertyPositionUsesAnchorPointGet();
            internal static readonly int PARENT_ORIGIN = Interop.ActorProperty.ActorPropertyParentOriginGet();
            internal static readonly int PARENT_ORIGIN_X = Interop.ActorProperty.ActorPropertyParentOriginXGet();
            internal static readonly int PARENT_ORIGIN_Y = Interop.ActorProperty.ActorPropertyParentOriginYGet();
            internal static readonly int PARENT_ORIGIN_Z = Interop.ActorProperty.ActorPropertyParentOriginZGet();
            internal static readonly int ANCHOR_POINT = Interop.ActorProperty.ActorPropertyAnchorPointGet();
            internal static readonly int ANCHOR_POINT_X = Interop.ActorProperty.ActorPropertyAnchorPointXGet();
            internal static readonly int ANCHOR_POINT_Y = Interop.ActorProperty.ActorPropertyAnchorPointYGet();
            internal static readonly int ANCHOR_POINT_Z = Interop.ActorProperty.ActorPropertyAnchorPointZGet();
            internal static readonly int SIZE = Interop.ActorProperty.ActorPropertySizeGet();
            internal static readonly int SIZE_WIDTH = Interop.ActorProperty.ActorPropertySizeWidthGet();
            internal static readonly int SIZE_HEIGHT = Interop.ActorProperty.ActorPropertySizeHeightGet();
            internal static readonly int SIZE_DEPTH = Interop.ActorProperty.ActorPropertySizeDepthGet();
            internal static readonly int POSITION = Interop.ActorProperty.ActorPropertyPositionGet();
            internal static readonly int POSITION_X = Interop.ActorProperty.ActorPropertyPositionXGet();
            internal static readonly int POSITION_Y = Interop.ActorProperty.ActorPropertyPositionYGet();
            internal static readonly int POSITION_Z = Interop.ActorProperty.ActorPropertyPositionZGet();
            internal static readonly int WORLD_POSITION = Interop.ActorProperty.ActorPropertyWorldPositionGet();
            internal static readonly int WORLD_POSITION_X = Interop.ActorProperty.ActorPropertyWorldPositionXGet();
            internal static readonly int WORLD_POSITION_Y = Interop.ActorProperty.ActorPropertyWorldPositionYGet();
            internal static readonly int WORLD_POSITION_Z = Interop.ActorProperty.ActorPropertyWorldPositionZGet();
            internal static readonly int ORIENTATION = Interop.ActorProperty.ActorPropertyOrientationGet();
            internal static readonly int WORLD_ORIENTATION = Interop.ActorProperty.ActorPropertyWorldOrientationGet();
            internal static readonly int SCALE = Interop.ActorProperty.ActorPropertyScaleGet();
            internal static readonly int SCALE_X = Interop.ActorProperty.ActorPropertyScaleXGet();
            internal static readonly int SCALE_Y = Interop.ActorProperty.ActorPropertyScaleYGet();
            internal static readonly int SCALE_Z = Interop.ActorProperty.ActorPropertyScaleZGet();
            internal static readonly int WORLD_SCALE = Interop.ActorProperty.ActorPropertyWorldScaleGet();
            internal static readonly int VISIBLE = Interop.ActorProperty.ActorPropertyVisibleGet();
            internal static readonly int WORLD_COLOR = Interop.ActorProperty.ActorPropertyWorldColorGet();
            internal static readonly int WORLD_MATRIX = Interop.ActorProperty.ActorPropertyWorldMatrixGet();
            internal static readonly int NAME = Interop.ActorProperty.ActorPropertyNameGet();
            internal static readonly int SENSITIVE = Interop.ActorProperty.ActorPropertySensitiveGet();
            internal static readonly int LEAVE_REQUIRED = Interop.ActorProperty.ActorPropertyLeaveRequiredGet();
            internal static readonly int INHERIT_ORIENTATION = Interop.ActorProperty.ActorPropertyInheritOrientationGet();
            internal static readonly int INHERIT_SCALE = Interop.ActorProperty.ActorPropertyInheritScaleGet();
            internal static readonly int DRAW_MODE = Interop.ActorProperty.ActorPropertyDrawModeGet();
            internal static readonly int SIZE_MODE_FACTOR = Interop.ActorProperty.ActorPropertySizeModeFactorGet();
            internal static readonly int WIDTH_RESIZE_POLICY = Interop.ActorProperty.ActorPropertyWidthResizePolicyGet();
            internal static readonly int HEIGHT_RESIZE_POLICY = Interop.ActorProperty.ActorPropertyHeightResizePolicyGet();
            internal static readonly int SIZE_SCALE_POLICY = Interop.ActorProperty.ActorPropertySizeScalePolicyGet();
            internal static readonly int WIDTH_FOR_HEIGHT = Interop.ActorProperty.ActorPropertyWidthForHeightGet();
            internal static readonly int HEIGHT_FOR_WIDTH = Interop.ActorProperty.ActorPropertyHeightForWidthGet();
            internal static readonly int MINIMUM_SIZE = Interop.ActorProperty.ActorPropertyMinimumSizeGet();
            internal static readonly int MAXIMUM_SIZE = Interop.ActorProperty.ActorPropertyMaximumSizeGet();
            internal static readonly int INHERIT_POSITION = Interop.ActorProperty.ActorPropertyInheritPositionGet();
            internal static readonly int CLIPPING_MODE = Interop.ActorProperty.ActorPropertyClippingModeGet();
            internal static readonly int INHERIT_LAYOUT_DIRECTION = Interop.ActorProperty.ActorPropertyInheritLayoutDirectionGet();
            internal static readonly int LAYOUT_DIRECTION = Interop.ActorProperty.ActorPropertyLayoutDirectionGet();
            internal static readonly int MARGIN = Interop.ViewProperty.View_Property_MARGIN_get();
            internal static readonly int PADDING = Interop.ViewProperty.View_Property_PADDING_get();
            internal static readonly int SHADOW = Interop.ViewProperty.View_Property_SHADOW_get();
            internal static readonly int CaptureAllTouchAfterStart = Interop.ActorProperty.ActorPropertyCaptureAllTouchAfterStartGet();
        }
    }
}
