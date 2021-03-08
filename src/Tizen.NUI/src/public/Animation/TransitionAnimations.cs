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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Data of animation data for transition
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TransitionAnimationData
    {
        /// <summary>
        /// start time of animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StartTime { get; set; }

        /// <summary>
        /// end time of animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int EndTime { get; set; }

        /// <summary>
        /// property of animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Property { get; set; }

        /// <summary>
        /// destination value of animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DestinationValue { get; set; }
    }

    /// <summary>
    /// Transition animation effect.
    /// This is normally used to specify transitions for a NUIApplication.
    /// </summary>
    /// <seealso cref="TransitionOptions.ForwardAnimation" />
    /// <seealso cref="TransitionOptions.BackwardAnimation" />
    /// <seealso cref="NUIApplication.TransitionOptions" />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TransitionAnimation : IDisposable
    {
        private bool disposed = false;
        private ImageViewStyle defaultImageStyle;
        private List<TransitionAnimationData> animationDataList;


        /// <summary>
        /// Create an instance of Transition.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionAnimation(int durationMilliSeconds)
        {
            DurationMilliSeconds = durationMilliSeconds;
            if (animationDataList == null)
            {
                animationDataList = new List<TransitionAnimationData>();
            }
        }

        /// <summary>
        /// total time of animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DurationMilliSeconds { get; set; }

        /// <summary>
        /// Default style of animate image view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<TransitionAnimationData> AnimationDataList
        {
            get
            {
                return animationDataList;
            }
        }


        /// <summary>
        /// Add data of transition animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddAnimationData(TransitionAnimationData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            animationDataList?.Add(data);
        }

        /// <summary>
        /// Remove data of transition animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAnimationData(TransitionAnimationData data)
        {
            animationDataList?.Remove(data);
        }

        /// <summary>
        /// Clear data list of transition animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearAnimationData()
        {
            animationDataList?.Clear();
        }

        /// <summary>
        /// Setting default style of ImageView
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle DefaultImageStyle
        {
            get
            {
                if (defaultImageStyle == null)
                {
                    defaultImageStyle = new ImageViewStyle();
                    defaultImageStyle.Size = new Size(0, 0);
                    defaultImageStyle.Position = new Position(0, 0);
                    defaultImageStyle.ParentOrigin = ParentOrigin.Center;
                    defaultImageStyle.PivotPoint = PivotPoint.Center;
                    defaultImageStyle.PositionUsesPivotPoint = true;
                }
                return defaultImageStyle;
            }
            set
            {
                defaultImageStyle = value;
            }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                defaultImageStyle?.Dispose();
            }
            disposed = true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            global::System.GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Screen slides are transitions between one entire screen to another 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SlideIn : TransitionAnimation
    {
        private int defaultInitValue = 0;

        /// <summary>
        /// Create an instance of SlideIn.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SlideIn(int durationMilliSeconds) : base(durationMilliSeconds)
        {
            defaultInitValue = -Window.Instance.GetWindowSize().Width;

            DefaultImageStyle.Position = new Position(defaultInitValue, 0);
            DefaultImageStyle.Size = Window.Instance.GetWindowSize();

            TransitionAnimationData data = new TransitionAnimationData();
            data.StartTime = 0;
            data.EndTime = durationMilliSeconds;
            data.Property = "PositionX";
            data.DestinationValue = "0";
            AddAnimationData(data);
        }
    }


    /// <summary>
    /// Screen slides are transitions between one entire screen to another 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SlideOut : TransitionAnimation
    {
        private int defaultInitValue = 0;

        /// <summary>
        /// Create an instance of SlideOut.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SlideOut(int durationMilliSeconds) : base(durationMilliSeconds)
        {
            defaultInitValue = 0;

            DefaultImageStyle.Position = new Position(defaultInitValue, 0);
            DefaultImageStyle.Size = Window.Instance.GetWindowSize();

            TransitionAnimationData data = new TransitionAnimationData();
            data.StartTime = 0;
            data.EndTime = durationMilliSeconds;
            data.Property = "PositionX";
            data.DestinationValue = Window.Instance.GetWindowSize().Width.ToString();
            AddAnimationData(data);
        }
    }
}
