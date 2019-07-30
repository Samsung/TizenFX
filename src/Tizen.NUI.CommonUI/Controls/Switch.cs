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

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// Switch is one kind of common component, it can be used as selector.
    /// User can handle Navigation by adding/inserting/deleting NavigationItem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Switch : Button
    {
        private const int aniTime = 100; // will be defined in const file later
        private ImageView switchBackgroundImage;
        private ImageView switchHandlerImage;
        private Animation handlerAni = null;
        private SwitchAttributes switchAttributes;

        /// <summary>
        /// Creates a new instance of a Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Switch() : base()
        {
            Initialize();
        }
        /// <summary>
        /// Creates a new instance of a Switch with style.
        /// </summary>
        /// <param name="style">Create Switch by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Switch(string style) : base(style)
        {
            Initialize();
        }
        /// <summary>
        /// Creates a new instance of a Switch with attributes.
        /// </summary>
        /// <param name="attrs">Create Switch by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Switch(SwitchAttributes attrs) : base(attrs)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the item selected signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SelectEventArgs> SelectedEvent;

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
                return switchAttributes?.SwitchBackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchBackgroundImageAttributes();
                    if (switchAttributes.SwitchBackgroundImageAttributes.ResourceURL == null)
                    {
                        switchAttributes.SwitchBackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    switchAttributes.SwitchBackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Background image's resource url selector in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector SwitchBackgroundImageURLSelector
        {
            get
            {
                return switchAttributes?.SwitchBackgroundImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchBackgroundImageAttributes();
                    switchAttributes.SwitchBackgroundImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Handler image's resource url in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SwitchHandlerImageURL
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    if (switchAttributes.SwitchHandlerImageAttributes.ResourceURL == null)
                    {
                        switchAttributes.SwitchHandlerImageAttributes.ResourceURL = new StringSelector();
                    }
                    switchAttributes.SwitchHandlerImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Handler image's resource url selector in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector SwitchHandlerImageURLSelector
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateSwitchHandlerImageAttributes();
                    switchAttributes.SwitchHandlerImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Handler image's size in Switch.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D SwitchHandlerImageSize2D
        {
            get
            {
                return switchAttributes?.SwitchHandlerImageAttributes?.Size2D ?? new Size2D(0, 0);
            }
            set
            {
                CreateSwitchHandlerImageAttributes();
                switchAttributes.SwitchHandlerImageAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Dispose Switch and all children on it.
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
                if (handlerAni != null)
                {
                    if (handlerAni.State == Animation.States.Playing)
                    {
                        handlerAni.Stop();
                    }
                    handlerAni.Dispose();
                    handlerAni = null;
                }

                if (switchHandlerImage != null)
                {
                    Utility.Dispose(switchHandlerImage);
                }
                if (switchBackgroundImage != null)
                {
                    Utility.Dispose(switchBackgroundImage);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update Switch by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (switchAttributes.SwitchBackgroundImageAttributes != null)
            {
                if (switchBackgroundImage == null)
                {
                    switchBackgroundImage = new ImageView()
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        PositionUsesPivotPoint = true,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                    };
                    switchBackgroundImage.Name = "SwitchBackgroundImage";
                    Add(switchBackgroundImage);
                }
                ApplyAttributes(switchBackgroundImage, switchAttributes.SwitchBackgroundImageAttributes);

                if (switchAttributes.SwitchHandlerImageAttributes != null)
                {
                    if (switchHandlerImage == null)
                    {
                        switchHandlerImage = new ImageView()
                        {
                            ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                            PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                            PositionUsesPivotPoint = true,
                        };
                        switchHandlerImage.Name = "SwitchHandlerImage";
                        switchBackgroundImage.Add(switchHandlerImage);
                    }
                    ApplyAttributes(switchHandlerImage, switchAttributes.SwitchHandlerImageAttributes);
                }
            }                          
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
            if (IsEnabled == false)
            {
                return false;
            }
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
            if(IsEnabled == false)
            {
                return false;
            }
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
        /// Get Switch attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new SwitchAttributes();
        }

        private void Initialize()
        {
            switchAttributes = attributes as SwitchAttributes;
            if (switchAttributes == null)
            {
                throw new Exception("Switch attribute parse error.");
            }

            switchAttributes.IsSelectable = true;
            CreateHandlerAnimation();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            SwitchAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as SwitchAttributes;
            if (tempAttributes != null)
            {
                attributes = switchAttributes = tempAttributes;
                RelayoutRequest();
            }
        }

        private void CreateSwitchBackgroundImageAttributes()
        {
            if (switchAttributes.SwitchBackgroundImageAttributes == null)
            {
                switchAttributes.SwitchBackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }

        private void CreateSwitchHandlerImageAttributes()
        {
            if (switchAttributes.SwitchHandlerImageAttributes == null)
            {
                switchAttributes.SwitchHandlerImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                };
            }
        }

        private void CreateHandlerAnimation()
        {
            if (handlerAni == null)
            {
                handlerAni = new Animation(aniTime);
            }
        }

        private void OnSelect()
        {
            if (handlerAni.State == Animation.States.Playing)
            {
                handlerAni.Stop();
            }
            handlerAni.Clear();
            if (switchHandlerImage != null)
            {
                handlerAni.AnimateTo(switchHandlerImage, "PositionX", Size2D.Width - switchHandlerImage.Size2D.Width - switchHandlerImage.Position2D.X);
            }
            if (switchBackgroundImage != null)
            {
                switchBackgroundImage.Opacity = 0.5f; ///////need defined by UX
                handlerAni.AnimateTo(switchBackgroundImage, "Opacity", 1);
            }
            handlerAni.Play();

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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SelectEventArgs : EventArgs
        {
            /// <summary> Select state of Switch </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool IsSelected;
        }
    }
}
