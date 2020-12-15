using System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.UIComponents
{
    public partial class Popup
    {
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TITLE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TITLE).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.CONTENT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.CONTENT).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FooterProperty = BindableProperty.Create(nameof(Footer), typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.FOOTER, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.FOOTER).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisplayStateProperty = BindableProperty.Create(nameof(DisplayState), typeof(DisplayStateType), typeof(Popup), DisplayStateType.Hidden, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((DisplayStateType)newValue)
                {
                    case DisplayStateType.Showing:
                        {
                            valueToString = "SHOWING";
                            break;
                        }
                    case DisplayStateType.Shown:
                        {
                            valueToString = "SHOWN";
                            break;
                        }
                    case DisplayStateType.Hiding:
                        {
                            valueToString = "HIDING";
                            break;
                        }
                    case DisplayStateType.Hidden:
                        {
                            valueToString = "HIDDEN";
                            break;
                        }
                    default:
                        {
                            valueToString = "HIDDEN";
                            break;
                        }
                }
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.DisplayState, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.DisplayState).Get(out temp) == false)
            {
                NUILog.Error("DisplayState get error!");
            }
            switch (temp)
            {
                case "SHOWING":
                    return DisplayStateType.Showing;
                case "SHOWN":
                    return DisplayStateType.Shown;
                case "HIDING":
                    return DisplayStateType.Hiding;
                case "HIDDEN":
                    return DisplayStateType.Hidden;
                default:
                    return DisplayStateType.Hidden;
            }
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TouchTransparentProperty = BindableProperty.Create(nameof(TouchTransparent), typeof(bool), typeof(Popup), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TouchTransparent, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TouchTransparent).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailVisibilityProperty = BindableProperty.Create(nameof(TailVisibility), typeof(bool), typeof(Popup), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailVisibility, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailVisibility).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailPositionProperty = BindableProperty.Create(nameof(TailPosition), typeof(Vector3), typeof(Popup), Vector3.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailPosition, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailPosition).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContextualModeProperty = BindableProperty.Create(nameof(ContextualMode), typeof(ContextualModeType), typeof(Popup), ContextualModeType.Below, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((ContextualModeType)newValue)
                {
                    case ContextualModeType.NonContextual:
                        {
                            valueToString = "NON_CONTEXTUAL";
                            break;
                        }
                    case ContextualModeType.Above:
                        {
                            valueToString = "ABOVE";
                            break;
                        }
                    case ContextualModeType.Rright:
                        {
                            valueToString = "RIGHT";
                            break;
                        }
                    case ContextualModeType.Below:
                        {
                            valueToString = "BELOW";
                            break;
                        }
                    case ContextualModeType.Left:
                        {
                            valueToString = "LEFT";
                            break;
                        }
                    default:
                        {
                            valueToString = "BELOW";
                            break;
                        }
                }
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.ContextualMode, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.ContextualMode).Get(out temp) == false)
            {
                NUILog.Error("ContextualMode get error!");
            }
            switch (temp)
            {
                case "NON_CONTEXTUAL":
                    return ContextualModeType.NonContextual;
                case "ABOVE":
                    return ContextualModeType.Above;
                case "RIGHT":
                    return ContextualModeType.Rright;
                case "BELOW":
                    return ContextualModeType.Below;
                case "LEFT":
                    return ContextualModeType.Left;
                default:
                    return ContextualModeType.Below;
            }
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnimationDurationProperty = BindableProperty.Create(nameof(AnimationDuration), typeof(float), typeof(Popup), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.AnimationDuration, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.AnimationDuration).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnimationModeProperty = BindableProperty.Create(nameof(AnimationMode), typeof(AnimationModeType), typeof(Popup), AnimationModeType.Fade, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((AnimationModeType)newValue)
                {
                    case AnimationModeType.None:
                        {
                            valueToString = "NONE";
                            break;
                        }
                    case AnimationModeType.Zoom:
                        {
                            valueToString = "ZOOM";
                            break;
                        }
                    case AnimationModeType.Fade:
                        {
                            valueToString = "FADE";
                            break;
                        }
                    case AnimationModeType.Custom:
                        {
                            valueToString = "CUSTOM";
                            break;
                        }
                    default:
                        {
                            valueToString = "FADE";
                            break;
                        }
                }
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.AnimationMode, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.AnimationMode).Get(out temp) == false)
            {
                NUILog.Error("AnimationMode get error!");
            }
            switch (temp)
            {
                case "NONE":
                    return AnimationModeType.None;
                case "ZOOM":
                    return AnimationModeType.Zoom;
                case "FADE":
                    return AnimationModeType.Fade;
                case "CUSTOM":
                    return AnimationModeType.Custom;
                default:
                    return AnimationModeType.Fade;
            }
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EntryAnimationProperty = BindableProperty.Create(nameof(EntryAnimation), typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.EntryAnimation, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.EntryAnimation).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExitAnimationProperty = BindableProperty.Create(nameof(ExitAnimation), typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.ExitAnimation, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.ExitAnimation).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoHideDelayProperty = BindableProperty.Create(nameof(AutoHideDelay), typeof(int), typeof(Popup), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.AutoHideDelay, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.AutoHideDelay).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackingEnabledProperty = BindableProperty.Create(nameof(BackingEnabled), typeof(bool), typeof(Popup), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.BackingEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.BackingEnabled).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackingColorProperty = BindableProperty.Create(nameof(BackingColor), typeof(Vector4), typeof(Popup), Vector4.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.BackingColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.BackingColor).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PopupBackgroundImageProperty = BindableProperty.Create(nameof(PopupBackgroundImage), typeof(string), typeof(Popup), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.PopupBackgroundImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.PopupBackgroundImage).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PopupBackgroundBorderProperty = BindableProperty.Create(nameof(PopupBackgroundBorder), typeof(Rectangle), typeof(Popup), new Rectangle(0, 0, 0, 0), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.PopupBackgroundBorder, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.PopupBackgroundBorder).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailUpImageProperty = BindableProperty.Create(nameof(TailUpImage), typeof(string), typeof(Popup), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailUpImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailUpImage).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailDownImageProperty = BindableProperty.Create(nameof(TailDownImage), typeof(string), typeof(Popup), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailDownImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailDownImage).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailLeftImageProperty = BindableProperty.Create(nameof(TailLeftImage), typeof(string), typeof(Popup), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailLeftImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailLeftImage).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailRightImageProperty = BindableProperty.Create(nameof(TailRightImage), typeof(string), typeof(Popup), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailRightImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)popup.SwigCPtr, Popup.Property.TailRightImage).Get(out temp);
            return temp;
        }));

    }
}
