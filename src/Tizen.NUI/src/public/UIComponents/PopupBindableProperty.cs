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
        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.TITLE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.TITLE).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = BindableProperty.Create("Content", typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.CONTENT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.CONTENT).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FooterProperty = BindableProperty.Create("Footer", typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.FOOTER, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.FOOTER).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisplayStateProperty = BindableProperty.Create("DisplayState", typeof(DisplayStateType), typeof(Popup), DisplayStateType.Hidden, propertyChanged: (bindable, oldValue, newValue) =>
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
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.DISPLAY_STATE, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.DISPLAY_STATE).Get(out temp) == false)
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
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TouchTransparentProperty = BindableProperty.Create("TouchTransparent", typeof(bool), typeof(Popup), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.TOUCH_TRANSPARENT, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.TOUCH_TRANSPARENT).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailVisibilityProperty = BindableProperty.Create("TailVisibility", typeof(bool), typeof(Popup), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.TAIL_VISIBILITY, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.TAIL_VISIBILITY).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailPositionProperty = BindableProperty.Create("TailPosition", typeof(Vector3), typeof(Popup), Vector3.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.TAIL_POSITION, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.TAIL_POSITION).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContextualModeProperty = BindableProperty.Create("ContextualMode", typeof(ContextualModeType), typeof(Popup), ContextualModeType.Below, propertyChanged: (bindable, oldValue, newValue) =>
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
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.CONTEXTUAL_MODE, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.CONTEXTUAL_MODE).Get(out temp) == false)
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
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnimationDurationProperty = BindableProperty.Create("AnimationDuration", typeof(float), typeof(Popup), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.ANIMATION_DURATION, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.ANIMATION_DURATION).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnimationModeProperty = BindableProperty.Create("AnimationMode", typeof(AnimationModeType), typeof(Popup), AnimationModeType.Fade, propertyChanged: (bindable, oldValue, newValue) =>
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
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.ANIMATION_MODE, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.ANIMATION_MODE).Get(out temp) == false)
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
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EntryAnimationProperty = BindableProperty.Create("EntryAnimation", typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.ENTRY_ANIMATION, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.ENTRY_ANIMATION).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExitAnimationProperty = BindableProperty.Create("ExitAnimation", typeof(PropertyMap), typeof(Popup), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.EXIT_ANIMATION, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.EXIT_ANIMATION).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoHideDelayProperty = BindableProperty.Create("AutoHideDelay", typeof(int), typeof(Popup), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.AUTO_HIDE_DELAY, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.AUTO_HIDE_DELAY).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackingEnabledProperty = BindableProperty.Create("BackingEnabled", typeof(bool), typeof(Popup), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.BACKING_ENABLED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.BACKING_ENABLED).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackingColorProperty = BindableProperty.Create("BackingColor", typeof(Vector4), typeof(Popup), Vector4.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.BACKING_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.BACKING_COLOR).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PopupBackgroundImageProperty = BindableProperty.Create("PopupBackgroundImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.POPUP_BACKGROUND_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.POPUP_BACKGROUND_IMAGE).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PopupBackgroundBorderProperty = BindableProperty.Create("PopupBackgroundBorder", typeof(Rectangle), typeof(Popup), new Rectangle(0, 0, 0, 0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.POPUP_BACKGROUND_BORDER, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.POPUP_BACKGROUND_BORDER).Get(temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailUpImageProperty = BindableProperty.Create("TailUpImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.TAIL_UP_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.TAIL_UP_IMAGE).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailDownImageProperty = BindableProperty.Create("TailDownImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.TAIL_DOWN_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.TAIL_DOWN_IMAGE).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailLeftImageProperty = BindableProperty.Create("TailLeftImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.TAIL_LEFT_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.TAIL_LEFT_IMAGE).Get(out temp);
            return temp;
        });
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TailRightImageProperty = BindableProperty.Create("TailRightImage", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var popup = (Popup)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(popup.swigCPtr, Popup.Property.TAIL_RIGHT_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var popup = (Popup)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(popup.swigCPtr, Popup.Property.TAIL_RIGHT_IMAGE).Get(out temp);
            return temp;
        });

    }
}
