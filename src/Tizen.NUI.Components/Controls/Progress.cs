﻿/*
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
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Progress class of nui component. It's used to show the ongoing status with a long narrow bar.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Progress : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create("currentValue", typeof(float), typeof(Progress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BufferValueProperty = BindableProperty.Create("bufferValue", typeof(float), typeof(Progress), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressStateProperty = BindableProperty.Create("state", typeof(ProgressStatusType), typeof(Progress), ProgressStatusType.Indeterminate, propertyChanged: (bindable, oldValue, newValue) =>
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
        private float maxValue = 100;
        private float minValue = 0;
        private float currentValue = 0;
        private float bufferValue = 0;
        private ProgressStyle progressStyle => ViewStyle as ProgressStyle;

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
        /// Get style of progress.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public new ProgressStyle Style
        {
            get
            {
                var result = new ProgressStyle(progressStyle);
                result.CopyPropertiesFromView(this);
                result.Track.CopyPropertiesFromView(trackImage);
                result.Progress.CopyPropertiesFromView(progressImage);
                result.Buffer.CopyPropertiesFromView(bufferImage);
                return result;
            }
        }

        /// <summary>
        /// The property to get/set Track image object URL of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string TrackImageURL
        {
            get
            {
                return progressStyle?.Track?.ResourceUrl?.All;
            }
            set
            {
                if (null != progressStyle?.Track)
                {
                    progressStyle.Track.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set Progress object image URL of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ProgressImageURL
        {
            get
            {
                return progressStyle?.Progress?.ResourceUrl?.All;
            }
            set
            {
                if (null != progressStyle?.Progress)
                {
                    progressStyle.Progress.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set Buffer object image resource URL of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string BufferImageURL
        {
            get
            {
                return progressStyle?.Buffer?.ResourceUrl?.All;
            }
            set
            {
                if (null != progressStyle?.Buffer)
                {
                    progressStyle.Buffer.ResourceUrl = value;
                    RelayoutRequest();
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
                return progressStyle?.Track?.BackgroundColor?.All;
            }
            set
            {
                if (null != progressStyle?.Track)
                {
                    progressStyle.Track.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set Progress object color of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color ProgressColor
        {
            get
            {
                return progressStyle?.Progress?.BackgroundColor?.All;
            }
            set
            {
                if (null != progressStyle?.Progress)
                {
                    progressStyle.Progress.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// The property to get/set Buffer object color of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color BufferColor
        {
            get
            {
                return progressStyle?.Buffer?.BackgroundColor?.All;
            }
            set
            {
                if (null != progressStyle?.Buffer)
                {
                    progressStyle.Buffer.BackgroundColor = value;
                }
            }
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
            }

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            ProgressStyle tempStyle = StyleManager.Instance.GetViewStyle(StyleName) as ProgressStyle;
            if (null != tempStyle)
            {
                progressStyle.CopyFrom(tempStyle);
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Change Image status. It can be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This needs to be considered more if public-open is necessary.
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void UpdateStates()
        {
            ChangeImageState(state);
        }

        /// <summary>
        /// Update progress value
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
            if (state == ProgressStatusType.Buffering)
            {
                bufferImage.Show();
                progressImage.Hide();
            }
            else if (state == ProgressStatusType.Determinate)
            {
                bufferImage.Show();
                progressImage.Show();
                UpdateValue();
            }
            else
            {
                bufferImage.Hide();
                progressImage.Hide();
            }
        }

        private void Initialize()
        {
            // create necessary components
            InitializeTrack();
            InitializeBuffer();
            InitializeProgress();
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
                trackImage.ApplyStyle(progressStyle.Track);
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
                progressImage.ApplyStyle(progressStyle.Progress);
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
                bufferImage.ApplyStyle(progressStyle.Buffer);
            }
        }
    }
}
