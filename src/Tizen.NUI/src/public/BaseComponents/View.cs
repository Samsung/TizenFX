/*
 * Copyright(c) 2017-2025 Samsung Electronics Co., Ltd.
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View : Container, IResourcesProvider
    {
        private static HashSet<BindableProperty> positionPropertyGroup = new HashSet<BindableProperty>();
        private static HashSet<BindableProperty> sizePropertyGroup = new HashSet<BindableProperty>();
        private static HashSet<BindableProperty> scalePropertyGroup = new HashSet<BindableProperty>();
        private static bool defaultGrabTouchAfterLeave = false;
        private static bool defaultAllowOnlyOwnTouch = false;

        internal BackgroundExtraData backgroundExtraData;
        private int widthPolicy = LayoutParamPolicies.WrapContent;
        private int heightPolicy = LayoutParamPolicies.WrapContent;
        private LayoutExtraData layoutExtraData;
        private ThemeData themeData;
        private Dictionary<Type, object> attached;
        private bool isThemeChanged = false;

        // Collection of image-sensitive properties, and need to update C# side cache value.
        private static readonly List<int> cachedNUIViewBackgroundImagePropertyKeyList = new List<int> {
            ImageVisualProperty.URL,
            ImageVisualProperty.SynchronousLoading,
        };
        private string backgroundImageUrl = null;
        private bool backgroundImageSynchronousLoading = false;

        // List of constraints
        private Constraint widthConstraint = null;
        private Constraint heightConstraint = null;

        private Size2D internalMaximumSize = null;
        private Size2D internalMinimumSize = null;
        private Extents internalMargin = null;
        private Extents internalPadding = null;
        private Vector3 internalSizeModeFactor = null;
        private Vector2 internalCellIndex = null;
        private Color internalBackgroundColor = null;
        private Color internalColor = null;
        private Position internalPivotPoint = null;
        private Position internalPosition = null;
        private Position2D internalPosition2D = null;
        private Vector3 internalScale = null;
        private Size internalSize = null;
        private Size2D internalSize2D = null;
        private int layoutCount = 0;
        private ControlState propagatableControlStates = ControlState.All;

        private string internalName = string.Empty;
        private Position internalCurrentParentOrigin = null;
        private Position internalCurrentAnchorPoint = null;
        private Vector3 internalTargetSize = null;
        private Size2D internalCurrentSize = null;
        private Position internalCurrentPosition = null;
        private Vector3 internalCurrentWorldPosition = null;
        private Vector3 internalCurrentScale = null;
        private Vector3 internalCurrentWorldScale = null;
        private Vector4 internalCurrentColor = null;
        private Vector4 internalCurrentWorldColor = null;
        private Vector2 internalCurrentScreenPosition = null;

        private static int aliveCount = 0;

        static View()
        {
            if (NUIApplication.IsUsingXaml)
            {
                StyleNameProperty = BindableProperty.Create(nameof(StyleName), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalStyleNameProperty, defaultValueCreator: GetInternalStyleNameProperty);

                KeyInputFocusProperty = BindableProperty.Create(nameof(KeyInputFocus), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalKeyInputFocusProperty, defaultValueCreator: GetInternalKeyInputFocusProperty);

                BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(View), null,
                    propertyChanged: SetInternalBackgroundColorProperty, defaultValueCreator: GetInternalBackgroundColorProperty);

                ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(View), null,
                    propertyChanged: SetInternalColorProperty, defaultValueCreator: GetInternalColorProperty);

                ColorRedProperty = BindableProperty.Create(nameof(ColorRed), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorRedProperty, defaultValueCreator: GetInternalColorRedProperty);

                ColorGreenProperty = BindableProperty.Create(nameof(ColorGreen), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorGreenProperty, defaultValueCreator: GetInternalColorGreenProperty);

                ColorBlueProperty = BindableProperty.Create(nameof(ColorBlue), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorBlueProperty, defaultValueCreator: GetInternalColorBlueProperty);

                BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(string), typeof(View), default(string),
                    propertyChanged: SetInternalBackgroundImageProperty, defaultValueCreator: GetInternalBackgroundImageProperty);

                BackgroundImageBorderProperty = BindableProperty.Create(nameof(BackgroundImageBorder), typeof(Rectangle), typeof(View), default(Rectangle),
                    propertyChanged: SetInternalBackgroundImageBorderProperty, defaultValueCreator: GetInternalBackgroundImageBorderProperty);

                BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(PropertyMap), typeof(View), null,
                    propertyChanged: SetInternalBackgroundProperty, defaultValueCreator: GetInternalBackgroundProperty);

                StateProperty = BindableProperty.Create(nameof(State), typeof(States), typeof(View), States.Normal,
                    propertyChanged: SetInternalStateProperty, defaultValueCreator: GetInternalStateProperty);

                SubStateProperty = BindableProperty.Create(nameof(SubState), typeof(States), typeof(View), States.Normal,
                    propertyChanged: SetInternalSubStateProperty, defaultValueCreator: GetInternalSubStateProperty);

                TooltipProperty = BindableProperty.Create(nameof(Tooltip), typeof(PropertyMap), typeof(View), null,
                    propertyChanged: SetInternalTooltipProperty, defaultValueCreator: GetInternalTooltipProperty);

                FlexProperty = BindableProperty.Create(nameof(Flex), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalFlexProperty, defaultValueCreator: GetInternalFlexProperty);

                AlignSelfProperty = BindableProperty.Create(nameof(AlignSelf), typeof(int), typeof(View), default(int),
                    propertyChanged: SetInternalAlignSelfProperty, defaultValueCreator: GetInternalAlignSelfProperty);

                FlexMarginProperty = BindableProperty.Create(nameof(FlexMargin), typeof(Vector4), typeof(View), null,
                    propertyChanged: SetInternalFlexMarginProperty, defaultValueCreator: GetInternalFlexMarginProperty);

                CellIndexProperty = BindableProperty.Create(nameof(CellIndex), typeof(Vector2), typeof(View), null,
                    propertyChanged: SetInternalCellIndexProperty, defaultValueCreator: GetInternalCellIndexProperty);

                RowSpanProperty = BindableProperty.Create(nameof(RowSpan), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalRowSpanProperty, defaultValueCreator: GetInternalRowSpanProperty);

                ColumnSpanProperty = BindableProperty.Create(nameof(ColumnSpan), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColumnSpanProperty, defaultValueCreator: GetInternalColumnSpanProperty);

                CellHorizontalAlignmentProperty = BindableProperty.Create(nameof(CellHorizontalAlignment), typeof(HorizontalAlignmentType), typeof(View), HorizontalAlignmentType.Left,
                    propertyChanged: SetInternalCellHorizontalAlignmentProperty, defaultValueCreator: GetInternalCellHorizontalAlignmentProperty);

                CellVerticalAlignmentProperty = BindableProperty.Create(nameof(CellVerticalAlignment), typeof(VerticalAlignmentType), typeof(View), VerticalAlignmentType.Top,
                    propertyChanged: SetInternalCellVerticalAlignmentProperty, defaultValueCreator: GetInternalCellVerticalAlignmentProperty);

                WeightProperty = BindableProperty.Create(nameof(Weight), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalWeightProperty, defaultValueCreator: GetInternalWeightProperty);

                LeftFocusableViewProperty = BindableProperty.Create(nameof(View.LeftFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalLeftFocusableViewProperty, defaultValueCreator: GetInternalLeftFocusableViewProperty);

                RightFocusableViewProperty = BindableProperty.Create(nameof(View.RightFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalRightFocusableViewProperty, defaultValueCreator: GetInternalRightFocusableViewProperty);

                UpFocusableViewProperty = BindableProperty.Create(nameof(View.UpFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalUpFocusableViewProperty, defaultValueCreator: GetInternalUpFocusableViewProperty);

                DownFocusableViewProperty = BindableProperty.Create(nameof(View.DownFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalDownFocusableViewProperty, defaultValueCreator: GetInternalDownFocusableViewProperty);

                ClockwiseFocusableViewProperty = BindableProperty.Create(nameof(View.ClockwiseFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalClockwiseFocusableViewProperty, defaultValueCreator: GetInternalClockwiseFocusableViewProperty);

                CounterClockwiseFocusableViewProperty = BindableProperty.Create(nameof(View.CounterClockwiseFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalCounterClockwiseFocusableViewProperty, defaultValueCreator: GetInternalCounterClockwiseFocusableViewProperty);

                FocusableProperty = BindableProperty.Create(nameof(Focusable), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalFocusableProperty, defaultValueCreator: GetInternalFocusableProperty);

                FocusableChildrenProperty = BindableProperty.Create(nameof(FocusableChildren), typeof(bool), typeof(View), true,
                    propertyChanged: SetInternalFocusableChildrenProperty, defaultValueCreator: GetInternalFocusableChildrenProperty);

                FocusableInTouchProperty = BindableProperty.Create(nameof(FocusableInTouch), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalFocusableInTouchProperty, defaultValueCreator: GetInternalFocusableInTouchProperty);

                Size2DProperty = BindableProperty.Create(nameof(Size2D), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalSize2DProperty, defaultValueCreator: GetInternalSize2DProperty);

                OpacityProperty = BindableProperty.Create(nameof(Opacity), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalOpacityProperty, defaultValueCreator: GetInternalOpacityProperty);

                Position2DProperty = BindableProperty.Create(nameof(Position2D), typeof(Position2D), typeof(View), null,
                    propertyChanged: SetInternalPosition2DProperty, defaultValueCreator: GetInternalPosition2DProperty);

                PositionUsesPivotPointProperty = BindableProperty.Create(nameof(PositionUsesPivotPoint), typeof(bool), typeof(View), true,
                    propertyChanged: SetInternalPositionUsesPivotPointProperty, defaultValueCreator: GetInternalPositionUsesPivotPointProperty);

                SiblingOrderProperty = BindableProperty.Create(nameof(SiblingOrder), typeof(int), typeof(View), default(int),
                    propertyChanged: SetInternalSiblingOrderProperty, defaultValueCreator: GetInternalSiblingOrderProperty);

                ParentOriginProperty = BindableProperty.Create(nameof(ParentOrigin), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalParentOriginProperty, defaultValueCreator: GetInternalParentOriginProperty);

                PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalPivotPointProperty, defaultValueCreator: GetInternalPivotPointProperty);

                SizeWidthProperty = BindableProperty.Create(nameof(SizeWidth), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalSizeWidthProperty, defaultValueCreator: GetInternalSizeWidthProperty);

                SizeHeightProperty = BindableProperty.Create(nameof(SizeHeight), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalSizeHeightProperty, defaultValueCreator: GetInternalSizeHeightProperty);

                PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalPositionProperty, defaultValueCreator: GetInternalPositionProperty);

                PositionXProperty = BindableProperty.Create(nameof(PositionX), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalPositionXProperty, defaultValueCreator: GetInternalPositionXProperty);

                PositionYProperty = BindableProperty.Create(nameof(PositionY), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalPositionYProperty, defaultValueCreator: GetInternalPositionYProperty);

                PositionZProperty = BindableProperty.Create(nameof(PositionZ), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalPositionZProperty, defaultValueCreator: GetInternalPositionZProperty);

                OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(Rotation), typeof(View), null,
                    propertyChanged: SetInternalOrientationProperty, defaultValueCreator: GetInternalOrientationProperty);

                ScaleProperty = BindableProperty.Create(nameof(Scale), typeof(Vector3), typeof(View), null,
                    propertyChanged: SetInternalScaleProperty, defaultValueCreator: GetInternalScaleProperty);

                ScaleXProperty = BindableProperty.Create(nameof(ScaleX), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleXProperty, defaultValueCreator: GetInternalScaleXProperty);

                ScaleYProperty = BindableProperty.Create(nameof(ScaleY), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleYProperty, defaultValueCreator: GetInternalScaleYProperty);

                ScaleZProperty = BindableProperty.Create(nameof(ScaleZ), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleZProperty, defaultValueCreator: GetInternalScaleZProperty);

                NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalNameProperty, defaultValueCreator: GetInternalNameProperty);

                SensitiveProperty = BindableProperty.Create(nameof(Sensitive), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalSensitiveProperty, defaultValueCreator: GetInternalSensitiveProperty);

                IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalIsEnabledProperty, defaultValueCreator: GetInternalIsEnabledProperty);

                DispatchKeyEventsProperty = BindableProperty.Create(nameof(DispatchKeyEvents), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalDispatchKeyEventsProperty, defaultValueCreator: GetInternalDispatchKeyEventsProperty);

                LeaveRequiredProperty = BindableProperty.Create(nameof(LeaveRequired), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalLeaveRequiredProperty, defaultValueCreator: GetInternalLeaveRequiredProperty);

                InheritOrientationProperty = BindableProperty.Create(nameof(InheritOrientation), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalInheritOrientationProperty, defaultValueCreator: GetInternalInheritOrientationProperty);

                InheritScaleProperty = BindableProperty.Create(nameof(InheritScale), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalInheritScaleProperty, defaultValueCreator: GetInternalInheritScaleProperty);

                DrawModeProperty = BindableProperty.Create(nameof(DrawMode), typeof(DrawModeType), typeof(View), DrawModeType.Normal,
                    propertyChanged: SetInternalDrawModeProperty, defaultValueCreator: GetInternalDrawModeProperty);

                SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(View), null,
                    propertyChanged: SetInternalSizeModeFactorProperty, defaultValueCreator: GetInternalSizeModeFactorProperty);

                WidthResizePolicyProperty = BindableProperty.Create(nameof(WidthResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed,
                    propertyChanged: SetInternalWidthResizePolicyProperty, defaultValueCreator: GetInternalWidthResizePolicyProperty);

                HeightResizePolicyProperty = BindableProperty.Create(nameof(HeightResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed,
                    propertyChanged: SetInternalHeightResizePolicyProperty, defaultValueCreator: GetInternalHeightResizePolicyProperty);

                SizeScalePolicyProperty = BindableProperty.Create(nameof(SizeScalePolicy), typeof(SizeScalePolicyType), typeof(View), SizeScalePolicyType.UseSizeSet,
                    propertyChanged: SetInternalSizeScalePolicyProperty, defaultValueCreator: GetInternalSizeScalePolicyProperty);

                WidthForHeightProperty = BindableProperty.Create(nameof(WidthForHeight), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalWidthForHeightProperty, defaultValueCreator: GetInternalWidthForHeightProperty);

                HeightForWidthProperty = BindableProperty.Create(nameof(HeightForWidth), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalHeightForWidthProperty, defaultValueCreator: GetInternalHeightForWidthProperty);

                PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(View), null,
                    propertyChanged: SetInternalPaddingProperty, defaultValueCreator: GetInternalPaddingProperty);

                SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(View), null,
                    propertyChanged: SetInternalSizeProperty, defaultValueCreator: GetInternalSizeProperty);

                MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalMinimumSizeProperty, defaultValueCreator: GetInternalMinimumSizeProperty);

                MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalMaximumSizeProperty, defaultValueCreator: GetInternalMaximumSizeProperty);

                InheritPositionProperty = BindableProperty.Create(nameof(InheritPosition), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalInheritPositionProperty, defaultValueCreator: GetInternalInheritPositionProperty);

                ClippingModeProperty = BindableProperty.Create(nameof(ClippingMode), typeof(ClippingModeType), typeof(View), ClippingModeType.Disabled,
                    propertyChanged: SetInternalClippingModeProperty, defaultValueCreator: GetInternalClippingModeProperty);

                InheritLayoutDirectionProperty = BindableProperty.Create(nameof(InheritLayoutDirection), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalInheritLayoutDirectionProperty, defaultValueCreator: GetInternalInheritLayoutDirectionProperty);

                LayoutDirectionProperty = BindableProperty.Create(nameof(LayoutDirection), typeof(ViewLayoutDirectionType), typeof(View), ViewLayoutDirectionType.LTR,
                    propertyChanged: SetInternalLayoutDirectionProperty, defaultValueCreator: GetInternalLayoutDirectionProperty);

                MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(View), null,
                    propertyChanged: SetInternalMarginProperty, defaultValueCreator: GetInternalMarginProperty);

                UpdateAreaHintProperty = BindableProperty.Create(nameof(UpdateAreaHint), typeof(Vector4), typeof(View), null,
                    propertyChanged: SetInternalUpdateAreaHintProperty, defaultValueCreator: GetInternalUpdateAreaHintProperty);

                ImageShadowProperty = BindableProperty.Create(nameof(ImageShadow), typeof(ImageShadow), typeof(View), null,
                    propertyChanged: SetInternalImageShadowProperty, defaultValueCreator: GetInternalImageShadowProperty);

                BoxShadowProperty = BindableProperty.Create(nameof(BoxShadow), typeof(Shadow), typeof(View), null,
                    propertyChanged: SetInternalBoxShadowProperty, defaultValueCreator: GetInternalBoxShadowProperty);

                CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(Vector4), typeof(View), null,
                    propertyChanged: SetInternalCornerRadiusProperty, defaultValueCreator: GetInternalCornerRadiusProperty);

                CornerRadiusPolicyProperty = BindableProperty.Create(nameof(CornerRadiusPolicy), typeof(VisualTransformPolicyType), typeof(View), VisualTransformPolicyType.Absolute,
                    propertyChanged: SetInternalCornerRadiusPolicyProperty, defaultValueCreator: GetInternalCornerRadiusPolicyProperty);

                BorderlineWidthProperty = BindableProperty.Create(nameof(BorderlineWidth), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalBorderlineWidthProperty, defaultValueCreator: GetInternalBorderlineWidthProperty);

                BorderlineColorProperty = BindableProperty.Create(nameof(BorderlineColor), typeof(Color), typeof(View), null,
                    propertyChanged: SetInternalBorderlineColorProperty, defaultValueCreator: GetInternalBorderlineColorProperty);

                BorderlineColorSelectorProperty = BindableProperty.Create(nameof(BorderlineColorSelector), typeof(Selector<Color>), typeof(View), null,
                    propertyChanged: SetInternalBorderlineColorSelectorProperty, defaultValueCreator: GetInternalBorderlineColorSelectorProperty);

                BorderlineOffsetProperty = BindableProperty.Create(nameof(BorderlineOffset), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalBorderlineOffsetProperty, defaultValueCreator: GetInternalBorderlineOffsetProperty);

                EnableControlStateProperty = BindableProperty.Create(nameof(EnableControlState), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalEnableControlStateProperty, defaultValueCreator: GetInternalEnableControlStateProperty);

                ThemeChangeSensitiveProperty = BindableProperty.Create(nameof(ThemeChangeSensitive), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalThemeChangeSensitiveProperty, defaultValueCreator: GetInternalThemeChangeSensitiveProperty);

                AccessibilityNameProperty = BindableProperty.Create(nameof(AccessibilityName), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalAccessibilityNameProperty, defaultValueCreator: GetInternalAccessibilityNameProperty);

                AccessibilityDescriptionProperty = BindableProperty.Create(nameof(AccessibilityDescription), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalAccessibilityDescriptionProperty, defaultValueCreator: GetInternalAccessibilityDescriptionProperty);

                AccessibilityTranslationDomainProperty = BindableProperty.Create(nameof(AccessibilityTranslationDomain), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalAccessibilityTranslationDomainProperty, defaultValueCreator: GetInternalAccessibilityTranslationDomainProperty);

                AccessibilityRoleProperty = BindableProperty.Create(nameof(AccessibilityRole), typeof(Role), typeof(View), default(Role),
                    propertyChanged: SetInternalAccessibilityRoleProperty, defaultValueCreator: GetInternalAccessibilityRoleProperty);

                AccessibilityHighlightableProperty = BindableProperty.Create(nameof(AccessibilityHighlightable), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalAccessibilityHighlightableProperty, defaultValueCreator: GetInternalAccessibilityHighlightableProperty);

                AccessibilityHiddenProperty = BindableProperty.Create(nameof(AccessibilityHidden), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalAccessibilityHiddenProperty, defaultValueCreator: GetInternalAccessibilityHiddenProperty);

                ExcludeLayoutingProperty = BindableProperty.Create(nameof(ExcludeLayouting), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalExcludeLayoutingProperty, defaultValueCreator: GetInternalExcludeLayoutingProperty);

                TooltipTextProperty = BindableProperty.Create(nameof(TooltipText), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalTooltipTextProperty, defaultValueCreator: GetInternalTooltipTextProperty);

                PositionUsesAnchorPointProperty = BindableProperty.Create(nameof(PositionUsesAnchorPoint), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalPositionUsesAnchorPointProperty, defaultValueCreator: GetInternalPositionUsesAnchorPointProperty);

                AnchorPointProperty = BindableProperty.Create(nameof(AnchorPoint), typeof(Tizen.NUI.Position), typeof(View), null,
                    propertyChanged: SetInternalAnchorPointProperty, defaultValueCreator: GetInternalAnchorPointProperty);

                WidthSpecificationProperty = BindableProperty.Create(nameof(WidthSpecification), typeof(int), typeof(View), 0,
                    propertyChanged: SetInternalWidthSpecificationProperty, defaultValueCreator: GetInternalWidthSpecificationProperty);

                HeightSpecificationProperty = BindableProperty.Create(nameof(HeightSpecification), typeof(int), typeof(View), 0,
                    propertyChanged: SetInternalHeightSpecificationProperty, defaultValueCreator: GetInternalHeightSpecificationProperty);

                LayoutTransitionProperty = BindableProperty.Create(nameof(LayoutTransition), typeof(Tizen.NUI.LayoutTransition), typeof(View), null,
                    propertyChanged: SetInternalLayoutTransitionProperty, defaultValueCreator: GetInternalLayoutTransitionProperty);

                PaddingEXProperty = BindableProperty.Create(nameof(PaddingEX), typeof(Tizen.NUI.Extents), typeof(View), null,
                    propertyChanged: SetInternalPaddingEXProperty, defaultValueCreator: GetInternalPaddingEXProperty);

                LayoutProperty = BindableProperty.Create(nameof(Layout), typeof(Tizen.NUI.LayoutItem), typeof(View), null,
                    propertyChanged: SetInternalLayoutProperty, defaultValueCreator: GetInternalLayoutProperty);

                BackgroundImageSynchronosLoadingProperty = BindableProperty.Create(nameof(BackgroundImageSynchronosLoading), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalBackgroundImageSynchronosLoadingProperty, defaultValueCreator: GetInternalBackgroundImageSynchronosLoadingProperty);

                BackgroundImageSynchronousLoadingProperty = BindableProperty.Create(nameof(BackgroundImageSynchronousLoading), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalBackgroundImageSynchronousLoadingProperty, defaultValueCreator: GetInternalBackgroundImageSynchronousLoadingProperty);

                EnableControlStatePropagationProperty = BindableProperty.Create(nameof(EnableControlStatePropagation), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalEnableControlStatePropagationProperty, defaultValueCreator: GetInternalEnableControlStatePropagationProperty);

                PropagatableControlStatesProperty = BindableProperty.Create(nameof(PropagatableControlStates), typeof(ControlState), typeof(View), ControlState.All,
                    propertyChanged: SetInternalPropagatableControlStatesProperty, defaultValueCreator: GetInternalPropagatableControlStatesProperty);

                GrabTouchAfterLeaveProperty = BindableProperty.Create(nameof(GrabTouchAfterLeave), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalGrabTouchAfterLeaveProperty, defaultValueCreator: GetInternalGrabTouchAfterLeaveProperty);

                AllowOnlyOwnTouchProperty = BindableProperty.Create(nameof(AllowOnlyOwnTouch), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalAllowOnlyOwnTouchProperty, defaultValueCreator: GetInternalAllowOnlyOwnTouchProperty);

                BlendEquationProperty = BindableProperty.Create(nameof(BlendEquation), typeof(BlendEquationType), typeof(View), default(BlendEquationType),
                    propertyChanged: SetInternalBlendEquationProperty, defaultValueCreator: GetInternalBlendEquationProperty);

                TransitionOptionsProperty = BindableProperty.Create(nameof(TransitionOptions), typeof(TransitionOptions), typeof(View), default(TransitionOptions),
                    propertyChanged: SetInternalTransitionOptionsProperty, defaultValueCreator: GetInternalTransitionOptionsProperty);

                AutomationIdProperty = BindableProperty.Create(nameof(AutomationId), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalAutomationIdProperty, defaultValueCreator: GetInternalAutomationIdProperty);

                TouchAreaOffsetProperty = BindableProperty.Create(nameof(TouchAreaOffset), typeof(Offset), typeof(View), default(Offset),
                    propertyChanged: SetInternalTouchAreaOffsetProperty, defaultValueCreator: GetInternalTouchAreaOffsetProperty);

                DispatchTouchMotionProperty = BindableProperty.Create(nameof(DispatchTouchMotion), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalDispatchTouchMotionProperty, defaultValueCreator: GetInternalDispatchTouchMotionProperty);

                DispatchHoverMotionProperty = BindableProperty.Create(nameof(DispatchHoverMotion), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalDispatchHoverMotionProperty, defaultValueCreator: GetInternalDispatchHoverMotionProperty);

                RegisterPropertyGroup(PositionProperty, positionPropertyGroup);
                RegisterPropertyGroup(Position2DProperty, positionPropertyGroup);
                RegisterPropertyGroup(PositionXProperty, positionPropertyGroup);
                RegisterPropertyGroup(PositionYProperty, positionPropertyGroup);

                RegisterPropertyGroup(SizeProperty, sizePropertyGroup);
                RegisterPropertyGroup(Size2DProperty, sizePropertyGroup);
                RegisterPropertyGroup(SizeWidthProperty, sizePropertyGroup);
                RegisterPropertyGroup(SizeHeightProperty, sizePropertyGroup);

                RegisterPropertyGroup(ScaleProperty, scalePropertyGroup);
                RegisterPropertyGroup(ScaleXProperty, scalePropertyGroup);
                RegisterPropertyGroup(ScaleYProperty, scalePropertyGroup);
                RegisterPropertyGroup(ScaleZProperty, scalePropertyGroup);
            }
            RegisterAccessibilityDelegate();
        }

        static internal new void Preload()
        {
            Container.Preload();
        }

        /// <summary>
        /// Accessibility mode for controlling View's Accessible implementation.
        /// It is only relevant when deriving custom controls from View directly,
        /// as classes derived from CustomView (or any of its subclasses) get the
        /// Custom mode by default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ViewAccessibilityMode
        {
            /// <summary>
            /// Default accessibility implementation. Overriding View.Accessibility...()
            /// virtual methods will have no effect.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Default,
            /// <summary>
            /// Custom accessibility implementation. Overriding View.Accessibility...()
            /// will be necessary to provide accessibility support for the View.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Custom,
        }

        /// <summary>
        /// ResizePolicy mode for controlling View's Relayout implementation.
        /// It will be used when we can ensure that current view
        /// will not use ResizePolicy and Relayout signal.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal enum ViewResizePolicyMode
        {
            /// <summary>
            /// Default implementation. Will consider ResizePolicy and Relayout implementations
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Default,
            /// <summary>
            /// Ignore ResizePolicy and relative functions.
            /// </summary>
            /// <remarks>
            /// It will be useful when we can assume that this View is...
            /// - Always be existed under Layout.
            /// - ResizePolicy don't need.
            /// - Relayout event not used.
            /// - Internal visuals and VisualObjects don't use FittingMode.
            /// - Text don't need.
            /// </remarks>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Ignore,
        }

        private static IntPtr NewWithAccessibilityModeAndResizePolicyMode(ViewAccessibilityMode accessibilityMode, ViewResizePolicyMode resizePolicyMode)
        {
            switch (accessibilityMode)
            {
                case ViewAccessibilityMode.Custom:
                {
                    switch (resizePolicyMode)
                    {
                        case ViewResizePolicyMode.Ignore:
                        {
                            return Interop.View.NewCustomWithBehaviour(1); // Special enum to ignore size negotiate.
                        }
                        case ViewResizePolicyMode.Default:
                        default:
                        {
                            return Interop.View.NewCustom();
                        }
                    }
                }
                case ViewAccessibilityMode.Default:
                default:
                {
                    switch (resizePolicyMode)
                    {
                        case ViewResizePolicyMode.Ignore:
                        {
                            return Interop.View.NewWithBehaviour(1); // Special enum to ignore size negotiate.
                        }
                        case ViewResizePolicyMode.Default:
                        default:
                        {
                            return Interop.View.New();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new instance of a view.
        /// The default constructor for the View class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View() : this(ViewAccessibilityMode.Default)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public View(ViewAccessibilityMode accessibilityMode) : this(accessibilityMode, ViewResizePolicyMode.Default)
        {
        }

        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View(ViewStyle viewStyle) : this(Interop.View.New(), true, viewStyle)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Create a new instance of a View with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View(bool shown) : this(Interop.View.New(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
            SetVisible(shown);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal View(ViewResizePolicyMode resizePolicyMode) : this(ViewAccessibilityMode.Default, resizePolicyMode)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal View(ViewAccessibilityMode accessibilityMode, ViewResizePolicyMode resizePolicyMode) : this(NewWithAccessibilityModeAndResizePolicyMode(accessibilityMode, resizePolicyMode), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn, ViewStyle viewStyle, bool shown = true) : this(cPtr, cMemoryOwn, shown)
        {
            InitializeStyle(viewStyle);
        }

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown = true) : this(cPtr, cMemoryOwn, shown, cMemoryOwn)
        {
        }

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            if (HasBody())
            {
                PositionUsesPivotPoint = false;
                GrabTouchAfterLeave = defaultGrabTouchAfterLeave;
                AllowOnlyOwnTouch = defaultAllowOnlyOwnTouch;
            }

            if (!shown)
            {
                SetVisible(false);
            }

            aliveCount++;
        }

        internal View(ViewImpl implementation, bool shown = true) : this(Interop.View.NewViewInternal(ViewImpl.getCPtr(implementation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (!shown)
            {
                SetVisible(false);
            }
        }

        /// <summary>
        /// The event that is triggered when the View's ControlState is changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ControlStateChangedEventArgs> ControlStateChangedEvent;

        internal event EventHandler<ControlStateChangedEventArgs> ControlStateChangeEventInternal;


        /// <summary>
        /// Flag to indicate if layout set explicitly via API call or View was automatically given a Layout.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LayoutSet => layoutExtraData?.LayoutSet ?? false;

        /// <summary>
        /// Flag to allow Layouting to be disabled for Views.
        /// Once a View has a Layout set then any children added to Views from then on will receive
        /// automatic Layouts.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool LayoutingDisabled { get; set; } = true;

        /// <summary>
        /// If set to true, the <see cref="GrabTouchAfterLeave"/> property value is set to true when all Views are created.
        /// </summary>
        /// <param name="enable">Sets value of GrabTouchAfterLeave property</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetDefaultGrabTouchAfterLeave(bool enable)
        {
            defaultGrabTouchAfterLeave = enable;
        }

        /// <summary>
        /// If set to true, the <see cref="AllowOnlyOwnTouch"/> property value is set to true when all Views are created.
        /// </summary>
        /// <param name="enable">Sets value of AllowOnlyOwnTouch property</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetDefaultAllowOnlyOwnTouch(bool enable)
        {
            defaultAllowOnlyOwnTouch = enable;
        }

        /// <summary>
        /// Deprecate. Do not use this.
        /// The style instance applied to this view.
        /// Note that do not modify the ViewStyle.
        /// Modifying ViewStyle will affect other views with same ViewStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ViewStyle ViewStyle
        {
            get
            {
                if (themeData == null) themeData = new ThemeData();

                if (themeData.viewStyle == null)
                {
                    ApplyStyle(CreateViewStyle());
                }
                return themeData.viewStyle;
            }
        }

        /// <summary>
        /// Get/Set the control state.
        /// Note that the ControlState only available for the classes derived from Control.
        /// If the classes that are not derived from Control (such as View, ImageView and TextLabel) want to use this system,
        /// please set <see cref="EnableControlState"/> to true.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when set null. </exception>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlState ControlState
        {
            get
            {
                return themeData == null ? ControlState.Normal : themeData.controlStates;
            }
            protected set
            {
                if (ControlState == value)
                {
                    return;
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "ControlState should not be null.");
                }

                var prevState = ControlState;

                if (themeData == null) themeData = new ThemeData();
                themeData.controlStates = value;

                var changeInfo = new ControlStateChangedEventArgs(prevState, value);

                ControlStateChangeEventInternal?.Invoke(this, changeInfo);

                if (themeData.ControlStatePropagation)
                {
                    foreach (View child in Children)
                    {
                        ControlState allowed = child.PropagatableControlStates;
                        if (allowed.Contains(ControlState.All))
                        {
                            child.ControlState = value;
                        }
                        else
                        {
                            ControlState newControlState = child.ControlState;

                            if (allowed.Contains(ControlState.Normal))
                            {
                                if (value.Contains(ControlState.Normal))
                                {
                                    newControlState += ControlState.Normal;
                                }
                                else
                                {
                                    newControlState -= ControlState.Normal;
                                }
                            }

                            if (allowed.Contains(ControlState.Disabled))
                            {
                                if (value.Contains(ControlState.Disabled))
                                {
                                    newControlState += ControlState.Disabled;
                                }
                                else
                                {
                                    newControlState -= ControlState.Disabled;
                                }
                            }

                            if (allowed.Contains(ControlState.Selected))
                            {
                                if (value.Contains(ControlState.Selected))
                                {
                                    newControlState += ControlState.Selected;
                                }
                                else
                                {
                                    newControlState -= ControlState.Selected;
                                }
                            }

                            if (allowed.Contains(ControlState.Pressed))
                            {
                                if (value.Contains(ControlState.Pressed))
                                {
                                    newControlState += ControlState.Pressed;
                                }
                                else
                                {
                                    newControlState -= ControlState.Pressed;
                                }
                            }

                            if (allowed.Contains(ControlState.Focused))
                            {
                                if (value.Contains(ControlState.Focused))
                                {
                                    newControlState += ControlState.Focused;
                                }
                                else
                                {
                                    newControlState -= ControlState.Focused;
                                }
                            }

                            if (allowed.Contains(ControlState.Other))
                            {
                                if (value.Contains(ControlState.Other))
                                {
                                    newControlState += ControlState.Other;
                                }
                                else
                                {
                                    newControlState -= ControlState.Other;
                                }
                            }

                            if (child.ControlState != newControlState)
                                child.ControlState = newControlState;
                        }
                    }
                }

                OnControlStateChanged(changeInfo);

                ControlStateChangedEvent?.Invoke(this, changeInfo);
            }
        }

        /// <summary>
        /// Gets / Sets the status of whether the view is excluded from its parent's layouting or not.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ExcludeLayouting
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(ExcludeLayoutingProperty);
                }
                else
                {
                    return GetInternalExcludeLayouting();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ExcludeLayoutingProperty, value);
                }
                else
                {
                    SetInternalExcludeLayouting(value);
                }
                NotifyPropertyChanged();
            }
        }

        private bool GetInternalExcludeLayouting()
        {
            return InternalExcludeLayouting;
        }

        private void SetInternalExcludeLayouting(bool excludeLayouting)
        {
            InternalExcludeLayouting = excludeLayouting;
        }

        private bool InternalExcludeLayouting
        {
            get => layoutExtraData?.ExcludeLayouting ?? false;
            set
            {
                EnsureLayoutExtraData().ExcludeLayouting = value;
                if (Layout != null && Layout.SetPositionByLayout == value)
                {
                    Layout.SetPositionByLayout = !value;
                    Layout.RequestLayout();
                }
            }
        }

        /// <summary>
        /// The StyleName, type string.
        /// The value indicates DALi style name defined in json theme file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string StyleName
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(StyleNameProperty);
                }
                else
                {
                    return GetInternalStyleName();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(StyleNameProperty, value);
                }
                else
                {
                    SetInternalStyleName(value);
                }
                NotifyPropertyChanged();
            }
        }

        private string GetInternalStyleName()
        {
            if (!string.IsNullOrEmpty(styleName))
                return styleName;

            return Object.InternalGetPropertyString(SwigCPtr, Property.StyleName);
        }

        private void SetInternalStyleName(string name)
        {
            string styleName = (string)name;
            Object.InternalSetPropertyString(SwigCPtr, Property.StyleName, styleName);
            this.styleName = styleName;
            if (string.IsNullOrEmpty(styleName))
                return;

            var style = ThemeManager.GetUpdateStyleWithoutClone(styleName);
            if (style == null)
                return;

            ApplyStyle(style);
            SetThemeApplied();
        }

        /// <summary>
        /// The KeyInputFocus, type bool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool KeyInputFocus
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(KeyInputFocusProperty);
                }
                else
                {
                    return GetInternalKeyInputFocus();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(KeyInputFocusProperty, value);
                }
                else
                {
                    SetInternalKeyInputFocus(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalKeyInputFocus(bool keyInputFocus)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.KeyInputFocus, keyInputFocus);
        }

        private bool GetInternalKeyInputFocus()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.KeyInputFocus);
        }

        /// <summary>
        /// The mutually exclusive with "backgroundImage" and "background" type Vector4.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The property cascade chaining set is not recommended.
        /// </para>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "BackgroundColor", new Color(r, g, b, a));
        /// </code>
        /// </para>
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.BackgroundColor = new Color(0.5f, 0.1f, 0, 1);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.BackgroundColor.R = 0.5f; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Color BackgroundColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(BackgroundColorProperty);
                }
                else
                {
                    return GetInternalBackgroundColor();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundColorProperty, value);
                }
                else
                {
                    SetInternalBackgroundColor(value);
                }
                NotifyPropertyChanged();
                NotifyBackgroundChanged();
            }
        }

        internal void SetInternalBackgroundColor(Selector<Color> selector)
        {
            themeData?.selectorData?.ClearBackground(this);
            if (selector.HasAll())
            {
                SetBackgroundColor(selector.All);
            }
            else
            {
                EnsureSelectorData().BackgroundColor = new TriggerableSelector<Color>(this, selector, SetBackgroundColor, true);
            }
        }

        private void SetInternalBackgroundColor(Color color)
        {
            themeData?.selectorData?.ClearBackground(this);
            SetBackgroundColor(color);
        }

        private Color GetInternalBackgroundColor()
        {
            if (internalBackgroundColor == null)
            {
                internalBackgroundColor = new Color(OnBackgroundColorChanged, 0, 0, 0, 0);
            }

            int visualType = (int)Visual.Type.Invalid;
            Object.InternalRetrievingVisualPropertyInt(SwigCPtr, Property.BACKGROUND, Visual.Property.Type, out visualType);

            if (visualType == (int)Visual.Type.Color)
            {
                Object.InternalRetrievingVisualPropertyVector4(SwigCPtr, Property.BACKGROUND, ColorVisualProperty.MixColor, Color.getCPtr(internalBackgroundColor));
            }
            return internalBackgroundColor;
        }

        /// <summary>
        /// The mutually exclusive with "backgroundColor" and "background" type Map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string BackgroundImage
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(BackgroundImageProperty);
                }
                else
                {
                    return GetInternalBackgroundImage();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundImageProperty, value);
                }
                else
                {
                    SetInternalBackgroundImage(value);
                }
                NotifyPropertyChanged();
                NotifyBackgroundChanged();
            }
        }

        internal void SetInternalBackgroundImage(Selector<string> selector)
        {
            if (themeData?.selectorData != null)
            {
                themeData.selectorData.BackgroundColor?.Reset(this);
                themeData.selectorData.BackgroundImage?.Reset(this);
            }

            if (selector.HasAll())
            {
                SetBackgroundImage(selector.All);
            }
            else
            {
                EnsureSelectorData().BackgroundImage = new TriggerableSelector<string>(this, selector, SetBackgroundImage, true);
            }
        }

        private void SetInternalBackgroundImage(string imageUrl)
        {
            if (themeData?.selectorData != null)
            {
                themeData.selectorData.BackgroundColor?.Reset(this);
                themeData.selectorData.BackgroundImage?.Reset(this);
            }
            SetBackgroundImage(imageUrl);
        }

        private string GetInternalBackgroundImage()
        {
            return backgroundImageUrl;
        }

        /// <summary>
        /// Get or set the border of background image.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle BackgroundImageBorder
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Rectangle)GetValue(BackgroundImageBorderProperty);
                }
                else
                {
                    return GetInternalBackgroundImageBorder();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundImageBorderProperty, value);
                }
                else
                {
                    SetInternalBackgroundImageBorder(value);
                }
                NotifyPropertyChanged();
            }
        }

        internal void SetInternalBackgroundImageBorder(Selector<Rectangle> selector)
        {
            themeData?.selectorData?.BackgroundImageBorder?.Reset(this);

            if (selector.HasAll())
            {
                SetBackgroundImageBorder(selector.All);
            }
            else
            {
                EnsureSelectorData().BackgroundImageBorder = new TriggerableSelector<Rectangle>(this, selector, SetBackgroundImageBorder, true);
            }
        }

        private void SetInternalBackgroundImageBorder(Rectangle border)
        {
            themeData?.selectorData?.BackgroundImageBorder?.Reset(this);
            SetBackgroundImageBorder(border);
        }

        private Rectangle GetInternalBackgroundImageBorder()
        {
            return backgroundExtraData?.BackgroundImageBorder;
        }

        /// <summary>
        /// Gets or sets the background of the view.
        /// This property value is the PropertyMap representing the background.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Background
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(BackgroundProperty);
                }
                else
                {
                    return GetInternalBackground();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundProperty, value);
                }
                else
                {
                    SetInternalBackground(value);
                }
                NotifyPropertyChanged();
                NotifyBackgroundChanged();
            }
        }

        private void SetInternalBackground(PropertyMap map)
        {
            if (map == null)
                return;

            // Background extra data is not valid anymore. We should ignore lazy UpdateBackgroundExtraData
            backgroundExtraData = null;
            backgroundExtraDataUpdatedFlag = BackgroundExtraDataUpdatedFlag.None;

            // Update backgroundImageUrl and backgroundImageSynchronousLoading from Map
            foreach (int key in cachedNUIViewBackgroundImagePropertyKeyList)
            {
                using PropertyValue propertyValue = map.Find(key);
                if (propertyValue != null)
                {
                    if (key == ImageVisualProperty.URL)
                    {
                        propertyValue.Get(out backgroundImageUrl);
                    }
                    else if (key == ImageVisualProperty.SynchronousLoading)
                    {
                        propertyValue.Get(out backgroundImageSynchronousLoading);
                    }
                }
            }

            using var mapValue = new PropertyValue(map);
            Object.SetProperty(SwigCPtr, Property.BACKGROUND, mapValue);
        }

        private PropertyMap GetInternalBackground()
        {
            // Sync as current properties
            UpdateBackgroundExtraData();

            PropertyMap tmp = new PropertyMap();
            var propertyValue = Object.GetProperty(SwigCPtr, Property.BACKGROUND);
            propertyValue.Get(tmp);
            propertyValue.Dispose();
            propertyValue = null;
            return tmp;
        }

        /// <summary>
        /// Describes a shadow as an image for a View.
        /// It is null by default.
        /// </summary>
        /// <remarks>
        /// Getter returns copied instance of current shadow.
        /// </remarks>
        /// <remarks>
        /// The mutually exclusive with "BoxShadow".
        /// </remarks>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// To animate this property, specify a sub-property with separator ".", for example, "ImageShadow.Offset".
        /// <code>
        /// animation.AnimateTo(view, "ImageShadow.Offset", new Vector2(10, 10));
        /// </code>
        /// Animatable sub-property : Offset.
        /// </para>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow ImageShadow
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ImageShadow)GetValue(ImageShadowProperty);
                }
                else
                {
                    return GetInternalImageShadow();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ImageShadowProperty, value);
                }
                else
                {
                    SetInternalImageShadow(value);
                }
                NotifyPropertyChanged();
            }
        }

        internal void SetInternalImageShadow(Selector<ImageShadow> shadow)
        {
            themeData?.selectorData?.ClearShadow(this);
            if (shadow.HasAll())
            {
                SetShadow(shadow.All);
            }
            else
            {
                EnsureSelectorData().ImageShadow = new TriggerableSelector<ImageShadow>(this, shadow, SetShadow, true);
            }
        }

        private void SetInternalImageShadow(ImageShadow shadow)
        {
            themeData?.selectorData?.ClearShadow(this);
            SetShadow(shadow);
        }

        private ImageShadow GetInternalImageShadow()
        {
            // Sync as current properties
            UpdateBackgroundExtraData();

            using PropertyMap map = new PropertyMap();
            using var shadowProperty = Object.GetProperty(SwigCPtr, Property.SHADOW);
            shadowProperty.Get(map);

            var shadow = new ImageShadow(map);
            return shadow.IsEmpty() ? null : shadow;
        }

        /// <summary>
        /// Describes a box shaped shadow drawing for a View.
        /// It is null by default.
        /// </summary>
        /// <remarks>
        /// The mutually exclusive with "ImageShadow".
        /// </remarks>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// To animate this property, specify a sub-property with separator ".", for example, "BoxShadow.BlurRadius".
        /// <code>
        /// animation.AnimateTo(view, "BoxShadow.BlurRadius", 10.0f);
        /// </code>
        /// Animatable sub-property : Offset, Color, BlurRadius.
        /// </para>
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public Shadow BoxShadow
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Shadow)GetValue(BoxShadowProperty);
                }
                else
                {
                    return GetInternalBoxShadow();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BoxShadowProperty, value);
                }
                else
                {
                    SetInternalBoxShadow(value);
                }
                NotifyPropertyChanged();
            }
        }

        internal void SetInternalBoxShadow(Selector<Shadow> shadow)
        {
            themeData?.selectorData?.ClearShadow(this);
            if (shadow.HasAll())
            {
                SetShadow(shadow.All);
            }
            else
            {
                EnsureSelectorData().BoxShadow = new TriggerableSelector<Shadow>(this, shadow, SetShadow, true);
            }
        }

        private void SetInternalBoxShadow(Shadow shadow)
        {
            themeData?.selectorData?.ClearShadow(this);
            SetShadow(shadow);
        }

        private Shadow GetInternalBoxShadow()
        {
            // Sync as current properties
            UpdateBackgroundExtraData();

            using PropertyMap map = new PropertyMap();
            using var shadowProperty = Object.GetProperty(SwigCPtr, Property.SHADOW);
            shadowProperty.Get(map);
            var shadow = new Shadow(map);
            return shadow.IsEmpty() ? null : shadow;
        }

        /// <summary>
        /// The radius for the rounded corners of the View.
        /// This will rounds background and shadow edges.
        /// The values in Vector4 are used in clockwise order from top-left to bottom-left : Vector4(top-left-corner, top-right-corner, bottom-right-corner, bottom-left-corner).
        /// Each radius will clamp internally to the half of smaller of the view's width or height.
        /// Note that, an image background (or shadow) may not have rounded corners if it uses a Border property.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "CornerRadius", new Vector4(10, 10, 10, 10));
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public Vector4 CornerRadius
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(CornerRadiusProperty);
                }
                else
                {
                    return GetInternalCornerRadius();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CornerRadiusProperty, value);
                }
                else
                {
                    SetInternalCornerRadius(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCornerRadius(Vector4 newValue)
        {
            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).CornerRadius = newValue;
            UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.CornerRadius);
        }

        private Vector4 GetInternalCornerRadius()
        {
            return backgroundExtraData == null ? Vector4.Zero : backgroundExtraData.CornerRadius;
        }

        /// <summary>
        /// Whether the CornerRadius property value is relative (percentage [0.0f to 0.5f] of the view size) or absolute (in world units).
        /// It is absolute by default.
        /// When the policy is relative, the corner radius is relative to the smaller of the view's width and height.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public VisualTransformPolicyType CornerRadiusPolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VisualTransformPolicyType)GetValue(CornerRadiusPolicyProperty);
                }
                else
                {
                    return GetInternalCornerRadiusPolicy();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CornerRadiusPolicyProperty, value);
                }
                else
                {
                    SetInternalCornerRadiusPolicy(value);
                }
            }
        }

        private void SetInternalCornerRadiusPolicy(VisualTransformPolicyType value)
        {
            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).CornerRadiusPolicy = value;

            if (backgroundExtraData.CornerRadius != null)
            {
                UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.CornerRadius);
            }
        }

        private VisualTransformPolicyType GetInternalCornerRadiusPolicy()
        {
            return backgroundExtraData == null ? VisualTransformPolicyType.Absolute : backgroundExtraData.CornerRadiusPolicy;
        }

        /// <summary>
        /// The squareness for the rounded corners of the View.
        /// This will make squircle background and shadow edges.
        /// The values in Vector4 are used in clockwise order from top-left to bottom-left : Vector4(top-left-corner, top-right-corner, bottom-right-corner, bottom-left-corner).
        ///
        /// Each squareness will clamp internally to the [0.0f to 1.0f].
        /// If 0.0f, rounded corner applied.
        /// If 1.0f, View will be rendered like a square.
        /// </summary>
        /// <remarks>
        /// This property only be available when the CornerRadius property used. Otherwise, it will be ignored.
        /// </remarks>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "CornerSquareness", new Vector4(0.6f, 0.6f, 0.0f, 0.0f));
        /// </code>
        /// </para>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 CornerSquareness
        {
            get
            {
                return GetInternalCornerSqurenessProperty();
            }
            set
            {
                SetInternalCornerSqurenessProperty(value);
                NotifyPropertyChanged();
            }
        }
        internal void SetInternalCornerSqurenessProperty(Vector4 cornerSquareness)
        {
            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).CornerSquareness = cornerSquareness;
            UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.CornerRadius);
        }
        internal Vector4 GetInternalCornerSqurenessProperty()
        {
            return backgroundExtraData == null ? Vector4.Zero : backgroundExtraData.CornerSquareness;
        }

        /// <summary>
        /// The width for the borderline of the View.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "BorderlineWidth", 100.0f);
        /// </code>
        /// </para>
        /// Note that, an image background may not have borderline if it uses the Border property.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public float BorderlineWidth
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(BorderlineWidthProperty);
                }
                else
                {
                    return GetInternalBorderlineWidth();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderlineWidthProperty, value);
                }
                else
                {
                    SetInternalBorderlineWidth(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalBorderlineWidth(float borderlineWidth)
        {
            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).BorderlineWidth = borderlineWidth;
            UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.Borderline);
        }

        private float GetInternalBorderlineWidth()
        {
            return backgroundExtraData == null ? 0.0f : backgroundExtraData.BorderlineWidth;
        }

        /// <summary>
        /// The color for the borderline of the View.
        /// It is Color.Black by default.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "BorderlineColor", new Color(r, g, b, a));
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public Color BorderlineColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(BorderlineColorProperty);
                }
                else
                {
                    return GetInternalBorderlineColor();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderlineColorProperty, value);
                }
                else
                {
                    SetInternalBorderlineColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        internal void SetInternalBorderlineColor(Selector<Color> selector)
        {
            themeData?.selectorData?.BorderlineColor?.Reset(this);
            if (selector.HasAll())
            {
                SetBorderlineColor(selector.All);
            }
            else
            {
                EnsureSelectorData().BorderlineColor = new TriggerableSelector<Color>(this, selector, SetBorderlineColor, true);
            }
        }

        private void SetInternalBorderlineColor(Color color)
        {
            themeData?.selectorData?.BorderlineColor?.Reset(this);
            SetBorderlineColor(color);
        }

        private Color GetInternalBorderlineColor()
        {
            return backgroundExtraData == null ? Color.Black : backgroundExtraData.BorderlineColor;
        }

        /// <summary>
        /// The color selector for the borderline of the View.
        /// Like BackgroundColor, color selector typed BorderlineColor should be used in ViewStyle only.
        /// So this API is internally used only.
        /// </summary>
        internal Selector<Color> BorderlineColorSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<Color>)GetValue(BorderlineColorSelectorProperty);
                }
                else
                {
                    return GetInternalBorderlineColorSelector();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderlineColorSelectorProperty, value);
                }
                else
                {
                    SetInternalBorderlineColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private Selector<Color> GetInternalBorderlineColorSelector()
        {
            var selector = themeData?.selectorData?.BorderlineColor?.Get();
            return (null != selector) ? selector : new Selector<Color>();
        }

        /// <summary>
        /// The Relative offset for the borderline of the View.
        /// Recommended range : [-1.0f to 1.0f].
        /// If -1.0f, draw borderline inside of the View.
        /// If 1.0f, draw borderline outside of the View.
        /// If 0.0f, draw borderline half inside and half outside.
        /// It is 0.0f by default.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "BorderlineOffset", -1.0f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public float BorderlineOffset
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(BorderlineOffsetProperty);
                }
                else
                {
                    return GetInternalBorderlineOffset();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderlineOffsetProperty, value);
                }
                else
                {
                    SetInternalBorderlineOffset(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalBorderlineOffset(float borderlineOffset)
        {
            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).BorderlineOffset = borderlineOffset;
            UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.Borderline);
        }

        private float GetInternalBorderlineOffset()
        {
            return backgroundExtraData == null ? 0.0f : backgroundExtraData.BorderlineOffset;
        }

        /// <summary>
        /// Gets or sets the current state of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public States State
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (States)GetValue(StateProperty);
                }
                else
                {
                    return GetInternalState();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(StateProperty, value);
                }
                else
                {
                    SetInternalState(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalState(States value)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.STATE, (int)value);
        }

        private States GetInternalState()
        {
            int temp = Object.InternalGetPropertyInt(SwigCPtr, Property.STATE);
            switch (temp)
            {
                case 0: return States.Normal;
                case 1: return States.Focused;
                case 2: return States.Disabled;
                default: return States.Normal;
            }
        }

        /// <summary>
        /// The current sub state of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public States SubState
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (States)GetValue(SubStateProperty);
                }
                else
                {
                    return GetInternalSubState();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SubStateProperty, value);
                }
                else
                {
                    SetInternalSubState(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSubState(States value)
        {
            string valueToString = value.GetDescription();
            Object.InternalSetPropertyString(SwigCPtr, Property.SubState, valueToString);
        }

        private States GetInternalSubState()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, Property.SubState);
            return temp.GetValueByDescription<States>();
        }

        /// <summary>
        /// Displays a tooltip
        /// This property allows setting the tooltip properties such as text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Tooltip
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(TooltipProperty);
                }
                else
                {
                    return GetInternalTooltip();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TooltipProperty, value);
                }
                else
                {
                    SetInternalTooltip(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTooltip(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.TOOLTIP, pv);
            }
        }

        private PropertyMap GetInternalTooltip()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var pv = Object.GetProperty(SwigCPtr, Property.TOOLTIP);
            pv.Get(temp);
            return temp;
        }

        /// <summary>
        /// Displays a tooltip as a text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TooltipText
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TooltipTextProperty) as string;
                }
                else
                {
                    return GetInternalTooltipText();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TooltipTextProperty, value);
                }
                else
                {
                    SetInternalTooltipText(value);
                }
            }
        }

        private void SetInternalTooltipText(string text)
        {
            if (text != null)
            {
                InternalTooltipText = text;
            }
        }

        private string GetInternalTooltipText()
        {
            return InternalTooltipText;
        }

        private string InternalTooltipText
        {
            get
            {
                using (var propertyValue = GetProperty(Property.TOOLTIP))
                {
                    using var propertyMap = new PropertyMap();
                    if (propertyValue != null && propertyValue.Get(propertyMap))
                    {
                        using var retrivedContentValue = propertyMap?.Find(NDalic.TooltipContent);
                        if (retrivedContentValue != null)
                        {
                            using var contextPropertyMap = new PropertyMap();
                            if (retrivedContentValue.Get(contextPropertyMap))
                            {
                                using var retrivedTextValue = contextPropertyMap?.Find(NDalic.TextVisualText);
                                if (retrivedTextValue != null && retrivedTextValue.Get(out string retrivedValue))
                                {
                                    return retrivedValue;
                                }
                            }
                        }
                    }
                    return "";
                }
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.TOOLTIP, temp);
                temp.Dispose();
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The proportion of the free space in the container, the flex item will receive.<br />
        /// If all items in the container set this property, their sizes will be proportional to the specified flex factor.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10.")]
        public float Flex
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(FlexProperty);
                }
                else
                {
                    return GetInternalFlex();

                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FlexProperty, value);
                }
                else
                {
                    SetInternalFlex(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalFlex(float flex)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, FlexContainer.ChildProperty.FLEX, flex);
        }

        private float GetInternalFlex()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, FlexContainer.ChildProperty.FLEX);
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The alignment of the flex item along the cross axis, which, if set, overrides the default alignment for all items in the container.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10.")]
        public int AlignSelf
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(AlignSelfProperty);
                }
                else
                {
                    return GetInternalAlignSelf();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AlignSelfProperty, value);
                }
                else
                {
                    SetInternalAlignSelf(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalAlignSelf(int alignSelf)
        {
            Object.InternalSetPropertyInt(SwigCPtr, FlexContainer.ChildProperty.AlignSelf, alignSelf);
        }

        private int GetInternalAlignSelf()
        {
            return Object.InternalGetPropertyInt(SwigCPtr, FlexContainer.ChildProperty.AlignSelf);
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The space around the flex item.<br />
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (view.FlexMargin.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API8, will be removed in API10.")]
        public Vector4 FlexMargin
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    Vector4 temp = (Vector4)GetValue(FlexMarginProperty);
                    return new Vector4(OnFlexMarginChanged, temp.X, temp.Y, temp.Z, temp.W);
                }
                else
                {
                    using Vector4 temp = GetInternalFlexMargin();
                    return new Vector4(OnFlexMarginChanged, temp.X, temp.Y, temp.Z, temp.W);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FlexMarginProperty, value);
                }
                else
                {
                    SetInternalFlexMargin(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalFlexMargin(Vector4 margin)
        {
            if (margin != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, FlexContainer.ChildProperty.FlexMargin, margin.SwigCPtr);
            }
        }

        private Vector4 GetInternalFlexMargin()
        {
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Object.InternalRetrievingPropertyVector4(SwigCPtr, FlexContainer.ChildProperty.FlexMargin, temp.SwigCPtr);
            return temp;
        }

        /// <summary>
        /// The top-left cell this child occupies, if not set, the first available cell is used.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is not recommended.
        /// Also, this property is for <see cref="TableView"/> class. Please use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.CellIndex = new Vector2(1, 3);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.CellIndex.X = 1; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 CellIndex
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(CellIndexProperty);
                }
                else
                {
                    return GetInternalCellIndex();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CellIndexProperty, value);
                }
                else
                {
                    SetInternalCellIndex(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCellIndex(Vector2 newValue)
        {
            if (newValue != null)
            {
                Object.InternalSetPropertyVector2(SwigCPtr, TableView.ChildProperty.CellIndex, newValue.SwigCPtr);
            }
        }

        private Vector2 GetInternalCellIndex()
        {
            if (internalCellIndex == null)
            {
                internalCellIndex = new Vector2(OnCellIndexChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(SwigCPtr, TableView.ChildProperty.CellIndex, internalCellIndex.SwigCPtr);
            return internalCellIndex;
        }

        /// <summary>
        /// The number of rows this child occupies, if not set, the default value is 1.
        /// </summary>
        /// <remarks>
        /// This property is for <see cref="TableView"/> class. Use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float RowSpan
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(RowSpanProperty);
                }
                else
                {
                    return GetInternalRowSpan();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RowSpanProperty, value);
                }
                else
                {
                    SetInternalRowSpan(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalRowSpan(float rowSpan)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, TableView.ChildProperty.RowSpan, rowSpan);
        }

        private float GetInternalRowSpan()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, TableView.ChildProperty.RowSpan);
        }

        /// <summary>
        /// The number of columns this child occupies, if not set, the default value is 1.
        /// </summary>
        /// <remarks>
        /// This property is for <see cref="TableView"/> class. Use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float ColumnSpan
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ColumnSpanProperty);
                }
                else
                {
                    return GetInternalColumnSpan();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ColumnSpanProperty, value);
                }
                else
                {
                    SetInternalColumnSpan(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalColumnSpan(float columnSpan)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, TableView.ChildProperty.ColumnSpan, columnSpan);
        }

        private float GetInternalColumnSpan()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, TableView.ChildProperty.ColumnSpan);
        }

        /// <summary>
        /// The horizontal alignment of this child inside the cells, if not set, the default value is 'left'.
        /// </summary>
        /// <remarks>
        /// This property is for <see cref="TableView"/> class. Use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.HorizontalAlignmentType CellHorizontalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignmentType)GetValue(CellHorizontalAlignmentProperty);
                }
                else
                {
                    return GetInternalCellHorizontalAlignment();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CellHorizontalAlignmentProperty, value);
                }
                else
                {
                    SetInternalCellHorizontalAlignment(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCellHorizontalAlignment(HorizontalAlignmentType value)
        {
            string valueToString = value.GetDescription();
            Object.InternalSetPropertyString(SwigCPtr, TableView.ChildProperty.CellHorizontalAlignment, valueToString);
        }

        private HorizontalAlignmentType GetInternalCellHorizontalAlignment()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, TableView.ChildProperty.CellHorizontalAlignment);
            return temp.GetValueByDescription<HorizontalAlignmentType>();
        }

        /// <summary>
        /// The vertical alignment of this child inside the cells, if not set, the default value is 'top'.
        /// </summary>
        /// <remarks>
        /// This property is for <see cref="TableView"/> class. Use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.VerticalAlignmentType CellVerticalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalAlignmentType)GetValue(CellVerticalAlignmentProperty);
                }
                else
                {
                    return GetInternalCellVerticalAlignment();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CellVerticalAlignmentProperty, value);
                }
                else
                {
                    SetInternalCellVerticalAlignment(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCellVerticalAlignment(VerticalAlignmentType value)
        {
            string valueToString = value.GetDescription();
            Object.InternalSetPropertyString(SwigCPtr, TableView.ChildProperty.CellVerticalAlignment, valueToString);
        }

        private VerticalAlignmentType GetInternalCellVerticalAlignment()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, TableView.ChildProperty.CellVerticalAlignment);
            return temp.GetValueByDescription<VerticalAlignmentType>();
        }

        /// <summary>
        /// The left focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified left focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View LeftFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (View)GetValue(LeftFocusableViewProperty);
                }
                else
                {
                    return GetInternalLeftFocusableView();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LeftFocusableViewProperty, value);
                }
                else
                {
                    SetInternalLeftFocusableView(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalLeftFocusableView(View view)
        {
            if (view != null)
            {
                LeftFocusableViewId = (int)view?.GetId();
            }
            else
            {
                LeftFocusableViewId = -1;
            }
        }

        private View GetInternalLeftFocusableView()
        {
            if (LeftFocusableViewId >= 0)
            {
                return ConvertIdToView((uint)LeftFocusableViewId);
            }
            return null;
        }

        /// <summary>
        /// The right focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified right focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View RightFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (View)GetValue(RightFocusableViewProperty);
                }
                else
                {
                    return GetInternalRightFocusableView();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RightFocusableViewProperty, value);
                }
                else
                {
                    SetInternalRightFocusableView(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalRightFocusableView(View view)
        {
            if (view != null)
            {
                RightFocusableViewId = (int)view.GetId();
            }
            else
            {
                RightFocusableViewId = -1;
            }
        }

        private View GetInternalRightFocusableView()
        {
            if (RightFocusableViewId >= 0)
            {
                return ConvertIdToView((uint)RightFocusableViewId);
            }
            return null;
        }

        /// <summary>
        /// The up focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified up focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View UpFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (View)GetValue(UpFocusableViewProperty);
                }
                else
                {
                    return GetInternalUpFocusableView();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UpFocusableViewProperty, value);
                }
                else
                {
                    SetInternalUpFocusableView(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalUpFocusableView(View view)
        {
            if (view != null)
            {
                UpFocusableViewId = (int)view?.GetId();
            }
            else
            {
                UpFocusableViewId = -1;
            }
        }

        private View GetInternalUpFocusableView()
        {
            if (UpFocusableViewId >= 0)
            {
                return ConvertIdToView((uint)UpFocusableViewId);
            }
            return null;
        }

        /// <summary>
        /// The down focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified down focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View DownFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (View)GetValue(DownFocusableViewProperty);
                }
                else
                {
                    return GetInternalDownFocusableView();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DownFocusableViewProperty, value);
                }
                else
                {
                    SetInternalDownFocusableView(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalDownFocusableView(View view)
        {
            if (view != null)
            {
                DownFocusableViewId = (int)view?.GetId();
            }
            else
            {
                DownFocusableViewId = -1;
            }
        }

        private View GetInternalDownFocusableView()
        {
            if (DownFocusableViewId >= 0)
            {
                return ConvertIdToView((uint)DownFocusableViewId);
            }
            return null;
        }

        /// <summary>
        /// The clockwise focusable view by rotary wheel.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified clockwise focusable view is not on a window.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View ClockwiseFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (View)GetValue(ClockwiseFocusableViewProperty);
                }
                else
                {
                    return GetInternalClockwiseFocusableView();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ClockwiseFocusableViewProperty, value);
                }
                else
                {
                    SetInternalClockwiseFocusableView(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalClockwiseFocusableView(View view)
        {
            if (view != null)
            {
                ClockwiseFocusableViewId = (int)view?.GetId();
            }
            else
            {
                ClockwiseFocusableViewId = -1;
            }
        }

        private View GetInternalClockwiseFocusableView()
        {
            if (ClockwiseFocusableViewId >= 0)
            {
                return ConvertIdToView((uint)ClockwiseFocusableViewId);
            }
            return null;
        }

        /// <summary>
        /// The counter clockwise focusable view by rotary wheel.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified counter clockwise focusable view is not on a window.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View CounterClockwiseFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (View)GetValue(CounterClockwiseFocusableViewProperty);
                }
                else
                {
                    return GetInternalCounterClockwiseFocusableView();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CounterClockwiseFocusableViewProperty, value);
                }
                else
                {
                    SetInternalCounterClockwiseFocusableView(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCounterClockwiseFocusableView(View view)
        {
            if (view != null)
            {
                CounterClockwiseFocusableViewId = (int)view?.GetId();
            }
            else
            {
                CounterClockwiseFocusableViewId = -1;
            }
        }

        private View GetInternalCounterClockwiseFocusableView()
        {
            if (CounterClockwiseFocusableViewId >= 0)
            {
                return ConvertIdToView((uint)CounterClockwiseFocusableViewId);
            }
            return null;
        }

        /// <summary>
        /// Whether the view should be focusable by keyboard navigation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Focusable
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(FocusableProperty);
                }
                else
                {
                    return GetInternalFocusable();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FocusableProperty, value);
                }
                else
                {
                    SetInternalFocusable(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalFocusable(bool focusable)
        {
            SetKeyboardFocusable(focusable);
        }

        private bool GetInternalFocusable()
        {
            return IsKeyboardFocusable();
        }

        /// <summary>
        /// Whether the children of this view can be focusable by keyboard navigation. If user sets this to false, the children of this actor view will not be focused.
        /// Note : Default value is true.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FocusableChildren
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(FocusableChildrenProperty);
                }
                else
                {
                    return GetInternalFocusableChildren();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FocusableChildrenProperty, value);
                }
                else
                {
                    SetInternalFocusableChildren(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalFocusableChildren(bool focusableChildren)
        {
            SetKeyboardFocusableChildren(focusableChildren);
        }

        private bool GetInternalFocusableChildren()
        {
            return AreChildrenKeyBoardFocusable();
        }

        /// <summary>
        /// Whether this view can focus by touch.
        /// If Focusable is false, FocusableInTouch is disabled.
        /// If you want to have focus on touch, you need to set both Focusable and FocusableInTouch settings to true.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FocusableInTouch
        {
            get
            {

                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(FocusableInTouchProperty);
                }
                else
                {
                    return GetInternalFocusableInTouch();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FocusableInTouchProperty, value);
                }
                else
                {
                    SetInternalFocusableInTouch(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalFocusableInTouch(bool focusableInTouch)
        {
            SetFocusableInTouch(focusableInTouch);
        }

        private bool GetInternalFocusableInTouch()
        {
            return IsFocusableInTouch();
        }

        /// <summary>
        /// Retrieves the position of the view.
        /// The coordinates are relative to the view's parent.
        /// </summary>
        /// <remarks>
        /// The <see cref="Size"/>, <see cref="Position"/>, <see cref="Color"/>, and <see cref="Scale"/> properties are set in the main thread.
        /// Therefore, it is not updated in real time when the value is changed in the render thread (for example, the value is changed during animation).
        /// However, <see cref="CurrentSize"/>, <see cref="CurrentPosition"/>, <see cref="CurrentColor"/>, and <see cref="CurrentScale"/> properties are updated in real time,
        /// and users can get the current actual values through them.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Position CurrentPosition
        {
            get
            {
                return GetCurrentPosition();
            }
        }

        /// <summary>
        /// Sets the size of a view for the width and the height.<br />
        /// Geometry can be scaled to fit within this area.<br />
        /// This does not interfere with the view's scale factor.<br />
        /// The views default depth is the minimum of width and height.<br />
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.Size2D = new Size2D(100, 200);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.Size2D.Width = 100; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Size2D Size2D
        {
            get
            {
                Size2D temp = null;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Size2D)GetValue(Size2DProperty);
                }
                else
                {
                    temp = GetInternalSize2D(); 
                }
                if (this.Layout == null)
                {
                    if (temp.Width < 0) { temp.Width = 0; }
                    if (temp.Height < 0) { temp.Height = 0; }
                }
                return temp;
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(Size2DProperty, value);
                }
                else
                {
                    SetInternalSize2D(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSize2D(Size2D size)
        {
            // Size property setter is only used by user.
            // Framework code uses SetSize() instead of Size property setter.
            // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
            // SuggestedMinimumWidth/Height is used by Layout calculation.
            int width = size.Width;
            int height = size.Height;
            userSizeWidth = (float)width;
            userSizeHeight = (float)height;

            if (layoutExtraData != null)
            {
                LayoutWidth = width;
                LayoutHeight = height;
            }

            bool relayoutRequired = false;
            // To avoid duplicated size setup, change internal policy directly.
            if (widthPolicy != width)
            {
                widthPolicy = width;
                relayoutRequired = true;
            }
            if (heightPolicy != height)
            {
                heightPolicy = height;
                relayoutRequired = true;
            }
            if (relayoutRequired)
            {
                RequestLayout();
            }

            Object.InternalSetPropertyVector2ActualVector3(SwigCPtr, Property.SIZE, size.SwigCPtr);
        }

        private Size2D GetInternalSize2D()
        {
            if (internalSize2D == null)
            {
                internalSize2D = new Size2D(OnSize2DChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2ActualVector3(SwigCPtr, Property.SIZE, internalSize2D.SwigCPtr);

            return internalSize2D;
        }

        /// <summary>
        /// Retrieves the size of the view.
        /// The coordinates are relative to the view's parent.
        /// </summary>
        /// <remarks>
        /// The <see cref="Size"/>, <see cref="Position"/>, <see cref="Color"/>, and <see cref="Scale"/> properties are set in the main thread.
        /// Therefore, it is not updated in real time when the value is changed in the render thread (for example, the value is changed during animation).
        /// However, <see cref="CurrentSize"/>, <see cref="CurrentPosition"/>, <see cref="CurrentColor"/>, and <see cref="CurrentScale"/> properties are updated in real time,
        /// and users can get the current actual values through them.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Size2D CurrentSize
        {
            get
            {
                return GetCurrentSize();
            }
        }

        /// <summary>
        /// Retrieves and sets the view's opacity.<br />
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "Opacity", 0.5f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float Opacity
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(OpacityProperty);
                }
                else
                {
                    return GetInternalOpacity();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OpacityProperty, value);
                }
                else
                {
                    SetInternalOpacity(value);
                }
                NotifyPropertyChanged();
            }
        }

        internal void SetInternalOpacity(Selector<float?> selector)
        {
            themeData?.selectorData?.Opacity?.Reset(this);
            if (selector.HasAll())
            {
                SetOpacity(selector.All);
            }
            else
            {
                EnsureSelectorData().Opacity = new TriggerableSelector<float?>(this, selector, SetOpacity, true);
            }
        }

        private void SetInternalOpacity(float opacity)
        {
            themeData?.selectorData?.Opacity?.Reset(this);

            //Selector using code has been removed because the Selector is not used when IsUsingXaml is false
            SetOpacity(opacity);
        }

        private float GetInternalOpacity()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.OPACITY);
        }

        /// <summary>
        /// Sets the position of the view for X and Y.<br />
        /// By default, sets the position vector between the parent origin and the pivot point (default).<br />
        /// If the position inheritance is disabled, sets the world position.<br />
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is not recommended.
        ///</remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.Position2D = new Position2D(100, 200);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.Position2D.X = 100; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Position2D Position2D
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Position2D)GetValue(Position2DProperty);
                }
                else
                {
                    return GetInternalPosition2D();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(Position2DProperty, value);
                }
                else
                {
                    SetInternalPosition2D(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPosition2D(Position2D newValue)
        {
            if (newValue != null)
            {
                Object.InternalSetPropertyVector2ActualVector3(SwigCPtr, Property.POSITION, newValue.SwigCPtr);
            }
        }

        private Position2D GetInternalPosition2D()
        {
            if (internalPosition2D == null)
            {
                internalPosition2D = new Position2D(OnPosition2DChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2ActualVector3(SwigCPtr, Property.POSITION, internalPosition2D.SwigCPtr);
            return internalPosition2D;
        }

        /// <summary>
        /// Retrieves the screen position of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenPosition
        {
            get
            {
                return GetCurrentScreenPosition();
            }
        }

        /// <summary>
        /// Retrieves the screen position and size of the view.<br />
        /// </summary>
        /// <remarks>
        /// The float type Rectangle class is not ready yet.
        /// Therefore, it transmits data in Vector4 class.
        /// This type should later be changed to the appropriate data type.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 ScreenPositionSize
        {
            get
            {
                return GetCurrentScreenPositionSize();
            }
        }

        /// <summary>
        /// Determines whether the pivot point should be used to determine the position of the view.
        /// This is false by default.
        /// </summary>
        /// <remarks>If false, then the top-left of the view is used for the position.
        /// Setting this to false will allow scaling or rotation around the pivot point without affecting the view's position.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool PositionUsesPivotPoint
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(PositionUsesPivotPointProperty);
                }
                else
                {
                    return GetInternalPositionUsesPivotPoint();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionUsesPivotPointProperty, value);
                }
                else
                {
                    SetInternalPositionUsesPivotPoint(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPositionUsesPivotPoint(bool positionUsesPivotPoint)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.PositionUsesAnchorPoint, positionUsesPivotPoint);
        }

        private bool GetInternalPositionUsesPivotPoint()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.PositionUsesAnchorPoint);
        }

        /// <summary>
        /// This has been deprecated in API5 and Will be removed in API8. Use PositionUsesPivotPoint instead.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API5 and will be removed in API8. Use PositionUsesPivotPoint instead. " +
            "Like: " +
            "View view = new View(); " +
            "view.PivotPoint = PivotPoint.Center; " +
            "view.PositionUsesPivotPoint = true;" +
            " This has been deprecated in API5 and will be removed in API8")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PositionUsesAnchorPoint
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(PositionUsesAnchorPointProperty);
                }
                else
                {
                    return GetInternalPositionUsesAnchorPoint();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionUsesAnchorPointProperty, value);
                }
                else
                {
                    SetInternalPositionUsesAnchorPoint(value);
                }
            }
        }

        private void SetInternalPositionUsesAnchorPoint(bool positionUsesAnchorPoint)
        {
            InternalPositionUsesAnchorPoint = positionUsesAnchorPoint;
        }

        private bool GetInternalPositionUsesAnchorPoint()
        {
            return InternalPositionUsesAnchorPoint;
        }

        private bool InternalPositionUsesAnchorPoint
        {
            get
            {
                return Object.InternalGetPropertyBool(SwigCPtr, View.Property.PositionUsesAnchorPoint);
            }
            set
            {
                Object.InternalSetPropertyBool(SwigCPtr, View.Property.PositionUsesAnchorPoint, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Queries whether the view is connected to the stage.<br />
        /// When a view is connected, it will be directly or indirectly parented to the root view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsOnWindow
        {
            get
            {
                return OnWindow();
            }
        }

        /// <summary>
        /// Gets the depth in the hierarchy for the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int HierarchyDepth
        {
            get
            {
                return GetHierarchyDepth();
            }
        }

        /// <summary>
        /// Sets the sibling order of the view so the depth position can be defined within the same parent.
        /// </summary>
        /// <remarks>
        /// Note the initial value is 0. SiblingOrder should be bigger than 0 or equal to 0.
        /// Raise, Lower, RaiseToTop, LowerToBottom, RaiseAbove, and LowerBelow will override the sibling order.
        /// The values set by this property will likely change.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public int SiblingOrder
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(SiblingOrderProperty);
                }
                else
                {
                    return GetInternalSiblingOrder();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SiblingOrderProperty, value);
                }
                else
                {
                    SetInternalSiblingOrder(value);
                }
                Layout?.ChangeLayoutSiblingOrder(value);
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSiblingOrder(int siblingOrder)
        {
            if (siblingOrder < 0)
            {
                NUILog.Error("SiblingOrder should be bigger than 0 or equal to 0.");
                return;
            }
            var siblings = GetParent()?.Children;
            if (siblings != null)
            {
                int currentOrder = siblings.IndexOf(this);
                if (siblingOrder != currentOrder)
                {
                    if (siblingOrder == 0) { LowerToBottom(); }
                    else if (siblingOrder < siblings.Count - 1)
                    {
                        if (siblingOrder > currentOrder) { RaiseAbove(siblings[siblingOrder]); }
                        else { LowerBelow(siblings[siblingOrder]); }
                    }
                    else { RaiseToTop(); }
                }
            }
        }

        private int GetInternalSiblingOrder()
        {
            var parentChildren = GetParent()?.Children;
            if (parentChildren != null)
            {
                int currentOrder = parentChildren.IndexOf(this);

                if (currentOrder < 0) { return 0; }
                else if (currentOrder < parentChildren.Count) { return currentOrder; }
            }
            return 0;
        }

        /// <summary>
        /// Returns the natural size of the view.
        /// </summary>
        /// <remarks>
        /// Deriving classes stipulate the natural size and by default a view has a zero natural size.
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        public Vector3 NaturalSize
        {
            get
            {
                Vector3 ret = GetNaturalSize();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Returns the natural size (Size2D) of the view.
        /// </summary>
        /// <remarks>
        /// Deriving classes stipulate the natural size and by default a view has a zero natural size.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public Size2D NaturalSize2D
        {
            get
            {
                Vector3 temp = GetNaturalSize();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                Size2D sz = null;
                if (temp != null)
                {
                    sz = new Size2D((int)temp.Width, (int)temp.Height);
                    temp.Dispose();
                }
                return sz;
            }
        }

        /// <summary>
        /// Gets or sets the origin of a view within its parent's area.<br />
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the parent, and (1.0, 1.0, 0.5) is the bottom-right corner.<br />
        /// The default parent-origin is ParentOrigin.TopLeft (0.0, 0.0, 0.5).<br />
        /// A view's position is the distance between this origin and the view's anchor-point.<br />
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <since_tizen> 3 </since_tizen>
        public Position ParentOrigin
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    var tmp = (Position)GetValue(ParentOriginProperty);
                    return new Position(OnParentOriginChanged, tmp.X, tmp.Y, tmp.Z);
                }
                else
                {
                    using var tmp = GetInternalParentOrigin();
                    return new Position(OnParentOriginChanged, tmp.X, tmp.Y, tmp.Z);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ParentOriginProperty, value);
                }
                else
                {
                    SetInternalParentOrigin(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalParentOrigin(Position origin)
        {
            if (origin != null)
            {
                Object.InternalSetPropertyVector3(SwigCPtr, Property.ParentOrigin, origin.SwigCPtr);
            }
        }

        private Position GetInternalParentOrigin()
        {
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Object.InternalRetrievingPropertyVector3(SwigCPtr, Property.ParentOrigin, temp.SwigCPtr);
            return temp;
        }

        /// <summary>
        /// Gets or sets the anchor-point of a view.<br />
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the view, and (1.0, 1.0, 0.5) is the bottom-right corner.<br />
        /// The default pivot point is PivotPoint.Center (0.5, 0.5, 0.5).<br />
        /// A view position is the distance between its parent-origin and this anchor-point.<br />
        /// A view's orientation is the rotation from its default orientation, the rotation is centered around its anchor-point.<br />
        /// <pre>The view has been initialized.</pre>
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is not recommended.
        ///</remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.PivotPoint = PivotPoint.Center;
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.PivotPoint.X = 0.5f; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Position PivotPoint
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Position)GetValue(PivotPointProperty);
                }
                else
                {
                    return GetInternalPivotPoint();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PivotPointProperty, value);
                }
                else
                {
                    SetInternalPivotPoint(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPivotPoint(Position position)
        {
            if (position != null)
            {
                SetAnchorPoint(position);
            }
        }

        private Position GetInternalPivotPoint()
        {
            if (internalPivotPoint == null)
            {
                internalPivotPoint = new Position(OnPivotPointChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(SwigCPtr, Property.AnchorPoint, internalPivotPoint.SwigCPtr);
            return internalPivotPoint;
        }

        /// <summary>
        /// Gets or sets the size width of the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "SizeWidth", 500.0f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float SizeWidth
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(SizeWidthProperty);
                }
                else
                {
                    return GetInternalSizeWidth();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeWidthProperty, value);
                }
                else
                {
                    SetInternalSizeWidth(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSizeWidth(float sizeWidth)
        {
            // Size property setter is only used by user.
            // Framework code uses SetSize() instead of Size property setter.
            // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
            // SuggestedMinimumWidth/Height is used by Layout calculation.
            float width = sizeWidth;
            userSizeWidth = width;

            if (layoutExtraData != null)
                LayoutWidth = width;

            // To avoid duplicated size setup, change internal policy directly.
            // change temporary value's name as widthPolicyCeiling
            int widthPolicyCeiling = (int)System.Math.Ceiling(width);
            if (widthPolicy != widthPolicyCeiling)
            {
                widthPolicy = widthPolicyCeiling;
                RequestLayout();
            }

            Object.InternalSetPropertyFloat(SwigCPtr, Property.SizeWidth, width);
        }

        private float GetInternalSizeWidth()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.SizeWidth);
        }

        /// <summary>
        /// Gets or sets the size height of the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// </para>
        /// <code>
        /// animation.AnimateTo(view, "SizeHeight", 500.0f);
        /// </code>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float SizeHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(SizeHeightProperty);
                }
                else
                {
                    return GetInternalSizeHeight();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeHeightProperty, value);
                }
                else
                {
                    SetInternalSizeHeight(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSizeHeight(float sizeHeight)
        {
            // Size property setter is only used by user.
            // Framework code uses SetSize() instead of Size property setter.
            // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
            // SuggestedMinimumWidth/Height is used by Layout calculation.
            float height = sizeHeight;
            userSizeHeight = height;

            if (layoutExtraData != null)
                LayoutHeight = height;

            // To avoid duplicated size setup, change internal policy directly.
            // change temporary value's name as heightPolicyCeiling
            int heightPolicyCeiling = (int)System.Math.Ceiling(height);
            if (heightPolicy != heightPolicyCeiling)
            {
                heightPolicy = heightPolicyCeiling;
                RequestLayout();
            }

            Object.InternalSetPropertyFloat(SwigCPtr, Property.SizeHeight, height);
        }

        private float GetInternalSizeHeight()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.SizeHeight);
        }


        /// <summary>
        /// Gets or sets the position of the view.<br />
        /// By default, sets the position vector between the parent origin and pivot point (default).<br />
        /// If the position inheritance is disabled, sets the world position.<br />
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "Position", new Position(50, 0));
        /// </code>
        /// </para>
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.Position = new Position(100, 200.5f, 0);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.Position.Y = 200.5f; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Position Position
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Position)GetValue(PositionProperty);
                }
                else
                {
                    return GetInternalPosition();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionProperty, value);
                }
                else
                {
                    SetInternalPosition(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPosition(Position position)
        {
            if (position != null)
            {
                Object.InternalSetPropertyVector3(SwigCPtr, Property.POSITION, position.SwigCPtr);
            }
        }

        private Position GetInternalPosition()
        {
            if (internalPosition == null)
            {
                internalPosition = new Position(OnPositionChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(SwigCPtr, Property.POSITION, internalPosition.SwigCPtr);
            return internalPosition;
        }

        /// <summary>
        /// Gets or sets the position X of the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "PositionX", 50.0f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float PositionX
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PositionXProperty);
                }
                else
                {
                    return GetInternalPositionX();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionXProperty, value);
                }
                else
                {
                    SetInternalPositionX(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPositionX(float positionX)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.PositionX, positionX);
        }

        private float GetInternalPositionX()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.PositionX);
        }

        /// <summary>
        /// Gets or sets the position Y of the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "PositionY", 50.0f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float PositionY
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PositionYProperty);
                }
                else
                {
                    return GetInternalPositionY();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionYProperty, value);
                }
                else
                {
                    SetInternalPositionY(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPositionY(float positionY)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.PositionY, positionY);
        }

        private float GetInternalPositionY()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.PositionY);
        }

        /// <summary>
        /// Gets or sets the position Z of the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "PositionZ", 50.0f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float PositionZ
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PositionZProperty);
                }
                else
                {
                    return GetInternalPositionZ();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionZProperty, value);
                }
                else
                {
                    SetInternalPositionZ(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPositionZ(float positionZ)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.PositionZ, positionZ);
        }

        private float GetInternalPositionZ()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.PositionZ);
        }

        /// <summary>
        /// Gets or sets the world position of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 WorldPosition
        {
            get
            {
                return GetCurrentWorldPosition();
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the view.<br />
        /// The view's orientation is the rotation from its default orientation, and the rotation is centered around its anchor-point.<br />
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is an asynchronous method.
        /// </para>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "Orientation", new Rotation(new Radian((float)Math.PI), Vector3.XAxis));
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Rotation Orientation
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Rotation)GetValue(OrientationProperty);
                }
                else
                {
                    return GetInternalOrientation();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OrientationProperty, value);
                }
                else
                {
                    SetInternalOrientation(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalOrientation(Rotation rotation)
        {
            using var tmp = new PropertyValue(rotation);
            Object.SetProperty(SwigCPtr, Property.ORIENTATION, tmp);
        }

        private Rotation GetInternalOrientation()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            Rotation temp = new Rotation();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var pv = Object.GetProperty(SwigCPtr, Property.ORIENTATION);
            pv.Get(temp);
            return temp;
        }

        /// <summary>
        /// Gets or sets the world orientation of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rotation WorldOrientation
        {
            get
            {
                Rotation temp = new Rotation();
                var pValue = GetProperty(View.Property.WorldOrientation);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
            }
        }

        /// <summary>
        /// Gets or sets the scale factor applied to the view.<br />
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "Scale", new Vector3(1.5f, 1.5f, 1.0f));
        /// </code>
        /// </para>
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.Scale = new Vector3(1.5f, 2.0f, 1.0f);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.Scale.Width = 1.5f; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 Scale
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector3)GetValue(ScaleProperty);
                }
                else
                {
                    return GetInternalScale();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScaleProperty, value);
                }
                else
                {
                    SetInternalScale(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScale(Vector3 scale)
        {
            if (scale != null)
            {
                SetScale(scale);
            }
        }

        private Vector3 GetInternalScale()
        {
            if (internalScale == null)
            {
                internalScale = new Vector3(OnScaleChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(SwigCPtr, Property.SCALE, internalScale.SwigCPtr);
            return internalScale;
        }

        /// <summary>
        /// Gets or sets the scale X factor applied to the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "ScaleX", 1.5f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleX
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ScaleXProperty);
                }
                else
                {
                    return GetInternalScaleX();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScaleXProperty, value);
                }
                else
                {
                    SetInternalScaleX(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScaleX(float scaleX)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.ScaleX, scaleX);
        }

        private float GetInternalScaleX()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ScaleX);
        }

        /// <summary>
        /// Gets or sets the scale Y factor applied to the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "ScaleY", 1.5f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleY
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ScaleYProperty);
                }
                else
                {
                    return GetInternalScaleY();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScaleYProperty, value);
                }
                else
                {
                    SetInternalScaleY(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScaleY(float scaleY)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.ScaleY, scaleY);
        }

        private float GetInternalScaleY()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ScaleY);
        }

        /// <summary>
        /// Gets or sets the scale Z factor applied to the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "ScaleZ", 1.5f);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleZ
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ScaleZProperty);
                }
                else
                {
                    return GetInternalScaleZ();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScaleZProperty, value);
                }
                else
                {
                    SetInternalScaleZ(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScaleZ(float scaleZ)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.ScaleZ, scaleZ);
        }

        private float GetInternalScaleZ()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ScaleZ);
        }

        /// <summary>
        /// Gets the world scale of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 WorldScale
        {
            get
            {
                return GetCurrentWorldScale();
            }
        }

        /// <summary>
        /// Retrieves the visibility flag of the view.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the view is not visible, then the view and its children will not be rendered.
        /// This is regardless of the individual visibility values of the children, i.e., the view will only be rendered if all of its parents have visibility set to true.
        /// </para>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "Visibility", false);
        /// </code>
        /// </para>
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool Visibility
        {
            get
            {
                return Object.InternalGetPropertyBool(SwigCPtr, View.Property.VISIBLE);
            }
        }

        /// <summary>
        /// Gets the view's world color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 WorldColor
        {
            get
            {
                return GetCurrentWorldColor();
            }
        }

        /// <summary>
        /// Gets or sets the view's name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(NameProperty);
                }
                else
                {
                    return GetInternalName();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(NameProperty, value);
                }
                else
                {
                    SetInternalName(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalName(string name)
        {
            if (name != null)
            {
                internalName = name;
                Object.InternalSetPropertyString(SwigCPtr, Property.NAME, name);
            }
        }

        private string GetInternalName()
        {
            return internalName;
        }

        /// <summary>
        /// Get the number of children held by the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new uint ChildCount
        {
            get
            {
                return Convert.ToUInt32(Children.Count);
            }
        }

        /// <summary>
        /// Gets The unique identifier of the view. (Read-only)
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint ID
        {
            get
            {
                return GetId();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the view should emit touch or hover signals.
        /// If a View is made insensitive, then the View and its children are not hittable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Sensitive
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(SensitiveProperty);
                }
                else
                {
                    return GetInternalSensitive();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SensitiveProperty, value);
                }
                else
                {
                    SetInternalSensitive(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSensitive(bool sensitive)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.SENSITIVE, sensitive);
        }

        private bool GetInternalSensitive()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.SENSITIVE);
        }

        /// <summary>
        /// Gets or sets the status of whether the view should be enabled user interactions.
        /// If a View is made disabled, then user interactions including touch, focus, and actiavation is disabled.
        /// </summary>
        /// <since_tizen> tizen_next </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(IsEnabledProperty);
                }
                else
                {
                    return GetInternalIsEnabled();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsEnabledProperty, value);
                }
                else
                {
                    SetInternalIsEnabled(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalIsEnabled(bool isEnabled)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.UserInteractionEnabled, isEnabled);
            OnEnabled(isEnabled);
        }

        private bool GetInternalIsEnabled()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.UserInteractionEnabled);
        }

        /// <summary>
        /// Gets or sets the status of whether the view should receive a notification when touch or hover motion events leave the boundary of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool LeaveRequired
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(LeaveRequiredProperty);
                }
                else
                {
                    return GetInternalLeaveRequired();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LeaveRequiredProperty, value);
                }
                else
                {
                    SetInternalLeaveRequired(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalLeaveRequired(bool leaveRequired)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.LeaveRequired, leaveRequired);
        }

        private bool GetInternalLeaveRequired()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.LeaveRequired);
        }

        /// <summary>
        /// Gets or sets the status of whether a child view inherits it's parent's orientation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritOrientation
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(InheritOrientationProperty);
                }
                else
                {
                    return GetInternalInheritOrientation();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InheritOrientationProperty, value);
                }
                else
                {
                    SetInternalInheritOrientation(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInheritOrientation(bool inheritOrientation)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.InheritOrientation, inheritOrientation);
        }

        private bool GetInternalInheritOrientation()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.InheritOrientation);
        }

        /// <summary>
        /// Gets or sets the status of whether a child view inherits it's parent's scale.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritScale
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(InheritScaleProperty);
                }
                else
                {
                    return GetInternalInheritScale();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InheritScaleProperty, value);
                }
                else
                {
                    SetInternalInheritScale(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInheritScale(bool inheritScale)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.InheritScale, inheritScale);
        }

        private bool GetInternalInheritScale()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.InheritScale);
        }

        /// <summary>
        /// Gets or sets the status of how the view and its children should be drawn.<br />
        /// Not all views are renderable, but DrawMode can be inherited from any view.<br />
        /// If an object is in a 3D layer, it will be depth-tested against other objects in the world, i.e., it may be obscured if other objects are in front.<br />
        /// If DrawMode.Overlay2D is used, the view and its children will be drawn as a 2D overlay.<br />
        /// Overlay views are drawn in a separate pass, after all non-overlay views within the layer.<br />
        /// For overlay views, the drawing order is with respect to tree levels of views, and depth-testing will not be used.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DrawModeType DrawMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (DrawModeType)GetValue(DrawModeProperty);
                }
                else
                {
                    return GetInternalDrawMode();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DrawModeProperty, value);
                }
                else
                {
                    SetInternalDrawMode(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalDrawMode(DrawModeType value)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.DrawMode, (int)value);
        }

        private DrawModeType GetInternalDrawMode()
        {
            return (DrawModeType)Object.InternalGetPropertyInt(SwigCPtr, Property.DrawMode);
        }

        /// <summary>
        /// Gets or sets the relative to parent size factor of the view.<br />
        /// This factor is only used when ResizePolicyType is set to either: ResizePolicyType.SizeRelativeToParent or ResizePolicyType.SizeFixedOffsetFromParent.<br />
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicyType.<br />
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var text = new TextField();
        /// text.SizeModeFactor = new Vector3(1.0f, 0.45f, 1.0f);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// text.SizeModeFactor.Width = 1.0f; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 SizeModeFactor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector3)GetValue(SizeModeFactorProperty);
                }
                else
                {
                    return GetInternalSizeModeFactor();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeModeFactorProperty, value);
                }
                else
                {
                    SetInternalSizeModeFactor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSizeModeFactor(Vector3 factor)
        {
            if (factor != null)
            {
                Object.InternalSetPropertyVector3(SwigCPtr, Property.SizeModeFactor, factor.SwigCPtr);
            }
        }

        private Vector3 GetInternalSizeModeFactor()
        {
            if (internalSizeModeFactor == null)
            {
                internalSizeModeFactor = new Vector3(OnSizeModeFactorChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(SwigCPtr, Property.SizeModeFactor, internalSizeModeFactor.SwigCPtr);
            return internalSizeModeFactor;
        }

        /// <summary>
        /// Gets or sets the width resize policy to be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResizePolicyType WidthResizePolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ResizePolicyType)GetValue(WidthResizePolicyProperty);
                }
                else
                {
                    return GetInternalWidthResizePolicy();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WidthResizePolicyProperty, value);
                }
                else
                {
                    SetInternalWidthResizePolicy(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalWidthResizePolicy(ResizePolicyType value)
        {
            if (value == ResizePolicyType.KeepSizeFollowingParent)
            {
                if (widthConstraint == null)
                {
                    widthConstraint = new EqualConstraintWithParentFloat(SwigCPtr, Property.SizeWidth, Property.SizeWidth);
                    widthConstraint.Apply();
                }
                Object.InternalSetPropertyInt(SwigCPtr, Property.WidthResizePolicy, (int)ResizePolicyType.FillToParent);
            }
            else
            {
                widthConstraint?.Remove();
                widthConstraint?.Dispose();
                widthConstraint = null;

                Object.InternalSetPropertyInt(SwigCPtr, Property.WidthResizePolicy, (int)value);
            }
            // Match ResizePolicy to new Layouting.
            // Parent relative policies can not be mapped at this point as parent size unknown.
            switch (value)
            {
                case ResizePolicyType.UseNaturalSize:
                    {
                        WidthSpecification = LayoutParamPolicies.WrapContent;
                        break;
                    }
                case ResizePolicyType.FillToParent:
                    {
                        WidthSpecification = LayoutParamPolicies.MatchParent;
                        break;
                    }
                case ResizePolicyType.FitToChildren:
                    {
                        WidthSpecification = LayoutParamPolicies.WrapContent;
                        break;
                    }
                default:
                    break;
            }
        }

        private ResizePolicyType GetInternalWidthResizePolicy()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, Property.WidthResizePolicy);
            return temp.GetValueByDescription<ResizePolicyType>();
        }

        /// <summary>
        /// Gets or sets the height resize policy to be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResizePolicyType HeightResizePolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ResizePolicyType)GetValue(HeightResizePolicyProperty);
                }
                else
                {
                    return GetInternalHeightResizePolicy();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HeightResizePolicyProperty, value);
                }
                else
                {
                    SetInternalHeightResizePolicy(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalHeightResizePolicy(ResizePolicyType value)
        {
            if (value == ResizePolicyType.KeepSizeFollowingParent)
            {
                if (heightConstraint == null)
                {
                    heightConstraint = new EqualConstraintWithParentFloat(SwigCPtr, Property.SizeHeight, Property.SizeHeight);
                    heightConstraint.Apply();
                }

                Object.InternalSetPropertyInt(SwigCPtr, Property.HeightResizePolicy, (int)ResizePolicyType.FillToParent);
            }
            else
            {
                heightConstraint?.Remove();
                heightConstraint?.Dispose();
                heightConstraint = null;

                Object.InternalSetPropertyInt(SwigCPtr, Property.HeightResizePolicy, (int)value);
            }
            // Match ResizePolicy to new Layouting.
            // Parent relative policies can not be mapped at this point as parent size unknown.
            switch (value)
            {
                case ResizePolicyType.UseNaturalSize:
                    {
                        HeightSpecification = LayoutParamPolicies.WrapContent;
                        break;
                    }
                case ResizePolicyType.FillToParent:
                    {
                        HeightSpecification = LayoutParamPolicies.MatchParent;
                        break;
                    }
                case ResizePolicyType.FitToChildren:
                    {
                        HeightSpecification = LayoutParamPolicies.WrapContent;
                        break;
                    }
                default:
                    break;
            }
        }

        private ResizePolicyType GetInternalHeightResizePolicy()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, Property.HeightResizePolicy);
            return temp.GetValueByDescription<ResizePolicyType>();
        }

        /// <summary>
        /// Gets or sets the policy to use when setting size with size negotiation.<br />
        /// Defaults to SizeScalePolicyType.UseSizeSet.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SizeScalePolicyType SizeScalePolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (SizeScalePolicyType)GetValue(SizeScalePolicyProperty);
                }
                else
                {
                    return GetInternalSizeScalePolicy();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeScalePolicyProperty, value);
                }
                else
                {
                    SetInternalSizeScalePolicy(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSizeScalePolicy(SizeScalePolicyType value)
        {
            string valueToString = value.GetDescription();
            Object.InternalSetPropertyString(SwigCPtr, Property.SizeScalePolicy, valueToString);
        }

        private SizeScalePolicyType GetInternalSizeScalePolicy()
        {
            return (SizeScalePolicyType)Object.InternalGetPropertyInt(SwigCPtr, Property.SizeScalePolicy);
        }

        /// <summary>
        /// Gets or sets the status of whether the width size is dependent on the height size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool WidthForHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(WidthForHeightProperty);
                }
                else
                {
                    return GetInternalWidthForHeight();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WidthForHeightProperty, value);
                }
                else
                {
                    SetInternalWidthForHeight(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalWidthForHeight(bool widthForHeight)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.WidthForHeight, widthForHeight);
        }

        private bool GetInternalWidthForHeight()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.WidthForHeight);
        }

        /// <summary>
        /// Gets or sets the status of whether the height size is dependent on the width size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool HeightForWidth
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(HeightForWidthProperty);
                }
                else
                {
                    return GetInternalHeightForWidth();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HeightForWidthProperty, value);
                }
                else
                {
                    SetInternalHeightForWidth(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalHeightForWidth(bool heightForWidth)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.HeightForWidth, heightForWidth);
        }

        private bool GetInternalHeightForWidth()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.HeightForWidth);
        }

        /// <summary>
        /// Gets or sets the padding for use in layout.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.Padding = new Extents(5, 5, 5, 5);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.Padding.Start = 5; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public Extents Padding
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Extents)GetValue(PaddingProperty);
                }
                else
                {
                    return GetInternalPadding();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PaddingProperty, value);
                }
                else
                {
                    SetInternalPadding(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPadding(Extents extents)
        {
            if (extents != null)
            {
                if (layoutExtraData != null && extents is Extents newPadding)
                    SetPadding(new UIExtents(newPadding.Start, newPadding.End, newPadding.Top, newPadding.Bottom), false);

                if (Layout != null && !Layout.IsPaddingHandledByNative())
                {
                    Layout.Padding = new Extents((Extents)extents);
                    if ((Padding.Start != 0) || (Padding.End != 0) || (Padding.Top != 0) || (Padding.Bottom != 0))
                    {
                        using var ex = new Extents(0, 0, 0, 0);
                        using var tmp = new PropertyValue(ex);
                        Object.SetProperty(SwigCPtr, Property.PADDING, tmp);
                    }
                    Layout.RequestLayout();
                }
                else
                {
                    using var tmp = new PropertyValue(extents);
                    Object.SetProperty(SwigCPtr, Property.PADDING, tmp);
                }
            }
        }

        private Extents GetInternalPadding()
        {
            if (internalPadding == null || (Layout != null && !Layout.IsPaddingHandledByNative()))
            {
                ushort start = 0, end = 0, top = 0, bottom = 0;
                if (Layout != null && !Layout.IsPaddingHandledByNative() && Layout.Padding != null)
                {
                    start = Layout.Padding.Start;
                    end = Layout.Padding.End;
                    top = Layout.Padding.Top;
                    bottom = Layout.Padding.Bottom;
                }
                internalPadding = new Extents(OnPaddingChanged, start, end, top, bottom);
            }

            if (Layout == null || Layout.IsPaddingHandledByNative())
            {
                var tmp = Object.GetProperty(SwigCPtr, Property.PADDING);
                tmp?.Get(internalPadding);
                tmp?.Dispose();
            }

            return internalPadding;
        }

        /// <summary>
        /// Gets or sets the minimum size the view can be assigned in size negotiation.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        /// <remarks>
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.MinimumSize = new Size2D(100, 200);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.MinimumSize.Width = 100; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Size2D MinimumSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size2D)GetValue(MinimumSizeProperty);
                }
                else
                {
                    return GetInternalMinimumSize();
                }
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (layoutExtraData != null)
                {
                    SetMinimumWidth(value.Width, false);
                    SetMinimumHeight(value.Height, false);
                }

                if (layoutExtraData?.Layout is LayoutItem layout)
                {
                    // Note: it only works if minimum size is >= than natural size.
                    // To force the size it should be done through the width&height spec or Size2D.
                    layout.MinimumWidth = new Tizen.NUI.LayoutLength(value.Width);
                    layout.MinimumHeight = new Tizen.NUI.LayoutLength(value.Height);
                    layout.RequestLayout();
                }
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MinimumSizeProperty, value);
                }
                else
                {
                    SetInternalMinimumSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMinimumSize(Size2D size)
        {
            if (size != null)
            {
                Object.InternalSetPropertyVector2(SwigCPtr, Property.MinimumSize, size.SwigCPtr);
            }
        }

        private Size2D GetInternalMinimumSize()
        {
            if (internalMinimumSize == null)
            {
                internalMinimumSize = new Size2D(OnMinimumSizeChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(SwigCPtr, Property.MinimumSize, internalMinimumSize.SwigCPtr);
            return internalMinimumSize;
        }

        /// <summary>
        /// Gets or sets the maximum size the view can be assigned in size negotiation.
        /// </summary>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.MaximumSize = new Size2D(100, 200);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.MaximumSize.Height = 200; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Size2D MaximumSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size2D)GetValue(MaximumSizeProperty);
                }
                else
                {
                    return GetInternalMaximumSize();
                }
            }
            set
            {
                if (layoutExtraData != null)
                {
                    SetMaximumWidth(value.Width, false);
                    SetMaximumHeight(value.Height, false);
                }

                // We don't have Layout.Maximum(Width|Height) so we cannot apply it to layout.
                // MATCH_PARENT spec + parent container size can be used to limit
                RequestLayout();

                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MaximumSizeProperty, value);
                }
                else
                {
                    SetInternalMaximumSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMaximumSize(Size2D size)
        {
            if (size != null)
            {
                Object.InternalSetPropertyVector2(SwigCPtr, Property.MaximumSize, size.SwigCPtr);
            }
        }

        private Size2D GetInternalMaximumSize()
        {
            if (internalMaximumSize == null)
            {
                internalMaximumSize = new Size2D(OnMaximumSizeChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(SwigCPtr, Property.MaximumSize, internalMaximumSize.SwigCPtr);
            return internalMaximumSize;
        }

        /// <summary>
        /// Gets or sets whether a child view inherits it's parent's position.<br />
        /// Default is to inherit.<br />
        /// Switching this off means that using position sets the view's world position, i.e., translates from the world origin (0,0,0) to the pivot point of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritPosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(InheritPositionProperty);
                }
                else
                {
                    return GetInternalInheritPosition();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InheritPositionProperty, value);
                }
                else
                {
                    SetInternalInheritPosition(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInheritPosition(bool inheritPosition)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.InheritPosition, inheritPosition);
        }

        private bool GetInternalInheritPosition()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.InheritPosition);
        }

        /// <summary>
        /// Gets or sets the clipping behavior (mode) of it's children.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ClippingModeType ClippingMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ClippingModeType)GetValue(ClippingModeProperty);
                }
                else
                {
                    return GetInternalClippingMode();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ClippingModeProperty, value);
                }
                else
                {
                    SetInternalClippingMode(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalClippingMode(ClippingModeType value)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.ClippingMode, (int)value);
        }

        private ClippingModeType GetInternalClippingMode()
        {
            return (ClippingModeType)Object.InternalGetPropertyInt(SwigCPtr, Property.ClippingMode);
        }

        /// <summary>
        /// Gets the number of renderers held by the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint RendererCount
        {
            get
            {
                return GetRendererCount();
            }
        }

        /// <summary>
        /// This has been deprecated in API5 and will be removed in API8. Use PivotPoint instead.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (view.AnchorPoint.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API5 and will be removed in API8. Use PivotPoint instead. " +
            "Like: " +
            "View view = new View(); " +
            "view.PivotPoint = PivotPoint.Center; " +
            "view.PositionUsesPivotPoint = true;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position AnchorPoint
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Position)GetValue(AnchorPointProperty);
                }
                else
                {
                    return GetInternalAnchorPoint();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AnchorPointProperty, value);
                }
                else
                {
                    SetInternalAnchorPoint(value);
                }
            }
        }

        private void SetInternalAnchorPoint(Position position)
        {
            if (position != null)
            {
                InternalAnchorPoint = position;
            }
        }

        private Position GetInternalAnchorPoint()
        {
            return InternalAnchorPoint;
        }

        private Position InternalAnchorPoint
        {
            get
            {
                return GetCurrentAnchorPoint();
            }
            set
            {
                SetAnchorPoint(value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Sets the size of a view for the width, the height and the depth.<br />
        /// Geometry can be scaled to fit within this area.<br />
        /// This does not interfere with the view's scale factor.<br />
        /// The views default depth is the minimum of width and height.<br />
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// <code>
        /// animation.AnimateTo(view, "Size", new Size(100, 100));
        /// </code>
        /// </para>
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.Size = new Size(100.5f, 200, 0);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.Size.Width = 100.5f; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public Size Size
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size)GetValue(SizeProperty);
                }
                else
                {
                    return GetInternalSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeProperty, value);
                }
                else
                {
                    SetInternalSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSize(Size size)
        {
            if (size != null)
            {
                // Size property setter is only used by user.
                // Framework code uses SetSize() instead of Size property setter.
                // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
                // SuggestedMinimumWidth/Height is used by Layout calculation.
                float width = size.Width;
                float height = size.Height;
                float depth = size.Depth;

                userSizeWidth = width;
                userSizeHeight = height;

                if (layoutExtraData != null)
                {
                    LayoutWidth = width;
                    LayoutHeight = height;
                }

                // Set Specification so when layouts measure this View it matches the value set here.
                // All Views are currently Layouts.
                int widthPolicy = (int)Math.Ceiling(width);
                int heightPolicy = (int)Math.Ceiling(height);

                bool relayoutRequired = false;
                // To avoid duplicated size setup, change internal policy directly.
                if (this.widthPolicy != widthPolicy)
                {
                    this.widthPolicy = widthPolicy;
                    relayoutRequired = true;
                }
                if (this.heightPolicy != heightPolicy)
                {
                    this.heightPolicy = heightPolicy;
                    relayoutRequired = true;
                }
                if (relayoutRequired)
                {
                    RequestLayout();
                }

                SetSize(width, height, depth);
            }
        }

        private Size GetInternalSize()
        {
            if (internalSize == null)
            {
                internalSize = new Size(OnSizeChanged, 0, 0, 0);
            }

            var w = Interop.Actor.InternalGetPropertyFloat(SwigCPtr, Property.SizeWidth);
            var h = Interop.Actor.InternalGetPropertyFloat(SwigCPtr, Property.SizeHeight);
            var d = Interop.Actor.InternalGetPropertyFloat(SwigCPtr, Property.SizeDepth);

            internalSize.ResetValue(w, h, d);

            return internalSize;
        }

        /// <summary>
        /// This has been deprecated in API5 and will be removed in API8. Use 'Container GetParent() for derived class' instead.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated in API5 and will be removed in API8. Use 'Container GetParent() for derived class' instead. " +
            "Like: " +
            "Container parent =  view.GetParent(); " +
            "View view = parent as View;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new View Parent
        {
            get
            {
                View ret;
                IntPtr cPtr = Interop.Actor.GetParent(SwigCPtr);
                HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
                BaseHandle basehandle = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle);

                if (basehandle is Layer layer)
                {
                    ret = new View(Layer.getCPtr(layer).Handle, false);
                    NUILog.Error("This Parent property is deprecated, should do not be used");
                }
                else
                {
                    ret = basehandle as View;
                }

                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Gets/Sets whether inherit parent's the layout Direction.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool InheritLayoutDirection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(InheritLayoutDirectionProperty);
                }
                else
                {
                    return GetInternalInheritLayoutDirection();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InheritLayoutDirectionProperty, value);
                }
                else
                {
                    SetInternalInheritLayoutDirection(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInheritLayoutDirection(bool inheritLayoutDirection)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.InheritLayoutDirection, inheritLayoutDirection);
        }

        private bool GetInternalInheritLayoutDirection()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.InheritLayoutDirection);
        }

        /// <summary>
        /// Gets/Sets the layout Direction.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ViewLayoutDirectionType LayoutDirection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ViewLayoutDirectionType)GetValue(LayoutDirectionProperty);
                }
                else
                {
                    return GetInternalLayoutDirection();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LayoutDirectionProperty, value);
                }
                else
                {
                    SetInternalLayoutDirection(value);
                }
                NotifyPropertyChanged();
                RequestLayout();
            }
        }

        private void SetInternalLayoutDirection(ViewLayoutDirectionType value)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.LayoutDirection, (int)value);
        }

        private ViewLayoutDirectionType GetInternalLayoutDirection()
        {
            return (ViewLayoutDirectionType)Object.InternalGetPropertyInt(SwigCPtr, Property.LayoutDirection);
        }

        /// <summary>
        /// Gets or sets the Margin for use in layout.
        /// </summary>
        /// <remarks>
        /// Margin property is supported by Layout algorithms and containers.
        /// Please Set Layout if you want to use Margin property.
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.Margin = new Extents(10, 5, 15, 20);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.Margin.Top = 15; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        /// <since_tizen> 4 </since_tizen>
        public Extents Margin
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Extents)GetValue(MarginProperty);
                }
                else
                {
                    return GetInternalMargin();
                }

            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MarginProperty, value);
                }
                else
                {
                    SetInternalMargin(value);
                }

                NotifyPropertyChanged();
            }
        }

        private void SetInternalMargin(Extents extents)
        {
            if (extents != null)
            {
                if (layoutExtraData != null && extents is Extents newMargin)
                    SetMargin(new UIExtents(newMargin.Start, newMargin.End, newMargin.Top, newMargin.Bottom), false);

                if (Layout != null)
                {
                    Layout.Margin = new Extents((Extents)extents);
                    if ((Margin.Start != 0) || (Margin.End != 0) || (Margin.Top != 0) || (Margin.Bottom != 0))
                    {
                        using var ex = new Extents(0, 0, 0, 0);
                        using var tmp = new PropertyValue(ex);
                        Object.SetProperty(SwigCPtr, Property.MARGIN, tmp);
                    }
                    Layout.RequestLayout();
                }
                else
                {
                    using var tmp = new PropertyValue(extents);
                    Object.SetProperty(SwigCPtr, Property.MARGIN, tmp);
                }
            }
        }

        private Extents GetInternalMargin()
        {
            if ((internalMargin == null) || (Layout != null))
            {
                ushort start = 0, end = 0, top = 0, bottom = 0;
                if (Layout != null)
                {
                    if (Layout.Margin != null)
                    {
                        start = Layout.Margin.Start;
                        end = Layout.Margin.End;
                        top = Layout.Margin.Top;
                        bottom = Layout.Margin.Bottom;
                    }
                }
                internalMargin = new Extents(OnMarginChanged, start, end, top, bottom);
            }

            if (Layout == null)
            {
                using var tmp = Object.GetProperty(SwigCPtr, Property.MARGIN);
                tmp?.Get(internalMargin);
            }

            return internalMargin;
        }

        ///<summary>
        /// The required policy for this dimension, <see cref="LayoutParamPolicies"/> values or exact value.
        ///</summary>
        /// <example>
        /// <code>
        /// // matchParentView matches its size to its parent size.
        /// matchParentView.WidthSpecification = LayoutParamPolicies.MatchParent;
        /// matchParentView.HeightSpecification = LayoutParamPolicies.MatchParent;
        ///
        /// // wrapContentView wraps its children with their desired size.
        /// wrapContentView.WidthSpecification = LayoutParamPolicies.WrapContent;
        /// wrapContentView.HeightSpecification = LayoutParamPolicies.WrapContent;
        ///
        /// // exactSizeView shows itself with an exact size.
        /// exactSizeView.WidthSpecification = 100;
        /// exactSizeView.HeightSpecification = 100;
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        [Binding.TypeConverter(typeof(IntGraphicsTypeConverter))]
        public int WidthSpecification
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(WidthSpecificationProperty);
                }
                else
                {
                    return GetInternalWidthSpecification();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WidthSpecificationProperty, value);
                }
                else
                {
                    SetInternalWidthSpecification(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalWidthSpecification(int widthSpecification)
        {
            InternalWidthSpecification = widthSpecification;
        }

        private int GetInternalWidthSpecification()
        {
            return InternalWidthSpecification;
        }

        private int InternalWidthSpecification
        {
            get
            {
                return widthPolicy;
            }
            set
            {
                if (value == widthPolicy)
                    return;

                widthPolicy = value;
                if (widthPolicy >= 0)
                {
                    SizeWidth = widthPolicy;
                }

                if (layoutExtraData != null)
                    LayoutWidth = widthPolicy;

                RequestLayout();
            }
        }

        ///<summary>
        /// The required policy for this dimension, <see cref="LayoutParamPolicies"/> values or exact value.
        ///</summary>
        /// <example>
        /// <code>
        /// // matchParentView matches its size to its parent size.
        /// matchParentView.WidthSpecification = LayoutParamPolicies.MatchParent;
        /// matchParentView.HeightSpecification = LayoutParamPolicies.MatchParent;
        ///
        /// // wrapContentView wraps its children with their desired size.
        /// wrapContentView.WidthSpecification = LayoutParamPolicies.WrapContent;
        /// wrapContentView.HeightSpecification = LayoutParamPolicies.WrapContent;
        ///
        /// // exactSizeView shows itself with an exact size.
        /// exactSizeView.WidthSpecification = 100;
        /// exactSizeView.HeightSpecification = 100;
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        [Binding.TypeConverter(typeof(IntGraphicsTypeConverter))]
        public int HeightSpecification
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(HeightSpecificationProperty);
                }
                else
                {
                    return GetInternalHeightSpecification();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HeightSpecificationProperty, value);
                }
                else
                {
                    SetInternalHeightSpecification(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalHeightSpecification(int heightSpecification)
        {
            InternalHeightSpecification = heightSpecification;
        }

        private int GetInternalHeightSpecification()
        {
            return InternalHeightSpecification;
        }

        private int InternalHeightSpecification
        {
            get
            {
                return heightPolicy;
            }
            set
            {
                if (value == heightPolicy)
                    return;

                heightPolicy = value;
                if (heightPolicy >= 0)
                {
                    SizeHeight = heightPolicy;
                }

                if (layoutExtraData != null)
                    LayoutHeight = heightPolicy;

                RequestLayout();
            }
        }

        ///<summary>
        /// Gets the List of transitions for this View.
        ///</summary>
        /// <since_tizen> 6 </since_tizen>
        public Dictionary<TransitionCondition, TransitionList> LayoutTransitions
        {
            get
            {
                var layoutExtraData = EnsureLayoutExtraData();

                if (layoutExtraData.LayoutTransitions == null)
                {
                    layoutExtraData.LayoutTransitions = new Dictionary<TransitionCondition, TransitionList>();
                }
                return layoutExtraData.LayoutTransitions;
            }
        }

        ///<summary>
        /// Sets a layout transitions for this View.
        ///</summary>
        /// <exception cref="ArgumentNullException"> Thrown when value is null. </exception>
        /// <remarks>
        /// Use LayoutTransitions to receive a collection of LayoutTransitions set on the View.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        public LayoutTransition LayoutTransition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(LayoutTransitionProperty) as LayoutTransition;
                }
                else
                {
                    return GetInternalLayoutTransition();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LayoutTransitionProperty, value);
                }
                else
                {
                    SetInternalLayoutTransition(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalLayoutTransition(LayoutTransition transition)
        {
            if (transition != null)
            {
                InternalLayoutTransition = transition;
            }
        }

        private LayoutTransition GetInternalLayoutTransition()
        {
            return InternalLayoutTransition;
        }

        private LayoutTransition InternalLayoutTransition
        {
            get => EnsureLayoutExtraData().LayoutTransition;
            set
            {
                if (value == null)
                {
                    throw new global::System.ArgumentNullException(nameof(value));
                }

                var layoutExtraData = EnsureLayoutExtraData();

                if (layoutExtraData.LayoutTransitions == null)
                {
                    layoutExtraData.LayoutTransitions = new Dictionary<TransitionCondition, TransitionList>();
                }

                LayoutTransitionsHelper.AddTransitionForCondition(layoutExtraData.LayoutTransitions, value.Condition, value, true);

                AttachTransitionsToChildren(value);

                layoutExtraData.LayoutTransition = value;
            }
        }

        /// <summary>
        /// This has been deprecated in API5 and will be removed in API8. Use Padding instead.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (view.DecorationBoundingBox.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("This has been deprecated in API5 and will be removed in API8. Use Padding instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents PaddingEX
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(PaddingEXProperty) as Extents;
                }
                else
                {
                    return GetInternalPaddingEX();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PaddingEXProperty, value);
                }
                else
                {
                    SetInternalPaddingEX(value);
                }
            }
        }

        private void SetInternalPaddingEX(Extents padding)
        {
            if (padding != null)
            {
                InternalPaddingEX = padding;
            }
        }

        private Extents GetInternalPaddingEX()
        {
            return InternalPaddingEX;
        }

        private Extents InternalPaddingEX
        {
            get
            {
                Extents temp = new Extents(0, 0, 0, 0);
                var pValue = GetProperty(View.Property.PADDING);
                pValue.Get(temp);
                pValue.Dispose();
                Extents ret = new Extents(OnPaddingEXChanged, temp.Start, temp.End, temp.Top, temp.Bottom);
                temp.Dispose();
                return ret;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.PADDING, temp);
                temp.Dispose();
                NotifyPropertyChanged();
                RequestLayout();
            }
        }

        /// <summary>
        /// The Color of View. This is an RGBA value.
        /// Each RGBA components match as <see cref="ColorRed"/>, <see cref="ColorGreen"/>, <see cref="ColorBlue"/>, and <see cref="Opacity"/>.
        /// This property will multiply the final color of this view. (BackgroundColor, BorderlineColor, BackgroundImage, etc).
        /// For example, if view.BackgroundColor = Color.Yellow and view.Color = Color.Purple, this view will shown as Red.
        /// Inherient of color value depend on <see cref="ColorMode"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// </para>
        /// The property cascade chaining set is not recommended.
        /// </remarks>
        /// <example>
        /// This way is recommended for setting the property
        /// <code>
        /// var view = new View();
        /// view.Color = new Color(0.5f, 0.2f, 0.1f, 0.5f);
        /// </code>
        /// This way to set the property is prohibited
        /// <code>
        /// view.Color.A = 0.5f; //This does not guarantee a proper operation
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(ColorProperty);
                }
                else
                {
                    return GetInternalColor();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ColorProperty, value);
                }
                else
                {
                    SetInternalColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        internal void SetInternalColor(Selector<Color> selector)
        {
            themeData?.selectorData?.Color?.Reset(this);
            if (selector.HasAll())
            {
                SetColor(selector.All);
            }
            else
            {
                EnsureSelectorData().Color = new TriggerableSelector<Color>(this, selector, SetColor, true);
            }
        }

        private void SetInternalColor(Color color)
        {
            themeData?.selectorData?.Color?.Reset(this);
            SetColor(color);
        }

        private Color GetInternalColor()
        {
            if (internalColor == null)
            {
                internalColor = new Color(OnColorChanged, 0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, View.Property.COLOR, internalColor.SwigCPtr);
            return internalColor;
        }

        /// <summary>
        /// The Red component of View.Color.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// </para>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ColorRed
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ColorRedProperty);
                }
                else
                {
                    return GetInternalColorRed();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ColorRedProperty, value);
                }
                else
                {
                    SetInternalColorRed(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalColorRed(float colorRed)
        {
            SetColorRed(colorRed);
        }
        private float GetInternalColorRed()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ColorRed);
        }

        /// <summary>
        /// The Green component of View.Color.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// </para>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ColorGreen
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ColorGreenProperty);
                }
                else
                {
                    return GetInternalColorGreen();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ColorGreenProperty, value);
                }
                else
                {
                    SetInternalColorGreen(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalColorGreen(float colorGreen)
        {
            SetColorGreen(colorGreen);
        }

        private float GetInternalColorGreen()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ColorGreen);
        }

        /// <summary>
        /// The Blue component of View.Color.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Animatable - This property can be animated using <c>Animation</c> class.
        /// </para>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ColorBlue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ColorBlueProperty);
                }
                else
                {
                    return GetInternalColorBlue();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ColorBlueProperty, value);
                }
                else
                {
                    SetInternalColorBlue(value);
                }
                NotifyPropertyChanged();
            }
        }
        private void SetInternalColorBlue(float colorBlue)
        {
            SetColorBlue(colorBlue);
        }

        private float GetInternalColorBlue()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ColorBlue);
        }

        /// <summary>
        /// Set the layout on this View. Replaces any existing Layout.
        /// </summary>
        /// <remarks>
        /// If this Layout is set as null explicitly, it means this View itself and it's child Views will not use Layout anymore.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        public LayoutItem Layout
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(LayoutProperty) as LayoutItem;
                }
                else
                {
                    return GetInternalLayout();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LayoutProperty, value);
                }
                else
                {
                    SetInternalLayout(value);
                }
            }
        }

        private void SetInternalLayout(LayoutItem item)
        {
            if (item != null)
            {
                InternalLayout = item;
            }
        }

        private LayoutItem GetInternalLayout()
        {
            return InternalLayout;
        }

        private LayoutItem InternalLayout
        {
            get => layoutExtraData?.Layout;
            set
            {
                var layoutExtraData = EnsureLayoutExtraData();

                // Do nothing if layout provided is already set on this View.
                if (value == layoutExtraData.Layout)
                {
                    return;
                }

                LayoutingDisabled = false;
                layoutExtraData.LayoutSet = true;

                // If new layout being set already has a owner then that owner receives a replacement default layout.
                // First check if the layout to be set already has a owner.
                if (value?.Owner != null)
                {
                    // Previous owner of the layout gets a default layout as a replacement.
                    value.Owner.Layout = new AbsoluteLayout()
                    {
                        // Copy Margin and Padding to replacement LayoutGroup.
                        Margin = value.Margin,
                        Padding = value.Padding,
                    };
                }

                // Copy Margin and Padding to new layout being set or restore padding and margin back to
                // View if no replacement. Previously margin and padding values would have been moved from
                // the View to the layout.
                if (layoutExtraData.Layout != null) // Existing layout
                {
                    if (value != null)
                    {
                        // Existing layout being replaced so copy over margin and padding values.
                        value.Margin = layoutExtraData.Layout.Margin;
                        value.Padding = layoutExtraData.Layout.Padding;
                        value.SetPositionByLayout = !layoutExtraData.ExcludeLayouting;
                    }
                    else
                    {
                        // Layout not being replaced so restore margin and padding to View.
                        if (NUIApplication.IsUsingXaml)
                        {
                            SetValue(MarginProperty, layoutExtraData.Layout.Margin);
                            SetValue(PaddingProperty, layoutExtraData.Layout.Padding);
                        }
                        else
                        {
                            SetInternalMargin(layoutExtraData.Layout.Margin);
                            SetInternalPadding(layoutExtraData.Layout.Padding);
                        }
                        NotifyPropertyChanged();
                    }
                }
                else
                {
                    // First Layout to be added to the View hence copy

                    // Do not try to set Margins or Padding on a null Layout (when a layout is being removed from a View)
                    if (value != null)
                    {
                        Extents margin = Margin;
                        Extents padding = Padding;
                        bool setMargin = false;
                        bool setPadding = false;

                        if (margin.Top != 0 || margin.Bottom != 0 || margin.Start != 0 || margin.End != 0)
                        {
                            // If View already has a margin set then store it in Layout instead.
                            value.Margin = margin;
                            using var extents = new Extents(0, 0, 0, 0);
                            if (NUIApplication.IsUsingXaml)
                            {
                                SetValue(MarginProperty, extents);
                            }
                            else
                            {
                                SetInternalMargin(extents);
                            }
                            setMargin = true;
                        }

                        // The calculation of the native size of the text component requires padding.
                        // Don't overwrite the zero padding.
                        if (!value.IsPaddingHandledByNative() && (padding.Top != 0 || padding.Bottom != 0 || padding.Start != 0 || padding.End != 0))
                        {
                            // If View already has a padding set then store it in Layout instead.
                            value.Padding = padding;
                            using var tmpPadding = new Extents(0, 0, 0, 0);
                            if (NUIApplication.IsUsingXaml)
                            {
                                SetValue(PaddingProperty, tmpPadding);
                            }
                            else
                            {
                                SetInternalPadding(tmpPadding);
                            }
                            setPadding = true;
                        }

                        if (setMargin || setPadding)
                        {
                            NotifyPropertyChanged();
                        }

                        value.SetPositionByLayout = !layoutExtraData.ExcludeLayouting;
                    }
                }

                // Remove existing layout from it's parent layout group.
                layoutExtraData.Layout?.Unparent();

                // Set layout to this view
                SetLayout(value);
            }
        }

        /// <summary>
        /// The weight of the View, used to share available space in a layout with siblings.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float Weight
        {
            get => layoutExtraData?.Weight ?? 0;
            set
            {
                var layoutExtraData = EnsureLayoutExtraData();
                layoutExtraData.Weight = value;
                layoutExtraData.Layout?.RequestLayout();
            }
        }

        /// <summary>
        ///  Whether to load the BackgroundImage synchronously.
        ///  If not specified, the default is false, i.e. the BackgroundImage is loaded asynchronously.
        ///  Note: For Normal Quad images only.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BackgroundImageSynchronosLoading
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(BackgroundImageSynchronosLoadingProperty);
                }
                else
                {
                    return GetInternalBackgroundImageSynchronosLoading();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundImageSynchronosLoadingProperty, value);
                }
                else
                {
                    SetInternalBackgroundImageSynchronosLoading(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalBackgroundImageSynchronosLoading(bool backgroundImageSynchronousLoading)
        {
            InternalBackgroundImageSynchronosLoading = backgroundImageSynchronousLoading;
        }

        private bool GetInternalBackgroundImageSynchronosLoading()
        {
            return InternalBackgroundImageSynchronosLoading;
        }

        private bool InternalBackgroundImageSynchronosLoading
        {
            get
            {
                return BackgroundImageSynchronousLoading;
            }
            set
            {
                BackgroundImageSynchronousLoading = value;
            }
        }

        /// <summary>
        ///  Whether to load the BackgroundImage synchronously.
        ///  If not specified, the default is false, i.e. the BackgroundImage is loaded asynchronously.
        ///  Note: For Normal Quad images only.
        /// </summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BackgroundImageSynchronousLoading
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(BackgroundImageSynchronousLoadingProperty);
                }
                else
                {
                    return GetInternalBackgroundImageSynchronousLoading();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundImageSynchronousLoadingProperty, value);
                }
                else
                {
                    SetInternalBackgroundImageSynchronousLoading(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalBackgroundImageSynchronousLoading(bool backgroundImageSynchronousLoading)
        {
            InternalBackgroundImageSynchronousLoading = backgroundImageSynchronousLoading;
        }

        private bool GetInternalBackgroundImageSynchronousLoading()
        {
            return InternalBackgroundImageSynchronousLoading;
        }

        private bool InternalBackgroundImageSynchronousLoading
        {
            get
            {
                return backgroundImageSynchronousLoading;
            }
            set
            {
                if (backgroundImageSynchronousLoading != value)
                {
                    backgroundImageSynchronousLoading = value;

                    if (!string.IsNullOrEmpty(BackgroundImage))
                    {
                        PropertyMap bgMap = this.Background;
                        bgMap.Set(ImageVisualProperty.SynchronousLoading, backgroundImageSynchronousLoading);
                        Background = bgMap;
                    }
                }
            }
        }

        /// <summary>
        /// Gets and Sets hint of partial update area.
        /// </summary>
        /// <remarks>
        /// The property format applied as below logics.
        /// Vector4(offsetX, offsetY, width, height).
        /// - offsetX : Offset of the center of partial update area's X axis position from the center of View.
        /// - offsetY : Offset of the center of partial update area's X axis position from the center of View.
        /// - width   : Width of partial update area.
        /// - height  : Height of partial update area.
        ///
        /// Special case - If we set Vector4.Zero, it will be used Vector4(0.0f, 0.0f, SizeWidth, SizeHeight) automatically.
        ///
        /// This update area give efforts for all Renderer and Visuals.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 UpdateAreaHint
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(UpdateAreaHintProperty);
                }
                else
                {
                    return GetInternalUpdateAreaHint();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UpdateAreaHintProperty, value);
                }
                else
                {
                    SetInternalUpdateAreaHint(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalUpdateAreaHint(Vector4 area)
        {
            if (area != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Interop.ActorProperty.UpdateAreaHintGet(), area.SwigCPtr);
            }
        }

        private Vector4 GetInternalUpdateAreaHint()
        {
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Interop.ActorProperty.UpdateAreaHintGet(), temp.SwigCPtr);
            return temp;
        }

        /// <summary>
        /// Enable/Disable ControlState propagation for children.
        /// It is false by default.
        /// If the View needs to share ControlState with descendants, please set it true.
        /// Please note that, changing the value will also changes children's EnableControlStatePropagation value recursively.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableControlStatePropagation
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableControlStatePropagationProperty);
                }
                else
                {
                    return GetInternalEnableControlStatePropagation();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableControlStatePropagationProperty, value);
                }
                else
                {
                    SetInternalEnableControlStatePropagation(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableControlStatePropagation(bool enableControlStatePropagation)
        {
            InternalEnableControlStatePropagation = enableControlStatePropagation;
        }

        private bool GetInternalEnableControlStatePropagation()
        {
            return InternalEnableControlStatePropagation;
        }

        private bool InternalEnableControlStatePropagation
        {
            get => themeData?.ControlStatePropagation ?? false;
            set
            {
                if (InternalEnableControlStatePropagation == value) return;

                if (themeData == null) themeData = new ThemeData();

                themeData.ControlStatePropagation = value;

                foreach (View child in Children)
                {
                    child.EnableControlStatePropagation = value;
                }
            }
        }

        /// <summary>
        /// The ControlStates can propagate from the parent.
        /// Listed ControlStates will be accepted propagation of the parent ControlState changes
        /// if parent view EnableControlState is true.
        /// <see cref="EnableControlState"/>.
        /// Default is ControlState.All, so every ControlStates will be propagated from the parent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlState PropagatableControlStates
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ControlState)GetValue(PropagatableControlStatesProperty);
                }
                else
                {
                    return GetInternalPropagatableControlStates();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PropagatableControlStatesProperty, value);
                }
                else
                {
                    SetInternalPropagatableControlStates(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPropagatableControlStates(ControlState state)
        {
            if (state != null)
            {
                InternalPropagatableControlStates = state;
            }
        }

        private ControlState GetInternalPropagatableControlStates()
        {
            return InternalPropagatableControlStates;
        }

        private ControlState InternalPropagatableControlStates
        {
            get => propagatableControlStates;
            set => propagatableControlStates = value;
        }

        /// <summary>
        /// By default, it is false in View, true in Control.
        /// Note that if the value is true, the View will be a touch receptor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableControlState
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableControlStateProperty);
                }
                else
                {
                    return GetInternalEnableControlState();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableControlStateProperty, value);
                }
                else
                {
                    SetInternalEnableControlState(value);
                }
            }
        }

        private void SetInternalEnableControlState(bool enableControlStateArg)
        {
            bool prev = enableControlState;
            enableControlState = enableControlStateArg;

            if (prev != enableControlState)
            {
                if (prev)
                {
                    TouchEvent -= EmptyOnTouch;
                }
                else
                {
                    TouchEvent += EmptyOnTouch;
                }
            }
        }

        private bool GetInternalEnableControlState()
        {
            return enableControlState;
        }

        /// <summary>
        /// Whether the actor grab all touches even if touch leaves its boundary.
        /// </summary>
        /// <returns>true, if it grab all touch after start</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GrabTouchAfterLeave
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(GrabTouchAfterLeaveProperty);
                }
                else
                {
                    return GetInternalGrabTouchAfterLeave();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(GrabTouchAfterLeaveProperty, value);
                }
                else
                {
                    SetInternalGrabTouchAfterLeave(value);
                }
            }
        }

        private void SetInternalGrabTouchAfterLeave(bool grabTouchAfterLeave)
        {
            InternalGrabTouchAfterLeave = grabTouchAfterLeave;
        }

        private bool GetInternalGrabTouchAfterLeave()
        {
            return InternalGrabTouchAfterLeave;
        }

        private bool InternalGrabTouchAfterLeave
        {
            get
            {
                return Object.InternalGetPropertyBool(SwigCPtr, View.Property.CaptureAllTouchAfterStart);
            }
            set
            {
                Object.InternalSetPropertyBool(SwigCPtr, View.Property.CaptureAllTouchAfterStart, value);

                // Use custom HitTest callback only if GrabTouchAfterLeave is true.
                if (value)
                {
                    RegisterHitTestCallback();
                }
                else
                {
                    UnregisterHitTestCallback();
                }

                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether the view will only receive own touch.
        /// </summary>
        /// <returns>true, if it only receives touches that started from itself.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllowOnlyOwnTouch
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(AllowOnlyOwnTouchProperty);
                }
                else
                {
                    return GetInternalAllowOnlyOwnTouch();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AllowOnlyOwnTouchProperty, value);
                }
                else
                {
                    SetInternalAllowOnlyOwnTouch(value);
                }
            }
        }

        private void SetInternalAllowOnlyOwnTouch(bool allowOnlyOwnTouch)
        {
            InternalAllowOnlyOwnTouch = allowOnlyOwnTouch;
        }

        private bool GetInternalAllowOnlyOwnTouch()
        {
            return InternalAllowOnlyOwnTouch;
        }

        private bool InternalAllowOnlyOwnTouch
        {
            get
            {
                return Object.InternalGetPropertyBool(SwigCPtr, View.Property.AllowOnlyOwnTouch);
            }
            set
            {
                Object.InternalSetPropertyBool(SwigCPtr, View.Property.AllowOnlyOwnTouch, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Determines which blend equation will be used to render renderers of this actor.
        /// </summary>
        /// <returns>blend equation enum currently assigned</returns>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendEquationType BlendEquation
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (BlendEquationType)GetValue(BlendEquationProperty);
                }
                else
                {
                    return GetInternalBlendEquation();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BlendEquationProperty, value);
                }
                else
                {
                    SetInternalBlendEquation(value);
                }
            }
        }

        private void SetInternalBlendEquation(BlendEquationType value)
        {
            InternalBlendEquation = value;
        }

        private BlendEquationType GetInternalBlendEquation()
        {
            return InternalBlendEquation;
        }

        private BlendEquationType InternalBlendEquation
        {
            get
            {
                return (BlendEquationType)Object.InternalGetPropertyInt(SwigCPtr, View.Property.BlendEquation);
            }
            set
            {
                Object.InternalSetPropertyInt(SwigCPtr, View.Property.BlendEquation, (int)value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// If the value is true, the View will change its style as the theme changes.
        /// The default value is false in normal case but it can be true when the NUIApplication is created with <see cref="NUIApplication.ThemeOptions.ThemeChangeSensitive"/>.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool ThemeChangeSensitive
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(ThemeChangeSensitiveProperty);
                }
                else
                {
                    return GetInternalThemeChangeSensitive();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThemeChangeSensitiveProperty, value);
                }
                else
                {
                    SetInternalThemeChangeSensitive(value);
                }
            }
        }

        private void SetInternalThemeChangeSensitive(bool themeChangeSensitive)
        {
            if (ThemeChangeSensitive == themeChangeSensitive) return;

            if (themeData == null) themeData = new ThemeData();

            themeData.ThemeChangeSensitive = themeChangeSensitive;

            if (themeData.ThemeChangeSensitive && !themeData.ListeningThemeChangeEvent)
            {
                themeData.ListeningThemeChangeEvent = true;
                ThemeManager.ThemeChangedInternal.Add(OnThemeChanged);
            }
            else if (!themeData.ThemeChangeSensitive && themeData.ListeningThemeChangeEvent)
            {
                themeData.ListeningThemeChangeEvent = false;
                ThemeManager.ThemeChangedInternal.Remove(OnThemeChanged);
            }
        }

        private bool GetInternalThemeChangeSensitive()
        {
            return themeData?.ThemeChangeSensitive ?? ThemeManager.ApplicationThemeChangeSensitive;
        }

        /// <summary>
        /// Create Style, it is abstract function and must be override.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ViewStyle CreateViewStyle()
        {
            return new ViewStyle();
        }

        /// <summary>
        /// Called after the View's ControlStates changed.
        /// </summary>
        /// <param name="controlStateChangedInfo">The information including state changed variables.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnControlStateChanged(ControlStateChangedEventArgs controlStateChangedInfo)
        {
        }

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnThemeChanged(object sender, ThemeChangedEventArgs e)
        {
            isThemeChanged = true;
            if (string.IsNullOrEmpty(styleName)) ApplyStyle(ThemeManager.GetUpdateStyleWithoutClone(GetType()));
            else ApplyStyle(ThemeManager.GetUpdateStyleWithoutClone(styleName));
            isThemeChanged = false;
        }

        /// <summary>
        /// Apply style instance to the view.
        /// Basically it sets the bindable property to the value of the bindable property with same name in the style.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public virtual void ApplyStyle(ViewStyle viewStyle)
        {
            if (viewStyle == null || themeData?.viewStyle == viewStyle) return;

            if (themeData == null) themeData = new ThemeData();

            themeData.viewStyle = viewStyle;

            ChangedPropertiesSetExcludingStyle = new HashSet<string>();

            foreach (var (property, value) in viewStyle.GetProperties())
            {
                // TODO Check isThemeChanged & ChangedPropertiesSetExcludingStyle
                property.ApplyTo(this, value);
            }

            // NOTE Support backward compatibility.
            ApplyStyleUsingBindableProperty(viewStyle);
        }

        /// <summary>
        /// Get whether the View is culled or not.
        /// True means that the View is out of the view frustum.
        /// </summary>
        /// <remarks>
        /// Hidden-API (Inhouse-API).
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Culled
        {
            get
            {
                return Object.InternalGetPropertyBool(SwigCPtr, View.Property.Culled);
            }
        }

        /// <summary>
        /// Set or Get TransitionOptions for the page transition.
        /// This property is used to define how this view will be transitioned during Page switching.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TransitionOptions TransitionOptions
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TransitionOptionsProperty) as TransitionOptions;
                }
                else
                {
                    return GetInternalTransitionOptions();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TransitionOptionsProperty, value);
                }
                else
                {
                    SetInternalTransitionOptions(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTransitionOptions(TransitionOptions options)
        {
            if (options != null)
            {
                InternalTransitionOptions = options;
            }
        }

        private TransitionOptions GetInternalTransitionOptions()
        {
            return InternalTransitionOptions;
        }

        private TransitionOptions InternalTransitionOptions
        {
            get => layoutExtraData?.TransitionOptions;
            set => EnsureLayoutExtraData().TransitionOptions = value;
        }

        /// <summary>
        /// Called when the view is hit through TouchEvent or GestureEvent.
        /// If it returns true, it means that it was hit, and the touch/gesture event is called from the view.
        /// If it returns false, it means that it will not be hit, and the hit-test continues to the next view.
        /// User can override whether hit or not in HitTest.
        /// You can get the coordinates relative to tthe top-left of the hit view by touch.GetLocalPosition(0).
        /// or you can get the coordinates relative to the top-left of the screen by touch.GetScreenPosition(0).
        /// </summary>
        // <param name="touch"><see cref="Tizen.NUI.Touch"/>The touch data</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool HitTest(Touch touch)
        {
            return true;
        }

        /// <summary>
        /// Retrieve the View's current Color.
        /// </summary>
        /// <remarks>
        /// The <see cref="Size"/>, <see cref="Position"/>, <see cref="Color"/>, and <see cref="Scale"/> properties are set in the main thread.
        /// Therefore, it is not updated in real time when the value is changed in the render thread (for example, the value is changed during animation).
        /// However, <see cref="CurrentSize"/>, <see cref="CurrentPosition"/>, <see cref="CurrentColor"/>, and <see cref="CurrentScale"/> properties are updated in real time,
        /// and users can get the current actual values through them.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color CurrentColor => GetCurrentColor();

        /// <summary>
        /// Retrieve the current scale factor applied to the View.
        /// </summary>
        /// <remarks>
        /// The <see cref="Size"/>, <see cref="Position"/>, <see cref="Color"/>, and <see cref="Scale"/> properties are set in the main thread.
        /// Therefore, it is not updated in real time when the value is changed in the render thread (for example, the value is changed during animation).
        /// However, <see cref="CurrentSize"/>, <see cref="CurrentPosition"/>, <see cref="CurrentColor"/>, and <see cref="CurrentScale"/> properties are updated in real time,
        /// and users can get the current actual values through them.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 CurrentScale => GetCurrentScale();

        /// <summary>
        /// Gets the number of currently alived View object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int AliveCount => aliveCount;

        /// <summary>
        /// Voice interaction name for Voice Touch.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public string VoiceInteractionName
        {
            set
            {
                AutomationId = value;
            }
            get
            {
                return AutomationId;
            }
        }

        /// <summary>
        /// Gets of sets the current offscreen rendering type of the view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OffScreenRenderingType OffScreenRendering
        {
            get
            {
                return GetInternalOffScreenRendering();
            }
            set
            {
                SetInternalOffScreenRendering(value);
                NotifyPropertyChanged();
            }
        }
        private void SetInternalOffScreenRendering(OffScreenRenderingType value)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.OffScreenRendering, (int)value);
        }
        private OffScreenRenderingType GetInternalOffScreenRendering()
        {
            int temp = Object.InternalGetPropertyInt(SwigCPtr, Property.OffScreenRendering);
            switch (temp)
            {
                case 0: return OffScreenRenderingType.None;
                case 1: return OffScreenRenderingType.RefreshOnce;
                case 2: return OffScreenRenderingType.RefreshAlways;
                default: return OffScreenRenderingType.None;
            }
        }

        private LayoutExtraData EnsureLayoutExtraData()
        {
            if (layoutExtraData == null)
            {
                layoutExtraData = new LayoutExtraData();

                LayoutWidth = widthPolicy;
                LayoutHeight = heightPolicy;

                layoutExtraData.MinimumWidth = MinimumSize.Width;
                layoutExtraData.MinimumHeight = MinimumSize.Height;
                layoutExtraData.MaximumWidth = MaximumSize.Width;
                layoutExtraData.MaximumHeight = MaximumSize.Height;

                layoutExtraData.Margin = new UIExtents(Margin.Start, Margin.End, Margin.Top, Margin.End);
                layoutExtraData.Padding = new UIExtents(Padding.Start, Padding.End, Padding.Top, Padding.End);
            }

            return layoutExtraData;
        }

        private void RequestLayout() => layoutExtraData?.Layout?.RequestLayout();

        private void ApplyStyleUsingBindableProperty(ViewStyle viewStyle)
        {
            // NOTE Support backward compatibility.
            if (viewStyle.DirtyProperties == null || viewStyle.DirtyProperties.Count == 0)
            {
                // Nothing to apply
                return;
            }

            BindableProperty.GetBindablePropertysOfType(GetType(), out var bindablePropertyOfView);

            if (bindablePropertyOfView == null)
            {
                return;
            }

            var dirtyStyleProperties = new BindableProperty[viewStyle.DirtyProperties.Count];
            viewStyle.DirtyProperties.CopyTo(dirtyStyleProperties);

            foreach (var sourceProperty in dirtyStyleProperties)
            {
                var sourceValue = viewStyle.GetValue(sourceProperty);

                if (sourceValue == null)
                {
                    continue;
                }

                bindablePropertyOfView.TryGetValue(sourceProperty.PropertyName, out var destinationProperty);

                // Do not set value again when theme is changed and the value has been set already.
                if (isThemeChanged && ChangedPropertiesSetExcludingStyle != null && ChangedPropertiesSetExcludingStyle.Contains(destinationProperty.PropertyName))
                {
                    continue;
                }

                if (destinationProperty != null)
                {
                    InternalSetValue(destinationProperty, sourceValue);
                }
            }
        }
    }
}
