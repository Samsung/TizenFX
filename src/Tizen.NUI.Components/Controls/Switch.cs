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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Switch is one kind of common component, it can be used as selector.
    /// User can handle Navigation by adding/inserting/deleting NavigationItem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Switch : Button
    {
        private ImageView track = null;
        private ImageView thumb = null;

        static Switch() { }

        /// <summary>
        /// Creates a new instance of a Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Switch() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Switch with style.
        /// </summary>
        /// <param name="style">Create Switch by special style defined in UX.</param>
        /// <since_tizen> 8 </since_tizen>
        public Switch(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Switch with style.
        /// </summary>
        /// <param name="switchStyle">Create Switch by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public Switch(SwitchStyle switchStyle) : base(switchStyle)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the item selected signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use SelectedChanged event instead.")]
        public event EventHandler<SelectEventArgs> SelectedEvent;

        /// <summary>
        /// An event for the item selected signal which can be used to subscribe or unsubscribe the event handler provided by the user.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<SelectedChangedEventArgs> SelectedChanged;

        /// <summary>
        /// Return a copied Style instance of Switch
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Switch.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public new SwitchStyle Style
        {
            get
            {
                var result = new SwitchStyle(ViewStyle as SwitchStyle);
                result.CopyPropertiesFromView(this);
                result.Track.CopyPropertiesFromView(Track);
                result.Thumb.CopyPropertiesFromView(Thumb);
                return result;
            }
        }

        /// <summary>
        /// Apply style to switch.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            SwitchStyle swStyle = viewStyle as SwitchStyle;

            if (null != swStyle)
            {
                if (swStyle.Track != null)
                {
                    Track.ApplyStyle(swStyle.Track);
                }

                if (swStyle.Thumb != null)
                {
                    Thumb.ApplyStyle(swStyle.Thumb);
                }
            }
        }

        /// <summary>
        /// Switch's track part.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageView Track
        {
            get
            {
                if (track == null)
                {
                    track = new ImageView()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };

                    var extension = (SwitchExtension)Extension;
                    if (extension != null)
                    {
                        track = extension.OnCreateTrack(this, track);
                    }
                    Add(track);
                }
                return track;
            }
            internal set
            {
                track = value;
            }
        }

        /// <summary>
        /// Switch's thumb part.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageView Thumb
        {
            get
            {
                if (thumb == null)
                {
                    thumb = new ImageView()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                        WidthResizePolicy = ResizePolicyType.Fixed,
                        HeightResizePolicy = ResizePolicyType.Fixed
                    };

                    var extension = (SwitchExtension)Extension;
                    if (extension != null)
                    {
                        thumb = extension.OnCreateThumb(this, thumb);
                    }
                    Add(thumb);
                }
                return thumb;
            }
            internal set
            {
                thumb = value;
            }
        }

        /// <summary>
        /// Background image's resource url selector in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector SwitchBackgroundImageURLSelector
        {
            get => track == null ? null : new StringSelector((Selector<string>)track.GetValue(ImageView.ResourceUrlSelectorProperty));
            set => track?.SetValue(ImageView.ResourceUrlSelectorProperty, value);
        }

        /// <summary>
        /// Handler image's resource url in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string SwitchHandlerImageURL
        {
            get
            {
                return Thumb.ResourceUrl;
            }
            set
            {
                Thumb.ResourceUrl = value;
            }
        }

        /// <summary>
        /// Handler image's resource url selector in Switch.
        /// Getter returns copied selector value if exist, null otherwise.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector SwitchHandlerImageURLSelector
        {
            get => thumb == null ? null : new StringSelector((Selector<string>)thumb.GetValue(ImageView.ResourceUrlSelectorProperty));
            set => thumb?.SetValue(ImageView.ResourceUrlSelectorProperty, value);
        }

        /// <summary>
        /// Handler image's size in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size SwitchHandlerImageSize
        {
            get
            {
                return Thumb.Size;
            }
            set
            {
                Thumb.Size = value;
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
                Utility.Dispose(Thumb);
                Utility.Dispose(Track);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 8 </since_tizen>
        public override bool OnKey(Key key)
        {
            return base.OnKey(key);
        }

        /// <summary>
        /// Called after a touch event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="touch">The touch event.</param>
        /// <returns>True if the event should be consumed.</returns>
        /// <since_tizen> 8 </since_tizen>
        public override bool OnTouch(Touch touch)
        {
            return base.OnTouch(touch);
        }

        /// <summary>
        /// Get Switch style.
        /// </summary>
        /// <returns>The default switch style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle CreateViewStyle()
        {
            return new SwitchStyle();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnControlStateChanged(ControlStateChangedEventArgs controlStateChangedInfo)
        {
            base.OnControlStateChanged(controlStateChangedInfo);

            if (!IsSelectable)
            {
                return;
            }

            bool previousSelected = controlStateChangedInfo.PreviousState.Contains(ControlState.Selected);

            if (previousSelected != IsSelected)
            {
                OnSelect();
            }
        }

        private void Initialize()
        {
            IsSelectable = true;
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            SwitchStyle switchStyle = StyleManager.Instance.GetViewStyle(StyleName) as SwitchStyle;
            if (null != switchStyle)
            {
                ApplyStyle(switchStyle);
            }
        }

        private void OnSelect()
        {
            ((SwitchExtension)Extension)?.OnSelectedChanged(this);

            if (SelectedEvent != null)
            {
                SelectEventArgs eventArgs = new SelectEventArgs();
                eventArgs.IsSelected = IsSelected;
                SelectedEvent(this, eventArgs);
            }

            if (SelectedChanged != null)
            {
                SelectedChangedEventArgs eventArgs = new SelectedChangedEventArgs();
                eventArgs.IsSelected = IsSelected;
                SelectedChanged(this, eventArgs);
            }
        }

        /// <summary>
        /// SelectEventArgs is a class to record item selected arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use SelectedChangedEventArgs instead.")]
        public class SelectEventArgs : EventArgs
        {
            /// <summary> Select state of Switch </summary>
            /// <since_tizen> 6 </since_tizen>
            public bool IsSelected;
        }
    }
}
