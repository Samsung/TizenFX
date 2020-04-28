using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;


namespace Tizen.NUI.Components
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ListItem : Control
    {
        public ListItem()
        {
        }

        public int DataIndex{get;set;}=0;
    }
}