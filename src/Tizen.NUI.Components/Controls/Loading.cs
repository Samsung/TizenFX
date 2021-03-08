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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Accessibility;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Loading class of nui component. It's used to indicate informs users of the ongoing operation.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Loading : Control
    {
        /// <summary>The ImageArray bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageArrayProperty = BindableProperty.Create(nameof(ImageArray), typeof(string[]), typeof(Loading), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                instance.loadingStyle.Images = (string[])newValue;
                instance.imageVisual.URLS = instance.loadingStyle.ImageList as List<string>;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Loading)bindable;
            return instance.loadingStyle.Images;
        });
        /// <summary>The ImageList bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageListProperty = BindableProperty.Create(nameof(ImageList), typeof(IList<string>), typeof(Loading), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                var newValueList = newValue as List<string>;
                instance.loadingStyle.ImageList = newValueList;
                if (instance.imageVisual != null) instance.imageVisual.URLS = newValueList;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Loading)bindable).loadingStyle.ImageList;
        });
        /// <summary>The Size bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(Loading), new Size(0, 0), propertyChanged: (bindable, oldValue, newValue) =>
         {
             var instance = (Loading)bindable;
             if (newValue != null)
             {
                 Size size = (Size)newValue;
                 ((View)bindable).Size = size;
                 instance.loadingStyle.LoadingSize = size;
             }
         },
        defaultValueCreator: (bindable) =>
        {
            var instance = (View)bindable;
            return instance.Size;
        });
        /// <summary>The FrameRate bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FrameRateProperty = BindableProperty.Create(nameof(FrameRate), typeof(int), typeof(Loading), (int)(1000 / 16.6f), propertyChanged: (bindable, oldValue, newValue) =>
          {
              var instance = (Loading)bindable;
              if (newValue != null)
              {
                  int frameRate = (int)newValue;
                  if (0 != frameRate) //It will crash if 0
                  {
                      instance.loadingStyle.FrameRate = frameRate;
                      instance.imageVisual.FrameDelay = 1000.0f / frameRate;
                  }
              }
          },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Loading)bindable;
            return instance.loadingStyle.FrameRate?.All ?? (int)(1000 / 16.6f);
        });

        private AnimatedImageVisual imageVisual = null;
        private LoadingStyle loadingStyle => ViewStyle as LoadingStyle;

        internal new class Property
        {
            internal static readonly int ActionPlay = Interop.ImageView.ImageVisualActionPlayGet();
            internal static readonly int ActionPause = Interop.ImageView.ImageVisualActionPauseGet();
            internal static readonly int ActionStop = Interop.ImageView.ImageVisualActionStopGet();
        }

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
        /// Get style of loading.
        /// Return a copied Style instance of Loading
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Loading.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>>
        /// <since_tizen> 8 </since_tizen>
        public new LoadingStyle Style
        {
            get
            {
                var result = new LoadingStyle(loadingStyle);
                result.CopyPropertiesFromView(this);
                return result;
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
                return (string[])GetValue(ImageArrayProperty);
            }
            set
            {
                SetValue(ImageArrayProperty, value);
            }
        }

        /// <summary>
        /// Gets loading image resource array.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ImageList
        {
            get
            {
                return GetValue(ImageListProperty) as List<string>;
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
        protected override ViewStyle CreateViewStyle()
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
                Position = new Vector2(0, 0),
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center,
                SizePolicy = VisualTransformPolicyType.Relative,
                Size = new Size2D(1, 1)
            };

            UpdateVisual();

            this.AddVisual("loadingImageVisual", imageVisual);

            AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Trait, "Loading");
        }

        private void UpdateVisual()
        {
            if (null != loadingStyle.Images)
            {
                loadingStyle.ImageList = new List<string>(loadingStyle.Images);
                imageVisual.URLS = loadingStyle.ImageList as List<string>;
            }
            if (null != loadingStyle.FrameRate?.All && 0 != loadingStyle.FrameRate.All.Value)
            {
                imageVisual.FrameDelay = 1000.0f / (float)loadingStyle.FrameRate.All.Value;
            }
        }

        /// <summary>
        /// Play Loading Animation.
        /// </summary>
        /// This may be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Play()
        {
            PropertyValue attributes = new PropertyValue(0);
            this.DoAction(imageVisual.VisualIndex, Property.ActionPlay, attributes);
            attributes.Dispose();
        }

        /// <summary>
        /// Pause Loading Animation.
        /// </summary>
        /// This may be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Pause()
        {
            PropertyValue attributes = new PropertyValue(0);
            this.DoAction(imageVisual.VisualIndex, Property.ActionPause, attributes);
            attributes.Dispose();
        }

        /// <summary>
        /// Stop Loading Animation.
        /// </summary>
        /// This may be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            PropertyValue attributes = new PropertyValue(0);
            this.DoAction(imageVisual.VisualIndex, Property.ActionStop, attributes);
            attributes.Dispose();
        }
    }
}
