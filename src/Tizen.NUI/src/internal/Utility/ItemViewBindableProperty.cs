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
        public static BindableProperty LayoutProperty = null;
        internal static void SetInternalLayoutProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalLayout = (Tizen.NUI.PropertyArray)newValue;
            }
        }
        internal static object GetInternalLayoutProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalLayout;
        }

        /// <summary>
        /// MinimumSwipeSpeedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty MinimumSwipeSpeedProperty = null;
        internal static void SetInternalMinimumSwipeSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalMinimumSwipeSpeed = (float)newValue;
            }
        }
        internal static object GetInternalMinimumSwipeSpeedProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalMinimumSwipeSpeed;
        }

        /// <summary>
        /// MinimumSwipeDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty MinimumSwipeDistanceProperty = null;
        internal static void SetInternalMinimumSwipeDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalMinimumSwipeDistance = (float)newValue;
            }
        }
        internal static object GetInternalMinimumSwipeDistanceProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalMinimumSwipeDistance;
        }

        /// <summary>
        /// WheelScrollDistanceStepProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty WheelScrollDistanceStepProperty = null;
        internal static void SetInternalWheelScrollDistanceStepProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalWheelScrollDistanceStep = (float)newValue;
            }
        }
        internal static object GetInternalWheelScrollDistanceStepProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalWheelScrollDistanceStep;
        }

        /// <summary>
        /// SnapToItemEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty SnapToItemEnabledProperty = null;
        internal static void SetInternalSnapToItemEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalSnapToItemEnabled = (bool)newValue;
            }
        }
        internal static object GetInternalSnapToItemEnabledProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalSnapToItemEnabled;
        }

        /// <summary>
        /// RefreshIntervalProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty RefreshIntervalProperty = null;
        internal static void SetInternalRefreshIntervalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalRefreshInterval = (float)newValue;
            }
        }
        internal static object GetInternalRefreshIntervalProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalRefreshInterval;
        }

        /// <summary>
        /// LayoutPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty LayoutPositionProperty = null;
        internal static void SetInternalLayoutPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalLayoutPosition = (float)newValue;
            }
        }
        internal static object GetInternalLayoutPositionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalLayoutPosition;
        }

        /// <summary>
        /// ScrollSpeedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ScrollSpeedProperty = null;
        internal static void SetInternalScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalScrollSpeed = (float)newValue;
            }
        }
        internal static object GetInternalScrollSpeedProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalScrollSpeed;
        }

        /// <summary>
        /// OvershootProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty OvershootProperty = null;
        internal static void SetInternalOvershootProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalOvershoot = (float)newValue;
            }
        }
        internal static object GetInternalOvershootProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalOvershoot;
        }

        /// <summary>
        /// ScrollDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ScrollDirectionProperty = null;
        internal static void SetInternalScrollDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalScrollDirection = (Tizen.NUI.Vector2)newValue;
            }
        }
        internal static object GetInternalScrollDirectionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalScrollDirection;
        }

        /// <summary>
        /// LayoutOrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty LayoutOrientationProperty = null;
        internal static void SetInternalLayoutOrientationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalLayoutOrientation = (int)newValue;
            }
        }
        internal static object GetInternalLayoutOrientationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalLayoutOrientation;
        }

        /// <summary>
        /// ScrollContentSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ScrollContentSizeProperty = null;
        internal static void SetInternalScrollContentSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            if (newValue != null)
            {
                instance.InternalScrollContentSize = (float)newValue;
            }
        }
        internal static object GetInternalScrollContentSizeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.ItemView)bindable;
            return instance.InternalScrollContentSize;
        }
    }
}
