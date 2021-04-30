/*
 * Copyright(c) 2019-2021 Samsung Electronics Co., Ltd.
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
        public static new BindableProperty LayoutProperty { get; } = BindableProperty.Create(nameof(Layout), typeof(Tizen.NUI.PropertyArray), typeof(Tizen.NUI.ItemView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// MinimumSwipeSpeedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty MinimumSwipeSpeedProperty { get; } = BindableProperty.Create(nameof(MinimumSwipeSpeed), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// MinimumSwipeDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty MinimumSwipeDistanceProperty { get; } = BindableProperty.Create(nameof(MinimumSwipeDistance), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// WheelScrollDistanceStepProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty WheelScrollDistanceStepProperty { get; } = BindableProperty.Create(nameof(WheelScrollDistanceStep), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// SnapToItemEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty SnapToItemEnabledProperty { get; } = BindableProperty.Create(nameof(SnapToItemEnabled), typeof(bool), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// RefreshIntervalProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty RefreshIntervalProperty { get; } = BindableProperty.Create(nameof(RefreshInterval), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// LayoutPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty LayoutPositionProperty { get; } = BindableProperty.Create(nameof(LayoutPosition), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// ScrollSpeedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ScrollSpeedProperty { get; } = BindableProperty.Create(nameof(ScrollSpeed), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// OvershootProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty OvershootProperty { get; } = BindableProperty.Create(nameof(Overshoot), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// ScrollDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ScrollDirectionProperty { get; } = BindableProperty.Create(nameof(ScrollDirection), typeof(Tizen.NUI.Vector2), typeof(Tizen.NUI.ItemView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// LayoutOrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty LayoutOrientationProperty { get; } = BindableProperty.Create(nameof(LayoutOrientation), typeof(int), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

        /// <summary>
        /// ScrollContentSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ScrollContentSizeProperty { get; } = BindableProperty.Create(nameof(ScrollContentSize), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        });

    }
}
