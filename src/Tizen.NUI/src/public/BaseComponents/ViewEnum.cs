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
            /// <summary>
            /// Property index to match native index.
            /// </summary>
            /// <remarks>
            /// When we need to add or remove property, native index should also be modified together.
            /// </remarks>
            private enum Index
            {
                TOOLTIPIndex = 0,
                STATEIndex,
                SubStateIndex,
                LeftFocusableViewIdIndex,
                RightFocusableViewIdIndex,
                UpFocusableViewIdIndex,
                DownFocusableViewIdIndex,
                ClockwiseFocusableViewIdIndex,
                CounterClockwiseFocusableViewIdIndex,
                StyleNameIndex,
                KeyInputFocusIndex,
                BACKGROUNDIndex,
                SiblingOrderIndex,
                OPACITYIndex,
                ScreenPositionIndex,
                PositionUsesAnchorPointIndex,
                ParentOriginIndex,
                ParentOriginXIndex,
                ParentOriginYIndex,
                ParentOriginZIndex,
                AnchorPointIndex,
                AnchorPointXIndex,
                AnchorPointYIndex,
                AnchorPointZIndex,
                SIZEIndex,
                SizeWidthIndex,
                SizeHeightIndex,
                SizeDepthIndex,
                POSITIONIndex,
                PositionXIndex,
                PositionYIndex,
                PositionZIndex,
                WorldPositionIndex,
                WorldPositionXIndex,
                WorldPositionYIndex,
                WorldPositionZIndex,
                ORIENTATIONIndex,
                WorldOrientationIndex,
                SCALEIndex,
                ScaleXIndex,
                ScaleYIndex,
                ScaleZIndex,
                WorldScaleIndex,
                VISIBLEIndex,
                COLORIndex,
                ColorRedIndex,
                ColorGreenIndex,
                ColorBlueIndex,
                WorldColorIndex,
                WorldMatrixIndex,
                NAMEIndex,
                SENSITIVEIndex,
                UserInteractionEnabledIndex,
                LeaveRequiredIndex,
                InheritOrientationIndex,
                InheritScaleIndex,
                DrawModeIndex,
                SizeModeFactorIndex,
                WidthResizePolicyIndex,
                HeightResizePolicyIndex,
                SizeScalePolicyIndex,
                WidthForHeightIndex,
                HeightForWidthIndex,
                MinimumSizeIndex,
                MaximumSizeIndex,
                InheritPositionIndex,
                ClippingModeIndex,
                InheritLayoutDirectionIndex,
                LayoutDirectionIndex,
                MARGINIndex,
                PADDINGIndex,
                SHADOWIndex,
                CaptureAllTouchAfterStartIndex,
                AllowOnlyOwnTouchIndex,
                BlendEquationIndex,
                CulledIndex,
                AccessibilityNameIndex,
                AccessibilityDescriptionIndex,
                AccessibilityTranslationDomainIndex,
                AccessibilityRoleIndex,
                AccessibilityHighlightableIndex,
                AccessibilityAttributesIndex,
                DispatchKeyEventsIndex,
                AccessibilityHiddenIndex,
                AutomationIdIndex,
                UpdateAreaHintIndex,
                DispatchTouchMotionIndex,
                DispatchHoverMotionIndex,
            };

            internal static readonly int TOOLTIP = Interop.ViewProperty.GetIndex((int)Index.TOOLTIPIndex);
            internal static readonly int STATE = Interop.ViewProperty.GetIndex((int)Index.STATEIndex);
            internal static readonly int SubState = Interop.ViewProperty.GetIndex((int)Index.SubStateIndex);
            internal static readonly int LeftFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.LeftFocusableViewIdIndex);
            internal static readonly int RightFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.RightFocusableViewIdIndex);
            internal static readonly int UpFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.UpFocusableViewIdIndex);
            internal static readonly int DownFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.DownFocusableViewIdIndex);
            internal static readonly int ClockwiseFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.ClockwiseFocusableViewIdIndex);
            internal static readonly int CounterClockwiseFocusableViewId = Interop.ViewProperty.GetIndex((int)Index.CounterClockwiseFocusableViewIdIndex);
            internal static readonly int StyleName = Interop.ViewProperty.GetIndex((int)Index.StyleNameIndex);
            internal static readonly int KeyInputFocus = Interop.ViewProperty.GetIndex((int)Index.KeyInputFocusIndex);
            internal static readonly int BACKGROUND = Interop.ViewProperty.GetIndex((int)Index.BACKGROUNDIndex);
            internal static readonly int SiblingOrder = Interop.ViewProperty.GetIndex((int)Index.SiblingOrderIndex);
            internal static readonly int OPACITY = Interop.ViewProperty.GetIndex((int)Index.OPACITYIndex);
            internal static readonly int ScreenPosition = Interop.ViewProperty.GetIndex((int)Index.ScreenPositionIndex);
            internal static readonly int PositionUsesAnchorPoint = Interop.ViewProperty.GetIndex((int)Index.PositionUsesAnchorPointIndex);
            internal static readonly int ParentOrigin = Interop.ViewProperty.GetIndex((int)Index.ParentOriginIndex);
            internal static readonly int ParentOriginX = Interop.ViewProperty.GetIndex((int)Index.ParentOriginXIndex);
            internal static readonly int ParentOriginY = Interop.ViewProperty.GetIndex((int)Index.ParentOriginYIndex);
            internal static readonly int ParentOriginZ = Interop.ViewProperty.GetIndex((int)Index.ParentOriginZIndex);
            internal static readonly int AnchorPoint = Interop.ViewProperty.GetIndex((int)Index.AnchorPointIndex);
            internal static readonly int AnchorPointX = Interop.ViewProperty.GetIndex((int)Index.AnchorPointXIndex);
            internal static readonly int AnchorPointY = Interop.ViewProperty.GetIndex((int)Index.AnchorPointYIndex);
            internal static readonly int AnchorPointZ = Interop.ViewProperty.GetIndex((int)Index.AnchorPointZIndex);
            internal static readonly int SIZE = Interop.ViewProperty.GetIndex((int)Index.SIZEIndex);
            internal static readonly int SizeWidth = Interop.ViewProperty.GetIndex((int)Index.SizeWidthIndex);
            internal static readonly int SizeHeight = Interop.ViewProperty.GetIndex((int)Index.SizeHeightIndex);
            internal static readonly int SizeDepth = Interop.ViewProperty.GetIndex((int)Index.SizeDepthIndex);
            internal static readonly int POSITION = Interop.ViewProperty.GetIndex((int)Index.POSITIONIndex);
            internal static readonly int PositionX = Interop.ViewProperty.GetIndex((int)Index.PositionXIndex);
            internal static readonly int PositionY = Interop.ViewProperty.GetIndex((int)Index.PositionYIndex);
            internal static readonly int PositionZ = Interop.ViewProperty.GetIndex((int)Index.PositionZIndex);
            internal static readonly int WorldPosition = Interop.ViewProperty.GetIndex((int)Index.WorldPositionIndex);
            internal static readonly int WorldPositionX = Interop.ViewProperty.GetIndex((int)Index.WorldPositionXIndex);
            internal static readonly int WorldPositionY = Interop.ViewProperty.GetIndex((int)Index.WorldPositionYIndex);
            internal static readonly int WorldPositionZ = Interop.ViewProperty.GetIndex((int)Index.WorldPositionZIndex);
            internal static readonly int ORIENTATION = Interop.ViewProperty.GetIndex((int)Index.ORIENTATIONIndex);
            internal static readonly int WorldOrientation = Interop.ViewProperty.GetIndex((int)Index.WorldOrientationIndex);
            internal static readonly int SCALE = Interop.ViewProperty.GetIndex((int)Index.SCALEIndex);
            internal static readonly int ScaleX = Interop.ViewProperty.GetIndex((int)Index.ScaleXIndex);
            internal static readonly int ScaleY = Interop.ViewProperty.GetIndex((int)Index.ScaleYIndex);
            internal static readonly int ScaleZ = Interop.ViewProperty.GetIndex((int)Index.ScaleZIndex);
            internal static readonly int WorldScale = Interop.ViewProperty.GetIndex((int)Index.WorldScaleIndex);
            internal static readonly int VISIBLE = Interop.ViewProperty.GetIndex((int)Index.VISIBLEIndex);
            internal static readonly int COLOR = Interop.ViewProperty.GetIndex((int)Index.COLORIndex);
            internal static readonly int ColorRed = Interop.ViewProperty.GetIndex((int)Index.ColorRedIndex);
            internal static readonly int ColorGreen = Interop.ViewProperty.GetIndex((int)Index.ColorGreenIndex);
            internal static readonly int ColorBlue = Interop.ViewProperty.GetIndex((int)Index.ColorBlueIndex);
            internal static readonly int WorldColor = Interop.ViewProperty.GetIndex((int)Index.WorldColorIndex);
            internal static readonly int WorldMatrix = Interop.ViewProperty.GetIndex((int)Index.WorldMatrixIndex);
            internal static readonly int NAME = Interop.ViewProperty.GetIndex((int)Index.NAMEIndex);
            internal static readonly int SENSITIVE = Interop.ViewProperty.GetIndex((int)Index.SENSITIVEIndex);
            internal static readonly int UserInteractionEnabled = Interop.ViewProperty.GetIndex((int)Index.UserInteractionEnabledIndex);
            internal static readonly int LeaveRequired = Interop.ViewProperty.GetIndex((int)Index.LeaveRequiredIndex);
            internal static readonly int InheritOrientation = Interop.ViewProperty.GetIndex((int)Index.InheritOrientationIndex);
            internal static readonly int InheritScale = Interop.ViewProperty.GetIndex((int)Index.InheritScaleIndex);
            internal static readonly int DrawMode = Interop.ViewProperty.GetIndex((int)Index.DrawModeIndex);
            internal static readonly int SizeModeFactor = Interop.ViewProperty.GetIndex((int)Index.SizeModeFactorIndex);
            internal static readonly int WidthResizePolicy = Interop.ViewProperty.GetIndex((int)Index.WidthResizePolicyIndex);
            internal static readonly int HeightResizePolicy = Interop.ViewProperty.GetIndex((int)Index.HeightResizePolicyIndex);
            internal static readonly int SizeScalePolicy = Interop.ViewProperty.GetIndex((int)Index.SizeScalePolicyIndex);
            internal static readonly int WidthForHeight = Interop.ViewProperty.GetIndex((int)Index.WidthForHeightIndex);
            internal static readonly int HeightForWidth = Interop.ViewProperty.GetIndex((int)Index.HeightForWidthIndex);
            internal static readonly int MinimumSize = Interop.ViewProperty.GetIndex((int)Index.MinimumSizeIndex);
            internal static readonly int MaximumSize = Interop.ViewProperty.GetIndex((int)Index.MaximumSizeIndex);
            internal static readonly int InheritPosition = Interop.ViewProperty.GetIndex((int)Index.InheritPositionIndex);
            internal static readonly int ClippingMode = Interop.ViewProperty.GetIndex((int)Index.ClippingModeIndex);
            internal static readonly int InheritLayoutDirection = Interop.ViewProperty.GetIndex((int)Index.InheritLayoutDirectionIndex);
            internal static readonly int LayoutDirection = Interop.ViewProperty.GetIndex((int)Index.LayoutDirectionIndex);
            internal static readonly int MARGIN = Interop.ViewProperty.GetIndex((int)Index.MARGINIndex);
            internal static readonly int PADDING = Interop.ViewProperty.GetIndex((int)Index.PADDINGIndex);
            internal static readonly int SHADOW = Interop.ViewProperty.GetIndex((int)Index.SHADOWIndex);
            internal static readonly int CaptureAllTouchAfterStart = Interop.ViewProperty.GetIndex((int)Index.CaptureAllTouchAfterStartIndex);
            internal static readonly int AllowOnlyOwnTouch = Interop.ViewProperty.GetIndex((int)Index.AllowOnlyOwnTouchIndex);
            internal static readonly int BlendEquation = Interop.ViewProperty.GetIndex((int)Index.BlendEquationIndex);
            internal static readonly int Culled = Interop.ViewProperty.GetIndex((int)Index.CulledIndex);
            internal static readonly int AccessibilityName = Interop.ViewProperty.GetIndex((int)Index.AccessibilityNameIndex);
            internal static readonly int AccessibilityDescription = Interop.ViewProperty.GetIndex((int)Index.AccessibilityDescriptionIndex);
            internal static readonly int AccessibilityTranslationDomain = Interop.ViewProperty.GetIndex((int)Index.AccessibilityTranslationDomainIndex);
            internal static readonly int AccessibilityRole = Interop.ViewProperty.GetIndex((int)Index.AccessibilityRoleIndex);
            internal static readonly int AccessibilityHighlightable = Interop.ViewProperty.GetIndex((int)Index.AccessibilityHighlightableIndex);
            internal static readonly int AccessibilityAttributes = Interop.ViewProperty.GetIndex((int)Index.AccessibilityAttributesIndex);
            internal static readonly int DispatchKeyEvents = Interop.ViewProperty.GetIndex((int)Index.DispatchKeyEventsIndex);
            internal static readonly int AccessibilityHidden = Interop.ViewProperty.GetIndex((int)Index.AccessibilityHiddenIndex);
            internal static readonly int AutomationId = Interop.ViewProperty.GetIndex((int)Index.AutomationIdIndex);
            internal static readonly int UpdateAreaHint = Interop.ViewProperty.GetIndex((int)Index.UpdateAreaHintIndex);
            internal static readonly int DispatchTouchMotion = Interop.ViewProperty.GetIndex((int)Index.DispatchTouchMotionIndex);
            internal static readonly int DispatchHoverMotion = Interop.ViewProperty.GetIndex((int)Index.DispatchHoverMotionIndex);
        }
    }
}
