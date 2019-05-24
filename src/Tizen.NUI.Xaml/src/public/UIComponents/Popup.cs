/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using static Tizen.NUI.UIComponents.Popup;

namespace Tizen.NUI.Xaml.UIComponents
{
    /// <summary>
    /// The Popup widget provides a configurable popup dialog with a built-in layout of three main fields.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Popup : Tizen.NUI.Xaml.Forms.BaseComponents.View
    {
        private Tizen.NUI.UIComponents.Popup _popup;
        internal Tizen.NUI.UIComponents.Popup popup
        {
            get
            {
                if (null == _popup)
                {
                    _popup = handleInstance as Tizen.NUI.UIComponents.Popup;
                }

                return _popup;
            }
        }

        /// <summary>
        /// Creates the popup.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Popup() : this(new Tizen.NUI.UIComponents.Popup())
        {
        }

        internal Popup(Tizen.NUI.UIComponents.Popup nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TitleProperty = Binding.BindableProperty.Create("Title", typeof(PropertyMap), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.Title = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.Title;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FooterProperty = Binding.BindableProperty.Create("Footer", typeof(PropertyMap), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.Footer = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.Footer;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty DisplayStateProperty = Binding.BindableProperty.Create("DisplayState", typeof(DisplayStateType), typeof(Popup), DisplayStateType.Hidden, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.DisplayState = (DisplayStateType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.DisplayState;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TouchTransparentProperty = Binding.BindableProperty.Create("TouchTransparent", typeof(bool), typeof(Popup), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.TouchTransparent = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.TouchTransparent;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TailVisibilityProperty = Binding.BindableProperty.Create("TailVisibility", typeof(bool), typeof(Popup), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.TailVisibility = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.TailVisibility;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TailPositionProperty = Binding.BindableProperty.Create("TailPosition", typeof(Vector3), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.TailPosition = (Vector3)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.TailPosition;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ContextualModeProperty = Binding.BindableProperty.Create("ContextualMode", typeof(ContextualModeType), typeof(Popup), ContextualModeType.Below, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.ContextualMode = (ContextualModeType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.ContextualMode;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty AnimationDurationProperty = Binding.BindableProperty.Create("AnimationDuration", typeof(float), typeof(Popup), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.AnimationDuration = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.AnimationDuration;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty AnimationModeProperty = Binding.BindableProperty.Create("AnimationMode", typeof(AnimationModeType), typeof(Popup), AnimationModeType.Fade, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.AnimationMode = (AnimationModeType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.AnimationMode;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EntryAnimationProperty = Binding.BindableProperty.Create("EntryAnimation", typeof(PropertyMap), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.EntryAnimation = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.EntryAnimation;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ExitAnimationProperty = Binding.BindableProperty.Create("ExitAnimation", typeof(PropertyMap), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.ExitAnimation = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.ExitAnimation;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty AutoHideDelayProperty = Binding.BindableProperty.Create("AutoHideDelay", typeof(int), typeof(Popup), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.AutoHideDelay = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.AutoHideDelay;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty BackingEnabledProperty = Binding.BindableProperty.Create("BackingEnabled", typeof(bool), typeof(Popup), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.BackingEnabled = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.BackingEnabled;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty BackingColorProperty = Binding.BindableProperty.Create("BackingColor", typeof(Vector4), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.BackingColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.BackingColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PopupBackgroundImageProperty = Binding.BindableProperty.Create("PopupBackgroundImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.PopupBackgroundImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.PopupBackgroundImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PopupBackgroundBorderProperty = Binding.BindableProperty.Create("PopupBackgroundBorder", typeof(Rectangle), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.PopupBackgroundBorder = (Rectangle)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.PopupBackgroundBorder;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TailUpImageProperty = Binding.BindableProperty.Create("TailUpImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.TailUpImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.TailUpImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TailDownImageProperty = Binding.BindableProperty.Create("TailDownImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.TailDownImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.TailDownImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TailLeftImageProperty = Binding.BindableProperty.Create("TailLeftImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.TailLeftImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.TailLeftImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TailRightImageProperty = Binding.BindableProperty.Create("TailRightImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = ((Popup)bindable).popup;
            popup.TailRightImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = ((Popup)bindable).popup;
            return popup.TailRightImage;
        });

        /// <summary>
        /// An event is sent when the user has touched outside the dialog.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TouchedOutsideEventArgs> TouchedOutside
        {
            add
            {
                popup.TouchedOutside += value;
            }
            remove
            {
                popup.TouchedOutside -= value;
            }
        }

        /// <summary>
        /// An event is sent when the popup starts showing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ShowingEventArgs> Showing
        {
            add
            {
                popup.Showing += value;
            }
            remove
            {
                popup.Showing -= value;
            }
        }

        /// <summary>
        /// An event is sent when the popup has been fully displayed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ShownEventArgs> Shown
        {
            add
            {
                popup.Shown += value;
            }
            remove
            {
                popup.Shown -= value;
            }
        }

        /// <summary>
        /// An event is sent when the popup starts to hide.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<HidingEventArgs> Hiding
        {
            add
            {
                popup.Hiding += value;
            }
            remove
            {
                popup.Hiding -= value;
            }
        }

        /// <summary>
        /// An event is sent when the popup has been completely hidden.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<HiddenEventArgs> Hidden
        {
            add
            {
                popup.Hidden += value;
            }
            remove
            {
                popup.Hidden -= value;
            }
        }

        /// <summary>
        /// Sets the content actor.
        /// </summary>
        /// <param name="content">The actor to use.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetContent(Tizen.NUI.Xaml.Forms.BaseComponents.View content)
        {
            popup.SetContent(content.handleInstance as View);
        }

        /// <summary>
        /// Sets the content actor.
        /// </summary>
        /// <param name="content">The actor to use.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetContent(View content)
        {
            popup.SetContent(content);
        }

        /// <summary>
        /// Sets the actor to use for the footer in this popup.
        /// </summary>
        /// <param name="footer">The footer actor to be added to this popup.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFooter(Tizen.NUI.Xaml.Forms.BaseComponents.View footer)
        {
            popup.SetFooter(footer.handleInstance as View);
        }

        /// <summary>
        /// Sets the actor to use for the footer in this popup.
        /// </summary>
        /// <param name="footer">The footer actor to be added to this popup.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFooter(View footer)
        {
            popup.SetFooter(footer);
        }

        /// <summary>
        /// Sets the display state of popup.<br />
        /// There are 4 total display states.<br />
        /// Only 2 can be set, but all four can be read for better inspection of the current popup state.<br />
        /// <br />
        /// The other two states are getable, but not setable, and are there for consistency.<br />
        /// <br />
        /// | Value    | Setting the state              | Getting the state              |<br />
        /// |----------|--------------------------------|--------------------------------|<br />
        /// | SHOWN    | Show the popup                 | The popup is fully shown       |<br />
        /// | HIDDEN   | Hide the popup                 | The popup is fully hidden      |<br />
        /// | SHOWING  |                                | The popup is transitioning in  |<br />
        /// | HIDING   |                                | The popup is transitioning out |<br />
        /// <br />
        /// All 4 states changes cause notifications via 4 respective signals that can be connected to.<br />
        /// </summary>
        /// <param name="displayState">The desired display state to change to.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetDisplayState(DisplayStateType displayState)
        {
            popup.SetDisplayState(displayState);
        }

        /// <summary>
        /// The popup title.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Title
        {
            get
            {
                return (PropertyMap)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// The popup footer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Footer
        {
            get
            {
                return (PropertyMap)GetValue(FooterProperty);
            }
            set
            {
                SetValue(FooterProperty, value);
            }
        }

        /// <summary>
        /// The popup display state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DisplayStateType DisplayState
        {
            get
            {
                return (DisplayStateType)GetValue(DisplayStateProperty);
            }
            set
            {
                SetValue(DisplayStateProperty, value);
            }
        }

        /// <summary>
        /// The touch transparent.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool TouchTransparent
        {
            get
            {
                return (bool)GetValue(TouchTransparentProperty);
            }
            set
            {
                SetValue(TouchTransparentProperty, value);
            }
        }

        /// <summary>
        /// The popup tail visibility.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool TailVisibility
        {
            get
            {
                return (bool)GetValue(TailVisibilityProperty);
            }
            set
            {
                SetValue(TailVisibilityProperty, value);
            }
        }

        /// <summary>
        /// The popup tail position.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 TailPosition
        {
            get
            {
                return (Vector3)GetValue(TailPositionProperty);
            }
            set
            {
                SetValue(TailPositionProperty, value);
            }
        }

        /// <summary>
        /// The contextual mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ContextualModeType ContextualMode
        {
            get
            {
                return (ContextualModeType)GetValue(ContextualModeProperty);
            }
            set
            {
                SetValue(ContextualModeProperty, value);
            }
        }

        /// <summary>
        /// The animation duration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float AnimationDuration
        {
            get
            {
                return (float)GetValue(AnimationDurationProperty);
            }
            set
            {
                SetValue(AnimationDurationProperty, value);
            }
        }

        /// <summary>
        /// The animation mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AnimationModeType AnimationMode
        {
            get
            {
                return (AnimationModeType)GetValue(AnimationModeProperty);
            }
            set
            {
                SetValue(AnimationModeProperty, value);
            }
        }

        /// <summary>
        /// The entry animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap EntryAnimation
        {
            get
            {
                return (PropertyMap)GetValue(EntryAnimationProperty);
            }
            set
            {
                SetValue(EntryAnimationProperty, value);
            }
        }

        /// <summary>
        /// The exit animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap ExitAnimation
        {
            get
            {
                return (PropertyMap)GetValue(ExitAnimationProperty);
            }
            set
            {
                SetValue(ExitAnimationProperty, value);
            }
        }

        /// <summary>
        /// The auto hide delay.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AutoHideDelay
        {
            get
            {
                return (int)GetValue(AutoHideDelayProperty);
            }
            set
            {
                SetValue(AutoHideDelayProperty, value);
            }
        }

        /// <summary>
        /// The backing enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool BackingEnabled
        {
            get
            {
                return (bool)GetValue(BackingEnabledProperty);
            }
            set
            {
                SetValue(BackingEnabledProperty, value);
            }
        }

        /// <summary>
        /// The backing color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 BackingColor
        {
            get
            {
                return (Vector4)GetValue(BackingColorProperty);
            }
            set
            {
                SetValue(BackingColorProperty, value);
            }
        }

        /// <summary>
        /// The background image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PopupBackgroundImage
        {
            get
            {
                return (string)GetValue(PopupBackgroundImageProperty);
            }
            set
            {
                SetValue(PopupBackgroundImageProperty, value);
            }
        }

        /// <summary>
        /// The background border.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle PopupBackgroundBorder
        {
            get
            {
                return (Rectangle)GetValue(PopupBackgroundBorderProperty);
            }
            set
            {
                SetValue(PopupBackgroundBorderProperty, value);
            }
        }

        /// <summary>
        /// The tail up image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TailUpImage
        {
            get
            {
                return (string)GetValue(TailUpImageProperty);
            }
            set
            {
                SetValue(TailUpImageProperty, value);
            }
        }

        /// <summary>
        /// The tail down image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TailDownImage
        {
            get
            {
                return (string)GetValue(TailDownImageProperty);
            }
            set
            {
                SetValue(TailDownImageProperty, value);
            }
        }

        /// <summary>
        /// The tail left image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TailLeftImage
        {
            get
            {
                return (string)GetValue(TailLeftImageProperty);
            }
            set
            {
                SetValue(TailLeftImageProperty, value);
            }
        }

        /// <summary>
        /// The tail right image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TailRightImage
        {
            get
            {
                return (string)GetValue(TailRightImageProperty);
            }
            set
            {
                SetValue(TailRightImageProperty, value);
            }
        }
    }
}
