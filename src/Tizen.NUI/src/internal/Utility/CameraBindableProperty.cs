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
        public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(string), typeof(Tizen.NUI.Camera), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalType = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalType;
        });

        /// <summary>
        /// ProjectionModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProjectionModeProperty = BindableProperty.Create(nameof(ProjectionMode), typeof(string), typeof(Tizen.NUI.Camera), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalProjectionMode = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalProjectionMode;
        });

        /// <summary>
        /// FieldOfViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FieldOfViewProperty = BindableProperty.Create(nameof(FieldOfView), typeof(float), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalFieldOfView = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalFieldOfView;
        });

        /// <summary>
        /// AspectRatioProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AspectRatioProperty = BindableProperty.Create(nameof(AspectRatio), typeof(float), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalAspectRatio = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalAspectRatio;
        });

        /// <summary>
        /// NearPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NearPlaneDistanceProperty = BindableProperty.Create(nameof(NearPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalNearPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalNearPlaneDistance;
        });

        /// <summary>
        /// FarPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FarPlaneDistanceProperty = BindableProperty.Create(nameof(FarPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalFarPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalFarPlaneDistance;
        });

        /// <summary>
        /// LeftPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftPlaneDistanceProperty = BindableProperty.Create(nameof(LeftPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalLeftPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalLeftPlaneDistance;
        });

        /// <summary>
        /// RightPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightPlaneDistanceProperty = BindableProperty.Create(nameof(RightPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalRightPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalRightPlaneDistance;
        });

        /// <summary>
        /// TopPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TopPlaneDistanceProperty = BindableProperty.Create(nameof(TopPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalTopPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalTopPlaneDistance;
        });

        /// <summary>
        /// BottomPlaneDistanceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BottomPlaneDistanceProperty = BindableProperty.Create(nameof(BottomPlaneDistance), typeof(float), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalBottomPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalBottomPlaneDistance;
        });

        /// <summary>
        /// TargetPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TargetPositionProperty = BindableProperty.Create(nameof(TargetPosition), typeof(Tizen.NUI.Vector3), typeof(Tizen.NUI.Camera), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalTargetPosition = (Tizen.NUI.Vector3)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalTargetPosition;
        });

        /// <summary>
        /// InvertYAxisProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InvertYAxisProperty = BindableProperty.Create(nameof(InvertYAxis), typeof(bool), typeof(Tizen.NUI.Camera), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalInvertYAxis = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Camera)bindable;
            return instance.InternalInvertYAxis;
        });
    }
}
