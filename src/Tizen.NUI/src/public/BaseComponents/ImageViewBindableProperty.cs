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
                imageView.SetInternalResourceUrl(selector);
            }
            else
            {
                imageView.SetInternalResourceUrl((string)newValue);
            }
        }
        internal static object GetInternalResourceUrlProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalResourceUrl();
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageProperty = null;

        internal static void SetInternalImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var imageView = (ImageView)bindable;
                imageView.SetInternalImage((PropertyMap)newValue);
            }
        }
        internal static object GetInternalImageProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalImage();
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PreMultipliedAlphaProperty = null;

        internal static void SetInternalPreMultipliedAlphaProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var imageView = (ImageView)bindable;
                imageView.SetInternalPreMultipliedAlpha((bool)newValue);
            }
        }
        internal static object GetInternalPreMultipliedAlphaProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalPreMultipliedAlpha();
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelAreaProperty = null;

        internal static void SetInternalPixelAreaProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var imageView = (ImageView)bindable;
                imageView.SetInternalPixelArea((RelativeVector4)newValue);
            }
        }
        internal static object GetInternalPixelAreaProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalPixelArea();
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderProperty = null;

        internal static void SetInternalBorderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var imageView = (ImageView)bindable;
            if (newValue is Selector<Rectangle> selector)
            {
                imageView.SetInternalBorder(selector);
            }
            else
            {
                imageView.SetInternalBorder((Rectangle)newValue);
            }
        }
        internal static object GetInternalBorderProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalBorder();
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderOnlyProperty = null;

        internal static void SetInternalBorderOnlyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                if (NUIApplication.IsUsingXaml)
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
                }
                var imageView = (ImageView)bindable;
                imageView.SetInternalBorderOnly((bool)newValue);
            }
        }
        internal static object GetInternalBorderOnlyProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalBorderOnly();
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronosLoadingProperty = null;

        internal static void SetInternalSynchronosLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                if (NUIApplication.IsUsingXaml)
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
                }
                // Note : We need to create new visual if previous visual was async, and now we set value as sync.
                var imageView = (ImageView)bindable;
                imageView.SetInternalSynchronousLoading((bool)newValue);
            }
        }
        internal static object GetInternalSynchronosLoadingProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalSynchronousLoading();
        }

        /// This will be public opened in tizen_7.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SynchronousLoadingProperty = null;

        internal static void SetInternalSynchronousLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                if (NUIApplication.IsUsingXaml)
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
                }
                // Note : We need to create new visual if previous visual was async, and now we set value as sync.
                var imageView = (ImageView)bindable;
                imageView.SetInternalSynchronousLoading((bool)newValue);
            }
        }
        internal static object GetInternalSynchronousLoadingProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalSynchronousLoading();
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationCorrectionProperty = null;

        internal static void SetInternalOrientationCorrectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                if (NUIApplication.IsUsingXaml)
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
                }
                var imageView = (ImageView)bindable;
                imageView.SetInternalOrientationCorrection((bool)newValue);
            }
        }
        internal static object GetInternalOrientationCorrectionProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalOrientationCorrection();
        }

        /// <summary>
        /// MaskingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaskingModeProperty = null;

        internal static void SetInternalMaskingModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalMaskingMode = (MaskingModeType)newValue;
            }
        }
        internal static object GetInternalMaskingModeProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalMaskingMode;
        }

        /// <summary>
        /// FastTrackUploadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FastTrackUploadingProperty = null;

        internal static void SetInternalFastTrackUploadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalFastTrackUploading = (bool)newValue;
            }
        }
        internal static object GetInternalFastTrackUploadingProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalFastTrackUploading;
        }

        /// <summary>
        /// ImageMapProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageMapProperty = null;

        internal static void SetInternalImageMapProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalImageMap = (PropertyMap)newValue;
            }
        }
        internal static object GetInternalImageMapProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalImageMap;
        }

        /// <summary>
        /// AlphaMaskURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlphaMaskURLProperty = null;

        internal static void SetInternalAlphaMaskURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalAlphaMaskURL = (string)newValue;
            }
        }

        internal static object GetInternalAlphaMaskURLProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalAlphaMaskURL;
        }

        /// <summary>
        /// CropToMaskProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CropToMaskProperty = null;

        internal static void SetInternalCropToMaskProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalCropToMask = (bool)newValue;
            }
        }
        internal static object GetInternalCropToMaskProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalCropToMask;
        }

        /// <summary>
        /// FittingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FittingModeProperty = null;

        internal static void SetInternalFittingModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalFittingMode = (FittingModeType)newValue;
            }
        }

        internal static object GetInternalFittingModeProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalFittingMode;
        }

        /// <summary>
        /// DesiredWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DesiredWidthProperty = null;

        internal static void SetInternalDesiredWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalDesiredWidth = (int)newValue;
            }
        }
        internal static object GetInternalDesiredWidthProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalDesiredWidth;
        }

        /// <summary>
        /// DesiredHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DesiredHeightProperty = null;

        internal static void SetInternalDesiredHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalDesiredHeight = (int)newValue;
            }
        }
        internal static object GetInternalDesiredHeightProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalDesiredHeight;
        }

        /// <summary>
        /// ReleasePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ReleasePolicyProperty = null;

        internal static void SetInternalReleasePolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalReleasePolicy = (ReleasePolicyType)newValue;
            }
        }
        internal static object GetInternalReleasePolicyProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalReleasePolicy;
        }

        /// <summary>
        /// WrapModeUProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapModeUProperty = null;

        internal static void SetInternalWrapModeUProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalWrapModeU = (WrapModeType)newValue;
            }
        }
        internal static object GetInternalWrapModeUProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalWrapModeU;
        }

        /// <summary>
        /// WrapModeVProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapModeVProperty = null;

        internal static void SetInternalWrapModeVProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalWrapModeV = (WrapModeType)newValue;
            }
        }
        internal static object GetInternalWrapModeVProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalWrapModeV;
        }

        /// <summary>
        /// AdjustViewSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AdjustViewSizeProperty = null;

        internal static void SetInternalAdjustViewSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.adjustViewSize = (bool)newValue;
            }
        }
        internal static object GetInternalAdjustViewSizeProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.adjustViewSize;
        }

        /// <summary>
        /// PlaceHolderUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceHolderUrlProperty = null;

        internal static void SetInternalPlaceHolderUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var imageView = (ImageView)bindable;
                imageView.SetInternalPlaceHolderUrl((string)newValue);
            }
        }
        internal static object GetInternalPlaceHolderUrlProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalPlaceHolderUrl();
        }

        /// Intenal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionEffectProperty = null;

        internal static void SetInternalTransitionEffectProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var imageView = (ImageView)bindable;
                imageView.SetInternalTransitionEffect((bool)newValue);
            }
        }
        internal static object GetInternalTransitionEffectProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalTransitionEffect();
        }

        /// <summary>
        /// ImageColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageColorProperty = null;

        internal static void SetInternalImageColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var imageView = (ImageView)bindable;
                imageView.SetInternalImageColor((Color)newValue);
            }
        }
        internal static object GetInternalImageColorProperty(BindableObject bindable)
        {
            var imageView = (ImageView)bindable;
            return imageView.GetInternalImageColor();
        }

        /// <summary>
        /// TransitionEffectOptionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionEffectOptionProperty = null;

        internal static void SetInternalTransitionEffectOptionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ImageView)bindable;
                instance.InternalTransitionEffectOption = (PropertyMap)newValue;
            }
        }
        internal static object GetInternalTransitionEffectOptionProperty(BindableObject bindable)
        {
            var instance = (ImageView)bindable;
            return instance.InternalTransitionEffectOption;
        }
    }
}
