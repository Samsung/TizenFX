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
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// SliderAttributes is a class which saves Slider's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SliderAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a SliderAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SliderAttributes() : base()
        {
            IndicatorType = Slider.IndicatorType.None;
        }

        /// <summary>
        /// Creates a new instance of a SliderAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create SliderAttributes by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SliderAttributes(SliderAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.BackgroundTrackAttributes != null)
            {
                BackgroundTrackAttributes = attributes.BackgroundTrackAttributes.Clone() as ImageAttributes;
            }
            if (attributes.SlidedTrackAttributes != null)
            {
                SlidedTrackAttributes = attributes.SlidedTrackAttributes.Clone() as ImageAttributes;
            }
            if (attributes.ThumbBackgroundAttributes != null)
            {
                ThumbBackgroundAttributes = attributes.ThumbBackgroundAttributes.Clone() as ImageAttributes;
            }
            if (attributes.ThumbAttributes != null)
            {
                ThumbAttributes = attributes.ThumbAttributes.Clone() as ImageAttributes;
            }
            if (attributes.LowIndicatorImageAttributes != null)
            {
                LowIndicatorImageAttributes = attributes.LowIndicatorImageAttributes.Clone() as ImageAttributes;
            }
            if (attributes.HighIndicatorImageAttributes != null)
            {
                HighIndicatorImageAttributes = attributes.HighIndicatorImageAttributes.Clone() as ImageAttributes;
            }
            if (attributes.LowIndicatorTextAttributes != null)
            {
                LowIndicatorTextAttributes = attributes.LowIndicatorTextAttributes.Clone() as TextAttributes;
            }
            if (attributes.HighIndicatorTextAttributes != null)
            {
                HighIndicatorTextAttributes = attributes.HighIndicatorTextAttributes.Clone() as TextAttributes;
            }
            if (attributes.TrackThickness != null)
            {
                TrackThickness = attributes.TrackThickness;
            }
            if (attributes.SpaceBetweenTrackAndIndicator != null)
            {
                SpaceBetweenTrackAndIndicator = attributes.SpaceBetweenTrackAndIndicator;
            }
            IndicatorType = attributes.IndicatorType;
        }

        /// <summary>
        /// Get or set background track attributes
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes BackgroundTrackAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set slided track attributes
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes SlidedTrackAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set thumb attributes
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ThumbAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set thumb background attributes
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ThumbBackgroundAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set low indicator image attributes
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes LowIndicatorImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set high indicator image attributes
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes HighIndicatorImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or low indicator text attributes
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes LowIndicatorTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set high indicator text attributes
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes HighIndicatorTextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set track thickness
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? TrackThickness
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set space between track and indicator
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? SpaceBetweenTrackAndIndicator
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set Indicator type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Slider.IndicatorType IndicatorType
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new SliderAttributes(this);
        }
    }
}
