/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.XamlBinding;
using static Tizen.NUI.UIComponents.Button;

namespace Tizen.NUI.Xaml.UIComponents
{
    /// <summary>
    /// The Button class is a base class for different kinds of buttons.<br />
    /// This class provides the disabled property and the clicked signal.<br />
    /// The clicked event handler is emitted when the button is touched, and the touch point doesn't leave the boundary of the button.<br />
    /// When the disabled property is set to true, no signal is emitted.<br />
    /// The 'Visual' describes not just traditional images like PNG and BMP, but also refers to whatever is used to show the button. It could be a color, gradient, or some other kind of renderer.<br />
    /// The button's appearance can be modified by setting properties for the various visuals or images.<br />
    /// It is not mandatory to set all the visuals. A button could be defined only by setting its background visual, or by setting its background and selected visuals.<br />
    /// The button visual is shown over the background visual.<br />
    /// When pressed, the unselected visuals are replaced by the selected visuals.<br />
    /// The text label is always placed on the top of all images.<br />
    /// When the button is disabled, the background button and the selected visuals are replaced by their disabled visuals.<br />
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Button : Tizen.NUI.Xaml.Forms.BaseComponents.View
    {
        private Tizen.NUI.UIComponents.Button _button;
        internal Tizen.NUI.UIComponents.Button button
        {
            get
            {
                if (null == _button)
                {
                    _button = handleInstance as Tizen.NUI.UIComponents.Button;
                }

                return _button;
            }
        }

        /// <summary>
        /// Creates an uninitialized button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button() : this(new Tizen.NUI.UIComponents.Button())
        {
        }

        internal Button(Tizen.NUI.UIComponents.Button nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnselectedVisualProperty = BindableProperty.Create("UnselectedVisual", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.UnselectedVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.UnselectedVisual;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedVisualProperty = BindableProperty.Create("SelectedVisual", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.SelectedVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.SelectedVisual;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledSelectedVisualProperty = BindableProperty.Create("DisabledSelectedVisual", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.DisabledSelectedVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.DisabledSelectedVisual;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledUnselectedVisualProperty = BindableProperty.Create("DisabledUnselectedVisual", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.DisabledUnselectedVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.DisabledUnselectedVisual;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnselectedBackgroundVisualProperty = BindableProperty.Create("UnselectedBackgroundVisual", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.UnselectedBackgroundVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.UnselectedBackgroundVisual;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedBackgroundVisualProperty = BindableProperty.Create("SelectedBackgroundVisual", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.SelectedBackgroundVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.SelectedBackgroundVisual;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledUnselectedBackgroundVisualProperty = BindableProperty.Create("DisabledUnselectedBackgroundVisual", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.DisabledUnselectedBackgroundVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.DisabledUnselectedBackgroundVisual;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledSelectedBackgroundVisualProperty = BindableProperty.Create("DisabledSelectedBackgroundVisual", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.DisabledSelectedBackgroundVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.DisabledSelectedBackgroundVisual;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelRelativeAlignmentProperty = BindableProperty.Create("LabelRelativeAlignment", typeof(Align), typeof(Button), Align.End, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.LabelRelativeAlignment = (Align)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.LabelRelativeAlignment;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelPaddingProperty = BindableProperty.Create("LabelPadding", typeof(Vector4), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.LabelPadding = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.LabelPadding;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ForegroundVisualPaddingProperty = BindableProperty.Create("ForegroundVisualPadding", typeof(Vector4), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.ForegroundVisualPadding = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.ForegroundVisualPadding;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoRepeatingProperty = BindableProperty.Create("AutoRepeating", typeof(bool), typeof(Button), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.AutoRepeating = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.AutoRepeating;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InitialAutoRepeatingDelayProperty = BindableProperty.Create("InitialAutoRepeatingDelay", typeof(float), typeof(Button), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.InitialAutoRepeatingDelay = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.InitialAutoRepeatingDelay;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NextAutoRepeatingDelayProperty = BindableProperty.Create("NextAutoRepeatingDelay", typeof(float), typeof(Button), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.NextAutoRepeatingDelay = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.NextAutoRepeatingDelay;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TogglableProperty = BindableProperty.Create("Togglable", typeof(bool), typeof(Button), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.Togglable = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.Togglable;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedProperty = BindableProperty.Create("Selected", typeof(bool), typeof(Button), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.Selected = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.Selected;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnselectedColorProperty = BindableProperty.Create("UnselectedColor", typeof(Color), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.UnselectedColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.UnselectedColor;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.SelectedColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.SelectedColor;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(PropertyMap), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.Label = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.Label;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create("LabelText", typeof(string), typeof(Button), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = ((Button)bindable).button;
            button.LabelText = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var button = ((Button)bindable).button;
            return button.LabelText;
        });

        /// <summary>
        /// The Clicked event will be triggered when the button is touched and the touch point doesn't leave the boundary of the button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Clicked
        {
            add
            {
                button.Clicked += value;
            }

            remove
            {
                button.Clicked -= value;
            }
        }

        /// <summary>
        /// The Pressed event will be triggered when the button is touched.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Pressed
        {
            add
            {
                button.Pressed += value;
            }

            remove
            {
                button.Pressed -= value;
            }
        }

        /// <summary>
        /// The Released event will be triggered when the button is touched and the touch point leaves the boundary of the button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Released
        {
            add
            {
                button.Released += value;
            }

            remove
            {
                button.Released -= value;
            }
        }

        /// <summary>
        /// The StateChanged event will be triggered when the button's state is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> StateChanged
        {
            add
            {
                button.StateChanged += value;
            }

            remove
            {
                button.StateChanged -= value;
            }
        }

        /// <summary>
        /// Gets or sets the unselected button foreground or icon visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap UnselectedVisual
        {
            get
            {
                return (PropertyMap)GetValue(UnselectedVisualProperty);
            }
            set
            {
                SetValue(UnselectedVisualProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected button foreground or icon visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectedVisual
        {
            get
            {
                return (PropertyMap)GetValue(SelectedVisualProperty);
            }
            set
            {
                SetValue(SelectedVisualProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the disabled selected state foreground or icon button visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap DisabledSelectedVisual
        {
            get
            {
                return (PropertyMap)GetValue(DisabledSelectedVisualProperty);
            }
            set
            {
                SetValue(DisabledSelectedVisualProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the disabled unselected state foreground or icon visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap DisabledUnselectedVisual
        {
            get
            {
                return (PropertyMap)GetValue(DisabledUnselectedVisualProperty);
            }
            set
            {
                SetValue(DisabledUnselectedVisualProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the disabled unselected state background button visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap UnselectedBackgroundVisual
        {
            get
            {
                return (PropertyMap)GetValue(UnselectedBackgroundVisualProperty);
            }
            set
            {
                SetValue(UnselectedBackgroundVisualProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected background button visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectedBackgroundVisual
        {
            get
            {
                return (PropertyMap)GetValue(SelectedBackgroundVisualProperty);
            }
            set
            {
                SetValue(SelectedBackgroundVisualProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the disabled while unselected background button visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap DisabledUnselectedBackgroundVisual
        {
            get
            {
                return (PropertyMap)GetValue(DisabledUnselectedBackgroundVisualProperty);
            }
            set
            {
                SetValue(DisabledUnselectedBackgroundVisualProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the disabled while selected background button visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap DisabledSelectedBackgroundVisual
        {
            get
            {
                return (PropertyMap)GetValue(DisabledSelectedBackgroundVisualProperty);
            }
            set
            {
                SetValue(DisabledSelectedBackgroundVisualProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the position of the the label in relation to the foreground or icon, if both present.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Align LabelRelativeAlignment
        {
            get
            {
                return (Align)GetValue(LabelRelativeAlignmentProperty);
            }
            set
            {
                SetValue(LabelRelativeAlignmentProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the padding around the text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 LabelPadding
        {
            get
            {
                return (Vector4)GetValue(LabelPaddingProperty);
            }
            set
            {
                SetValue(LabelPaddingProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the padding around the foreground visual.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 ForegroundVisualPadding
        {
            get
            {
                return (Vector4)GetValue(ForegroundVisualPaddingProperty);
            }
            set
            {
                SetValue(ForegroundVisualPaddingProperty, value);
            }
        }

        /// <summary>
        /// If the autorepeating property is set to true, then the togglable property is set to false.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AutoRepeating
        {
            get
            {
                return (bool)GetValue(AutoRepeatingProperty);
            }
            set
            {
                SetValue(AutoRepeatingProperty, value);
            }
        }

        /// <summary>
        /// By default, this value is set to 0.15 seconds.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float InitialAutoRepeatingDelay
        {
            get
            {
                return (float)GetValue(InitialAutoRepeatingDelayProperty);
            }
            set
            {
                SetValue(InitialAutoRepeatingDelayProperty, value);
            }
        }

        /// <summary>
        /// By default, this value is set to 0.05 seconds.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float NextAutoRepeatingDelay
        {
            get
            {
                return (float)GetValue(NextAutoRepeatingDelayProperty);
            }
            set
            {
                SetValue(NextAutoRepeatingDelayProperty, value);
            }
        }

        /// <summary>
        /// If the togglable property is set to true, then the autorepeating property is set to false.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Togglable
        {
            get
            {
                return (bool)GetValue(TogglableProperty);
            }
            set
            {
                SetValue(TogglableProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the togglable button as either selected or unselected, togglable property must be set to true.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Selected
        {
            get
            {
                return (bool)GetValue(SelectedProperty);
            }
            set
            {
                SetValue(SelectedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the unselected color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color UnselectedColor
        {
            get
            {
                return (Color)GetValue(UnselectedColorProperty);
            }
            set
            {
                SetValue(UnselectedColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color SelectedColor
        {
            get
            {
                return (Color)GetValue(SelectedColorProperty);
            }
            set
            {
                SetValue(SelectedColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Label
        {
            get
            {
                return (PropertyMap)GetValue(LabelProperty);
            }
            set
            {
                SetValue(LabelProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text of the label.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LabelText
        {
            get
            {
                return (string)GetValue(LabelTextProperty);
            }
            set
            {
                SetValue(LabelTextProperty, value);
            }
        }
    }
}
