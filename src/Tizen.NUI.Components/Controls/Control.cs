﻿/*
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
        /// <summary>
        /// Control style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected string style;

        private TapGestureDetector tapGestureDetector = new TapGestureDetector();
        private bool isFocused = false;

        internal ImageView backgroundImage;
        internal ImageView shadowImage;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlStyle Style => ViewStyle as ControlStyle;

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
        /// Construct with attributes
        /// </summary>
        /// <param name="attributes">Create attributes customized by user</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control(ControlStyle controlStyle) : base(controlStyle)
        {
            Initialize(null);
        }

        /// <summary>
        /// Construct with style
        /// </summary>
        /// <param name="style">Style to be applied</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control(string style) : base()
        {
            Initialize(style);
        }

        public new Selector<string> BackgroundImage
        {
            get
            {
                return Style.Background.ResourceUrl;
            }
            set
            {
                Style.Background.ResourceUrl = value;
            }
        }

        public Selector<Rectangle> BackgroundBorder
        {
            get
            {
                return Style.Background.Border;
            }
            set
            {
                Style.Background.Border = value;
            }
        }

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
        internal bool StateFocusableOnTouchMode
        {
            get;
            set;
        }

        internal bool IsFocused
        {
            get
            {
                return isFocused || HasFocus();
            }
        }

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
                    shadowImage = new ImageView();
                    this.Add(shadowImage);
                }

                shadowImage.ApplyStyle(controlStyle.Shadow);
            }

            if (null != controlStyle?.Background)
            {
                if (null == backgroundImage)
                {
                    backgroundImage = new ImageView();
                    this.Add(backgroundImage);
                }
                backgroundImage.ApplyStyle(controlStyle.Background);
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
        protected virtual void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
        }
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
        protected virtual void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void RegisterDetectionOfSubstyleChanges()
        {

        }

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

        private ViewStyle GetAttributes(string style)
        {
            ViewStyle attributes = StyleManager.Instance.GetAttributes(style);
            if(attributes == null)
            {
                throw new InvalidOperationException($"There is no style {style}");
            }
            this.style = style;
            return attributes;
        }
    }
}
