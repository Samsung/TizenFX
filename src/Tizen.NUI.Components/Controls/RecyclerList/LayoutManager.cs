using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
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
        public float StepSize{
            get
            {
                return mStepSize;
            }
        }
        protected float mStepSize = 0.0f;

        public virtual void Layout(float scrollPosition)
        {
           
        }

        public virtual List<ListItem> Recycle(float scrollPositio)
        {
            return new List<ListItem>();
        }

        public virtual float CalculateCandidateScrollPosition(float position)
        {
            return position;
        }

        

    }
}