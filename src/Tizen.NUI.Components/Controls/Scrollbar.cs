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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The ScrollBar class of nui component. It allows users to recognize the direction and the range of lists/content. .
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ScrollBar : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DirectionProperty = BindableProperty.Create("Direction", typeof(DirectionType), typeof(ScrollBar), DirectionType.Horizontal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.Style.Direction = (DirectionType?)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.Style.Direction;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create("MaxValue", typeof(int), typeof(ScrollBar), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                if ((int)newValue >= 0)
                {
                    instance.maxValue = (int)newValue;
                    instance.UpdateValue();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.maxValue;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create("MinValue", typeof(int), typeof(ScrollBar), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                if ((int)newValue >= 0)
                {
                    instance.minValue = (int)newValue;
                    instance.UpdateValue();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.minValue;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create("CurrentValue", typeof(int), typeof(ScrollBar), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                if ((int)newValue >= 0)
                {
                    instance.curValue = (int)newValue;
                    instance.UpdateValue();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.curValue;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DurationProperty = BindableProperty.Create("Duration", typeof(uint), typeof(ScrollBar), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.Style.Duration = (uint)newValue;
                if (instance.scrollAniPlayer != null)
                {
                    instance.scrollAniPlayer.Duration = (int)newValue;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.Style.Duration;
        });

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
        /// The constructor of ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// The constructor of ScrollBar with specific style.
        /// </summary>
        /// <param name="style">The style object to initialize the ScrollBar.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar(ScrollBarStyle style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The direction type of the Scroll.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum DirectionType
        {
            /// <summary>
            /// The Horizontal type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Horizontal,

            /// <summary>
            /// The Vertical type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Vertical
        }

        #region public property 
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ScrollBarStyle Style => ViewStyle as ScrollBarStyle;

        /// <summary>
        /// The property to get/set the direction of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public DirectionType Direction
        {
            get
            {
                return (DirectionType)GetValue(DirectionProperty);
            }
            set
            {
                SetValue(DirectionProperty, value);
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
        public Size ThumbSize
        {
            get
            {
                return Style?.Thumb?.Size;
            }
            set
            {
                if (null != Style?.Thumb)
                {
                    Style.Thumb.Size = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the image URL of the track object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string TrackImageURL
        {
            get
            {
                return Style?.Track?.ResourceUrl?.All;
            }
            set
            {
                if (null != Style?.Track)
                {
                    Style.Track.ResourceUrl = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the color of the track object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color TrackColor
        {
            get
            {
                return Style?.Track?.BackgroundColor?.All;
            }
            set
            {
                if (null != Style?.Track)
                {
                    Style.Track.BackgroundColor = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the color of the thumb object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color ThumbColor
        {
            get
            {
                return Style?.Thumb?.BackgroundColor?.All;
            }
            set
            {
                if(null != Style?.Thumb)
                {
                    Style.Thumb.BackgroundColor = value;
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// The property to get/set the max value of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int MaxValue
        {
            get
            {
                return (int)GetValue(MaxValueProperty);
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set the min value of the ScrollBar.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int MinValue
        {
            get
            {
                return (int)GetValue(MinValueProperty);
            }
            set
            {
                SetValue(MinValueProperty, value);
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
        public int CurrentValue
        {
            get
            {
                return (int)GetValue(CurrentValueProperty);
            }
            set
            {
                SetValue(CurrentValueProperty, value);
            }
        }

        /// <summary>
        /// Property to set/get animation duration.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Duration
        {
            get
            {
                return (uint)GetValue(DurationProperty);
            }
            set
            {
                SetValue(DurationProperty, value);
            }
        }
        #endregion

        /// <summary>
        /// Method to set current value. The thumb object would move to the corresponding position with animation or not.
        /// </summary>
        /// <param name="currentValue">The special current value.</param>
        /// <param name="EnableAnimation">Enable move with animation or not, the default value is true.</param>
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
        public void SetCurrentValue(int currentValue, bool enableAnimation = true)
        {
            if (currentValue < minValue || currentValue > maxValue)
            {
                //TNLog.E("Current value is less than the Min value, or greater than the Max value. currentValue = " + currentValue + ";");
                throw new ArgumentOutOfRangeException("Wrong Current value. It shoud be greater than the Min value, and less than the Max value!");
            }

            enableAni = enableAnimation;
            CurrentValue = currentValue;
        }

        /// <summary>
        /// Dispose ScrollBar.
        /// </summary>
        /// <param name="type">The DisposeTypes value.</param>
        /// <since_tizen> 6 </since_tizen>
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

                Utility.Dispose(trackImage);
                Utility.Dispose(thumbImage);

                if (scrollAniPlayer != null)
                {
                    scrollAniPlayer.Stop();
                    scrollAniPlayer.Clear();
                    scrollAniPlayer.Dispose();
                    scrollAniPlayer = null;
                }
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            //Unreference this from if a static instance refer to this. 

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// Get Scrollbar style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new ScrollBarStyle();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            ScrollBarStyle tempStyle = StyleManager.Instance.GetViewStyle(style) as ScrollBarStyle;
            if (tempStyle != null)
            {
                Style.CopyFrom(tempStyle);
                UpdateValue();
            }
        }

        private void Initialize()
        {
            this.Focusable = false;

            trackImage = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft
            };
            this.Add(trackImage);
            trackImage.ApplyStyle(Style.Track);

            thumbImage = new ImageView
            {
                Focusable = false,
                WidthResizePolicy = ResizePolicyType.Fixed,
                HeightResizePolicy = ResizePolicyType.Fixed,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft
            };
            this.Add(thumbImage);
            thumbImage.ApplyStyle(Style.Thumb);

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

        private void UpdateValue()
        {
            if (minValue >= maxValue || curValue < minValue || curValue > maxValue) return;

            float width = (float)Size2D.Width;
            float height = (float)Size2D.Height;
            float thumbW = 0.0f;
            float thumbH = 0.0f;
            if (Style.Thumb.Size == null)
            {
                return;
            }
            else
            {
                thumbW = Style.Thumb.Size.Width;
                thumbH = Style.Thumb.Size.Height;
            }
            float ratio = (float)(curValue - minValue) / (float)(maxValue - minValue);

            if (Style.Direction == DirectionType.Horizontal)
            {
                if (LayoutDirection == ViewLayoutDirectionType.RTL)
                {
                    ratio = 1.0f - ratio;
                }

                float posX = ratio * (width - thumbW);
                float posY = (height - thumbH) / 2.0f;

                thumbImagePosX = posX;
                if (null != scrollAniPlayer)
                {
                    scrollAniPlayer.Stop();
                }

                if (!enableAni)
                {
                    thumbImage.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (null != scrollAniPlayer)
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
                if (null != scrollAniPlayer)
                {
                    scrollAniPlayer.Stop();
                }

                if (!enableAni)
                {
                    thumbImage.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (null != scrollAniPlayer)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(thumbImage, "PositionY", posY);
                        scrollAniPlayer.Play();
                    }
                }
            }

            if (enableAni) enableAni = false;
        }

        private DirectionType CurrentDirection()
        {
            DirectionType dir = DirectionType.Horizontal;
            if (null != Style.Direction)
            {
                dir = Style.Direction.Value;
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

            return curValue;
        }
    }
}
