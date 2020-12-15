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

namespace Tizen.NUI
{
    /// <summary>
    /// ScrollView contains views that can be scrolled manually (via touch).
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ScrollView : Scrollable
    {

        /// <summary>
        /// Create an instance of ScrollView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollView() : this(Interop.ScrollView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ScrollView.Upcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// Sets and Gets WrapEnabled property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
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

        /// <summary>
        /// Gets snap-animation's AlphaFunction.
        /// </summary>
        /// <returns>Current easing alpha function of the snap animation.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction GetScrollSnapAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(Interop.ScrollView.GetScrollSnapAlphaFunction(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets snap-animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the snap animation.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSnapAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.SetScrollSnapAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets flick-animation's AlphaFunction.
        /// </summary>
        /// <returns>Current easing alpha function of the flick animation.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction GetScrollFlickAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(Interop.ScrollView.GetScrollFlickAlphaFunction(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets flick-animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the flick animation.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollFlickAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.SetScrollFlickAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the time for the scroll snap-animation.
        /// </summary>
        /// <returns>The time in seconds for the animation to take.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetScrollSnapDuration()
        {
            float ret = Interop.ScrollView.GetScrollSnapDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the time for the scroll snap-animation.
        /// </summary>
        /// <param name="time">The time in seconds for the animation to take.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSnapDuration(float time)
        {
            Interop.ScrollView.SetScrollSnapDuration(swigCPtr, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the time for the scroll flick-animation.
        /// </summary>
        /// <returns>The time in seconds for the animation to take.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetScrollFlickDuration()
        {
            float ret = Interop.ScrollView.GetScrollFlickDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the time for the scroll snap-animation.
        /// </summary>
        /// <param name="time">The time in seconds for the animation to take.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollFlickDuration(float time)
        {
            Interop.ScrollView.SetScrollFlickDuration(swigCPtr, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets scroll sensibility of pan gesture.
        /// </summary>
        /// <param name="sensitive">True to enable scroll, false to disable scrolling.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSensitive(bool sensitive)
        {
            Interop.ScrollView.SetScrollSensitive(swigCPtr, sensitive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets maximum overshoot amount.
        /// </summary>
        /// <param name="overshootX">The maximum number of horizontally scrolled pixels before overshoot X reaches 1.0f.</param>
        /// <param name="overshootY">The maximum number of vertically scrolled pixels before overshoot X reaches 1.0f.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaxOvershoot(float overshootX, float overshootY)
        {
            Interop.ScrollView.SetMaxOvershoot(swigCPtr, overshootX, overshootY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets Snap Overshoot animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the overshoot snap animation.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSnapOvershootAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.SetSnapOvershootAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets Snap Overshoot animation's Duration.
        /// </summary>
        /// <param name="duration">duration The duration of the overshoot snap animation.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSnapOvershootDuration(float duration)
        {
            Interop.ScrollView.SetSnapOvershootDuration(swigCPtr, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enables or Disables Actor Auto-Snap mode.<br />
        /// When Actor Auto-Snap mode has been enabled, ScrollView will automatically,
        /// snap to the closest actor (The closest actor will appear in the center of the ScrollView).
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) Actor AutoSnap.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetViewAutoSnap(bool enable)
        {
            Interop.ScrollView.SetActorAutoSnap(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enables or Disables Wrap mode for ScrollView contents.<br />
        /// When enabled, the ScrollView contents are wrapped over the X/Y Domain.
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) Wrap Mode.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWrapMode(bool enable)
        {
            Interop.ScrollView.SetWrapMode(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current distance needed to scroll for ScrollUpdatedSignal to be emitted.
        /// </summary>
        /// <returns>Current scroll update distance.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetScrollUpdateDistance()
        {
            int ret = Interop.ScrollView.GetScrollUpdateDistance(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the distance needed to scroll for ScrollUpdatedSignal to be emitted.<br />
        /// The scroll update distance tells ScrollView how far to move before ScrollUpdatedSignal the informs application.<br />
        /// Each time the ScrollView crosses this distance the signal will be emitted.<br />
        /// </summary>
        /// <param name="distance">The distance for ScrollView to move before emitting update signal.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollUpdateDistance(int distance)
        {
            Interop.ScrollView.SetScrollUpdateDistance(swigCPtr, distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns state of Axis Auto Lock mode.
        /// </summary>
        /// <returns>Whether Axis Auto Lock mode has been enabled or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetAxisAutoLock()
        {
            bool ret = Interop.ScrollView.GetAxisAutoLock(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Enables or Disables Axis Auto Lock mode for panning within the ScrollView.<br />
        /// When enabled, any pan gesture that appears mostly horizontal or mostly
        /// vertical, will be automatically restricted to horizontal only or vertical
        /// only panning, until the pan gesture has completed.
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) AxisAutoLock mode.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAxisAutoLock(bool enable)
        {
            Interop.ScrollView.SetAxisAutoLock(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the gradient threshold at which a panning gesture should be locked to the Horizontal or Vertical axis.
        /// </summary>
        /// <returns>The gradient, a value between 0.0 and 1.0f.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetAxisAutoLockGradient()
        {
            float ret = Interop.ScrollView.GetAxisAutoLockGradient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the gradient threshold at which a panning gesture should be locked to the Horizontal or Vertical axis.<br />
        /// By default, this is 0.36 (0.36:1) which means angles less than 20 degrees to an axis will lock to that axis.<br />
        /// </summary>
        /// <param name="gradient">gradient A value between 0.0 and 1.0 (auto-lock for all angles).</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAxisAutoLockGradient(float gradient)
        {
            Interop.ScrollView.SetAxisAutoLockGradient(swigCPtr, gradient);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the friction coefficient setting for ScrollView when flicking in free panning mode.
        /// This is a value in stage-diagonals per second^2, stage-diagonal = Length( stage.width, stage.height )
        /// </summary>
        /// <returns>Friction coefficient is returned.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFrictionCoefficient()
        {
            float ret = Interop.ScrollView.GetFrictionCoefficient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the friction coefficient for ScrollView when flicking.<br />
        /// </summary>
        /// <param name="friction">Friction coefficient must be greater than 0.0 (default = 1.0).</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFrictionCoefficient(float friction)
        {
            Interop.ScrollView.SetFrictionCoefficient(swigCPtr, friction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the flick speed coefficient for ScrollView when flicking in free panning mode.<br />
        /// This is a constant which multiplies the input touch flick velocity to determine the actual velocity at which to move the scrolling area.
        /// </summary>
        /// <returns>The flick speed coefficient is returned.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFlickSpeedCoefficient()
        {
            float ret = Interop.ScrollView.GetFlickSpeedCoefficient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the flick speed coefficient for ScrollView when flicking in free panning mode.<br />
        /// This is a constant which multiplies the input touch flick velocity to determine the actual velocity at
        /// which to move the scrolling area.<br />
        /// </summary>
        /// <param name="speed">The flick speed coefficient (default = 1.0).</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFlickSpeedCoefficient(float speed)
        {
            Interop.ScrollView.SetFlickSpeedCoefficient(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the minimum pan distance required for a flick gesture in pixels.<br />
        /// </summary>
        /// <returns>Minimum pan distance vector with separate x and y distance.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetMinimumDistanceForFlick()
        {
            Vector2 ret = new Vector2(Interop.ScrollView.GetMinimumDistanceForFlick(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the minimum pan distance required for a flick in pixels.<br />
        /// Takes a Vector2 containing separate x and y values. As long as the pan distance exceeds one of these axes, a flick will be allowed.
        /// </summary>
        /// <param name="distance">The flick speed coefficient (default = 1.0).</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumDistanceForFlick(Vector2 distance)
        {
            Interop.ScrollView.SetMinimumDistanceForFlick(swigCPtr, Vector2.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the minimum pan speed required for a flick gesture in pixels per second.
        /// </summary>
        /// <returns>Minimum pan speed.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMinimumSpeedForFlick()
        {
            float ret = Interop.ScrollView.GetMinimumSpeedForFlick(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the minimum pan speed required for a flick in pixels per second.<br />
        /// </summary>
        /// <param name="speed">The minimum pan speed for a flick.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumSpeedForFlick(float speed)
        {
            Interop.ScrollView.SetMinimumSpeedForFlick(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the maximum flick speed setting for ScrollView when flicking in free panning mode.<br />
        /// This is a value in stage-diagonals per second.
        /// </summary>
        /// <returns>Maximum flick speed is returned.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMaxFlickSpeed()
        {
            float ret = Interop.ScrollView.GetMaxFlickSpeed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the maximum flick speed for the ScrollView when flicking in free panning mode.<br />
        /// This is a value in stage-diagonals per second. stage-diagonal = Length( stage.width, stage.height ).<br />
        /// </summary>
        /// <param name="speed">Maximum flick speed (default = 3.0).</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaxFlickSpeed(float speed)
        {
            Interop.ScrollView.SetMaxFlickSpeed(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the step of scroll distance in actor coordinates for each wheel event received in free panning mode.<br />
        /// </summary>
        /// <returns>The step of scroll distance(pixel) in X and Y axes.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetWheelScrollDistanceStep()
        {
            Vector2 ret = new Vector2(Interop.ScrollView.GetWheelScrollDistanceStep(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the step of scroll distance in actor coordinates for each wheel event received in free panning mode.<br />
        /// </summary>
        /// <param name="step">step The step of scroll distance(pixel) in X and Y axes.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWheelScrollDistanceStep(Vector2 step)
        {
            Interop.ScrollView.SetWheelScrollDistanceStep(swigCPtr, Vector2.getCPtr(step));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves current scroll position.<br />
        /// </summary>
        /// <returns>The current scroll position.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetCurrentScrollPosition()
        {
            Vector2 ret = new Vector2(Interop.ScrollView.GetCurrentScrollPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves current scroll page based on ScrollView dimensions being the size of one page, and all pages laid out in<br />
        /// a grid fashion, increasing from left to right until the end of the X-domain.
        /// </summary>
        /// <returns>The current scroll position.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetCurrentPage()
        {
            uint ret = Interop.ScrollView.GetCurrentPage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position)
        {
            Interop.ScrollView.ScrollToVector2(swigCPtr, Vector2.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration)
        {
            Interop.ScrollView.ScrollTo(swigCPtr, Vector2.getCPtr(position), duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="alpha">The alpha function to use.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha)
        {
            Interop.ScrollView.ScrollTo(swigCPtr, Vector2.getCPtr(position), duration, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="horizontalBias">Whether to bias scrolling to left or right.</param>
        /// <param name="verticalBias">Whether to bias scrolling to top or bottom.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            Interop.ScrollView.ScrollTo(swigCPtr, Vector2.getCPtr(position), duration, (int)horizontalBias, (int)verticalBias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="alpha">Alpha function to use.</param>
        /// <param name="horizontalBias">Whether to bias scrolling to left or right.</param>
        /// <param name="verticalBias">Whether to bias scrolling to top or bottom.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            Interop.ScrollView.ScrollTo(swigCPtr, Vector2.getCPtr(position), duration, AlphaFunction.getCPtr(alpha), (int)horizontalBias, (int)verticalBias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page)
        {
            Interop.ScrollView.ScrollTo(swigCPtr, page);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page, float duration)
        {
            Interop.ScrollView.ScrollTo(swigCPtr, page, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="bias">Whether to bias scrolling to left or right.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page, float duration, DirectionBias bias)
        {
            Interop.ScrollView.ScrollTo(swigCPtr, page, duration, (int)bias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="view">The view to center in on (via Scrolling).</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(View view)
        {
            Interop.ScrollView.ScrollToView(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="view">The view to center in on (via Scrolling).</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(View view, float duration)
        {
            Interop.ScrollView.ScrollToViewDuration(swigCPtr, View.getCPtr(view), duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to the nearest snap points as specified by the Rulers.<br />
        /// If already at snap points, then will return false, and not scroll.<br />
        /// </summary>
        /// <returns>True if Snapping necessary.</returns>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScrollToSnapPoint()
        {
            bool ret = Interop.ScrollView.ScrollToSnapPoint(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Applies Effect to ScrollView.
        /// </summary>
        /// <param name="effect">The effect to apply to scroll view.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyEffect(ScrollViewEffect effect)
        {
            Interop.ScrollView.ApplyEffect(swigCPtr, ScrollViewEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes Effect from ScrollView.
        /// </summary>
        /// <param name="effect">The effect to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveEffect(ScrollViewEffect effect)
        {
            Interop.ScrollView.RemoveEffect(swigCPtr, ScrollViewEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Remove All Effects from ScrollView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAllEffects()
        {
            Interop.ScrollView.RemoveAllEffects(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Binds view to this ScrollView.
        /// Once an actor is bound to a ScrollView, it will be subject to that ScrollView's properties.
        /// </summary>
        /// <param name="child">The view to add to this ScrollView.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BindView(View child)
        {
            Interop.ScrollView.BindActor(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Unbinds view to this ScrollView.
        /// Once an actor is bound to a ScrollView, it will be subject to that ScrollView's properties.
        /// </summary>
        /// <param name="child">The view to remove to this ScrollView.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UnbindView(View child)
        {
            Interop.ScrollView.UnbindActor(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows the user to constrain the scroll view in a particular direction.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <param name="threshold">The threshold to apply around the axis.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollingDirection(Radian direction, Radian threshold)
        {
            Interop.ScrollView.SetScrollingDirection(swigCPtr, Radian.getCPtr(direction), Radian.getCPtr(threshold));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows the user to constrain the scroll view in a particular direction.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollingDirection(Radian direction)
        {
            Interop.ScrollView.SetScrollingDirection(swigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a direction constraint from the scroll view.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveScrollingDirection(Radian direction)
        {
            Interop.ScrollView.RemoveScrollingDirection(swigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set ruler X
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRulerX(RulerPtr ruler)
        {
            Interop.ScrollView.SetRulerX(swigCPtr, RulerPtr.getCPtr(ruler));
        }

        /// <summary>
        /// Set ruler Y
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRulerY(RulerPtr ruler)
        {
            Interop.ScrollView.SetRulerY(swigCPtr, RulerPtr.getCPtr(ruler));
        }

        internal void ApplyConstraintToChildren(SWIGTYPE_p_Dali__Constraint constraint)
        {
            Interop.ScrollView.ApplyConstraintToChildren(swigCPtr, SWIGTYPE_p_Dali__Constraint.getCPtr(constraint));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type">the dispose type</param>
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

            if (this != null && _scrollViewSnapStartedCallbackDelegate != null)
            {
                this.SnapStartedSignal().Disconnect(_scrollViewSnapStartedCallbackDelegate);
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ScrollView.DeleteScrollView(swigCPtr);
        }

        /// <summary>
        /// This should be internal, please do not use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new class Property
        {
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int WrapEnabled = Interop.ScrollView.WrapEnabledGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int PanningEnabled = Interop.ScrollView.PanningEnabledGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int AxisAutoLockEnabled = Interop.ScrollView.AxisAutoLockEnabledGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int WheelScrollDistanceStep = Interop.ScrollView.WheelScrollDistanceStepGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollMode = Interop.ScrollView.ScrollModeGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPosition = Interop.ScrollView.ScrollPositionGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePosition = Interop.ScrollView.ScrollPrePositionGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionX = Interop.ScrollView.ScrollPrePositionXGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionY = Interop.ScrollView.ScrollPrePositionYGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionMax = Interop.ScrollView.ScrollPrePositionMaxGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionMaxX = Interop.ScrollView.ScrollPrePositionMaxXGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionMaxY = Interop.ScrollView.ScrollPrePositionMaxYGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int OvershootX = Interop.ScrollView.OvershootXGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int OvershootY = Interop.ScrollView.OvershootYGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollFinal = Interop.ScrollView.ScrollFinalGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollFinalX = Interop.ScrollView.ScrollFinalXGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollFinalY = Interop.ScrollView.ScrollFinalYGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int WRAP = Interop.ScrollView.WrapGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int PANNING = Interop.ScrollView.PanningGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int SCROLLING = Interop.ScrollView.ScrollingGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDomainSize = Interop.ScrollView.ScrollDomainSizeGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDomainSizeX = Interop.ScrollView.ScrollDomainSizeXGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDomainSizeY = Interop.ScrollView.ScrollDomainSizeYGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDomainOffset = Interop.ScrollView.ScrollDomainOffsetGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPositionDelta = Interop.ScrollView.ScrollPositionDeltaGet();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int StartPagePosition = Interop.ScrollView.StartPagePositionGet();
        }
    }
}

