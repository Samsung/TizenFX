using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tizen.NUI;

namespace Tizen.NUI
{
    /// <summary>
    /// Transition animation effect
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TransitionAnimation : Animation
    {
        /// <summary>
        /// Create an instance of Transition.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionAnimation(int durationMilliSeconds) : base(durationMilliSeconds)
        {

        }

        internal virtual int GetDefaultInitValue()
        {
            return 0;
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
            Properties = new string[1];
            DestValue = new string[1];
            StartTime = new int[1];
            EndTime = new int[1];

            StartTime[0] = 0;
            EndTime[0] = durationMilliSeconds;

            Properties[0] = "PositionX";
            DestValue[0] = "0";

            defaultInitValue = -Window.Instance.GetWindowSize().Width;
        }

        internal override int GetDefaultInitValue()
        {
            return defaultInitValue;
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
            Properties = new string[1];
            DestValue = new string[1];
            StartTime = new int[1];
            EndTime = new int[1];

            StartTime[0] = 0;
            EndTime[0] = durationMilliSeconds;

            Properties[0] = "PositionX";

            DestValue[0] = Window.Instance.GetWindowSize().Width.ToString();

            defaultInitValue = 0;
        }

        internal override int GetDefaultInitValue()
        {
            return defaultInitValue;
        }
    }
}
