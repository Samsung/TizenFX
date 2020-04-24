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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DirectionProperty = BindableProperty.Create(nameof(Direction), typeof(DirectionType), typeof(ScrollBar), DirectionType.Horizontal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                instance.direction = (DirectionType)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return instance.direction;
        });
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(ScrollBar), default(int), propertyChanged: (bindable, oldValue, newValue) =>
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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(int), typeof(ScrollBar), default(int), propertyChanged: (bindable, oldValue, newValue) =>
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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(int), typeof(ScrollBar), default(int), propertyChanged: (bindable, oldValue, newValue) =>
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
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DurationProperty = BindableProperty.Create(nameof(Duration), typeof(uint), typeof(ScrollBar), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ScrollBar)bindable;
            if (newValue != null)
            {
                if (instance.scrollAniPlayer != null)
                {
                    instance.scrollAniPlayer.Duration = (int)(uint)newValue;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ScrollBar)bindable;
            return (uint)instance.scrollAniPlayer?.Duration;
        });

        private Animation scrollAniPlayer = null;
        private ImageView trackImage;
        private ImageView thumbImage;
        private float thumbImagePosX;
        private float thumbImagePosY;
        private bool enableAni = false;
        private int minValue;
        private int maxValue;
        private int curValue;
        private DirectionType direction;
        static ScrollBar() { }

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
        /// <since_tizen> 8 </since_tizen>
        public ScrollBar(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of ScrollBar with specific style.
        /// </summary>
        /// <param name="scrollBarStyle">The style object to initialize the ScrollBar.</param>
        /// <since_tizen> 8 </since_tizen>
        public ScrollBar(ScrollBarStyle scrollBarStyle) : base(scrollBarStyle)
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
        /// <summary>
        /// Return a copied Style instance of Scrollbar
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Scrollbar.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public new ScrollBarStyle Style
        {
            get
            {
                return new ScrollBarStyle(ViewStyle as ScrollBarStyle);
            }
        }

        /// <summary>
        /// Return ImageView instance of background
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView TrackImage
        {
            get
            {
                if (null == trackImage)
                {
                    trackImage = new ImageView()
                    {
                        Focusable = false,
                        PositionUsesPivotPoint = true,
                        ParentOrigin = NUI.ParentOrigin.CenterLeft,
                        PivotPoint = NUI.ParentOrigin.CenterLeft,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    Add(trackImage);
                }
                return trackImage;
            }
            set
            {
                trackImage = value;
            }
        }

        /// <summary>
        /// Return ImageView instance of travelling thumbnail
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView ThumbImage
        {
            get
            {
                if (null == thumbImage)
                {
                    thumbImage = new ImageView()
                    {
                        Focusable = false,
                        PositionUsesPivotPoint = true,
                        ParentOrigin = NUI.ParentOrigin.CenterLeft,
                        PivotPoint = NUI.ParentOrigin.CenterLeft,
                        WidthResizePolicy = ResizePolicyType.Fixed,
                        HeightResizePolicy = ResizePolicyType.Fixed
                    };
                    Add(thumbImage);
                }
                return thumbImage;
            }
            set
            {
                thumbImage = value;
            }
        }

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
                return ThumbImage.Size;
            }
            set
            {
                ThumbImage.Size = value;
                RelayoutRequest();
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
                return TrackImage.ResourceUrl;
            }
            set
            {
                TrackImage.ResourceUrl = value;
                RelayoutRequest();
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
                return TrackImage.BackgroundColor;
            }
            set
            {
                TrackImage.BackgroundColor = value;
                RelayoutRequest();
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
                return ThumbImage.BackgroundColor;
            }
            set
            {
                ThumbImage.BackgroundColor = value;
                RelayoutRequest();
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
        /// <param name="enableAnimation">Enable move with animation or not, the default value is true.</param>
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
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentOutOfRangeException("Wrong Current value. It shoud be greater than the Min value, and less than the Max value!");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            enableAni = enableAnimation;
            CurrentValue = currentValue;
        }

        /// <summary>
        /// Apply style to ScrollBar.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);
            ScrollBarStyle sbStyle = viewStyle as ScrollBarStyle;
            if (null != sbStyle)
            {
                TrackImage.ApplyStyle(sbStyle.Track);
                ThumbImage.ApplyStyle(sbStyle.Thumb);
                UpdateValue();
            }
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
        /// <returns>The default scrollbar style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle GetViewStyle()
        {
            return new ScrollBarStyle();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        /// <since_tizen> 8 </since_tizen>
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
            Duration = Style.Duration;

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

            float width = Size.Width;
            float height = Size.Height;
            float thumbW = 0.0f;
            float thumbH = 0.0f;
            if (ThumbImage.Size == null)
            {
                return;
            }
            else
            {
                thumbW = ThumbImage.Size.Width;
                thumbH = ThumbImage.Size.Height;
            }
            float ratio = (float)(curValue - minValue) / (float)(maxValue - minValue);

            if (Direction == DirectionType.Horizontal)
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
                    ThumbImage.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (null != scrollAniPlayer)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(ThumbImage, "PositionX", posX);
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
                    ThumbImage.Position = new Position(posX, posY, 0);
                }
                else
                {
                    if (null != scrollAniPlayer)
                    {
                        scrollAniPlayer.Clear();
                        scrollAniPlayer.AnimateTo(ThumbImage, "PositionY", posY);
                        scrollAniPlayer.Play();
                    }
                }
            }

            if (enableAni) enableAni = false;
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
                else if (thumbImagePosX > Size.Width - thumbImage.Size.Width)
                {
                    thumbImage.PositionX = Size.Width - thumbImage.Size.Width;
                    curValue = maxValue;
                }
                else
                {
                    thumbImage.PositionX = thumbImagePosX;
                    curValue = (int)((thumbImagePosX / (float)(Size.Width - thumbImage.Size.Width)) * (float)(maxValue - minValue) + 0.5f);
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
                else if (thumbImagePosY > Size.Height - thumbImage.Size.Height)
                {
                    thumbImage.PositionY = Size.Height - thumbImage.Size.Height;
                    curValue = maxValue;
                }
                else
                {
                    thumbImage.PositionY = thumbImagePosY;
                    curValue = (int)((thumbImagePosY / (float)(Size.Height - thumbImage.Size.Height)) * (float)(maxValue - minValue) + 0.5f);
                }
            }

            return curValue;
        }
    }
}
