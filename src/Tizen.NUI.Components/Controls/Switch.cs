/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
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
        }

        /// <summary>
        /// Creates a new instance of a Switch with style.
        /// </summary>
        /// <param name="style">Create Switch by special style defined in UX.</param>
        /// <since_tizen> 8 </since_tizen>
        public Switch(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of a Switch with style.
        /// </summary>
        /// <param name="switchStyle">Create Switch by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public Switch(SwitchStyle switchStyle) : base(switchStyle)
        {
        }

        /// <summary>
        /// Initialize AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            track = new ImageView()
            {
                EnableControlStatePropagation = true
            };
            thumb = new ImageView();
            track.Add(thumb);

            base.OnInitialize();
            SetAccessibilityConstructor(Role.ToggleButton);

            IsSelectable = true;
#if PROFILE_MOBILE
            Feedback = true;
#endif
        }

        /// <summary>
        /// Informs AT-SPI bridge about the set of AT-SPI states associated with this object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();
            states.Set(AccessibilityState.Checked, this.IsSelected);
            return states;
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
        /// Return currently applied style.
        /// </summary>
        /// <remarks>
        /// Modifying contents in style may cause unexpected behaviour.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public new SwitchStyle Style => (SwitchStyle)(ViewStyle as SwitchStyle)?.Clone();

        /// <summary>
        /// Apply style to switch.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            if (viewStyle is SwitchStyle switchStyle)
            {
                if (Extension is SwitchExtension extension)
                {
                    track.Unparent();
                    thumb.Unparent();
                    track = extension.OnCreateTrack(this, track);
                    thumb = extension.OnCreateThumb(this, thumb);
                    track.Add(thumb);
                }

                if (switchStyle.Track != null)
                {
                    Track.ApplyStyle(switchStyle.Track);
                }

                if (switchStyle.Thumb != null)
                {
                    Thumb.ApplyStyle(switchStyle.Thumb);
                }
            }

            base.ApplyStyle(viewStyle);
        }

        /// <summary>
        /// Switch's track part.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageView Track
        {
            get => track;
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
            get => thumb;
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
            get => new StringSelector(track.ResourceUrlSelector);
            set
            {
                Debug.Assert(track != null);
                track.ResourceUrlSelector = value;
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
            get => new StringSelector(thumb.ResourceUrlSelector);
            set
            {
                Debug.Assert(thumb != null);
                thumb.ResourceUrlSelector = value;
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
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use OnClicked instead.")]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        public override bool OnTouch(Touch touch)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutItems()
        {
            base.LayoutItems();
            track.Unparent();
            Add(track);
            track.LowerToBottom();
        }

        private void OnSelect()
        {
            if (IsHighlighted)
            {
                EmitAccessibilityStateChangedEvent(AccessibilityState.Checked, IsSelected);
            }

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
        /// It will be removed in API10
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use SelectedChangedEventArgs instead.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class SelectEventArgs : EventArgs
        {
            /// <summary> Select state of Switch </summary>
            /// <since_tizen> 6 </since_tizen>
            public bool IsSelected;
        }
    }
}
