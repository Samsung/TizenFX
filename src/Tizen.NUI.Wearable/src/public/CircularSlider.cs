/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using System.ComponentModel;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// Value Changed event data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularSliderValueChangedEventArgs : EventArgs
    {
        private float currentValue = 0.0f;

        /// <summary>
        /// Current value
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }
    }

    /// <summary>
    /// The CircularSlider class of Wearable is used to let users select a value from a continuous or discrete range of values by moving the slider thumb.
    /// CircularSlider shows the current value with the length of the line.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularSlider : Control
    {
        #region Fields

        /// <summary>Bindable property of Thickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(float), typeof(CircularSlider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((CircularSlider)bindable);
            instance.CurrentStyle.Thickness = (float)newValue;
            instance.UpdateVisualThickness((float)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSlider)bindable).CurrentStyle.Thickness;
        });

        /// <summary>Bindable property of MaxValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(float), typeof(CircularSlider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularSlider)bindable;
            if (newValue != null)
            {
                instance.maxValue = (float)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CircularSlider)bindable;
            return instance.maxValue;
        });

        /// <summary>Bindable property of MinValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(float), typeof(CircularSlider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularSlider)bindable;
            if (newValue != null)
            {
                instance.minValue = (float)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CircularSlider)bindable;
            return instance.minValue;
        });

        /// <summary>Bindable property of CurrentValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(float), typeof(CircularSlider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularSlider)bindable;
            if (newValue != null)
            {
                if ((float)newValue > instance.maxValue || (float)newValue < instance.minValue)
                {
                    return;
                }
                instance.currentValue = (float)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CircularSlider)bindable;
            return instance.currentValue;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(CircularSlider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularSlider)bindable;
            instance.CurrentStyle.TrackColor = (Color)newValue;
            instance.UpdateTrackVisualColor((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSlider)bindable).CurrentStyle.TrackColor;
        });

        /// <summary>Bindable property of ProgressColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularSlider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularSlider)bindable;
            instance.CurrentStyle.ProgressColor = (Color)newValue;
            instance.UpdateProgressVisualColor((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSlider)bindable).CurrentStyle.ProgressColor;
        });

        /// <summary>Bindable property of ThumbSize</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbSizeProperty = BindableProperty.Create(nameof(ThumbSize), typeof(Size), typeof(CircularSlider), new Size(0,0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularSlider)bindable;
            if (newValue != null)
            {
                instance.thumbSize = (Size)newValue;
                instance.UpdateThumbVisualSize((Size)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CircularSlider)bindable;
            return instance.thumbSize;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(CircularSlider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularSlider)bindable;
            instance.CurrentStyle.ThumbColor = (Color)newValue;
            instance.UpdateThumbVisualColor((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSlider)bindable).CurrentStyle.ThumbColor;
        });

        /// <summary>Bindable property of IsEnabled</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(CircularSlider), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularSlider)bindable;
            if (newValue != null)
            {
                instance.privateIsEnabled = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CircularSlider)bindable;
            return instance.privateIsEnabled;
        });

        private const string TrackVisualName = "Track";
        private const string ProgressVisualName = "Progress";
        private const string ThumbVisualName = "Thumb";
        private ArcVisual trackVisual;
        private ArcVisual progressVisual;
        private ArcVisual thumbVisual;

        private float maxValue = 100;
        private float minValue = 0;
        private float currentValue = 0;
        private Size thumbSize;
        private bool isEnabled = true;

        float sliderPadding = 6.0f;

        private Animation sweepAngleAnimation;
        private Animation thumbAnimation;

        #endregion Fields


        #region Constructors

        static CircularSlider()
        {
            ThemeManager.AddPackageTheme(DefaultThemeCreator.Instance);
        }

        /// <summary>
        /// The constructor of CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularSlider() : base()
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the CircularSlider class with specific style.
        /// </summary>
        /// <param name="progressStyle">The style object to initialize the CircularSlider.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularSlider(CircularSliderStyle progressStyle) : base(progressStyle)
        {
            Initialize();
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// The value changed event handler.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<CircularSliderValueChangedEventArgs> ValueChanged;

        #endregion Events

        #region Properties

        /// <summary>
        /// The thickness of the track and progress.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Thickness
        {
            get
            {
                return (float)GetValue(ThicknessProperty);
            }
            set
            {
                SetValue(ThicknessProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set the maximum value of the CircularSlider.
        /// The default value is 100.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaxValue
        {
            get
            {
                return (float)GetValue(MaxValueProperty);
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set the minimum value of the CircularSlider.
        /// The default value is 0.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinValue
        {
            get
            {
                return (float)GetValue(MinValueProperty);
            }
            set
            {
                SetValue(MinValueProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set the current value of the CircularSlider.
        /// The default value is 0.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CurrentValue
        {
            get
            {
                return (float)GetValue(CurrentValueProperty);
            }
            set
            {
                if (sweepAngleAnimation)
                {
                    sweepAngleAnimation.Stop();
                }
                // For the first Animation effect
                sweepAngleAnimation = AnimateVisual(progressVisual, "sweepAngle", progressVisual.SweepAngle, 0, 100, AlphaFunction.BuiltinFunctions.EaseIn);

                SetValue(CurrentValueProperty, value);

                UpdateAnimation();
            }
        }

        /// <summary>
        /// The property to get/set Track object color of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TrackColor
        {
            get
            {
                return (Color)GetValue(TrackColorProperty);
            }
            set
            {
                SetValue(TrackColorProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set Progress object color of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ProgressColor
        {
            get
            {
                return (Color)GetValue(ProgressColorProperty);
            }
            set
            {
                SetValue(ProgressColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the thumb of Slider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ThumbSize
        {
            get
            {
                return (Size)GetValue(ThumbSizeProperty);
            }
            set
            {
                SetValue(ThumbSizeProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set Thumb object color of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ThumbColor
        {
            get
            {
                return (Color)GetValue(ThumbColorProperty);
            }
            set
            {
                SetValue(ThumbColorProperty, value);
            }
        }

        /// <summary>
        /// Flag to be enabled or disabled in CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEnabled
        {
            get
            {
                return (bool)GetValue(IsEnabledProperty);
            }
            set
            {
                SetValue(IsEnabledProperty, value);
            }
        }
        private bool privateIsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                if (isEnabled)
                {
                    UpdateTrackVisualColor(new Color(0.0f, 0.16f, 0.30f, 1.0f)); // #002A4D
                }
                else
                {
                    UpdateTrackVisualColor(new Color(0.25f, 0.25f, 0.25f, 1.0f)); // #404040
                }
            }
        }

        private CircularSliderStyle CurrentStyle => ViewStyle as CircularSliderStyle;

        #endregion Properties


        #region Methods

        /// <summary>
        /// Dispose Progress and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                trackVisual = null;
                progressVisual = null;
                thumbVisual = null;
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update progress value
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateValue()
        {
            if (null == trackVisual || null == progressVisual || null == thumbVisual)
            {
                return;
            }

            if (minValue >= maxValue || currentValue < minValue || currentValue > maxValue)
            {
                return;
            }

            HandleProgressVisualVisibility();

            UpdateProgressVisualSweepAngle();
        }

        /// <summary>
        /// Get Progress style.
        /// </summary>
        /// <returns>The default progress style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new CircularSliderStyle();
        }

        private void Initialize()
        {
            Size = new Size(360.0f, 360.0f);

            sweepAngleAnimation?.Stop();
            sweepAngleAnimation = null;

            thumbAnimation?.Stop();
            thumbAnimation = null;

            trackVisual = new ArcVisual
            {
                SuppressUpdateVisual = true,
                Size = new Size(this.Size.Width - sliderPadding, this.Size.Height - sliderPadding),
                SizePolicy = VisualTransformPolicyType.Absolute,
                Thickness = this.Thickness,
                Cap = ArcVisual.CapType.Butt,
                MixColor = TrackColor,
                StartAngle = 0.0f,
                SweepAngle = 360.0f
            };
            this.AddVisual(TrackVisualName, trackVisual);

            progressVisual = new ArcVisual
            {
                SuppressUpdateVisual = true,
                Size = new Size(this.Size.Width - sliderPadding, this.Size.Height - sliderPadding),
                SizePolicy = VisualTransformPolicyType.Absolute,
                Thickness = this.Thickness,
                Cap = ArcVisual.CapType.Butt,
                MixColor = ProgressColor,
                StartAngle = 0.0f,
                SweepAngle = 0.0f
            };
            this.AddVisual(ProgressVisualName, progressVisual);

            thumbVisual = new ArcVisual
            {
                SuppressUpdateVisual = true,
                Size = new Size(this.Size.Width + sliderPadding, this.Size.Height + sliderPadding),
                SizePolicy = VisualTransformPolicyType.Absolute,
                Thickness = this.ThumbSize.Width,
                Cap = ArcVisual.CapType.Round,
                MixColor = this.ThumbColor,
                StartAngle = 0.0f,
                SweepAngle = 0.0f
            };
            this.AddVisual(ThumbVisualName,  thumbVisual);

            HandleProgressVisualVisibility();

            UpdateProgressVisualSweepAngle();
        }

        private void HandleProgressVisualVisibility()
        {
            if (isEnabled)
            {
                progressVisual.Opacity = 1.0f;
            }
            else if (!isEnabled)
            {
                progressVisual.Opacity = 0.6f;
            }
        }

        private void UpdateVisualThickness(float thickness)
        {
            if (trackVisual == null)
            {
                return;
            }

            trackVisual.Thickness = thickness;
            progressVisual.Thickness = thickness;

            trackVisual.UpdateVisual(true);
            progressVisual.UpdateVisual(true);
        }

        private void UpdateProgressVisualSweepAngle()
        {
            float progressRatio = (float)(currentValue - minValue) / (float)(maxValue - minValue);
            float progressWidth = 360.0f * progressRatio; // Circle

            progressVisual.SweepAngle = progressWidth;
            thumbVisual.StartAngle = progressWidth;

            if (!sweepAngleAnimation)
            {
                progressVisual.UpdateVisual(true);
                thumbVisual.UpdateVisual(true);
            }
        }

        private void UpdateAnimation()
        {
            // TODO : Currently not sure which effect is needed.
            AlphaFunction.BuiltinFunctions builtinAlphaFunction = AlphaFunction.BuiltinFunctions.EaseOut;

            if (sweepAngleAnimation)
            {
                sweepAngleAnimation.Stop();
            }
            if (thumbAnimation)
            {
                thumbAnimation.Stop();
            }

            sweepAngleAnimation = AnimateVisual(progressVisual, "sweepAngle", progressVisual.SweepAngle, 0, 500, builtinAlphaFunction);
            thumbAnimation = AnimateVisual(thumbVisual, "startAngle", thumbVisual.StartAngle, 0, 500, builtinAlphaFunction);

            if (sweepAngleAnimation)
            {
                sweepAngleAnimation.Play();
                thumbAnimation.Play();
            }

            ValueChanged?.Invoke(this, new CircularSliderValueChangedEventArgs() { CurrentValue = currentValue });
        }

        private void UpdateTrackVisualColor(Color trackColor)
        {
            if (trackVisual == null)
            {
                return;
            }

            trackVisual.MixColor = trackColor;
            trackVisual.UpdateVisual(true);
        }

        private void UpdateProgressVisualColor(Color progressColor)
        {
            if (progressVisual == null)
            {
                return;
            }

            progressVisual.MixColor = progressColor;
            if (!isEnabled) // Dim state
            {
                progressVisual.Opacity = 0.6f;
            }

            progressVisual.UpdateVisual(true);
        }

        private void UpdateThumbVisualSize(Size thumbSize)
        {
            if (thumbVisual == null)
            {
                return;
            }

            thumbVisual.Thickness = thumbSize.Width;
            thumbVisual.UpdateVisual(true);
        }

        private void UpdateThumbVisualColor(Color thumbColor)
        {
            if (thumbVisual == null)
            {
                return;
            }

            thumbVisual.MixColor = thumbColor;
            thumbVisual.UpdateVisual(true);
        }


        #endregion Methods
    }
}
