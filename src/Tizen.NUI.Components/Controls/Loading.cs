/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Loading class of nui component. It's used to indicate informs users of the ongoing operation.
    /// </summary>
    /// <remarks>
    /// The Loading is created as `LottieAnimationView` first.
    /// When the user sets ImageArray separately, the image is changed to `ImageVisual`.
    /// </remarks>
    /// <since_tizen> 6 </since_tizen>
    public class Loading : Control
    {
        /// <summary>
        /// ImageArrayProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageArrayProperty = null;
        internal static void SetInternalImageArrayProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                instance.InternalImageArray = newValue as string[];
            }
        }
        internal static object GetInternalImageArrayProperty(BindableObject bindable)
        {
            var instance = (Loading)bindable;
            return instance.InternalImageArray;
        }

        /// <summary>The ImageList bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageListProperty = null;
        internal static void SetInternalImageListProperty(BindableObject bindable, object oldValue, object newValue)
        {
            Debug.Assert(((Loading)bindable).imageVisual != null);

            var newList = newValue as List<string>;
            ((Loading)bindable).imageVisual.URLS = newList == null ? new List<string>() : newList;
        }
        internal static object GetInternalImageListProperty(BindableObject bindable)
        {
            Debug.Assert(((Loading)bindable).imageVisual != null);
            return ((Loading)bindable).imageVisual.URLS;
        }

        /// <summary>The lottie resource url bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LottieResourceUrlProperty = null;
        internal static void SetInternalLottieResourceUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Loading)bindable;
            instance.RemoveImageVisual();
            instance.EnsureLottieView(newValue as string ?? string.Empty);
        }
        internal static object GetInternalLottieResourceUrlProperty(BindableObject bindable)
        {
            var lottie = ((Loading)bindable).defaultLottieView;
            return lottie == null ? string.Empty : lottie.URL;
        }

        /// <summary>The Size bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static readonly BindableProperty SizeProperty = null;
        internal static new void SetInternalSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Loading)bindable;
            if (newValue != null)
            {
                Size size = (Size)newValue;
                ((View)bindable).Size = size;
            }
        }
        internal static new object GetInternalSizeProperty(BindableObject bindable)
        {
            var instance = (View)bindable;
            return instance.Size;
        }

        /// <summary>The FrameRate bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FrameRateProperty = null;
        internal static void SetInternalFrameRateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Loading)bindable;
            instance.frameRate = (int)newValue;
            if (0 != instance.frameRate && instance.imageVisual != null) //It will crash if 0
            {
                instance.imageVisual.FrameDelay = instance.frameRate;
            }
        }
        internal static object GetInternalFrameRateProperty(BindableObject bindable)
        {
            return ((Loading)bindable).frameRate;
        }

        private const string ImageVisualName = "loadingImageVisual";
        private AnimatedImageVisual imageVisual = null;
        private LottieAnimationView defaultLottieView = null;
        private int frameRate = (int)(1000 / 16.6f);
        private const float defaultFrameDelay = 16.6f;
        private static readonly string lottieResource = FrameworkInformation.ResourcePath + "IoT_loading_circle_light.json";

        /// <summary>
        /// Actions value to Play animated images.
        /// </summary>
        private static int ActionPlay = Interop.AnimatedImageView.AnimatedImageVisualActionPlayGet();

        /// <summary>
        /// Actions value to Pause animated images.
        /// </summary>
        private static int ActionPause = Interop.AnimatedImageView.AnimatedImageVisualActionPauseGet();

        /// <summary>
        /// Actions value to Stop animated images.
        /// </summary>
        private static int ActionStop = Interop.AnimatedImageView.AnimatedImageVisualActionStopGet();

        static Loading()
        {
            if (NUIApplication.IsUsingXaml)
            {
                ImageArrayProperty = BindableProperty.Create(nameof(ImageArray), typeof(string[]), typeof(Loading), null,
                    propertyChanged: SetInternalImageArrayProperty, defaultValueCreator: GetInternalImageArrayProperty);
                ImageListProperty = BindableProperty.Create(nameof(ImageList), typeof(IList<string>), typeof(Loading), null,
                    propertyChanged: SetInternalImageListProperty, defaultValueCreator: GetInternalImageListProperty);
                LottieResourceUrlProperty = BindableProperty.Create(nameof(LottieResourceUrl), typeof(string), typeof(Loading), null,
                    propertyChanged: SetInternalLottieResourceUrlProperty, defaultValueCreator: GetInternalLottieResourceUrlProperty);
                SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(Loading), new Size(0, 0),
                    propertyChanged: SetInternalSizeProperty, defaultValueCreator: GetInternalSizeProperty);
                FrameRateProperty = BindableProperty.Create(nameof(FrameRate), typeof(int), typeof(Loading), (int)(1000 / 16.6f),
                    propertyChanged: SetInternalFrameRateProperty, defaultValueCreator: GetInternalFrameRateProperty);
            }
        }

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
        /// The mutually exclusive with "LottieResourceUrl".
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string[] ImageArray
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ImageArrayProperty) as string[];
                }
                else
                {
                    return GetInternalImageArrayProperty(this) as string[];
                }
            }
            set
            {
                RemoveLottieView();
                EnsureImageVisual();

                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ImageArrayProperty, value);
                }
                else
                {
                    SetInternalImageArrayProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private string[] InternalImageArray
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (GetValue(ImageListProperty) as List<string>)?.ToArray() ?? null;
                }
                else
                {
                    return (GetInternalImageListProperty(this) as List<string>)?.ToArray() ?? null;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ImageListProperty, value == null ? new List<string>() : new List<string>((string[])value));
                }
                else
                {
                    SetInternalImageListProperty(this, null, value == null ? new List<string>() : new List<string>((string[])value));
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ImageListProperty) as List<string>;
                }
                else
                {
                    return GetInternalImageListProperty(this) as IList<string>;
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
        /// Gets or sets loading size.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new Size Size
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size)GetValue(SizeProperty);
                }
                else
                {
                    return (Size)GetInternalSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeProperty, value);
                }
                else
                {
                    SetInternalSizeProperty(this, null, value);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(FrameRateProperty);
                }
                else
                {
                    return (int)GetInternalFrameRateProperty(this);
                }
            }
            set
            {
                if (defaultLottieView != null)
                {
                    Tizen.Log.Error("NUI", "Cannot set the frame rate to Lottie Animation. If you want to control it, please set `ImageArray` together.\n");
                }
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FrameRateProperty, value);
                }
                else
                {
                    SetInternalFrameRateProperty(this, null, value);
                }
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.ProgressBar;

            EnsureLottieView(lottieResource);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            if (viewStyle is LoadingStyle loadingStyle)
            {
                if (loadingStyle.Images != null)
                {
                    ImageArray = loadingStyle.Images;
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

                if (defaultLottieView != null)
                {
                    Utility.Dispose(defaultLottieView);
                    defaultLottieView = null;
                }
            }

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// Play Loading Animation.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void Play()
        {
            if (defaultLottieView != null)
            {
                defaultLottieView.Play();
            }
            else
            {
                PropertyValue attributes = new PropertyValue(0);
                this.DoAction(imageVisual.VisualIndex, ActionPlay, attributes);
                attributes.Dispose();
            }
        }

        /// <summary>
        /// Pause Loading Animation.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void Pause()
        {
            if (defaultLottieView != null)
            {
                defaultLottieView.Pause();
            }
            else
            {
                PropertyValue attributes = new PropertyValue(0);
                this.DoAction(imageVisual.VisualIndex, ActionPause, attributes);
                attributes.Dispose();
            }
        }

        /// <summary>
        /// Stop Loading Animation.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void Stop()
        {
            if (defaultLottieView != null)
            {
                defaultLottieView.Stop();
            }
            else
            {
                PropertyValue attributes = new PropertyValue(0);
                this.DoAction(imageVisual.VisualIndex, ActionStop, attributes);
                attributes.Dispose();
            }
        }

        private void Initialize()
        {
            AccessibilityHighlightable = true;
        }

        private void EnsureLottieView(string url)
        {
            if (defaultLottieView != null)
            {
                if (defaultLottieView.URL == url) return;
                defaultLottieView.Stop();
            }
            else Add(defaultLottieView = new LottieAnimationView() { LoopCount = -1 });

            defaultLottieView.URL = url;
            defaultLottieView.Play();
        }

        private void RemoveLottieView()
        {
            if (defaultLottieView == null) return;
            defaultLottieView.Stop();
            defaultLottieView.Dispose();
            defaultLottieView = null;
        }

        private void EnsureImageVisual()
        {
            if (imageVisual == null)
            {
                imageVisual = new AnimatedImageVisual()
                {
                    URLS = new List<string>(),
                    FrameDelay = defaultFrameDelay,
                    LoopCount = -1,
                    Position = new Vector2(0, 0),
                    Origin = Visual.AlignType.Center,
                    AnchorPoint = Visual.AlignType.Center,
                    SizePolicy = VisualTransformPolicyType.Relative,
                    Size = new Size2D(1, 1)
                };

                AddVisual(ImageVisualName, imageVisual);
            }
        }

        private void RemoveImageVisual()
        {
            if (imageVisual == null) return;
            RemoveVisual(ImageVisualName);
            imageVisual.Dispose();
            imageVisual = null;
        }
    }
}
