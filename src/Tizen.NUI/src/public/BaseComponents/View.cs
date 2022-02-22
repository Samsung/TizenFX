/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

        internal BackgroundExtraData backgroundExtraData;

        private bool layoutSet = false;
        private LayoutItem layout; // Exclusive layout assigned to this View.

        // List of transitions paired with the condition that uses the transition.
        private Dictionary<TransitionCondition, TransitionList> layoutTransitions;
        private int widthPolicy = LayoutParamPolicies.WrapContent; // Layout width policy
        private int heightPolicy = LayoutParamPolicies.WrapContent; // Layout height policy
        private float weight = 0.0f; // Weighting of child View in a Layout
        private bool backgroundImageSynchronousLoading = false;
        private bool excludeLayouting = false;
        private LayoutTransition layoutTransition;
        private TransitionOptions transitionOptions = null;
        private ThemeData themeData;
        private bool isThemeChanged = false;

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

        static View()
        {
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

            RegisterAccessibilityDelegate();
        }

        /// <summary>
        /// Creates a new instance of a view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View() : this(Interop.View.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View(ViewStyle viewStyle) : this(Interop.View.New(), true, viewStyle)
        {
        }

        /// <summary>
        /// Create a new instance of a View with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View(bool shown) : this(Interop.View.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        internal View(View uiControl, bool shown = true) : this(Interop.View.NewView(View.getCPtr(uiControl)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (!shown)
            {
                SetVisible(false);
            }

            backgroundExtraData = uiControl.backgroundExtraData == null ? null : new BackgroundExtraData(uiControl.backgroundExtraData);
        }

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn, ViewStyle viewStyle, bool shown = true) : this(cPtr, cMemoryOwn, shown)
        {
            InitializeStyle(viewStyle);
        }

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown = true) : base(cPtr, cMemoryOwn)
        {
            if (HasBody())
            {
                PositionUsesPivotPoint = false;
            }

            onWindowSendEventCallback = SendViewAddedEventToWindow;
            using ViewSignal signal = new ViewSignal(Interop.ActorSignal.ActorOnSceneSignal(SwigCPtr), false);
            signal?.Connect(onWindowSendEventCallback);

            if (!shown)
            {
                SetVisible(false);
            }
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LayoutSet
        {
            get
            {
                return layoutSet;
            }
        }

        /// <summary>
        /// Flag to allow Layouting to be disabled for Views.
        /// Once a View has a Layout set then any children added to Views from then on will receive
        /// automatic Layouts.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool LayoutingDisabled { get; set; } = true;

        /// <summary>
        /// Deprecate. Please do not use this.
        /// The style instance applied to this view.
        /// Note that please do not modify the ViewStyle.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

                var prevState = ControlState;

                if (themeData == null) themeData = new ThemeData();
                themeData.controlStates = value;

                var changeInfo = new ControlStateChangedEventArgs(prevState, value);

                ControlStateChangeEventInternal?.Invoke(this, changeInfo);

                if (themeData.ControlStatePropagation)
                {
                    foreach (View child in Children)
                    {
                        child.ControlState = value;
                    }
                }

                OnControlStateChanged(changeInfo);

                ControlStateChangedEvent?.Invoke(this, changeInfo);
            }
        }

        /// <summary>
        /// Gets / Sets the status of whether the view is excluded from its parent's layouting or not.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ExcludeLayouting
        {
            get
            {
                return (bool)GetValue(ExcludeLayoutingProperty);
            }
            set
            {
                SetValue(ExcludeLayoutingProperty, value);
                NotifyPropertyChanged();
            }
        }

        private bool InternalExcludeLayouting
        {
            get
            {
                return excludeLayouting;
            }
            set
            {
                excludeLayouting = value;
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
                return (string)GetValue(StyleNameProperty);
            }
            set
            {
                SetValue(StyleNameProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The KeyInputFocus, type bool.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool KeyInputFocus
        {
            get
            {
                return (bool)GetValue(KeyInputFocusProperty);
            }
            set
            {
                SetValue(KeyInputFocusProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Color)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The mutually exclusive with "backgroundColor" and "background" type Map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string BackgroundImage
        {
            get
            {
                return (string)GetValue(BackgroundImageProperty);
            }
            set
            {
                SetValue(BackgroundImageProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Get or set the border of background image.
        /// </summary>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle BackgroundImageBorder
        {
            get
            {
                return (Rectangle)GetValue(BackgroundImageBorderProperty);
            }
            set
            {
                SetValue(BackgroundImageBorderProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The background of view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Background
        {
            get
            {
                return (PropertyMap)GetValue(BackgroundProperty);
            }
            set
            {
                SetValue(BackgroundProperty, value);
                NotifyPropertyChanged();
            }
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
                return (ImageShadow)GetValue(ImageShadowProperty);
            }
            set
            {
                SetValue(ImageShadowProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Shadow)GetValue(BoxShadowProperty);
            }
            set
            {
                SetValue(BoxShadowProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Vector4)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether the CornerRadius property value is relative (percentage [0.0f to 0.5f] of the view size) or absolute (in world units).
        /// It is absolute by default.
        /// When the policy is relative, the corner radius is relative to the smaller of the view's width and height.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public VisualTransformPolicyType CornerRadiusPolicy
        {
            get => (VisualTransformPolicyType)GetValue(CornerRadiusPolicyProperty);
            set => SetValue(CornerRadiusPolicyProperty, value);
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
                return (float)GetValue(BorderlineWidthProperty);
            }
            set
            {
                SetValue(BorderlineWidthProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Color)GetValue(BorderlineColorProperty);
            }
            set
            {
                SetValue(BorderlineColorProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(BorderlineOffsetProperty);
            }
            set
            {
                SetValue(BorderlineOffsetProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The current state of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public States State
        {
            get
            {
                return (States)GetValue(StateProperty);
            }
            set
            {
                SetValue(StateProperty, value);
                NotifyPropertyChanged();
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
                return (States)GetValue(SubStateProperty);
            }
            set
            {
                SetValue(SubStateProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Displays a tooltip
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Tooltip
        {
            get
            {
                return (PropertyMap)GetValue(TooltipProperty);
            }
            set
            {
                SetValue(TooltipProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Displays a tooltip as a text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TooltipText
        {
            get
            {
                return GetValue(TooltipTextProperty) as string;
            }
            set
            {
                SetValue(TooltipTextProperty, value);
            }
        }

        private string InternalTooltipText
        {
            get
            {
                using (var propertyValue = GetProperty(Property.TOOLTIP))
                {
                    if (propertyValue != null && propertyValue.Get(out string retrivedValue))
                    {
                        return retrivedValue;
                    }
                    NUILog.Error($"[ERROR] Fail to get TooltipText! Return error MSG (error to get TooltipText)!");
                    return "error to get TooltipText";
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
                return (float)GetValue(FlexProperty);
            }
            set
            {
                SetValue(FlexProperty, value);
                NotifyPropertyChanged();
            }
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
                return (int)GetValue(AlignSelfProperty);
            }
            set
            {
                SetValue(AlignSelfProperty, value);
                NotifyPropertyChanged();
            }
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
                Vector4 temp = (Vector4)GetValue(FlexMarginProperty);
                return new Vector4(OnFlexMarginChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                SetValue(FlexMarginProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Vector2)GetValue(CellIndexProperty);
            }
            set
            {
                SetValue(CellIndexProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The number of rows this child occupies, if not set, the default value is 1.
        /// </summary>
        /// <remarks>
        /// This property is for <see cref="TableView"/> class. Please use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float RowSpan
        {
            get
            {
                return (float)GetValue(RowSpanProperty);
            }
            set
            {
                SetValue(RowSpanProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The number of columns this child occupies, if not set, the default value is 1.
        /// </summary>
        /// <remarks>
        /// This property is for <see cref="TableView"/> class. Please use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public float ColumnSpan
        {
            get
            {
                return (float)GetValue(ColumnSpanProperty);
            }
            set
            {
                SetValue(ColumnSpanProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The horizontal alignment of this child inside the cells, if not set, the default value is 'left'.
        /// </summary>
        /// <remarks>
        /// This property is for <see cref="TableView"/> class. Please use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.HorizontalAlignmentType CellHorizontalAlignment
        {
            get
            {
                return (HorizontalAlignmentType)GetValue(CellHorizontalAlignmentProperty);
            }
            set
            {
                SetValue(CellHorizontalAlignmentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The vertical alignment of this child inside the cells, if not set, the default value is 'top'.
        /// </summary>
        /// <remarks>
        /// This property is for <see cref="TableView"/> class. Please use the property for the child position of <see cref="TableView"/>.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.VerticalAlignmentType CellVerticalAlignment
        {
            get
            {
                return (VerticalAlignmentType)GetValue(CellVerticalAlignmentProperty);
            }
            set
            {
                SetValue(CellVerticalAlignmentProperty, value);
                NotifyPropertyChanged();
            }
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
                return (View)GetValue(LeftFocusableViewProperty);
            }
            set
            {
                SetValue(LeftFocusableViewProperty, value);
                NotifyPropertyChanged();
            }
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
                return (View)GetValue(RightFocusableViewProperty);
            }
            set
            {
                SetValue(RightFocusableViewProperty, value);
                NotifyPropertyChanged();
            }
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
                return (View)GetValue(UpFocusableViewProperty);
            }
            set
            {
                SetValue(UpFocusableViewProperty, value);
                NotifyPropertyChanged();
            }
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
                return (View)GetValue(DownFocusableViewProperty);
            }
            set
            {
                SetValue(DownFocusableViewProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether the view should be focusable by keyboard navigation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Focusable
        {
            set
            {
                SetValue(FocusableProperty, value);
                NotifyPropertyChanged();
            }
            get
            {
                return (bool)GetValue(FocusableProperty);
            }
        }

        /// <summary>
        /// Whether the children of this view can be focusable by keyboard navigation. If user sets this to false, the children of this actor view will not be focused.
        /// Note : Default value is true.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FocusableChildren
        {
            set
            {
                SetValue(FocusableChildrenProperty, value);
                NotifyPropertyChanged();
            }
            get
            {
                return (bool)GetValue(FocusableChildrenProperty);
            }
        }

        /// <summary>
        /// Whether this view can focus by touch.
        /// If Focusable is false, FocusableInTouch is disabled.
        /// If you want to have focus on touch, you need to set both Focusable and FocusableInTouch settings to true.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FocusableInTouch
        {
            set
            {
                SetValue(FocusableInTouchProperty, value);
                NotifyPropertyChanged();
            }
            get
            {
                return (bool)GetValue(FocusableInTouchProperty);
            }
        }

        /// <summary>
        ///  Retrieves the position of the view.<br />
        ///  The coordinates are relative to the view's parent.<br />
        /// </summary>
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
                var temp = (Size2D)GetValue(Size2DProperty);

                if (this.Layout == null)
                {
                    if (temp.Width < 0) { temp.Width = 0; }
                    if (temp.Height < 0) { temp.Height = 0; }
                }

                return temp;
            }
            set
            {
                SetValue(Size2DProperty, value);

                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ///  Retrieves the size of the view.<br />
        ///  The coordinates are relative to the view's parent.<br />
        /// </summary>
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
                return (float)GetValue(OpacityProperty);
            }
            set
            {
                SetValue(OpacityProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Position2D)GetValue(Position2DProperty);
            }
            set
            {
                SetValue(Position2DProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Retrieves the screen position of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenPosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                var pValue = GetProperty(View.Property.ScreenPosition);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
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
                return (bool)GetValue(PositionUsesPivotPointProperty);
            }
            set
            {
                SetValue(PositionUsesPivotPointProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Deprecated in API5; Will be removed in API8. Please use PositionUsesPivotPoint instead!
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API5; Will be removed in API8. Please use PositionUsesPivotPoint instead! " +
            "Like: " +
            "View view = new View(); " +
            "view.PivotPoint = PivotPoint.Center; " +
            "view.PositionUsesPivotPoint = true;" +
            " Deprecated in API5: Will be removed in API8")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PositionUsesAnchorPoint
        {
            get
            {
                return (bool)GetValue(PositionUsesAnchorPointProperty);
            }
            set
            {
                SetValue(PositionUsesAnchorPointProperty, value);
            }
        }

        private bool InternalPositionUsesAnchorPoint
        {
            get
            {
                bool temp = false;
                var pValue = GetProperty(View.Property.PositionUsesAnchorPoint);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.PositionUsesAnchorPoint, temp);
                temp.Dispose();
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
                return (int)GetValue(SiblingOrderProperty);
            }
            set
            {
                SetValue(SiblingOrderProperty, value);

                Layout?.ChangeLayoutSiblingOrder(value);

                NotifyPropertyChanged();
            }
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

                Size2D sz = new Size2D((int)temp.Width, (int)temp.Height);
                temp.Dispose();
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
                Position tmp = (Position)GetValue(ParentOriginProperty);
                return new Position(OnParentOriginChanged, tmp.X, tmp.Y, tmp.Z);
            }
            set
            {
                SetValue(ParentOriginProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Position)GetValue(PivotPointProperty);
            }
            set
            {
                SetValue(PivotPointProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(SizeWidthProperty);
            }
            set
            {
                SetValue(SizeWidthProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(SizeHeightProperty);
            }
            set
            {
                SetValue(SizeHeightProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Position)GetValue(PositionProperty);
            }
            set
            {
                SetValue(PositionProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(PositionXProperty);
            }
            set
            {
                SetValue(PositionXProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(PositionYProperty);
            }
            set
            {
                SetValue(PositionYProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(PositionZProperty);
            }
            set
            {
                SetValue(PositionZProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the world position of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 WorldPosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                var pValue = GetProperty(View.Property.WorldPosition);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
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
                return (Rotation)GetValue(OrientationProperty);
            }
            set
            {
                SetValue(OrientationProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Vector3)GetValue(ScaleProperty);
            }
            set
            {
                SetValue(ScaleProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(ScaleXProperty);
            }
            set
            {
                SetValue(ScaleXProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(ScaleYProperty);
            }
            set
            {
                SetValue(ScaleYProperty, value);
                NotifyPropertyChanged();
            }
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
                return (float)GetValue(ScaleZProperty);
            }
            set
            {
                SetValue(ScaleZProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the world scale of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 WorldScale
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                var pValue = GetProperty(View.Property.WorldScale);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
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
                bool temp = false;
                var pValue = GetProperty(View.Property.VISIBLE);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
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
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                var pValue = GetProperty(View.Property.WorldColor);
                pValue.Get(temp);
                pValue.Dispose();
                return temp;
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
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
                NotifyPropertyChanged();
            }
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
        /// Gets the view's ID.
        /// Read-only
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
                return (bool)GetValue(SensitiveProperty);
            }
            set
            {
                SetValue(SensitiveProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the view should receive a notification when touch or hover motion events leave the boundary of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool LeaveRequired
        {
            get
            {
                return (bool)GetValue(LeaveRequiredProperty);
            }
            set
            {
                SetValue(LeaveRequiredProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether a child view inherits it's parent's orientation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritOrientation
        {
            get
            {
                return (bool)GetValue(InheritOrientationProperty);
            }
            set
            {
                SetValue(InheritOrientationProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether a child view inherits it's parent's scale.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritScale
        {
            get
            {
                return (bool)GetValue(InheritScaleProperty);
            }
            set
            {
                SetValue(InheritScaleProperty, value);
                NotifyPropertyChanged();
            }
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
                return (DrawModeType)GetValue(DrawModeProperty);
            }
            set
            {
                SetValue(DrawModeProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Vector3)GetValue(SizeModeFactorProperty);
            }
            set
            {
                SetValue(SizeModeFactorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the width resize policy to be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResizePolicyType WidthResizePolicy
        {
            get
            {
                return (ResizePolicyType)GetValue(WidthResizePolicyProperty);
            }
            set
            {
                SetValue(WidthResizePolicyProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the height resize policy to be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResizePolicyType HeightResizePolicy
        {
            get
            {
                return (ResizePolicyType)GetValue(HeightResizePolicyProperty);
            }
            set
            {
                SetValue(HeightResizePolicyProperty, value);
                NotifyPropertyChanged();
            }
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
                return (SizeScalePolicyType)GetValue(SizeScalePolicyProperty);
            }
            set
            {
                SetValue(SizeScalePolicyProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ///  Gets or sets the status of whether the width size is dependent on the height size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool WidthForHeight
        {
            get
            {
                return (bool)GetValue(WidthForHeightProperty);
            }
            set
            {
                SetValue(WidthForHeightProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the height size is dependent on the width size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool HeightForWidth
        {
            get
            {
                return (bool)GetValue(HeightForWidthProperty);
            }
            set
            {
                SetValue(HeightForWidthProperty, value);
                NotifyPropertyChanged();
            }
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
                // If View has a Layout then padding in stored in the base Layout class
                if (Layout != null)
                {
                    return Layout.Padding;
                }
                else
                {
                    return (Extents)GetValue(PaddingProperty);
                }
                // Two return points to prevent creating a zeroed Extent native object before assignment
            }
            set
            {
                Extents padding = value;
                if (Layout != null)
                {
                    // Layout set so store Padding in LayoutItem instead of in View.
                    // If View stores the Padding value then Legacy Size Negotiation will overwrite
                    // the position and sizes measure in the Layouting.
                    Layout.Padding = value;
                    // If Layout is a LayoutItem then it could be a View that handles it's own padding.
                    // Let the View keeps it's padding.  Still store Padding in Layout to reduce code paths.
                    if (typeof(LayoutGroup).IsAssignableFrom(Layout.GetType())) // If a Layout container of some kind.
                    {
                        padding = new Extents(0, 0, 0, 0); // Reset value stored in View.
                    }
                }

                SetValue(PaddingProperty, padding);
                NotifyPropertyChanged();
            }
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
                return (Size2D)GetValue(MinimumSizeProperty);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                if (layout != null)
                {
                    // Note: it only works if minimum size is >= than natural size.
                    // To force the size it should be done through the width&height spec or Size2D.
                    layout.MinimumWidth = new Tizen.NUI.LayoutLength(value.Width);
                    layout.MinimumHeight = new Tizen.NUI.LayoutLength(value.Height);
                    layout.RequestLayout();
                }
                SetValue(MinimumSizeProperty, value);
                NotifyPropertyChanged();
            }
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
                return (Size2D)GetValue(MaximumSizeProperty);
            }
            set
            {
                // We don't have Layout.Maximum(Width|Height) so we cannot apply it to layout.
                // MATCH_PARENT spec + parent container size can be used to limit
                if (layout != null)
                {
                    layout.RequestLayout();
                }
                SetValue(MaximumSizeProperty, value);
                NotifyPropertyChanged();
            }
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
                return (bool)GetValue(InheritPositionProperty);
            }
            set
            {
                SetValue(InheritPositionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the clipping behavior (mode) of it's children.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ClippingModeType ClippingMode
        {
            get
            {
                return (ClippingModeType)GetValue(ClippingModeProperty);
            }
            set
            {
                SetValue(ClippingModeProperty, value);
                NotifyPropertyChanged();
            }
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
        /// Deprecated in API5; Will be removed in API8. Please use PivotPoint instead!
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (view.AnchorPoint.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API5; Will be removed in API8. Please use PivotPoint instead! " +
            "Like: " +
            "View view = new View(); " +
            "view.PivotPoint = PivotPoint.Center; " +
            "view.PositionUsesPivotPoint = true;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position AnchorPoint
        {
            get
            {
                return GetValue(AnchorPointProperty) as Position;
            }
            set
            {
                SetValue(AnchorPointProperty, value);
            }
        }

        private Position InternalAnchorPoint
        {
            get
            {
                Position temp = new Position(0.0f, 0.0f, 0.0f);
                var pValue = GetProperty(View.Property.AnchorPoint);
                pValue.Get(temp);
                pValue.Dispose();
                Position ret = new Position(OnAnchorPointChanged, temp.X, temp.Y, temp.Z);
                temp.Dispose();
                return ret;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.AnchorPoint, temp);
                temp.Dispose();
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
                return (Size)GetValue(SizeProperty);
            }
            set
            {
                SetValue(SizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Deprecated in API5; Will be removed in API8. Please use 'Container GetParent() for derived class' instead!
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated in API5; Will be removed in API8. Please use 'Container GetParent() for derived class' instead! " +
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
                return (bool)GetValue(InheritLayoutDirectionProperty);
            }
            set
            {
                SetValue(InheritLayoutDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets/Sets the layout Direction.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ViewLayoutDirectionType LayoutDirection
        {
            get
            {
                return (ViewLayoutDirectionType)GetValue(LayoutDirectionProperty);
            }
            set
            {
                SetValue(LayoutDirectionProperty, value);
                NotifyPropertyChanged();
                layout?.RequestLayout();
            }
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
                // If View has a Layout then margin is stored in Layout.
                if (Layout != null)
                {
                    return Layout.Margin;
                }
                else
                {
                    // If Layout not set then return margin stored in View.
                    return (Extents)GetValue(MarginProperty);
                }
                // Two return points to prevent creating a zeroed Extent native object before assignment
            }
            set
            {
                if (Layout != null)
                {
                    // Layout set so store Margin in LayoutItem instead of View.
                    // If View stores the Margin too then the Legacy Size Negotiation will
                    // overwrite the position and size values measured in the Layouting.
                    Layout.Margin = value;
                    SetValue(MarginProperty, new Extents(0, 0, 0, 0));
                    layout?.RequestLayout();
                }
                else
                {
                    SetValue(MarginProperty, value);
                }
                NotifyPropertyChanged();
                layout?.RequestLayout();
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
        public int WidthSpecification
        {
            get
            {
                return (int)GetValue(WidthSpecificationProperty);
            }
            set
            {
                SetValue(WidthSpecificationProperty, value);
                NotifyPropertyChanged();
            }
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
                    if (heightPolicy >= 0) // Policy an exact value
                    {
                        // Create Size2D only both _widthPolicy and _heightPolicy are set.
                        Size2D = new Size2D(widthPolicy, heightPolicy);
                    }
                }
                layout?.RequestLayout();
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
                return (int)GetValue(HeightSpecificationProperty);
            }
            set
            {
                SetValue(HeightSpecificationProperty, value);
                NotifyPropertyChanged();
            }
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
                    if (widthPolicy >= 0) // Policy an exact value
                    {
                        // Create Size2D only both _widthPolicy and _heightPolicy are set.
                        Size2D = new Size2D(widthPolicy, heightPolicy);
                    }
                }
                layout?.RequestLayout();
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
                if (layoutTransitions == null)
                {
                    layoutTransitions = new Dictionary<TransitionCondition, TransitionList>();
                }
                return layoutTransitions;
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
                return GetValue(LayoutTransitionProperty) as LayoutTransition;
            }
            set
            {
                SetValue(LayoutTransitionProperty, value);
                NotifyPropertyChanged();
            }
        }

        private LayoutTransition InternalLayoutTransition
        {
            get
            {
                return layoutTransition;
            }
            set
            {
                if (value == null)
                {
                    throw new global::System.ArgumentNullException(nameof(value));
                }
                if (layoutTransitions == null)
                {
                    layoutTransitions = new Dictionary<TransitionCondition, TransitionList>();
                }

                LayoutTransitionsHelper.AddTransitionForCondition(layoutTransitions, value.Condition, value, true);

                AttachTransitionsToChildren(value);

                layoutTransition = value;
            }
        }

        /// <summary>
        /// Deprecated in API5; Will be removed in API8. Please use Padding instead.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (view.DecorationBoundingBox.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API5; Will be removed in API8. Please use Padding instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents PaddingEX
        {
            get
            {
                return GetValue(PaddingEXProperty) as Extents;
            }
            set
            {
                SetValue(PaddingEXProperty, value);
            }
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
                layout?.RequestLayout();
            }
        }

        /// <summary>
        /// The Color of View. This is an RGBA value.
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
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
                NotifyPropertyChanged();
            }
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
                return GetValue(LayoutProperty) as LayoutItem;
            }
            set
            {
                SetValue(LayoutProperty, value);
            }
        }

        private LayoutItem InternalLayout
        {
            get
            {
                return layout;
            }
            set
            {
                // Do nothing if layout provided is already set on this View.
                if (value == layout)
                {
                    return;
                }

                LayoutingDisabled = false;
                layoutSet = true;

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
                if (layout != null) // Existing layout
                {
                    if (value != null)
                    {
                        // Existing layout being replaced so copy over margin and padding values.
                        value.Margin = layout.Margin;
                        value.Padding = layout.Padding;
                        value.SetPositionByLayout = !excludeLayouting;
                    }
                    else
                    {
                        // Layout not being replaced so restore margin and padding to View.
                        SetValue(MarginProperty, layout.Margin);
                        SetValue(PaddingProperty, layout.Padding);
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
                        if (margin.Top != 0 || margin.Bottom != 0 || margin.Start != 0 || margin.End != 0)
                        {
                            // If View already has a margin set then store it in Layout instead.
                            value.Margin = margin;
                            SetValue(MarginProperty, new Extents(0, 0, 0, 0));
                            NotifyPropertyChanged();
                        }

                        if (padding.Top != 0 || padding.Bottom != 0 || padding.Start != 0 || padding.End != 0)
                        {
                            // If View already has a padding set then store it in Layout instead.
                            value.Padding = padding;

                            // If Layout is a LayoutItem then it could be a View that handles it's own padding.
                            // Let the View keeps it's padding.  Still store Padding in Layout to reduce code paths.
                            if (typeof(LayoutGroup).IsAssignableFrom(value.GetType()))
                            {
                                SetValue(PaddingProperty, new Extents(0, 0, 0, 0));
                                NotifyPropertyChanged();
                            }
                        }

                        value.SetPositionByLayout = !excludeLayouting;
                    }
                }

                // Remove existing layout from it's parent layout group.
                layout?.Unparent();

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
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                layout?.RequestLayout();
            }
        }

        /// <summary>
        ///  Whether to load the BackgroundImage synchronously.
        ///  If not specified, the default is false, i.e. the BackgroundImage is loaded asynchronously.
        ///  Note: For Normal Quad images only.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BackgroundImageSynchronosLoading
        {
            get
            {
                return (bool)GetValue(BackgroundImageSynchronosLoadingProperty);
            }
            set
            {
                SetValue(BackgroundImageSynchronosLoadingProperty, value);
                NotifyPropertyChanged();
            }
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
        /// This will be public opened in tizen_7.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BackgroundImageSynchronousLoading
        {
            get
            {
                return (bool)GetValue(BackgroundImageSynchronousLoadingProperty);
            }
            set
            {
                SetValue(BackgroundImageSynchronousLoadingProperty, value);
                NotifyPropertyChanged();
            }
        }

        private bool InternalBackgroundImageSynchronousLoading
        {
            get
            {
                return backgroundImageSynchronousLoading;
            }
            set
            {
                backgroundImageSynchronousLoading = value;

                string bgUrl = null;
                var pValue = Background.Find(ImageVisualProperty.URL);
                pValue?.Get(out bgUrl);
                pValue?.Dispose();

                if (!string.IsNullOrEmpty(bgUrl))
                {
                    PropertyMap bgMap = this.Background;
                    var temp = new PropertyValue(backgroundImageSynchronousLoading);
                    bgMap[ImageVisualProperty.SynchronousLoading] = temp;
                    temp.Dispose();
                    Background = bgMap;
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 UpdateSizeHint
        {
            get
            {
                return (Vector2)GetValue(UpdateSizeHintProperty);
            }
            set
            {
                SetValue(UpdateSizeHintProperty, value);
                NotifyPropertyChanged();
            }
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
                return (bool)GetValue(EnableControlStatePropagationProperty);
            }
            set
            {
                SetValue(EnableControlStatePropagationProperty, value);
                NotifyPropertyChanged();
            }
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
        /// By default, it is false in View, true in Control.
        /// Note that if the value is true, the View will be a touch receptor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableControlState
        {
            get
            {
                return (bool)GetValue(EnableControlStateProperty);
            }
            set
            {
                SetValue(EnableControlStateProperty, value);
            }
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
                return (bool)GetValue(GrabTouchAfterLeaveProperty);
            }
            set
            {
                SetValue(GrabTouchAfterLeaveProperty, value);
            }
        }

        private bool InternalGrabTouchAfterLeave
        {
            get
            {
                bool temp = false;
                var pValue = GetProperty(View.Property.CaptureAllTouchAfterStart);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.CaptureAllTouchAfterStart, temp);
                temp.Dispose();
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Determines which blend equation will be used to render renderers of this actor.
        /// </summary>
        /// <returns>blend equation enum currently assigned</returns>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendEquationType BlendEquation
        {
            get
            {
                return (BlendEquationType)GetValue(BlendEquationProperty);
            }
            set
            {
                SetValue(BlendEquationProperty, value);
            }
        }

        private BlendEquationType InternalBlendEquation
        {
            get
            {
                int temp = 0;
                var pValue = GetProperty(View.Property.BlendEquation);
                pValue.Get(out temp);
                pValue.Dispose();
                return (BlendEquationType)temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue((int)value);
                SetProperty(View.Property.BlendEquation, temp);
                temp.Dispose();
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
            get => (bool)GetValue(ThemeChangeSensitiveProperty);
            set => SetValue(ThemeChangeSensitiveProperty, value);
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
                if (isThemeChanged && ChangedPropertiesSetExcludingStyle.Contains(destinationProperty))
                {
                    continue;
                }

                if (destinationProperty != null)
                {
                    InternalSetValue(destinationProperty, sourceValue);
                }
            }
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
                bool temp = false;
                var pValue = GetProperty(View.Property.Culled);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
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
                return GetValue(TransitionOptionsProperty) as TransitionOptions;
            }
            set
            {
                SetValue(TransitionOptionsProperty, value);
                NotifyPropertyChanged();
            }
        }

        private TransitionOptions InternalTransitionOptions
        {
            set
            {
                transitionOptions = value;
            }
            get
            {
                return transitionOptions;
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the view should emit key event signals.
        /// If a View's DispatchKeyEvents is set to false, then it's children will not emit a key event signal either.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DispatchKeyEvents
        {
            get
            {
                return (bool)GetValue(DispatchKeyEventsProperty);
            }
            set
            {
                SetValue(DispatchKeyEventsProperty, value);
                NotifyPropertyChanged();
            }
        }




    }
}
