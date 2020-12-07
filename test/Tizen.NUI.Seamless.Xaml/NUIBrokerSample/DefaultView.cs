using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIBrokerSample
{
    public class DefaultView : View
    {
        public DefaultView()
        {
            PositionUsesPivotPoint = true;
            ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter;
            PivotPoint = Tizen.NUI.PivotPoint.Center;
        }
    }
}
