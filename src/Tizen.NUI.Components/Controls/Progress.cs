﻿/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
using Tizen.NUI.Accessibility;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Progress class is used to show the ongoing status with a long narrow bar.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public partial class Progress : Control, IAtspiValue
    {
        private const int IndeterminateAnimationDuration = 2000;

        /// <summary>
        /// MaxValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(float), typeof(Progress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.maxValue = (float)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.maxValue;
        });

        /// <summary>
        /// MinValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(float), typeof(Progress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.minValue = (float)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.minValue;
        });

        /// <summary>
        /// CurrentValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(float), typeof(Progress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
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
            var instance = (Progress)bindable;
            return instance.currentValue;
        });

        /// <summary>
        /// BufferValueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BufferValueProperty = BindableProperty.Create(nameof(BufferValue), typeof(float), typeof(Progress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                if ((float)newValue > instance.maxValue || (float)newValue < instance.minValue)
                {
                    return;
                }
                instance.bufferValue = (float)newValue;
                instance.UpdateValue();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.bufferValue;
        });

        /// <summary>
        /// ProgressStateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressStateProperty = BindableProperty.Create(nameof(ProgressState), typeof(ProgressStatusType), typeof(Progress), ProgressStatusType.Indeterminate, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Progress)bindable;
            if (newValue != null)
            {
                instance.state = (ProgressStatusType)newValue;
                instance.UpdateStates();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Progress)bindable;
            return instance.state;
        });

        /// This needs to be considered more if public-open is necessary.
        private ProgressStatusType state = ProgressStatusType.Determinate;

        private Vector2 size = null;
        private const float round = 0.5f;
        private ImageView trackImage = null;
        private ImageView progressImage = null;
        private ImageView bufferImage = null;
        private ImageView indeterminateImage = null;
        private float maxValue = 100;
        private float minValue = 0;
        private float currentValue = 0;
        private float bufferValue = 0;
        private Animation indeterminateAnimation = null;

        static Progress() { }
        /// <summary>
        /// The constructor of Progress
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Progress() : base()
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Progress class with specific style.
        /// </summary>
        /// <param name="style">style name</param>
        /// <since_tizen> 8 </since_tizen>
        public Progress(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Progress class with specific style.
        /// </summary>
        /// <param name="progressStyle">The style object to initialize the Progress.</param>
        /// <since_tizen> 8 </since_tizen>
        public Progress(ProgressStyle progressStyle) : base(progressStyle)
        {
            Initialize();
        }

        /// <summary>
        /// The status type of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum ProgressStatusType
        {
            /// <summary>
            /// Show BufferImage
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Buffering,

            /// <summary>
            /// Show ProgressImage and BufferImage
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Determinate,

            /// <summary>
            /// Show TrackImage
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Indeterminate
        }

        /// <summary>
        /// Return currently applied style.
        /// </summary>
        /// <remarks>
        /// Modifying contents in style may cause unexpected behaviour.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public ProgressStyle Style => (ProgressStyle)(ViewStyle as ProgressStyle)?.Clone();

        /// <summary>
        /// The property to get/set Track image object URL of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string TrackImageURL
        {
            get
            {
                return GetValue(TrackImageURLProperty) as string;
            }
            set
            {
                SetValue(TrackImageURLProperty, value);
                NotifyPropertyChanged();
            }
        }
        private string InternalTrackImageURL
        {
            get => trackImage.ResourceUrl;
            set => trackImage.ResourceUrl = value;
        }

        /// <summary>
        /// The property to get/set Progress object image URL of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ProgressImageURL
        {
            get
            {
                return GetValue(ProgressImageURLProperty) as string;
            }
            set
            {
                SetValue(ProgressImageURLProperty, value);
                NotifyPropertyChanged();
            }
        }
        private string InternalProgressImageURL
        {
            get => progressImage.ResourceUrl;
            set => progressImage.ResourceUrl = value;
        }

        /// <summary>
        /// The property to get/set Buffer object image resource URL of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string BufferImageURL
        {
            get
            {
                return GetValue(BufferImageURLProperty) as string;
            }
            set
            {
                SetValue(BufferImageURLProperty, value);
                NotifyPropertyChanged();
            }
        }
        private string InternalBufferImageURL
        {
            get => bufferImage.ResourceUrl;
            set => bufferImage.ResourceUrl = value;
        }

        /// <summary>
        /// The property to get/set the indeterminate image.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// <since_tizen> 9 </since_tizen>
        public string IndeterminateImageUrl
        {
            get
            {
                return GetValue(IndeterminateImageUrlProperty) as string;
            }
            set
            {
                SetValue(IndeterminateImageUrlProperty, value);
                NotifyPropertyChanged();
            }
        }
        private string InternalIndeterminateImageUrl
        {
            get
            {
                if (indeterminateImage == null)
                {
                    return null;
                }
                else
                {
                    return indeterminateImage?.ResourceUrl;
                }
            }
            set
            {
                if (value == null || indeterminateImage == null)
                {
                    throw new NullReferenceException("Progress.IndeterminateImage is null");
                }
                else
                {
                    indeterminateImage.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set Track object color of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color TrackColor
        {
            get
            {
                return GetValue(TrackColorProperty) as Color;
            }
            set
            {
                SetValue(TrackColorProperty, value);
                NotifyPropertyChanged();
            }
        }
        private Color InternalTrackColor
        {
            get => trackImage.BackgroundColor;
            set => trackImage.BackgroundColor = value;
        }

        /// <summary>
        /// The property to get/set Progress object color of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color ProgressColor
        {
            get
            {
                return GetValue(ProgressColorProperty) as Color;
            }
            set
            {
                SetValue(ProgressColorProperty, value);
                NotifyPropertyChanged();
            }
        }
        private Color InternalProgressColor
        {
            get => progressImage.BackgroundColor;
            set => progressImage.BackgroundColor = value;
        }

        /// <summary>
        /// The property to get/set Buffer object color of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color BufferColor
        {
            get
            {
                return GetValue(BufferColorProperty) as Color;
            }
            set
            {
                SetValue(BufferColorProperty, value);
                NotifyPropertyChanged();
            }
        }
        private Color InternalBufferColor
        {
            get => bufferImage.BackgroundColor;
            set => bufferImage.BackgroundColor = value;
        }

        /// <summary>
        /// The property to get/set the maximum value of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// The property to get/set the minim value of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// The property to get/set the current value of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float CurrentValue
        {
            get
            {
                return (float)GetValue(CurrentValueProperty);
            }
            set
            {
                SetValue(CurrentValueProperty, value);
                if (Accessibility.Accessibility.IsEnabled && IsHighlighted)
                {
                    EmitAccessibilityEvent(AccessibilityPropertyChangeEvent.Value);
                }
            }
        }

        /// <summary>
        /// The property to get/set the buffer value of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float BufferValue
        {
            get
            {
                return (float)GetValue(BufferValueProperty);
            }
            set
            {
                SetValue(BufferValueProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets state of progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ProgressStatusType ProgressState
        {
            get
            {
                return (ProgressStatusType)GetValue(ProgressStateProperty);
            }
            set
            {
                SetValue(ProgressStateProperty, value);
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.ProgressBar;
            // create necessary components
            InitializeTrack();
            InitializeBuffer();
            InitializeProgress();
            InitializeIndeterminate();

            indeterminateAnimation?.Stop();
            indeterminateAnimation = null;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle style)
        {
            base.ApplyStyle(style);

            if (style is ProgressStyle progressStyle)
            {
                Debug.Assert(trackImage != null);
                Debug.Assert(progressImage != null);
                Debug.Assert(bufferImage != null);
                Debug.Assert(indeterminateImage != null);

                trackImage.ApplyStyle(progressStyle.Track);
                progressImage.ApplyStyle(progressStyle.Progress);
                bufferImage.ApplyStyle(progressStyle.Buffer);

                if (null != indeterminateImage && null != progressStyle.IndeterminateImageUrl)
                {
                    indeterminateImage.ResourceUrl = progressStyle.IndeterminateImageUrl;
                }
            }
        }

        /// <summary>
        /// Gets minimum value for Accessibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMinimum()
        {
            if (this.ProgressState == Progress.ProgressStatusType.Determinate)
            {
                return (double)MinValue;
            }
            else
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Gets the current value for Accessibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetCurrent()
        {
            if (this.ProgressState == Progress.ProgressStatusType.Determinate)
            {
                return (double)CurrentValue;
            }
            else
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Formatted current value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string IAtspiValue.AccessibilityGetValueText()
        {
            return (this as IAtspiValue).AccessibilityGetCurrent().ToString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IAtspiValue.AccessibilitySetCurrent(double value)
        {
            return false;
        }

        /// <summary>
        /// Gets maximum value for Accessibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMaximum()
        {
            if (this.ProgressState == Progress.ProgressStatusType.Determinate)
            {
                return (double)MaxValue;
            }
            else
            {
                return 0.0;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMinimumIncrement()
        {
            return 0.0;
        }

        /// <summary>
        /// Dispose Progress and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
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
                Utility.Dispose(progressImage);
                Utility.Dispose(bufferImage);
                Utility.Dispose(indeterminateImage);
            }

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// Change Image status. It can be override.
        /// </summary>
        /// This needs to be considered more if public-open is necessary.
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void UpdateStates()
        {
            ChangeImageState(state);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            if (size == null) return;

            if (size.Equals(this.size))
            {
                return;
            }

            this.size = new Vector2(size);
            UpdateValue();

            if (state == ProgressStatusType.Indeterminate) UpdateIndeterminateAnimation();
        }

        /// <summary>
        /// Update progress value
        /// </summary>
        /// This needs to be considered more if public-open is necessary.
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void UpdateValue()
        {
            if (null == trackImage || null == progressImage)
            {
                return;
            }

            if (minValue >= maxValue || currentValue < minValue || currentValue > maxValue)
            {
                return;
            }

            float width = this.SizeWidth;
            float height = this.SizeHeight;
            float progressRatio = (float)(currentValue - minValue) / (float)(maxValue - minValue);
            float progressWidth = width * progressRatio;
            progressImage.Size2D = new Size2D((int)(progressWidth + round), (int)height); //Add const round to reach Math.Round function.
            if (null != bufferImage)
            {
                if (bufferValue < minValue || bufferValue > maxValue)
                {
                    return;
                }

                float bufferRatio = (float)(bufferValue - minValue) / (float)(maxValue - minValue);
                float bufferWidth = width * bufferRatio;
                bufferImage.Size2D = new Size2D((int)(bufferWidth + round), (int)height); //Add const round to reach Math.Round function.
            }
        }

        private Vector4 destinationValue = new Vector4(-1.0f, 0.0f, 10.0f, 1.0f);
        private Vector4 initialValue = new Vector4(0.0f, 0.0f, 10.0f, 1.0f);

        /// <summary>
        /// Update Animation for Indeterminate mode.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void UpdateIndeterminateAnimation()
        {
            if (indeterminateImage == null) return;

            if (indeterminateAnimation == null)
            {
                indeterminateAnimation = new Animation(IndeterminateAnimationDuration);
            }
            else
            {
                indeterminateAnimation.Stop();
                indeterminateAnimation.Clear();
            }

            float destination = (this.SizeWidth - indeterminateImage.SizeWidth);

            KeyFrames keyFrames = new KeyFrames();
            keyFrames.Add(0.0f /*  0%*/, new Position(0, 0));
            AlphaFunction ease = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut);
            keyFrames.Add(0.5f /* 50%*/, new Position(destination, 0), ease);
            keyFrames.Add(1.0f /*100%*/, new Position(0, 0), ease);
            ease.Dispose();

            indeterminateAnimation.AnimateBetween(indeterminateImage, "Position", keyFrames);
            indeterminateAnimation.Looping = true;
            indeterminateAnimation.Play();
        }

        /// <summary>
        /// Get Progress style.
        /// </summary>
        /// <returns>The default progress style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle CreateViewStyle()
        {
            return new ProgressStyle();
        }

        /// <summary>
        /// Change Image status
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="statusType">New status type</param>
        protected void ChangeImageState(ProgressStatusType statusType)
        {
            if (!IsEnabled)
            {
                ControlState = ControlState.Disabled;

                indeterminateAnimation?.Stop();
                indeterminateAnimation = null;

                if (null != indeterminateImage)
                {
                    indeterminateImage.Hide();
                }
                progressImage.Hide();
                bufferImage.Hide();
                return;
            }

            if (statusType == ProgressStatusType.Buffering)
            {
                indeterminateAnimation?.Stop();
                indeterminateAnimation = null;

                if (null != indeterminateImage)
                {
                    indeterminateImage.Hide();
                }
                progressImage.Hide();
                bufferImage.Show();
            }
            else if (statusType == ProgressStatusType.Determinate)
            {
                indeterminateAnimation?.Stop();
                indeterminateAnimation = null;

                if (null != indeterminateImage)
                {
                    indeterminateImage.Hide();
                }
                bufferImage.Hide();
                progressImage.Show();

                UpdateValue();
            }
            else if (statusType == ProgressStatusType.Indeterminate)
            {
                bufferImage.Hide();
                progressImage.Hide();
                if (null != indeterminateImage)
                {
                    indeterminateImage.Show();
                }

                UpdateIndeterminateAnimation();
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnEnabled(bool enabled)
        {
            base.OnEnabled(enabled);
            UpdateStates();
        }

        private void Initialize()
        {
            AccessibilityHighlightable = true;
        }

        private void InitializeTrack()
        {
            if (null == trackImage)
            {
                trackImage = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = NUI.ParentOrigin.TopLeft,
                    PivotPoint = NUI.PivotPoint.TopLeft,
                    AccessibilityHidden = true,
                };
                Add(trackImage);
            }
        }

        private void InitializeProgress()
        {
            if (null == progressImage)
            {
                progressImage = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    AccessibilityHidden = true,
                };
                Add(progressImage);
            }
        }

        private void InitializeBuffer()
        {
            if (null == bufferImage)
            {
                bufferImage = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    AccessibilityHidden = true,
                };
                Add(bufferImage);
                bufferImage.Hide(); // At first, buffer image does not show.
            }
        }

        private void InitializeIndeterminate()
        {
            indeterminateImage = new ImageView
            {
                Size = new Size(16, 16),
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                AccessibilityHidden = true,
            };
            trackImage.Add(indeterminateImage);
            indeterminateImage.Hide();

            if (state == ProgressStatusType.Indeterminate)
            {
                indeterminateImage.Show();
            }
        }
    }
}
