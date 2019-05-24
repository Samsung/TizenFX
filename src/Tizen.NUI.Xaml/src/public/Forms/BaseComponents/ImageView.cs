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
using Tizen.NUI;
using static Tizen.NUI.BaseComponents.ImageView;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    /// <summary>
    /// ImageView is a class for displaying an image resource.<br />
    /// An instance of ImageView can be created using a URL or an image instance.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ImageView : View
    {
        private Tizen.NUI.BaseComponents.ImageView _imageView;
        private Tizen.NUI.BaseComponents.ImageView imageView
        {
            get
            {
                if (_imageView == null)
                {
                    _imageView = handleInstance as Tizen.NUI.BaseComponents.ImageView;
                }

                return _imageView;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImageView() : this(new Tizen.NUI.BaseComponents.ImageView())
        {
        }

        internal ImageView(Tizen.NUI.BaseComponents.ImageView nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ResourceUrlProperty = Binding.BindableProperty.Create(nameof(Tizen.NUI.BaseComponents.ImageView.ResourceUrl), typeof(string), typeof(ImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;

            string url = (string)newValue;
            if (url.Contains("*Resource*"))
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                url = url.Replace("*Resource*", resource);
            }

            imageView.imageView.ResourceUrl = url;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView.imageView.ResourceUrl;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ImageProperty = Binding.BindableProperty.Create("Image", typeof(PropertyMap), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;

            PropertyMap map = (PropertyMap)newValue;
            string url = "", alphaMaskURL = "", auxiliaryImageURL = "";
            string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            PropertyValue urlValue = map.Find(ImageVisualProperty.URL);
            bool ret = false;
            if (urlValue != null) ret = urlValue.Get(out url);
            PropertyMap mmap = new PropertyMap();
            if (ret && url.Contains("*Resource*"))
            {
                url = url.Replace("*Resource*", resource);
                mmap.Insert(ImageVisualProperty.URL, new PropertyValue(url));
            }

            ret = false;
            PropertyValue alphaMaskUrlValue = map.Find(ImageVisualProperty.AlphaMaskURL);
            if (alphaMaskUrlValue != null) ret = alphaMaskUrlValue.Get(out alphaMaskURL);
            if (ret && alphaMaskURL.Contains("*Resource*"))
            {
                alphaMaskURL = alphaMaskURL.Replace("*Resource*", resource);
                mmap.Insert(ImageVisualProperty.AlphaMaskURL, new PropertyValue(alphaMaskURL));
            }

            ret = false;
            PropertyValue auxiliaryImageURLValue = map.Find(ImageVisualProperty.AuxiliaryImageURL);
            if (auxiliaryImageURLValue != null) ret = auxiliaryImageURLValue.Get(out auxiliaryImageURL);
            if (ret && auxiliaryImageURL.Contains("*Resource*"))
            {
                auxiliaryImageURL = auxiliaryImageURL.Replace("*Resource*", resource);
                mmap.Insert(ImageVisualProperty.AuxiliaryImageURL, new PropertyValue(auxiliaryImageURL));
            }

            map.Merge(mmap);

            imageView.imageView.Image = (PropertyMap)map;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView.imageView.Image;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PreMultipliedAlphaProperty = Binding.BindableProperty.Create("PreMultipliedAlpha", typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            imageView.imageView.PreMultipliedAlpha = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView.imageView.PreMultipliedAlpha;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PixelAreaProperty = Binding.BindableProperty.Create("PixelArea", typeof(RelativeVector4), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            imageView.imageView.PixelArea = (RelativeVector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView.imageView.PixelArea;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty BorderProperty = Binding.BindableProperty.Create("Border", typeof(Rectangle), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            imageView.imageView.Border = (Rectangle)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView.imageView.Border;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty BorderOnlyProperty = Binding.BindableProperty.Create("BorderOnly", typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            imageView.imageView.BorderOnly = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView.imageView.BorderOnly;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SynchronosLoadingProperty = Binding.BindableProperty.Create("SynchronosLoading", typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            imageView.imageView.SynchronosLoading = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView.imageView.SynchronosLoading;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OrientationCorrectionProperty = Binding.BindableProperty.Create("OrientationCorrection", typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            imageView.imageView.OrientationCorrection = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView.imageView.OrientationCorrection;
        });

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
                imageView.ResourceReady += value;
            }

            remove
            {
                imageView.ResourceReady -= value;
            }
        }

        /// <summary>
        /// ImageView ResourceUrl, type string.
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
                return imageView.ImageMap;
            }
            set
            {
                imageView.ImageMap = value;
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
                return (PropertyMap)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
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
            }
        }

        /// <summary>
        /// Gets the loading state of the visual resource.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public LoadingStatusType LoadingStatus
        {
            get
            {
                return imageView.LoadingStatus;
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
            Tizen.NUI.BaseComponents.ImageView result = Tizen.NUI.BaseComponents.ImageView.DownCast(handle.handleInstance) as Tizen.NUI.BaseComponents.ImageView;
            return BaseHandle.GetHandle(result) as ImageView;
        }

        /// <summary>
        /// Sets this ImageView from the given URL.<br />
        /// If the URL is empty, ImageView will not display anything.<br />
        /// </summary>
        /// <param name="url">The URL to the image resource to display.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetImage(string url)
        {
            imageView.SetImage(url);
        }

        /// <summary>
        /// Queries if all resources required by a control are loaded and ready.<br />
        /// Most resources are only loaded when the control is placed on the stage.<br />
        /// True if the resources are loaded and ready, false otherwise.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new bool IsResourceReady()
        {
            return imageView.IsResourceReady();
        }

        /// <summary>
        /// Forcefully reloads the image. All the visuals using this image will reload to the latest image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Reload()
        {
            imageView.Reload();
        }

        /// <summary>
        /// Plays the animated GIF. This is also the default playback mode.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Play()
        {
            imageView.Play();
        }

        /// <summary>
        /// Pauses the animated GIF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Pause()
        {
            imageView.Pause();
        }

        /// <summary>
        /// Stops the animated GIF.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Stop()
        {
            imageView.Stop();
        }
    }
}
