/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ValueChangedEventArgs is a class to notify changed Picker value argument which will sent to user.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// ValueChangedEventArgs default constructor.
        /// <param name="value">value of Picker.</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public ValueChangedEventArgs(int value)
        {
            Value = value;
        }

        /// <summary>
        /// ValueChangedEventArgs default constructor.
        /// <returns>The current value of Picker.</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]   
        public int Value { get; }
        
    }

    /// <summary>
    /// Picker is a class which provides a function that allows the user to select 
    /// a value through a scrolling motion by expressing the specified value as a list.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Picker : Control
    {
        //Tizen 6.5 base components Picker guide visible scroll item is 5.
        private const int scrollVisibleItems = 5;
        //Dummy item count for loop feature. Max value of scrolling distance in 
        //RPI target is bigger than 20 items height. it can adjust depends on the internal logic and device env.
        private const int dummyItemsForLoop = 20;             
        private int startScrollOffset;
        private int itemHeight;
        private int startScrollY;
        private int startY;
        private int pageSize;
        private int currentValue;
        private int maxValue;
        private int minValue;
        private int lastScrollPosion;
        private bool onAnimation; //Scroller on animation check.
        private bool onAlignAnimation;
        private bool displayedValuesUpdate; //User sets displayed value check.
        private bool needItemUpdate; //min, max or display value updated check.
        private bool loopEnabled;
        private ReadOnlyCollection<string> displayedValues;
        private PickerScroller pickerScroller;
        private View upLine;
        private View downLine;
        private IList<TextLabel> itemList;
        private PickerStyle pickerStyle => ViewStyle as PickerStyle;

        /// <summary>
        /// Creates a new instance of Picker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Picker()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of Picker.
        /// </summary>
        /// <param name="style">Creates Picker by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Picker(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of Picker.
        /// </summary>
        /// <param name="pickerStyle">Creates Picker by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Picker(PickerStyle pickerStyle) : base(pickerStyle)
        {
            Initialize();
        }

        /// <summary>
        /// Dispose Picker and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (itemList != null)
                {
                    foreach (TextLabel textLabel in itemList)
                    {
                        if (pickerScroller) pickerScroller.Remove(textLabel);
                        Utility.Dispose(textLabel);
                    }

                    itemList = null;
                }

                if (pickerScroller != null)
                {
                    Remove(pickerScroller);
                    Utility.Dispose(pickerScroller);
                    pickerScroller = null;
                }

                Remove(upLine);
                Utility.Dispose(upLine);
                Remove(downLine);
                Utility.Dispose(downLine);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// An event emitted when Picker value changed, user can subscribe or unsubscribe to this event handler.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        //TODO Fomatter here

        /// <summary>
        /// The values to be displayed instead of numbers.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyCollection<String> DisplayedValues
        {
            get
            {
                return displayedValues;
            }
            set
            {
                displayedValues = value;

                needItemUpdate = true;
                displayedValuesUpdate = true;

                UpdateValueList();
            }
        }
        
        /// <summary>
        /// The Current value of Picker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                if (currentValue == value) return;

                if (currentValue < minValue) currentValue = minValue;
                else if (currentValue > maxValue) currentValue = maxValue;

                currentValue = value;

                UpdateCurrentValue();
            }
        }

        /// <summary>
        /// The max value of Picker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                if (maxValue == value) return;
                if (currentValue > value) currentValue = value;
                
                maxValue = value;
                needItemUpdate = true;

                UpdateValueList();
            }
        }

        /// <summary>
        /// The min value of Picker.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                if (minValue == value) return;
                if (currentValue < value) currentValue = value;
                
                minValue = value;
                needItemUpdate = true;

                UpdateValueList();
            }
        }

        /// <summary>
        /// Applies style to Picker.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            //Apply StartScrollOffset style.
            if (pickerStyle?.StartScrollOffset != null)
                startScrollOffset = (int)pickerStyle.StartScrollOffset.Height;

            //Apply ItemTextLabel style.
            if (pickerStyle?.ItemTextLabel != null)
            {
                itemHeight = (int)pickerStyle.ItemTextLabel.Size.Height;

                if (itemList != null)
                    foreach (TextLabel textLabel in itemList)
                        textLabel.ApplyStyle(pickerStyle.ItemTextLabel);
            }

            //Apply PickerCenterLine style.
            if (pickerStyle?.Divider != null && upLine != null && downLine != null)
            {
                upLine.ApplyStyle(pickerStyle.Divider);
                downLine.ApplyStyle(pickerStyle.Divider);
                downLine.PositionY = (int)pickerStyle.Divider.PositionY + itemHeight;
            }
        }
                
        private void Initialize()
        {
            HeightSpecification = LayoutParamPolicies.MatchParent;

            //Picker Using scroller internally. actually it is a kind of scroller which has infinity loop,
            //and item center align features.
            pickerScroller = new PickerScroller(pickerStyle)
            {
                Size = new Size(-1, pickerStyle.Size.Height),
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                //FIXME: Need to expand as many as possible;
                //       When user want to start list middle of the list item. currently confused how to create list before render.
                ScrollAvailableArea = new Vector2(0, 10000),
                Name = "pickerScroller",
            };
            pickerScroller.Scrolling += OnScroll;
            pickerScroller.ScrollAnimationEnded += OnScrollAnimationEnded;
            pickerScroller.ScrollAnimationStarted += OnScrollAnimationStarted;

            itemList = new List<TextLabel>();
            
            minValue = maxValue = currentValue = 0;
            displayedValues = null;
            //Those many flags for min, max, value method calling sequence dependency.
            needItemUpdate = true;
            displayedValuesUpdate = false;
            onAnimation = false;
            loopEnabled = false;

            startScrollOffset = (int)pickerStyle.StartScrollOffset.Height;
            itemHeight = (int)pickerStyle.ItemTextLabel.Size.Height;
            startScrollY = (itemHeight * dummyItemsForLoop) + startScrollOffset;
            startY = startScrollOffset;

            Add(pickerScroller);
            AddLine();
        }

        private void OnValueChanged()
        { 
            ValueChangedEventArgs eventArgs =
                new ValueChangedEventArgs(displayedValuesUpdate ? Int32.Parse(itemList[currentValue].Name) : Int32.Parse(itemList[currentValue].Text));
            ValueChanged?.Invoke(this, eventArgs);
        }

        private void PageAdjust(float positionY)
        {
            //Check the scroll is going out to the dummys if so, bring it back to page.
            if (positionY > -(startScrollY - (itemHeight * 2)))
                pickerScroller.ScrollTo(-positionY + pageSize, false);
            else if (positionY < -(startScrollY + pageSize - (itemHeight * 2)))
                pickerScroller.ScrollTo(-positionY - pageSize, false);
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            if (!loopEnabled || onAnimation || onAlignAnimation) return;
            
            PageAdjust(e.Position.Y);
        }

        private void OnScrollAnimationStarted(object sender, ScrollEventArgs e)
        {
            onAnimation = true;
        }

        private void OnScrollAnimationEnded(object sender, ScrollEventArgs e)
        {
            //Ignore if the scroll position was not changed. (called it from this function)
            if (lastScrollPosion == (int)e.Position.Y) return;

            //Calc offset from closest item.
            int offset = (int)(e.Position.Y + startScrollOffset) % itemHeight;
            if (offset < -(itemHeight / 2)) offset += itemHeight;

            lastScrollPosion = (int)(-e.Position.Y + offset);

            onAnimation = false;
            if (onAlignAnimation) {
                onAlignAnimation = false;
                PageAdjust(e.Position.Y);

                return;
            }

            //Item center align with animation, otherwise changed event emit.
            if (offset != 0) {
                onAlignAnimation = true;
                pickerScroller.ScrollTo(-e.Position.Y + offset, true);
            }
            else {
                currentValue = ((int)(-e.Position.Y / itemHeight) + 2);
                OnValueChanged();
            }
        }

        //This is UI requirement. It helps where exactly center item is.
        private void AddLine()
        {
            upLine = new View(pickerStyle.Divider);
            downLine = new View(pickerStyle.Divider)
            {
                Position = new Position(0, (int)pickerStyle.Divider.PositionY + itemHeight),
            };

            Add(upLine);
            Add(downLine);
        }

        private String GetItemText(bool loopEnabled, int idx)
        {
            if (!loopEnabled) return " ";
            else {
                if (displayedValuesUpdate) {
                    idx = idx - MinValue;
                    if (idx <= displayedValues.Count) {
                        return displayedValues[idx];
                    }
                    return " ";
                }

                return idx.ToString();
            }
        }

        //FIXME: If textVisual can add in scroller please change it to textVisual for performance
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The items are added to itemList and are disposed in Picker.Dispose().")]
        private void AddPickerItem(bool loopEnabled, int idx)
        {
            TextLabel temp = new TextLabel(pickerStyle.ItemTextLabel)
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = GetItemText(loopEnabled, idx),
                Name = idx.ToString(),
            };

            itemList.Add(temp);
            pickerScroller.Add(temp);
        }

        private void UpdateCurrentValue()
        {
            // -2 for center align
            int startItemIdx = (currentValue == 0) ? -2 : currentValue - minValue - 2;

            if (loopEnabled) startY = ((dummyItemsForLoop + startItemIdx) * itemHeight) + startScrollOffset;
            // + 2 for non loop picker center align
            else startY = ((2 + startItemIdx) * itemHeight) + startScrollOffset;
            pickerScroller.ScrollTo(startY, false);
        }

        private void UpdateValueList()
        {
            if (!needItemUpdate) return;
            if (minValue > maxValue) return;

            //FIXME: This is wrong.
            //       But scroller can't update item property after added please fix me.
            if (itemList.Count > 0) {
                itemList.Clear();
                pickerScroller.RemoveAllChildren();
            }

            if (maxValue - minValue + 1 >= scrollVisibleItems)
            {
                loopEnabled = true;
                //Current scroller can't add at specific index.
                //So need below calc.
                int dummyStartIdx = 0;
                if (maxValue - minValue >= dummyItemsForLoop)
                  dummyStartIdx = maxValue - dummyItemsForLoop + 1;
                else
                  dummyStartIdx = maxValue - (dummyItemsForLoop % (maxValue - minValue + 1)) + 1;

                //Start add items in scroller. first dummys for scroll anim.
                for (int i = 0; i < dummyItemsForLoop; i++)
                {
                    if (dummyStartIdx > maxValue) dummyStartIdx = minValue;
                    AddPickerItem(loopEnabled, dummyStartIdx++);
                }
                //Second real items.
                for (int i = minValue; i <= maxValue; i++)
                {
                    AddPickerItem(loopEnabled, i);
                }
                //Last dummys for scroll anim.
                dummyStartIdx = minValue;
                for (int i = 0; i < dummyItemsForLoop; i++)
                {
                    if (dummyStartIdx > maxValue) dummyStartIdx = minValue;
                    AddPickerItem(loopEnabled, dummyStartIdx++);
                }
            }
            else
            {
                loopEnabled = false;

                for (int i = 0; i < 2; i++)
                    AddPickerItem(loopEnabled, 0);
                for (int i = minValue; i <= maxValue; i++)
                    AddPickerItem(!loopEnabled, i);
                for (int i = 0; i < 2; i++)
                    AddPickerItem(loopEnabled, 0);

            }
            pageSize = itemHeight * (maxValue - minValue + 1);

            UpdateCurrentValue();

            //Give a correct scroll area.
            pickerScroller.ScrollAvailableArea = new Vector2(0, (itemList.Count * itemHeight) - pickerStyle.Size.Height);

            needItemUpdate = false;
        }

        internal class PickerScroller : ScrollableBase
        {
            private int itemHeight;
            private int startScrollOffset;
            private float velocityOfLastPan = 0.0f;
            private float panAnimationDuration = 0.0f;
            private float panAnimationDelta = 0.0f;
            private float decelerationRate = 0.0f;
            private float logValueOfDeceleration = 0.0f;
            private delegate float UserAlphaFunctionDelegate(float progress);
            private UserAlphaFunctionDelegate customScrollAlphaFunction;

            public PickerScroller(PickerStyle pickerStyle) : base()
            {
                //Default rate is 0.998. this is for reduce scroll animation length.
                decelerationRate = 0.991f;
                startScrollOffset = (int)pickerStyle.StartScrollOffset.Height;
                itemHeight = (int)pickerStyle.ItemTextLabel.Size.Height;
                logValueOfDeceleration = (float)Math.Log(decelerationRate);
            }

            private float CustomScrollAlphaFunction(float progress)
            {
                if (panAnimationDelta == 0)
                {
                    return 1.0f;
                }
                else
                {
                    // Parameter "progress" is normalized value. We need to multiply target duration to calculate distance.
                    // Can get real distance using equation of deceleration (check Decelerating function)
                    // After get real distance, normalize it
                    float realDuration = progress * panAnimationDuration;
                    float realDistance = velocityOfLastPan * ((float)Math.Pow(decelerationRate, realDuration) - 1) / logValueOfDeceleration;
                    float result = Math.Min(realDistance / Math.Abs(panAnimationDelta), 1.0f);

                    return result;
                }
            }

            //Override Decelerating for Picker feature.
            protected override void Decelerating(float velocity, Animation animation)
            {
                //Reduce Scroll animation speed.
                //The picker is to select items in the scroll area, it is not correct to animate
                //the scroll with very high speed.
                velocity *= 0.5f;
                velocityOfLastPan = Math.Abs(velocity);

                float currentScrollPosition = -ContentContainer.PositionY;
                panAnimationDelta = (velocityOfLastPan * decelerationRate) / (1 - decelerationRate);
                panAnimationDelta = velocity > 0 ? -panAnimationDelta : panAnimationDelta;

                float destination = -(panAnimationDelta + currentScrollPosition);
                //Animation destination has to center of the item.
                float align = destination % itemHeight;
                destination -= align;
                destination -= startScrollOffset;

                float adjustDestination = AdjustTargetPositionOfScrollAnimation(destination);

                float maxPosition = ScrollAvailableArea != null ? ScrollAvailableArea.Y : 0;
                float minPosition = ScrollAvailableArea != null ? ScrollAvailableArea.X : 0;

                if (destination < -maxPosition || destination > minPosition)
                {
                    panAnimationDelta = velocity > 0 ? (currentScrollPosition - minPosition) : (maxPosition - currentScrollPosition);
                    destination = velocity > 0 ? minPosition : -maxPosition;
                    destination = -maxPosition + itemHeight;

                    if (panAnimationDelta == 0)
                    {
                        panAnimationDuration = 0.0f;
                    }
                    else
                    {
                        panAnimationDuration = (float)Math.Log((panAnimationDelta * logValueOfDeceleration / velocityOfLastPan + 1), decelerationRate);
                    }
                }
                else
                {
                    panAnimationDuration = (float)Math.Log(-DecelerationThreshold * logValueOfDeceleration / velocityOfLastPan) / logValueOfDeceleration;

                    if (adjustDestination != destination)
                    {
                        destination = adjustDestination;
                        panAnimationDelta = destination + currentScrollPosition;
                        velocityOfLastPan = Math.Abs(panAnimationDelta * logValueOfDeceleration / ((float)Math.Pow(decelerationRate, panAnimationDuration) - 1));
                        panAnimationDuration = (float)Math.Log(-DecelerationThreshold * logValueOfDeceleration / velocityOfLastPan) / logValueOfDeceleration;
                    }
                }

                customScrollAlphaFunction = new UserAlphaFunctionDelegate(CustomScrollAlphaFunction);
                animation.DefaultAlphaFunction = new AlphaFunction(customScrollAlphaFunction);
                animation.Duration = (int)panAnimationDuration;
                animation.AnimateTo(ContentContainer, "PositionY", (int)destination);
                animation.Play();
            }
        }
    }
}
