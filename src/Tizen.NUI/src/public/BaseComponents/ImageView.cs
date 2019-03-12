/*
* Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ResourceUrlProperty = BindableProperty.Create(nameof(ImageView.ResourceUrl), typeof(string), typeof(ImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                string url = (string)newValue;
                if (imageView.IsCreateByXaml && url.Contains("*Resource*"))
                {
                    string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                    url = url.Replace("*Resource*", resource);
                }
                imageView._url = url;
                imageView.UpdateImage();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            if(_imageType == ImageType.Normal)
            {
                Tizen.NUI.Object.GetProperty(imageView.swigCPtr, ImageView.Property.IMAGE).Get(out imageView._url);
            }
            return imageView._url;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(ImageView.Image), typeof(PropertyMap), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                PropertyMap map = (PropertyMap)newValue;
                if (imageView.IsCreateByXaml)
                {
                    string url = "", alphaMaskURL = "", auxiliaryImageURL = "";
                    string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                    PropertyValue urlValue = map.Find(NDalic.IMAGE_VISUAL_URL);
                    bool ret = false;
                    if (urlValue != null) ret = urlValue.Get(out url);
                    PropertyMap mmap = new PropertyMap();
                    if (ret && url.Contains("*Resource*"))
                    {
                        url = url.Replace("*Resource*", resource);
                        mmap.Insert(NDalic.IMAGE_VISUAL_URL, new PropertyValue(url));
                    }

                    ret = false;
                    PropertyValue alphaMaskUrlValue = map.Find(NDalic.IMAGE_VISUAL_ALPHA_MASK_URL);
                    if (alphaMaskUrlValue != null) ret = alphaMaskUrlValue.Get(out alphaMaskURL);
                    if (ret && alphaMaskURL.Contains("*Resource*"))
                    {
                        alphaMaskURL = alphaMaskURL.Replace("*Resource*", resource);
                        mmap.Insert(NDalic.IMAGE_VISUAL_URL, new PropertyValue(alphaMaskURL));
                    }

                    ret = false;
                    PropertyValue auxiliaryImageURLValue = map.Find(NDalic.IMAGE_VISUAL_AUXILIARY_IMAGE_URL);
                    if (auxiliaryImageURLValue != null) ret = auxiliaryImageURLValue.Get(out auxiliaryImageURL);
                    if (ret && auxiliaryImageURL.Contains("*Resource*"))
                    {
                        auxiliaryImageURL = auxiliaryImageURL.Replace("*Resource*", resource);
                        mmap.Insert(NDalic.IMAGE_VISUAL_AUXILIARY_IMAGE_URL, new PropertyValue(auxiliaryImageURL));
                    }

                    map.Merge(mmap);
                }
                if (imageView._border == null)
                {
                    imageView._image = map;
                    imageView.UpdateImage();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            if (imageView._border == null)
            {
                PropertyMap temp = new PropertyMap();
                Tizen.NUI.Object.GetProperty(imageView.swigCPtr, ImageView.Property.IMAGE).Get(temp);
                return temp;
            }
            else
            {
                return null;
            }
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PreMultipliedAlphaProperty = BindableProperty.Create("PreMultipliedAlpha", typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(imageView.swigCPtr, ImageView.Property.PRE_MULTIPLIED_ALPHA, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(imageView.swigCPtr, ImageView.Property.PRE_MULTIPLIED_ALPHA).Get(out temp);
            return temp;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelAreaProperty = BindableProperty.Create("PixelArea", typeof(RelativeVector4), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(imageView.swigCPtr, ImageView.Property.PIXEL_AREA, new Tizen.NUI.PropertyValue((RelativeVector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(imageView.swigCPtr, ImageView.Property.PIXEL_AREA).Get(temp);
            RelativeVector4 relativeTemp = new RelativeVector4(temp.X, temp.Y, temp.Z, temp.W);
            return relativeTemp;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderProperty = BindableProperty.Create("Border", typeof(Rectangle), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView._border = (Rectangle)newValue;
                imageView.UpdateImage();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView._border;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderOnlyProperty = BindableProperty.Create("BorderOnly", typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView._borderOnly = (bool)newValue;
                imageView.UpdateImage();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView._borderOnly ?? false;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronosLoadingProperty = BindableProperty.Create("SynchronosLoading", typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView._synchronousLoading = (bool)newValue;
                imageView.UpdateImage();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView._synchronousLoading ?? false;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationCorrectionProperty = BindableProperty.Create("OrientationCorrection", typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView._orientationCorrection = (bool)newValue;
                imageView.UpdateImage();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView._orientationCorrection ?? false;
        });

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private EventHandler<ResourceReadyEventArgs> _resourceReadyEventHandler;
        private ResourceReadyEventCallbackType _resourceReadyEventCallback;
        private EventHandler<ResourceLoadedEventArgs> _resourceLoadedEventHandler;
        private _resourceLoadedCallbackType _resourceLoadedCallback;

        private Rectangle _border;
        private PropertyMap _nPatchMap;
        private bool? _synchronousLoading;
        private bool? _borderOnly;
        private string _url;
        private bool? _orientationCorrection;
        private PropertyMap _image;
        private static ImageType _imageType;

        /// <summary>
        /// Creates an initialized ImageView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImageView() : this(NDalicPINVOKE.ImageView_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized ImageView from a URL to an image resource.<br />
        /// If the string is empty, ImageView will not display anything.<br />
        /// </summary>
        /// <param name="url">The URL of the image resource to display.</param>
        /// <since_tizen> 3 </since_tizen>
        public ImageView(string url) : this(NDalicPINVOKE.ImageView_New__SWIG_2(url), true)
        {
            _url = url;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal ImageView(string url, Uint16Pair size) : this(NDalicPINVOKE.ImageView_New__SWIG_3(url, Uint16Pair.getCPtr(size)), true)
        {
            _url = url;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal ImageView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ImageView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
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
                    ResourceReadySignal(this).Connect(_resourceReadyEventCallback);
                }

                _resourceReadyEventHandler += value;
            }

            remove
            {
                _resourceReadyEventHandler -= value;

                if (_resourceReadyEventHandler == null && ResourceReadySignal(this).Empty() == false)
                {
                    ResourceReadySignal(this).Disconnect(_resourceReadyEventCallback);
                }
            }
        }

        internal event EventHandler<ResourceLoadedEventArgs> ResourceLoaded
        {
            add
            {
                if (_resourceLoadedEventHandler == null)
                {
                    _resourceLoadedCallback = OnResourceLoaded;
                    this.ResourceReadySignal(this).Connect(_resourceLoadedCallback);
                }

                _resourceLoadedEventHandler += value;
            }
            remove
            {
                _resourceLoadedEventHandler -= value;

                if (_resourceLoadedEventHandler == null && this.ResourceReadySignal(this).Empty() == false)
                {
                    this.ResourceReadySignal(this).Disconnect(_resourceLoadedCallback);
                }
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
                _url = (value == null ? "" : value);
                SetValue(ResourceUrlProperty, _url);
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
                    PropertyMap temp = new PropertyMap();
                    GetProperty(ImageView.Property.IMAGE).Get(temp);
                    return temp;
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
                    if (_url != null) { value.Add("url", new PropertyValue(_url)); }
                    SetProperty(ImageView.Property.IMAGE, new Tizen.NUI.PropertyValue(value));
                    NotifyPropertyChanged();
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
        /// <since_tizen> 3 </since_tizen>
        public Rectangle Border
        {
            get
            {
                return (Rectangle)GetValue(BorderProperty);
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
        /// Gets or sets whether to synchronos loading the resourceurl of image.<br />
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
                return (ImageView.LoadingStatusType)NDalicManualPINVOKE.View_GetVisualResourceStatus(swigCPtr, (int)Property.IMAGE);
            }
        }

        /// <summary>
        /// Downcasts a handle to imageView handle.
        /// </summary>
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
            ImageView ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as ImageView;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets this ImageView from the given URL.<br />
        /// If the URL is empty, ImageView will not display anything.<br />
        /// </summary>
        /// <param name="url">The URL to the image resource to display.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetImage(string url)
        {
            _url = url;
            NDalicPINVOKE.ImageView_SetImage__SWIG_1(swigCPtr, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Queries if all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// True if the resources are loaded and ready, false otherwise.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new bool IsResourceReady()
        {
            bool ret = NDalicPINVOKE.IsResourceReady(swigCPtr);
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
            this.DoAction(ImageView.Property.IMAGE, Property.ACTION_RELOAD, new PropertyValue(0));
        }

        /// <summary>
        /// Plays the animated GIF. This is also the default playback mode.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Play()
        {
            this.DoAction(ImageView.Property.IMAGE, Property.ACTION_PLAY, new PropertyValue(0));
        }

        /// <summary>
        /// Pauses the animated GIF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Pause()
        {
            this.DoAction(ImageView.Property.IMAGE, Property.ACTION_PAUSE, new PropertyValue(0));
        }

        /// <summary>
        /// Stops the animated GIF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Stop()
        {
            this.DoAction(ImageView.Property.IMAGE, Property.ACTION_STOP, new PropertyValue(0));
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ImageView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal void SetImage(string url, Uint16Pair size)
        {
            _url = url;
            NDalicPINVOKE.ImageView_SetImage__SWIG_2(swigCPtr, url, Uint16Pair.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ViewResourceReadySignal ResourceReadySignal(View view)
        {
            ViewResourceReadySignal ret = new ViewResourceReadySignal(NDalicPINVOKE.ResourceReadySignal(View.getCPtr(view)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ResourceLoadingStatusType GetResourceStatus()
        {
            return (ResourceLoadingStatusType)NDalicManualPINVOKE.View_GetVisualResourceStatus(this.swigCPtr, Property.IMAGE);
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
                _nPatchMap?.Dispose();
                _nPatchMap = null;
                _image?.Dispose();
                _image = null;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_ImageView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
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

        private void UpdateImage()
        {
            if (_url != null && _url != "")
            {
                if (_border != null)
                { // for nine-patch image
                    _nPatchMap = new PropertyMap();
                    _nPatchMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch));
                    _nPatchMap.Add(NpatchImageVisualProperty.URL, new PropertyValue(_url));
                    _nPatchMap.Add(NpatchImageVisualProperty.Border, new PropertyValue(_border));
                    if (_borderOnly != null) { _nPatchMap.Add(NpatchImageVisualProperty.BorderOnly, new PropertyValue((bool)_borderOnly)); }
                    if (_synchronousLoading != null) { _nPatchMap.Add(NpatchImageVisualProperty.SynchronousLoading, new PropertyValue((bool)_synchronousLoading)); }
                    if (_orientationCorrection != null) { _nPatchMap.Add(ImageVisualProperty.OrientationCorrection, new PropertyValue((bool)_orientationCorrection)); }
                    SetProperty(ImageView.Property.IMAGE, new PropertyValue(_nPatchMap));
                    _imageType = ImageType.Npatch;
                }
                else if (_synchronousLoading != null || _orientationCorrection != null)
                { // for normal image, with synchronous loading property
                    PropertyMap imageMap = new PropertyMap();
                    imageMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                    imageMap.Add(ImageVisualProperty.URL, new PropertyValue(_url));
                    if (_synchronousLoading != null) { imageMap.Add(ImageVisualProperty.SynchronousLoading, new PropertyValue((bool)_synchronousLoading)); }
                    if (_orientationCorrection != null) { imageMap.Add(ImageVisualProperty.OrientationCorrection, new PropertyValue((bool)_orientationCorrection)); }
                    SetProperty(ImageView.Property.IMAGE, new PropertyValue(imageMap));

                    _imageType = ImageType.Specific;
                }
                else
                { // just for normal image
                    SetProperty(ImageView.Property.IMAGE, new PropertyValue(_url));
                    _imageType = ImageType.Normal;
                }
            }
            else
            {
                //Image property is set and used
                PropertyMap map = new PropertyMap();
                map.Insert(ImageVisualProperty.URL, new PropertyValue(""));
                if (_synchronousLoading != null)
                {
                    map.Insert(ImageVisualProperty.SynchronousLoading, new PropertyValue((bool)_synchronousLoading));
                }
                if (_orientationCorrection != null)
                {
                    map.Insert(ImageVisualProperty.OrientationCorrection, new PropertyValue((bool)_orientationCorrection));
                }
                if (_image != null)
                {
                    map.Merge(_image);
                }
                SetProperty(ImageView.Property.IMAGE, new PropertyValue(map));
                _imageType = ImageType.Normal;
            }
        }

        private void OnResourceLoaded(IntPtr view)
        {
            ResourceLoadedEventArgs e = new ResourceLoadedEventArgs();
            e.Status = (ResourceLoadingStatusType)NDalicManualPINVOKE.View_GetVisualResourceStatus(this.swigCPtr, Property.IMAGE);

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
            internal static readonly int RESOURCE_URL = NDalicPINVOKE.ImageView_Property_RESOURCE_URL_get();
            internal static readonly int IMAGE = NDalicPINVOKE.ImageView_Property_IMAGE_get();
            internal static readonly int PRE_MULTIPLIED_ALPHA = NDalicPINVOKE.ImageView_Property_PRE_MULTIPLIED_ALPHA_get();
            internal static readonly int PIXEL_AREA = NDalicPINVOKE.ImageView_Property_PIXEL_AREA_get();
            internal static readonly int ACTION_RELOAD = NDalicManualPINVOKE.ImageView_IMAGE_VISUAL_ACTION_RELOAD_get();
            internal static readonly int ACTION_PLAY = NDalicManualPINVOKE.ImageView_IMAGE_VISUAL_ACTION_PLAY_get();
            internal static readonly int ACTION_PAUSE = NDalicManualPINVOKE.ImageView_IMAGE_VISUAL_ACTION_PAUSE_get();
            internal static readonly int ACTION_STOP = NDalicManualPINVOKE.ImageView_IMAGE_VISUAL_ACTION_STOP_get();
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
    }
}
