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

using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    public partial class Slider
    {
        // the background track image object
        private ImageView bgTrackImage = null;
        // the slided track image object
        private ImageView slidedTrackImage = null;
        // the warning track image object
        private ImageView warningTrackImage = null;
        // the warning slided track image object
        private ImageView warningSlidedTrackImage = null;
        // the thumb image object
        private ImageView thumbImage = null;
        // the low indicator image object
        private ImageView lowIndicatorImage = null;
        // the high indicator image object
        private ImageView highIndicatorImage = null;
        // the low indicator text object
        private TextLabel lowIndicatorText = null;
        // the high indicator text object
        private TextLabel highIndicatorText = null;
        // the direction type
        private DirectionType direction = DirectionType.Horizontal;
        // the indicator type
        private IndicatorType indicatorType = IndicatorType.None;
        private const float round = 0.5f;
        // the minimum value
        private float minValue = 0;
        // the maximum value
        private float maxValue = 100;
        // the current value
        private float curValue = 0;
        // the warning start value
        private float warningStartValue = 100;
        // the size of the low indicator
        private Size lowIndicatorSize = null;
        // the size of the high indicator
        private Size highIndicatorSize = null;
        // the track thickness value
        private uint? trackThickness = null;
        // the value of the space between track and indicator object
        private Extents spaceTrackIndicator = null;
        // Whether the value indicator is shown or not
        private bool isValueShown = false;
        // the value indicator text
        private TextLabel valueIndicatorText = null;
        // the value indicator image object
        private ImageView valueIndicatorImage = null;

        // To store the thumb size of normal state
        private Size thumbSize = null;
        // To store the thumb image url of normal state
        private string thumbImageUrl = null;
        // To store the thumb image url selector of normal state
        private Selector<string> thumbImageUrlSelector = null;
        // To store the thumb color of normal state
        private Color thumbColor = Color.White;
        // To store the thumb image url of warning state
        private string warningThumbImageUrl = null;
        // To store the thumb image url selector of warning state
        private Selector<string> warningThumbImageUrlSelector = null;
        // To store the thumb color of warning state
        private Color warningThumbColor = null;
        // the discrete value
        private float discreteValue = 0;

        private PanGestureDetector panGestureDetector = null;
        private float currentSlidedOffset;
        private EventHandler<ValueChangedArgs> valueChangedHandler;
        private EventHandler<SlidingFinishedArgs> slidingFinishedHandler;
        private EventHandler<SliderValueChangedEventArgs> sliderValueChangedHandler;
        private EventHandler<SliderSlidingStartedEventArgs> sliderSlidingStartedHandler;
        private EventHandler<SliderSlidingFinishedEventArgs> sliderSlidingFinishedHandler;
        private EventHandler<StateChangedArgs> stateChangedHandler;

        bool isFocused = false;
        bool isPressed = false;

        private void Initialize()
        {
            AccessibilityHighlightable = true;

            currentSlidedOffset = 0;
            isFocused = false;
            isPressed = false;
            LayoutDirectionChanged += OnLayoutDirectionChanged;

            panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(this);
            panGestureDetector.Detected += OnPanGestureDetected;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            RelayoutRequest();
        }

        private ImageView CreateSlidedTrack()
        {
            if (null == slidedTrackImage)
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

            return slidedTrackImage;
        }

        private ImageView CreateWarningTrack()
        {
            if (null == warningTrackImage)
            {
                warningTrackImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };

                if (bgTrackImage != null)
                {
                    bgTrackImage.Add(warningTrackImage);
                }

                if (warningSlidedTrackImage != null)
                {
                    warningTrackImage.Add(warningSlidedTrackImage);
                }

                if (slidedTrackImage != null)
                {
                    warningTrackImage.RaiseAbove(slidedTrackImage);
                }
            }

            return warningTrackImage;
        }

        private ImageView CreateWarningSlidedTrack()
        {
            if (null == warningSlidedTrackImage)
            {
                warningSlidedTrackImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };

                if (warningTrackImage != null)
                {
                    warningTrackImage.Add(warningSlidedTrackImage);
                }
            }

            return warningSlidedTrackImage;
        }

        private TextLabel CreateLowIndicatorText()
        {
            if (null == lowIndicatorText)
            {
                lowIndicatorText = new TextLabel()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(lowIndicatorText);
            }

            return lowIndicatorText;
        }

        private TextLabel CreateHighIndicatorText()
        {
            if (null == highIndicatorText)
            {
                highIndicatorText = new TextLabel()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                this.Add(highIndicatorText);
            }

            return highIndicatorText;
        }

        private ImageView CreateBackgroundTrack()
        {
            if (null == bgTrackImage)
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

                if (null != slidedTrackImage)
                {
                    bgTrackImage.Add(slidedTrackImage);
                }
                if (null != warningTrackImage)
                {
                    bgTrackImage.Add(warningTrackImage);
                }
                if (null != thumbImage)
                {
                    bgTrackImage.Add(thumbImage);
                    thumbImage.RaiseToTop();
                }

                bgTrackImage.TouchEvent += OnTouchEventForBgTrack;
            }

            return bgTrackImage;
        }

        private ImageView CreateThumb()
        {
            if (null == thumbImage)
            {
                thumbImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = NUI.ParentOrigin.Center,
                    PivotPoint = NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true
                };
                if (bgTrackImage != null)
                {
                    bgTrackImage.Add(thumbImage);
                }
                thumbImage.RaiseToTop();
                thumbImage.TouchEvent += OnTouchEventForThumb;
            }

            return thumbImage;
        }

        private ImageView CreateValueIndicator()
        {
            if (valueIndicatorImage == null)
            {
                valueIndicatorImage = new ImageView()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                };
                if (valueIndicatorText != null)
                {
                    valueIndicatorImage.Add(valueIndicatorText);
                }
                // TODO : ValueIndicator can be a child of Thumb
                this.Add(valueIndicatorImage);
            }

            valueIndicatorImage.Hide();
            return valueIndicatorImage;
        }

        private TextLabel CreateValueIndicatorText()
        {
            if (null == valueIndicatorText)
            {
                valueIndicatorText = new TextLabel()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                if (valueIndicatorImage != null)
                {
                    valueIndicatorImage.Add(valueIndicatorText);
                }
            }

            return valueIndicatorText;
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

                if (isValueShown)
                {
                    valueIndicatorImage.Show();
                }

                if (null != sliderSlidingStartedHandler)
                {
                    SliderSlidingStartedEventArgs args = new SliderSlidingStartedEventArgs();
                    args.CurrentValue = curValue;
                    sliderSlidingStartedHandler(this, args);
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
                if (isValueShown)
                {
                    valueIndicatorImage.Hide();
                }

                if (null != slidingFinishedHandler)
                {
                    SlidingFinishedArgs args = new SlidingFinishedArgs();
                    args.CurrentValue = curValue;
                    slidingFinishedHandler(this, args);
                }

                if (null != sliderSlidingFinishedHandler)
                {
                    SliderSlidingFinishedEventArgs args = new SliderSlidingFinishedEventArgs();
                    args.CurrentValue = curValue;
                    sliderSlidingFinishedHandler(this, args);
                }

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
                if (warningTrackImage != null)
                {
                    warningTrackImage.ParentOrigin = NUI.ParentOrigin.CenterRight;
                    warningTrackImage.PivotPoint = NUI.PivotPoint.CenterRight;
                    warningTrackImage.PositionUsesPivotPoint = true;
                }
                if (warningSlidedTrackImage != null)
                {
                    warningSlidedTrackImage.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    warningSlidedTrackImage.PivotPoint = NUI.PivotPoint.CenterLeft;
                    warningSlidedTrackImage.PositionUsesPivotPoint = true;
                }
                if (thumbImage != null)
                {
                    thumbImage.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                    thumbImage.PivotPoint = NUI.PivotPoint.Center;
                    thumbImage.PositionUsesPivotPoint = true;
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
                if (valueIndicatorImage != null)
                {
                    valueIndicatorImage.ParentOrigin = NUI.ParentOrigin.TopLeft;
                    valueIndicatorImage.PivotPoint = NUI.PivotPoint.BottomCenter;
                    valueIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (valueIndicatorText != null)
                {
                    valueIndicatorText.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    valueIndicatorText.PivotPoint = NUI.PivotPoint.TopCenter;
                    valueIndicatorText.PositionUsesPivotPoint = true;
                    valueIndicatorText.Padding = new Extents(0, 0, 5, 0); // TODO : How to set the text as center
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
                if (warningTrackImage != null)
                {
                    warningTrackImage.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    warningTrackImage.PivotPoint = NUI.PivotPoint.TopCenter;
                    warningTrackImage.PositionUsesPivotPoint = true;
                }
                if (warningSlidedTrackImage != null)
                {
                    warningSlidedTrackImage.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    warningSlidedTrackImage.PivotPoint = NUI.PivotPoint.BottomCenter;
                    warningSlidedTrackImage.PositionUsesPivotPoint = true;
                }
                if (thumbImage != null)
                {
                    thumbImage.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    thumbImage.PivotPoint = NUI.PivotPoint.Center;
                    thumbImage.PositionUsesPivotPoint = true;
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
                if (valueIndicatorImage != null)
                {
                    valueIndicatorImage.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    valueIndicatorImage.PivotPoint = NUI.PivotPoint.BottomCenter;
                    valueIndicatorImage.PositionUsesPivotPoint = true;
                }
                if (valueIndicatorText != null)
                {
                    valueIndicatorText.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    valueIndicatorText.PivotPoint = NUI.PivotPoint.TopCenter;
                    valueIndicatorText.PositionUsesPivotPoint = true;
                    valueIndicatorText.Padding = new Extents(0, 0, 5, 0); // TODO : How to set the text as center
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
                Size lowIndicatorImageSize = LowIndicatorImageSize();
                Size highIndicatorImageSize = HighIndicatorImageSize();
                int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = ((lowIndicatorImageSize.Width == 0) ? (0) : ((int)(curSpace + lowIndicatorImageSize.Width)));
                    int highIndicatorSpace = ((highIndicatorImageSize.Width == 0) ? (0) : ((int)(curSpace + highIndicatorImageSize.Width)));
                    bgTrackLength = this.Size2D.Width - lowIndicatorSpace - highIndicatorSpace;
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = ((lowIndicatorImageSize.Height == 0) ? (0) : ((int)(curSpace + lowIndicatorImageSize.Height)));
                    int highIndicatorSpace = ((highIndicatorImageSize.Height == 0) ? (0) : ((int)(curSpace + highIndicatorImageSize.Height)));
                    bgTrackLength = this.Size2D.Height - lowIndicatorSpace - highIndicatorSpace;
                }
            }
            else if (type == IndicatorType.Text)
            {// <lowIndicatorText> <spaceBetweenTrackAndIndicator> <bgTrack> <spaceBetweenTrackAndIndicator> <highIndicatorText>
                Size lowIndicatorTextSize = LowIndicatorTextSize();
                Size highIndicatorTextSize = HighIndicatorTextSize();
                int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = ((lowIndicatorTextSize.Width == 0) ? (0) : ((int)(curSpace + lowIndicatorTextSize.Width)));
                    int highIndicatorSpace = ((highIndicatorTextSize.Width == 0) ? (0) : ((int)(curSpace + highIndicatorTextSize.Width)));
                    bgTrackLength = this.Size2D.Width - lowIndicatorSpace - highIndicatorSpace;
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = ((lowIndicatorTextSize.Height == 0) ? (0) : ((int)(curSpace + lowIndicatorTextSize.Height)));
                    int highIndicatorSpace = ((highIndicatorTextSize.Height == 0) ? (0) : ((int)(curSpace + highIndicatorTextSize.Height)));
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
                    lowIndicatorImage.Size = lowIndicatorSize;
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Size = lowIndicatorSize;
                }
            }
            else
            {
                if (lowIndicatorImage != null && lowIndicatorImage != null && lowIndicatorImage.Size != null)
                {
                    lowIndicatorImage.Size = lowIndicatorSize ?? (ViewStyle as SliderStyle)?.LowIndicatorImage.Size;
                }
                if (lowIndicatorText != null && lowIndicatorText != null && lowIndicatorText.Size != null)
                {
                    lowIndicatorText.Size = lowIndicatorSize ?? (ViewStyle as SliderStyle)?.LowIndicator.Size;
                }
            }
        }

        private void UpdateBgTrackSize()
        {
            if (bgTrackImage == null)
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
                Size lowIndicatorImageSize = LowIndicatorImageSize();
                Size highIndicatorImageSize = HighIndicatorImageSize();
                int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = ((lowIndicatorImageSize.Width == 0) ? (0) : ((int)(curSpace + lowIndicatorImageSize.Width)));
                    int highIndicatorSpace = ((highIndicatorImageSize.Width == 0) ? (0) : ((int)(curSpace + highIndicatorImageSize.Width)));
                    bgTrackImage.Position2D = new Position2D(lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2, 0);
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = ((lowIndicatorImageSize.Height == 0) ? (0) : ((int)(curSpace + lowIndicatorImageSize.Height)));
                    int highIndicatorSpace = ((highIndicatorImageSize.Height == 0) ? (0) : ((int)(curSpace + highIndicatorImageSize.Height)));
                    bgTrackImage.Position2D = new Position2D(0, lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2);
                }
            }
            else if (type == IndicatorType.Text)
            {
                Size lowIndicatorTextSize = LowIndicatorTextSize();
                Size highIndicatorTextSize = HighIndicatorTextSize();
                int curSpace = (int)CurrentSpaceBetweenTrackAndIndicator();
                if (direction == DirectionType.Horizontal)
                {
                    int lowIndicatorSpace = ((lowIndicatorTextSize.Width == 0) ? (0) : ((int)(curSpace + lowIndicatorTextSize.Width)));
                    int highIndicatorSpace = ((highIndicatorTextSize.Width == 0) ? (0) : ((int)(curSpace + highIndicatorTextSize.Width)));
                    bgTrackImage.Position2D = new Position2D(lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2, 0);
                }
                else if (direction == DirectionType.Vertical)
                {
                    int lowIndicatorSpace = ((lowIndicatorTextSize.Height == 0) ? (0) : ((int)(curSpace + lowIndicatorTextSize.Height)));
                    int highIndicatorSpace = ((highIndicatorTextSize.Height == 0) ? (0) : ((int)(curSpace + highIndicatorTextSize.Height)));
                    bgTrackImage.Position2D = new Position2D(0, -(lowIndicatorSpace - (lowIndicatorSpace + highIndicatorSpace) / 2));
                }
            }
        }

        private void UpdateValue()
        {
            if (slidedTrackImage == null)
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
                slidedTrackImage.Size2D = new Size2D((int)(slidedTrackLength + round), (int)curTrackThickness); //Add const round to reach Math.Round function.
                thumbImage.Position = new Position(slidedTrackImage.Size2D.Width, 0);
                thumbImage.RaiseToTop();

                if (isValueShown)
                {
                    valueIndicatorImage.Position = new Position(slidedTrackImage.Size2D.Width, 0);
                }
            }
            else if (direction == DirectionType.Vertical)
            {
                float slidedTrackLength = (float)BgTrackLength() * ratio;
                slidedTrackImage.Size2D = new Size2D((int)curTrackThickness, (int)(slidedTrackLength + round)); //Add const round to reach Math.Round function.
                thumbImage.Position = new Position(0, -slidedTrackImage.Size2D.Height);
                thumbImage.RaiseToTop();

                if (isValueShown)
                {
                    valueIndicatorImage.Position = new Position(0, -(slidedTrackImage.Size2D.Height + thumbImage.Size.Height / 2));
                }
            }

            // Update the track and thumb when the value is over warning value.
            if (curValue >= warningStartValue)
            {
                if (direction == DirectionType.Horizontal)
                {
                    warningSlidedTrackImage.Size2D = new Size2D((int)(((curValue - warningStartValue) / 100) * this.Size2D.Width), (int)curTrackThickness);
                }
                else if (direction == DirectionType.Vertical)
                {
                    warningSlidedTrackImage.Size2D = new Size2D((int)curTrackThickness, (int)(((curValue - warningStartValue) / 100) * this.Size2D.Height));
                }

                if (warningThumbColor != null && thumbImage.Color.NotEqualTo(warningThumbColor))
                {
                    thumbImage.Color = warningThumbColor;
                }
                if (warningThumbImageUrl != null && !thumbImage.ResourceUrl.Equals(warningThumbImageUrl))
                {
                    thumbImage.ResourceUrl = warningThumbImageUrl;
                }
            }
            else
            {
                warningSlidedTrackImage.Size2D = new Size2D(0, 0);
                if (warningThumbColor != null && thumbImage.Color.EqualTo(warningThumbColor))
                {
                    thumbImage.Color = thumbColor;
                }
                if (warningThumbImageUrl != null && thumbImage.ResourceUrl.Equals(warningThumbImageUrl))
                {
                    thumbImage.ResourceUrl = thumbImageUrl;
                }
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
                if (ViewStyle is SliderStyle sliderStyle && sliderStyle.TrackThickness != null)
                {
                    curTrackThickness = sliderStyle.TrackThickness.Value;
                }
            }
            return curTrackThickness;
        }

        private uint CurrentSpaceBetweenTrackAndIndicator()
        {
            uint curSpace = 0;
            if (spaceBetweenTrackAndIndicator != null)
            {
                curSpace = spaceBetweenTrackAndIndicator.Start;
            }
            else
            {
                if (ViewStyle is SliderStyle sliderStyle && sliderStyle.TrackPadding != null)
                {
                    curSpace = sliderStyle.TrackPadding.Start;
                }
            }
            return curSpace;
        }

        private void UpdateWarningTrackSize()
        {
            if (warningTrackImage == null)
            {
                return;
            }

            int curTrackThickness = (int)CurrentTrackThickness();
            float warningTrackLength = maxValue - warningStartValue;
            if (direction == DirectionType.Horizontal)
            {
                warningTrackLength = (warningTrackLength / 100) * this.Size2D.Width;
                warningTrackImage.Size2D = new Size2D((int)warningTrackLength, curTrackThickness);
            }
            else if (direction == DirectionType.Vertical)
            {
                warningTrackLength = (warningTrackLength / 100) * this.Size2D.Height;
                warningTrackImage.Size2D = new Size2D(curTrackThickness, (int)warningTrackLength);
            }
        }

        private IndicatorType CurrentIndicatorType()
        {
            IndicatorType type = IndicatorType.None;
            if (ViewStyle is SliderStyle sliderStyle)
            {
                type = (IndicatorType)sliderStyle.IndicatorType;
            }
            return type;
        }

        private Size LowIndicatorImageSize()
        {
            Size size = new Size(0, 0);
            if (lowIndicatorSize != null)
            {
                size = lowIndicatorSize;
            }
            else
            {
                if (ViewStyle is SliderStyle sliderStyle && sliderStyle.LowIndicatorImage != null && sliderStyle.LowIndicatorImage.Size != null)
                {
                    size = sliderStyle.LowIndicatorImage.Size;
                }
            }
            return size;
        }

        private Size HighIndicatorImageSize()
        {
            Size size = new Size(0, 0);
            if (highIndicatorSize != null)
            {
                size = highIndicatorSize;
            }
            else
            {
                if (ViewStyle is SliderStyle sliderStyle && sliderStyle.HighIndicatorImage != null && sliderStyle.HighIndicatorImage.Size != null)
                {
                    size = sliderStyle.HighIndicatorImage.Size;
                }
            }
            return size;
        }

        private Size LowIndicatorTextSize()
        {
            Size size = new Size(0, 0);
            if (lowIndicatorSize != null)
            {
                size = lowIndicatorSize;
            }
            else
            {
                if (ViewStyle is SliderStyle sliderStyle && sliderStyle.LowIndicator != null && sliderStyle.LowIndicator.Size != null)
                {
                    size = sliderStyle.LowIndicator.Size;
                }
            }
            return size;
        }

        private Size HighIndicatorTextSize()
        {
            Size size = new Size(0, 0);
            if (highIndicatorSize != null)
            {
                size = highIndicatorSize;
            }
            else
            {
                if (ViewStyle is SliderStyle sliderStyle && sliderStyle.HighIndicator != null && sliderStyle.HighIndicator.Size != null)
                {
                    size = sliderStyle.HighIndicator.Size;
                }
            }
            return size;
        }
    }
}
