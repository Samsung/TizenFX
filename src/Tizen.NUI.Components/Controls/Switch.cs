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
        public event EventHandler<SelectEventArgs> SelectedEvent;

        /// <summary>
        /// Return a copied Style instance of Switch
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Switch.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        //public new SwitchStyle Style
        //{
        //    get
        //    {
        //        return new SwitchStyle(ViewStyle as SwitchStyle);
        //    }
        //}
        public new SwitchStyle Style => ViewStyle as SwitchStyle;

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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Background image's resource url in Switch.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SwitchBackgroundImageURL
        {
            get
            {
                return Track.ResourceUrl;
            }
            set
            {
                Track.ResourceUrl = value;
            }
        }

        private StringSelector switchBackgroundImageURLSelector = new StringSelector();
        /// <summary>
        /// Background image's resource url selector in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector SwitchBackgroundImageURLSelector
        {
            get
            {
                return switchBackgroundImageURLSelector;
            }
            set
            {
                if (value == null || switchBackgroundImageURLSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] SwitchBackgroundImageURLSelector is null");
                    throw new NullReferenceException("SwitchBackgroundImageURLSelector is null");
                }
                else
                {
                    switchBackgroundImageURLSelector.Clone(value);
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
                return Thumb.ResourceUrl;
            }
            set
            {
                Thumb.ResourceUrl = value;
            }
        }

        private StringSelector switchHandlerImageURLSelector = new StringSelector();
        /// <summary>
        /// Handler image's resource url selector in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector SwitchHandlerImageURLSelector
        {
            get
            {
                return switchHandlerImageURLSelector;
            }
            set
            {
                if (value == null || switchHandlerImageURLSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] SwitchHandlerImageURLSelector is null");
                    throw new NullReferenceException("SwitchHandlerImageURLSelector is null");
                }
                else
                {
                    switchHandlerImageURLSelector.Clone(value);
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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
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

        private void Initialize()
        {
            IsSelectable = true;
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
    }
}
