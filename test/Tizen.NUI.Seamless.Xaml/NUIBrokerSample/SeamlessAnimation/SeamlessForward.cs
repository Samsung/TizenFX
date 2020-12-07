using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    class SeamlessForward : TransitionAnimation
    {
        private string[] properties = { "SizeWidth", "SizeHeight", "PositionX", "PositionY", "Opacity" };
        private string[] destinationValue = { "1080", "1920", "0", "0", "1" };

        public SeamlessForward(int durationMilliSeconds) : base(durationMilliSeconds)
        {
            DefaultImageStyle.Size = new Size(470, 600);
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

