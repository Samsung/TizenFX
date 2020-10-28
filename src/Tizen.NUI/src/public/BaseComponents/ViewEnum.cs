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
            internal static readonly int BACKGROUND = Interop.ViewProperty.View_Property_BACKGROUND_get();
            internal static readonly int SIBLING_ORDER = Interop.ActorProperty.Actor_Property_SIBLING_ORDER_get();
            internal static readonly int OPACITY = Interop.ActorProperty.Actor_Property_OPACITY_get();
            internal static readonly int SCREEN_POSITION = Interop.ActorProperty.Actor_Property_SCREEN_POSITION_get();
            internal static readonly int POSITION_USES_ANCHOR_POINT = Interop.ActorProperty.Actor_Property_POSITION_USES_ANCHOR_POINT_get();
            internal static readonly int PARENT_ORIGIN = Interop.ActorProperty.Actor_Property_PARENT_ORIGIN_get();
            internal static readonly int PARENT_ORIGIN_X = Interop.ActorProperty.Actor_Property_PARENT_ORIGIN_X_get();
            internal static readonly int PARENT_ORIGIN_Y = Interop.ActorProperty.Actor_Property_PARENT_ORIGIN_Y_get();
            internal static readonly int PARENT_ORIGIN_Z = Interop.ActorProperty.Actor_Property_PARENT_ORIGIN_Z_get();
            internal static readonly int ANCHOR_POINT = Interop.ActorProperty.Actor_Property_ANCHOR_POINT_get();
            internal static readonly int ANCHOR_POINT_X = Interop.ActorProperty.Actor_Property_ANCHOR_POINT_X_get();
            internal static readonly int ANCHOR_POINT_Y = Interop.ActorProperty.Actor_Property_ANCHOR_POINT_Y_get();
            internal static readonly int ANCHOR_POINT_Z = Interop.ActorProperty.Actor_Property_ANCHOR_POINT_Z_get();
            internal static readonly int SIZE = Interop.ActorProperty.Actor_Property_SIZE_get();
            internal static readonly int SIZE_WIDTH = Interop.ActorProperty.Actor_Property_SIZE_WIDTH_get();
            internal static readonly int SIZE_HEIGHT = Interop.ActorProperty.Actor_Property_SIZE_HEIGHT_get();
            internal static readonly int SIZE_DEPTH = Interop.ActorProperty.Actor_Property_SIZE_DEPTH_get();
            internal static readonly int POSITION = Interop.ActorProperty.Actor_Property_POSITION_get();
            internal static readonly int POSITION_X = Interop.ActorProperty.Actor_Property_POSITION_X_get();
            internal static readonly int POSITION_Y = Interop.ActorProperty.Actor_Property_POSITION_Y_get();
            internal static readonly int POSITION_Z = Interop.ActorProperty.Actor_Property_POSITION_Z_get();
            internal static readonly int WORLD_POSITION = Interop.ActorProperty.Actor_Property_WORLD_POSITION_get();
            internal static readonly int WORLD_POSITION_X = Interop.ActorProperty.Actor_Property_WORLD_POSITION_X_get();
            internal static readonly int WORLD_POSITION_Y = Interop.ActorProperty.Actor_Property_WORLD_POSITION_Y_get();
            internal static readonly int WORLD_POSITION_Z = Interop.ActorProperty.Actor_Property_WORLD_POSITION_Z_get();
            internal static readonly int ORIENTATION = Interop.ActorProperty.Actor_Property_ORIENTATION_get();
            internal static readonly int WORLD_ORIENTATION = Interop.ActorProperty.Actor_Property_WORLD_ORIENTATION_get();
            internal static readonly int SCALE = Interop.ActorProperty.Actor_Property_SCALE_get();
            internal static readonly int SCALE_X = Interop.ActorProperty.Actor_Property_SCALE_X_get();
            internal static readonly int SCALE_Y = Interop.ActorProperty.Actor_Property_SCALE_Y_get();
            internal static readonly int SCALE_Z = Interop.ActorProperty.Actor_Property_SCALE_Z_get();
            internal static readonly int WORLD_SCALE = Interop.ActorProperty.Actor_Property_WORLD_SCALE_get();
            internal static readonly int VISIBLE = Interop.ActorProperty.Actor_Property_VISIBLE_get();
            internal static readonly int WORLD_COLOR = Interop.ActorProperty.Actor_Property_WORLD_COLOR_get();
            internal static readonly int WORLD_MATRIX = Interop.ActorProperty.Actor_Property_WORLD_MATRIX_get();
            internal static readonly int NAME = Interop.ActorProperty.Actor_Property_NAME_get();
            internal static readonly int SENSITIVE = Interop.ActorProperty.Actor_Property_SENSITIVE_get();
            internal static readonly int LEAVE_REQUIRED = Interop.ActorProperty.Actor_Property_LEAVE_REQUIRED_get();
            internal static readonly int INHERIT_ORIENTATION = Interop.ActorProperty.Actor_Property_INHERIT_ORIENTATION_get();
            internal static readonly int INHERIT_SCALE = Interop.ActorProperty.Actor_Property_INHERIT_SCALE_get();
            internal static readonly int DRAW_MODE = Interop.ActorProperty.Actor_Property_DRAW_MODE_get();
            internal static readonly int SIZE_MODE_FACTOR = Interop.ActorProperty.Actor_Property_SIZE_MODE_FACTOR_get();
            internal static readonly int WIDTH_RESIZE_POLICY = Interop.ActorProperty.Actor_Property_WIDTH_RESIZE_POLICY_get();
            internal static readonly int HEIGHT_RESIZE_POLICY = Interop.ActorProperty.Actor_Property_HEIGHT_RESIZE_POLICY_get();
            internal static readonly int SIZE_SCALE_POLICY = Interop.ActorProperty.Actor_Property_SIZE_SCALE_POLICY_get();
            internal static readonly int WIDTH_FOR_HEIGHT = Interop.ActorProperty.Actor_Property_WIDTH_FOR_HEIGHT_get();
            internal static readonly int HEIGHT_FOR_WIDTH = Interop.ActorProperty.Actor_Property_HEIGHT_FOR_WIDTH_get();
            internal static readonly int MINIMUM_SIZE = Interop.ActorProperty.Actor_Property_MINIMUM_SIZE_get();
            internal static readonly int MAXIMUM_SIZE = Interop.ActorProperty.Actor_Property_MAXIMUM_SIZE_get();
            internal static readonly int INHERIT_POSITION = Interop.ActorProperty.Actor_Property_INHERIT_POSITION_get();
            internal static readonly int CLIPPING_MODE = Interop.ActorProperty.Actor_Property_CLIPPING_MODE_get();
            internal static readonly int INHERIT_LAYOUT_DIRECTION = Interop.ActorProperty.Actor_Property_INHERIT_LAYOUT_DIRECTION_get();
            internal static readonly int LAYOUT_DIRECTION = Interop.ActorProperty.Actor_Property_LAYOUT_DIRECTION_get();
            internal static readonly int MARGIN = Interop.ViewProperty.View_Property_MARGIN_get();
            internal static readonly int PADDING = Interop.ViewProperty.View_Property_PADDING_get();
            internal static readonly int SHADOW = Interop.ViewProperty.View_Property_SHADOW_get();
        }
    }
}
