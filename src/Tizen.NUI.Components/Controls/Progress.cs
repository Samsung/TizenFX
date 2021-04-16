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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.ComponentModel;
using System.Diagnostics;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Progress class is used to show the ongoing status with a long narrow bar.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Progress : Control
    {
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

        private const float round = 0.5f;
        private ImageView trackImage = null;
        private ImageView progressImage = null;
        private ImageView bufferImage = null;
        private ImageVisual indeterminateImage = null;
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
        }

        /// <summary>
        /// The constructor of the Progress class with specific style.
        /// </summary>
        /// <param name="style">style name</param>
        /// <since_tizen> 8 </since_tizen>
        public Progress(string style) : base(style)
        {
        }

        /// <summary>
        /// The constructor of the Progress class with specific style.
        /// </summary>
        /// <param name="progressStyle">The style object to initialize the Progress.</param>
        /// <since_tizen> 8 </since_tizen>
        public Progress(ProgressStyle progressStyle) : base(progressStyle)
        {
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
            get => trackImage.ResourceUrl;
            set => trackImage.ResourceUrl = value;
        }

        /// <summary>
        /// The property to get/set Progress object image URL of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ProgressImageURL
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
                if (indeterminateImage == null)
                {
                    return null;
                }
                else
                {
                    return indeterminateImage?.URL;
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
                    indeterminateImage.URL = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set Track object color of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color TrackColor
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
            get => progressImage.BackgroundColor;
            set => progressImage.BackgroundColor = value;
        }

        /// <summary>
        /// The property to get/set Buffer object color of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color BufferColor
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

                trackImage.ApplyStyle(progressStyle.Track);
                progressImage.ApplyStyle(progressStyle.Progress);
                bufferImage.ApplyStyle(progressStyle.Buffer);

                if (null != indeterminateImage && null != progressStyle.IndeterminateImageUrl)
                {
                    indeterminateImage.URL = progressStyle.IndeterminateImageUrl;
                }
            }
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
                indeterminateImage = null;
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
            indeterminateAnimation?.Stop();

            if (null != indeterminateImage)
            {
                indeterminateAnimation = AnimateVisual(indeterminateImage, "pixelArea", destinationValue, 0, 1000,  AlphaFunction.BuiltinFunctions.Default, initialValue);
                indeterminateAnimation.Looping = true;
                indeterminateAnimation.Play();
            }
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
            if (statusType == ProgressStatusType.Buffering)
            {
                indeterminateAnimation?.Stop();
                indeterminateAnimation = null;

                if (null != indeterminateImage)
                {
                    indeterminateImage.Opacity = 0.0f;
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
                    indeterminateImage.Opacity = 0.0f;
                }
                bufferImage.Show();
                progressImage.Show();

                UpdateValue();
            }
            else if (statusType == ProgressStatusType.Indeterminate)
            {
                bufferImage.Hide();
                progressImage.Hide();
                if (null != indeterminateImage)
                {
                    indeterminateImage.Opacity = 1.0f;
                }

                UpdateIndeterminateAnimation();
            }
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
                    PivotPoint = NUI.PivotPoint.TopLeft
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
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
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
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                };
                Add(bufferImage);
            }
        }

        private void InitializeIndeterminate()
        {
            indeterminateImage = new ImageVisual
            {
                PixelArea = new Vector4(0.0f, 0.0f, 10.0f, 1.0f),
                WrapModeU = WrapModeType.Repeat,
                SizePolicy = VisualTransformPolicyType.Relative,
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center,
                Opacity = 0.0f,
                Size = new Size2D(1, 1),
                URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "nui_component_default_progress_indeterminate.png"
            };
            AddVisual("Indeterminate", indeterminateImage);

            if (state == ProgressStatusType.Indeterminate)
            {
                indeterminateImage.Opacity = 1.0f;
            }
        }
    }
}
