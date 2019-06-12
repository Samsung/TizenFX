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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// A slider lets users select a value from a continuous or discrete range of values by moving the slider thumb.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Slider : Control
    {
        // the background track image object
        private ImageView bgTrackImage = null;
        // the slided track image object
        private ImageView slidedTrackImage = null;
        // the thumb image object
        private ImageView thumbImage = null;
        // the background thumb image object
        private ImageView bgThumbImage = null;
        // the low indicator image object
        private ImageView lowIndicatorImage = null;
        // the high indicator image object
        private ImageView highIndicatorImage = null;
        // the low indicator text object
        private TextLabel lowIndicatorText = null;
        // the high indicator text object
        private TextLabel highIndicatorText = null;
        // the attributes of the slider
        private SliderAttributes sliderAttrs = null;
        // the direction type
        private DirectionType direction = DirectionType.Horizontal;
        // the indicator type
        private IndicatorType indicatorType = IndicatorType.None;
        // the minimum value
        private int? minValue = null;
        // the maximum value
        private int? maxValue = null;
        // the current value
        private int? curValue = null;
        // the size of the low indicator
        private Size2D lowIndicatorSize = null;
        // the size of the high indicator
        private Size2D highIndicatorSize = null;
        // the track thickness value
        private uint? trackThickness = null;
        // the value of the space between track and indicator object
        private uint? spaceBetweenTrackAndIndicator = null;
        
        private PanGestureDetector panGestureDetector = null;
        private float currentSlidedOffset;
        private EventHandler<ValueChangedArgs> valueChangedHandler;
        private EventHandler<StateChangedArgs> stateChangedHandler;

        bool isFocused = false;
        bool isPressed = false;

        /// <summary>
        /// The constructor of the Slider class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Slider() 
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Slider class with specific style
        /// </summary>
        /// <param name="style">The string to initialize the Slider</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Slider(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Slider class with specific Attributes
        /// </summary>
        /// <param name="attributes">The Attributes object to initialize the Slider</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Slider(SliderAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// The value changed event handler
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ValueChangedArgs> ValueChangedEvent
        {
            add
            {
                valueChangedHandler += value;
            }
            remove
            {
                valueChangedHandler -= value;
            }
        }

        /// <summary>
        /// The state changed event handler
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<StateChangedArgs> StateChangedEvent
        {
            add
            {
                stateChangedHandler += value;
            }
            remove
            {
                stateChangedHandler -= value;
            }
        }

        /// <summary>
        /// The direction type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum DirectionType
        {
            /// <summary>
            /// The Horizontal type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Horizontal,

            /// <summary>
            /// The Vertical type
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Vertical
        }

        /// <summary>
        /// The indicator type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum IndicatorType
        {
            /// <summary> Only contains slider bar.</summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            None,

            /// <summary> Contains slider bar, IndicatorImage.</summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Image,

            /// <summary> Contains slider bar, IndicatorText.</summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Text
        }

        /// <summary>
        /// The property for the direction type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DirectionType Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if (direction == value)
                {
                    return;
                }
                direction = value;
                RelayoutBaseComponent(false);
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        /// <summary>
        /// Property to get/set the indicator type, arrow or sign
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IndicatorType Indicator
        {
            get
            {
                return indicatorType;
            }
            set
            {
                if (indicatorType == value)
                {
                    return;
                }
                indicatorType = value;
                RelayoutBaseComponent(false);
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        /// <summary>
        /// The property for the minimum value
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MinValue
        {
            get
            {
                return minValue.Value;
            }
            set
            {
                minValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property for the maximum value
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MaxValue
        {
            get
            {
                return maxValue.Value;
            }
            set
            {
                maxValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property for the current value
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentValue
        {
            get
            {
                return curValue.Value;
            }
            set
            {
                curValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// The property for the size of the thumb image object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D ThumbSize
        {
            get
            {
                return sliderAttrs.ThumbAttributes?.Size2D;
            }
            set
            {
                CreateThumbAttributes();
                sliderAttrs.ThumbAttributes.Size2D = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the resource url selector of the thumb image background object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector ThumbImageBackgroundURLSelector
        {
            get { return sliderAttrs.ThumbBackgroundAttributes?.ResourceURL; }
            set
            {
                CreateThumbBackgroundAttributes();
                if (value != null)
                {
                    sliderAttrs.ThumbBackgroundAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property for the resource url of the thumb image object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ThumbImageURL
        {
            get { return sliderAttrs.ThumbAttributes?.ResourceURL?.All; }
            set
            {
                CreateThumbAttributes();
                if (sliderAttrs.ThumbAttributes.ResourceURL == null)
                {
                    sliderAttrs.ThumbAttributes.ResourceURL = new StringSelector(); 
                }
                sliderAttrs.ThumbAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the resource url selector of the thumb image object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector ThumbImageURLSelector
        {
            get { return sliderAttrs.ThumbAttributes?.ResourceURL; }
            set
            {
                CreateThumbAttributes();
                if (value != null)
                {
                    sliderAttrs.ThumbAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property for the color of the background track image object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BgTrackColor
        {
            get
            {
                return sliderAttrs.BackgroundTrackAttributes?.BackgroundColor?.All;
            }
            set
            {
                CreateBackgroundTrackAttributes();
                if (sliderAttrs.BackgroundTrackAttributes.BackgroundColor == null)
                {
                    sliderAttrs.BackgroundTrackAttributes.BackgroundColor = new ColorSelector();
                }
                sliderAttrs.BackgroundTrackAttributes.BackgroundColor.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the color of the slided track image object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color SlidedTrackColor
        {
            get
            {
                return sliderAttrs.SlidedTrackAttributes?.BackgroundColor?.All;
            }
            set
            {
                CreateSlidedTrackAttributes();
                if (sliderAttrs.SlidedTrackAttributes.BackgroundColor == null)
                {
                    sliderAttrs.SlidedTrackAttributes.BackgroundColor = new ColorSelector();
                }
                sliderAttrs.SlidedTrackAttributes.BackgroundColor.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the thickness value of the track
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint TrackThickness
        {
            get
            {
                return trackThickness.Value;
            }
            set
            {
                trackThickness = value;
                if (bgTrackImage != null)
                {
                    if (direction == DirectionType.Horizontal)
                    {
                        bgTrackImage.SizeHeight = (float)trackThickness.Value;
                    }
                    else if (direction == DirectionType.Vertical)
                    {
                        bgTrackImage.SizeWidth = (float)trackThickness.Value;
                    }
                }
                if (slidedTrackImage != null)
                {
                    if (direction == DirectionType.Horizontal)
                    {
                        slidedTrackImage.SizeHeight = (float)trackThickness.Value;
                    }
                    else if (direction == DirectionType.Vertical)
                    {
                        slidedTrackImage.SizeWidth = (float)trackThickness.Value;
                    }
                }
            }
        }

        /// <summary>
        /// The property for the resource url of the low indicator image object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LowIndicatorImageURL
        {
            get
            {
                return sliderAttrs.LowIndicatorImageAttributes?.ResourceURL?.All;
            }
            set
            {
                CreateLowIndicatorImageAttributes();
                if (sliderAttrs.LowIndicatorImageAttributes.ResourceURL == null)
                {
                    sliderAttrs.LowIndicatorImageAttributes.ResourceURL = new StringSelector();
                }
                sliderAttrs.LowIndicatorImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the resource url of the high indicator image object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HighIndicatorImageURL
        {
            get
            {
                return sliderAttrs.HighIndicatorImageAttributes?.ResourceURL?.All;
            }
            set
            {
                CreateHighIndicatorImageAttributes();
                if (sliderAttrs.HighIndicatorImageAttributes.ResourceURL == null)
                {
                    sliderAttrs.HighIndicatorImageAttributes.ResourceURL = new StringSelector();
                }
                sliderAttrs.HighIndicatorImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the text content of the low indicator text object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LowIndicatorTextContent
        {
            get
            {
                return sliderAttrs.LowIndicatorTextAttributes?.Text?.All;
            }
            set
            {
                CreateLowIndicatorTextAttributes();
                if (sliderAttrs.LowIndicatorTextAttributes.Text == null)
                {
                    sliderAttrs.LowIndicatorTextAttributes.Text = new StringSelector();
                }
                sliderAttrs.LowIndicatorTextAttributes.Text.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the text content of the high indicator text object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HighIndicatorTextContent
        {
            get
            {
                return sliderAttrs.HighIndicatorTextAttributes?.Text?.All;
            }
            set
            {
                CreateHighIndicatorTextAttributes();
                if (sliderAttrs.HighIndicatorTextAttributes.Text == null)
                {
                    sliderAttrs.HighIndicatorTextAttributes.Text = new StringSelector();
                }
                sliderAttrs.HighIndicatorTextAttributes.Text.All = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property for the size of the low indicator object(image or text)
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D LowIndicatorSize
        {
            get
            {
                return lowIndicatorSize;
            }
            set
            {
                lowIndicatorSize = value;
                UpdateLowIndicatorSize();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        /// <summary>
        /// The property for the size of the high indicator object(image or text)
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D HighIndicatorSize
        {
            get
            {
                return highIndicatorSize;
            }
            set
            {
                highIndicatorSize = value;
                UpdateHighIndicatorSize();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        /// <summary>
        /// The property for the value of the space between track and indicator
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint SpaceBetweenTrackAndIndicator
        {
            get
            {
                return spaceBetweenTrackAndIndicator.Value;
            }
            set
            {
                spaceBetweenTrackAndIndicator = value;
                UpdateComponentByIndicatorTypeChanged();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        /// <summary>
        /// Focus gained callback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusGained()
        {
            //State = ControlStates.Focused;
            UpdateState(true, isPressed);
            base.OnFocusGained();
        }

        /// <summary>
        /// Focus Lost callback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusLost()
        {
            //State = ControlStates.Normal;
            UpdateState(false, isPressed);
            base.OnFocusLost();
        }

        /// <summary>
        /// Get Slider attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new SliderAttributes();
        }

        /// <summary>
        /// Dispose Slider.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (panGestureDetector != null)
                {
                    if (thumbImage != null)
                    {
                        panGestureDetector.Detach(thumbImage);
                    }
                    panGestureDetector.Detected -= OnPanGestureDetected;
                    panGestureDetector.Dispose();
                    panGestureDetector = null;
                }
                
                if (thumbImage != null)
                {
                    thumbImage.TouchEvent -= OnTouchEventForThumb;
                    Utility.Dispose(thumbImage);
                }
                Utility.Dispose(bgThumbImage);
                Utility.Dispose(slidedTrackImage);
                if (bgTrackImage != null)
                {
                    bgTrackImage.TouchEvent -= OnTouchEventForBgTrack;
                    Utility.Dispose(bgTrackImage);
                }
                Utility.Dispose(lowIndicatorImage);
                Utility.Dispose(highIndicatorImage);
                Utility.Dispose(lowIndicatorText);
                Utility.Dispose(highIndicatorText);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update Slider by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            if (sliderAttrs.BackgroundTrackAttributes != null && bgTrackImage == null)
            {
                bgTrackImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true
                };
                this.Add(bgTrackImage);
                bgTrackImage.TouchEvent += OnTouchEventForBgTrack;
            }
            if (sliderAttrs.SlidedTrackAttributes != null && slidedTrackImage == null)
            {
                slidedTrackImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                if (bgTrackImage != null)
                {
                    bgTrackImage.Add(slidedTrackImage);
                }
            }
            if (sliderAttrs.ThumbBackgroundAttributes != null && bgThumbImage == null)
            {
                bgThumbImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                if (slidedTrackImage != null)
                {
                    slidedTrackImage.Add(bgThumbImage);
                }
            }
            if (sliderAttrs.ThumbAttributes != null && thumbImage == null)
            {
                thumbImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    ParentOrigin = NUI.ParentOrigin.Center,
                    PivotPoint = NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true
                };
                if (bgThumbImage != null)
                {
                    bgThumbImage.Add(thumbImage);
                }
                thumbImage.TouchEvent += OnTouchEventForThumb;

                panGestureDetector = new PanGestureDetector();
                panGestureDetector.Attach(thumbImage);
                panGestureDetector.Detected += OnPanGestureDetected;
            }
            if (sliderAttrs.LowIndicatorImageAttributes != null && lowIndicatorImage == null)
            {
                lowIndicatorImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(lowIndicatorImage);
            }
            if (sliderAttrs.HighIndicatorImageAttributes != null && highIndicatorImage == null)
            {
                highIndicatorImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(highIndicatorImage);
            }
            if (sliderAttrs.LowIndicatorTextAttributes != null && lowIndicatorText == null)
            {
                lowIndicatorText = new TextLabel()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(lowIndicatorText);
            }
            if (sliderAttrs.HighIndicatorTextAttributes != null && highIndicatorText == null)
            {
                highIndicatorText = new TextLabel()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(highIndicatorText);
            }

            ApplyAttributes(bgTrackImage, sliderAttrs.BackgroundTrackAttributes);
            ApplyAttributes(slidedTrackImage, sliderAttrs.SlidedTrackAttributes);
            ApplyAttributes(bgThumbImage, sliderAttrs.ThumbBackgroundAttributes);
            ApplyAttributes(thumbImage, sliderAttrs.ThumbAttributes);
            ApplyAttributes(lowIndicatorImage, sliderAttrs.LowIndicatorImageAttributes);
            ApplyAttributes(highIndicatorImage, sliderAttrs.HighIndicatorImageAttributes);
            ApplyAttributes(lowIndicatorText, sliderAttrs.LowIndicatorTextAttributes);
            ApplyAttributes(highIndicatorText, sliderAttrs.HighIndicatorTextAttributes);

            RelayoutBaseComponent();

            UpdateComponentByIndicatorTypeChanged();
            UpdateBgTrackSize();
            UpdateBgTrackPosition();
            UpdateLowIndicatorSize();
            UpdateHighIndicatorSize();
            UpdateValue();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">serder object</param>
        /// <param name="e">ThemeChangeEventArgs</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            SliderAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as SliderAttributes;
            if (tempAttributes != null)
            {
                attributes = sliderAttrs = tempAttributes;
                RelayoutRequest();
            }
        }

        private void Initialize()
        {
            sliderAttrs = attributes as SliderAttributes;
            if (sliderAttrs == null)
            {
                throw new Exception("Fail to get the slider attributes.");
            }

            ApplyAttributes(this, sliderAttrs);

            currentSlidedOffset = 0;
            isFocused = false;
            isPressed = false;
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            RelayoutRequest();
        }

        private void CreateSlidedTrackAttributes()
        {
            if (sliderAttrs.SlidedTrackAttributes == null)
            {
                sliderAttrs.SlidedTrackAttributes = new ImageAttributes();
            }
        }

        private void CreateLowIndicatorImageAttributes()
        {
            if (sliderAttrs.LowIndicatorImageAttributes == null)
            {
                sliderAttrs.LowIndicatorImageAttributes = new ImageAttributes();
            }
        }

        private void CreateLowIndicatorTextAttributes()
        {
            if (sliderAttrs.LowIndicatorTextAttributes == null)
            {
                sliderAttrs.LowIndicatorTextAttributes = new TextAttributes();
            }
        }

        private void CreateHighIndicatorTextAttributes()
        {
            if (sliderAttrs.HighIndicatorTextAttributes == null)
            {
                sliderAttrs.HighIndicatorTextAttributes = new TextAttributes();
            }
        }

        private void CreateHighIndicatorImageAttributes()
        {
            if (sliderAttrs.HighIndicatorImageAttributes == null)
            {
                sliderAttrs.HighIndicatorImageAttributes = new ImageAttributes();
            }
        }

        private void CreateBackgroundTrackAttributes()
        {
            if (sliderAttrs.BackgroundTrackAttributes == null)
            {
                sliderAttrs.BackgroundTrackAttributes = new ImageAttributes();
            }
        }

        private void CreateThumbAttributes()
        {
            if (sliderAttrs.ThumbAttributes == null)
            {
                sliderAttrs.ThumbAttributes = new ImageAttributes();
            }
        }

        private void CreateThumbBackgroundAttributes()
        {
            if (sliderAttrs.ThumbBackgroundAttributes == null)
            {
                sliderAttrs.ThumbBackgroundAttributes = new ImageAttributes();
            }
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                if (direction == DirectionType.Horizontal)
                {
                    currentSlidedOffset = slidedTrackImage.SizeWidth;
                }
                else if (direction == DirectionType.Vertical)
                {
                    currentSlidedOffset = slidedTrackImage.SizeHeight;
                }
                UpdateState(isFocused, true);
            }

            if (e.PanGesture.State == Gesture.StateType.Continuing || e.PanGesture.State == Gesture.StateType.Started)
            {
                if (direction == DirectionType.Horizontal)
                {
                    CalculateCurrentValueByGesture(e.PanGesture.Displacement.X);
                }
                else if (direction == DirectionType.Vertical)
                {
                    CalculateCurrentValueByGesture(-e.PanGesture.Displacement.Y);
                }
                UpdateValue();
            }

            if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                UpdateState(isFocused, false);
            }
        }

        // Relayout basic component: track, thumb and indicator
        private void RelayoutBaseComponent(bool isInitial = true)
        {
            if (direction == DirectionType.Horizontal)
            {
                if (slidedTrackImage != null)
                {
                    slidedTrackImage.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    slidedTrackImage.PivotPoint = NUI.PivotPoint.CenterLeft;
                    slidedTrackImage.PositionUsesPivotPoint = true;
                }
                if (bgThumbImage != null)
                {
                    bgThumbImage.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    bgThumbImage.PivotPoint = NUI.PivotPoint.Center;
                    bgThumbImage.PositionUsesPivotPoint = true;
                }
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    lowIndicatorImage.PivotPoint = NUI.PivotPoint.CenterLeft;
                    lowIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    highIndicatorImage.PivotPoint = NUI.PivotPoint.CenterRight;
                    highIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    lowIndicatorText.PivotPoint = NUI.PivotPoint.CenterLeft;
                    lowIndicatorText.PositionUsesPivotPoint = true;
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    highIndicatorText.PivotPoint = NUI.PivotPoint.CenterRight;
                    highIndicatorText.PositionUsesPivotPoint = true;
                }
                if (panGestureDetector != null)
                {
                    if (!isInitial)
                    {
                        panGestureDetector.RemoveDirection(PanGestureDetector.DirectionVertical);
                    }
                    panGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
                }
            }
            else if (direction == DirectionType.Vertical)
            {
                if (slidedTrackImage != null)
                {
                    slidedTrackImage.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    slidedTrackImage.PivotPoint = NUI.PivotPoint.BottomCenter;
                    slidedTrackImage.PositionUsesPivotPoint = true;
                }
                if (bgThumbImage != null)
                {
                    bgThumbImage.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    bgThumbImage.PivotPoint = NUI.PivotPoint.Center;
                    bgThumbImage.PositionUsesPivotPoint = true;
                }
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    lowIndicatorImage.PivotPoint = NUI.PivotPoint.BottomCenter;
                    lowIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    highIndicatorImage.PivotPoint = NUI.PivotPoint.TopCenter;
                    highIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    lowIndicatorText.PivotPoint = NUI.PivotPoint.BottomCenter;
                    lowIndicatorText.PositionUsesPivotPoint = true;
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    highIndicatorText.PivotPoint = NUI.PivotPoint.TopCenter;
                    highIndicatorText.PositionUsesPivotPoint = true;
                }
                if (panGestureDetector != null)
                {
                    if (!isInitial)
                    {
                        panGestureDetector.RemoveDirection(PanGestureDetector.DirectionHorizontal);
                    }
                    panGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
                }
            }
        }

        private int BgTrackLength()
        {
            int bgTrackLength = 0;
            IndicatorType type = CurrentIndicatorType();

            if (type == IndicatorType.None)
            {
                if (direction == DirectionType.Horizontal)
                {
                    bgTrackLength = this.Size2D.Width;
                }
                else if (direction == DirectionType.Vertical)
                {
                    bgTrackLength = this.Size2D.Height;
                }
            }
            else if (type == IndicatorType.Image)
            {// <lowIndicatorImage> <spaceBetweenTrackAndIndicator> <bgTrack> <spaceBetweenTrackAndIndicator> <highIndicatorImage>
                Size2D lowIndicatorImageSize = LowIndicatorImageSize();
                Size2D highIndicatorImageSize = HighIndicatorImageSize();
                int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = ((lowIndicatorImageSize.Width == 0) ? (0) : (curSpace + lowIndicatorImageSize.Width));
                    int highIndicatorSpace = ((highIndicatorImageSize.Width == 0) ? (0) : (curSpace + highIndicatorImageSize.Width));
                    bgTrackLength = this.Size2D.Width - lowIndicatorSpace - highIndicatorSpace;
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = ((lowIndicatorImageSize.Height == 0) ? (0) : (curSpace + lowIndicatorImageSize.Height));
                    int highIndicatorSpace = ((highIndicatorImageSize.Height == 0) ? (0) : (curSpace + highIndicatorImageSize.Height));
                    bgTrackLength = this.Size2D.Height - lowIndicatorSpace - highIndicatorSpace;
                }
            }
            else if (type == IndicatorType.Text)
            {// <lowIndicatorText> <spaceBetweenTrackAndIndicator> <bgTrack> <spaceBetweenTrackAndIndicator> <highIndicatorText>
                Size2D lowIndicatorTextSize = LowIndicatorTextSize();
                Size2D highIndicatorTextSize = HighIndicatorTextSize();
                int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = ((lowIndicatorTextSize.Width == 0) ? (0) : (curSpace + lowIndicatorTextSize.Width));
                    int highIndicatorSpace = ((highIndicatorTextSize.Width == 0) ? (0) : (curSpace + highIndicatorTextSize.Width));
                    bgTrackLength = this.Size2D.Width - lowIndicatorSpace - highIndicatorSpace;
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = ((lowIndicatorTextSize.Height == 0) ? (0) : (curSpace + lowIndicatorTextSize.Height));
                    int highIndicatorSpace = ((highIndicatorTextSize.Height == 0) ? (0) : (curSpace + highIndicatorTextSize.Height));
                    bgTrackLength = this.Size2D.Height - lowIndicatorSpace - highIndicatorSpace;
                }
            }
            return bgTrackLength;
        }

        private void UpdateLowIndicatorSize()
        {
            if (lowIndicatorSize != null)
            {
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Size2D = lowIndicatorSize;
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Size2D = lowIndicatorSize;
                }
            }
            else
            {
                if (lowIndicatorImage != null && sliderAttrs != null && sliderAttrs.LowIndicatorImageAttributes != null && sliderAttrs.LowIndicatorImageAttributes.Size2D != null)
                {
                    lowIndicatorImage.Size2D = sliderAttrs.LowIndicatorImageAttributes.Size2D;
                }
                if (lowIndicatorText != null && sliderAttrs != null && sliderAttrs.LowIndicatorTextAttributes != null && sliderAttrs.LowIndicatorTextAttributes.Size2D != null)
                {
                    lowIndicatorText.Size2D = sliderAttrs.LowIndicatorTextAttributes.Size2D;
                }
            }
        }

        private void UpdateHighIndicatorSize()
        {
            if (highIndicatorSize != null)
            {
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Size2D = highIndicatorSize;
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Size2D = highIndicatorSize;
                }
            }
            else
            {
                if (highIndicatorImage != null && sliderAttrs != null && sliderAttrs.HighIndicatorImageAttributes != null && sliderAttrs.HighIndicatorImageAttributes.Size2D != null)
                {
                    highIndicatorImage.Size2D = sliderAttrs.HighIndicatorImageAttributes.Size2D;
                }
                if (highIndicatorText != null && sliderAttrs != null && sliderAttrs.HighIndicatorTextAttributes != null && sliderAttrs.HighIndicatorTextAttributes.Size2D != null)
                {
                    highIndicatorText.Size2D = sliderAttrs.HighIndicatorTextAttributes.Size2D;
                }
            }
        }

        private void UpdateBgTrackSize()
        {
            if(bgTrackImage == null)
            {
                return;
            }
            int curTrackThickness = (int)CurrentTrackThickness();
            int bgTrackLength = BgTrackLength();
            if (direction == DirectionType.Horizontal)
            {
                bgTrackImage.Size2D = new Size2D(bgTrackLength, curTrackThickness);
            }
            else if (direction == DirectionType.Vertical)
            {
                bgTrackImage.Size2D = new Size2D(curTrackThickness, bgTrackLength);
            }
        }

        private void UpdateBgTrackPosition()
        {
            if (bgTrackImage == null)
            {
                return;
            }
            IndicatorType type = CurrentIndicatorType();

            if (type == IndicatorType.None)
            {
                bgTrackImage.Position2D = new Position2D(0, 0);
            }
            else if (type == IndicatorType.Image)
            {
                Size2D lowIndicatorImageSize = LowIndicatorImageSize();
                Size2D highIndicatorImageSize = HighIndicatorImageSize();
                int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = ((lowIndicatorImageSize.Width == 0) ? (0) : (curSpace + lowIndicatorImageSize.Width));
                    int highIndicatorSpace = ((highIndicatorImageSize.Width == 0) ? (0) : (curSpace + highIndicatorImageSize.Width));
                    bgTrackImage.Position2D = new Position2D(lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2, 0);
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = ((lowIndicatorImageSize.Height == 0) ? (0) : (curSpace + lowIndicatorImageSize.Height));
                    int highIndicatorSpace = ((highIndicatorImageSize.Height == 0) ? (0) : (curSpace + highIndicatorImageSize.Height));
                    bgTrackImage.Position2D = new Position2D(0, lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2);
                }
            }
            else if (type == IndicatorType.Text)
            {
                Size2D lowIndicatorTextSize = LowIndicatorTextSize();
                Size2D highIndicatorTextSize = HighIndicatorTextSize();
                int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = ((lowIndicatorTextSize.Width == 0) ? (0) : (curSpace + lowIndicatorTextSize.Width));
                    int highIndicatorSpace = ((highIndicatorTextSize.Width == 0) ? (0) : (curSpace + highIndicatorTextSize.Width));
                    bgTrackImage.Position2D = new Position2D(lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2, 0);
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = ((lowIndicatorTextSize.Height == 0) ? (0) : (curSpace + lowIndicatorTextSize.Height));
                    int highIndicatorSpace = ((highIndicatorTextSize.Height == 0) ? (0) : (curSpace + highIndicatorTextSize.Height));
                    bgTrackImage.Position2D = new Position2D(0, -(lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2));
                }
            }
        }

        private void UpdateValue()
        {
            if (slidedTrackImage == null || curValue == null || minValue == null || maxValue == null)
            {
                return;
            }
            if (curValue < minValue || curValue > maxValue || minValue >= maxValue)
            {
                return;
            }
            
            float ratio = 0;
            ratio = (float)(curValue - minValue) / (float)(maxValue - minValue);

            uint curTrackThickness = CurrentTrackThickness();

            if (direction == DirectionType.Horizontal)
            {
                if (LayoutDirection == ViewLayoutDirectionType.RTL)
                {
                    ratio = 1.0f - ratio;
                }
                float slidedTrackLength = (float)BgTrackLength() * ratio;
                slidedTrackImage.Size2D = new Size2D((int)slidedTrackLength, (int)curTrackThickness);
            }
            else if (direction == DirectionType.Vertical)
            {
                float slidedTrackLength = (float)BgTrackLength() * ratio;
                slidedTrackImage.Size2D = new Size2D((int)curTrackThickness, (int)slidedTrackLength);
            }
        }

        private uint CurrentTrackThickness()
        {
            uint curTrackThickness = 0;
            if (trackThickness != null)
            {
                curTrackThickness = trackThickness.Value;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.TrackThickness != null)
                {
                    curTrackThickness = sliderAttrs.TrackThickness.Value;
                }
            }
            return curTrackThickness;
        }

        private uint CurrentSpaceBetweenTrackAndIndicator()
        {
            uint curSpace = 0;
            if (spaceBetweenTrackAndIndicator != null)
            {
                curSpace = spaceBetweenTrackAndIndicator.Value;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.SpaceBetweenTrackAndIndicator != null)
                {
                    curSpace = sliderAttrs.SpaceBetweenTrackAndIndicator.Value;
                }
            }
            return curSpace;
        }

        private IndicatorType CurrentIndicatorType()
        {
            IndicatorType type = IndicatorType.None;
            if (sliderAttrs != null)
            {
                type = sliderAttrs.IndicatorType;
            }
            return type;
        }

        private Size2D LowIndicatorImageSize()
        {
            Size2D size = new Size2D(0, 0);
            if (lowIndicatorSize != null)
            {
                size = lowIndicatorSize;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.LowIndicatorImageAttributes != null && sliderAttrs.LowIndicatorImageAttributes.Size2D != null)
                {
                    size = sliderAttrs.LowIndicatorImageAttributes.Size2D;
                }
            }
            return size;
        }

        private Size2D HighIndicatorImageSize()
        {
            Size2D size = new Size2D(0, 0);
            if (highIndicatorSize != null)
            {
                size = highIndicatorSize;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.HighIndicatorImageAttributes != null && sliderAttrs.HighIndicatorImageAttributes.Size2D != null)
                {
                    size = sliderAttrs.HighIndicatorImageAttributes.Size2D;
                }
            }
            return size;
        }

        private Size2D LowIndicatorTextSize()
        {
            Size2D size = new Size2D(0, 0);
            if (lowIndicatorSize != null)
            {
                size = lowIndicatorSize;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.LowIndicatorTextAttributes != null && sliderAttrs.LowIndicatorTextAttributes.Size2D != null)
                {
                    size = sliderAttrs.LowIndicatorTextAttributes.Size2D;
                }
            }
            return size;
        }

        private Size2D HighIndicatorTextSize()
        {
            Size2D size = new Size2D(0, 0);
            if (highIndicatorSize != null)
            {
                size = highIndicatorSize;
            }
            else
            {
                if (sliderAttrs != null && sliderAttrs.HighIndicatorTextAttributes != null && sliderAttrs.HighIndicatorTextAttributes.Size2D != null)
                {
                    size = sliderAttrs.HighIndicatorTextAttributes.Size2D;
                }
            }
            return size;
        }

        private void CalculateCurrentValueByGesture(float offset)
        {
            currentSlidedOffset += offset;

            if (currentSlidedOffset <= 0)
            {
                curValue = minValue;
            }
            else if (currentSlidedOffset >= BgTrackLength())
            {
                curValue = maxValue;
            }
            else
            {
                int bgTrackLength = BgTrackLength();
                if (bgTrackLength != 0)
                {
                    curValue = (int)((currentSlidedOffset / (float)bgTrackLength) * (float)(maxValue - minValue) + 0.5f) + minValue;
                }
            }
            if (valueChangedHandler != null)
            {
                ValueChangedArgs args = new ValueChangedArgs();
                args.CurrentValue = curValue.Value;
                valueChangedHandler(this, args);
            }
        }

        private bool OnTouchEventForBgTrack(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                Vector2 pos = e.Touch.GetLocalPosition(0);
                CalculateCurrentValueByTouch(pos);
                UpdateValue();
            }
            return false;
        }

        private bool OnTouchEventForThumb(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                UpdateState(isFocused, true);
            }
            else if (state == PointStateType.Up)
            {
                UpdateState(isFocused, false);
            }
            return true;
        }

        private void CalculateCurrentValueByTouch(Vector2 pos)
        {
            int bgTrackLength = BgTrackLength();
            if (direction == DirectionType.Horizontal)
            {
                currentSlidedOffset = pos.X;
            }
            else if (direction == DirectionType.Vertical)
            {
                currentSlidedOffset = bgTrackLength - pos.Y;
            }
            if (bgTrackLength != 0)
            {
                curValue = (int)((currentSlidedOffset / (float)bgTrackLength) * (float)(maxValue - minValue) + 0.5f) + minValue;
                if (valueChangedHandler != null)
                {
                    ValueChangedArgs args = new ValueChangedArgs();
                    args.CurrentValue = curValue.Value;
                    valueChangedHandler(this, args);
                }
            }
        }

        private void UpdateState(bool isFocusedNew, bool isPressedNew)
        {
            if (isFocused == isFocusedNew && isPressed == isPressedNew)
            {
                return;
            }
            if (thumbImage == null || sliderAttrs == null)
            {
                return;
            }
            isFocused = isFocusedNew;
            isPressed = isPressedNew;

            if (!isFocused && !isPressed)
            {
                State = ControlStates.Normal;
                ApplyAttributes(bgThumbImage, sliderAttrs.ThumbBackgroundAttributes);
                ApplyAttributes(thumbImage, sliderAttrs.ThumbAttributes);
                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = ControlStates.Normal;
                    stateChangedHandler(this, args);
                }
            }
            else if (isPressed)
            {
                State = ControlStates.Pressed;
                ApplyAttributes(bgThumbImage, sliderAttrs.ThumbBackgroundAttributes);
                ApplyAttributes(thumbImage, sliderAttrs.ThumbAttributes);

                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = ControlStates.Pressed;
                    stateChangedHandler(this, args);
                }
            }
            else if (!isPressed && isFocused)
            {
                State = ControlStates.Focused;
                ApplyAttributes(bgThumbImage, sliderAttrs.ThumbBackgroundAttributes);
                ApplyAttributes(thumbImage, sliderAttrs.ThumbAttributes);

                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = ControlStates.Focused;
                    stateChangedHandler(this, args);
                }
            }
        }

        private void UpdateComponentByIndicatorTypeChanged()
        {
            IndicatorType type = CurrentIndicatorType();
            if (type == IndicatorType.None)
            {
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Hide();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Hide();
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Hide();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Hide();
                }
            }
            else if (type == IndicatorType.Image)
            {
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Show();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Show();
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Hide();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Hide();
                }
            }
            else if (type == IndicatorType.Text)
            {
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Show();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Show();
                }
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Hide();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Hide();
                }
            }
        }

        /// <summary>
        /// Value Changed event data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ValueChangedArgs : EventArgs
        {
            /// <summary>
            /// Curren value
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int CurrentValue;
        }

        /// <summary>
        /// State Changed event data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class StateChangedArgs : EventArgs
        {
            /// <summary>
            /// Curent state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ControlStates CurrentState;
        }
    }
}
