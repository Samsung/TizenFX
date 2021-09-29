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
        public static new readonly BindableProperty LayoutProperty = BindableProperty.Create(nameof(Layout), typeof(Tizen.NUI.PropertyArray), typeof(Tizen.NUI.ItemView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty MinimumSwipeSpeedProperty = BindableProperty.Create(nameof(MinimumSwipeSpeed), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty MinimumSwipeDistanceProperty = BindableProperty.Create(nameof(MinimumSwipeDistance), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty WheelScrollDistanceStepProperty = BindableProperty.Create(nameof(WheelScrollDistanceStep), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SnapToItemEnabledProperty = BindableProperty.Create(nameof(SnapToItemEnabled), typeof(bool), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty RefreshIntervalProperty = BindableProperty.Create(nameof(RefreshInterval), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty LayoutPositionProperty = BindableProperty.Create(nameof(LayoutPosition), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty OvershootProperty = BindableProperty.Create(nameof(Overshoot), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ScrollDirectionProperty = BindableProperty.Create(nameof(ScrollDirection), typeof(Tizen.NUI.Vector2), typeof(Tizen.NUI.ItemView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty LayoutOrientationProperty = BindableProperty.Create(nameof(LayoutOrientation), typeof(int), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ScrollContentSizeProperty = BindableProperty.Create(nameof(ScrollContentSize), typeof(float), typeof(Tizen.NUI.ItemView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
