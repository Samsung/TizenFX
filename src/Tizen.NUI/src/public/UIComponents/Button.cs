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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.UIComponents
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
    /// <since_tizen> 3 </since_tizen>
    /// This will be deprecated
    [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Button : View
    {
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnselectedVisualProperty = BindableProperty.Create("UnselectedVisual", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.UNSELECTED_VISUAL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.UNSELECTED_VISUAL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedVisualProperty = BindableProperty.Create("SelectedVisual", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.SELECTED_VISUAL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.SELECTED_VISUAL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledSelectedVisualProperty = BindableProperty.Create("DisabledSelectedVisual", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.DISABLED_SELECTED_VISUAL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.DISABLED_SELECTED_VISUAL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledUnselectedVisualProperty = BindableProperty.Create("DisabledUnselectedVisual", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.DISABLED_UNSELECTED_VISUAL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.DISABLED_UNSELECTED_VISUAL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnselectedBackgroundVisualProperty = BindableProperty.Create("UnselectedBackgroundVisual", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.UNSELECTED_BACKGROUND_VISUAL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.UNSELECTED_BACKGROUND_VISUAL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedBackgroundVisualProperty = BindableProperty.Create("SelectedBackgroundVisual", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.SELECTED_BACKGROUND_VISUAL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.SELECTED_BACKGROUND_VISUAL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        public static readonly BindableProperty DisabledUnselectedBackgroundVisualProperty = BindableProperty.Create("DisabledUnselectedBackgroundVisual", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.DISABLED_UNSELECTED_BACKGROUND_VISUAL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.DISABLED_UNSELECTED_BACKGROUND_VISUAL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledSelectedBackgroundVisualProperty = BindableProperty.Create("DisabledSelectedBackgroundVisual", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.DISABLED_SELECTED_BACKGROUND_VISUAL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.DISABLED_SELECTED_BACKGROUND_VISUAL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelRelativeAlignmentProperty = BindableProperty.Create("LabelRelativeAlignment", typeof(Align), typeof(Button), Align.End, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((Align)newValue)
                {
                    case Align.Begin: { valueToString = "BEGIN"; break; }
                    case Align.End: { valueToString = "END"; break; }
                    case Align.Top: { valueToString = "TOP"; break; }
                    case Align.Bottom: { valueToString = "BOTTOM"; break; }
                    default: { valueToString = "END";  break; }
                }
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.LABEL_RELATIVE_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.LABEL_RELATIVE_ALIGNMENT).Get(out temp) == false)
            {
                NUILog.Error("LabelRelativeAlignment get error!");
            }
            switch (temp)
            {
                case "BEGIN":  return Align.Begin;
                case "END": return Align.End;
                case "TOP": return Align.Top;
                case "BOTTOM": return Align.Bottom;
                default: return Align.End;
            }
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelPaddingProperty = BindableProperty.Create("LabelPadding", typeof(Vector4), typeof(Button), Vector4.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.LABEL_PADDING, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.LABEL_PADDING).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ForegroundVisualPaddingProperty = BindableProperty.Create("ForegroundVisualPadding", typeof(Vector4), typeof(Button), Vector4.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.FOREGROUND_VISUAL_PADDING, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.FOREGROUND_VISUAL_PADDING).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoRepeatingProperty = BindableProperty.Create("AutoRepeating", typeof(bool), typeof(Button), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.AUTO_REPEATING, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.AUTO_REPEATING).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InitialAutoRepeatingDelayProperty = BindableProperty.Create("InitialAutoRepeatingDelay", typeof(float), typeof(Button), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.INITIAL_AUTO_REPEATING_DELAY, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.INITIAL_AUTO_REPEATING_DELAY).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NextAutoRepeatingDelayProperty = BindableProperty.Create("NextAutoRepeatingDelay", typeof(float), typeof(Button), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.NEXT_AUTO_REPEATING_DELAY, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.NEXT_AUTO_REPEATING_DELAY).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TogglableProperty = BindableProperty.Create("Togglable", typeof(bool), typeof(Button), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.TOGGLABLE, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.TOGGLABLE).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedProperty = BindableProperty.Create("Selected", typeof(bool), typeof(Button), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.SELECTED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.SELECTED).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnselectedColorProperty = BindableProperty.Create("UnselectedColor", typeof(Color), typeof(Button), Color.Transparent, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                PropertyMap background = new PropertyMap();
                background.Add( Visual.Property.Type, new PropertyValue((int)Visual.Type.Color) )
                          .Add( ColorVisualProperty.MixColor, new PropertyValue((Color)newValue) );
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.UNSELECTED_BACKGROUND_VISUAL, new Tizen.NUI.PropertyValue(background));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.PropertyMap map = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.UNSELECTED_BACKGROUND_VISUAL).Get(map);
            Tizen.NUI.PropertyValue value = map.Find( Visual.Property.MixColor);
            value?.Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(Button), Color.Transparent, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                PropertyMap background = new PropertyMap();
                background.Add( Visual.Property.Type, new PropertyValue((int)Visual.Type.Color) )
                          .Add( ColorVisualProperty.MixColor, new PropertyValue((Color)newValue) );
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.SELECTED_BACKGROUND_VISUAL, new Tizen.NUI.PropertyValue(background));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.PropertyMap map = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.SELECTED_BACKGROUND_VISUAL).Get(map);
            Tizen.NUI.PropertyValue value = map.Find( Visual.Property.MixColor);
            value?.Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.LABEL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.LABEL).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create("LabelText", typeof(string), typeof(Button), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(button.swigCPtr, Button.Property.LABEL, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var button = (Button)bindable;
            Tizen.NUI.PropertyMap map = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(button.swigCPtr, Button.Property.LABEL).Get(map);
            Tizen.NUI.PropertyValue value = map.Find( TextVisualProperty.Text, "Text");
            string str = "";
            value?.Get(out str);
            return str;
        });

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private EventHandlerWithReturnType<object, EventArgs, bool> _clickedEventHandler;
        private ClickedCallbackType _clickedCallback;
        private EventHandlerWithReturnType<object, EventArgs, bool> _pressedEventHandler;
        private PressedCallbackType _pressedCallback;
        private EventHandlerWithReturnType<object, EventArgs, bool> _releasedEventHandler;
        private ReleasedCallbackType _releasedCallback;
        private EventHandlerWithReturnType<object, EventArgs, bool> _stateChangedEventHandler;
        private StateChangedCallback _stateChangedCallback;

        /// <summary>
        /// Creates an uninitialized button.<br />
        /// Only the derived versions can be instantiated.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button() : this(Interop.Button.new_Button__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Button(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Button.Button_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ClickedCallbackType(global::System.IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool PressedCallbackType(global::System.IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ReleasedCallbackType(global::System.IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool StateChangedCallback(global::System.IntPtr data);

        /// <summary>
        /// The Clicked event will be triggered when the button is touched and the touch point doesn't leave the boundary of the button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Clicked
        {
            add
            {
                if (_clickedEventHandler == null)
                {
                    _clickedCallback = OnClicked;
                    ClickedSignal().Connect(_clickedCallback);
                }

                _clickedEventHandler += value;
            }

            remove
            {
                _clickedEventHandler -= value;

                if (_clickedEventHandler == null && ClickedSignal().Empty() == false)
                {
                    ClickedSignal().Disconnect(_clickedCallback);
                }
            }
        }

        /// <summary>
        /// The Pressed event will be triggered when the button is touched.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Pressed
        {
            add
            {
                if (_pressedEventHandler == null)
                {
                    _pressedCallback = OnPressed;
                    PressedSignal().Connect(_pressedCallback);
                }

                _pressedEventHandler += value;
            }

            remove
            {
                _pressedEventHandler -= value;

                if (_pressedEventHandler == null && PressedSignal().Empty() == false)
                {
                    this.PressedSignal().Disconnect(_pressedCallback);
                }
            }
        }

        /// <summary>
        /// The Released event will be triggered when the button is touched and the touch point leaves the boundary of the button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Released
        {
            add
            {
                if (_releasedEventHandler == null)
                {
                    _releasedCallback = OnReleased;
                    ReleasedSignal().Connect(_releasedCallback);
                }
                _releasedEventHandler += value;
            }

            remove
            {
                _releasedEventHandler -= value;

                if (_releasedEventHandler == null && ReleasedSignal().Empty() == false)
                {
                    ReleasedSignal().Disconnect(_releasedCallback);
                }

            }
        }

        /// <summary>
        /// The StateChanged event will be triggered when the button's state is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, bool> StateChanged
        {
            add
            {
                if (_stateChangedEventHandler == null)
                {
                    _stateChangedCallback = OnStateChanged;
                    StateChangedSignal().Connect(_stateChangedCallback);
                }

                _stateChangedEventHandler += value;
            }

            remove
            {
                _stateChangedEventHandler -= value;

                if (_stateChangedEventHandler == null && StateChangedSignal().Empty() == false)
                {
                    StateChangedSignal().Disconnect(_stateChangedCallback);
                }
            }
        }

        /// <summary>
        /// Enumeration for describing the position, the text label can be, in relation to the control (and foreground/icon).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum Align
        {
            /// <summary>
            /// At the start of the control before the foreground or icon.
            /// </summary>
            Begin,
            /// <summary>
            /// At the end of the control after the foreground or icon.
            /// </summary>
            End,
            /// <summary>
            /// At the top of the control above the foreground or icon.
            /// </summary>
            Top,
            /// <summary>
            /// At the bottom of the control below the foreground or icon.
            /// </summary>
            Bottom
        }

        /// <summary>
        /// Gets or sets the unselected button foreground or icon visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap UnselectedVisual
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap SelectedVisual
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap DisabledSelectedVisual
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap DisabledUnselectedVisual
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap UnselectedBackgroundVisual
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap SelectedBackgroundVisual
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap DisabledUnselectedBackgroundVisual
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap DisabledSelectedBackgroundVisual
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyMap Label
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Button obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal ButtonSignal PressedSignal()
        {
            ButtonSignal ret = new ButtonSignal(Interop.Button.Button_PressedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ButtonSignal ReleasedSignal()
        {
            ButtonSignal ret = new ButtonSignal(Interop.Button.Button_ReleasedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ButtonSignal ClickedSignal()
        {
            ButtonSignal ret = new ButtonSignal(Interop.Button.Button_ClickedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ButtonSignal StateChangedSignal()
        {
            ButtonSignal ret = new ButtonSignal(Interop.Button.Button_StateChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To dispose the button instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                DisConnectFromSignals();
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.Button.delete_Button(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void DisConnectFromSignals()
        {
            // Save current CPtr.
            global::System.Runtime.InteropServices.HandleRef currentCPtr = swigCPtr;

            // Use BaseHandle CPtr as current might have been deleted already in derived classes.
            swigCPtr = GetBaseHandleCPtrHandleRef;

            if (_stateChangedCallback != null)
            {
                StateChangedSignal().Disconnect(_stateChangedCallback);
            }

            if (_releasedCallback != null)
            {
                ReleasedSignal().Disconnect(_releasedCallback);
            }

            if (_pressedCallback != null)
            {
                this.PressedSignal().Disconnect(_pressedCallback);
            }

            if (_clickedCallback != null)
            {
                ClickedSignal().Disconnect(_clickedCallback);
            }

            // BaseHandle CPtr is used in Registry and there is danger of deletion if we keep using it here.
            // Restore current CPtr.
            swigCPtr = currentCPtr;
        }

        private bool OnClicked(IntPtr data)
        {
            if (_clickedEventHandler != null)
            {
                return _clickedEventHandler(this, null);
            }
            return false;
        }

        private bool OnPressed(IntPtr data)
        {
            if (_pressedEventHandler != null)
            {
                return _pressedEventHandler(this, null);
            }
            return false;
        }

        private bool OnReleased(IntPtr data)
        {
            if (_releasedEventHandler != null)
            {
                return _releasedEventHandler(this, null);
            }
            return false;
        }

        private bool OnStateChanged(IntPtr data)
        {
            if (_stateChangedEventHandler != null)
            {
                return _stateChangedEventHandler(this, null);
            }
            return false;
        }

        internal new class Property
        {
            internal static readonly int UNSELECTED_VISUAL = Interop.Button.Button_Property_UNSELECTED_VISUAL_get();
            internal static readonly int SELECTED_VISUAL = Interop.Button.Button_Property_SELECTED_VISUAL_get();
            internal static readonly int DISABLED_SELECTED_VISUAL = Interop.Button.Button_Property_DISABLED_SELECTED_VISUAL_get();
            internal static readonly int DISABLED_UNSELECTED_VISUAL = Interop.Button.Button_Property_DISABLED_UNSELECTED_VISUAL_get();
            internal static readonly int UNSELECTED_BACKGROUND_VISUAL = Interop.Button.Button_Property_UNSELECTED_BACKGROUND_VISUAL_get();
            internal static readonly int SELECTED_BACKGROUND_VISUAL = Interop.Button.Button_Property_SELECTED_BACKGROUND_VISUAL_get();
            internal static readonly int DISABLED_UNSELECTED_BACKGROUND_VISUAL = Interop.Button.Button_Property_DISABLED_UNSELECTED_BACKGROUND_VISUAL_get();
            internal static readonly int DISABLED_SELECTED_BACKGROUND_VISUAL = Interop.Button.Button_Property_DISABLED_SELECTED_BACKGROUND_VISUAL_get();
            internal static readonly int LABEL_RELATIVE_ALIGNMENT = Interop.Button.Button_Property_LABEL_RELATIVE_ALIGNMENT_get();
            internal static readonly int LABEL_PADDING = Interop.Button.Button_Property_LABEL_PADDING_get();
            internal static readonly int FOREGROUND_VISUAL_PADDING = Interop.Button.Button_Property_VISUAL_PADDING_get();
            internal static readonly int AUTO_REPEATING = Interop.Button.Button_Property_AUTO_REPEATING_get();
            internal static readonly int INITIAL_AUTO_REPEATING_DELAY = Interop.Button.Button_Property_INITIAL_AUTO_REPEATING_DELAY_get();
            internal static readonly int NEXT_AUTO_REPEATING_DELAY = Interop.Button.Button_Property_NEXT_AUTO_REPEATING_DELAY_get();
            internal static readonly int TOGGLABLE = Interop.Button.Button_Property_TOGGLABLE_get();
            internal static readonly int SELECTED = Interop.Button.Button_Property_SELECTED_get();
            internal static readonly int LABEL = Interop.Button.Button_Property_LABEL_get();
        }
    }
}
