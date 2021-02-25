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
        public static readonly BindableProperty UnselectedVisualProperty = BindableProperty.Create(nameof(UnselectedVisual), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.UnselectedVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.UnselectedVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedVisualProperty = BindableProperty.Create(nameof(SelectedVisual), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.SelectedVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.SelectedVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledSelectedVisualProperty = BindableProperty.Create(nameof(DisabledSelectedVisual), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.DisabledSelectedVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.DisabledSelectedVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledUnselectedVisualProperty = BindableProperty.Create(nameof(DisabledUnselectedVisual), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.DisabledUnselectedVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.DisabledUnselectedVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnselectedBackgroundVisualProperty = BindableProperty.Create(nameof(UnselectedBackgroundVisual), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.UnselectedBackgroundVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.UnselectedBackgroundVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedBackgroundVisualProperty = BindableProperty.Create(nameof(SelectedBackgroundVisual), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.SelectedBackgroundVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.SelectedBackgroundVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        public static readonly BindableProperty DisabledUnselectedBackgroundVisualProperty = BindableProperty.Create(nameof(DisabledUnselectedBackgroundVisual), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.DisabledUnselectedBackgroundVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.DisabledUnselectedBackgroundVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledSelectedBackgroundVisualProperty = BindableProperty.Create(nameof(DisabledSelectedBackgroundVisual), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.DisabledSelectedBackgroundVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.DisabledSelectedBackgroundVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelRelativeAlignmentProperty = BindableProperty.Create(nameof(LabelRelativeAlignment), typeof(Align), typeof(Button), Align.End, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
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
                    default: { valueToString = "END"; break; }
                }
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.LabelRelativeAlignment, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             string temp;
             if (Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.LabelRelativeAlignment).Get(out temp) == false)
             {
                 NUILog.Error("LabelRelativeAlignment get error!");
             }
             switch (temp)
             {
                 case "BEGIN": return Align.Begin;
                 case "END": return Align.End;
                 case "TOP": return Align.Top;
                 case "BOTTOM": return Align.Bottom;
                 default: return Align.End;
             }
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelPaddingProperty = BindableProperty.Create(nameof(LabelPadding), typeof(Vector4), typeof(Button), Vector4.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.LabelPadding, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.LabelPadding).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ForegroundVisualPaddingProperty = BindableProperty.Create(nameof(ForegroundVisualPadding), typeof(Vector4), typeof(Button), Vector4.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.ForegroundVisualPadding, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.ForegroundVisualPadding).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoRepeatingProperty = BindableProperty.Create(nameof(AutoRepeating), typeof(bool), typeof(Button), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.AutoRepeating, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             bool temp = false;
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.AutoRepeating).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InitialAutoRepeatingDelayProperty = BindableProperty.Create(nameof(InitialAutoRepeatingDelay), typeof(float), typeof(Button), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.InitialAutoRepeatingDelay, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             float temp = 0.0f;
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.InitialAutoRepeatingDelay).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NextAutoRepeatingDelayProperty = BindableProperty.Create(nameof(NextAutoRepeatingDelay), typeof(float), typeof(Button), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.NextAutoRepeatingDelay, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             float temp = 0.0f;
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.NextAutoRepeatingDelay).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TogglableProperty = BindableProperty.Create(nameof(Togglable), typeof(bool), typeof(Button), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.TOGGLABLE, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             bool temp = false;
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.TOGGLABLE).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedProperty = BindableProperty.Create(nameof(Selected), typeof(bool), typeof(Button), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.SELECTED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             bool temp = false;
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.SELECTED).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnselectedColorProperty = BindableProperty.Create(nameof(UnselectedColor), typeof(Color), typeof(Button), Color.Transparent, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                PropertyMap background = new PropertyMap();
                background.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color))
                          .Add(ColorVisualProperty.MixColor, new PropertyValue((Color)newValue));
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.UnselectedBackgroundVisual, new Tizen.NUI.PropertyValue(background));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
             Tizen.NUI.PropertyMap map = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.UnselectedBackgroundVisual).Get(map);
             Tizen.NUI.PropertyValue value = map.Find(Visual.Property.MixColor);
             value?.Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(Button), Color.Transparent, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                PropertyMap background = new PropertyMap();
                background.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color))
                          .Add(ColorVisualProperty.MixColor, new PropertyValue((Color)newValue));
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.SelectedBackgroundVisual, new Tizen.NUI.PropertyValue(background));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
             Tizen.NUI.PropertyMap map = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.SelectedBackgroundVisual).Get(map);
             Tizen.NUI.PropertyValue value = map.Find(Visual.Property.MixColor);
             value?.Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(PropertyMap), typeof(Button), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.LABEL, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.LABEL).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), typeof(string), typeof(Button), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var button = (Button)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)button.SwigCPtr, Button.Property.LABEL, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var button = (Button)bindable;
             Tizen.NUI.PropertyMap map = new Tizen.NUI.PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)button.SwigCPtr, Button.Property.LABEL).Get(map);
             Tizen.NUI.PropertyValue value = map.Find(TextVisualProperty.Text, "Text");
             string str = "";
             value?.Get(out str);
             return str;
         }));

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
        public Button() : this(Interop.Button.NewButton(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Button(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1710: Rename EventHandlerWithReturnType to end in 'EventHandler'.")]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Clicked
        {
            add
            {
                if (_clickedEventHandler == null)
                {
                    _clickedCallback = OnClicked;
                    ButtonSignal clickSignal = ClickedSignal();
                    clickSignal?.Connect(_clickedCallback);
                    clickSignal?.Dispose();
                }

                _clickedEventHandler += value;
            }

            remove
            {
                _clickedEventHandler -= value;

                ButtonSignal clickSignal = ClickedSignal();
                if (_clickedEventHandler == null && clickSignal.Empty() == false)
                {
                    clickSignal?.Disconnect(_clickedCallback);
                }
                clickSignal?.Dispose();
            }
        }

        /// <summary>
        /// The Pressed event will be triggered when the button is touched.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1710: Rename EventHandlerWithReturnType to end in 'EventHandler'.")]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Pressed
        {
            add
            {
                if (_pressedEventHandler == null)
                {
                    _pressedCallback = OnPressed;
                    ButtonSignal pressSignal = PressedSignal();
                    pressSignal?.Connect(_pressedCallback);
                    pressSignal?.Dispose();
                }

                _pressedEventHandler += value;
            }

            remove
            {
                _pressedEventHandler -= value;

                ButtonSignal pressSignal = this.PressedSignal();
                if (_pressedEventHandler == null && pressSignal.Empty() == false)
                {
                    pressSignal?.Disconnect(_pressedCallback);
                }
                pressSignal?.Dispose();
            }
        }

        /// <summary>
        /// The Released event will be triggered when the button is touched and the touch point leaves the boundary of the button.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1710: Rename EventHandlerWithReturnType to end in 'EventHandler'.")]
        public event EventHandlerWithReturnType<object, EventArgs, bool> Released
        {
            add
            {
                if (_releasedEventHandler == null)
                {
                    _releasedCallback = OnReleased;
                    ButtonSignal releaseSignal = ReleasedSignal();
                    releaseSignal?.Connect(_releasedCallback);
                    releaseSignal?.Dispose();
                }
                _releasedEventHandler += value;
            }

            remove
            {
                _releasedEventHandler -= value;

                ButtonSignal releaseSignal = ReleasedSignal();
                if (_releasedEventHandler == null && releaseSignal.Empty() == false)
                {
                    releaseSignal?.Disconnect(_releasedCallback);
                }
                releaseSignal?.Dispose();

            }
        }

        /// <summary>
        /// The StateChanged event will be triggered when the button's state is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1710: Rename EventHandlerWithReturnType to end in 'EventHandler'.")]
        public event EventHandlerWithReturnType<object, EventArgs, bool> StateChanged
        {
            add
            {
                if (_stateChangedEventHandler == null)
                {
                    _stateChangedCallback = OnStateChanged;
                    ButtonSignal stateChanged = StateChangedSignal();
                    stateChanged?.Connect(_stateChangedCallback);
                    stateChanged?.Dispose();
                }

                _stateChangedEventHandler += value;
            }

            remove
            {
                _stateChangedEventHandler -= value;

                ButtonSignal stateChanged = StateChangedSignal();
                if (_stateChangedEventHandler == null && stateChanged.Empty() == false)
                {
                    stateChanged?.Disconnect(_stateChangedCallback);
                }
                stateChanged?.Dispose();
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
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal ButtonSignal PressedSignal()
        {
            ButtonSignal ret = new ButtonSignal(Interop.Button.PressedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ButtonSignal ReleasedSignal()
        {
            ButtonSignal ret = new ButtonSignal(Interop.Button.ReleasedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ButtonSignal ClickedSignal()
        {
            ButtonSignal ret = new ButtonSignal(Interop.Button.ClickedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ButtonSignal StateChangedSignal()
        {
            ButtonSignal ret = new ButtonSignal(Interop.Button.StateChangedSignal(SwigCPtr), false);
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

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                DisConnectFromSignals();
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Button.DeleteButton(swigCPtr);
        }

        private void DisConnectFromSignals()
        {
            // Save current CPtr.
            global::System.Runtime.InteropServices.HandleRef currentCPtr = SwigCPtr;

            // Use BaseHandle CPtr as current might have been deleted already in derived classes.
            SwigCPtr = GetBaseHandleCPtrHandleRef;

            if (_stateChangedCallback != null)
            {
                ButtonSignal stateChanged = StateChangedSignal();
                stateChanged?.Disconnect(_stateChangedCallback);
                stateChanged?.Dispose();
            }

            if (_releasedCallback != null)
            {
                ButtonSignal released = ReleasedSignal();
                released?.Disconnect(_releasedCallback);
                released?.Dispose();
            }

            if (_pressedCallback != null)
            {
                ButtonSignal pressSignal = PressedSignal();
                pressSignal?.Disconnect(_pressedCallback);
                pressSignal?.Dispose();
            }

            if (_clickedCallback != null)
            {
                ButtonSignal clickSignal = ClickedSignal();
                clickSignal?.Disconnect(_clickedCallback);
                clickSignal?.Dispose();
            }

            // BaseHandle CPtr is used in Registry and there is danger of deletion if we keep using it here.
            // Restore current CPtr.
            SwigCPtr = currentCPtr;
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
            internal static readonly int UnselectedVisual = Interop.Button.UnselectedVisualGet();
            internal static readonly int SelectedVisual = Interop.Button.SelectedVisualGet();
            internal static readonly int DisabledSelectedVisual = Interop.Button.DisabledSelectedVisualGet();
            internal static readonly int DisabledUnselectedVisual = Interop.Button.DisabledUnselectedVisualGet();
            internal static readonly int UnselectedBackgroundVisual = Interop.Button.UnselectedBackgroundVisualGet();
            internal static readonly int SelectedBackgroundVisual = Interop.Button.SelectedBackgroundVisualGet();
            internal static readonly int DisabledUnselectedBackgroundVisual = Interop.Button.DisabledUnselectedBackgroundVisualGet();
            internal static readonly int DisabledSelectedBackgroundVisual = Interop.Button.DisabledSelectedBackgroundVisualGet();
            internal static readonly int LabelRelativeAlignment = Interop.Button.LabelRelativeAlignmentGet();
            internal static readonly int LabelPadding = Interop.Button.LabelPaddingGet();
            internal static readonly int ForegroundVisualPadding = Interop.Button.VisualPaddingGet();
            internal static readonly int AutoRepeating = Interop.Button.AutoRepeatingGet();
            internal static readonly int InitialAutoRepeatingDelay = Interop.Button.InitialAutoRepeatingDelayGet();
            internal static readonly int NextAutoRepeatingDelay = Interop.Button.NextAutoRepeatingDelayGet();
            internal static readonly int TOGGLABLE = Interop.Button.TogglableGet();
            internal static readonly int SELECTED = Interop.Button.SelectedGet();
            internal static readonly int LABEL = Interop.Button.LabelGet();
        }
    }
}
