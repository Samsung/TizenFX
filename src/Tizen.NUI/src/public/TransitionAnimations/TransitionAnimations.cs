﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tizen.NUI;
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
    /// Transition animation effect
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TransitionAnimation : IDisposable
    {
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
            if (disposing)
            {
                // Dispose managed resources.
                defaultImageStyle?.Dispose();
            }
            // Free native resources.
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
