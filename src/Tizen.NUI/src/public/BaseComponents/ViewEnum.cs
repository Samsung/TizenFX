/*
 * Copyright(c) 2019-2021 Samsung Electronics Co., Ltd.
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
            internal static readonly int TOOLTIP = Interop.ViewProperty.TooltipGet();
            internal static readonly int STATE = Interop.ViewProperty.StateGet();
            internal static readonly int SubState = Interop.ViewProperty.SubStateGet();
            internal static readonly int LeftFocusableViewId = Interop.ViewProperty.LeftFocusableActorIdGet();
            internal static readonly int RightFocusableViewId = Interop.ViewProperty.RightFocusableActorIdGet();
            internal static readonly int UpFocusableViewId = Interop.ViewProperty.UpFocusableActorIdGet();
            internal static readonly int DownFocusableViewId = Interop.ViewProperty.DownFocusableActorIdGet();
            internal static readonly int StyleName = Interop.ViewProperty.StyleNameGet();
            internal static readonly int KeyInputFocus = Interop.ViewProperty.KeyInputFocusGet();
            internal static readonly int BACKGROUND = Interop.ViewProperty.BackgroundGet();
            internal static readonly int SiblingOrder = Interop.ActorProperty.SiblingOrderGet();
            internal static readonly int OPACITY = Interop.ActorProperty.OpacityGet();
            internal static readonly int ScreenPosition = Interop.ActorProperty.ScreenPositionGet();
            internal static readonly int PositionUsesAnchorPoint = Interop.ActorProperty.PositionUsesAnchorPointGet();
            internal static readonly int ParentOrigin = Interop.ActorProperty.ParentOriginGet();
            internal static readonly int ParentOriginX = Interop.ActorProperty.ParentOriginXGet();
            internal static readonly int ParentOriginY = Interop.ActorProperty.ParentOriginYGet();
            internal static readonly int ParentOriginZ = Interop.ActorProperty.ParentOriginZGet();
            internal static readonly int AnchorPoint = Interop.ActorProperty.AnchorPointGet();
            internal static readonly int AnchorPointX = Interop.ActorProperty.AnchorPointXGet();
            internal static readonly int AnchorPointY = Interop.ActorProperty.AnchorPointYGet();
            internal static readonly int AnchorPointZ = Interop.ActorProperty.AnchorPointZGet();
            internal static readonly int SIZE = Interop.ActorProperty.SizeGet();
            internal static readonly int SizeWidth = Interop.ActorProperty.SizeWidthGet();
            internal static readonly int SizeHeight = Interop.ActorProperty.SizeHeightGet();
            internal static readonly int SizeDepth = Interop.ActorProperty.SizeDepthGet();
            internal static readonly int POSITION = Interop.ActorProperty.PositionGet();
            internal static readonly int PositionX = Interop.ActorProperty.PositionXGet();
            internal static readonly int PositionY = Interop.ActorProperty.PositionYGet();
            internal static readonly int PositionZ = Interop.ActorProperty.PositionZGet();
            internal static readonly int WorldPosition = Interop.ActorProperty.WorldPositionGet();
            internal static readonly int WorldPositionX = Interop.ActorProperty.WorldPositionXGet();
            internal static readonly int WorldPositionY = Interop.ActorProperty.WorldPositionYGet();
            internal static readonly int WorldPositionZ = Interop.ActorProperty.WorldPositionZGet();
            internal static readonly int ORIENTATION = Interop.ActorProperty.OrientationGet();
            internal static readonly int WorldOrientation = Interop.ActorProperty.WorldOrientationGet();
            internal static readonly int SCALE = Interop.ActorProperty.ScaleGet();
            internal static readonly int ScaleX = Interop.ActorProperty.ScaleXGet();
            internal static readonly int ScaleY = Interop.ActorProperty.ScaleYGet();
            internal static readonly int ScaleZ = Interop.ActorProperty.ScaleZGet();
            internal static readonly int WorldScale = Interop.ActorProperty.WorldScaleGet();
            internal static readonly int VISIBLE = Interop.ActorProperty.VisibleGet();
            internal static readonly int WorldColor = Interop.ActorProperty.WorldColorGet();
            internal static readonly int WorldMatrix = Interop.ActorProperty.WorldMatrixGet();
            internal static readonly int NAME = Interop.ActorProperty.NameGet();
            internal static readonly int SENSITIVE = Interop.ActorProperty.SensitiveGet();
            internal static readonly int LeaveRequired = Interop.ActorProperty.LeaveRequiredGet();
            internal static readonly int InheritOrientation = Interop.ActorProperty.InheritOrientationGet();
            internal static readonly int InheritScale = Interop.ActorProperty.InheritScaleGet();
            internal static readonly int DrawMode = Interop.ActorProperty.DrawModeGet();
            internal static readonly int SizeModeFactor = Interop.ActorProperty.SizeModeFactorGet();
            internal static readonly int WidthResizePolicy = Interop.ActorProperty.WidthResizePolicyGet();
            internal static readonly int HeightResizePolicy = Interop.ActorProperty.HeightResizePolicyGet();
            internal static readonly int SizeScalePolicy = Interop.ActorProperty.SizeScalePolicyGet();
            internal static readonly int WidthForHeight = Interop.ActorProperty.WidthForHeightGet();
            internal static readonly int HeightForWidth = Interop.ActorProperty.HeightForWidthGet();
            internal static readonly int MinimumSize = Interop.ActorProperty.MinimumSizeGet();
            internal static readonly int MaximumSize = Interop.ActorProperty.MaximumSizeGet();
            internal static readonly int InheritPosition = Interop.ActorProperty.InheritPositionGet();
            internal static readonly int ClippingMode = Interop.ActorProperty.ClippingModeGet();
            internal static readonly int InheritLayoutDirection = Interop.ActorProperty.InheritLayoutDirectionGet();
            internal static readonly int LayoutDirection = Interop.ActorProperty.LayoutDirectionGet();
            internal static readonly int MARGIN = Interop.ViewProperty.MarginGet();
            internal static readonly int PADDING = Interop.ViewProperty.PaddingGet();
            internal static readonly int SHADOW = Interop.ViewProperty.ShadowGet();
            internal static readonly int CaptureAllTouchAfterStart = Interop.ActorProperty.CaptureAllTouchAfterStartGet();
            internal static readonly int BlendEquation = Interop.ActorProperty.BlendEquationGet();
            internal static readonly int Culled = Interop.ActorProperty.CulledGet();
            internal static readonly int AccessibilityName = Interop.ViewProperty.AccessibilityNameGet();
            internal static readonly int AccessibilityDescription = Interop.ViewProperty.AccessibilityDescriptionGet();
            internal static readonly int AccessibilityTranslationDomain = Interop.ViewProperty.AccessibilityTranslationDomainGet();
            internal static readonly int AccessibilityRole = Interop.ViewProperty.AccessibilityRoleGet();
            internal static readonly int AccessibilityHighlightable = Interop.ViewProperty.AccessibilityHighlightableGet();
            internal static readonly int AccessibilityAttributes = Interop.ViewProperty.AccessibilityAttributesGet();
            internal static readonly int AccessibilityAnimated = Interop.ViewProperty.AccessibilityAnimatedGet();
        }
    }
}
