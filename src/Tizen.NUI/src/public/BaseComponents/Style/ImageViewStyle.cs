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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageViewStyle : ViewStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceUrlProperty = null;
        internal static void SetInternalResourceUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.resourceUrl = ((Selector<string>)newValue)?.Clone();
        }
        internal static object GetInternalResourceUrlProperty(BindableObject bindable)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.resourceUrl;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderProperty = null;
        internal static void SetInternalBorderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.border = ((Selector<Rectangle>)newValue)?.Clone();
        }
        internal static object GetInternalBorderProperty(BindableObject bindable)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.border;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderOnlyProperty = null;
        internal static void SetInternalBorderOnlyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.borderOnly = (bool?)newValue;
        }
        internal static object GetInternalBorderOnlyProperty(BindableObject bindable)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.borderOnly;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronosLoadingProperty = null;
        internal static void SetInternalSynchronosLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.synchronousLoading = (bool?)newValue;
        }
        internal static object GetInternalSynchronosLoadingProperty(BindableObject bindable)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.synchronousLoading;
        }

        /// This will be public opened in tizen_7.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronousLoadingProperty = null;
        internal static void SetInternalSynchronousLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.synchronousLoading = (bool?)newValue;
        }
        internal static object GetInternalSynchronousLoadingProperty(BindableObject bindable)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.synchronousLoading;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationCorrectionProperty = null;
        internal static void SetInternalOrientationCorrectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.orientationCorrection = (bool?)newValue;
        }
        internal static object GetInternalOrientationCorrectionProperty(BindableObject bindable)
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.orientationCorrection;
        }

        private bool? borderOnly;
        private bool? synchronousLoading;
        private bool? orientationCorrection;
        private Selector<string> resourceUrl;
        private Selector<Rectangle> border;

        static ImageViewStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                ResourceUrlProperty = BindableProperty.Create(nameof(ResourceUrl), typeof(Selector<string>), typeof(ImageViewStyle), null,
                    propertyChanged: SetInternalResourceUrlProperty, defaultValueCreator: GetInternalResourceUrlProperty);
                BorderProperty = BindableProperty.Create(nameof(Border), typeof(Selector<Rectangle>), typeof(ImageViewStyle), null,
                    propertyChanged: SetInternalBorderProperty, defaultValueCreator: GetInternalBorderProperty);
                BorderOnlyProperty = BindableProperty.Create(nameof(BorderOnly), typeof(bool?), typeof(ImageViewStyle), null,
                    propertyChanged: SetInternalBorderOnlyProperty, defaultValueCreator: GetInternalBorderOnlyProperty);
                SynchronosLoadingProperty = BindableProperty.Create(nameof(SynchronousLoading), typeof(bool?), typeof(ImageViewStyle), null,
                    propertyChanged: SetInternalSynchronosLoadingProperty, defaultValueCreator: GetInternalSynchronosLoadingProperty);
                SynchronousLoadingProperty = BindableProperty.Create(nameof(SynchronousLoading), typeof(bool?), typeof(ImageViewStyle), null,
                    propertyChanged: SetInternalSynchronousLoadingProperty, defaultValueCreator: GetInternalSynchronousLoadingProperty);
                OrientationCorrectionProperty = BindableProperty.Create(nameof(OrientationCorrection), typeof(bool?), typeof(ImageViewStyle), null,
                    propertyChanged: SetInternalOrientationCorrectionProperty, defaultValueCreator: GetInternalOrientationCorrectionProperty);
            }
        }

        /// <summary>
        /// Create an empty instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle() : base()
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? BorderOnly
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(BorderOnlyProperty);
                }
                else
                {
                    return (bool?)GetInternalBorderOnlyProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderOnlyProperty, value);
                }
                else
                {
                    SetInternalBorderOnlyProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SynchronosLoading
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(SynchronosLoadingProperty);
                }
                else
                {
                    return (bool?)GetInternalSynchronosLoadingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SynchronosLoadingProperty, value);
                }
                else
                {
                    SetInternalSynchronosLoadingProperty(this, null, value); 
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SynchronousLoading
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(SynchronousLoadingProperty);
                }
                else
                {
                    return (bool?)GetInternalSynchronousLoadingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SynchronousLoadingProperty, value);
                }
                else
                {
                    SetInternalSynchronousLoadingProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? OrientationCorrection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(OrientationCorrectionProperty);
                }
                else
                {
                    return (bool?)GetInternalOrientationCorrectionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OrientationCorrectionProperty, value);
                }
                else
                {
                    SetInternalOrientationCorrectionProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Image URL.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> ResourceUrl
        {
            get
            {
                Selector<string> tmp = null;
                if (NUIApplication.IsUsingXaml)
                {
                    tmp = (Selector<string>)GetValue(ResourceUrlProperty);
                }
                else
                {
                    tmp = (Selector<string>)GetInternalResourceUrlProperty(this);
                }
                return (null != tmp) ? tmp : resourceUrl = new Selector<string>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ResourceUrlProperty, value);
                }
                else
                {
                    SetInternalResourceUrlProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Image border.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> Border
        {
            get
            {
                Selector<Rectangle> tmp = null;
                if (NUIApplication.IsUsingXaml)
                {
                    tmp = (Selector<Rectangle>)GetValue(BorderProperty);
                }
                else
                {
                    tmp = (Selector<Rectangle>)GetInternalBorderProperty(this);
                }
                return (null != tmp) ? tmp : border = new Selector<Rectangle>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderProperty, value);
                }
                else
                {
                    SetInternalBorderProperty(this, null, value);
                }
            }
        }
    }
}
