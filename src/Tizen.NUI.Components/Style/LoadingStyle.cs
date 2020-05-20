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
using System.ComponentModel;
using System.Collections.Generic;
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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(string[]), typeof(LoadingStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (LoadingStyle)bindable;
            if (newValue != null)
            {
                instance.images = (string[])newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (LoadingStyle)bindable;
            return instance.images;
        });

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(LoadingStyle), new Size(0, 0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (LoadingStyle)bindable;
            if (newValue != null)
            {
                Size size = (Size)newValue;
                instance.loadingSize = size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (LoadingStyle)bindable;
            return instance.loadingSize;
        });

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty FrameRateProperty = BindableProperty.Create(nameof(FrameRate), typeof(Selector<int?>), typeof(LoadingStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (LoadingStyle)bindable;
            if (newValue != null)
            {
                if (instance.frameRate == null) instance.frameRate = new Selector<int?>();
                instance.frameRate.Clone((Selector<int?>)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (LoadingStyle)bindable;
            return instance.frameRate;
        });

        private string[] images = null;
        private Size loadingSize = null;
        private Selector<int?> frameRate = null;

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
            if(null == style)
            {
                return;
            }
            this.CopyFrom(style);
        }

        /// <summary>
        /// Gets or sets loading image resources.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public string[] Images 
        {
            get
            {
                string[] im = (string[])GetValue(ImagesProperty);
                return (null != im) ? im : images = new string[1];
            }
            set
            {
                SetValue(ImagesProperty, value);
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
                Size size = (Size)GetValue(SizeProperty);
                return (null != size) ? size : loadingSize = new Size(10, 10);
            }
            set
            {
                SetValue(SizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets loading frame per second.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        //public Selector<int?> FrameRate { get; set; } = new Selector<int?>();
        public Selector<int?> FrameRate
        {
            get
            {
                Selector<int?> fm = (Selector<int?>)GetValue(FrameRateProperty);
                return (null != fm) ? fm : frameRate = new Selector<int?>();
            }
            set
            {
                SetValue(FrameRateProperty, value);
            }
        }

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);
        }
    }
}
