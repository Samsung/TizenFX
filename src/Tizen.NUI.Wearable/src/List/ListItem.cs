using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;


namespace Tizen.NUI.Wearable
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ListItem : Control
    {
        public ListItem()
        {
            PositionUsesPivotPoint = true;
        }

        public int DataIndex{get;set;}=0;
    }
}