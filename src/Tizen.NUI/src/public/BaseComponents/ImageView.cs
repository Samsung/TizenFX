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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{

    /// <summary>
    /// ImageView is a class for displaying an image resource.<br />
    /// An instance of ImageView can be created using a URL or an image instance.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class ImageView : View
    {
        static ImageView() { }

        private EventHandler<ResourceReadyEventArgs> _resourceReadyEventHandler;
        private ResourceReadyEventCallbackType _resourceReadyEventCallback;
        private EventHandler<ResourceLoadedEventArgs> _resourceLoadedEventHandler;
        private _resourceLoadedCallbackType _resourceLoadedCallback;

        /// <summary>
        /// Convert non-null string that some keyword change as application specific directory.
        /// </summary>
        /// <param name="value">Inputed and replaced after this function finished</param>
        /// <returns>Replaced url</returns>
        private static string ConvertResourceUrl(ref string value)
        {
            value ??= "";
            if (value.StartsWith("*Resource*"))
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                value = value.Replace("*Resource*", resource);
            }
            return value;
        }

        // Collection of image-sensitive properties.
        private static readonly List<int> cachedImagePropertyKeyList = new List<int> {
            Visual.Property.Type,
            ImageVisualProperty.URL,
            ImageVisualProperty.AlphaMaskURL,
            ImageVisualProperty.CropToMask,
            Visual.Property.VisualFittingMode,
            ImageVisualProperty.DesiredWidth,
            ImageVisualProperty.DesiredHeight,
            ImageVisualProperty.ReleasePolicy,
            ImageVisualProperty.WrapModeU,
            ImageVisualProperty.WrapModeV,
            ImageVisualProperty.SynchronousLoading,
            Visual.Property.PremultipliedAlpha,
            ImageVisualProperty.OrientationCorrection,
            NpatchImageVisualProperty.Border,
            NpatchImageVisualProperty.BorderOnly,
        };
        internal PropertyMap cachedImagePropertyMap;
        internal bool imagePropertyUpdatedFlag = false;

        private bool imagePropertyUpdateProcessAttachedFlag = false;
        private Rectangle _border;
        private string _resourceUrl = "";
        private int _desired_width = -1;
        private int _desired_height = -1;
        private TriggerableSelector<string> resourceUrlSelector;
        private TriggerableSelector<Rectangle> borderSelector;

        private RelativeVector4 internalPixelArea;

        /// <summary>
        /// Creates an initialized ImageView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImageView() : this(Interop.ImageView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView(ViewStyle viewStyle) : this(Interop.ImageView.New(), true, viewStyle)
        {
        }

        /// <summary>
        /// Creates an initialized ImageView with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView(bool shown) : this(Interop.ImageView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        /// <summary>
        /// Creates an initialized ImageView from a URL to an image resource.<br />
        /// If the string is empty, ImageView will not display anything.<br />
        /// </summary>
        /// <param name="url">The URL of the image resource to display.</param>
        /// <since_tizen> 3 </since_tizen>
        public ImageView(string url) : this(Interop.ImageView.New(ConvertResourceUrl(ref url)), true)
        {
            _resourceUrl = url;

            // Update cached property. Note that we should not re-create new visual.
            using (PropertyValue urlValue = new PropertyValue(_resourceUrl))
            {
                UpdateImage(ImageVisualProperty.URL, urlValue, false);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates an initialized ImageView from a URL to an image resource with setting shown or hidden.
        /// </summary>
        /// <param name="url">The URL of the image resource to display.</param>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView(string url, bool shown) : this(Interop.ImageView.New(ConvertResourceUrl(ref url)), true)
        {
            _resourceUrl = url;

            // Update cached property. Note that we should not re-create new visual.
            using (PropertyValue urlValue = new PropertyValue(_resourceUrl))
            {
                UpdateImage(ImageVisualProperty.URL, urlValue, false);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        internal ImageView(string url, Uint16Pair size, bool shown = true) : this(Interop.ImageView.New(ConvertResourceUrl(ref url), Uint16Pair.getCPtr(size)), true)
        {
            _resourceUrl = url;
            _desired_width = size?.GetWidth() ?? -1;
            _desired_height = size?.GetHeight() ?? -1;

            // Update cached property. Note that we should not re-create new visual.
            using (PropertyValue urlValue = new PropertyValue(_resourceUrl))
            {
                UpdateImage(ImageVisualProperty.URL, urlValue, false);
            }
            using (PropertyValue desiredWidthValue = new PropertyValue(_desired_width))
            {
                UpdateImage(ImageVisualProperty.DesiredWidth, desiredWidthValue, false);
            }
            using (PropertyValue desiredHeightValue = new PropertyValue(_desired_height))
            {
                UpdateImage(ImageVisualProperty.DesiredWidth, desiredHeightValue, false);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal ImageView(global::System.IntPtr cPtr, bool cMemoryOwn, ViewStyle viewStyle, bool shown = true) : base(cPtr, cMemoryOwn, viewStyle)
        {
            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal ImageView(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown = true) : base(cPtr, cMemoryOwn, null)
        {
            if (!shown)
            {
                SetVisible(false);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ResourceReadyEventCallbackType(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void _resourceLoadedCallbackType(IntPtr view);

        /// <summary>
        /// An event for ResourceReady signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted after all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ResourceReadyEventArgs> ResourceReady
        {
            add
            {
                if (_resourceReadyEventHandler == null)
                {
                    _resourceReadyEventCallback = OnResourceReady;
                    ViewResourceReadySignal resourceReadySignal = ResourceReadySignal(this);
                    resourceReadySignal?.Connect(_resourceReadyEventCallback);
                    resourceReadySignal?.Dispose();
                }

                _resourceReadyEventHandler += value;
            }

            remove
            {
                _resourceReadyEventHandler -= value;

                ViewResourceReadySignal resourceReadySignal = ResourceReadySignal(this);
                if (_resourceReadyEventHandler == null && resourceReadySignal?.Empty() == false)
                {
                    resourceReadySignal?.Disconnect(_resourceReadyEventCallback);
                }
                resourceReadySignal?.Dispose();
            }
        }

        internal event EventHandler<ResourceLoadedEventArgs> ResourceLoaded
        {
            add
            {
                if (_resourceLoadedEventHandler == null)
                {
                    _resourceLoadedCallback = OnResourceLoaded;
                    ViewResourceReadySignal resourceReadySignal = this.ResourceReadySignal(this);
                    resourceReadySignal?.Connect(_resourceLoadedCallback);
                    resourceReadySignal?.Dispose();
                }

                _resourceLoadedEventHandler += value;
            }
            remove
            {
                _resourceLoadedEventHandler -= value;
                ViewResourceReadySignal resourceReadySignal = this.ResourceReadySignal(this);
                if (_resourceLoadedEventHandler == null && resourceReadySignal?.Empty() == false)
                {
                    resourceReadySignal?.Disconnect(_resourceLoadedCallback);
                }
                resourceReadySignal?.Dispose();
            }
        }

        /// <summary>
        /// Enumeration for LoadingStatus of image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public enum LoadingStatusType
        {
            /// <summary>
            /// Loading preparing status.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Preparing,
            /// <summary>
            /// Loading ready status.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Ready,
            /// <summary>
            /// Loading failed status.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            Failed
        }

        /// <summary>
        /// Enumeration for MaskingMode of image.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum MaskingModeType
        {
            /// <summary>
            /// Applies alpha masking on rendering time.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MaskingOnRendering,
            /// <summary>
            /// Applies alpha masking on loading time.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MaskingOnLoading
        }

        /// <summary>
        /// ImageView ResourceUrl, type string.
        /// This is one of mandatory property. Even if not set or null set, it sets empty string ("") internally.
        /// When it is set as null, it gives empty string ("") to be read.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ResourceUrl
        {
            get
            {
                return (string)GetValue(ResourceUrlProperty);
            }
            set
            {
                SetValue(ResourceUrlProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// This will be deprecated, Use Image instead. <br />
        /// ImageView ImageMap, type PropertyMap: string if it is a URL, map otherwise.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Do not use this, that will be deprecated. Use Image property instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap ImageMap
        {
            get
            {
                return GetValue(ImageMapProperty) as PropertyMap;
            }
            set
            {
                SetValue(ImageMapProperty, value);
                NotifyPropertyChanged();
            }
        }
        private PropertyMap InternalImageMap
        {
            get
            {
                if (_border == null)
                {
                    // Sync as current properties
                    UpdateImage();

                    // Get current properties force.
                    PropertyMap returnValue = new PropertyMap();
                    PropertyValue image = GetProperty(ImageView.Property.IMAGE);
                    image?.Get(returnValue);
                    image?.Dispose();

                    // Update cached property map
                    if (returnValue != null)
                    {
                        MergeCachedImageVisualProperty(returnValue);
                    }
                    return returnValue;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (_border == null)
                {
                    PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                    SetProperty(ImageView.Property.IMAGE, setValue);

                    // Image properties are changed hardly. We should ignore lazy UpdateImage
                    imagePropertyUpdatedFlag = false;
                    cachedImagePropertyMap?.Dispose();
                    cachedImagePropertyMap = null;
                    MergeCachedImageVisualProperty(value);

                    NotifyPropertyChanged();
                    setValue?.Dispose();
                }
            }
        }

        /// <summary>
        /// ImageView Image, type PropertyMap: string if it is a URL, map otherwise.
        /// </summary>
        /// <remarks>
        /// This PropertyMap use a <see cref="ImageVisualProperty"/>. <br />
        /// See <see cref="ImageVisualProperty"/> for a detailed description. <br />
        /// you can also use <see cref="Visual.Property"/>. <br />
        /// See <see cref="Visual.Property"/> for a detailed description. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the Image property.
        /// <code>
        /// PropertyMap map = new PropertyMap();
        /// map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
        /// map.Insert(ImageVisualProperty.AlphaMaskURL, new PropertyValue(url));
        /// map.Insert(ImageVisualProperty.FittingMode, new PropertyValue((int)FittingModeType.ScaleToFill);
        /// imageview.Image = map;
        /// </code>
        /// </example>
        /// <since_tizen> 4 </since_tizen>
        public PropertyMap Image
        {
            get
            {
                if (_border == null)
                {
                    return (PropertyMap)GetValue(ImageProperty);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (_border == null)
                {
                    SetValue(ImageProperty, value);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// ImageView PreMultipliedAlpha, type Boolean.<br />
        /// Image must be initialized.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool PreMultipliedAlpha
        {
            get
            {
                return (bool)GetValue(PreMultipliedAlphaProperty);
            }
            set
            {
                SetValue(PreMultipliedAlphaProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// ImageView PixelArea, type Vector4 (Animatable property).<br />
        /// Pixel area is a relative value with the whole image area as [0.0, 0.0, 1.0, 1.0].<br />
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (imageView.PixelArea.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector4 PixelArea
        {
            get
            {
                return (RelativeVector4)GetValue(PixelAreaProperty);
            }
            set
            {
                SetValue(PixelAreaProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The border of the image in the order: left, right, bottom, top.<br />
        /// If set, ImageMap will be ignored.<br />
        /// For N-Patch images only.<br />
        /// Optional.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (imageView.Border.X = 1;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle Border
        {
            get
            {
                Rectangle temp = (Rectangle)GetValue(BorderProperty);
                if (null == temp)
                {
                    return null;
                }
                else
                {
                    return new Rectangle(OnBorderChanged, temp.X, temp.Y, temp.Width, temp.Height);
                }
            }
            set
            {
                SetValue(BorderProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether to draw the borders only (if true).<br />
        /// If not specified, the default is false.<br />
        /// For N-Patch images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool BorderOnly
        {
            get
            {
                return (bool)GetValue(BorderOnlyProperty);
            }
            set
            {
                SetValue(BorderOnlyProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether to synchronous loading the resourceurl of image.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("This has been deprecated since API9 and will be removed in API11. Use SynchronousLoading instead.")]
        public bool SynchronosLoading
        {
            get
            {
                return SynchronousLoading;
            }
            set
            {
                SynchronousLoading = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the image of the ResourceUrl property will be loaded synchronously.<br />
        /// </summary>
        /// <remarks>
        /// Changing this property make this ImageView load image synchronously at the next loading
        /// by following operation: <see cref="Reload"/>, <see cref="SetImage(string)"/>,
        /// and by some properties those cause reloading: <see cref="ResourceUrl"/>, <see cref="PreMultipliedAlpha"/> and etc.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public bool SynchronousLoading
        {
            get
            {
                return (bool)GetValue(SynchronousLoadingProperty);
            }
            set
            {
                SetValue(SynchronousLoadingProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether to automatically correct the orientation of an image.<br />
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool OrientationCorrection
        {
            get
            {
                return (bool)GetValue(OrientationCorrectionProperty);
            }
            set
            {
                SetValue(OrientationCorrectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether to apply mask on GPU or not.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MaskingModeType MaskingMode
        {
            get
            {
                return (MaskingModeType)GetValue(MaskingModeProperty);
            }
            set
            {
                SetValue(MaskingModeProperty, value);
                NotifyPropertyChanged();
            }
        }

        private MaskingModeType InternalMaskingMode
        {
            get
            {
                int ret = (int)MaskingModeType.MaskingOnLoading;

                PropertyValue maskingMode = GetCachedImageVisualProperty(ImageVisualProperty.MaskingMode);
                maskingMode?.Get(out ret);
                maskingMode?.Dispose();

                return (MaskingModeType)ret;
            }
            set
            {
                MaskingModeType ret = value;
                PropertyValue setValue = new PropertyValue((int)ret);
                UpdateImage(ImageVisualProperty.MaskingMode, setValue);
                setValue?.Dispose();
            }
        }

        /// <summary>
        /// Gets the loading state of the visual resource.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public ImageView.LoadingStatusType LoadingStatus
        {
            get
            {
                return (ImageView.LoadingStatusType)Interop.View.GetVisualResourceStatus(SwigCPtr, (int)Property.IMAGE);
            }
        }

        /// <summary>
        /// Downcasts a handle to imageView handle.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when handle is null. </exception>
        /// Do not use this, that will be deprecated. Use as keyword instead.
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Do not use this, that will be deprecated. Use as keyword instead. " +
        "Like: " +
        "BaseHandle handle = new ImageView(imagePath); " +
        "ImageView image = handle as ImageView")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ImageView DownCast(BaseHandle handle)
        {
            if (null == handle)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            ImageView ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as ImageView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets this ImageView from the given URL.<br />
        /// If the URL is empty, ImageView will not display anything.<br />
        /// </summary>
        /// <param name="url">The URL to the image resource to display.</param>
        /// <exception cref="ArgumentNullException"> Thrown when url is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetImage(string url)
        {
            if (null == url)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url.Contains(".json"))
            {
                Tizen.Log.Fatal("NUI", "[ERROR] Do not set lottie file in ImageView! This is temporary checking, will be removed soon!");
                return;
            }

            Interop.ImageView.SetImage(SwigCPtr, ConvertResourceUrl(ref url));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            _resourceUrl = url;
            // Update cached property. Note that we should not re-create new visual.
            using (PropertyValue urlValue = new PropertyValue(_resourceUrl))
            {
                UpdateImage(ImageVisualProperty.URL, urlValue, false);
            }
            imagePropertyUpdatedFlag = false;
        }

        /// <summary>
        /// Queries if all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// True if the resources are loaded and ready, false otherwise.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new bool IsResourceReady()
        {
            bool ret = Interop.View.IsResourceReady(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Forcefully reloads the image. All the visuals using this image will reload to the latest image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Reload()
        {
            // Sync as current properties
            UpdateImage();


            Interop.View.DoActionWithEmptyAttributes(this.SwigCPtr, ImageView.Property.IMAGE, ActionReload);
        }

        /// <summary>
        /// Plays the animated GIF. This is also the default playback mode.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Play()
        {
            // Sync as current properties
            UpdateImage();


            Interop.View.DoActionWithEmptyAttributes(this.SwigCPtr, ImageView.Property.IMAGE, ActionPlay);
        }

        /// <summary>
        /// Pauses the animated GIF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Pause()
        {
            // Sync as current properties
            UpdateImage();


            Interop.View.DoActionWithEmptyAttributes(this.SwigCPtr, ImageView.Property.IMAGE, ActionPause);
        }

        /// <summary>
        /// Stops the animated GIF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Stop()
        {
            // Sync as current properties
            UpdateImage();



            Interop.View.DoActionWithEmptyAttributes(this.SwigCPtr, ImageView.Property.IMAGE, ActionStop);
        }

        /// <summary>
        /// Gets or sets the URL of the alpha mask.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 6</since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AlphaMaskURL
        {
            get
            {
                return GetValue(AlphaMaskURLProperty) as string;
            }
            set
            {
                SetValue(AlphaMaskURLProperty, value);
                NotifyPropertyChanged();
            }
        }

        private string InternalAlphaMaskURL
        {
            get
            {
                string ret = "";

                PropertyValue maskUrl = GetCachedImageVisualProperty(ImageVisualProperty.AlphaMaskURL);
                maskUrl?.Get(out ret);
                maskUrl?.Dispose();

                return ret;
            }
            set
            {
                PropertyValue setValue = new PropertyValue(value ?? "");
                UpdateImage(ImageVisualProperty.AlphaMaskURL, setValue);
                // When we never set CropToMask property before, we should set default value as true.
                using (PropertyValue cropToMask = GetCachedImageVisualProperty(ImageVisualProperty.CropToMask))
                {
                    if (cropToMask == null)
                    {
                        using PropertyValue setCropValue = new PropertyValue(true);
                        UpdateImage(ImageVisualProperty.CropToMask, setCropValue);
                    }
                }
                setValue?.Dispose();
            }
        }


        /// <summary>
        ///  Whether to crop image to mask or scale mask to fit image.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool CropToMask
        {
            get
            {
                return (bool)GetValue(CropToMaskProperty);
            }
            set
            {
                SetValue(CropToMaskProperty, value);
                NotifyPropertyChanged();
            }
        }
        private bool InternalCropToMask
        {
            get
            {
                bool ret = false;

                PropertyValue cropToMask = GetCachedImageVisualProperty(ImageVisualProperty.CropToMask);
                cropToMask?.Get(out ret);
                cropToMask?.Dispose();

                return ret;
            }
            set
            {
                PropertyValue setValue = new PropertyValue(value);
                UpdateImage(ImageVisualProperty.CropToMask, setValue);
                setValue?.Dispose();
            }
        }

        /// <summary>
        /// Actions property value for Reload image.
        /// </summary>
        private int ActionReload { get; set; } = Interop.ImageView.ImageVisualActionReloadGet();

        /// <summary>
        /// Actions property value to Play animated images.
        /// This property can be redefined by child class if it use different value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int ActionPlay { get; set; } = Interop.AnimatedImageView.AnimatedImageVisualActionPlayGet();

        /// <summary>
        /// Actions property value to Pause animated images.
        /// This property can be redefined by child class if it use different value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int ActionPause { get; set; } = Interop.AnimatedImageView.AnimatedImageVisualActionPauseGet();

        /// <summary>
        /// Actions property value to Stop animated images.
        /// This property can be redefined by child class if it use different value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int ActionStop { get; set; } = Interop.AnimatedImageView.AnimatedImageVisualActionStopGet();

        internal VisualFittingModeType ConvertFittingModetoVisualFittingMode(FittingModeType value)
        {
            switch (value)
            {
                case FittingModeType.ShrinkToFit:
                    return VisualFittingModeType.FitKeepAspectRatio;
                case FittingModeType.ScaleToFill:
                    return VisualFittingModeType.OverFitKeepAspectRatio;
                case FittingModeType.Center:
                    return VisualFittingModeType.Center;
                case FittingModeType.Fill:
                    return VisualFittingModeType.Fill;
                case FittingModeType.FitHeight:
                    return VisualFittingModeType.FitHeight;
                case FittingModeType.FitWidth:
                    return VisualFittingModeType.FitWidth;
                default:
                    return VisualFittingModeType.Fill;
            }
        }

        internal FittingModeType ConvertVisualFittingModetoFittingMode(VisualFittingModeType value)
        {
            switch (value)
            {
                case VisualFittingModeType.FitKeepAspectRatio:
                    return FittingModeType.ShrinkToFit;
                case VisualFittingModeType.OverFitKeepAspectRatio:
                    return FittingModeType.ScaleToFill;
                case VisualFittingModeType.Center:
                    return FittingModeType.Center;
                case VisualFittingModeType.Fill:
                    return FittingModeType.Fill;
                case VisualFittingModeType.FitHeight:
                    return FittingModeType.FitHeight;
                case VisualFittingModeType.FitWidth:
                    return FittingModeType.FitWidth;
                default:
                    return FittingModeType.ShrinkToFit;
            }
        }

        internal override LayoutItem CreateDefaultLayout()
        {
            return new ImageLayout();
        }

        /// <summary>
        /// Gets or sets fitting options used when resizing images to fit.<br />
        /// If not supplied, the default is FittingModeType.Fill.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FittingModeType FittingMode
        {
            get
            {
                return (FittingModeType)GetValue(FittingModeProperty);
            }
            set
            {
                SetValue(FittingModeProperty, value);
                NotifyPropertyChanged();
            }
        }

        private FittingModeType InternalFittingMode
        {
            get
            {
                int ret = (int)VisualFittingModeType.Fill;

                PropertyValue fittingMode = GetCachedImageVisualProperty(Visual.Property.VisualFittingMode);
                fittingMode?.Get(out ret);
                fittingMode?.Dispose();

                return ConvertVisualFittingModetoFittingMode((VisualFittingModeType)ret);
            }
            set
            {
                VisualFittingModeType ret = ConvertFittingModetoVisualFittingMode(value);
                PropertyValue setValue = new PropertyValue((int)ret);
                UpdateImage(Visual.Property.VisualFittingMode, setValue);
                setValue?.Dispose();
            }
        }

        /// <summary>
        /// Gets or sets the desired image width.<br />
        /// If not specified, the actual image width is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DesiredWidth
        {
            get
            {
                return (int)GetValue(DesiredWidthProperty);
            }
            set
            {
                SetValue(DesiredWidthProperty, value);
                NotifyPropertyChanged();
            }
        }
        private int InternalDesiredWidth
        {
            get
            {
                // Sync as current properties only if both _desired_width and _desired_height are setuped.
                if (_desired_width != -1 && _desired_height != -1)
                {
                    UpdateImage();
                }
                PropertyValue desirewidth = GetCachedImageVisualProperty(ImageVisualProperty.DesiredWidth);
                desirewidth?.Get(out _desired_width);
                desirewidth?.Dispose();

                return _desired_width;
            }
            set
            {
                if (_desired_width != value)
                {
                    _desired_width = value;
                    PropertyValue setValue = new PropertyValue(value);
                    UpdateImage(ImageVisualProperty.DesiredWidth, setValue, false);
                    setValue?.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets or sets the desired image height.<br />
        /// If not specified, the actual image height is used.<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DesiredHeight
        {
            get
            {
                return (int)GetValue(DesiredHeightProperty);
            }
            set
            {
                SetValue(DesiredHeightProperty, value);
                NotifyPropertyChanged();
            }
        }
        private int InternalDesiredHeight
        {
            get
            {
                // Sync as current properties only if both _desired_width and _desired_height are setuped.
                if (_desired_width != -1 && _desired_height != -1)
                {
                    UpdateImage();
                }
                PropertyValue desireheight = GetCachedImageVisualProperty(ImageVisualProperty.DesiredHeight);
                desireheight?.Get(out _desired_height);
                desireheight?.Dispose();

                return _desired_height;
            }
            set
            {
                if (_desired_height != value)
                {
                    _desired_height = value;
                    PropertyValue setValue = new PropertyValue(value);
                    UpdateImage(ImageVisualProperty.DesiredHeight, setValue, false);
                    setValue?.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets or sets ReleasePolicy for image.<br />
        /// If not supplied, the default is ReleasePolicyType.Detached.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReleasePolicyType ReleasePolicy
        {
            get
            {
                return (ReleasePolicyType)GetValue(ReleasePolicyProperty);
            }
            set
            {
                SetValue(ReleasePolicyProperty, value);
                NotifyPropertyChanged();
            }
        }

        private ReleasePolicyType InternalReleasePolicy
        {
            get
            {
                int ret = (int)ReleasePolicyType.Detached;

                PropertyValue releasePoli = GetCachedImageVisualProperty(ImageVisualProperty.ReleasePolicy);
                releasePoli?.Get(out ret);
                releasePoli?.Dispose();

                return (ReleasePolicyType)ret;
            }
            set
            {
                PropertyValue setValue = new PropertyValue((int)value);
                UpdateImage(ImageVisualProperty.ReleasePolicy, setValue);
                setValue?.Dispose();
            }
        }

        /// <summary>
        /// Gets or sets the wrap mode for the u coordinate.<br />
        /// It decides how the texture should be sampled when the u coordinate exceeds the range of 0.0 to 1.0.<br />
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br />
        /// For normal quad images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WrapModeType WrapModeU
        {
            get
            {
                return (WrapModeType)GetValue(WrapModeUProperty);
            }
            set
            {
                SetValue(WrapModeUProperty, value);
                NotifyPropertyChanged();
            }
        }

        private WrapModeType InternalWrapModeU
        {
            get
            {
                int ret = (int)WrapModeType.Default;

                PropertyValue wrapModeU = GetCachedImageVisualProperty(ImageVisualProperty.WrapModeU);
                wrapModeU?.Get(out ret);
                wrapModeU?.Dispose();

                return (WrapModeType)ret;
            }
            set
            {
                PropertyValue setValue = new PropertyValue((int)value);
                UpdateImage(ImageVisualProperty.WrapModeU, setValue);
                setValue?.Dispose();
            }
        }

        /// <summary>
        /// Gets or sets the wrap mode for the v coordinate.<br />
        /// It decides how the texture should be sampled when the v coordinate exceeds the range of 0.0 to 1.0.<br />
        /// The first two elements indicate the top-left position of the area, and the last two elements are the areas of the width and the height respectively.<br />
        /// If not specified, the default is WrapModeType.Default(CLAMP).<br />
        /// For normal quad images only.
        /// Optional.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WrapModeType WrapModeV
        {
            get
            {
                return (WrapModeType)GetValue(WrapModeVProperty);
            }
            set
            {
                SetValue(WrapModeVProperty, value);
                NotifyPropertyChanged();
            }
        }

        private WrapModeType InternalWrapModeV
        {
            get
            {
                int ret = (int)WrapModeType.Default;

                PropertyValue wrapModeV = GetCachedImageVisualProperty(ImageVisualProperty.WrapModeV);
                wrapModeV?.Get(out ret);
                wrapModeV?.Dispose();

                return (WrapModeType)ret;
            }
            set
            {
                PropertyValue setValue = new PropertyValue((int)value);
                UpdateImage(ImageVisualProperty.WrapModeV, setValue);
                setValue?.Dispose();
            }
        }

        /// <summary>
        /// Gets or sets the mode to adjust view size to preserve the aspect ratio of the image resource.
        /// </summary>
        /// <remarks>
        /// This is false by default.
        /// If this is set to be true, then the width or height value, which is not set by user explicitly, can be changed automatically
        /// to preserve the aspect ratio of the image resource.
        /// AdjustViewSize works only if ImageView is added to a View having Layout.
        /// e.g. If the image resource size is (100, 100), then the ImageView requests size (100, 100) to its parent layout by default.
        ///      If the ImageView's HeightSpecification is 50 and AdjustViewSize is true, then the ImageView requests size (50, 50) instead of (100, 50).
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public bool AdjustViewSize
        {
            get
            {
                return (bool)GetValue(AdjustViewSizeProperty);
            }
            set
            {
                SetValue(AdjustViewSizeProperty, value);
                NotifyPropertyChanged();
            }
        }
        private bool adjustViewSize = false;

        /// <summary>
        /// ImageView PlaceHolderUrl, type string.
        /// This is one of mandatory property. Even if not set or null set, it sets empty string ("") internally.
        /// When it is set as null, it gives empty string ("") to be read.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlaceHolderUrl
        {
            get
            {
                return (string)GetValue(PlaceHolderUrlProperty);
            }
            set
            {
                SetValue(PlaceHolderUrlProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether the image use TransitionEffect or not<br />
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TransitionEffect
        {
            get
            {
                return (bool)GetValue(TransitionEffectProperty);
            }
            set
            {
                SetValue(TransitionEffectProperty, value);
                NotifyPropertyChanged();
            }
        }

        internal Selector<string> ResourceUrlSelector
        {
            get => GetSelector<string>(resourceUrlSelector, ImageView.ResourceUrlProperty);
            set
            {
                resourceUrlSelector?.Reset(this);
                if (value == null) return;

                if (value.HasAll()) SetResourceUrl(value.All);
                else resourceUrlSelector = new TriggerableSelector<string>(this, value, SetResourceUrl, true);
            }
        }

        /// <summary>
        /// Get attributes, it is abstract function and must be override.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new ImageViewStyle();
        }

        internal void SetImage(string url, Uint16Pair size)
        {
            if (url.Contains(".json"))
            {
                Tizen.Log.Fatal("NUI", "[ERROR] Do not set lottie file in ImageView! This is temporary checking, will be removed soon!");
                return;
            }

            Interop.ImageView.SetImage(SwigCPtr, ConvertResourceUrl(ref url), Uint16Pair.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            _resourceUrl = url;
            _desired_width = size?.GetWidth() ?? -1;
            _desired_height = size?.GetHeight() ?? -1;

            // Update cached property. Note that we should not re-create new visual.
            using (PropertyValue urlValue = new PropertyValue(_resourceUrl))
            {
                UpdateImage(ImageVisualProperty.URL, urlValue, false);
            }
            using (PropertyValue desiredWidthValue = new PropertyValue(_desired_width))
            {
                UpdateImage(ImageVisualProperty.DesiredWidth, desiredWidthValue, false);
            }
            using (PropertyValue desiredHeightValue = new PropertyValue(_desired_height))
            {
                UpdateImage(ImageVisualProperty.DesiredWidth, desiredHeightValue, false);
            }
            imagePropertyUpdatedFlag = false;
        }

        internal ViewResourceReadySignal ResourceReadySignal(View view)
        {
            ViewResourceReadySignal ret = new ViewResourceReadySignal(Interop.View.ResourceReadySignal(View.getCPtr(view)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal override void ApplyCornerRadius()
        {
            base.ApplyCornerRadius();

            if (backgroundExtraData == null) return;


            // Update corner radius properties to image by ActionUpdateProperty
            if (backgroundExtraData.CornerRadius != null)
            {
                Interop.View.InternalUpdateVisualPropertyVector4(this.SwigCPtr, ImageView.Property.IMAGE, Visual.Property.CornerRadius, Vector4.getCPtr(backgroundExtraData.CornerRadius));
            }
            Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, Visual.Property.CornerRadiusPolicy, (int)backgroundExtraData.CornerRadiusPolicy);
        }

        internal override void ApplyBorderline()
        {
            base.ApplyBorderline();

            if (backgroundExtraData == null) return;


            // Update borderline properties to image by ActionUpdateProperty
            Interop.View.InternalUpdateVisualPropertyFloat(this.SwigCPtr, ImageView.Property.IMAGE, Visual.Property.BorderlineWidth, backgroundExtraData.BorderlineWidth);
            Interop.View.InternalUpdateVisualPropertyVector4(this.SwigCPtr, ImageView.Property.IMAGE, Visual.Property.BorderlineColor, Vector4.getCPtr(backgroundExtraData.BorderlineColor ?? Color.Black));
            Interop.View.InternalUpdateVisualPropertyFloat(this.SwigCPtr, ImageView.Property.IMAGE, Visual.Property.BorderlineOffset, backgroundExtraData.BorderlineOffset);
        }

        internal ResourceLoadingStatusType GetResourceStatus()
        {
            return (ResourceLoadingStatusType)Interop.View.GetVisualResourceStatus(this.SwigCPtr, Property.IMAGE);
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            internalPixelArea?.Dispose();

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                _border?.Dispose();
                _border = null;
                borderSelector?.Reset(this);
                resourceUrlSelector?.Reset(this);
                imagePropertyUpdatedFlag = false;
                if (imagePropertyUpdateProcessAttachedFlag)
                {
                    ProcessorController.Instance.ProcessorOnceEvent -= UpdateImage;
                    imagePropertyUpdateProcessAttachedFlag = false;
                }
                cachedImagePropertyMap?.Dispose();
                cachedImagePropertyMap = null;
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ImageView.DeleteImageView(swigCPtr);
        }

        // Callback for View ResourceReady signal
        private void OnResourceReady(IntPtr data)
        {
            if (!CheckResourceReady())
            {
                return;
            }

            ResourceReadyEventArgs e = new ResourceReadyEventArgs();
            if (data != null)
            {
                e.View = Registry.GetManagedBaseHandleFromNativePtr(data) as View;
            }

            if (_resourceReadyEventHandler != null)
            {
                _resourceReadyEventHandler(this, e);
            }
        }

        private void SetResourceUrl(string value)
        {
            if (_resourceUrl != ConvertResourceUrl(ref value))
            {
                _resourceUrl = value;
                if (string.IsNullOrEmpty(_resourceUrl))
                {
                    // Special case. If we set ResourceUrl as empty, Unregist visual.
                    RemoveImage();
                }
                else
                {
                    using (PropertyValue setValue = new PropertyValue(value))
                    {
                        UpdateImage(ImageVisualProperty.URL, setValue);
                    }
                    // Special case. If we set GeneratedUrl, Create ImageVisual synchronously.
                    if (value.StartsWith("dali://") || value.StartsWith("enbuf://"))
                    {
                        UpdateImage();
                    }
                }
            }
        }

        private void SetBorder(Rectangle value)
        {
            if (value == null)
            {
                return;
            }
            if (_border != value)
            {
                _border = new Rectangle(value);
                UpdateImage(NpatchImageVisualProperty.Border, new PropertyValue(_border));
            }
        }

        /// <summary>
        /// Unregist image visual directly. After this operation, we cannot get any properties from Image property.
        /// </summary>
        private void RemoveImage()
        {
            // If previous resourceUrl was already empty, we don't need to do anything. just ignore.
            // Unregist and detach process only if previous resourceUrl was not empty
            string currentResourceUrl = "";
            PropertyValue currentResourceUrlValue = GetCachedImageVisualProperty(ImageVisualProperty.URL);
            if ((currentResourceUrlValue?.Get(out currentResourceUrl) ?? false) && !string.IsNullOrEmpty(currentResourceUrl))
            {
                PropertyValue emptyValue = new PropertyValue();

                // Remove current registed Image.
                SetProperty(ImageView.Property.IMAGE, emptyValue);

                // Image visual is not exist anymore. We should ignore lazy UpdateImage
                imagePropertyUpdatedFlag = false;
                if (imagePropertyUpdateProcessAttachedFlag)
                {
                    ProcessorController.Instance.ProcessorOnceEvent -= UpdateImage;
                    imagePropertyUpdateProcessAttachedFlag = false;
                }
                // Update resourceUrl as empty value
                cachedImagePropertyMap[ImageVisualProperty.URL] = emptyValue;

                emptyValue?.Dispose();
            }
            currentResourceUrlValue?.Dispose();
        }

        /// <summary>
        /// Lazy call to UpdateImage.
        /// Collect Properties need to be update, and set properties that starts the Processing.
        ///
        /// If you want to update cachedImagePropertyMap, but don't want to request new visual creation, make requiredVisualCreation value as false.
        /// (Example : if we change SynchronousLoading property from 'true' to 'false', or if we call this function during UpdateImage)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateImage(int key, PropertyValue value, bool requiredVisualCreation = true)
        {
            // Update image property map value as inputed value.
            if (key != 0)
            {
                if (cachedImagePropertyMap == null)
                {
                    cachedImagePropertyMap = new PropertyMap();
                }

                // To optimization, we don't check URL duplicate case. We already checked before.
                if (key != ImageVisualProperty.URL)
                {
                    using (PropertyValue oldValue = GetCachedImageVisualProperty(key))
                    {
                        if (oldValue != null && oldValue.EqualTo(value))
                        {
                            // Ignore UpdateImage query when we try to update equality value.
                            return;
                        }
                    }
                }
                imagePropertyUpdatedFlag = true;
                cachedImagePropertyMap[key] = value;

                // Lazy update only if visual creation required, and _resourceUrl is not empty, and ProcessAttachedFlag is false.
                if (requiredVisualCreation && !string.IsNullOrEmpty(_resourceUrl) && !imagePropertyUpdateProcessAttachedFlag)
                {
                    imagePropertyUpdateProcessAttachedFlag = true;
                    ProcessorController.Instance.ProcessorOnceEvent += UpdateImage;
                    // Call process hardly.
                    ProcessorController.Instance.Awake();
                }
            }
        }

        /// <summary>
        /// Callback function to Lazy UpdateImage.
        /// </summary>
        private void UpdateImage(object source, EventArgs e)
        {
            // Note : To allow event attachment during UpdateImage, let we make flag as false before call UpdateImage().
            imagePropertyUpdateProcessAttachedFlag = false;
            UpdateImage();
        }

        /// <summary>
        /// Update image-relative properties synchronously.
        /// After call this API, All image properties updated.
        /// </summary>
        /// <remarks>
        /// Current version ImageView property update asynchronously.
        /// If you want to guarantee that ImageView property setuped,
        /// Please call this ImageView.UpdateImage() API.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateImage()
        {
            if (!imagePropertyUpdatedFlag) return;

            imagePropertyUpdatedFlag = false;

            if (cachedImagePropertyMap == null)
            {
                cachedImagePropertyMap = new PropertyMap();
            }

            // Checkup the cached visual type is AnimatedImage.
            // It is trick to know that this code is running on AnimatedImageView.UpdateImage() / LottieAnimationView.UpdateImage() or not.
            int visualType = (int)Visual.Type.Invalid;
            if (!((GetCachedImageVisualProperty(Visual.Property.Type)?.Get(out visualType) ?? false) && (visualType == (int)Visual.Type.AnimatedImage || visualType == (int)Visual.Type.AnimatedVectorImage)))
            {
                // If ResourceUrl is not setuped, don't set property. fast return.
                if (string.IsNullOrEmpty(_resourceUrl))
                {
                    return;
                }
                if (_border == null)
                {
                    PropertyValue image = new PropertyValue((int)Visual.Type.Image);
                    cachedImagePropertyMap[Visual.Property.Type] = image;
                    image?.Dispose();
                }
                else
                {
                    PropertyValue nPatch = new PropertyValue((int)Visual.Type.NPatch);
                    cachedImagePropertyMap[Visual.Property.Type] = nPatch;
                    nPatch?.Dispose();
                    PropertyValue border = new PropertyValue(_border);
                    cachedImagePropertyMap[NpatchImageVisualProperty.Border] = border;
                    border?.Dispose();
                }
            }

            if (backgroundExtraData != null && backgroundExtraData.CornerRadius != null)
            {
                using (var cornerRadius = new PropertyValue(backgroundExtraData.CornerRadius))
                using (var cornerRadiusPolicy = new PropertyValue((int)backgroundExtraData.CornerRadiusPolicy))
                {
                    cachedImagePropertyMap[Visual.Property.CornerRadius] = cornerRadius;
                    cachedImagePropertyMap[Visual.Property.CornerRadiusPolicy] = new PropertyValue((int)(backgroundExtraData.CornerRadiusPolicy));
                }
            }

            if (backgroundExtraData != null && backgroundExtraData.BorderlineWidth > 0.0f)
            {
                using (var borderlineWidth = new PropertyValue(backgroundExtraData.BorderlineWidth))
                using (var borderlineColor = new PropertyValue(backgroundExtraData.BorderlineColor))
                using (var borderlineOffset = new PropertyValue(backgroundExtraData.BorderlineOffset))
                {
                    cachedImagePropertyMap[Visual.Property.BorderlineWidth] = borderlineWidth;
                    cachedImagePropertyMap[Visual.Property.BorderlineColor] = borderlineColor;
                    cachedImagePropertyMap[Visual.Property.BorderlineOffset] = borderlineOffset;
                }
            }

            // Do Fitting Buffer when desired dimension is set
            if (_desired_width != -1 && _desired_height != -1)
            {
                if (_resourceUrl != null)
                {
                    Size2D imageSize = ImageLoader.GetOriginalImageSize(_resourceUrl, true);
                    if (imageSize.Height > 0 && imageSize.Width > 0 && _desired_width > 0 && _desired_height > 0)
                    {
                        int adjustedDesiredWidth, adjustedDesiredHeight;
                        float aspectOfDesiredSize = (float)_desired_height / (float)_desired_width;
                        float aspectOfImageSize = (float)imageSize.Height / (float)imageSize.Width;
                        if (aspectOfImageSize > aspectOfDesiredSize)
                        {
                            adjustedDesiredWidth = _desired_width;
                            adjustedDesiredHeight = imageSize.Height * _desired_width / imageSize.Width;
                        }
                        else
                        {
                            adjustedDesiredWidth = imageSize.Width * _desired_height / imageSize.Height;
                            adjustedDesiredHeight = _desired_height;
                        }

                        PropertyValue returnWidth = new PropertyValue(adjustedDesiredWidth);
                        cachedImagePropertyMap[ImageVisualProperty.DesiredWidth] = returnWidth;
                        returnWidth?.Dispose();
                        PropertyValue returnHeight = new PropertyValue(adjustedDesiredHeight);
                        cachedImagePropertyMap[ImageVisualProperty.DesiredHeight] = returnHeight;
                        returnHeight?.Dispose();
                        PropertyValue scaleToFit = new PropertyValue((int)FittingModeType.ScaleToFill);
                        cachedImagePropertyMap[ImageVisualProperty.FittingMode] = scaleToFit;
                        scaleToFit?.Dispose();
                    }
                    else
                    {
                        Tizen.Log.Fatal("NUI", "[ERROR] Can't use DesiredSize when ImageLoading is failed.");
                    }
                    imageSize?.Dispose();
                }
            }

            UpdateImageMap();
        }

        /// <summary>
        /// Merge our collected properties, and set IMAGE property internally.
        /// </summary>
        private void UpdateImageMap()
        {
            // Note : We can't use ImageView.Image property here. Because That property call UpdateImage internally.
            using (PropertyMap imageMap = new PropertyMap())
            {
                using (PropertyValue returnValue = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE))
                {
                    returnValue?.Get(imageMap);
                }
                if (cachedImagePropertyMap != null)
                {
                    imageMap?.Merge(cachedImagePropertyMap);
                }
                using (PropertyValue setValue = new PropertyValue(imageMap))
                {
                    SetProperty(ImageView.Property.IMAGE, setValue);
                }

                // Update cached image property.
                MergeCachedImageVisualProperty(imageMap);
            }
        }

        /// <summary>
        /// Get image visual property by key.
        /// If we found value in local Cached result, return that.
        /// Else, get synced native map and return that.
        /// If there is no matched value, return null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual PropertyValue GetImageVisualProperty(int key)
        {
            PropertyValue ret = GetCachedImageVisualProperty(key);
            if (ret == null)
            {
                // If we cannot find result form cached map, Get value from native engine.
                ret = Image?.Find(key);
            }
            return ret;
        }

        /// <summary>
        /// Get image visual property from NUI cached image map by key.
        /// If there is no matched value, return null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual PropertyValue GetCachedImageVisualProperty(int key)
        {
            return cachedImagePropertyMap?.Find(key);
        }

        /// <summary>
        /// Update NUI cached image visual property map by inputed property map.
        /// </summary>
        /// <remarks>
        /// For performance issue, we will collect only "cachedImagePropertyKeyList" hold.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MergeCachedImageVisualProperty(PropertyMap map)
        {
            if (map == null) return;
            if (cachedImagePropertyMap == null)
            {
                cachedImagePropertyMap = new PropertyMap();
            }
            foreach (var key in cachedImagePropertyKeyList)
            {
                PropertyValue value = map.Find(key);
                if (value != null)
                {
                    // Update-or-Insert new value
                    cachedImagePropertyMap[key] = value;
                }
            }
        }

        /// <summary>
        /// GetNaturalSize() should be guaranteed that ResourceUrl property setuped.
        /// So before get base.GetNaturalSize(), we should synchronous image properties
        /// </summary>
        internal override Vector3 GetNaturalSize()
        {
            // Sync as current properties
            UpdateImage();
            return base.GetNaturalSize();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool CheckResourceReady()
        {
            // If we have some properties to be updated, this signal is old thing.
            // We need to ignore current signal, and wait next.
            return !(imagePropertyUpdateProcessAttachedFlag && imagePropertyUpdatedFlag);
        }

        private void OnResourceLoaded(IntPtr view)
        {
            if (!CheckResourceReady())
            {
                return;
            }
            ResourceLoadedEventArgs e = new ResourceLoadedEventArgs();
            e.Status = (ResourceLoadingStatusType)Interop.View.GetVisualResourceStatus(this.SwigCPtr, Property.IMAGE);

            if (_resourceLoadedEventHandler != null)
            {
                _resourceLoadedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments of resource ready.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class ResourceReadyEventArgs : EventArgs
        {
            private View _view;

            /// <summary>
            /// The view whose resource is ready.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View View
            {
                get
                {
                    return _view;
                }
                set
                {
                    _view = value;
                }
            }
        }

        internal class ResourceLoadedEventArgs : EventArgs
        {
            private ResourceLoadingStatusType status = ResourceLoadingStatusType.Invalid;
            public ResourceLoadingStatusType Status
            {
                get
                {
                    return status;
                }
                set
                {
                    status = value;
                }
            }
        }

        internal new class Property
        {
            internal static readonly int IMAGE = Interop.ImageView.ImageGet();
            internal static readonly int PreMultipliedAlpha = Interop.ImageView.PreMultipliedAlphaGet();
            internal static readonly int PixelArea = Interop.ImageView.PixelAreaGet();
            internal static readonly int PlaceHolderUrl = Interop.ImageView.PlaceHolderImageGet();
            internal static readonly int TransitionEffect = Interop.ImageView.TransitionEffectGet();
        }

        private enum ImageType
        {
            /// <summary>
            /// For Normal Image.
            /// </summary>
            Normal = 0,

            /// <summary>
            /// For normal image, with synchronous loading and orientation correction property
            /// </summary>
            Specific = 1,

            /// <summary>
            /// For nine-patch image
            /// </summary>
            Npatch = 2,
        }

        private void OnBorderChanged(int x, int y, int width, int height)
        {
            Border = new Rectangle(x, y, width, height);
        }
        private void OnPixelAreaChanged(float x, float y, float z, float w)
        {
            PixelArea = new RelativeVector4(x, y, z, w);
        }

        private class ImageLayout : LayoutItem
        {
            /// <summary>
            /// Gets or sets the mode to adjust view size to preserve the aspect ratio of the image resource.
            /// If this is set to be true, then the width or height, which is not set by user explicitly, can be adjusted to preserve the aspect ratio of the image resource.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool AdjustViewSize
            {
                get
                {
                    return (Owner as ImageView)?.AdjustViewSize ?? false;
                }
                set
                {
                    if (Owner is ImageView imageView)
                    {
                        imageView.AdjustViewSize = value;
                    }
                }
            }

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                // To not change the view size by DALi
                Owner.WidthResizePolicy = ResizePolicyType.Fixed;
                Owner.HeightResizePolicy = ResizePolicyType.Fixed;

                float specWidth = widthMeasureSpec.Size.AsDecimal();
                float specHeight = heightMeasureSpec.Size.AsDecimal();
                float naturalWidth = Owner.NaturalSize.Width;
                float naturalHeight = Owner.NaturalSize.Height;
                float minWidth = Owner.MinimumSize.Width;
                float maxWidth = Owner.MaximumSize.Width;
                float minHeight = Owner.MinimumSize.Height;
                float maxHeight = Owner.MaximumSize.Height;
                float aspectRatio = (naturalWidth > 0) ? (naturalHeight / naturalWidth) : 0;

                // Assume that the new width and height are given from the view's suggested size by default.
                float newWidth = Math.Min(Math.Max(naturalWidth, minWidth), (maxWidth < 0 ? Int32.MaxValue : maxWidth));
                float newHeight = Math.Min(Math.Max(naturalHeight, minHeight), (maxHeight < 0 ? Int32.MaxValue : maxHeight));

                // The width and height measure specs are going to be used to set measured size.
                // Mark that the measure specs are changed by default to update measure specs later.
                bool widthSpecChanged = true;
                bool heightSpecChanged = true;

                if (widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                {
                    newWidth = specWidth;
                    widthSpecChanged = false;

                    if (heightMeasureSpec.Mode != MeasureSpecification.ModeType.Exactly)
                    {
                        if ((AdjustViewSize) && (aspectRatio > 0))
                        {
                            newHeight = newWidth * aspectRatio;
                        }
                    }
                }

                if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                {
                    newHeight = specHeight;
                    heightSpecChanged = false;

                    if (widthMeasureSpec.Mode != MeasureSpecification.ModeType.Exactly)
                    {
                        if ((AdjustViewSize) && (aspectRatio > 0))
                        {
                            newWidth = newHeight / aspectRatio;
                        }
                    }
                }

                if (widthSpecChanged)
                {
                    widthMeasureSpec = new MeasureSpecification(new LayoutLength(newWidth), MeasureSpecification.ModeType.Exactly);
                }

                if (heightSpecChanged)
                {
                    heightMeasureSpec = new MeasureSpecification(new LayoutLength(newHeight), MeasureSpecification.ModeType.Exactly);
                }

                MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
                MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

                SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(newWidth), widthMeasureSpec, childWidthState),
                                      ResolveSizeAndState(new LayoutLength(newHeight), heightMeasureSpec, childHeightState));
            }
        }
    }
}
