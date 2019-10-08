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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Progress class of nui component. It's used to show the ongoing status with a long narrow bar.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Progress : Control
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ProgressAttributes progressAttrs = null;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ProgressStatusType state = ProgressStatusType.Indeterminate;

        private const float round = 0.5f;
        private ImageView trackObj = null;
        private ImageView progressObj = null;
        private ImageView bufferObj = null;
        private ImageView loadingObj = null;
        private float maxValue = 100;
        private float minValue = 0;
        private float currentValue = 0;
        private float bufferValue = 0;

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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Progress(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Progress class with specific Attributes.
        /// </summary>
        /// <param name="attributes">The Attributes object to initialize the Progress.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Progress(ProgressAttributes attributes) : base(attributes)
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
            /// Show TrackImage
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Buffering,

            /// <summary>
            /// Show ProgressImage
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Determinate,

            /// <summary>
            /// Show LoadingImage
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Indeterminate
        }

        /// <summary>
        /// The property to get/set Track image object URL of the Progress.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string TrackImageURL
        {
            get
            {
                return progressAttrs.TrackImageAttributes?.ResourceURL?.All;
            }
            set
            {
                CreateTrackImageAttributes();
                if (progressAttrs.TrackImageAttributes.ResourceURL == null)
                {
                    progressAttrs.TrackImageAttributes.ResourceURL = new StringSelector();
                }
                progressAttrs.TrackImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
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
                return progressAttrs.ProgressImageAttributes?.ResourceURL?.All;
            }
            set
            {
                CreateProgressImageAttributes();
                if (progressAttrs.ProgressImageAttributes.ResourceURL == null)
                {
                    progressAttrs.ProgressImageAttributes.ResourceURL = new StringSelector();
                }
                progressAttrs.ProgressImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
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
                return progressAttrs.BufferImageAttributes?.ResourceURL?.All;
            }
            set
            {
                CreateBufferImageAttributes();
                if (progressAttrs.BufferImageAttributes.ResourceURL == null)
                {
                    progressAttrs.BufferImageAttributes.ResourceURL = new StringSelector();
                }
                progressAttrs.BufferImageAttributes.ResourceURL.All = value;
                RelayoutRequest();
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
                return progressAttrs.TrackImageAttributes?.BackgroundColor?.All;
            }
            set
            {
                CreateTrackImageAttributes();
                if (progressAttrs.TrackImageAttributes.BackgroundColor == null)
                {
                    progressAttrs.TrackImageAttributes.BackgroundColor = new ColorSelector();
                }
                progressAttrs.TrackImageAttributes.BackgroundColor.All = value;
                RelayoutRequest();
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
                return progressAttrs.ProgressImageAttributes?.BackgroundColor?.All;
            }
            set
            {
                CreateProgressImageAttributes();
                if (null == progressAttrs.ProgressImageAttributes.BackgroundColor)
                {
                    progressAttrs.ProgressImageAttributes.BackgroundColor = new ColorSelector();
                }
                progressAttrs.ProgressImageAttributes.BackgroundColor.All = value;
                RelayoutRequest();
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
                return progressAttrs.BufferImageAttributes?.BackgroundColor?.All;
            }
            set
            {
                CreateBufferImageAttributes();
                if (null == progressAttrs.BufferImageAttributes.BackgroundColor)
                {
                    progressAttrs.BufferImageAttributes.BackgroundColor = new ColorSelector();
                }
                progressAttrs.BufferImageAttributes.BackgroundColor.All = value;
                RelayoutRequest();
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
                return maxValue;
            }
            set
            {
                maxValue = value;
                UpdateValue();
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
                return minValue;
            }
            set
            {
                minValue = value;
                UpdateValue();
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
                return currentValue;
            }
            set
            {
                if (value > maxValue || value < minValue)
                {
                    return;
                }
                currentValue = value;
                UpdateValue();
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
                return bufferValue;
            }
            set
            {
                if (value > maxValue || value < minValue)
                {
                    return;
                }
                bufferValue = value;
                UpdateValue();
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
                return state;
            }
            set
            {
                state = value;
                UpdateStates();
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
                Utility.Dispose(trackObj);
                Utility.Dispose(progressObj);
                Utility.Dispose(bufferObj);
                Utility.Dispose(loadingObj);
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
            ApplyAttributes(this, progressAttrs);
            ApplyAttributes(trackObj, progressAttrs.TrackImageAttributes);
            ApplyAttributes(progressObj, progressAttrs.ProgressImageAttributes);
            ApplyAttributes(loadingObj, progressAttrs.LoadingImageAttributes);
            ApplyAttributes(bufferObj, progressAttrs.BufferImageAttributes);
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
            ProgressAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as ProgressAttributes;
            if (null != tempAttributes)
            {
                attributes = progressAttrs = tempAttributes;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Change Image status. It can be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateStates()
        {
            ChangeImageState(state);
        }

        /// <summary>
        /// Update progress value
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateValue()
        {
            if (null == trackObj || null == progressObj)
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
            progressObj.Size2D = new Size2D((int)(progressWidth + round), (int)height); //Add const round to reach Math.Round function.
            if (null != bufferObj)
            {
                if (bufferValue < minValue || bufferValue > maxValue)
                {
                    return;
                }

                float bufferRatio = (float)(bufferValue - minValue) / (float)(maxValue - minValue);
                float bufferWidth = width * bufferRatio;
                bufferObj.Size2D = new Size2D((int)(bufferWidth + round), (int)height); //Add const round to reach Math.Round function.
            }
        }

        /// <summary>
        /// Get Progress attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ProgressAttributes();
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
                bufferObj.Show();
                loadingObj.Hide();
                progressObj.Hide();
            }
            else if (state == ProgressStatusType.Determinate)
            {
                bufferObj.Hide();
                loadingObj.Hide();
                progressObj.Show();
                UpdateValue();
            }
            else
            {
                bufferObj.Hide();
                loadingObj.Show();
                progressObj.Hide();
            }
        }

        private void Initialize()
        {
            progressAttrs = attributes as ProgressAttributes;
            if (null == progressAttrs)
            {
                throw new Exception("Progress attribute parse error.");
            }

            // create necessary components
            InitializeTrack();
            InitializeBuffer();
            InitializeProgress();
            InitializeLoading();
        }

        private void InitializeTrack()
        {
            if (null == trackObj)
            {
                trackObj = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                };
                Add(trackObj);
            }
        }

        private void InitializeProgress()
        {
            if (null == progressObj)
            {
                progressObj = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                };
                Add(progressObj);
            }
        }

        private void InitializeBuffer()
        {
            if (null == bufferObj)
            {
                bufferObj = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                };
                Add(bufferObj);
            }
        }

        private void InitializeLoading()
        {
            if (null == loadingObj)
            {
                loadingObj = new ImageView
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                };
                Add(loadingObj);
            }
        }

        private void CreateTrackImageAttributes()
        {
            if (null == progressAttrs.TrackImageAttributes)
            {
                progressAttrs.TrackImageAttributes = new ImageAttributes();
            }
        }

        private void CreateProgressImageAttributes()
        {
            if (null == progressAttrs.ProgressImageAttributes)
            {
                progressAttrs.ProgressImageAttributes = new ImageAttributes();
            }
        }

        private void CreateBufferImageAttributes()
        {
            if (null == progressAttrs.BufferImageAttributes)
            {
                progressAttrs.BufferImageAttributes = new ImageAttributes();
            }
        }
    }
}
