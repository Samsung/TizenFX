using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI;

namespace NUIBrokerSample
{
    class SeamlessBackward : TransitionAnimation
    {
        string[] properties = { "SizeWidth", "SizeHeight" };
        string[] destinationValue = { "470", "600" };

        public SeamlessBackward(int durationMilliSeconds) : base(durationMilliSeconds)
        {
            DefaultImageStyle.Size = new Size(Window.Instance.WindowSize);
            DefaultImageStyle.Position = new Position(0, 0);
            DefaultImageStyle.ParentOrigin = ParentOrigin.TopCenter;
            DefaultImageStyle.PivotPoint = PivotPoint.TopCenter;

            int idx = 0;
            foreach (string property in properties)
            {
                TransitionAnimationData data = new TransitionAnimationData();
                data.StartTime = 0;
                data.EndTime = durationMilliSeconds;
                data.Property = property;
                data.DestinationValue = destinationValue[idx++];
                AddAnimationData(data);
            }
        }
    }
}

