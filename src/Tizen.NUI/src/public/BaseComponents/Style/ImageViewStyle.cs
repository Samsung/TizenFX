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
        static readonly IStyleProperty BorderOnlyProperty = new StyleProperty<ImageView, bool>((v, o) => v.BorderOnly = o);
        static readonly IStyleProperty SynchronousLoadingProperty = new StyleProperty<ImageView, bool>((v, o) => v.SynchronousLoading = o);
        static readonly IStyleProperty OrientationCorrectionProperty = new StyleProperty<ImageView, bool>((v, o) => v.OrientationCorrection = o);
        static readonly IStyleProperty ResourceUrlProperty = new StyleProperty<ImageView, Selector<string>>((v, o) => ImageView.SetInternalResourceUrlProperty(v, null, o));
        static readonly IStyleProperty BorderProperty = new StyleProperty<ImageView, Selector<Rectangle>>((v, o) => ImageView.SetInternalBorderProperty(v, null, o));

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
            get => (bool?)GetValue(SynchronousLoadingProperty);
            set => SetValue(SynchronousLoadingProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SynchronousLoading
        {
            get => (bool?)GetValue(SynchronousLoadingProperty);
            set => SetValue(SynchronousLoadingProperty, value);
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
            get => GetOrCreateValue<Selector<string>>(ResourceUrlProperty);
            set => SetValue(ResourceUrlProperty, value);
        }

        /// <summary>
        /// Image border.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> Border
        {
            get => GetOrCreateValue<Selector<Rectangle>>(BorderProperty);
            set => SetValue(BorderProperty, value);
        }
    }
}
