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
    /// The ScrollBar class of nui component. It allows users to recognize the direction and the range of lists/content. .
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollBar : Control
    {
        private ScrollBarAttributes scrollBarAttrs;
        private ImageView trackImage;
        private ImageView thumbImage;
        private Animation scrollAniPlayer = null;
        private float thumbImagePosX;
        private float thumbImagePosY;
        private bool enableAni = false;
        private int minValue;
        private int maxValue;
        private int curValue;

        /// <summary>
        /// The constructor of ScrollBar
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar() : base()
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of ScrollBar with specific style.
        /// </summary>
        /// <param name="style">style name</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of ScrollBar with specific Attributes.
        /// </summary>
        /// <param name="attributes">The Attributes object to initialize the ScrollBar.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar(ScrollBarAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// The direction type of the Scroll.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum DirectionType
        {
            /// <summary>
            /// The Horizontal type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Horizontal,

            /// <summary>
            /// The Vertical type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Vertical
        }

        #region public property 

        /// <summary>
        /// The property to get/set the direction of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DirectionType Direction
        {
            get
            {
                return scrollBarAttrs.Direction.Value;
            }
            set
            {
                scrollBarAttrs.Direction = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set the size of the thumb object.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throw when ThumbSize is null.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// try
        /// {
        ///     scroll.ThumbSize = new Size(500, 10, 0);
        /// }
        /// catch(InvalidOperationException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set ThumbSize value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D ThumbSize
        {
            get
            {
                if (scrollBarAttrs.ThumbImageAttributes.Size2D == null)
                {
                    scrollBarAttrs.ThumbImageAttributes.Size2D = new Size2D();
                }
                return scrollBarAttrs.ThumbImageAttributes.Size2D;
            }
            set
            {
                if (scrollBarAttrs.ThumbImageAttributes.Size2D == null)
                {
                    scrollBarAttrs.ThumbImageAttributes.Size2D = new Size2D();
                }
                if (thumbImage != null)
                {
                    scrollBarAttrs.ThumbImageAttributes.Size2D.Width = value.Width;
                    scrollBarAttrs.ThumbImageAttributes.Size2D.Height = value.Height;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the image URL of the track object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TrackImageURL
        {
            get
            {
                return scrollBarAttrs.TrackImageAttributes.ResourceUrl.All;
            }
            set
            {
                if (trackImage != null)
                {
                    if (scrollBarAttrs.TrackImageAttributes.ResourceUrl == null)
                    {
                        scrollBarAttrs.TrackImageAttributes.ResourceUrl = new StringSelector();
                    }
                    scrollBarAttrs.TrackImageAttributes.ResourceUrl.All = value;
                }
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set the color of the track object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TrackColor
        {
            get
            {
                return scrollBarAttrs.TrackImageAttributes.BackgroundColor?.All;
            }
            set
            {
                if (scrollBarAttrs.TrackImageAttributes.BackgroundColor == null)
                {
                    scrollBarAttrs.TrackImageAttributes.BackgroundColor = new ColorSelector { All = value };
                }
                else
                {
                    scrollBarAttrs.TrackImageAttributes.BackgroundColor.All = value;
                }
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set the color of the thumb object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ThumbColor
        {
            get
            {
                return scrollBarAttrs.ThumbImageAttributes.BackgroundColor?.All;
            }
            set
            {
                if(scrollBarAttrs.ThumbImageAttributes.BackgroundColor == null)
                {
                    scrollBarAttrs.ThumbImageAttributes.BackgroundColor = new ColorSelector { All = value };
                }
                else
                {
                    scrollBarAttrs.ThumbImageAttributes.BackgroundColor.All = value;
                }
                RelayoutRequest();
            }
        }

        /// <summary>
        /// The property to get/set the max value of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                if(value >= 0)
                {
                    maxValue = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the min value of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                if(value >= 0)
                {
                    minValue = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the current value of the ScrollBar.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when Current value is less than Min value, or greater than Max value.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// scroll.MaxValue = 100;
        /// scroll.MinValue = 0;
        /// try
        /// {
        ///     scroll.CurrentValue = 50;
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set Current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentValue
        {
            get
            {
                return curValue;
            }
            set
            {
                if(value >= 0)
                {
                    curValue = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Property to set/get animation duration.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Duration
        {
            get
            {
                return scrollBarAttrs.Duration;
            }
            set
            {
                scrollBarAttrs.Duration = value;
                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Duration = (int)value;
                }
            }
        }
        #endregion

        /// <summary>
        /// Method to set current value. The thumb object would move to the corresponding position with animation or not.
        /// </summary>
        /// <param name="currentValue">The special current value.</param>
        /// <param name="isEnableAni">Enable move with animation or not, the default value is true.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when current size is less than the min value, or greater than the max value.</exception>
        /// <example>
        /// <code>
        /// ScrollBar scroll;
        /// scroll.MinValue = 0;
        /// scroll.MaxValue = 100;
        /// try
        /// {
        ///     scroll.SetCurrentValue(50);
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set current value : " + e.Message);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCurrentValue(int currentValue, bool isEnableAni = true)
        {
            if (currentValue < minValue || currentValue > maxValue)
            {
                //TNLog.E("Current value is less than the Min value, or greater than the Max value. currentValue = " + currentValue + ";");
                throw new ArgumentOutOfRangeException("Wrong Current value. It shoud be greater than the Min value, and less than the Max value!");
            }

            enableAni = isEnableAni;
            CurrentValue = currentValue;
        }

        /// <summary>
        /// Dispose ScrollBar.
        /// </summary>
        /// <param name="type">The DisposeTypes value.</param>
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
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

                if (trackImage != null)
                {
                    Utility.Dispose(trackImage);
                }

                if (thumbImage != null)
                {
                    Utility.Dispose(thumbImage);
                }

                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Stop();
                    scrollAniPlayer.Clear();
                    scrollAniPlayer.Dispose();
                    scrollAniPlayer = null;
                }
                // UIDirectionChangedEvent -= OnUIDirectionChangedEvent;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            //Unreference this from if a static instance refer to this. 

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// The method to update Attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            ApplyAttributes(this, scrollBarAttrs);
            ApplyAttributes(trackImage, scrollBarAttrs.TrackImageAttributes);
            ApplyAttributes(thumbImage, scrollBarAttrs.ThumbImageAttributes);
            if (enableAni)
            {
                UpdateValue(true);
                enableAni = false;
            }
            else
            {
                UpdateValue();
            }
        }

        /// <summary>
        /// Get Scrollbar attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ScrollBarAttributes()
            {
                ThumbImageAttributes = new ImageAttributes
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                },
                TrackImageAttributes = new ImageAttributes
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                }

            };
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            ScrollBarAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as ScrollBarAttributes;
            if (tempAttributes != null)
            {
                attributes = scrollBarAttrs = tempAttributes;
                RelayoutRequest();
            }
        }

        private void Initialize()
        {
            scrollBarAttrs = this.attributes as ScrollBarAttributes;
            if(scrollBarAttrs == null)
            {
                throw new Exception("ScrollBar attribute parse error.");
            }

            this.Focusable = false;

            trackImage = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft

            };
            thumbImage = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.Fixed,
                HeightResizePolicy = ResizePolicyType.Fixed,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft
            };

            Add(trackImage);
            Add(thumbImage);

            scrollAniPlayer = new Animation(334);
            scrollAniPlayer.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);

            thumbImagePosX = 0;
            thumbImagePosY = 0;
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            RelayoutRequest();
        }

        private void UpdateValue(bool enableAni = false)
        {
            if (trackImage == null || thumbImage == null || scrollBarAttrs.Direction == null)
            {             
                return;
            }

            if (minValue >= maxValue || curValue < minValue || curValue > maxValue)
            {
                return;
            }
            float width = (float)Size2D.Width;
            float height = (float)Size2D.Height;
            float thumbW = 0.0f;
            float thumbH = 0.0f;
            if (scrollBarAttrs.ThumbImageAttributes.Size2D == null)
            {
                return;
            }
            else
            {
                thumbW = scrollBarAttrs.ThumbImageAttributes.Size2D.Width;
                thumbH = scrollBarAttrs.ThumbImageAttributes.Size2D.Height;
            }
            float ratio = (float)(curValue - minValue) / (float)(maxValue - minValue);

            if (scrollBarAttrs.Direction == DirectionType.Horizontal)
            {
                if (LayoutDirection == ViewLayoutDirectionType.RTL)
                {
                    ratio = 1.0f - ratio;
                }

                float posX = ratio * (width - thumbW);
                float posY = (height - thumbH) / 2.0f;

                thumbImagePosX = posX;
                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Stop();
                }

                if (!enableAni)
                {
                    thumbImage.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (scrollAniPlayer != null)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(thumbImage, "PositionX", posX);
                        scrollAniPlayer.Play();
                    }
                }
            }
            else
            {
                float posX = (width - thumbW) / 2.0f;
                float posY = ratio * (height - thumbH);

                thumbImagePosY = posY;
                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Stop();
                }

                if (!enableAni)
                {
                    thumbImage.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (scrollAniPlayer != null)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(thumbImage, "PositionY", posY);
                        scrollAniPlayer.Play();
                    }
                }
            }
        }

        private DirectionType CurrentDirection()
        {
            DirectionType dir = DirectionType.Horizontal;
            if (scrollBarAttrs != null)
            {
                if (scrollBarAttrs.Direction != null)
                {
                    dir = scrollBarAttrs.Direction.Value;
                }
            }
            return dir;
        }

        private int CalculateCurrentValue(float offset, DirectionType dir)
        {
            if (dir == DirectionType.Horizontal)
            {
                thumbImagePosX += offset;
                if (thumbImagePosX < 0)
                {
                    thumbImage.PositionX = 0;
                    curValue = minValue;
                }
                else if (thumbImagePosX > Size2D.Width - thumbImage.Size2D.Width)
                {
                    thumbImage.PositionX = Size2D.Width - thumbImage.Size2D.Width;
                    curValue = maxValue;
                }
                else
                {
                    thumbImage.PositionX = thumbImagePosX;
                    curValue = (int)((thumbImagePosX / (float)(Size2D.Width - thumbImage.Size2D.Width)) * (float)(maxValue - minValue) + 0.5f);
                }
            }
            else
            {
                thumbImagePosY += offset;
                if (thumbImagePosY < 0)
                {
                    thumbImage.PositionY = 0;
                    curValue = minValue;
                }
                else if (thumbImagePosY > Size2D.Height - thumbImage.Size2D.Height)
                {
                    thumbImage.PositionY = Size2D.Height - thumbImage.Size2D.Height;
                    curValue = maxValue;
                }
                else
                {
                    thumbImage.PositionY = thumbImagePosY;
                    curValue = (int)((thumbImagePosY / (float)(Size2D.Height - thumbImage.Size2D.Height)) * (float)(maxValue - minValue) + 0.5f);
                }
            }

            return (int)curValue;
        }
    }
}
