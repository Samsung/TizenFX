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
        /// <summary>The FrameRateSelector bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FrameRateSelectorProperty = null;
        internal static void SetInternalFrameRateSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((LoadingStyle)bindable).frameRate = ((Selector<int?>)newValue)?.Clone();
        }
        internal static object GetInternalFrameRateSelectorProperty(BindableObject bindable)
        {
            return ((LoadingStyle)bindable).frameRate;
        }

        /// <summary>The LoadingSize bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoadingSizeProperty = null;
        internal static void SetInternalLoadingSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((LoadingStyle)bindable).Size = (Size)newValue;
        }
        internal static object GetInternalLoadingSizeProperty(BindableObject bindable)
        {
            return ((LoadingStyle)bindable).Size;
        }

        /// <summary>The Images bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImagesProperty = null;
        internal static void SetInternalImagesProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((LoadingStyle)bindable).images = newValue == null ? null : new List<string>((string[])newValue);
        }
        internal static object GetInternalImagesProperty(BindableObject bindable)
        {
            return ((LoadingStyle)bindable).images?.ToArray();
        }

        /// <summary>The Images bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageListProperty = null;
        internal static void SetInternalImageListProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((LoadingStyle)bindable).images = newValue == null ? null : newValue as List<string>;
        }
        internal static object GetInternalImageListProperty(BindableObject bindable)
        {
            return ((LoadingStyle)bindable).images;
        }

        /// <summary>The lottie resource url bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LottieResourceUrlProperty = null;
        internal static void SetInternalLottieResourceUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((LoadingStyle)bindable).lottieResourceUrl = newValue as string;
        }
        internal static object GetInternalLottieResourceUrlProperty(BindableObject bindable)
        {
            return ((LoadingStyle)bindable).lottieResourceUrl;
        }

        private Selector<int?> frameRate;
        private List<string> images;
        private string lottieResourceUrl;

        static LoadingStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                FrameRateSelectorProperty = BindableProperty.Create("FrameRateSelector", typeof(Selector<int?>), typeof(LoadingStyle), null,
                    propertyChanged: SetInternalFrameRateSelectorProperty, defaultValueCreator: GetInternalFrameRateSelectorProperty);
                LoadingSizeProperty = BindableProperty.Create(nameof(LoadingSize), typeof(Size), typeof(LoadingStyle), null,
                    propertyChanged: SetInternalLoadingSizeProperty, defaultValueCreator: GetInternalLoadingSizeProperty);
                ImagesProperty = BindableProperty.Create(nameof(Images), typeof(string[]), typeof(LoadingStyle), null,
                    propertyChanged: SetInternalImagesProperty, defaultValueCreator: GetInternalImagesProperty);
                ImageListProperty = BindableProperty.Create(nameof(ImageList), typeof(IList<string>), typeof(LoadingStyle), null,
                    propertyChanged: SetInternalImageListProperty, defaultValueCreator: GetInternalImageListProperty);
                LottieResourceUrlProperty = BindableProperty.Create(nameof(LottieResourceUrl), typeof(string), typeof(LoadingStyle), null,
                    propertyChanged: SetInternalLottieResourceUrlProperty, defaultValueCreator: GetInternalLottieResourceUrlProperty);
            }
        }

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
        public string[] Images
        {
            get
            {
                return (ImageList as List<string>)?.ToArray();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ImagesProperty, value);
                }
                else
                {
                    SetInternalImagesProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets loading image resources.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ImageList
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ImageListProperty) as List<string>;
                }
                else
                {
                    return GetInternalImageListProperty(this) as IList<string>;
                }
            }
            internal set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ImageListProperty, value);
                }
                else
                {
                    SetInternalImageListProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets an lottie resource url.
        /// The mutually exclusive with "ImageArray".
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LottieResourceUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(LottieResourceUrlProperty) as string;
                }
                else
                {
                    return GetInternalLottieResourceUrlProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LottieResourceUrlProperty, value);
                }
                else
                {
                    SetInternalLottieResourceUrlProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets loading image size.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Size LoadingSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size)GetValue(LoadingSizeProperty);
                }
                else
                {
                    return (Size)GetInternalLoadingSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LoadingSizeProperty, value);
                }
                else
                {
                    SetInternalLoadingSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets loading frame per second.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Selector<int?> FrameRate
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<int?>)GetValue(FrameRateSelectorProperty);
                }
                else
                {
                    return (Selector<int?>)GetInternalFrameRateSelectorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FrameRateSelectorProperty, value);
                }
                else
                {
                    SetInternalFrameRateSelectorProperty(this, null, value);
                }
            }
        }

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);
        }
    }
}
