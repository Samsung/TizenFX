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
        public static readonly BindableProperty WrapEnabledProperty = BindableProperty.Create(nameof(WrapEnabled), typeof(bool), typeof(ScrollView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WrapEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WrapEnabled).Get(out temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PanningEnabledProperty = BindableProperty.Create(nameof(PanningEnabled), typeof(bool), typeof(ScrollView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.PanningEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.PanningEnabled).Get(out temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AxisAutoLockEnabledProperty = BindableProperty.Create(nameof(AxisAutoLockEnabled), typeof(bool), typeof(ScrollView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.AxisAutoLockEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.AxisAutoLockEnabled).Get(out temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WheelScrollDistanceStepProperty = BindableProperty.Create(nameof(WheelScrollDistanceStep), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WheelScrollDistanceStep, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WheelScrollDistanceStep).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionProperty = BindableProperty.Create(nameof(ScrollPosition), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPosition, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPosition).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPrePositionProperty = BindableProperty.Create(nameof(ScrollPrePosition), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPrePosition, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPrePosition).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPrePositionMaxProperty = BindableProperty.Create(nameof(ScrollPrePositionMax), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPrePositionMax, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPrePositionMax).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootXProperty = BindableProperty.Create(nameof(OvershootX), typeof(float), typeof(ScrollView), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.OvershootX, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.OvershootX).Get(out temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootYProperty = BindableProperty.Create(nameof(OvershootY), typeof(float), typeof(ScrollView), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.OvershootY, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.OvershootY).Get(out temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollFinalProperty = BindableProperty.Create(nameof(ScrollFinal), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollFinal, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollFinal).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapProperty = BindableProperty.Create(nameof(Wrap), typeof(bool), typeof(ScrollView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WRAP, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.WRAP).Get(out temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PanningProperty = BindableProperty.Create(nameof(Panning), typeof(bool), typeof(ScrollView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.PANNING, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.PANNING).Get(out temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollingProperty = BindableProperty.Create(nameof(Scrolling), typeof(bool), typeof(ScrollView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.SCROLLING, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.SCROLLING).Get(out temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDomainSizeProperty = BindableProperty.Create(nameof(ScrollDomainSize), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollDomainSize, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollDomainSize).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDomainOffsetProperty = BindableProperty.Create(nameof(ScrollDomainOffset), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollDomainOffset, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollDomainOffset).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionDeltaProperty = BindableProperty.Create(nameof(ScrollPositionDelta), typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPositionDelta, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollPositionDelta).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StartPagePositionProperty = BindableProperty.Create(nameof(StartPagePosition), typeof(Vector3), typeof(ScrollView), Vector3.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.StartPagePosition, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.StartPagePosition).Get(temp);
            return temp;
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollModeProperty = BindableProperty.Create(nameof(ScrollMode), typeof(PropertyMap), typeof(ScrollView), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollMode, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            PropertyValue value = Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)scrollView.SwigCPtr, ScrollView.Property.ScrollMode);
            PropertyMap map = new PropertyMap();
            value.Get(map);
            return map;
        }));
    }
}
