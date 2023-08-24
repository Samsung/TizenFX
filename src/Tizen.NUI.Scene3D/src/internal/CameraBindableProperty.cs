/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Scene3D
{
    public partial class Camera
    {
        /// <summary>
        /// ProjectionModeProperty
        /// </summary>
        internal static readonly BindableProperty ProjectionProperty = BindableProperty.Create(nameof(ProjectionMode), typeof(ProjectionModeType), typeof(Tizen.NUI.Scene3D.Camera), ProjectionModeType.Perspective, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalProjectionMode = (ProjectionModeType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalProjectionMode;
        });

        /// <summary>
        /// ProjectionDirectionProperty
        /// </summary>
        internal static readonly BindableProperty ProjectionDirectionProperty = BindableProperty.Create(nameof(ProjectionDirection), typeof(ProjectionDirectionType), typeof(Tizen.NUI.Scene3D.Camera), ProjectionDirectionType.Vertical, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                // Keep previous orthographicSize.
                float orthographicSize = instance.OrthographicSize;
                instance.InternalProjectionDirection = (ProjectionDirectionType)newValue;

                // Recalculate orthographicSize by changed direction.
                instance.OrthographicSize = orthographicSize;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalProjectionDirection;
        });

        /// <summary>
        /// FieldOfViewProperty
        /// </summary>
        internal static readonly BindableProperty FieldOfViewProperty = BindableProperty.Create(nameof(FieldOfView), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalFieldOfView = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalFieldOfView;
        });

        /// <summary>
        /// OrthographicSizeProperty
        /// </summary>
        internal static readonly BindableProperty OrthographicSizeProperty = BindableProperty.Create(nameof(OrthographicSize), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalOrthographicSize = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalOrthographicSize;
        });

        /// <summary>
        /// AspectRatioProperty
        /// </summary>
        internal static readonly BindableProperty AspectRatioProperty = BindableProperty.Create(nameof(AspectRatio), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalAspectRatio = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalAspectRatio;
        });

        /// <summary>
        /// NearPlaneDistanceProperty
        /// </summary>
        internal static readonly BindableProperty NearPlaneDistanceProperty = BindableProperty.Create(nameof(NearPlaneDistance), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalNearPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalNearPlaneDistance;
        });

        /// <summary>
        /// FarPlaneDistanceProperty
        /// </summary>
        internal static readonly BindableProperty FarPlaneDistanceProperty = BindableProperty.Create(nameof(FarPlaneDistance), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalFarPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalFarPlaneDistance;
        });

        /// <summary>
        /// LeftPlaneDistanceProperty
        /// </summary>
        internal static readonly BindableProperty LeftPlaneDistanceProperty = BindableProperty.Create(nameof(LeftPlaneDistance), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalLeftPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalLeftPlaneDistance;
        });

        /// <summary>
        /// RightPlaneDistanceProperty
        /// </summary>
        internal static readonly BindableProperty RightPlaneDistanceProperty = BindableProperty.Create(nameof(RightPlaneDistance), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalRightPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalRightPlaneDistance;
        });

        /// <summary>
        /// TopPlaneDistanceProperty
        /// </summary>
        internal static readonly BindableProperty TopPlaneDistanceProperty = BindableProperty.Create(nameof(TopPlaneDistance), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalTopPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalTopPlaneDistance;
        });

        /// <summary>
        /// BottomPlaneDistanceProperty
        /// </summary>
        internal static readonly BindableProperty BottomPlaneDistanceProperty = BindableProperty.Create(nameof(BottomPlaneDistance), typeof(float), typeof(Tizen.NUI.Scene3D.Camera), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalBottomPlaneDistance = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalBottomPlaneDistance;
        });

        /// <summary>
        /// InvertYAxisProperty
        /// </summary>
        internal static readonly BindableProperty InvertYAxisProperty = BindableProperty.Create(nameof(InvertYAxis), typeof(bool), typeof(Tizen.NUI.Scene3D.Camera), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            if (newValue != null)
            {
                instance.InternalInvertYAxis = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Scene3D.Camera)bindable;
            return instance.InternalInvertYAxis;
        });
    }
}
