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
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.Binding;
using static Tizen.NUI.BaseComponents.Scrollable;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    /// <summary>
    /// Base class for derived Scrollables that contains actors that can be scrolled manually
    /// (via touch) or automatically.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Scrollable : View
    {
        private Tizen.NUI.BaseComponents.Scrollable _scrollable;
        internal Tizen.NUI.BaseComponents.Scrollable scrollable
        {
            get
            {
                if (null == _scrollable)
                {
                    _scrollable = handleInstance as Tizen.NUI.BaseComponents.Scrollable;
                }

                return _scrollable;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Scrollable() : this(new Tizen.NUI.BaseComponents.Scrollable())
        {
        }

        internal Scrollable(Tizen.NUI.BaseComponents.Scrollable nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OvershootEffectColorProperty = Binding.BindableProperty.Create("OvershootEffectColor", typeof(Vector4), typeof(Scrollable), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.OvershootEffectColor = (Vector4)newValue;
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.OvershootEffectColor;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OvershootAnimationSpeedProperty = Binding.BindableProperty.Create("OvershootAnimationSpeed", typeof(float), typeof(Scrollable), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.OvershootAnimationSpeed = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.OvershootAnimationSpeed;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OvershootEnabledProperty = Binding.BindableProperty.Create("OvershootEnabled", typeof(bool), typeof(Scrollable), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.OvershootEnabled = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.OvershootEnabled;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OvershootSizeProperty = Binding.BindableProperty.Create("OvershootSize", typeof(Vector2), typeof(Scrollable), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.OvershootSize = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.OvershootSize;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollToAlphaFunctionProperty = Binding.BindableProperty.Create("ScrollToAlphaFunction", typeof(int), typeof(Scrollable), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.ScrollToAlphaFunction = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.ScrollToAlphaFunction;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollRelativePositionProperty = Binding.BindableProperty.Create("ScrollRelativePosition", typeof(Vector2), typeof(Scrollable), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.ScrollRelativePosition = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.ScrollRelativePosition;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollPositionMinProperty = Binding.BindableProperty.Create("ScrollPositionMin", typeof(Vector2), typeof(Scrollable), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.ScrollPositionMin = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.ScrollPositionMin;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollPositionMaxProperty = Binding.BindableProperty.Create("ScrollPositionMax", typeof(Vector2), typeof(Scrollable), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.ScrollPositionMax = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.ScrollPositionMax;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CanScrollVerticalProperty = Binding.BindableProperty.Create("CanScrollVertical", typeof(bool), typeof(Scrollable), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.CanScrollVertical = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.CanScrollVertical;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CanScrollHorizontalProperty = Binding.BindableProperty.Create("CanScrollHorizontal", typeof(bool), typeof(Scrollable), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            scrollable.CanScrollHorizontal = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollable = ((Scrollable)bindable).scrollable;
            return scrollable.CanScrollHorizontal;
        });

        /// <summary>
        /// The ScrollStarted event emitted when the Scrollable has moved (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, StartedEventArgs> ScrollStarted
        {
            add
            {
                scrollable.ScrollStarted += value;
            }

            remove
            {
                scrollable.ScrollStarted -= value;
            }
        }

        /// <summary>
        /// The ScrollUpdated event emitted when the Scrollable has moved (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, UpdatedEventArgs> ScrollUpdated
        {
            add
            {
                scrollable.ScrollUpdated += value;
            }

            remove
            {
                scrollable.ScrollUpdated -= value;
            }
        }

        /// <summary>
        /// The ScrollCompleted event emitted when the Scrollable has completed movement
        /// (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, CompletedEventArgs> ScrollCompleted
        {
            add
            {
                scrollable.ScrollCompleted += value;
            }

            remove
            {
                scrollable.ScrollCompleted -= value;
            }
        }

        /// <summary>
        /// Sets and Gets the color of the overshoot effect.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 OvershootEffectColor
        {
            get
            {
                return (Vector4)GetValue(OvershootEffectColorProperty);
            }
            set
            {
                SetValue(OvershootEffectColorProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets the speed of overshoot animation in pixels per second.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float OvershootAnimationSpeed
        {
            get
            {
                return (float)GetValue(OvershootAnimationSpeedProperty);
            }
            set
            {
                SetValue(OvershootAnimationSpeedProperty, value);
            }
        }

        /// <summary>
        /// Checks if scroll overshoot has been enabled or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OvershootEnabled
        {
            get
            {
                return (bool)GetValue(OvershootEnabledProperty);
            }
            set
            {
                SetValue(OvershootEnabledProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets OvershootSize property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 OvershootSize
        {
            get
            {
                return (Vector2)GetValue(OvershootSizeProperty);
            }
            set
            {
                SetValue(OvershootSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets ScrollToAlphaFunction property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ScrollToAlphaFunction
        {
            get
            {
                return (int)GetValue(ScrollToAlphaFunctionProperty);
            }
            set
            {
                SetValue(ScrollToAlphaFunctionProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets ScrollRelativePosition property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollRelativePosition
        {
            get
            {
                return (Vector2)GetValue(ScrollRelativePositionProperty);
            }
            set
            {
                SetValue(ScrollRelativePositionProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets ScrollPositionMin property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPositionMin
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionMinProperty);
            }
            set
            {
                SetValue(ScrollPositionMinProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets ScrollPositionMax property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPositionMax
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionMaxProperty);
            }
            set
            {
                SetValue(ScrollPositionMaxProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets CanScrollVertical property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanScrollVertical
        {
            get
            {
                return (bool)GetValue(CanScrollVerticalProperty);
            }
            set
            {
                SetValue(CanScrollVerticalProperty, value);
            }
        }

        /// <summary>
        /// Gets and Sets CanScrollHorizontal property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanScrollHorizontal
        {
            get
            {
                return (bool)GetValue(CanScrollHorizontalProperty);
            }
            set
            {
                SetValue(CanScrollHorizontalProperty, value);

            }
        }
    }
}