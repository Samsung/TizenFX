/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageViewStyle : ViewStyle
    {
        private bool? preMultipliedAlpha;
        private RelativeVector4 pixelArea;
        private bool? borderOnly;
        private bool? synchronosLoading;
        private bool? orientationCorrection;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceUrlSelectorProperty = BindableProperty.Create("ResourceUrlSelector", typeof(Selector<string>), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.resourceUrlSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.resourceUrlSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PreMultipliedAlphaProperty = BindableProperty.Create(nameof(PreMultipliedAlpha), typeof(bool?), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.preMultipliedAlpha = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.preMultipliedAlpha;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelAreaProperty = BindableProperty.Create(nameof(PixelArea), typeof(RelativeVector4), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.pixelArea = (RelativeVector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.pixelArea;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderSelectorProperty = BindableProperty.Create("BorderSelector", typeof(Selector<Rectangle>), typeof(ImageViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            imageViewStyle.borderSelector.Clone((Selector<Rectangle>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var imageViewStyle = (ImageViewStyle)bindable;
            return imageViewStyle.borderSelector;
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? PreMultipliedAlpha
        {
            get
            {
                bool? temp = (bool?)GetValue(PreMultipliedAlphaProperty);
                return temp;
            }
            set
            {
                SetValue(PreMultipliedAlphaProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RelativeVector4 PixelArea
        {
            get
            {
                RelativeVector4 temp = (RelativeVector4)GetValue(PixelAreaProperty);
                return temp;
            }
            set
            {
                SetValue(PixelAreaProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? BorderOnly
        {
            get
            {
                bool? temp = (bool?)GetValue(BorderOnlyProperty);
                return temp;
            }
            set
            {
                SetValue(BorderOnlyProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SynchronosLoading
        {
            get
            {
                bool? temp = (bool?)GetValue(SynchronosLoadingProperty);
                return temp;
            }
            set
            {
                SetValue(SynchronosLoadingProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? OrientationCorrection
        {
            get
            {
                bool? temp = (bool?)GetValue(OrientationCorrectionProperty);
                return temp;
            }
            set
            {
                SetValue(OrientationCorrectionProperty, value);
            }
        }

        private Selector<string> resourceUrlSelector = new Selector<string>();
        /// <summary>
        /// Image URL.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> ResourceUrl
        {
            get
            {
                return (Selector<string>)GetValue(ResourceUrlSelectorProperty);
            }
            set
            {
                SetValue(ResourceUrlSelectorProperty, value);
            }
        }

        private Selector<Rectangle> borderSelector = new Selector<Rectangle>();
        /// <summary>
        /// Image border.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> Border
        {
            get
            {
                return (Selector<Rectangle>)GetValue(BorderSelectorProperty);
            }
            set
            {
                SetValue(BorderSelectorProperty, value);
            }
        }
    }
}
