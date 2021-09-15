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

using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    public partial class ImageView
    {
        /// Intenal used, will never be opened.
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

        /// Intenal used, will never be opened.
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

        /// Intenal used, will never be opened.
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

        /// Intenal used, will never be opened.
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

        /// Intenal used, will never be opened.
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

        /// Intenal used, will never be opened.
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

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronosLoadingProperty = BindableProperty.Create(nameof(SynchronousLoading), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView._synchronousLoading = (bool)newValue;
                imageView.UpdateImage(NpatchImageVisualProperty.SynchronousLoading, new PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView._synchronousLoading;
        });

        /// This will be public opened in tizen_7.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronousLoadingProperty = BindableProperty.Create(nameof(SynchronousLoading), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView._synchronousLoading = (bool)newValue;
                imageView.UpdateImage(NpatchImageVisualProperty.SynchronousLoading, new PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            return imageView._synchronousLoading;
        });

        /// Intenal used, will never be opened.
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

        /// <summary>
        /// ImageMapProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageMapProperty = BindableProperty.Create(nameof(ImageMap), typeof(Tizen.NUI.PropertyMap), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalImageMap = (Tizen.NUI.PropertyMap)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalImageMap;
        });

        /// <summary>
        /// AlphaMaskURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlphaMaskURLProperty = BindableProperty.Create(nameof(AlphaMaskURL), typeof(string), typeof(Tizen.NUI.BaseComponents.ImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalAlphaMaskURL = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalAlphaMaskURL;
        });

        /// <summary>
        /// CropToMaskProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CropToMaskProperty = BindableProperty.Create(nameof(CropToMask), typeof(bool), typeof(Tizen.NUI.BaseComponents.ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCropToMask = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalCropToMask;
        });

        /// <summary>
        /// FittingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FittingModeProperty = BindableProperty.Create(nameof(FittingMode), typeof(Tizen.NUI.FittingModeType), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalFittingMode = (Tizen.NUI.FittingModeType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalFittingMode;
        });

        /// <summary>
        /// DesiredWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DesiredWidthProperty = BindableProperty.Create(nameof(DesiredWidth), typeof(int), typeof(Tizen.NUI.BaseComponents.ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalDesiredWidth = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalDesiredWidth;
        });

        /// <summary>
        /// DesiredHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DesiredHeightProperty = BindableProperty.Create(nameof(DesiredHeight), typeof(int), typeof(Tizen.NUI.BaseComponents.ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalDesiredHeight = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalDesiredHeight;
        });

        /// <summary>
        /// ReleasePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ReleasePolicyProperty = BindableProperty.Create(nameof(ReleasePolicy), typeof(Tizen.NUI.ReleasePolicyType), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalReleasePolicy = (Tizen.NUI.ReleasePolicyType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalReleasePolicy;
        });

        /// <summary>
        /// WrapModeUProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapModeUProperty = BindableProperty.Create(nameof(WrapModeU), typeof(Tizen.NUI.WrapModeType), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalWrapModeU = (Tizen.NUI.WrapModeType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalWrapModeU;
        });

        /// <summary>
        /// WrapModeVProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapModeVProperty = BindableProperty.Create(nameof(WrapModeV), typeof(Tizen.NUI.WrapModeType), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalWrapModeV = (Tizen.NUI.WrapModeType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalWrapModeV;
        });

        /// <summary>
        /// AdjustViewSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AdjustViewSizeProperty = BindableProperty.Create(nameof(AdjustViewSize), typeof(bool), typeof(Tizen.NUI.BaseComponents.ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.adjustViewSize = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.adjustViewSize;
        });
    }
}
