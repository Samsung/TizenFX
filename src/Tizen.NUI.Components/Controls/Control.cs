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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The control component is base class of tv nui components. It's abstract class, so cann't instantiate and can only be inherited.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Control : VisualView
    {
        /// <summary> BackgroundImageProperty</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create("ControlBackgroundImage", typeof(Selector<string>), typeof(Control), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (Control)bindable;
            if (null != newValue)
            {
                control.BackgroundImageSelector.Clone((Selector<string>)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var control = (Control)bindable;
            return control.BackgroundImageSelector;
        });
        /// <summary>BackgroundBorderProperty</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty BackgroundImageBorderProperty = BindableProperty.Create("ControlBackgroundImageBorder", typeof(Selector<Rectangle>), typeof(Control), default(Rectangle), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (Control)bindable;
            if (null != newValue)
            {
                control.backgroundImageBorderSelector.Clone((Selector<Rectangle>)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var control = (Control)bindable;
            return control.backgroundImageBorderSelector;
        });
        /// <summary> BackgroundColorProperty </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create("ControlBackgroundColor", typeof(Selector<Color>), typeof(Control), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (Control)bindable;
            if (null != newValue)
            {
                control.BackgroundColorSelector.Clone((Selector<Color>)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var control = (Control)bindable;
            return control.BackgroundColorSelector;
        });
        /// <summary> Control style. </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected string style;

        private TapGestureDetector tapGestureDetector = new TapGestureDetector();
        private bool isFocused = false;

        internal ImageView backgroundImage = new ImageView();
        internal ImageView shadowImage;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlStyle Style => ViewStyle as ControlStyle;

        static Control() { }

        /// <summary>
        /// Construct an empty Control.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control() : base()
        {
            Initialize(null);
        }

        /// <summary>
        /// Construct with style.
        /// </summary>
        /// <param name="style">Create control with style.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control(ControlStyle style) : base(style)
        {
            Initialize(null);
        }

        /// <summary>
        /// Construct with styleSheet
        /// </summary>
        /// <param name="styleSheet">StyleSheet to be applied</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control(string styleSheet) : base()
        {
            ViewStyle viewStyle = StyleManager.Instance.GetViewStyle(styleSheet);
            if (viewStyle == null)
            {
                throw new InvalidOperationException($"There is no style {styleSheet}");
            }

            ApplyStyle(viewStyle);
            this.style = styleSheet;

            Initialize(style);
        }

        private TriggerableSelector<string> _backgroundImageSelector;
        private TriggerableSelector<string> BackgroundImageSelector
        {
            get
            {
                if (null == _backgroundImageSelector)
                {
                    _backgroundImageSelector = new TriggerableSelector<string>(backgroundImage, ImageView.ResourceUrlProperty);
                }
                return _backgroundImageSelector;
            }
        }
        private TriggerableSelector<Rectangle> _backgroundImageBorderSelector;
        private TriggerableSelector<Rectangle> backgroundImageBorderSelector
        {
            get
            {
                if (null == _backgroundImageBorderSelector)
                {
                    _backgroundImageBorderSelector = new TriggerableSelector<Rectangle>(backgroundImage, ImageView.BorderProperty);
                }
                return _backgroundImageBorderSelector;
            }
        }
        private TriggerableSelector<Color> _backgroundColorSelector;
        private TriggerableSelector<Color> BackgroundColorSelector
        {
            get
            {
                if (null == _backgroundColorSelector)
                {
                    _backgroundColorSelector = new TriggerableSelector<Color>(backgroundImage, View.BackgroundColorProperty);
                }
                return _backgroundColorSelector;
            }
        }
        /// <summary>
        /// Override view's BackgroundImage.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Selector<string> BackgroundImage
        {
            get => (Selector<string>)GetValue(BackgroundImageProperty);
            set => SetValue(BackgroundImageProperty, value);
        }

        /// <summary>
        /// Override view's BackgroundImageBorder.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Selector<Rectangle> BackgroundImageBorder
        {
            get => (Selector<Rectangle>)GetValue(BackgroundImageBorderProperty);
            set => SetValue(BackgroundImageBorderProperty, value);
        }
        /// <summary>
        /// Override view's BackgroundBorder.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Selector<Color> BackgroundColor
        {
            get => (Selector<Color>)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        /// <summary>
        /// Shadow image.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> ShadowImage
        {
            get
            {
                return Style.Shadow.ResourceUrl;
            }
            set
            {
                Style.Shadow.ResourceUrl = value;
            }
        }

        /// <summary>
        /// Shadow image border.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> ShadowImageBorder
        {
            get
            {
                return Style.Shadow.Border;
            }
            set
            {
                Style.Shadow.Border = value;
            }
        }

        internal void ApplyAttributes(View view, ViewStyle viewStyle)
        {
            view.CopyFrom(viewStyle);
        }

        /// <summary>
        /// Whether focusable when touch
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal bool StateFocusableOnTouchMode { get; set; }

        internal bool IsFocused => (isFocused || HasFocus());

        /// <summary>
        /// Dispose Control and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                StyleManager.Instance.ThemeChangedEvent -= OnThemeChangedEvent;
                tapGestureDetector.Detected -= OnTapGestureDetected;
                tapGestureDetector.Detach(this);
            }

            if (backgroundImage != null)
            {
                Utility.Dispose(backgroundImage);
            }
            if (shadowImage != null)
            {
                Utility.Dispose(shadowImage);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnKey(Key key)
        {
            return false;
        }

        /// <summary>
        /// Called after the size negotiation has been finished for this control.<br />
        /// The control is expected to assign this given size to itself or its children.<br />
        /// Should be overridden by derived classes if they need to layout views differently after certain operations like add or remove views, resize, or after changing specific properties.<br />
        /// As this function is called from inside the size negotiation algorithm, you cannot call RequestRelayout (the call would just be ignored).<br />
        /// </summary>
        /// <param name="size">The allocated size.</param>
        /// <param name="container">The control should add views to this container that it is not able to allocate a size for.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            OnUpdate();
        }

        /// <summary>
        /// Called when the control gain key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is gained.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusGained()
        {
            isFocused = true;
        }

        /// <summary>
        /// Called when the control loses key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is lost.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusLost()
        {
            isFocused = false;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            ControlStyle controlStyle = viewStyle as ControlStyle;

            if (null != controlStyle?.Shadow)
            {
                if (null == shadowImage)
                {
                    shadowImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                    };
                    this.Add(shadowImage);
                    shadowImage.LowerToBottom();
                }

                shadowImage.ApplyStyle(controlStyle.Shadow);
            }
            if (null != controlStyle.BackgroundImage)
            {
                backgroundImage.WidthResizePolicy = ResizePolicyType.FillToParent;
                backgroundImage.HeightResizePolicy = ResizePolicyType.FillToParent;
                this.Add(backgroundImage);
            }
        }

        /// <summary>
        /// Tap gesture callback.
        /// </summary>
        /// <param name="source">The sender</param>
        /// <param name="e">The tap gesture event data</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e) { }

        /// <summary>
        /// Called after a touch event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="touch">The touch event.</param>
        /// <returns>True if the event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnTouch(Touch touch)
        {
            return false;
        }

        /// <summary>
        /// Update by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnUpdate()
        {
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e) { }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void RegisterDetectionOfSubstyleChanges() { }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new ControlStyle();
        }

        private void Initialize(string style)
        {
            ControlState = ControlStates.Normal;

            RegisterDetectionOfSubstyleChanges();

            LeaveRequired = true;

            StateFocusableOnTouchMode = false;

            tapGestureDetector.Attach(this);
            tapGestureDetector.Detected += OnTapGestureDetected;

            StyleManager.Instance.ThemeChangedEvent += OnThemeChangedEvent;
        }
    }
}
