/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// ScrollView contains views that can be scrolled manually (via touch).
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ScrollView : Scrollable
    {

        static ScrollView()
        {
            if(NUIApplication.IsUsingXaml)
            {
                WrapEnabledProperty = BindableProperty.Create(nameof(WrapEnabled), typeof(bool), typeof(ScrollView), false, propertyChanged: SetInternalWrapEnabledProperty, defaultValueCreator: GetInternalWrapEnabledProperty);

                PanningEnabledProperty = BindableProperty.Create(nameof(PanningEnabled), typeof(bool), typeof(ScrollView), false, propertyChanged: SetInternalPanningEnabledProperty, defaultValueCreator: GetInternalPanningEnabledProperty);

                AxisAutoLockEnabledProperty = BindableProperty.Create(nameof(AxisAutoLockEnabled), typeof(bool), typeof(ScrollView), false, propertyChanged: SetInternalAxisAutoLockEnabledProperty, defaultValueCreator: GetInternalAxisAutoLockEnabledProperty);

                WheelScrollDistanceStepProperty = BindableProperty.Create(nameof(WheelScrollDistanceStep), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: SetInternalWheelScrollDistanceStepProperty, defaultValueCreator: GetInternalWheelScrollDistanceStepProperty);

                ScrollPositionProperty = BindableProperty.Create(nameof(ScrollPosition), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: SetInternalScrollPositionProperty, defaultValueCreator: GetInternalScrollPositionProperty);

                ScrollPrePositionProperty = BindableProperty.Create(nameof(ScrollPrePosition), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: SetInternalScrollPrePositionProperty, defaultValueCreator: GetInternalScrollPrePositionProperty);

                ScrollPrePositionMaxProperty = BindableProperty.Create(nameof(ScrollPrePositionMax), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: SetInternalScrollPrePositionMaxProperty, defaultValueCreator: GetInternalScrollPrePositionMaxProperty);

                OvershootXProperty = BindableProperty.Create(nameof(OvershootX), typeof(float), typeof(ScrollView), default(float), propertyChanged: SetInternalOvershootXProperty, defaultValueCreator: GetInternalOvershootXProperty);

                OvershootYProperty = BindableProperty.Create(nameof(OvershootY), typeof(float), typeof(ScrollView), default(float), propertyChanged: SetInternalOvershootYProperty, defaultValueCreator: GetInternalOvershootYProperty);

                ScrollFinalProperty = BindableProperty.Create(nameof(ScrollFinal), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: SetInternalScrollFinalProperty, defaultValueCreator: GetInternalScrollFinalProperty);

                WrapProperty = BindableProperty.Create(nameof(Wrap), typeof(bool), typeof(ScrollView), false, propertyChanged: SetInternalWrapProperty, defaultValueCreator: GetInternalWrapProperty);

                PanningProperty = BindableProperty.Create(nameof(Panning), typeof(bool), typeof(ScrollView), false, propertyChanged: SetInternalPanningProperty, defaultValueCreator: GetInternalPanningProperty);

                ScrollingProperty = BindableProperty.Create(nameof(Scrolling), typeof(bool), typeof(ScrollView), false, propertyChanged: SetInternalScrollingProperty, defaultValueCreator: GetInternalScrollingProperty);

                ScrollDomainSizeProperty = BindableProperty.Create(nameof(ScrollDomainSize), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: SetInternalScrollDomainSizeProperty, defaultValueCreator: GetInternalScrollDomainSizeProperty);

                ScrollDomainOffsetProperty = BindableProperty.Create(nameof(ScrollDomainOffset), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: SetInternalScrollDomainOffsetProperty, defaultValueCreator: GetInternalScrollDomainOffsetProperty);

                ScrollPositionDeltaProperty = BindableProperty.Create(nameof(ScrollPositionDelta), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: SetInternalScrollPositionDeltaProperty, defaultValueCreator: GetInternalScrollPositionDeltaProperty);

                StartPagePositionProperty = BindableProperty.Create(nameof(StartPagePosition), typeof(Vector3), typeof(ScrollView), Vector3.Zero, propertyChanged: SetInternalStartPagePositionProperty, defaultValueCreator: GetInternalStartPagePositionProperty);

                ScrollModeProperty = BindableProperty.Create(nameof(ScrollMode), typeof(PropertyMap), typeof(ScrollView), new PropertyMap(), propertyChanged: SetInternalScrollModeProperty, defaultValueCreator: GetInternalScrollModeProperty);

            }
        }

        /// <summary>
        /// Create an instance of ScrollView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollView() : this(Interop.ScrollView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Sets and Gets WrapEnabled property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool WrapEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(WrapEnabledProperty);
                }
                else
                {
                    return (bool)GetInternalWrapEnabledProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WrapEnabledProperty, value);
                }
                else
                {
                    SetInternalWrapEnabledProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets PanningEnabled property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PanningEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(PanningEnabledProperty);
                }
                else
                {
                    return (bool)GetInternalPanningEnabledProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PanningEnabledProperty, value);
                }
                else
                {
                    SetInternalPanningEnabledProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets AxisAutoLockEnabled property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AxisAutoLockEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(AxisAutoLockEnabledProperty);
                }
                else
                {
                     return (bool)GetInternalAxisAutoLockEnabledProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AxisAutoLockEnabledProperty, value);
                }
                else
                {
                    SetInternalAxisAutoLockEnabledProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets WheelScrollDistanceStep property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 WheelScrollDistanceStep
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(WheelScrollDistanceStepProperty);
                }
                else
                {
                    return (Vector2)GetInternalWheelScrollDistanceStepProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WheelScrollDistanceStepProperty, value);
                }
                else
                {
                    SetInternalWheelScrollDistanceStepProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPosition property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollPositionProperty);
                }
                else
                {
                    return (Vector2)GetInternalScrollPositionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollPositionProperty, value);
                }
                else
                {
                    SetInternalScrollPositionProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPrePosition property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPrePosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollPrePositionProperty);
                }
                else
                {
                    return (Vector2)GetInternalScrollPrePositionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollPrePositionProperty, value);
                }
                else
                {
                    SetInternalScrollPrePositionProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPrePositionMax property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPrePositionMax
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollPrePositionMaxProperty);
                }
                else
                {
                    return (Vector2)GetInternalScrollPrePositionMaxProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollPrePositionMaxProperty, value);
                    
                }
                else
                {
                    SetInternalScrollPrePositionMaxProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets OvershootX property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float OvershootX
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(OvershootXProperty);
                }
                else
                {
                    return (float)GetInternalOvershootXProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OvershootXProperty, value);
                }
                else
                {
                    SetInternalOvershootXProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets OvershootY property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float OvershootY
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(OvershootYProperty);
                }
                else
                {
                    return (float)GetInternalOvershootYProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OvershootYProperty, value);
                }
                else
                {
                    SetInternalOvershootYProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets ScrollFinal property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollFinal
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollFinalProperty);
                }
                else
                {
                    return (Vector2)GetInternalScrollFinalProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollFinalProperty, value);
                }
                else
                {
                    SetInternalScrollFinalProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets Wrap property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Wrap
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(WrapProperty);
                }
                else
                {
                    return (bool)GetInternalWrapProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WrapProperty, value);
                    
                }
                else
                {
                    SetInternalWrapProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets Panning property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Panning
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(PanningProperty);
                }
                else
                {
                    return (bool)GetInternalPanningProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PanningProperty, value);
                }
                else
                {
                    SetInternalPanningProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets Scrolling property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Scrolling
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(ScrollingProperty);
                }
                else
                {
                    return (bool)GetInternalScrollingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollingProperty, value);
                }
                else
                {
                    SetInternalScrollingProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets ScrollDomainSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollDomainSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollDomainSizeProperty);
                }
                else
                {
                    return (Vector2)GetInternalScrollDomainSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollDomainSizeProperty, value);
                }
                else
                {
                    SetInternalScrollDomainSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets ScrollDomainOffset property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollDomainOffset
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollDomainOffsetProperty);
                }
                else
                {
                    return (Vector2)GetInternalScrollDomainOffsetProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollDomainOffsetProperty, value);
                }
                else
                {
                    SetInternalScrollDomainOffsetProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPositionDelta property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScrollPositionDelta
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollPositionDeltaProperty);
                }
                else
                {
                    return (Vector2)GetInternalScrollPositionDeltaProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollPositionDeltaProperty, value);
                }
                else
                {
                    SetInternalScrollPositionDeltaProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets and Gets StartPagePosition property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 StartPagePosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector3)GetValue(StartPagePositionProperty);
                }
                else
                {
                    return (Vector3)GetInternalStartPagePositionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(StartPagePositionProperty, value);
                }
                else
                {
                    SetInternalStartPagePositionProperty(this, null, value);
                }
            }
        }


        /// <summary>
        /// Sets and Gets ScrollMode property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap ScrollMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(ScrollModeProperty);
                }
                else
                {
                    return (PropertyMap)GetInternalScrollModeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollModeProperty, value);
                }
                else
                {
                    SetInternalScrollModeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets snap-animation's AlphaFunction.
        /// </summary>
        /// <returns>Current easing alpha function of the snap animation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction GetScrollSnapAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(Interop.ScrollView.GetScrollSnapAlphaFunction(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets snap-animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the snap animation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSnapAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.SetScrollSnapAlphaFunction(SwigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets flick-animation's AlphaFunction.
        /// </summary>
        /// <returns>Current easing alpha function of the flick animation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction GetScrollFlickAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(Interop.ScrollView.GetScrollFlickAlphaFunction(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets flick-animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the flick animation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollFlickAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.SetScrollFlickAlphaFunction(SwigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the time for the scroll snap-animation.
        /// </summary>
        /// <returns>The time in seconds for the animation to take.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetScrollSnapDuration()
        {
            float ret = Interop.ScrollView.GetScrollSnapDuration(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the time for the scroll snap-animation.
        /// </summary>
        /// <param name="time">The time in seconds for the animation to take.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSnapDuration(float time)
        {
            Interop.ScrollView.SetScrollSnapDuration(SwigCPtr, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the time for the scroll flick-animation.
        /// </summary>
        /// <returns>The time in seconds for the animation to take.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetScrollFlickDuration()
        {
            float ret = Interop.ScrollView.GetScrollFlickDuration(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the time for the scroll snap-animation.
        /// </summary>
        /// <param name="time">The time in seconds for the animation to take.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollFlickDuration(float time)
        {
            Interop.ScrollView.SetScrollFlickDuration(SwigCPtr, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets scroll sensibility of pan gesture.
        /// </summary>
        /// <param name="sensitive">True to enable scroll, false to disable scrolling.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollSensitive(bool sensitive)
        {
            Interop.ScrollView.SetScrollSensitive(SwigCPtr, sensitive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets maximum overshoot amount.
        /// </summary>
        /// <param name="overshootX">The maximum number of horizontally scrolled pixels before overshoot X reaches 1.0f.</param>
        /// <param name="overshootY">The maximum number of vertically scrolled pixels before overshoot X reaches 1.0f.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaxOvershoot(float overshootX, float overshootY)
        {
            Interop.ScrollView.SetMaxOvershoot(SwigCPtr, overshootX, overshootY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets Snap Overshoot animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the overshoot snap animation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSnapOvershootAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.SetSnapOvershootAlphaFunction(SwigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets Snap Overshoot animation's Duration.
        /// </summary>
        /// <param name="duration">duration The duration of the overshoot snap animation.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSnapOvershootDuration(float duration)
        {
            Interop.ScrollView.SetSnapOvershootDuration(SwigCPtr, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enables or Disables Actor Auto-Snap mode.<br />
        /// When Actor Auto-Snap mode has been enabled, ScrollView will automatically,
        /// snap to the closest actor (The closest actor will appear in the center of the ScrollView).
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) Actor AutoSnap.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetViewAutoSnap(bool enable)
        {
            Interop.ScrollView.SetActorAutoSnap(SwigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enables or Disables Wrap mode for ScrollView contents.<br />
        /// When enabled, the ScrollView contents are wrapped over the X/Y Domain.
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) Wrap Mode.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWrapMode(bool enable)
        {
            Interop.ScrollView.SetWrapMode(SwigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current distance needed to scroll for ScrollUpdatedSignal to be emitted.
        /// </summary>
        /// <returns>Current scroll update distance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetScrollUpdateDistance()
        {
            int ret = Interop.ScrollView.GetScrollUpdateDistance(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the distance needed to scroll for ScrollUpdatedSignal to be emitted.<br />
        /// The scroll update distance tells ScrollView how far to move before ScrollUpdatedSignal the informs application.<br />
        /// Each time the ScrollView crosses this distance the signal will be emitted.<br />
        /// </summary>
        /// <param name="distance">The distance for ScrollView to move before emitting update signal.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollUpdateDistance(int distance)
        {
            Interop.ScrollView.SetScrollUpdateDistance(SwigCPtr, distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns state of Axis Auto Lock mode.
        /// </summary>
        /// <returns>Whether Axis Auto Lock mode has been enabled or not.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetAxisAutoLock()
        {
            bool ret = Interop.ScrollView.GetAxisAutoLock(SwigCPtr);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAxisAutoLock(bool enable)
        {
            Interop.ScrollView.SetAxisAutoLock(SwigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the gradient threshold at which a panning gesture should be locked to the Horizontal or Vertical axis.
        /// </summary>
        /// <returns>The gradient, a value between 0.0 and 1.0f.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetAxisAutoLockGradient()
        {
            float ret = Interop.ScrollView.GetAxisAutoLockGradient(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the gradient threshold at which a panning gesture should be locked to the Horizontal or Vertical axis.<br />
        /// By default, this is 0.36 (0.36:1) which means angles less than 20 degrees to an axis will lock to that axis.<br />
        /// </summary>
        /// <param name="gradient">gradient A value between 0.0 and 1.0 (auto-lock for all angles).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAxisAutoLockGradient(float gradient)
        {
            Interop.ScrollView.SetAxisAutoLockGradient(SwigCPtr, gradient);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the friction coefficient setting for ScrollView when flicking in free panning mode.
        /// This is a value in stage-diagonals per second^2, stage-diagonal = Length( stage.width, stage.height )
        /// </summary>
        /// <returns>Friction coefficient is returned.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFrictionCoefficient()
        {
            float ret = Interop.ScrollView.GetFrictionCoefficient(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the friction coefficient for ScrollView when flicking.<br />
        /// </summary>
        /// <param name="friction">Friction coefficient must be greater than 0.0 (default = 1.0).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFrictionCoefficient(float friction)
        {
            Interop.ScrollView.SetFrictionCoefficient(SwigCPtr, friction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the flick speed coefficient for ScrollView when flicking in free panning mode.<br />
        /// This is a constant which multiplies the input touch flick velocity to determine the actual velocity at which to move the scrolling area.
        /// </summary>
        /// <returns>The flick speed coefficient is returned.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetFlickSpeedCoefficient()
        {
            float ret = Interop.ScrollView.GetFlickSpeedCoefficient(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the flick speed coefficient for ScrollView when flicking in free panning mode.<br />
        /// This is a constant which multiplies the input touch flick velocity to determine the actual velocity at
        /// which to move the scrolling area.<br />
        /// </summary>
        /// <param name="speed">The flick speed coefficient (default = 1.0).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFlickSpeedCoefficient(float speed)
        {
            Interop.ScrollView.SetFlickSpeedCoefficient(SwigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the minimum pan distance required for a flick gesture in pixels.<br />
        /// </summary>
        /// <returns>Minimum pan distance vector with separate x and y distance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetMinimumDistanceForFlick()
        {
            Vector2 ret = new Vector2(Interop.ScrollView.GetMinimumDistanceForFlick(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the minimum pan distance required for a flick in pixels.<br />
        /// Takes a Vector2 containing separate x and y values. As long as the pan distance exceeds one of these axes, a flick will be allowed.
        /// </summary>
        /// <param name="distance">The flick speed coefficient (default = 1.0).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumDistanceForFlick(Vector2 distance)
        {
            Interop.ScrollView.SetMinimumDistanceForFlick(SwigCPtr, Vector2.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the minimum pan speed required for a flick gesture in pixels per second.
        /// </summary>
        /// <returns>Minimum pan speed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMinimumSpeedForFlick()
        {
            float ret = Interop.ScrollView.GetMinimumSpeedForFlick(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the minimum pan speed required for a flick in pixels per second.<br />
        /// </summary>
        /// <param name="speed">The minimum pan speed for a flick.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumSpeedForFlick(float speed)
        {
            Interop.ScrollView.SetMinimumSpeedForFlick(SwigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the maximum flick speed setting for ScrollView when flicking in free panning mode.<br />
        /// This is a value in stage-diagonals per second.
        /// </summary>
        /// <returns>Maximum flick speed is returned.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetMaxFlickSpeed()
        {
            float ret = Interop.ScrollView.GetMaxFlickSpeed(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the maximum flick speed for the ScrollView when flicking in free panning mode.<br />
        /// This is a value in stage-diagonals per second. stage-diagonal = Length( stage.width, stage.height ).<br />
        /// </summary>
        /// <param name="speed">Maximum flick speed (default = 3.0).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaxFlickSpeed(float speed)
        {
            Interop.ScrollView.SetMaxFlickSpeed(SwigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves current scroll position.<br />
        /// </summary>
        /// <returns>The current scroll position.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetCurrentScrollPosition()
        {
            Vector2 ret = new Vector2(Interop.ScrollView.GetCurrentScrollPosition(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves current scroll page based on ScrollView dimensions being the size of one page, and all pages laid out in<br />
        /// a grid fashion, increasing from left to right until the end of the X-domain.
        /// </summary>
        /// <returns>The current scroll position.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetCurrentPage()
        {
            uint ret = Interop.ScrollView.GetCurrentPage(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position)
        {
            Interop.ScrollView.ScrollToVector2(SwigCPtr, Vector2.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration)
        {
            Interop.ScrollView.ScrollTo(SwigCPtr, Vector2.getCPtr(position), duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="alpha">The alpha function to use.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha)
        {
            Interop.ScrollView.ScrollTo(SwigCPtr, Vector2.getCPtr(position), duration, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="horizontalBias">Whether to bias scrolling to left or right.</param>
        /// <param name="verticalBias">Whether to bias scrolling to top or bottom.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            Interop.ScrollView.ScrollTo(SwigCPtr, Vector2.getCPtr(position), duration, (int)horizontalBias, (int)verticalBias);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            Interop.ScrollView.ScrollTo(SwigCPtr, Vector2.getCPtr(position), duration, AlphaFunction.getCPtr(alpha), (int)horizontalBias, (int)verticalBias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page)
        {
            Interop.ScrollView.ScrollTo(SwigCPtr, page);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page, float duration)
        {
            Interop.ScrollView.ScrollTo(SwigCPtr, page, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="bias">Whether to bias scrolling to left or right.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(uint page, float duration, DirectionBias bias)
        {
            Interop.ScrollView.ScrollTo(SwigCPtr, page, duration, (int)bias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="view">The view to center in on (via Scrolling).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(View view)
        {
            Interop.ScrollView.ScrollToView(SwigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="view">The view to center in on (via Scrolling).</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(View view, float duration)
        {
            Interop.ScrollView.ScrollToViewDuration(SwigCPtr, View.getCPtr(view), duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to the nearest snap points as specified by the Rulers.<br />
        /// If already at snap points, then will return false, and not scroll.<br />
        /// </summary>
        /// <returns>True if Snapping necessary.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScrollToSnapPoint()
        {
            bool ret = Interop.ScrollView.ScrollToSnapPoint(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Applies Effect to ScrollView.
        /// </summary>
        /// <param name="effect">The effect to apply to scroll view.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyEffect(ScrollViewEffect effect)
        {
            Interop.ScrollView.ApplyEffect(SwigCPtr, ScrollViewEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes Effect from ScrollView.
        /// </summary>
        /// <param name="effect">The effect to remove.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveEffect(ScrollViewEffect effect)
        {
            Interop.ScrollView.RemoveEffect(SwigCPtr, ScrollViewEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Remove All Effects from ScrollView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAllEffects()
        {
            Interop.ScrollView.RemoveAllEffects(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Binds view to this ScrollView.
        /// Once an actor is bound to a ScrollView, it will be subject to that ScrollView's properties.
        /// </summary>
        /// <param name="child">The view to add to this ScrollView.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BindView(View child)
        {
            Interop.ScrollView.BindActor(SwigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Unbinds view to this ScrollView.
        /// Once an actor is bound to a ScrollView, it will be subject to that ScrollView's properties.
        /// </summary>
        /// <param name="child">The view to remove to this ScrollView.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UnbindView(View child)
        {
            Interop.ScrollView.UnbindActor(SwigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows the user to constrain the scroll view in a particular direction.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <param name="threshold">The threshold to apply around the axis.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollingDirection(Radian direction, Radian threshold)
        {
            Interop.ScrollView.SetScrollingDirection(SwigCPtr, Radian.getCPtr(direction), Radian.getCPtr(threshold));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows the user to constrain the scroll view in a particular direction.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollingDirection(Radian direction)
        {
            Interop.ScrollView.SetScrollingDirection(SwigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a direction constraint from the scroll view.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveScrollingDirection(Radian direction)
        {
            Interop.ScrollView.RemoveScrollingDirection(SwigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set ruler X
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRulerX(RulerPtr ruler)
        {
            Interop.ScrollView.SetRulerX(SwigCPtr, RulerPtr.getCPtr(ruler));
        }

        /// <summary>
        /// Set ruler Y
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetRulerY(RulerPtr ruler)
        {
            Interop.ScrollView.SetRulerY(SwigCPtr, RulerPtr.getCPtr(ruler));
        }

        internal void ApplyConstraintToChildren(Constraint constraint)
        {
            Interop.ScrollView.ApplyConstraintToChildren(SwigCPtr, constraint.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type">the dispose type</param>
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

            if (this != null && scrollViewSnapStartedCallbackDelegate != null)
            {
                ScrollViewSnapStartedSignal snapStarted = this.SnapStartedSignal();
                snapStarted?.Disconnect(scrollViewSnapStartedCallbackDelegate);
                snapStarted?.Dispose();
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
        /// This should be internal, do not use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CA1716, CA1052, CA1034 // Identifiers should not match keywords
        public new class Property
#pragma warning restore CA1716, CA1052, CA1034 // Identifiers should not match keywords
        {
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int WrapEnabled = Interop.ScrollView.WrapEnabledGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int PanningEnabled = Interop.ScrollView.PanningEnabledGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int AxisAutoLockEnabled = Interop.ScrollView.AxisAutoLockEnabledGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int WheelScrollDistanceStep = Interop.ScrollView.WheelScrollDistanceStepGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollMode = Interop.ScrollView.ScrollModeGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPosition = Interop.ScrollView.ScrollPositionGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePosition = Interop.ScrollView.ScrollPrePositionGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionX = Interop.ScrollView.ScrollPrePositionXGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionY = Interop.ScrollView.ScrollPrePositionYGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionMax = Interop.ScrollView.ScrollPrePositionMaxGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionMaxX = Interop.ScrollView.ScrollPrePositionMaxXGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPrePositionMaxY = Interop.ScrollView.ScrollPrePositionMaxYGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int OvershootX = Interop.ScrollView.OvershootXGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int OvershootY = Interop.ScrollView.OvershootYGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollFinal = Interop.ScrollView.ScrollFinalGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollFinalX = Interop.ScrollView.ScrollFinalXGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollFinalY = Interop.ScrollView.ScrollFinalYGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int WRAP = Interop.ScrollView.WrapGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int PANNING = Interop.ScrollView.PanningGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int SCROLLING = Interop.ScrollView.ScrollingGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDomainSize = Interop.ScrollView.ScrollDomainSizeGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDomainSizeX = Interop.ScrollView.ScrollDomainSizeXGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDomainSizeY = Interop.ScrollView.ScrollDomainSizeYGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollDomainOffset = Interop.ScrollView.ScrollDomainOffsetGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int ScrollPositionDelta = Interop.ScrollView.ScrollPositionDeltaGet();
            /// <summary>
            /// This should be internal, do not use.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly int StartPagePosition = Interop.ScrollView.StartPagePositionGet();
        }
    }
}
