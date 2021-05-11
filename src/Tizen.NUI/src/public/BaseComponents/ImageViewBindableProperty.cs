/*
 * Copyright(c) 2019-2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    public partial class ImageView
    {
        /// <summary>
        /// ImageMapProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BindableProperty ImageMapProperty { get; } = BindableProperty.Create(nameof(ImageMap), typeof(Tizen.NUI.PropertyMap), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static BindableProperty AlphaMaskURLProperty { get; } = BindableProperty.Create(nameof(AlphaMaskURL), typeof(string), typeof(Tizen.NUI.BaseComponents.ImageView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static BindableProperty CropToMaskProperty { get; } = BindableProperty.Create(nameof(CropToMask), typeof(bool), typeof(Tizen.NUI.BaseComponents.ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static BindableProperty FittingModeProperty { get; } = BindableProperty.Create(nameof(FittingMode), typeof(Tizen.NUI.FittingModeType), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static BindableProperty DesiredWidthProperty { get; } = BindableProperty.Create(nameof(DesiredWidth), typeof(int), typeof(Tizen.NUI.BaseComponents.ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static BindableProperty DesiredHeightProperty { get; } = BindableProperty.Create(nameof(DesiredHeight), typeof(int), typeof(Tizen.NUI.BaseComponents.ImageView), 0, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static BindableProperty ReleasePolicyProperty { get; } = BindableProperty.Create(nameof(ReleasePolicy), typeof(Tizen.NUI.ReleasePolicyType), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static BindableProperty WrapModeUProperty { get; } = BindableProperty.Create(nameof(WrapModeU), typeof(Tizen.NUI.WrapModeType), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static BindableProperty WrapModeVProperty { get; } = BindableProperty.Create(nameof(WrapModeV), typeof(Tizen.NUI.WrapModeType), typeof(Tizen.NUI.BaseComponents.ImageView), null, propertyChanged: (bindable, oldValue, newValue) =>
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

    }
}
