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
        public static readonly BindableProperty ResourceUrlProperty = BindableProperty.Create(nameof(ResourceUrl), typeof(Selector<string>), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.resourceUrl = ((Selector<string>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.resourceUrl;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderProperty = BindableProperty.Create(nameof(Border), typeof(Selector<Rectangle>), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.border = ((Selector<Rectangle>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.border;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderOnlyProperty = BindableProperty.Create(nameof(BorderOnly), typeof(bool?), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.borderOnly = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.borderOnly;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronosLoadingProperty = BindableProperty.Create(nameof(SynchronosLoading), typeof(bool?), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.synchronosLoading = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.synchronosLoading;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationCorrectionProperty = BindableProperty.Create(nameof(OrientationCorrection), typeof(bool?), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.orientationCorrection = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.orientationCorrection;
        });

        private bool? borderOnly;
        private bool? synchronosLoading;
        private bool? orientationCorrection;
        private Selector<string> resourceUrl;
        private Selector<Rectangle> border;

        static ImageViewStyle() { }

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
            get => (bool?)GetValue(BorderOnlyProperty);
            set => SetValue(BorderOnlyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SynchronosLoading
        {
            get => (bool?)GetValue(SynchronosLoadingProperty);
            set => SetValue(SynchronosLoadingProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? OrientationCorrection
        {
            get => (bool?)GetValue(OrientationCorrectionProperty);
            set => SetValue(OrientationCorrectionProperty, value);
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
                Selector<string> tmp = (Selector<string>)GetValue(ResourceUrlProperty);
                return (null != tmp) ? tmp : resourceUrl = new Selector<string>();
            }
            set => SetValue(ResourceUrlProperty, value);
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
                Selector<Rectangle> tmp = (Selector<Rectangle>)GetValue(BorderProperty);
                return (null != tmp) ? tmp : border = new Selector<Rectangle>();
            }
            set => SetValue(BorderProperty, value);
        }
    }
}
