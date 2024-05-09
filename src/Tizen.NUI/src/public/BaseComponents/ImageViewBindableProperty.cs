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
        public static readonly BindableProperty ResourceUrlProperty = null;

        internal static void SetInternalResourceUrlProperty(BindableObject bindable, object oldValue, object newValue)
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
        }

        internal static object GetInternalResourceUrlProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;

            return imageView?._resourceUrl ?? "";
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageProperty = null;

        internal static void SetInternalImageProperty(BindableObject bindable, object oldValue, object newValue)
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
        }

        internal static object GetInternalImageProperty(BindableObject bindable)
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
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PreMultipliedAlphaProperty = null;

        internal static void SetInternalPreMultipliedAlphaProperty(BindableObject bindable, object oldValue, object newValue)
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
        }

        internal static object GetInternalPreMultipliedAlphaProperty(BindableObject bindable)
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
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelAreaProperty = null;

        internal static void SetInternalPixelAreaProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(imageView.SwigCPtr, ImageView.Property.PixelArea, ((RelativeVector4)newValue).SwigCPtr);
            }
        }

        internal static object GetInternalPixelAreaProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;

            if (imageView.internalPixelArea == null)
            {
                imageView.internalPixelArea = new RelativeVector4(imageView.OnPixelAreaChanged, 0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(imageView.SwigCPtr, ImageView.Property.PixelArea, imageView.internalPixelArea.SwigCPtr);
            return imageView.internalPixelArea;
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderProperty = null;

        internal static void SetInternalBorderProperty(BindableObject bindable, object oldValue, object newValue)
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
        }

        internal static object GetInternalBorderProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView._border;
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderOnlyProperty = null;

        internal static void SetInternalBorderOnlyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                if (oldValue != null)
                {
                    bool oldBool = (bool)oldValue;
                    bool newBool = (bool)newValue;
                    if (oldBool == newBool)
                    {
                        return;
                    }
                }
                imageView.UpdateImage(NpatchImageVisualProperty.BorderOnly, new PropertyValue((bool)newValue));
            }
        }

        internal static object GetInternalBorderOnlyProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            bool ret = false;

            imageView.GetCachedImageVisualProperty(NpatchImageVisualProperty.BorderOnly)?.Get(out ret);

            return ret;
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronosLoadingProperty = null;

        internal static void SetInternalSynchronosLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                if (oldValue != null)
                {
                    bool oldBool = (bool)oldValue;
                    bool newBool = (bool)newValue;
                    if (oldBool == newBool)
                    {
                        return;
                    }
                }
                // Note : We need to create new visual if previous visual was async, and now we set value as sync.
                imageView.UpdateImage(ImageVisualProperty.SynchronousLoading, new PropertyValue((bool)newValue), (bool)newValue);
            }
        }

        internal static object GetInternalSynchronosLoadingProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            bool ret = false;

            imageView.GetCachedImageVisualProperty(ImageVisualProperty.SynchronousLoading)?.Get(out ret);

            return ret;
        }

        /// This will be public opened in tizen_7.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronousLoadingProperty = null;

        internal static void SetInternalSynchronousLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                if (oldValue != null)
                {
                    bool oldBool = (bool)oldValue;
                    bool newBool = (bool)newValue;
                    if (oldBool == newBool)
                    {
                        return;
                    }
                }
                // Note : We need to create new visual if previous visual was async, and now we set value as sync.
                imageView.UpdateImage(ImageVisualProperty.SynchronousLoading, new PropertyValue((bool)newValue), (bool)newValue);
            }
        }

        internal static object GetInternalSynchronousLoadingProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            bool ret = false;

            imageView.GetCachedImageVisualProperty(ImageVisualProperty.SynchronousLoading)?.Get(out ret);

            return ret;
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationCorrectionProperty = null;

        internal static void SetInternalOrientationCorrectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                if (oldValue != null)
                {
                    bool oldBool = (bool)oldValue;
                    bool newBool = (bool)newValue;
                    if (oldBool == newBool)
                    {
                        return;
                    }
                }
                imageView.UpdateImage(ImageVisualProperty.OrientationCorrection, new PropertyValue((bool)newValue));
            }
        }

        internal static object GetInternalOrientationCorrectionProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;

            bool ret = false;

            imageView.GetCachedImageVisualProperty(ImageVisualProperty.OrientationCorrection)?.Get(out ret);

            return ret;
        }

        /// <summary>
        /// MaskingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaskingModeProperty = null;

        internal static void SetInternalMaskingModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalMaskingMode = (ImageView.MaskingModeType)newValue;
            }
        }

        internal static object GetInternalMaskingModeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalMaskingMode;
        }

        /// <summary>
        /// FastTrackUploadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FastTrackUploadingProperty = null;

        internal static void SetInternalFastTrackUploadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalFastTrackUploading = (bool)newValue;
            }
        }

        internal static object GetInternalFastTrackUploadingProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalFastTrackUploading;
        }

        /// <summary>
        /// ImageMapProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageMapProperty = null;

        internal static void SetInternalImageMapProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalImageMap = (Tizen.NUI.PropertyMap)newValue;
            }
        }

        internal static object GetInternalImageMapProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalImageMap;
        }

        /// <summary>
        /// AlphaMaskURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlphaMaskURLProperty = null;

        internal static void SetInternalAlphaMaskURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalAlphaMaskURL = (string)newValue;
            }
        }
        
        internal static object GetInternalAlphaMaskURLProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalAlphaMaskURL;
        }

        /// <summary>
        /// CropToMaskProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CropToMaskProperty = null;

        internal static void SetInternalCropToMaskProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalCropToMask = (bool)newValue;
            }
        }
        
        internal static object GetInternalCropToMaskProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalCropToMask;
        }

        /// <summary>
        /// FittingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FittingModeProperty = null;
        
        internal static void SetInternalFittingModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalFittingMode = (Tizen.NUI.FittingModeType)newValue;
            }
        }
        
        internal static object GetInternalFittingModeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalFittingMode;
        }

        /// <summary>
        /// DesiredWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DesiredWidthProperty = null;

        internal static void SetInternalDesiredWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalDesiredWidth = (int)newValue;
            }
        }
        
        internal static object GetInternalDesiredWidthProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalDesiredWidth;
        }

        /// <summary>
        /// DesiredHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DesiredHeightProperty = null;

        internal static void SetInternalDesiredHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalDesiredHeight = (int)newValue;
            }
        }
        
        internal static object GetInternalDesiredHeightProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalDesiredHeight;
        }

        /// <summary>
        /// ReleasePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ReleasePolicyProperty = null;

        internal static void SetInternalReleasePolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalReleasePolicy = (Tizen.NUI.ReleasePolicyType)newValue;
            }
        }
        
        internal static object GetInternalReleasePolicyProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalReleasePolicy;
        }

        /// <summary>
        /// WrapModeUProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapModeUProperty = null;

        internal static void SetInternalWrapModeUProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalWrapModeU = (Tizen.NUI.WrapModeType)newValue;
            }
        }
        
        internal static object GetInternalWrapModeUProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalWrapModeU;
        }

        /// <summary>
        /// WrapModeVProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapModeVProperty = null;

        internal static void SetInternalWrapModeVProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalWrapModeV = (Tizen.NUI.WrapModeType)newValue;
            }
        }
        
        internal static object GetInternalWrapModeVProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalWrapModeV;
        }

        /// <summary>
        /// AdjustViewSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AdjustViewSizeProperty = null;

        internal static void SetInternalAdjustViewSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.adjustViewSize = (bool)newValue;
            }
        }
        
        internal static object GetInternalAdjustViewSizeProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.adjustViewSize;
        }

        /// <summary>
        /// PlaceHolderUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceHolderUrlProperty = null;

        internal static void SetInternalPlaceHolderUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyString(imageView.SwigCPtr, ImageView.Property.PlaceHolderUrl, (string)newValue);
            }
        }

        internal static object GetInternalPlaceHolderUrlProperty(BindableObject bindable)
        {
            var imageView = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return Object.InternalGetPropertyString(imageView.SwigCPtr, ImageView.Property.PlaceHolderUrl);
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionEffectProperty = null;

        internal static void SetInternalTransitionEffectProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(imageView.SwigCPtr, ImageView.Property.TransitionEffect, (bool)newValue);
            }
        }

        internal static object GetInternalTransitionEffectProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return Object.InternalGetPropertyBool(imageView.SwigCPtr, ImageView.Property.TransitionEffect);
        }

        /// <summary>
        /// ImageColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageColorProperty = null;

        internal static void SetInternalImageColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (ImageView)bindable;
            if (newValue != null)
            {
                imageView.UpdateImage(Visual.Property.Opacity, new PropertyValue(((Color)newValue).A), false);
                imageView.UpdateImage(Visual.Property.MixColor, new PropertyValue((Color)newValue), false);

                // Update property
                Interop.View.InternalUpdateVisualPropertyVector4(imageView.SwigCPtr, ImageView.Property.IMAGE, Visual.Property.MixColor, Vector4.getCPtr((Color)newValue));
            }
        }
        
        internal static object GetInternalImageColorProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            Color ret = new Color();

            imageView.GetCachedImageVisualProperty(Visual.Property.MixColor)?.Get(ret);

            return ret;
        }

        /// <summary>
        /// TransitionEffectOptionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionEffectOptionProperty = null;

        internal static void SetInternalTransitionEffectOptionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            if (newValue != null)
            {
                instance.InternalTransitionEffectOption = (Tizen.NUI.PropertyMap)newValue;
            }
        }

        internal static object GetInternalTransitionEffectOptionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.ImageView)bindable;
            return instance.InternalTransitionEffectOption;
        }
    }
}
