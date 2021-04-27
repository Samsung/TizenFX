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

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        /// <summary>The ImageList bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageListProperty = BindableProperty.Create(nameof(ImageList), typeof(IList<string>), typeof(Loading), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            Debug.Assert(((Loading)bindable).imageVisual != null);

            var newList = newValue as List<string>;
            ((Loading)bindable).imageVisual.URLS = newList == null ? new List<string>() : newList;
        },
        defaultValueCreator: (bindable) =>
        {
            Debug.Assert(((Loading)bindable).imageVisual != null);
            return ((Loading)bindable).imageVisual.URLS;
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
            Debug.Assert(instance.imageVisual != null);

            instance.frameRate = (int)newValue;
            if (0 != instance.frameRate) //It will crash if 0
            {
                instance.imageVisual.FrameDelay = instance.frameRate;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Loading)bindable).frameRate;
        });

        private AnimatedImageVisual imageVisual = null;
        private int frameRate = (int)(1000 / 16.6f);

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
        /// Return currently applied style.
        /// </summary>
        /// <remarks>
        /// Modifying contents in style may cause unexpected behaviour.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public LoadingStyle Style => (LoadingStyle)(ViewStyle as LoadingStyle)?.Clone();

        /// <summary>
        /// Gets or sets loading image resource array.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string[] ImageArray
        {
            get => (GetValue(ImageListProperty) as List<string>).ToArray();
            set => SetValue(ImageListProperty, value == null ? new List<string>() : new List<string>((string[])value));
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            SetAccessibilityConstructor(Role.ProgressBar);

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

            this.AddVisual("loadingImageVisual", imageVisual);

            AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Trait, "Loading");
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            Debug.Assert(imageVisual != null);

            if (viewStyle is LoadingStyle loadingStyle)
            {
                if (loadingStyle.Images != null)
                {
                    imageVisual.URLS = loadingStyle.ImageList as List<string>;
                }

                if (loadingStyle.LoadingSize != null)
                {
                    Size = loadingStyle.LoadingSize;
                }
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

        private void Initialize()
        {
            AccessibilityHighlightable = true;
        }
    }
}
