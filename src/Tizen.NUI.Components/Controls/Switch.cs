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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Switch is one kind of common component, it can be used as selector.
    /// User can handle Navigation by adding/inserting/deleting NavigationItem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Switch : Button
    {
        private ImageView trackImage;
        private ImageView thumbImage;
        static Switch() { }

        /// <summary>
        /// Creates a new instance of a Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Switch() : base()
        {
            Initialize(Extension as SwitchExtension);
        }

        /// <summary>
        /// Creates a new instance of a Switch with style.
        /// </summary>
        /// <param name="style">Create Switch by special style defined in UX.</param>
        /// <since_tizen> 8 </since_tizen>
        public Switch(string style) : base(style)
        {
            Initialize(Extension as SwitchExtension);
        }

        /// <summary>
        /// Creates a new instance of a Switch with style.
        /// </summary>
        /// <param name="switchStyle">Create Switch by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public Switch(SwitchStyle switchStyle) : base(switchStyle)
        {
            Initialize(Extension as SwitchExtension);
        }

        /// <summary>
        /// Creates a new instance of a Switch with custom extension.
        /// </summary>
        /// <param name="extension">A custom extension for the Switch.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Switch(SwitchExtension extension) : base(extension)
        {
            Initialize(extension);
        }

        /// <summary>
        /// Creates a new instance of a Switch with style and a custom extension.
        /// </summary>
        /// <param name="switchStyle">Create Switch by style customized by user.</param>
        /// <param name="extension">A custom extension for the Switch.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Switch(SwitchStyle switchStyle, SwitchExtension extension) : base(switchStyle, extension)
        {
            Initialize(extension);
        }

        /// <summary>
        /// An event for the item selected signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<SelectEventArgs> SelectedEvent;

        /// <summary>
        /// Get style of switch.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public new SwitchStyle Style => ViewStyle as SwitchStyle;

        /// <summary>
        /// Background image's resource url in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SwitchBackgroundImageURL
        {
            get
            {
                return Style?.Track?.ResourceUrl?.All;
            }
            set
            {
                if (null != value && null != Style?.Track)
                {
                    Style.Track.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// Background image's resource url selector in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector SwitchBackgroundImageURLSelector
        {
            get
            {
                StringSelector strSl = new StringSelector();
                strSl.Clone(Style?.Track?.ResourceUrl);
                return strSl;
            }
            set
            {
                if (null != value && null != Style?.Track)
                {
                    Style.Track.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// Handler image's resource url in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string SwitchHandlerImageURL
        {
            get
            {
                return Style?.Thumb?.ResourceUrl?.All;
            }
            set
            {
                if (null != value && null != Style?.Thumb)
                {
                    Style.Thumb.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// Handler image's resource url selector in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector SwitchHandlerImageURLSelector
        {
            get
            {
                StringSelector strSl = new StringSelector();
                strSl.Clone(Style?.Thumb?.ResourceUrl);
                return strSl;
            }
            set
            {
                if (null != value && null != Style?.Thumb)
                {
                    Style.Thumb.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// Handler image's size in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size SwitchHandlerImageSize
        {
            get
            {
                return Style?.Thumb?.Size;
            }
            set
            {
                if (null != Style?.Thumb)
                {
                    Style.Thumb.Size = value;
                }
            }
        }

        /// <summary>
        /// Dispose Switch and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed) return;

            if (type == DisposeTypes.Explicit)
            {
                Utility.Dispose(thumbImage);
                Utility.Dispose(trackImage);
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
            if (!IsEnabled || null == key) return false;

            bool ret = base.OnKey(key);
            if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    OnSelect();
                }
            }

            return ret;
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
            if(!IsEnabled || null == touch) return false;

            PointStateType state = touch.GetState(0);
            bool ret = base.OnTouch(touch);
            switch (state)
            {
                case PointStateType.Up:
                    OnSelect();
                    break;
                default:
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Get Switch style.
        /// </summary>
        /// <returns>The default switch style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle GetViewStyle()
        {
            return new SwitchStyle();
        }

        /// <summary>
        /// Get default SwitchExtension for this class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ButtonExtension GetDefaultExtension()
        {
            return new Switch.DefaultExtension();
        }

        private void Initialize(SwitchExtension extension)
        {
            Style.IsSelectable = true;

            trackImage = new ImageView();
            extension?.OnCreateTrack(this, ref trackImage, Style.Track);
            if (null != trackImage)
            {
                Add(trackImage);
                trackImage.ApplyStyle(Style.Track);
            }

            thumbImage = new ImageView();
            extension?.OnCreateThumb(this, ref thumbImage, Style.Thumb);
            if (null != thumbImage)
            {
                Add(thumbImage);
                thumbImage.ApplyStyle(Style.Thumb);
            }
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        /// <since_tizen> 8 </since_tizen>
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            SwitchStyle switchStyle = StyleManager.Instance.GetViewStyle(style) as SwitchStyle;
            if (null != switchStyle)
            {
                Style.CopyFrom(switchStyle);
            }
        }

        private void OnSelect()
        {
            if (SelectedEvent != null)
            {
                SelectEventArgs eventArgs = new SelectEventArgs();
                eventArgs.IsSelected = IsSelected;
                SelectedEvent(this, eventArgs);
            }
        }

        /// <summary>
        /// SelectEventArgs is a class to record item selected arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class SelectEventArgs : EventArgs
        {
            /// <summary> Select state of Switch </summary>
            /// <since_tizen> 6 </since_tizen>
            public bool IsSelected;
        }

        internal override ButtonExposer GetExposer()
        {
            return new SwitchExposer(this);
        }

        /// <summary>
        /// SwitchExposer helps SwitchExtension to access inside of a Switch.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SwitchExposer : Button.ButtonExposer
        {
            internal SwitchExposer(Switch switchButton) : base(switchButton)
            {
            }

            /// <summary>
            /// Expose Switch's overlay track part.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ImageView Track => (Button as Switch)?.trackImage;

            /// <summary>
            /// Expose Switch's overlay track part.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ImageView Thumb => (Button as Switch)?.thumbImage;
        }

        /// <summary>
        /// The Switch.DefaultExtension class implements SwitchExtension to define a thumb animation.
        /// </summary>
        internal class DefaultExtension : SwitchExtension
        {
            private Animation selectAnimation;

            public override void OnClick(Button.ButtonExposer buttonExposer, Touch clickUp)
            {
                var thumb = (buttonExposer as SwitchExposer)?.Thumb;

                if (null == thumb)
                {
                    return;
                }

                if (null == selectAnimation)
                {
                    selectAnimation = new Animation(100);
                }
                else if (selectAnimation.State == Animation.States.Playing)
                {
                    selectAnimation.Stop();
                }

                selectAnimation.Clear();
                selectAnimation.AnimateTo(thumb, "PositionX", ((SwitchExposer)buttonExposer).Track.Size.Width - thumb.Size.Width - thumb.Position.X);
                selectAnimation.Play();
            }

            public override void OnDisconnect(Button.ButtonExposer buttonExposer)
            {
                if (null != selectAnimation)
                {
                    if (selectAnimation.State == Animation.States.Playing)
                    {
                        selectAnimation.Stop();
                    }
                    selectAnimation.Dispose();
                    selectAnimation = null;
                }
            }
        }
    }
}
