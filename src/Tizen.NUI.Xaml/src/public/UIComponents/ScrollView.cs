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
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml.Forms.BaseComponents;
using static Tizen.NUI.ScrollView;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Xaml.UIComponents
{
    /// <summary>
    /// ScrollView contains views that can be scrolled manually (via touch).
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollView : Scrollable
    {
        private Tizen.NUI.ScrollView _scrollView;
        internal Tizen.NUI.ScrollView scrollView
        {
            get
            {
                if (null == _scrollView)
                {
                    _scrollView = handleInstance as Tizen.NUI.ScrollView;
                }

                return _scrollView;
            }
        }

        /// <summary>
        /// Create an instance of ScrollView.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollView() : this(new Tizen.NUI.ScrollView())
        {
        }

        internal ScrollView(Tizen.NUI.ScrollView nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty WrapEnabledProperty = Binding.BindableProperty.Create("WrapEnabled", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.WrapEnabled = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.WrapEnabled;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PanningEnabledProperty = Binding.BindableProperty.Create("PanningEnabled", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.PanningEnabled = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.PanningEnabled;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty AxisAutoLockEnabledProperty = Binding.BindableProperty.Create("AxisAutoLockEnabled", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.AxisAutoLockEnabled = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.AxisAutoLockEnabled;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty WheelScrollDistanceStepProperty = Binding.BindableProperty.Create("WheelScrollDistanceStep", typeof(Vector2), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.WheelScrollDistanceStep = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.WheelScrollDistanceStep;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollPositionProperty = Binding.BindableProperty.Create("ScrollPosition", typeof(Vector2), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.ScrollPosition = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.ScrollPosition;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollPrePositionProperty = Binding.BindableProperty.Create("ScrollPrePosition", typeof(Vector2), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.ScrollPrePosition = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.ScrollPrePosition;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollPrePositionMaxProperty = Binding.BindableProperty.Create("ScrollPrePositionMax", typeof(Vector2), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.ScrollPrePositionMax = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.ScrollPrePositionMax;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OvershootXProperty = Binding.BindableProperty.Create("OvershootX", typeof(float), typeof(ScrollView), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.OvershootX = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.OvershootX;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OvershootYProperty = Binding.BindableProperty.Create("OvershootY", typeof(float), typeof(ScrollView), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.OvershootY = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.OvershootY;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollFinalProperty = Binding.BindableProperty.Create("ScrollFinal", typeof(Vector2), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.ScrollFinal = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.ScrollFinal;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty WrapProperty = Binding.BindableProperty.Create("Wrap", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.Wrap = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.Wrap;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PanningProperty = Binding.BindableProperty.Create("Panning", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.Panning = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.Panning;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollingProperty = Binding.BindableProperty.Create("Scrolling", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.Scrolling = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.Scrolling;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollDomainSizeProperty = Binding.BindableProperty.Create("ScrollDomainSize", typeof(Vector2), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.ScrollDomainSize = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.ScrollDomainSize;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollDomainOffsetProperty = Binding.BindableProperty.Create("ScrollDomainOffset", typeof(Vector2), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.ScrollDomainOffset = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.ScrollDomainOffset;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollPositionDeltaProperty = Binding.BindableProperty.Create("ScrollPositionDelta", typeof(Vector2), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.ScrollPositionDelta = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.ScrollPositionDelta;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty StartPagePositionProperty = Binding.BindableProperty.Create("StartPagePosition", typeof(Vector3), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.StartPagePosition = (Vector3)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.StartPagePosition;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollModeProperty = Binding.BindableProperty.Create("ScrollMode", typeof(PropertyMap), typeof(ScrollView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            scrollView.ScrollMode = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = ((ScrollView)bindable).scrollView;
            return scrollView.ScrollMode;
        });

        /// <summary>
        /// SnapStarted can be used to subscribe or unsubscribe the event handler
        /// The SnapStarted signal is emitted when the ScrollView has started to snap or flick (it tells the target
        ///  position, scale, rotation for the snap or flick).
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, SnapStartedEventArgs> SnapStarted
        {
            add
            {
                scrollView.SnapStarted += value;
            }

            remove
            {
                scrollView.SnapStarted -= value;
            }
        }

        /// <summary>
        /// Gets snap-animation's AlphaFunction.
        /// </summary>
        /// <returns>Current easing alpha function of the snap animation.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction GetScrollSnapAlphaFunction()
        {
            return scrollView.GetScrollSnapAlphaFunction();
        }

        /// <summary>
        /// Sets snap-animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the snap animation.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSnapAlphaFunction(AlphaFunction alpha)
        {
            scrollView.SetScrollSnapAlphaFunction(alpha);
        }

        /// <summary>
        /// Gets flick-animation's AlphaFunction.
        /// </summary>
        /// <returns>Current easing alpha function of the flick animation.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction GetScrollFlickAlphaFunction()
        {
            return scrollView.GetScrollFlickAlphaFunction();
        }

        /// <summary>
        /// Sets flick-animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the flick animation.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollFlickAlphaFunction(AlphaFunction alpha)
        {
            scrollView.SetScrollFlickAlphaFunction(alpha);
        }

        /// <summary>
        /// Gets the time for the scroll snap-animation.
        /// </summary>
        /// <returns>The time in seconds for the animation to take.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetScrollSnapDuration()
        {
            return scrollView.GetScrollSnapDuration();
        }

        /// <summary>
        /// Sets the time for the scroll snap-animation.
        /// </summary>
        /// <param name="time">The time in seconds for the animation to take.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSnapDuration(float time)
        {
            scrollView.SetScrollSnapDuration(time);
        }

        /// <summary>
        /// Gets the time for the scroll flick-animation.
        /// </summary>
        /// <returns>The time in seconds for the animation to take.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetScrollFlickDuration()
        {
            return scrollView.GetScrollFlickDuration();
        }

        /// <summary>
        /// Sets the time for the scroll snap-animation.
        /// </summary>
        /// <param name="time">The time in seconds for the animation to take.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollFlickDuration(float time)
        {
            scrollView.SetScrollFlickDuration(time);
        }

        /// <summary>
        /// Sets scroll sensibility of pan gesture.
        /// </summary>
        /// <param name="sensitive">True to enable scroll, false to disable scrolling.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSensitive(bool sensitive)
        {
            scrollView.SetScrollSensitive(sensitive);
        }

        /// <summary>
        /// Sets maximum overshoot amount.
        /// </summary>
        /// <param name="overshootX">The maximum number of horizontally scrolled pixels before overshoot X reaches 1.0f.</param>
        /// <param name="overshootY">The maximum number of vertically scrolled pixels before overshoot X reaches 1.0f.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaxOvershoot(float overshootX, float overshootY)
        {
            scrollView.SetMaxOvershoot(overshootX, OvershootY);
        }

        /// <summary>
        /// Sets Snap Overshoot animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the overshoot snap animation.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSnapOvershootAlphaFunction(AlphaFunction alpha)
        {
            scrollView.SetSnapOvershootAlphaFunction(alpha);
        }

        /// <summary>
        /// Sets Snap Overshoot animation's Duration.
        /// </summary>
        /// <param name="duration">duration The duration of the overshoot snap animation.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSnapOvershootDuration(float duration)
        {
            scrollView.SetSnapOvershootDuration(duration);
        }

        /// <summary>
        /// Enables or Disables Actor Auto-Snap mode.<br />
        /// When Actor Auto-Snap mode has been enabled, ScrollView will automatically,
        /// snap to the closest actor (The closest actor will appear in the center of the ScrollView).
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) Actor AutoSnap.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetViewAutoSnap(bool enable)
        {
            scrollView.SetViewAutoSnap(enable);
        }

        /// <summary>
        /// Enables or Disables Wrap mode for ScrollView contents.<br />
        /// When enabled, the ScrollView contents are wrapped over the X/Y Domain.
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) Wrap Mode.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWrapMode(bool enable)
        {
            scrollView.SetWrapMode(enable);
        }

        /// <summary>
        /// Gets the current distance needed to scroll for ScrollUpdatedSignal to be emitted.
        /// </summary>
        /// <returns>Current scroll update distance.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetScrollUpdateDistance()
        {
            return scrollView.GetScrollUpdateDistance();
        }

        /// <summary>
        /// Sets the distance needed to scroll for ScrollUpdatedSignal to be emitted.<br />
        /// The scroll update distance tells ScrollView how far to move before ScrollUpdatedSignal the informs application.<br />
        /// Each time the ScrollView crosses this distance the signal will be emitted.<br />
        /// </summary>
        /// <param name="distance">The distance for ScrollView to move before emitting update signal.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollUpdateDistance(int distance)
        {
            scrollView.SetScrollUpdateDistance(distance);
        }

        /// <summary>
        /// Returns state of Axis Auto Lock mode.
        /// </summary>
        /// <returns>Whether Axis Auto Lock mode has been enabled or not.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetAxisAutoLock()
        {
            return scrollView.GetAxisAutoLock();
        }

        /// <summary>
        /// Enables or Disables Axis Auto Lock mode for panning within the ScrollView.<br />
        /// When enabled, any pan gesture that appears mostly horizontal or mostly
        /// vertical, will be automatically restricted to horizontal only or vertical
        /// only panning, until the pan gesture has completed.
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) AxisAutoLock mode.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAxisAutoLock(bool enable)
        {
            scrollView.SetAxisAutoLock(enable);
        }

        /// <summary>
        /// Gets the gradient threshold at which a panning gesture should be locked to the Horizontal or Vertical axis.
        /// </summary>
        /// <returns>The gradient, a value between 0.0 and 1.0f.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetAxisAutoLockGradient()
        {
            return scrollView.GetAxisAutoLockGradient();
        }

        /// <summary>
        /// Sets the gradient threshold at which a panning gesture should be locked to the Horizontal or Vertical axis.<br />
        /// By default, this is 0.36 (0.36:1) which means angles less than 20 degrees to an axis will lock to that axis.<br />
        /// </summary>
        /// <param name="gradient">gradient A value between 0.0 and 1.0 (auto-lock for all angles).</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAxisAutoLockGradient(float gradient)
        {
            scrollView.SetAxisAutoLockGradient(gradient);
        }

        /// <summary>
        /// Gets the friction coefficient setting for ScrollView when flicking in free panning mode.
        /// This is a value in stage-diagonals per second^2, stage-diagonal = Length( stage.width, stage.height )
        /// </summary>
        /// <returns>Friction coefficient is returned.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFrictionCoefficient()
        {
            return scrollView.GetFrictionCoefficient();
        }

        /// <summary>
        /// Sets the friction coefficient for ScrollView when flicking.<br />
        /// </summary>
        /// <param name="friction">Friction coefficient must be greater than 0.0 (default = 1.0).</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFrictionCoefficient(float friction)
        {
            scrollView.SetFrictionCoefficient(friction);
        }

        /// <summary>
        /// Gets the flick speed coefficient for ScrollView when flicking in free panning mode.<br />
        /// This is a constant which multiplies the input touch flick velocity to determine the actual velocity at which to move the scrolling area.
        /// </summary>
        /// <returns>The flick speed coefficient is returned.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFlickSpeedCoefficient()
        {
            return scrollView.GetFlickSpeedCoefficient();
        }

        /// <summary>
        /// Sets the flick speed coefficient for ScrollView when flicking in free panning mode.<br />
        /// This is a constant which multiplies the input touch flick velocity to determine the actual velocity at
        /// which to move the scrolling area.<br />
        /// </summary>
        /// <param name="speed">The flick speed coefficient (default = 1.0).</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFlickSpeedCoefficient(float speed)
        {
            scrollView.SetFlickSpeedCoefficient(speed);
        }

        /// <summary>
        /// Gets the minimum pan distance required for a flick gesture in pixels.<br />
        /// </summary>
        /// <returns>Minimum pan distance vector with separate x and y distance.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetMinimumDistanceForFlick()
        {
            return scrollView.GetMinimumDistanceForFlick();
        }

        /// <summary>
        /// Sets the minimum pan distance required for a flick in pixels.<br />
        /// Takes a Vector2 containing separate x and y values. As long as the pan distance exceeds one of these axes, a flick will be allowed.
        /// </summary>
        /// <param name="distance">The flick speed coefficient (default = 1.0).</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumDistanceForFlick(Vector2 distance)
        {
            scrollView.SetMinimumDistanceForFlick(distance);
        }

        /// <summary>
        /// Returns the minimum pan speed required for a flick gesture in pixels per second.
        /// </summary>
        /// <returns>Minimum pan speed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMinimumSpeedForFlick()
        {
            return scrollView.GetMinimumSpeedForFlick();
        }

        /// <summary>
        /// Sets the minimum pan speed required for a flick in pixels per second.<br />
        /// </summary>
        /// <param name="speed">The minimum pan speed for a flick.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumSpeedForFlick(float speed)
        {
            scrollView.SetMinimumSpeedForFlick(speed);
        }

        /// <summary>
        /// Gets the maximum flick speed setting for ScrollView when flicking in free panning mode.<br />
        /// This is a value in stage-diagonals per second.
        /// </summary>
        /// <returns>Maximum flick speed is returned.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMaxFlickSpeed()
        {
            return scrollView.GetMaxFlickSpeed();
        }

        /// <summary>
        /// Sets the maximum flick speed for the ScrollView when flicking in free panning mode.<br />
        /// This is a value in stage-diagonals per second. stage-diagonal = Length( stage.width, stage.height ).<br />
        /// </summary>
        /// <param name="speed">Maximum flick speed (default = 3.0).</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaxFlickSpeed(float speed)
        {
            scrollView.SetMaxFlickSpeed(speed);
        }

        /// <summary>
        /// Gets the step of scroll distance in actor coordinates for each wheel event received in free panning mode.<br />
        /// </summary>
        /// <returns>The step of scroll distance(pixel) in X and Y axes.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetWheelScrollDistanceStep()
        {
            return scrollView.GetWheelScrollDistanceStep();
        }

        /// <summary>
        /// Sets the step of scroll distance in actor coordinates for each wheel event received in free panning mode.<br />
        /// </summary>
        /// <param name="step">step The step of scroll distance(pixel) in X and Y axes.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWheelScrollDistanceStep(Vector2 step)
        {
            scrollView.SetWheelScrollDistanceStep(step);
        }

        /// <summary>
        /// Retrieves current scroll position.<br />
        /// </summary>
        /// <returns>The current scroll position.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetCurrentScrollPosition()
        {
            return scrollView.GetCurrentScrollPosition();
        }

        /// <summary>
        /// Retrieves current scroll page based on ScrollView dimensions being the size of one page, and all pages laid out in<br />
        /// a grid fashion, increasing from left to right until the end of the X-domain.
        /// </summary>
        /// <returns>The current scroll position.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetCurrentPage()
        {
            return scrollView.GetCurrentPage();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position)
        {
            scrollView.ScrollTo(position);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration)
        {
            scrollView.ScrollTo(position, duration);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="alpha">The alpha function to use.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha)
        {
            scrollView.ScrollTo(position, duration, alpha);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="horizontalBias">Whether to bias scrolling to left or right.</param>
        /// <param name="verticalBias">Whether to bias scrolling to top or bottom.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            scrollView.ScrollTo(position, duration, horizontalBias, verticalBias);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="alpha">Alpha function to use.</param>
        /// <param name="horizontalBias">Whether to bias scrolling to left or right.</param>
        /// <param name="verticalBias">Whether to bias scrolling to top or bottom.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            scrollView.ScrollTo(position, duration, alpha, horizontalBias, verticalBias);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page)
        {
            scrollView.ScrollTo(page);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page, float duration)
        {
            scrollView.ScrollTo(page, duration);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="bias">Whether to bias scrolling to left or right.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page, float duration, DirectionBias bias)
        {
            scrollView.ScrollTo(page, duration, bias);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="view">The view to center in on (via Scrolling).</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(View view)
        {
            scrollView.ScrollTo(view.handleInstance as Tizen.NUI.BaseComponents.View);
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="view">The view to center in on (via Scrolling).</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(View view, float duration)
        {
            scrollView.ScrollTo(view.handleInstance as Tizen.NUI.BaseComponents.View, duration);
        }

        /// <summary>
        /// Scrolls View to the nearest snap points as specified by the Rulers.<br />
        /// If already at snap points, then will return false, and not scroll.<br />
        /// </summary>
        /// <returns>True if Snapping necessary.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScrollToSnapPoint()
        {
            return scrollView.ScrollToSnapPoint();
        }

        /// <summary>
        /// Applies Effect to ScrollView.
        /// </summary>
        /// <param name="effect">The effect to apply to scroll view.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyEffect(ScrollViewEffect effect)
        {
            scrollView.ApplyEffect(effect);
        }

        /// <summary>
        /// Removes Effect from ScrollView.
        /// </summary>
        /// <param name="effect">The effect to remove.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveEffect(ScrollViewEffect effect)
        {
            scrollView.RemoveEffect(effect);
        }

        /// <summary>
        /// Remove All Effects from ScrollView.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAllEffects()
        {
            scrollView.RemoveAllEffects();
        }

        /// <summary>
        /// Binds view to this ScrollView.
        /// Once an actor is bound to a ScrollView, it will be subject to that ScrollView's properties.
        /// </summary>
        /// <param name="child">The view to add to this ScrollView.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BindView(View child)
        {
            scrollView.BindView(child.handleInstance as Tizen.NUI.BaseComponents.View);
        }

        /// <summary>
        /// Unbinds view to this ScrollView.
        /// Once an actor is bound to a ScrollView, it will be subject to that ScrollView's properties.
        /// </summary>
        /// <param name="child">The view to remove to this ScrollView.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UnbindView(View child)
        {
            scrollView.UnbindView(child.handleInstance as Tizen.NUI.BaseComponents.View);
        }

        /// <summary>
        /// Allows the user to constrain the scroll view in a particular direction.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <param name="threshold">The threshold to apply around the axis.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollingDirection(Radian direction, Radian threshold)
        {
            scrollView.SetScrollingDirection(direction, threshold);
        }

        /// <summary>
        /// Allows the user to constrain the scroll view in a particular direction.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollingDirection(Radian direction)
        {
            scrollView.SetScrollingDirection(direction);
        }

        /// <summary>
        /// Removes a direction constraint from the scroll view.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveScrollingDirection(Radian direction)
        {
            scrollView.RemoveScrollingDirection(direction);
        }

        /// <summary>
        /// Sets and Gets WrapEnabled property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool WrapEnabled
        {
            get
            {
                return (bool)GetValue(WrapEnabledProperty);
            }
            set
            {
                SetValue(WrapEnabledProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets PanningEnabled property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PanningEnabled
        {
            get
            {
                return (bool)GetValue(PanningEnabledProperty);
            }
            set
            {
                SetValue(PanningEnabledProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets AxisAutoLockEnabled property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AxisAutoLockEnabled
        {
            get
            {
                return (bool)GetValue(AxisAutoLockEnabledProperty);
            }
            set
            {
                SetValue(AxisAutoLockEnabledProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets WheelScrollDistanceStep property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 WheelScrollDistanceStep
        {
            get
            {
                return (Vector2)GetValue(WheelScrollDistanceStepProperty);
            }
            set
            {
                SetValue(WheelScrollDistanceStepProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPosition property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPosition
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionProperty);
            }
            set
            {
                SetValue(ScrollPositionProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPrePosition property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPrePosition
        {
            get
            {
                return (Vector2)GetValue(ScrollPrePositionProperty);
            }
            set
            {
                SetValue(ScrollPrePositionProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPrePositionMax property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPrePositionMax
        {
            get
            {
                return (Vector2)GetValue(ScrollPrePositionMaxProperty);
            }
            set
            {
                SetValue(ScrollPrePositionMaxProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets OvershootX property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float OvershootX
        {
            get
            {
                return (float)GetValue(OvershootXProperty);
            }
            set
            {
                SetValue(OvershootXProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets OvershootY property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float OvershootY
        {
            get
            {
                return (float)GetValue(OvershootYProperty);
            }
            set
            {
                SetValue(OvershootYProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollFinal property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollFinal
        {
            get
            {
                return (Vector2)GetValue(ScrollFinalProperty);
            }
            set
            {
                SetValue(ScrollFinalProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets Wrap property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Wrap
        {
            get
            {
                return (bool)GetValue(WrapProperty);
            }
            set
            {
                SetValue(WrapProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets Panning property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Panning
        {
            get
            {
                return (bool)GetValue(PanningProperty);
            }
            set
            {
                SetValue(PanningProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets Scrolling property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Scrolling
        {
            get
            {
                return (bool)GetValue(ScrollingProperty);
            }
            set
            {
                SetValue(ScrollingProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollDomainSize property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollDomainSize
        {
            get
            {
                return (Vector2)GetValue(ScrollDomainSizeProperty);
            }
            set
            {
                SetValue(ScrollDomainSizeProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollDomainOffset property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollDomainOffset
        {
            get
            {
                return (Vector2)GetValue(ScrollDomainOffsetProperty);
            }
            set
            {
                SetValue(ScrollDomainOffsetProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPositionDelta property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPositionDelta
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionDeltaProperty);
            }
            set
            {
                SetValue(ScrollPositionDeltaProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets StartPagePosition property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 StartPagePosition
        {
            get
            {
                return (Vector3)GetValue(StartPagePositionProperty);
            }
            set
            {
                SetValue(StartPagePositionProperty, value);
            }
        }


        /// <summary>
        /// Sets and Gets ScrollMode property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap ScrollMode
        {
            get
            {
                return (PropertyMap)GetValue(ScrollModeProperty);
            }
            set
            {
                SetValue(ScrollModeProperty, value);
            }
        }

    }

}
