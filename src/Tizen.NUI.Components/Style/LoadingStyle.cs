/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// LoadingStyle is a class which saves Loading's ux data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class LoadingStyle : ControlStyle
    {
        // NOTE framerate selector does not work.
        static readonly IStyleProperty FrameRateProperty = new StyleProperty<Loading, Selector<int?>>((v, o) => v.FrameRate = (int)o.Normal);
        static readonly IStyleProperty ImageListProperty = new StyleProperty<Loading, IList<string>>((v, o) => v.SetInternalImageList(o));
        static readonly IStyleProperty LottieResourceUrlProperty = new StyleProperty<Loading, string>((v, o) => v.LottieResourceUrl = o);

        private Size loadingSize;

        static LoadingStyle() { }

        /// <summary>
        /// Creates a new instance of a LoadingStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public LoadingStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a LoadingStyle with style.
        /// </summary>
        /// <param name="style">Create LoadingStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public LoadingStyle(LoadingStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets loading image resources.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public string[] Images { get; set; }

        /// <summary>
        /// Gets loading image resources.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ImageList
        {
            get
            {
                return GetValue(ImageListProperty) as List<string>;
            }
            internal set => SetValue(ImageListProperty, value);
        }

        /// <summary>
        /// Gets or sets an lottie resource url.
        /// The mutually exclusive with "ImageArray".
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LottieResourceUrl
        {
            get => GetValue(LottieResourceUrlProperty) as string;
            set => SetValue(LottieResourceUrlProperty, value);
        }

        /// <summary>
        /// Gets or sets loading image size.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Size LoadingSize
        {
            get => loadingSize;
            set
            {
                loadingSize = value;
            }
        }

        /// <summary>
        /// Gets or sets loading frame per second.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Selector<int?> FrameRate
        {
            get => (Selector<int?>)GetValue(FrameRateProperty);
            set => SetValue(FrameRateProperty, value);
        }

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);
        }
    }
}
