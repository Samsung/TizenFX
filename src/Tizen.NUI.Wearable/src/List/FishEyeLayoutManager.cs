using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System.Collections.Generic;
using System.ComponentModel;


namespace Tizen.NUI.Wearable
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FishEyeLayoutManager : LayoutManager
    {
        public int CurrentFocusedIndex{get;set;} = 0;
        private int FocusedIndex{get;set;} = 0;
        private float StepSize = 0.0f;
        private List<PropertyNotification> notifications = new List<PropertyNotification>();
        public FishEyeLayoutManager(Size itemSize, View container)
        {
            ItemSize = itemSize;
            Container = container;
            Layout(0.0f);

            StepSize = Container.Children[0].SizeHeight/2.0f + Container.Children[1].SizeHeight*Container.Children[1].Scale.X/2.0f;
            Container.SizeHeight = StepSize*49;

            Tizen.Log.Error("NUI","STEPSIZE : "+StepSize+" Container.SizeHeight : "+Container.SizeHeight+" \n");

            foreach(ListItem item in Container.Children)
            {
                PropertyNotification noti = item.AddPropertyNotification("size",PropertyCondition.Step(1.0f));
                noti.Notified += (object source, PropertyNotification.NotifyEventArgs args) =>
                {
                    Layout(mPrevScrollPosition);
                };

                notifications.Add(noti);
            }
        }

        private float FindCandidatePosition(float startPosition)
        {
            float result = 0.0f;
            float itemSize = LayoutOrientation == Orientation.Horizontal?ItemSize.Width:ItemSize.Height;
            float maximumPosition = startPosition + itemSize;

            // it should be updated to binary search
            for(float i = startPosition ; i < maximumPosition ; i++)
            {
                float scaleFactor = calculateScaleFactor(i);
                float halfOfScaledItemSize = itemSize*scaleFactor*0.5f;

                if(halfOfScaledItemSize < i - startPosition)
                {
                    result = i;

                    break;
                }
            }

            return result;
        }

        protected override void Layout(float scrollPosition)
        {
            Tizen.Log.Error("NUI","LAYOUT START =================\n");
            ListItem centerItem = Container.Children[FocusedIndex] as ListItem;
            float centerItemPosition = LayoutOrientation == Orientation.Horizontal?centerItem.Position.X:centerItem.Position.Y;
            float centerItemScale = calculateScaleFactor(centerItemPosition);
            centerItem.Scale = new Vector3(centerItemScale,centerItemScale,1.0f);

            ListItem prevItem = centerItem;
            bool visible = true;

            Tizen.Log.Error("NUI","FocusedIndex : "+FocusedIndex+" scrollPosition : "+scrollPosition+" ==== \n");

            //Center front
            for(int i = FocusedIndex - 1; i > -1; i--)
            {
                ListItem target = Container.Children[i] as ListItem;

                if(visible)
                {
                    float prevItemPosition = LayoutOrientation == Orientation.Horizontal?prevItem.Position.X:prevItem.Position.Y;
                    float prevItemSize = (LayoutOrientation == Orientation.Horizontal?prevItem.Size.Width:prevItem.Size.Height);
                    float prevItemCurrentSize = (LayoutOrientation == Orientation.Horizontal?prevItem.CurrentSize.Width:prevItem.CurrentSize.Height);
                    prevItemSize = Math.Max(prevItemSize,prevItemCurrentSize);
                    Tizen.Log.Error("NUI","["+i+"]Calculate from ["+prevItem.DataIndex+"] : ["+prevItemSize+"]\n");

                    prevItemSize *= prevItem.Scale.X;

                    float startPosition = prevItemPosition - prevItemSize / 2.0f;
                    float minimumPosition = startPosition - prevItemSize;
                    float candidatePosition = Math.Abs(scrollPosition) - 180;

                    for(float j = startPosition ; j > minimumPosition ; j--)
                    {
                        float itemSize = LayoutOrientation == Orientation.Horizontal?ItemSize.Width:ItemSize.Height;
                        float halfOfScaledItemSize = itemSize*calculateScaleFactor(j)*0.5f;

                        if(halfOfScaledItemSize < Math.Abs(j - startPosition))
                        {
                            candidatePosition = j;
                            break;
                        }
                    }

                    float scaleFactor = calculateScaleFactor(candidatePosition);

                    target.Scale = new Vector3(scaleFactor,scaleFactor,1.0f);

                    target.Position = LayoutOrientation == Orientation.Horizontal?
                                new Position(candidatePosition,target.Position.Y):
                                new Position(target.Position.X,candidatePosition);

                    prevItem = target;

                    visible = scaleFactor > 0.0f ? true:false;
                }
                else
                {
                    target.Scale = new Vector3(0.0f,0.0f,1.0f);
                }
            }

            prevItem = centerItem;
            visible = true;

            //Center back
            for(int i = FocusedIndex + 1; i < Container.Children.Count; i++)
            {
                ListItem target = Container.Children[i] as ListItem;

                if(visible)
                {
                    float prevItemPosition = LayoutOrientation == Orientation.Horizontal?prevItem.Position.X:prevItem.Position.Y;
                    float prevItemSize = (LayoutOrientation == Orientation.Horizontal?prevItem.Size.Width:prevItem.Size.Height);
                    float prevItemCurrentSize = (LayoutOrientation == Orientation.Horizontal?prevItem.CurrentSize.Width:prevItem.CurrentSize.Height);
                    prevItemSize = Math.Max(prevItemSize,prevItemCurrentSize);

                    Tizen.Log.Error("NUI","["+i+"]Calculate from ["+prevItem.DataIndex+"] : ["+prevItemSize+"]\n");
                    prevItemSize *= prevItem.Scale.X;

                    float startPosition = prevItemPosition + prevItemSize / 2.0f;
                    float maximumPosition = startPosition + prevItemSize;
                    float candidatePosition = Math.Abs(scrollPosition) + 180;

                    for(float j = startPosition ; j < maximumPosition ; j++)
                    {
                        float itemSize = LayoutOrientation == Orientation.Horizontal?ItemSize.Width:ItemSize.Height;
                        float halfOfScaledItemSize = itemSize*calculateScaleFactor(j)*0.5f;

                        if(halfOfScaledItemSize < Math.Abs(j - startPosition))
                        {
                            candidatePosition = j;
                            break;
                        }
                    }

                    float scaleFactor = calculateScaleFactor(candidatePosition);

                    target.Scale = new Vector3(scaleFactor,scaleFactor,1.0f);

                    target.Position = LayoutOrientation == Orientation.Horizontal?
                                new Position(candidatePosition,target.Position.Y):
                                new Position(target.Position.X,candidatePosition);

                    prevItem = target;

                    visible = scaleFactor > 0.0f ? true:false;
                }
                else
                {
                    target.Scale = new Vector3(0.0f,0.0f,1.0f);
                }
            }

            if(centerItemPosition < -scrollPosition - 10)
            {
                FocusedIndex = Math.Min(Container.Children.Count-1,FocusedIndex+1);
                // ListItem newCenterItem = Container.Children[FocusedIndex] as ListItem;
                // newCenterItem.Position = new Position(0.0f,Math.Abs(StepSize*(FocusedIndex)));
                // newCenterItem.Scale = new Vector3(1.0f,1.0f,1.0f);
                // Tizen.Log.Error("NUI","Change CI "+FocusedIndex+"[DI:"+newCenterItem.DataIndex+"]\n");
            }
            else if(centerItemPosition > -scrollPosition + 10)
            {
                FocusedIndex = Math.Max(0,FocusedIndex-1);
                // ListItem newCenterItem = Container.Children[FocusedIndex] as ListItem;
                // newCenterItem.Position = new Position(0.0f,Math.Abs(StepSize*(FocusedIndex)));
                // newCenterItem.Scale = new Vector3(1.0f,1.0f,1.0f);
                // Tizen.Log.Error("NUI","Change CI "+FocusedIndex+"[DI:"+newCenterItem.DataIndex+"]\n");
            }

            Tizen.Log.Error("NUI","LAYOUT END =================\n");
        }

        private double calculateXFactor(double y)
        {
            double factor1 = Math.Pow(180,2);
            double factor2 = Math.Pow(333,2);
            double factor3 = Math.Pow((y + 153),2);

            return Math.Sqrt(factor1-(factor1/factor2*factor3));
        }

        private float calculateScaleFactor(float position)
        {
            float origin = Math.Abs(mPrevScrollPosition);
            float diff = position - origin;
            
            diff = Math.Max(diff,-180);
            diff = Math.Min(diff,180);
            diff = Math.Abs(diff);

            float result = (float)(calculateXFactor(diff)/calculateXFactor(0));

            if(result < 0.001f)
            {
                result = 0.0f;
            }
            else if(result > 0.99f )
            {
                result = 1.0f;
            }

            return result;
        }

        public override List<ListItem> OnScroll(float scrollPosition)
        {
            Layout(scrollPosition);

            List<ListItem> result = new List<ListItem>();

            bool checkFront = mPrevScrollPosition-scrollPosition>0?true:false;

            if(checkFront)
            {
                if(FocusedIndex > 6)
                {
                    Tizen.Log.Error("NUI","======\n");
                    Tizen.Log.Error("NUI","RF CI "+FocusedIndex+"\n");

                    //Too many Items in fornt
                    ListItem target = Container.Children[0] as ListItem;
                    target.SiblingOrder = Container.Children.Count - 1;
                    target.DataIndex = target.DataIndex + Container.Children.Count;

                    //Need to bind again
                    result.Add(target);

                    //All index will be changed;
                    FocusedIndex--;
                    Tizen.Log.Error("NUI","NEW CI "+FocusedIndex+"\n");
                }
            }
            else
            {
                if(FocusedIndex < Container.Children.Count - 7)
                {
                    Tizen.Log.Error("NUI","======\n");
                    Tizen.Log.Error("NUI","RB CI "+FocusedIndex+"\n");

                    //Too many Items in back
                    ListItem target = Container.Children[Container.Children.Count -1] as ListItem;
                    target.SiblingOrder = 0;
                    target.DataIndex = target.DataIndex - Container.Children.Count;

                    //Need to bind again
                    result.Add(target);

                    //All index will be changed;
                    FocusedIndex++;

                    Tizen.Log.Error("NUI","NEW CI "+FocusedIndex+"\n");
                }
            }

            mPrevScrollPosition = scrollPosition;

            return result;
        }

        public override float CalculateCandidateScrollPosition(float position)
        {
            int value = (int)(Math.Abs(position) / StepSize);
            float remain = Math.Abs(position) % StepSize;

            int newValue = remain > StepSize / 2.0f?value+1:value;

            CurrentFocusedIndex = newValue;
            return -newValue * StepSize;
        }
    }
}