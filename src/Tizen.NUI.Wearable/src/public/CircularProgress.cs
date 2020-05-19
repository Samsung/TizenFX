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
    /// The CircularProgress class of Wearable is used to show the ongoing status with a circular bar.
    /// CircularProgress can be counted in its percentage.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularProgress : Control
    {
        #region Fields

        /// <summary>Bindable property of Thickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(float), typeof(CircularProgress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((CircularProgress)bindable);

            // TODO Set viewStyle.Thickness after style refactoring done.

            instance.UpdateVisualThickness((float)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularProgressStyle)((CircularProgress)bindable).viewStyle)?.Thickness;
        });

        /// <summary>Bindable property of MaxValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(float), typeof(CircularProgress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularProgress)bindable;
            if (newValue != null)
            {
                instance.maxValue = (float)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CircularProgress)bindable;
            return instance.maxValue;
        });

        /// <summary>Bindable property of MinValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(float), typeof(CircularProgress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularProgress)bindable;
            if (newValue != null)
            {
                instance.minValue = (float)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CircularProgress)bindable;
            return instance.minValue;
        });

        /// <summary>Bindable property of CurrentValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create("currentValue", typeof(float), typeof(CircularProgress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularProgress)bindable;
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
            var instance = (CircularProgress)bindable;
            return instance.currentValue;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create("trackColor", typeof(Color), typeof(CircularProgress), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularProgress)bindable;

            // TODO : Set viewStyle.TrackColor after style refactoring done.

            instance.UpdateTrackVisualColor((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularProgressStyle)((CircularProgress)bindable).viewStyle)?.TrackColor;
        });

        /// <summary>Bindable property of ProgressColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create("progressColor", typeof(Color), typeof(CircularProgress), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularProgress)bindable;

            // TODO : Set viewStyle.ProgressColor after style refactoring done.

            instance.UpdateProgressVisualColor((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularProgressStyle)((CircularProgress)bindable).viewStyle)?.ProgressColor;
        });

        /// <summary>Bindable property of IsEnabled</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(CircularProgress), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CircularProgress)bindable;
            if (newValue != null)
            {
                instance.privateIsEnabled = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CircularProgress)bindable;
            return instance.privateIsEnabled;
        });

        private static readonly string TrackVisualName = "Track";
        private static readonly string ProgressVisualName = "Progress";
        private ArcVisual trackVisual;
        private ArcVisual progressVisual;

        private float maxValue = 100;
        private float minValue = 0;
        private float currentValue = 0;
        private bool isEnabled = true;


        /// <summary>
        /// Get style of progress.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new CircularProgressStyle Style => ViewStyle as CircularProgressStyle;

        #endregion Fields


        #region Constructors

        static CircularProgress() { }
        /// <summary>
        /// The constructor of CircularProgress.
        /// Basically, CircularProgress is for full screen. (360 x 360)
        /// But, it also can be displayed on the button or the list for small size.
        /// User can set its size.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularProgress() : base(new CircularProgressStyle())
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the CircularProgress class with specific style.
        /// </summary>
        /// <param name="style">style name</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularProgress(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the CircularProgress class with specific style.
        /// </summary>
        /// <param name="progressStyle">The style object to initialize the CircularProgress.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularProgress(CircularProgressStyle progressStyle) : base(progressStyle)
        {
            Initialize();
        }

        #endregion Constructors


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
        /// The property to get/set the maximum value of the CircularProgress.
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
        /// The property to get/set the minim value of the CircularProgress.
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
        /// The property to get/set the current value of the CircularProgress.
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
                SetValue(CurrentValueProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set Track object color of the CircularProgress.
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
        /// The property to get/set Progress object color of the CircularProgress.
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
        /// Flag to be enabled or disabled in CircularProgress.
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
                if(isEnabled)
                {
                    UpdateTrackVisualColor(new Color(0.0f, 0.16f, 0.30f, 1.0f)); // #002A4D
                }
                else
                {
                    UpdateTrackVisualColor(new Color(0.25f, 0.25f, 0.25f, 1.0f)); // #404040
                }
            }
        }

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
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update progress value
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateValue()
        {
            if (null == trackVisual || null == progressVisual)
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
        protected override ViewStyle GetViewStyle()
        {
            return new CircularProgressStyle();
        }


        private void Initialize()
        {
            Size = new Size(360.0f, 360.0f);

            trackVisual = new ArcVisual
            {
                Thickness = this.Thickness,
                Cap = ArcVisual.CapType.Butt,
                MixColor = TrackColor,
                StartAngle = 0.0f,
                SweepAngle = 360.0f
            };
            this.AddVisual(TrackVisualName, trackVisual);

            progressVisual = new ArcVisual
            {
                Thickness = this.Thickness,
                Cap = ArcVisual.CapType.Butt,
                MixColor = ProgressColor,
                StartAngle = 0.0f,
            };
            this.AddVisual(ProgressVisualName, progressVisual);

            HandleProgressVisualVisibility();

            UpdateProgressVisualSweepAngle();
        }

        private void HandleProgressVisualVisibility()
        {
            if (minValue == currentValue)
            {
                progressVisual.Opacity = 0.0f;
            }
            else if (isEnabled)
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

            trackVisual.UpdateVisual();
            progressVisual.UpdateVisual();
        }

        private void UpdateProgressVisualSweepAngle()
        {
            float progressRatio = (float)(currentValue - minValue) / (float)(maxValue - minValue);
            float progressWidth = 360.0f * progressRatio; // Circle
            progressVisual.SweepAngle = progressWidth;

            progressVisual.UpdateVisual();
            //trackVisual.UpdateVisual(); // TODO : Not sure to update track visual here.
        }

        private void UpdateTrackVisualColor(Color trackColor)
        {
            if (trackVisual == null)
            {
                return;
            }

            trackVisual.MixColor = trackColor;
            trackVisual.UpdateVisual();
        }

        private void UpdateProgressVisualColor(Color progressColor)
        {
            if (progressVisual == null)
            {
                return;
            }

            progressVisual.MixColor = progressColor;
            if( !isEnabled ) // Dim state
            {
                progressVisual.Opacity = 0.6f;
            }

            progressVisual.UpdateVisual();
        }

        #endregion Methods
    }
}
