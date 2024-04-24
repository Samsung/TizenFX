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
    public partial class Camera
    {
        /// <summary>
        /// TypeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty TypeProperty = null;
        internal static void SetInternalTypeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalType = (string)newValue;
            }
        }
        internal static object GetInternalTypeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalType;
        }

        /// <summary>
        /// ProjectionModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ProjectionModeProperty = null;
        internal static void SetInternalProjectionModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalProjectionMode = (string)newValue;
            }
        }
        internal static object GetInternalProjectionModeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalProjectionMode;
        }

        /// <summary>
        /// FieldOfViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty FieldOfViewProperty = null;
        internal static void SetInternalFieldOfViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalFieldOfView = (float)newValue;
            }
        }
        internal static object GetInternalFieldOfViewProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalFieldOfView;
        }

        /// <summary>
        /// AspectRatioProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty AspectRatioProperty = null;
        internal static void SetInternalAspectRatioProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalAspectRatio = (float)newValue;
            }
        }
        internal static object GetInternalAspectRatioProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalAspectRatio;
        }

        /// <summary>
        /// NearPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty NearPlaneDistanceProperty = null;
        internal static void SetInternalNearPlaneDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalNearPlaneDistance = (float)newValue;
            }
        }
        internal static object GetInternalNearPlaneDistanceProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalNearPlaneDistance;
        }

        /// <summary>
        /// FarPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty FarPlaneDistanceProperty = null;
        internal static void SetInternalFarPlaneDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalFarPlaneDistance = (float)newValue;
            }
        }
        internal static object GetInternalFarPlaneDistanceProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalFarPlaneDistance;
        }

        /// <summary>
        /// LeftPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty LeftPlaneDistanceProperty = null;
        internal static void SetInternalLeftPlaneDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalLeftPlaneDistance = (float)newValue;
            }
        }
        internal static object GetInternalLeftPlaneDistanceProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalLeftPlaneDistance;
        }

        /// <summary>
        /// RightPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty RightPlaneDistanceProperty = null;
        internal static void SetInternalRightPlaneDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalRightPlaneDistance = (float)newValue;
            }
        }
        internal static object GetInternalRightPlaneDistanceProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalRightPlaneDistance;
        }

        /// <summary>
        /// TopPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty TopPlaneDistanceProperty = null;
        internal static void SetInternalTopPlaneDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalTopPlaneDistance = (float)newValue;
            }
        }
        internal static object GetInternalTopPlaneDistanceProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalTopPlaneDistance;
        }

        /// <summary>
        /// BottomPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty BottomPlaneDistanceProperty = null;
        internal static void SetInternalBottomPlaneDistanceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalBottomPlaneDistance = (float)newValue;
            }
        }
        internal static object GetInternalBottomPlaneDistanceProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalBottomPlaneDistance;
        }

        /// <summary>
        /// TargetPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty TargetPositionProperty = null;
        internal static void SetInternalTargetPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalTargetPosition = (Tizen.NUI.Vector3)newValue;
            }
        }
        internal static object GetInternalTargetPositionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalTargetPosition;
        }

        /// <summary>
        /// InvertYAxisProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty InvertYAxisProperty = null;
        internal static void SetInternalInvertYAxisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalInvertYAxis = (bool)newValue;
            }
        }
        internal static object GetInternalInvertYAxisProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalInvertYAxis;
        }
    }
}
