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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    public partial class ItemView
    {
        /// <summary>
        /// LayoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new readonly BindableProperty LayoutProperty = BindableProperty.Create(nameof(Layout), typeof(Tizen.NUI.PropertyArray), typeof(ItemView), null,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalLayout = (Tizen.NUI.PropertyArray)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalLayout;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// MinimumSwipeSpeedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSwipeSpeedProperty = BindableProperty.Create(nameof(MinimumSwipeSpeed), typeof(float), typeof(ItemView), default(float),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalMinimumSwipeSpeed = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalMinimumSwipeSpeed;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// MinimumSwipeDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSwipeDistanceProperty = BindableProperty.Create(nameof(MinimumSwipeDistance), typeof(float), typeof(ItemView), default(float),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalMinimumSwipeDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalMinimumSwipeDistance;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// WheelScrollDistanceStepProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WheelScrollDistanceStepProperty = BindableProperty.Create(nameof(WheelScrollDistanceStep), typeof(float), typeof(ItemView), default(float),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalWheelScrollDistanceStep = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalWheelScrollDistanceStep;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// SnapToItemEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SnapToItemEnabledProperty = BindableProperty.Create(nameof(SnapToItemEnabled), typeof(bool), typeof(ItemView), true,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalSnapToItemEnabled = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalSnapToItemEnabled;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// RefreshIntervalProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RefreshIntervalProperty = BindableProperty.Create(nameof(RefreshInterval), typeof(float), typeof(ItemView), default(float),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalRefreshInterval = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalRefreshInterval;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// LayoutPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutPositionProperty = BindableProperty.Create(nameof(LayoutPosition), typeof(float), typeof(ItemView), default(float),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalLayoutPosition = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalLayoutPosition;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// ScrollSpeedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float), typeof(ItemView), default(float),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalScrollSpeed = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalScrollSpeed;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// OvershootProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootProperty = BindableProperty.Create(nameof(Overshoot), typeof(float), typeof(ItemView), default(float),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalOvershoot = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalOvershoot;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// ScrollDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDirectionProperty = BindableProperty.Create(nameof(ScrollDirection), typeof(Tizen.NUI.Vector2), typeof(ItemView), null,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalScrollDirection = (Tizen.NUI.Vector2)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalScrollDirection;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// LayoutOrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutOrientationProperty = BindableProperty.Create(nameof(LayoutOrientation), typeof(int), typeof(ItemView), 0,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalLayoutOrientation = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalLayoutOrientation;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// ScrollContentSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollContentSizeProperty = BindableProperty.Create(nameof(ScrollContentSize), typeof(float), typeof(ItemView), default(float),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalScrollContentSize = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalScrollContentSize;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);
    }
}
