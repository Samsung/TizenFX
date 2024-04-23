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

using System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// ScrollView contains views that can be scrolled manually (via touch).
    /// </summary>
    public partial class ScrollView
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapEnabledProperty = null;

        internal static void SetInternalWrapEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WrapEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }
        
        internal static object GetInternalWrapEnabledProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WrapEnabled).Get(out temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PanningEnabledProperty = null;

        internal static void SetInternalPanningEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.PanningEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }
        
        internal static object GetInternalPanningEnabledProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.PanningEnabled).Get(out temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AxisAutoLockEnabledProperty = null;

        internal static void SetInternalAxisAutoLockEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.AxisAutoLockEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }
        
        internal static object GetInternalAxisAutoLockEnabledProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.AxisAutoLockEnabled).Get(out temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WheelScrollDistanceStepProperty = null;

        internal static void SetInternalWheelScrollDistanceStepProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WheelScrollDistanceStep, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        
        internal static object GetInternalWheelScrollDistanceStepProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WheelScrollDistanceStep).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionProperty = null;

        internal static void SetInternalScrollPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPosition, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        
        internal static object GetInternalScrollPositionProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPosition).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPrePositionProperty = null;

        internal static void SetInternalScrollPrePositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPrePosition, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        
        internal static object GetInternalScrollPrePositionProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPrePosition).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPrePositionMaxProperty = null;

        internal static void SetInternalScrollPrePositionMaxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPrePositionMax, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        
        internal static object GetInternalScrollPrePositionMaxProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPrePositionMax).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootXProperty = null;

        internal static void SetInternalOvershootXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.OvershootX, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }
        
        internal static object GetInternalOvershootXProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.OvershootX).Get(out temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootYProperty = null;

        internal static void SetInternalOvershootYProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.OvershootY, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }
        
        internal static object GetInternalOvershootYProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.OvershootY).Get(out temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollFinalProperty = null;

        internal static void SetInternalScrollFinalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollFinal, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        
        internal static object GetInternalScrollFinalProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollFinal).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapProperty = null;

        internal static void SetInternalWrapProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WRAP, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }
        
        internal static object GetInternalWrapProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WRAP).Get(out temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PanningProperty = null;

        internal static void SetInternalPanningProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.PANNING, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }
        
        internal static object GetInternalPanningProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.PANNING).Get(out temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollingProperty = null;

        internal static void SetInternalScrollingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.SCROLLING, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }
        
        internal static object GetInternalScrollingProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.SCROLLING).Get(out temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDomainSizeProperty = null;

        internal static void SetInternalScrollDomainSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollDomainSize, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        
        internal static object GetInternalScrollDomainSizeProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollDomainSize).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDomainOffsetProperty = null;

        internal static void SetInternalScrollDomainOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollDomainOffset, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        
        internal static object GetInternalScrollDomainOffsetProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollDomainOffset).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionDeltaProperty = null;

        internal static void SetInternalScrollPositionDeltaProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPositionDelta, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }
        
        internal static object GetInternalScrollPositionDeltaProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPositionDelta).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StartPagePositionProperty = null;

        internal static void SetInternalStartPagePositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.StartPagePosition, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        }
        
        internal static object GetInternalStartPagePositionProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.StartPagePosition).Get(temp);
            return temp;
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollModeProperty = null;

        internal static void SetInternalScrollModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollMode, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalScrollModeProperty(BindableObject bindable)
        {
            var scrollView = (ScrollView)bindable;
            PropertyValue value = Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollMode);
            PropertyMap map = new PropertyMap();
            value.Get(map);
            return map;
        }
    }
}
