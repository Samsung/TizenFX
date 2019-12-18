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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Loading class of nui component. It's used to indicate informs users of the ongoing operation.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Loading : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(string[]), typeof(Loading), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                instance.Style.Images = (string[])newValue;
                instance.imageVisual.URLS = new List<string>((string[])newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Loading)bindable;
            return instance.Style.Images;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(Loading), new Size(0,0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                Size size = (Size)newValue;
                instance.Style.Size = size;
                if (null != instance.imageVisual)
                {
                    instance.imageVisual.Size = new Size2D((int)size.Width, (int)size.Height);
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Loading)bindable;
            return instance.Style.Size;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FrameRateProperty = BindableProperty.Create(nameof(FrameRate), typeof(int), typeof(Loading), (int)(1000/16.6f), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                int frameRate = (int)newValue;
                if (0 != frameRate) //It will crash if 0 
                {
                    instance.Style.FrameRate.All = frameRate;
                    instance.imageVisual.FrameDelay = 1000.0f / frameRate;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Loading)bindable;
            return instance.Style.FrameRate?.All ?? (int)(1000/16.6f);
        });

        private AnimatedImageVisual imageVisual = null;

        /// <summary>
        /// The constructor of Loading.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Loading() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor of the Loading class with special style.
        /// </summary>
        /// <param name="style">The string to initialize the Loading.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Loading(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Loading class with specific style.
        /// </summary>
        /// <param name="style">The style object to initialize the Loading.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Loading(LoadingStyle style) : base(style)
        {
            Initialize();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new LoadingStyle Style => ViewStyle as LoadingStyle;

        /// <summary>
        /// Gets or sets loading image resource array.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string[] ImageArray
        {
            get
            {
                return Images;
            }
            set
            {
                Images = value;
            }
        }

        /// <summary>
        /// Gets or sets loading image resources.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] Images
        {
            get
            {
                return (string[])GetValue(ImagesProperty);
            }
            set
            {
                SetValue(ImagesProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets loading size.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new Size Size
        {
            get
            {
                return (Size)GetValue(SizeProperty);
            }
            set
            {
                SetValue(SizeProperty, value); 
            }
        }

        /// <summary>
        /// Gets or sets frame rate of loading.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int FrameRate
        {
            get
            {
                return (int)GetValue(FrameRateProperty);
            }
            set
            {
                SetValue(FrameRateProperty, value);
            }
        }

        /// <summary>
        /// Get Loading style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new LoadingStyle();
        }

        /// <summary>
        /// Dispose Loading.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                RemoveVisual("loadingImageVisual");
            }

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        private void Initialize()
        {
            imageVisual = new AnimatedImageVisual()
            {
                URLS = new List<string>(),
                FrameDelay = 16.6f,
                LoopCount = -1,
                Size = new Size2D(100, 100),
                Position = new Vector2(0, 0),
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center
            };

            UpdateVisual();

            this.AddVisual("loadingImageVisual", imageVisual);
        }

        private void UpdateVisual()
        {
            if (null != Style.Images)
            {
                imageVisual.URLS = new List<string>(Style.Images);
            }
            if (null != Style.FrameRate?.All && 0 != Style.FrameRate.All.Value)
            {
                imageVisual.FrameDelay = 1000.0f / (float)Style.FrameRate.All.Value;
            }
            if (null != Style.LoadingSize)
            {
                imageVisual.Size = new Size2D((int)Style.LoadingSize.Width, (int)Style.LoadingSize.Height);
            }
        }
    }
}
