using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Wearable
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LayoutManager
    {
        public enum Orientation
        {
            Vertical = 0,
            Horizontal = 1,
        }


        protected float mPrevScrollPosition = 0.0f;
        protected int mPrevFirstDataIndex = 0;

        public View Container{get;set;}
        public Size ItemSize{get;set;} = new Size();
        public Orientation LayoutOrientation{get;set;} = Orientation.Vertical;

        public virtual List<ListItem> OnScroll(float scrollPosition)
        {
            return new List<ListItem>();
        }

        protected virtual void Layout(float scrollPosition)
        {
           
        }

        public virtual float CalculateCandidateScrollPosition(float position)
        {
            return position;
        }

    }
}