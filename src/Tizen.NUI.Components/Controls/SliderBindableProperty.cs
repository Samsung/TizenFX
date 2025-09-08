/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Slider
    {
        /// <summary>
        /// SpaceBetweenTrackAndIndicatorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorProperty = null;
        internal static void SetInternalIndicatorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.privateIndicatorType = (IndicatorType)newValue;
            }
        }
        internal static object GetInternalIndicatorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.privateIndicatorType;
        }

        /// <summary>
        /// SpaceBetweenTrackAndIndicatorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceBetweenTrackAndIndicatorProperty = null;
        internal static void SetInternalSpaceBetweenTrackAndIndicatorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.privateSpaceBetweenTrackAndIndicator = (uint)newValue;
            }
        }
        internal static object GetInternalSpaceBetweenTrackAndIndicatorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.privateSpaceBetweenTrackAndIndicator;
        }

        /// <summary>
        /// TrackThicknessProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackThicknessProperty = null;
        internal static void SetInternalTrackThicknessProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.privateTrackThickness = (uint)newValue;
            }
        }
        internal static object GetInternalTrackThicknessProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.privateTrackThickness;
        }

        /// <summary>
        /// IsValueShownProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsValueShownProperty = null;
        internal static void SetInternalIsValueShownProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.SetInternalIsValueShown((bool)newValue);
            }
        }
        internal static object GetInternalIsValueShownProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.GetInternalIsValueShown();
        }

        /// <summary>
        /// ValueIndicatorTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValueIndicatorTextProperty = null;
        internal static void SetInternalValueIndicatorTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.valueIndicatorText.Text = (string)newValue;
            }
        }
        internal static object GetInternalValueIndicatorTextProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.valueIndicatorText.Text;
        }

        /// <summary>
        /// Bindable property of CurrentValue
        /// <remark>
        /// Hidden API, used for NUI XAML data binding
        /// </remark>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = null;
        internal static void SetInternalCurrentValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.SetInternalCurrentValue((float)newValue);
            }
        }
        internal static object GetInternalCurrentValueProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.GetInternalCurrentValue();
        }

        /// <summary>
        /// DirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DirectionProperty = null;
        internal static void SetInternalDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalDirection = (DirectionType)newValue;
            }
        }
        internal static object GetInternalDirectionProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalDirection;
        }

        /// <summary>
        /// MinValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = null;
        internal static void SetInternalMinValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalMinValue = (float)newValue;
            }
        }
        internal static object GetInternalMinValueProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalMinValue;
        }

        /// <summary>
        /// MaxValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = null;
        internal static void SetInternalMaxValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalMaxValue = (float)newValue;
            }
        }
        internal static object GetInternalMaxValueProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalMaxValue;
        }

        /// <summary>
        /// ThumbSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbSizeProperty = null;
        internal static void SetInternalThumbSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalThumbSize = newValue as Size;
            }
        }
        internal static object GetInternalThumbSizeProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbSize;
        }

        /// <summary>
        /// ThumbImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbImageURLProperty = null;
        internal static void SetInternalThumbImageURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalThumbImageURL = newValue as string;
            }
        }
        internal static object GetInternalThumbImageURLProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbImageURL;
        }

        /// <summary>
        /// ThumbImageURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbImageURLSelectorProperty = null;
        internal static void SetInternalThumbImageURLSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Slider)bindable;
            //NOTE: null value is allowed here.
            instance.InternalThumbImageURLSelector = newValue as StringSelector;
        }
        internal static object GetInternalThumbImageURLSelectorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbImageURLSelector;
        }

        /// <summary>
        /// ThumbImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbImageUrlProperty = null;
        internal static void SetInternalThumbImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalThumbImageUrl = newValue as Tizen.NUI.BaseComponents.Selector<string>;
            }
        }
        internal static object GetInternalThumbImageUrlProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbImageUrl;
        }

        /// <summary>
        /// ThumbColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = null;
        internal static void SetInternalThumbColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalThumbColor = newValue as Color;
            }
        }
        internal static object GetInternalThumbColorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalThumbColor;
        }

        /// <summary>
        /// BgTrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BgTrackColorProperty = null;
        internal static void SetInternalBgTrackColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalBgTrackColor = newValue as Color;
            }
        }
        internal static object GetInternalBgTrackColorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalBgTrackColor;
        }

        /// <summary>
        /// SlidedTrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SlidedTrackColorProperty = null;
        internal static void SetInternalSlidedTrackColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalSlidedTrackColor = newValue as Color;
            }
        }
        internal static object GetInternalSlidedTrackColorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalSlidedTrackColor;
        }

        /// <summary>
        /// WarningStartValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningStartValueProperty = null;
        internal static void SetInternalWarningStartValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalWarningStartValue = (float)newValue;
            }
        }
        internal static object GetInternalWarningStartValueProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningStartValue;
        }

        /// <summary>
        /// WarningTrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningTrackColorProperty = null;
        internal static void SetInternalWarningTrackColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalWarningTrackColor = newValue as Color;
            }
        }
        internal static object GetInternalWarningTrackColorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningTrackColor;
        }

        /// <summary>
        /// WarningSlidedTrackColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningSlidedTrackColorProperty = null;
        internal static void SetInternalWarningSlidedTrackColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalWarningSlidedTrackColor = newValue as Color;
            }
        }
        internal static object GetInternalWarningSlidedTrackColorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningSlidedTrackColor;
        }

        /// <summary>
        /// WarningThumbImageUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningThumbImageUrlProperty = null;
        internal static void SetInternalWarningThumbImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalWarningThumbImageUrl = newValue as Tizen.NUI.BaseComponents.Selector<string>;
            }
        }
        internal static object GetInternalWarningThumbImageUrlProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningThumbImageUrl;
        }

        /// <summary>
        /// WarningThumbColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WarningThumbColorProperty = null;
        internal static void SetInternalWarningThumbColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalWarningThumbColor = newValue as Color;
            }
        }
        internal static object GetInternalWarningThumbColorProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalWarningThumbColor;
        }

        /// <summary>
        /// LowIndicatorImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LowIndicatorImageURLProperty = null;
        internal static void SetInternalLowIndicatorImageURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalLowIndicatorImageURL = newValue as string;
            }
        }
        internal static object GetInternalLowIndicatorImageURLProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalLowIndicatorImageURL;
        }

        /// <summary>
        /// HighIndicatorImageURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HighIndicatorImageURLProperty = null;
        internal static void SetInternalHighIndicatorImageURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalHighIndicatorImageURL = newValue as string;
            }
        }
        internal static object GetInternalHighIndicatorImageURLProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalHighIndicatorImageURL;
        }

        /// <summary>
        /// LowIndicatorTextContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LowIndicatorTextContentProperty = null;
        internal static void SetInternalLowIndicatorTextContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalLowIndicatorTextContent = newValue as string;
            }
        }
        internal static object GetInternalLowIndicatorTextContentProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalLowIndicatorTextContent;
        }

        /// <summary>
        /// HighIndicatorTextContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HighIndicatorTextContentProperty = null;
        internal static void SetInternalHighIndicatorTextContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalHighIndicatorTextContent = newValue as string;
            }
        }
        internal static object GetInternalHighIndicatorTextContentProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalHighIndicatorTextContent;
        }

        /// <summary>
        /// LowIndicatorSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LowIndicatorSizeProperty = null;
        internal static void SetInternalLowIndicatorSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue as Size is var nVal && nVal != null)
            {
                var instance = (Slider)bindable;
                instance.InternalLowIndicatorSize = nVal;
            }
        }
        internal static object GetInternalLowIndicatorSizeProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalLowIndicatorSize;
        }

        /// <summary>
        /// HighIndicatorSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HighIndicatorSizeProperty = null;
        internal static void SetInternalHighIndicatorSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue as Size is var nVal && nVal != null)
            {
                var instance = (Slider)bindable;
                instance.InternalHighIndicatorSize = nVal;
            }
        }
        internal static object GetInternalHighIndicatorSizeProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalHighIndicatorSize;
        }

        /// <summary>
        /// ValueIndicatorSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValueIndicatorSizeProperty = null;
        internal static void SetInternalValueIndicatorSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue as Size is var nVal && nVal != null)
            {
                var instance = (Slider)bindable;
                instance.InternalValueIndicatorSize = nVal;
            }
        }
        internal static object GetInternalValueIndicatorSizeProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalValueIndicatorSize;
        }

        /// <summary>
        /// ValueIndicatorUrlProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValueIndicatorUrlProperty = null;
        internal static void SetInternalValueIndicatorUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalValueIndicatorUrl = newValue as string;
            }
        }
        internal static object GetInternalValueIndicatorUrlProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalValueIndicatorUrl;
        }

        /// <summary>
        /// IsDiscreteProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsDiscreteProperty = null;
        internal static void SetInternalIsDiscreteProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalIsDiscrete = (bool)newValue;
            }
        }
        internal static object GetInternalIsDiscreteProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalIsDiscrete;
        }

        /// <summary>
        /// DiscreteValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DiscreteValueProperty = null;
        internal static void SetInternalDiscreteValueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Slider)bindable;
                instance.InternalDiscreteValue = (float)newValue;
            }
        }
        internal static object GetInternalDiscreteValueProperty(BindableObject bindable)
        {
            var instance = (Slider)bindable;
            return instance.InternalDiscreteValue;
        }
    }
}
