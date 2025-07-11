/*
 * Copyright(c) 2019-2022 Samsung Electronics Co., Ltd.
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
    /// Layout policies to decide the size of View when the View is laid out in its parent View.
    /// LayoutParamPolicies.MatchParent and LayoutParamPolicies.WrapContent can be assigned to <see cref="View.WidthSpecification"/> and <see cref="View.HeightSpecification"/>.
    /// </summary>
    /// <example>
    /// <code>
    /// // matchParentView matches its size to its parent size.
    /// matchParentView.WidthSpecification = LayoutParamPolicies.MatchParent;
    /// matchParentView.HeightSpecification = LayoutParamPolicies.MatchParent;
    ///
    /// // wrapContentView wraps its children with their desired size.
    /// wrapContentView.WidthSpecification = LayoutParamPolicies.WrapContent;
    /// wrapContentView.HeightSpecification = LayoutParamPolicies.WrapContent;
    /// </code>
    /// </example>
    /// <since_tizen> 9 </since_tizen>
    public static class LayoutParamPolicies
    {
        /// <summary>
        /// Constant which indicates child size should match parent size.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public const int MatchParent = -1;
        /// <summary>
        /// Constant which indicates parent should take the smallest size possible to wrap its children with their desired size.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
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
            PageDown,
            /// <summary>
            /// Move keyboard focus towards the forward direction.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Forward,
            /// <summary>
            /// Move keyboard focus towards the backward direction.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Backward,
            /// <summary>
            /// Move focus towards the Clockwise direction by rotary wheel.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Clockwise,
            /// <summary>
            /// Move focus towards the CounterClockwise direction by rotary wheel.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            CounterClockwise,
        }

        /// <summary>
        /// Describes offscreen rendering types.
        /// View with this property enabled renders at offscreen buffer, with all its children.
        /// The property expects to reduce many repetitive render calls.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum OffScreenRenderingType
        {
            /// <summary>
            /// No offscreen rendering.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            None,
            /// <summary>
            /// Draw offscreen only once.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            RefreshOnce,
            /// <summary>
            /// Draw offscreen every frame.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            RefreshAlways,
        };


        /// <summary>
        /// Actions property value to update visual property.
        /// Note : Only few kind of properies can be update. Update with invalid property action is undefined.
        /// </summary>
        internal static readonly int ActionUpdateProperty = Interop.Visual.GetActionUpdateProperty();

        internal enum PropertyRange
        {
            PROPERTY_START_INDEX = PropertyRanges.PROPERTY_REGISTRATION_START_INDEX,
            CONTROL_PROPERTY_START_INDEX = PROPERTY_START_INDEX,
            CONTROL_PROPERTY_END_INDEX = CONTROL_PROPERTY_START_INDEX + 1000
        }

        internal class Property
        {
            private enum Index
            {
                Tooltip,
                State,
                SubState,
                LeftFocusableViewId,
                RightFocusableViewId,
                UpFocusableViewId,
                DownFocusableViewId,
                ClockwiseFocusableViewId,
                CounterClockwiseFocusableViewId,
                StyleName,
                KeyInputFocus,
                Background,
                SiblingOrder,
                Opacity,
                ScreenPosition,
                PositionUsesAnchorPoint,
                ParentOrigin,
                ParentOriginX,
                ParentOriginY,
                ParentOriginZ,
                AnchorPoint,
                AnchorPointX,
                AnchorPointY,
                AnchorPointZ,
                Size,
                SizeWidth,
                SizeHeight,
                SizeDepth,
                Position,
                PositionX,
                PositionY,
                PositionZ,
                WorldPosition,
                WorldPositionX,
                WorldPositionY,
                WorldPositionZ,
                Orientation,
                WorldOrientation,
                Scale,
                ScaleX,
                ScaleY,
                ScaleZ,
                WorldScale,
                Visible,
                Color,
                ColorRed,
                ColorGreen,
                ColorBlue,
                WorldColor,
                WorldMatrix,
                Name,
                Sensitive,
                UserInteractionEnabled,
                LeaveRequired,
                InheritOrientation,
                InheritScale,
                DrawMode,
                SizeModeFactor,
                WidthResizePolicy,
                HeightResizePolicy,
                SizeScalePolicy,
                WidthForHeight,
                HeightForWidth,
                MinimumSize,
                MaximumSize,
                InheritPosition,
                ClippingMode,
                InheritLayoutDirection,
                LayoutDirection,
                Margin,
                Padding,
                Shadow,
                CaptureAllTouchAfterStart,
                AllowOnlyOwnTouch,
                BlendEquation,
                Culled,
                AccessibilityName,
                AccessibilityDescription,
                AccessibilityTranslationDomain,
                AccessibilityRole,
                AccessibilityHighlightable,
                AccessibilityAttributes,
                DispatchKeyEvents,
                AccessibilityHidden,
                AutomationId,
                AccessibilityState,
                AccessibilityIsModal,
                AccessibilityValue,
                AccessibilityScrollable,
                UpdateAreaHint,
                DispatchTouchMotion,
                DispatchHoverMotion,
                OffScreenRendering,
                InnerShadow,
                Borderline,
                CornerRadiusPolicy,
                CornerRadius,
                CornerSquareness,
                BorderlineWidth,
                BorderlineColor,
                BorderlineOffset,
            };

            internal static readonly int Tooltip = Interop.ViewProperty.GetIndex((int)Index.Tooltip);
            internal static readonly int State = Interop.ViewProperty.GetIndex((int)Index.State);
            internal static readonly int SubState = Interop.ViewProperty.GetIndex((int)Index.SubState);
            internal static readonly int LeftFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.LeftFocusableViewId);
            internal static readonly int RightFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.RightFocusableViewId);
            internal static readonly int UpFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.UpFocusableViewId);
            internal static readonly int DownFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.DownFocusableViewId);
            internal static readonly int ClockwiseFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.ClockwiseFocusableViewId);
            internal static readonly int CounterClockwiseFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.CounterClockwiseFocusableViewId);
            internal static readonly int StyleName = Interop.ViewProperty.GetIndex((int)Index.StyleName);
            internal static readonly int KeyInputFocus = Interop.ViewProperty.GetIndex((int)Index.KeyInputFocus);
            internal static readonly int Background = Interop.ViewProperty.GetIndex((int)Index.Background);
            internal static readonly int SiblingOrder = Interop.ViewProperty.GetIndex((int)Index.SiblingOrder);
            internal static readonly int Opacity = Interop.ViewProperty.GetIndex((int)Index.Opacity);
            internal static readonly int ScreenPosition = Interop.ViewProperty.GetIndex((int)Index.ScreenPosition);
            internal static readonly int PositionUsesAnchorPoint = Interop.ViewProperty.GetIndex((int)Index.PositionUsesAnchorPoint);
            internal static readonly int ParentOrigin = Interop.ViewProperty.GetIndex((int)Index.ParentOrigin);
            internal static readonly int ParentOriginX = Interop.ViewProperty.GetIndex((int)Index.ParentOriginX);
            internal static readonly int ParentOriginY = Interop.ViewProperty.GetIndex((int)Index.ParentOriginY);
            internal static readonly int ParentOriginZ = Interop.ViewProperty.GetIndex((int)Index.ParentOriginZ);
            internal static readonly int AnchorPoint = Interop.ViewProperty.GetIndex((int)Index.AnchorPoint);
            internal static readonly int AnchorPointX = Interop.ViewProperty.GetIndex((int)Index.AnchorPointX);
            internal static readonly int AnchorPointY = Interop.ViewProperty.GetIndex((int)Index.AnchorPointY);
            internal static readonly int AnchorPointZ = Interop.ViewProperty.GetIndex((int)Index.AnchorPointZ);
            internal static readonly int Size = Interop.ViewProperty.GetIndex((int)Index.Size);
            internal static readonly int SizeWidth = Interop.ViewProperty.GetIndex((int)Index.SizeWidth);
            internal static readonly int SizeHeight = Interop.ViewProperty.GetIndex((int)Index.SizeHeight);
            internal static readonly int SizeDepth = Interop.ViewProperty.GetIndex((int)Index.SizeDepth);
            internal static readonly int Position = Interop.ViewProperty.GetIndex((int)Index.Position);
            internal static readonly int PositionX = Interop.ViewProperty.GetIndex((int)Index.PositionX);
            internal static readonly int PositionY = Interop.ViewProperty.GetIndex((int)Index.PositionY);
            internal static readonly int PositionZ = Interop.ViewProperty.GetIndex((int)Index.PositionZ);
            internal static readonly int WorldPosition = Interop.ViewProperty.GetIndex((int)Index.WorldPosition);
            internal static readonly int WorldPositionX = Interop.ViewProperty.GetIndex((int)Index.WorldPositionX);
            internal static readonly int WorldPositionY = Interop.ViewProperty.GetIndex((int)Index.WorldPositionY);
            internal static readonly int WorldPositionZ = Interop.ViewProperty.GetIndex((int)Index.WorldPositionZ);
            internal static readonly int Orientation = Interop.ViewProperty.GetIndex((int)Index.Orientation);
            internal static readonly int WorldOrientation = Interop.ViewProperty.GetIndex((int)Index.WorldOrientation);
            internal static readonly int Scale = Interop.ViewProperty.GetIndex((int)Index.Scale);
            internal static readonly int ScaleX = Interop.ViewProperty.GetIndex((int)Index.ScaleX);
            internal static readonly int ScaleY = Interop.ViewProperty.GetIndex((int)Index.ScaleY);
            internal static readonly int ScaleZ = Interop.ViewProperty.GetIndex((int)Index.ScaleZ);
            internal static readonly int WorldScale = Interop.ViewProperty.GetIndex((int)Index.WorldScale);
            internal static readonly int Visible = Interop.ViewProperty.GetIndex((int)Index.Visible);
            internal static readonly int Color = Interop.ViewProperty.GetIndex((int)Index.Color);
            internal static readonly int ColorRed = Interop.ViewProperty.GetIndex((int)Index.ColorRed);
            internal static readonly int ColorGreen = Interop.ViewProperty.GetIndex((int)Index.ColorGreen);
            internal static readonly int ColorBlue = Interop.ViewProperty.GetIndex((int)Index.ColorBlue);
            internal static readonly int WorldColor = Interop.ViewProperty.GetIndex((int)Index.WorldColor);
            internal static readonly int WorldMatrix = Interop.ViewProperty.GetIndex((int)Index.WorldMatrix);
            internal static readonly int Name = Interop.ViewProperty.GetIndex((int)Index.Name);
            internal static readonly int Sensitive = Interop.ViewProperty.GetIndex((int)Index.Sensitive);
            internal static readonly int UserInteractionEnabled = Interop.ViewProperty.GetIndex((int)Index.UserInteractionEnabled);
            internal static readonly int LeaveRequired = Interop.ViewProperty.GetIndex((int)Index.LeaveRequired);
            internal static readonly int InheritOrientation = Interop.ViewProperty.GetIndex((int)Index.InheritOrientation);
            internal static readonly int InheritScale = Interop.ViewProperty.GetIndex((int)Index.InheritScale);
            internal static readonly int DrawMode = Interop.ViewProperty.GetIndex((int)Index.DrawMode);
            internal static readonly int SizeModeFactor = Interop.ViewProperty.GetIndex((int)Index.SizeModeFactor);
            internal static readonly int WidthResizePolicy = Interop.ViewProperty.GetIndex((int)Index.WidthResizePolicy);
            internal static readonly int HeightResizePolicy = Interop.ViewProperty.GetIndex((int)Index.HeightResizePolicy);
            internal static readonly int SizeScalePolicy = Interop.ViewProperty.GetIndex((int)Index.SizeScalePolicy);
            internal static readonly int WidthForHeight = Interop.ViewProperty.GetIndex((int)Index.WidthForHeight);
            internal static readonly int HeightForWidth = Interop.ViewProperty.GetIndex((int)Index.HeightForWidth);
            internal static readonly int MinimumSize = Interop.ViewProperty.GetIndex((int)Index.MinimumSize);
            internal static readonly int MaximumSize = Interop.ViewProperty.GetIndex((int)Index.MaximumSize);
            internal static readonly int InheritPosition = Interop.ViewProperty.GetIndex((int)Index.InheritPosition);
            internal static readonly int ClippingMode = Interop.ViewProperty.GetIndex((int)Index.ClippingMode);
            internal static readonly int InheritLayoutDirection = Interop.ViewProperty.GetIndex((int)Index.InheritLayoutDirection);
            internal static readonly int LayoutDirection = Interop.ViewProperty.GetIndex((int)Index.LayoutDirection);
            internal static readonly int Margin = Interop.ViewProperty.GetIndex((int)Index.Margin);
            internal static readonly int Padding = Interop.ViewProperty.GetIndex((int)Index.Padding);
            internal static readonly int Shadow = Interop.ViewProperty.GetIndex((int)Index.Shadow);
            internal static readonly int CaptureAllTouchAfterStart = Interop.ViewProperty.GetIndex((int)Index.CaptureAllTouchAfterStart);
            internal static readonly int AllowOnlyOwnTouch = Interop.ViewProperty.GetIndex((int)Index.AllowOnlyOwnTouch);
            internal static readonly int BlendEquation = Interop.ViewProperty.GetIndex((int)Index.BlendEquation);
            internal static readonly int Culled = Interop.ViewProperty.GetIndex((int)Index.Culled);
            internal static readonly int AccessibilityName = Interop.ViewProperty.GetIndex((int)Index.AccessibilityName);
            internal static readonly int AccessibilityDescription = Interop.ViewProperty.GetIndex((int)Index.AccessibilityDescription);
            internal static readonly int AccessibilityTranslationDomain = Interop.ViewProperty.GetIndex((int)Index.AccessibilityTranslationDomain);
            internal static readonly int AccessibilityRole = Interop.ViewProperty.GetIndex((int)Index.AccessibilityRole);
            internal static readonly int AccessibilityHighlightable = Interop.ViewProperty.GetIndex((int)Index.AccessibilityHighlightable);
            internal static readonly int AccessibilityAttributes = Interop.ViewProperty.GetIndex((int)Index.AccessibilityAttributes);
            internal static readonly int DispatchKeyEvents = Interop.ViewProperty.GetIndex((int)Index.DispatchKeyEvents);
            internal static readonly int AccessibilityHidden = Interop.ViewProperty.GetIndex((int)Index.AccessibilityHidden);
            internal static readonly int AutomationId = Interop.ViewProperty.GetIndex((int)Index.AutomationId);
            internal static readonly int AccessibilityState = Interop.ViewProperty.GetIndex((int)Index.AccessibilityState);
            internal static readonly int AccessibilityIsModal = Interop.ViewProperty.GetIndex((int)Index.AccessibilityIsModal);
            internal static readonly int AccessibilityValue = Interop.ViewProperty.GetIndex((int)Index.AccessibilityValue);
            internal static readonly int AccessibilityScrollable = Interop.ViewProperty.GetIndex((int)Index.AccessibilityScrollable);
            internal static readonly int UpdateAreaHint = Interop.ViewProperty.GetIndex((int)Index.UpdateAreaHint);
            internal static readonly int DispatchTouchMotion = Interop.ViewProperty.GetIndex((int)Index.DispatchTouchMotion);
            internal static readonly int DispatchHoverMotion = Interop.ViewProperty.GetIndex((int)Index.DispatchHoverMotion);
            internal static readonly int OffScreenRendering = Interop.ViewProperty.GetIndex((int)Index.OffScreenRendering);
            internal static readonly int InnerShadow = Interop.ViewProperty.GetIndex((int)Index.InnerShadow);
            internal static readonly int Borderline = Interop.ViewProperty.GetIndex((int)Index.Borderline);
            internal static readonly int CornerRadiusPolicy = Interop.ViewProperty.GetIndex((int)Index.CornerRadiusPolicy);
            internal static readonly int CornerRadius = Interop.ViewProperty.GetIndex((int)Index.CornerRadius);
            internal static readonly int CornerSquareness = Interop.ViewProperty.GetIndex((int)Index.CornerSquareness);
            internal static readonly int BorderlineWidth = Interop.ViewProperty.GetIndex((int)Index.BorderlineWidth);
            internal static readonly int BorderlineColor = Interop.ViewProperty.GetIndex((int)Index.BorderlineColor);
            internal static readonly int BorderlineOffset = Interop.ViewProperty.GetIndex((int)Index.BorderlineOffset);


            /* For Compatibility. This will be removed after synchronization*/
            internal static readonly int TOOLTIP = Tooltip;
            internal static readonly int STATE = State;
            internal static readonly int BACKGROUND = Background;
            internal static readonly int OPACITY = Opacity;
            internal static readonly int SIZE = Size;
            internal static readonly int POSITION = Position;
            internal static readonly int ORIENTATION = Orientation;
            internal static readonly int SCALE = Scale;
            internal static readonly int VISIBLE = Visible;
            internal static readonly int COLOR = Color;
            internal static readonly int NAME = Name;
            internal static readonly int SENSITIVE = Sensitive;
            internal static readonly int MARGIN = Margin;
            internal static readonly int PADDING = Padding;
            internal static readonly int SHADOW = Shadow;
        }
    }
}
