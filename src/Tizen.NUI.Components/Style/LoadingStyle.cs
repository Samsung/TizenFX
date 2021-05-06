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
        public static readonly BindableProperty FrameRateSelectorProperty = BindableProperty.Create("FrameRateSelector", typeof(Selector<int?>), typeof(LoadingStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((LoadingStyle)bindable).frameRate = ((Selector<int?>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((LoadingStyle)bindable).frameRate;
        });

        /// <summary>The LoadingSize bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LoadingSizeProperty = BindableProperty.Create(nameof(LoadingSize), typeof(Size), typeof(LoadingStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((LoadingStyle)bindable).Size = (Size)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((LoadingStyle)bindable).Size;
        });

        /// <summary>The Images bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(string[]), typeof(LoadingStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((LoadingStyle)bindable).images = newValue == null ? null : new List<string>((string[])newValue);
        },
        defaultValueCreator: (bindable) => ((LoadingStyle)bindable).images?.ToArray()
        );

        /// <summary>The Images bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageListProperty = BindableProperty.Create(nameof(ImageList), typeof(IList<string>), typeof(LoadingStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((LoadingStyle)bindable).images = newValue as List<string>;
        },
        defaultValueCreator: (bindable) => ((LoadingStyle)bindable).images
        );

        private Selector<int?> frameRate;
        private List<string> images;

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
        public string[] Images
        {
            get => (ImageList as List<string>)?.ToArray();
            set => SetValue(ImagesProperty, value);
        }

        /// <summary>
        /// Gets loading image resources.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ImageList
        {
            get
            {
                if (images == null)
                {
                    images = new List<string>();
                }
                return GetValue(ImageListProperty) as List<string>;
            }
            internal set => SetValue(ImageListProperty, value);
        }

        /// <summary>
        /// Gets or sets loading image size.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Size LoadingSize
        {
            get => (Size)GetValue(LoadingSizeProperty);
            set => SetValue(LoadingSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets loading frame per second.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Selector<int?> FrameRate
        {
            get => (Selector<int?>)GetValue(FrameRateSelectorProperty);
            set => SetValue(FrameRateSelectorProperty, value);
        }

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);
        }
    }
}
