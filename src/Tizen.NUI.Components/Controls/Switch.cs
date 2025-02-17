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
using Tizen.NUI.Binding;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Switch is a kind of <see cref="Button"/> component that uses icon part as a toggle shape.
    /// The icon part consists of track and thumb.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public partial class Switch : Button
    {
        private ImageView thumb = null;

        static Switch()
        {
            if (NUIApplication.IsUsingXaml)
            {
                SwitchBackgroundImageURLSelectorProperty = BindableProperty.Create(nameof(SwitchBackgroundImageURLSelector), typeof(StringSelector), typeof(Switch), null,
                    propertyChanged: SetInternalSwitchBackgroundImageURLSelectorProperty, defaultValueCreator: GetInternalSwitchBackgroundImageURLSelectorProperty);
                SwitchHandlerImageURLProperty = BindableProperty.Create(nameof(SwitchHandlerImageURL), typeof(string), typeof(Switch), default(string),
                    propertyChanged: SetInternalSwitchHandlerImageURLProperty, defaultValueCreator: GetInternalSwitchHandlerImageURLProperty);
                SwitchHandlerImageURLSelectorProperty = BindableProperty.Create(nameof(SwitchHandlerImageURLSelector), typeof(StringSelector), typeof(Switch), null,
                    propertyChanged: SetInternalSwitchHandlerImageURLSelectorProperty, defaultValueCreator: GetInternalSwitchHandlerImageURLSelectorProperty);
                SwitchHandlerImageSizeProperty = BindableProperty.Create(nameof(SwitchHandlerImageSize), typeof(Size), typeof(Switch), null,
                    propertyChanged: SetInternalSwitchHandlerImageSizeProperty, defaultValueCreator: GetInternalSwitchHandlerImageSizeProperty);
            }
        }

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
            base.OnInitialize();
            AccessibilityRole = Role.ToggleButton;

            IsSelectable = true;

            Feedback = true;
        }

        /// <summary>
        /// Informs AT-SPI bridge about the set of AT-SPI states associated with this object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.Checked] = this.IsSelected;

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
            styleApplying++;

            base.ApplyStyle(viewStyle);

            if (viewStyle is SwitchStyle switchStyle)
            {
                if (Extension is SwitchExtension extension)
                {
                    if (extension.ProcessThumb(this, ref thumb))
                    {
                        LayoutItems();
                    }

                    Icon.Relayout -= OnTrackOrThumbRelayout;
                    Icon.Relayout += OnTrackOrThumbRelayout;

                    thumb.Relayout -= OnTrackOrThumbRelayout;
                    thumb.Relayout += OnTrackOrThumbRelayout;
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
            styleApplying--;

            UpdateState();
        }

        private void OnTrackOrThumbRelayout(object sender, EventArgs args)
        {
            if (Extension is SwitchExtension switchExtension)
            {
                switchExtension.OnTrackOrThumbResized(this, Icon, thumb);
            }
        }

        /// <summary>
        /// Switch's track part.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageView Track
        {
            get => Icon;
            internal set
            {
                Icon = value;
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
        /// Switch's track part image url selector.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector SwitchBackgroundImageURLSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(SwitchBackgroundImageURLSelectorProperty) as StringSelector;
                }
                else
                {
                    return GetInternalSwitchBackgroundImageURLSelectorProperty(this) as StringSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SwitchBackgroundImageURLSelectorProperty, value);
                }
                else
                {
                    SetInternalSwitchBackgroundImageURLSelectorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private StringSelector InternalSwitchBackgroundImageURLSelector
        {
            get
            {
                Selector<string> resourceUrlSelector = Icon?.ResourceUrlSelector;
                if(resourceUrlSelector != null)
                {
                    return new StringSelector(resourceUrlSelector);
                }
                return null;
            }
            set
            {
                Debug.Assert(Icon != null);
                Icon.ResourceUrlSelector = value;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(SwitchHandlerImageURLProperty) as string;
                }
                else
                {
                    return GetInternalSwitchHandlerImageURLProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SwitchHandlerImageURLProperty, value);
                }
                else
                {
                    SetInternalSwitchHandlerImageURLProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalSwitchHandlerImageURL
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
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(SwitchHandlerImageURLSelectorProperty) as StringSelector;
                }
                else
                {
                    return GetInternalSwitchHandlerImageURLSelectorProperty(this) as StringSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SwitchHandlerImageURLSelectorProperty, value);
                }
                else
                {
                    SetInternalSwitchHandlerImageURLSelectorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private StringSelector InternalSwitchHandlerImageURLSelector
        {
            get
            {
                Selector<string> resourceUrlSelector = thumb?.ResourceUrlSelector;
                if (resourceUrlSelector != null)
                {
                    return new StringSelector(resourceUrlSelector);
                }
                return null;
            }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(SwitchHandlerImageSizeProperty) as Size;
                }
                else
                {
                    return GetInternalSwitchHandlerImageSizeProperty(this) as Size;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SwitchHandlerImageSizeProperty, value);
                }
                else
                {
                    SetInternalSwitchHandlerImageSizeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private Size InternalSwitchHandlerImageSize
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
                if (Icon != null)
                {
                    Icon.Relayout -= OnTrackOrThumbRelayout;
                }
                if (thumb != null)
                {
                    thumb.Relayout -= OnTrackOrThumbRelayout;
                    Utility.Dispose(thumb);
                }
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
        protected override ImageView CreateIcon()
        {
            var icon = new ImageView()
            {
                AccessibilityHidden = true,
                EnableControlStatePropagation = true
            };

            thumb = new ImageView();
            icon.Add(thumb);

            return icon;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnControlStateChanged(ControlStateChangedEventArgs controlStateChangedInfo)
        {
            if (controlStateChangedInfo == null) throw new ArgumentNullException(nameof(controlStateChangedInfo));
            base.OnControlStateChanged(controlStateChangedInfo);

            if (IsSelectable)
            {
                if (controlStateChangedInfo.PreviousState.Contains(ControlState.Selected) != controlStateChangedInfo.CurrentState.Contains(ControlState.Selected))
                {
                   OnSelect();
                }
            }
        }

        private void OnSelect()
        {
            if (Accessibility.Accessibility.IsEnabled && IsHighlighted)
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
