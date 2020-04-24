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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(string[]), typeof(Loading), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                instance.images = (string[])newValue;
            }
            instance.UpdateVisual();
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Loading)bindable;
            return instance.images;
        });
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(Loading), new Size(0, 0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                Size size = (Size)newValue;
                instance.Size2D = size;
            }
            instance.UpdateVisual();
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Loading)bindable;
            return (Size)instance.Size2D;
        });
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FrameRateProperty = BindableProperty.Create(nameof(FrameRate), typeof(int), typeof(Loading), (int)(1000 / 16.6f), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                int frameRate = (int)newValue;
                if (0 != frameRate) //It will crash if 0 
                {
                    instance.frameRate = frameRate;
                }
                instance.UpdateVisual();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Loading)bindable;
            return instance.frameRate;
        });

        private AnimatedImageVisual imageVisual = new AnimatedImageVisual()
        {
            URLS = new List<string>(),
            FrameDelay = 16.6f,
            LoopCount = -1,
            Size = new Size2D(100, 100),
            Position = new Vector2(0, 0),
            Origin = Visual.AlignType.Center,
            AnchorPoint = Visual.AlignType.Center
        };

        private string[] images;
        private int frameRate = (int)(1000 / 16.6f);

        static Loading() { }

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
        /// <since_tizen> 8 </since_tizen>
        public Loading(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Loading class with specific style.
        /// </summary>
        /// <param name="loadingStyle">The style object to initialize the Loading.</param>
        /// <since_tizen> 8 </since_tizen>
        public Loading(LoadingStyle loadingStyle) : base(loadingStyle)
        {
            Initialize();
        }

        /// <summary>
        /// Return a copied Style instance of Loading
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Loading.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public new LoadingStyle Style
        {
            get
            {
                return new LoadingStyle(ViewStyle as LoadingStyle);
            }
        }

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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// <returns>The default loading style.</returns>
        /// <since_tizen> 8 </since_tizen>
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
            UpdateVisual();
            this.AddVisual("loadingImageVisual", imageVisual);
        }

        private void UpdateVisual()
        {
            if (imageVisual != null) 
            {
                imageVisual.Size = Size2D;
                if (null != images)
                {
                    imageVisual.URLS = new List<string>(images);
                }
                if (0 != frameRate)
                {
                    imageVisual.FrameDelay = 1000.0f / (float)frameRate;
                }
            }
        }
    }
}
