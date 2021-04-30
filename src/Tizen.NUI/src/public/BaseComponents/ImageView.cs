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
    public class ImageView : View
    {
        static ImageView() { }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceUrlProperty = BindableProperty.Create(nameof(ImageView.ResourceUrl), typeof(string), typeof(ImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;

            if (newValue is Selector<string> selector)
            {
                imageView.ResourceUrlSelector = selector;
            }
            else
            {
                imageView.resourceUrlSelector?.Reset(imageView);
                imageView.SetResourceUrl((string)newValue);
            }
        },
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;
            string ret = "";

            PropertyMap imageMap = new PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.IMAGE).Get(imageMap);
            imageMap.Find(ImageVisualProperty.URL)?.Get(out ret);
            return ret;
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(ImageView.Image), typeof(PropertyMap), typeof(ImageView), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                PropertyMap map = (PropertyMap)newValue;
                if (imageView.IsCreateByXaml)
                {
                    string url = "", alphaMaskURL = "", auxiliaryImageURL = "";
                    string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                    PropertyValue urlValue = map.Find(NDalic.ImageVisualUrl);
                    bool ret = false;
                    if (urlValue != null) ret = urlValue.Get(out url);
                    PropertyMap mmap = new PropertyMap();
                    if (ret && url.StartsWith("*Resource*"))
                    {
                        url = url.Replace("*Resource*", resource);
                        mmap.Insert(NDalic.ImageVisualUrl, new PropertyValue(url));
                    }

                    ret = false;
                    PropertyValue alphaMaskUrlValue = map.Find(NDalic.ImageVisualAlphaMaskUrl);
                    if (alphaMaskUrlValue != null) ret = alphaMaskUrlValue.Get(out alphaMaskURL);
                    if (ret && alphaMaskURL.StartsWith("*Resource*"))
                    {
                        alphaMaskURL = alphaMaskURL.Replace("*Resource*", resource);
                        mmap.Insert(NDalic.ImageVisualUrl, new PropertyValue(alphaMaskURL));
                    }

                    ret = false;
                    PropertyValue auxiliaryImageURLValue = map.Find(NDalic.ImageVisualAuxiliaryImageUrl);
                    if (auxiliaryImageURLValue != null) ret = auxiliaryImageURLValue.Get(out auxiliaryImageURL);
                    if (ret && auxiliaryImageURL.StartsWith("*Resource*"))
                    {
                        auxiliaryImageURL = auxiliaryImageURL.Replace("*Resource*", resource);
                        mmap.Insert(NDalic.ImageVisualAuxiliaryImageUrl, new PropertyValue(auxiliaryImageURL));
                    }

                    map.Merge(mmap);
                }
                if (imageView._border == null)
                {
                    Tizen.NUI.Object.SetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.IMAGE, new Tizen.NUI.PropertyValue(map));
                }
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;
            if (imageView._border == null)
            {
                PropertyMap temp = new PropertyMap();
                Tizen.NUI.Object.GetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.IMAGE).Get(temp);
                return temp;
            }
            else
            {
                return null;
            }
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PreMultipliedAlphaProperty = BindableProperty.Create(nameof(PreMultipliedAlpha), typeof(bool), typeof(ImageView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.PreMultipliedAlpha, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.PreMultipliedAlpha).Get(out temp);
            return temp;
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelAreaProperty = BindableProperty.Create(nameof(PixelArea), typeof(RelativeVector4), typeof(ImageView), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.PixelArea, new Tizen.NUI.PropertyValue((RelativeVector4)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.PixelArea).Get(temp);
            RelativeVector4 relativeTemp = new RelativeVector4(temp.X, temp.Y, temp.Z, temp.W);
            return relativeTemp;
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderProperty = BindableProperty.Create(nameof(Border), typeof(Rectangle), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            imageView.borderSelector?.Reset(imageView);

            if (newValue is Selector<Rectangle> selector)
            {
                if (selector.HasAll()) imageView.SetBorder(selector.All);
                else imageView.borderSelector = new TriggerableSelector<Rectangle>(imageView, selector, imageView.SetBorder, true);
            }
            else
            {
                imageView.SetBorder((Rectangle)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView._border;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderOnlyProperty = BindableProperty.Create(nameof(BorderOnly), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView.UpdateImage(NpatchImageVisualProperty.BorderOnly, new PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;
            bool ret = false;
            PropertyMap imageMap = new PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.IMAGE).Get(imageMap);
            imageMap.Find(ImageVisualProperty.BorderOnly)?.Get(out ret);
            return ret;
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronosLoadingProperty = BindableProperty.Create(nameof(SynchronosLoading), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView._synchronosLoading = (bool)newValue;
                imageView.UpdateImage(NpatchImageVisualProperty.SynchronousLoading, new PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView._synchronosLoading;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationCorrectionProperty = BindableProperty.Create(nameof(OrientationCorrection), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView.UpdateImage(ImageVisualProperty.OrientationCorrection, new PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;

            bool ret = false;
            PropertyMap imageMap = new PropertyMap();
            Tizen.NUI.Object.GetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.IMAGE).Get(imageMap);
            imageMap?.Find(ImageVisualProperty.OrientationCorrection)?.Get(out ret);

            return ret;
        }));

        private EventHandler<ResourceReadyEventArgs> _resourceReadyEventHandler;
        private ResourceReadyEventCallbackType _resourceReadyEventCallback;
        private EventHandler<ResourceLoadedEventArgs> _resourceLoadedEventHandler;
        private _resourceLoadedCallbackType _resourceLoadedCallback;

        private Rectangle _border;
        private string _resourceUrl = "";
        private bool _synchronosLoading = false;
        private string _alphaMaskUrl = null;
        private int _desired_width = -1;
        private int _desired_height = -1;
        private VisualFittingModeType _fittingMode = VisualFittingModeType.Fill;
        private TriggerableSelector<string> resourceUrlSelector;
        private TriggerableSelector<Rectangle> borderSelector;

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
        public ImageView(string url) : this(Interop.ImageView.New(url), true)
        {
            ResourceUrl = url;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates an initialized ImageView from a URL to an image resource with setting shown or hidden.
        /// </summary>
        /// <param name="url">The URL of the image resource to display.</param>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView(string url, bool shown) : this(Interop.ImageView.New(url), true)
        {
            ResourceUrl = url;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        internal ImageView(string url, Uint16Pair size, bool shown = true) : this(Interop.ImageView.New(url, Uint16Pair.getCPtr(size)), true)
        {
            ResourceUrl = url;
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
        /// This will be deprecated, please use Image instead. <br />
        /// ImageView ImageMap, type PropertyMap: string if it is a URL, map otherwise.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use Image property instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap ImageMap
        {
            get
            {
                if (_border == null)
                {
                    PropertyMap returnValue = new PropertyMap();
                    PropertyValue image = GetProperty(ImageView.Property.IMAGE);
                    image?.Get(returnValue);
                    image?.Dispose();
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
                    NotifyPropertyChanged();
                    setValue?.Dispose();
                }
            }
        }

        /// <summary>
        /// ImageView Image, type PropertyMap
        /// </summary>
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
                RelativeVector4 temp = (RelativeVector4)GetValue(PixelAreaProperty);
                return new RelativeVector4(OnPixelAreaChanged, temp.X, temp.Y, temp.Z, temp.W);
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
        public bool SynchronosLoading
        {
            get
            {
                return (bool)GetValue(SynchronosLoadingProperty);
            }
            set
            {
                SetValue(SynchronosLoadingProperty, value);
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
        /// Please do not use! this will be deprecated!
        /// Instead please use as keyword.
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use as keyword instead! " +
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
                Tizen.Log.Fatal("NUI", "[ERROR] Please DO NOT set lottie file in ImageView! This is temporary checking, will be removed soon!");
                return;
            }

            Interop.ImageView.SetImage(SwigCPtr, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            ResourceUrl = url;
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
            PropertyValue attributes = new PropertyValue(0);
            this.DoAction(ImageView.Property.IMAGE, Property.ActionReload, attributes);
            attributes?.Dispose();
        }

        /// <summary>
        /// Plays the animated GIF. This is also the default playback mode.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Play()
        {
            PropertyValue attributes = new PropertyValue(0);
            this.DoAction(ImageView.Property.IMAGE, Property.ActionPlay, attributes);
            attributes?.Dispose();
        }

        /// <summary>
        /// Pauses the animated GIF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Pause()
        {
            PropertyValue attributes = new PropertyValue(0);
            this.DoAction(ImageView.Property.IMAGE, Property.ActionPause, attributes);
            attributes?.Dispose();
        }

        /// <summary>
        /// Stops the animated GIF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Stop()
        {
            PropertyValue attributes = new PropertyValue(0);
            this.DoAction(ImageView.Property.IMAGE, Property.ActionStop, attributes);
            attributes?.Dispose();
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
                string ret = "";
                PropertyMap imageMap = new PropertyMap();
                PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
                image?.Get(imageMap);
                PropertyValue maskUrl = imageMap?.Find(ImageVisualProperty.AlphaMaskURL);
                maskUrl?.Get(out ret);
                _alphaMaskUrl = ret;

                imageMap?.Dispose();
                image?.Dispose();
                maskUrl?.Dispose();

                return ret;
            }
            set
            {
                if (value == null)
                {
                    value = "";
                }

                _alphaMaskUrl = value;

                PropertyValue setValue = new PropertyValue(value);
                UpdateImage(ImageVisualProperty.AlphaMaskURL, setValue);
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
                bool ret = false;
                PropertyMap imageMap = new PropertyMap();
                PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
                image?.Get(imageMap);
                PropertyValue cropUrl = imageMap?.Find(ImageVisualProperty.CropToMask);
                cropUrl?.Get(out ret);

                imageMap?.Dispose();
                image?.Dispose();
                cropUrl?.Dispose();

                return ret;
            }
            set
            {
                PropertyValue setValue = new PropertyValue(value);
                UpdateImage(ImageVisualProperty.CropToMask, setValue);
                setValue.Dispose();
            }
        }

        internal VisualFittingModeType CovertFittingModetoVisualFittingMode(FittingModeType value)
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
                    return VisualFittingModeType.FitHeight;
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
                int ret = (int)_fittingMode;
                PropertyMap imageMap = new PropertyMap();
                PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
                image?.Get(imageMap);
                PropertyValue fittingMode = imageMap?.Find(Visual.Property.VisualFittingMode);
                fittingMode?.Get(out ret);
                _fittingMode = (VisualFittingModeType)ret;

                imageMap?.Dispose();
                image?.Dispose();
                fittingMode?.Dispose();

                return ConvertVisualFittingModetoFittingMode((VisualFittingModeType)ret);
            }
            set
            {
                VisualFittingModeType ret = CovertFittingModetoVisualFittingMode(value);
                _fittingMode = ret;
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
                PropertyMap imageMap = new PropertyMap();
                PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
                image?.Get(imageMap);
                PropertyValue desireWidth = imageMap?.Find(ImageVisualProperty.DesiredWidth);
                desireWidth?.Get(out _desired_width);

                imageMap?.Dispose();
                image?.Dispose();
                desireWidth?.Dispose();

                return _desired_width;
            }
            set
            {
                if (_desired_width != value)
                {
                    _desired_width = value;
                    UpdateImage(0, null);
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
                PropertyMap imageMap = new PropertyMap();
                PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
                image?.Get(imageMap);
                PropertyValue desireheight = imageMap?.Find(ImageVisualProperty.DesiredHeight);
                desireheight?.Get(out _desired_height);

                imageMap?.Dispose();
                image?.Dispose();
                desireheight?.Dispose();

                return _desired_height;
            }
            set
            {
                if (_desired_height != value)
                {
                    _desired_height = value;
                    UpdateImage(0, null);
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
                int ret = (int)ReleasePolicyType.Detached;
                PropertyMap imageMap = new PropertyMap();
                PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
                image?.Get(imageMap);
                PropertyValue releasePoli = imageMap?.Find(ImageVisualProperty.ReleasePolicy);
                releasePoli?.Get(out ret);

                imageMap?.Dispose();
                image?.Dispose();
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
                int ret = (int)WrapModeType.Default;
                PropertyMap imageMap = new PropertyMap();
                PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
                image?.Get(imageMap);
                PropertyValue warpModeU = imageMap?.Find(ImageVisualProperty.WrapModeU);
                warpModeU?.Get(out ret);

                imageMap?.Dispose();
                image?.Dispose();
                warpModeU?.Dispose();

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
                int ret = (int)WrapModeType.Default;
                PropertyMap imageMap = new PropertyMap();
                PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
                image?.Get(imageMap);
                PropertyValue wrapModeV = imageMap?.Find(ImageVisualProperty.WrapModeV);
                wrapModeV?.Get(out ret);

                imageMap?.Dispose();
                image?.Dispose();
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
                Tizen.Log.Fatal("NUI", "[ERROR] Please DO NOT set lottie file in ImageView! This is temporary checking, will be removed soon!");
                return;
            }

            Interop.ImageView.SetImage(SwigCPtr, url, Uint16Pair.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            ResourceUrl = url;
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

            UpdateImage(0, null);
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

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                _border?.Dispose();
                _border = null;
                borderSelector?.Reset(this);
                resourceUrlSelector?.Reset(this);
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
            value = (value == null ? "" : value);
            if (value.StartsWith("*Resource*"))
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                value = value.Replace("*Resource*", resource);
            }
            _resourceUrl = value;
            UpdateImage(ImageVisualProperty.URL, new PropertyValue(value));
        }

        private void SetBorder(Rectangle value)
        {
            if (value == null)
            {
                return;
            }
            _border = new Rectangle(value);
            UpdateImage(NpatchImageVisualProperty.Border, new PropertyValue(_border));
        }

        private void UpdateImageMap(PropertyMap fromMap)
        {
            PropertyMap imageMap = new PropertyMap();

            PropertyValue image = Tizen.NUI.Object.GetProperty(SwigCPtr, ImageView.Property.IMAGE);
            image?.Get(imageMap);
            imageMap?.Merge(fromMap);
            PropertyValue setValue = new PropertyValue(imageMap);
            SetProperty(ImageView.Property.IMAGE, setValue);

            imageMap?.Dispose();
            image?.Dispose();
            setValue?.Dispose();
        }

        private void UpdateImage(int key, PropertyValue value)
        {
            PropertyMap imageMap = new PropertyMap();

            if (_alphaMaskUrl != null)
            {
                PropertyValue alphaMaskUrl = new PropertyValue(_alphaMaskUrl);
                imageMap?.Insert(ImageVisualProperty.AlphaMaskURL, alphaMaskUrl);
                alphaMaskUrl?.Dispose();
            }

            if (string.IsNullOrEmpty(_resourceUrl))
            {
                PropertyValue resourceUrl = new PropertyValue(_resourceUrl);
                imageMap?.Insert(ImageVisualProperty.URL, resourceUrl);
                PropertyValue setValue = new PropertyValue(imageMap);
                SetProperty(ImageView.Property.IMAGE, setValue);
                resourceUrl?.Dispose();
                setValue?.Dispose();
                return;
            }

            if (_border == null)
            {
                PropertyValue image = new PropertyValue((int)Visual.Type.Image);
                imageMap?.Insert(Visual.Property.Type, image);
                image?.Dispose();
            }
            else
            {
                PropertyValue nPatch = new PropertyValue((int)Visual.Type.NPatch);
                imageMap?.Insert(Visual.Property.Type, nPatch);
                nPatch?.Dispose();
                PropertyValue border = new PropertyValue(_border);
                imageMap?.Insert(NpatchImageVisualProperty.Border, border);
                border?.Dispose();
            }

            if(key != Visual.Property.VisualFittingMode && _fittingMode != VisualFittingModeType.Fill)
            {
                PropertyValue fittingMode = new PropertyValue((int)_fittingMode);
                imageMap?.Insert(Visual.Property.VisualFittingMode, fittingMode);
                fittingMode?.Dispose();
            }

            PropertyValue synchronosLoading = new PropertyValue(_synchronosLoading);
            imageMap?.Insert(NpatchImageVisualProperty.SynchronousLoading, synchronosLoading);
            synchronosLoading?.Dispose();

            if (backgroundExtraData != null && backgroundExtraData.CornerRadius != null)
            {
                using (var cornerRadius = new PropertyValue(backgroundExtraData.CornerRadius))
                using (var cornerRadiusPolicy = new PropertyValue((int)backgroundExtraData.CornerRadiusPolicy))
                {
                    imageMap.Insert(Visual.Property.CornerRadius, cornerRadius);
                    imageMap.Insert(Visual.Property.CornerRadiusPolicy, new PropertyValue((int)(backgroundExtraData.CornerRadiusPolicy)));
                }
            }

            if (value != null)
            {
                imageMap?.Insert(key, value);
            }

            // Do Fitting Buffer when desired dimension is set
            if (_desired_width != -1 && _desired_height != -1)
            {
                if (_resourceUrl != null)
                {
                    Size2D imageSize = ImageLoading.GetOriginalImageSize(_resourceUrl, true);

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
                    imageMap?.Insert(ImageVisualProperty.DesiredWidth, returnWidth);
                    returnWidth?.Dispose();
                    PropertyValue returnHeight = new PropertyValue(adjustedDesiredHeight);
                    imageMap?.Insert(ImageVisualProperty.DesiredHeight, returnHeight);
                    returnHeight?.Dispose();
                    PropertyValue scaleToFit = new PropertyValue((int)FittingModeType.ScaleToFill);
                    imageMap?.Insert(ImageVisualProperty.FittingMode, scaleToFit);
                    scaleToFit?.Dispose();
                }
            }

            UpdateImageMap(imageMap);

            imageMap?.Dispose();
            imageMap = null;
        }


        private void OnResourceLoaded(IntPtr view)
        {
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
            internal static readonly int ActionReload = Interop.ImageView.ImageVisualActionReloadGet();
            internal static readonly int ActionPlay = Interop.ImageView.ImageVisualActionPlayGet();
            internal static readonly int ActionPause = Interop.ImageView.ImageVisualActionPauseGet();
            internal static readonly int ActionStop = Interop.ImageView.ImageVisualActionStopGet();
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
    }
}
