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

            return imageView?._resourceUrl ?? "";
        }),
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

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
                        mmap.Insert(NDalic.ImageVisualAlphaMaskUrl, new PropertyValue(alphaMaskURL));
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
                    imageView.SetImageByPropertyMap(map);
                }
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;
            if (imageView._border == null)
            {
                // Sync as current properties
                imageView.UpdateImage();

                // Get current properties force.
                PropertyMap returnValue = new PropertyMap();
                Tizen.NUI.Object.GetProperty((HandleRef)imageView.SwigCPtr, ImageView.Property.IMAGE).Get(returnValue);

                // Update cached property map
                if (returnValue != null)
                {
                    imageView.MergeCachedImageVisualProperty(returnValue);
                }
                return returnValue;
            }
            else
            {
                return null;
            }
        }),
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PreMultipliedAlphaProperty = BindableProperty.Create(nameof(PreMultipliedAlpha), typeof(bool), typeof(ImageView), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                if (imageView.imagePropertyUpdatedFlag)
                {
                    // If imageView Property still not send to the dali, Append cached property.
                    imageView.UpdateImage(Visual.Property.PremultipliedAlpha, new PropertyValue((bool)newValue));
                }
                else
                {
                    // Else, we don't need to re-create view. Get value from current ImageView.
                    Object.InternalSetPropertyBool(imageView.SwigCPtr, ImageView.Property.PreMultipliedAlpha, (bool)newValue);
                }
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;
            bool temp = false;

            if (imageView.imagePropertyUpdatedFlag)
            {
                // If imageView Property still not send to the dali, just get cached property.
                imageView.GetCachedImageVisualProperty(Visual.Property.PremultipliedAlpha)?.Get(out temp);
            }
            else
            {
                // Else, PremultipliedAlpha may not setuped in cached property. Get value from current ImageView.
                temp = Object.InternalGetPropertyBool(imageView.SwigCPtr, ImageView.Property.PreMultipliedAlpha);
            }
            return temp;
        }),
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelAreaProperty = BindableProperty.Create(nameof(PixelArea), typeof(RelativeVector4), typeof(ImageView), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(imageView.SwigCPtr, ImageView.Property.PixelArea, ((RelativeVector4)newValue).SwigCPtr);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;

            if (imageView.internalPixelArea == null)
            {
                imageView.internalPixelArea = new RelativeVector4(imageView.OnPixelAreaChanged, 0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(imageView.SwigCPtr, ImageView.Property.PixelArea, imageView.internalPixelArea.SwigCPtr);
            return imageView.internalPixelArea;
        }),
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

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

            imageView.GetCachedImageVisualProperty(NpatchImageVisualProperty.BorderOnly)?.Get(out ret);

            return ret;
        }),
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronosLoadingProperty = BindableProperty.Create(nameof(SynchronousLoading), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                // Note : We need to create new visual if previous visual was async, and now we set value as sync.
                imageView.UpdateImage(ImageVisualProperty.SynchronousLoading, new PropertyValue((bool)newValue), (bool)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            bool ret = false;

            imageView.GetCachedImageVisualProperty(ImageVisualProperty.SynchronousLoading)?.Get(out ret);

            return ret;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// This will be public opened in tizen_7.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronousLoadingProperty = BindableProperty.Create(nameof(SynchronousLoading), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                // Note : We need to create new visual if previous visual was async, and now we set value as sync.
                imageView.UpdateImage(ImageVisualProperty.SynchronousLoading, new PropertyValue((bool)newValue), (bool)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            bool ret = false;

            imageView.GetCachedImageVisualProperty(ImageVisualProperty.SynchronousLoading)?.Get(out ret);

            return ret;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

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

            imageView.GetCachedImageVisualProperty(ImageVisualProperty.OrientationCorrection)?.Get(out ret);

            return ret;
        }),
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// MaskingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaskingModeProperty = BindableProperty.Create(nameof(MaskingMode), typeof(MaskingModeType), typeof(ImageView), default(MaskingModeType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalMaskingMode = (ImageView.MaskingModeType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalMaskingMode;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// FastTrackUploadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FastTrackUploadingProperty = BindableProperty.Create(nameof(FastTrackUploading), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalFastTrackUploading = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalFastTrackUploading;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// ImageMapProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageMapProperty = BindableProperty.Create(nameof(ImageMap), typeof(Tizen.NUI.PropertyMap), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// AlphaMaskURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlphaMaskURLProperty = BindableProperty.Create(nameof(AlphaMaskURL), typeof(string), typeof(ImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// CropToMaskProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CropToMaskProperty = BindableProperty.Create(nameof(CropToMask), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// FittingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FittingModeProperty = BindableProperty.Create(nameof(FittingMode), typeof(FittingModeType), typeof(ImageView), default(FittingModeType), propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// DesiredWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DesiredWidthProperty = BindableProperty.Create(nameof(DesiredWidth), typeof(int), typeof(ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// DesiredHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DesiredHeightProperty = BindableProperty.Create(nameof(DesiredHeight), typeof(int), typeof(ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// ReleasePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ReleasePolicyProperty = BindableProperty.Create(nameof(ReleasePolicy), typeof(ReleasePolicyType), typeof(ImageView), default(ReleasePolicyType), propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// WrapModeUProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapModeUProperty = BindableProperty.Create(nameof(WrapModeU), typeof(Tizen.NUI.WrapModeType), typeof(ImageView), default(WrapModeType), propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// WrapModeVProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapModeVProperty = BindableProperty.Create(nameof(WrapModeV), typeof(Tizen.NUI.WrapModeType), typeof(ImageView), default(WrapModeType), propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// AdjustViewSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AdjustViewSizeProperty = BindableProperty.Create(nameof(AdjustViewSize), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// PlaceHolderUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceHolderUrlProperty = BindableProperty.Create(nameof(PlaceHolderUrl), typeof(string), typeof(ImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyString(imageView.SwigCPtr, ImageView.Property.PlaceHolderUrl, (string)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return Object.InternalGetPropertyString(imageView.SwigCPtr, ImageView.Property.PlaceHolderUrl);
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionEffectProperty = BindableProperty.Create(nameof(TransitionEffect), typeof(bool), typeof(ImageView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(imageView.SwigCPtr, ImageView.Property.TransitionEffect, (bool)newValue);
            }
        },
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var imageView = (ImageView)bindable;
            return Object.InternalGetPropertyBool(imageView.SwigCPtr, ImageView.Property.TransitionEffect);
        }),
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);

        /// <summary>
        /// ImageColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageColorProperty = BindableProperty.Create(nameof(ImageColor), typeof(Color), typeof(ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView.UpdateImage(Visual.Property.Opacity, new PropertyValue(((Color)newValue).A), false);
                imageView.UpdateImage(Visual.Property.MixColor, new PropertyValue((Color)newValue), false);

                // Update property
                Interop.View.InternalUpdateVisualPropertyVector4(imageView.SwigCPtr, ImageView.Property.IMAGE, Visual.Property.MixColor, Vector4.getCPtr((Color)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var imageView = (ImageView)bindable;
            Color ret = new Color();

            imageView.GetCachedImageVisualProperty(Visual.Property.MixColor)?.Get(ret);

            return ret;
        },
        valuePolicy : ValuePolicy.IgnoreOldValueWhenSetValue);
    }
}
