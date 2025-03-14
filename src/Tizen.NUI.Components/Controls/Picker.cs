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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ValueChangedEventArgs is a class to notify changed Picker value argument which will sent to user.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
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
        /// <since_tizen> 9 </since_tizen>
        public int Value { get; }

    }

    /// <summary>
    /// Picker is a class which provides a function that allows the user to select
    /// a value through a scrolling motion by expressing the specified value as a list.
    /// It is recommended to use when selecting less than 100 selections.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class Picker : Control
    {
        //Tizen 6.5 base components Picker guide visible scroll item is 5.
        private const int scrollVisibleItems = 5;
        //Dummy item count for loop feature. Max value of scrolling distance in
        //RPI target is bigger than 20 items height. it can adjust depends on the internal logic and device env.
        private const int dummyItemsForLoop = 20;
        private const int middleItemIdx = 2;
        private int startScrollOffset;
        private int itemHeight;
        private int startScrollY;
        private int startY;
        private int pageSize;
        private int currentValue;
        private int maxValue;
        private int minValue;
        private int currentIdx;
        private int lastScrollPosion;
        private int accessibilityHiddenStartIdx;
        private bool onAnimation; //Scroller on animation check.
        private bool onAlignAnimation;
        private bool displayedValuesUpdate; //User sets displayed value check.
        private bool needItemUpdate; //min, max or display value updated check.
        private bool loopEnabled;
        private bool isScreenReaderEnabled;
        private bool isAtspiEnabled;
        private ReadOnlyCollection<string> displayedValues;
        private PickerScroller pickerScroller;
        private IList<TextLabel> itemList;
        private Vector2 size;
        private TextLabelStyle itemTextLabel;
        private bool keyEditMode = false;
        private View recoverIndicator = null;
        private View keyEditModeIndicator = null;
        private View UpperMask = null; //For Tizen 7.0 UX
        private View LowerMask = null; //For Tizen 7.0 UX

        static Picker()
        {
            if (NUIApplication.IsUsingXaml)
            {
                CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(int), typeof(Picker), default(int),
                    propertyChanged: SetInternalCurrentValueProperty, defaultValueCreator: GetInternalCurrentValueProperty);
                MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(Picker), default(int),
                    propertyChanged: SetInternalMaxValueProperty, defaultValueCreator: GetInternalMaxValueProperty);
                MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(int), typeof(Picker), default(int),
                    propertyChanged: SetInternalMinValueProperty, defaultValueCreator: GetInternalMinValueProperty);
            }
        }


        /// <summary>
        /// Creates a new instance of Picker.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Picker()
        {
        }

        /// <summary>
        /// Creates a new instance of Picker.
        /// </summary>
        /// <param name="style">Creates Picker by special style defined in UX.</param>
        /// <since_tizen> 9 </since_tizen>
        public Picker(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of Picker.
        /// </summary>
        /// <param name="pickerStyle">Creates Picker by style customized by user.</param>
        /// <since_tizen> 9 </since_tizen>
        public Picker(PickerStyle pickerStyle) : base(pickerStyle)
        {
        }


        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnEnabled(bool enabled)
        {
            base.OnEnabled(enabled);

            pickerScroller.IsEnabled = enabled;
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

                Remove(UpperMask);
                Utility.Dispose(UpperMask);
                Remove(LowerMask);
                Utility.Dispose(LowerMask);

                recoverIndicator = null;
                if (keyEditModeIndicator)
                {
                    keyEditModeIndicator.Dispose();
                    keyEditModeIndicator = null;
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// An event emitted when Picker value changed, user can subscribe or unsubscribe to this event handler.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        //TODO Fomatter here

        /// <summary>
        /// The values to be displayed instead of numbers.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
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
        /// <since_tizen> 9 </since_tizen>
        public int CurrentValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(CurrentValueProperty);
                }
                else
                {
                    return InternalCurrentValue;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CurrentValueProperty, value);
                }
                else
                {
                    InternalCurrentValue =  value;
                }
                NotifyPropertyChanged();
            }
        }
        private int InternalCurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                if (currentValue == value) return;
                if (value < minValue) currentValue = minValue;
                else if (value > maxValue) currentValue = maxValue;
                else currentValue = value;

                UpdateCurrentValue();
            }
        }

        /// <summary>
        /// The max value of Picker.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public int MaxValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(MaxValueProperty);
                }
                else
                {
                    return InternalMaxValue;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MaxValueProperty, value);
                }
                else
                {
                    InternalMaxValue =  value;
                }
                NotifyPropertyChanged();
            }
        }
        private int InternalMaxValue
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
        /// <since_tizen> 9 </since_tizen>
        public int MinValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(MinValueProperty);
                }
                else
                {
                    return InternalMinValue;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MinValueProperty, value);
                }
                else
                {
                    InternalMinValue = value;
                }
                NotifyPropertyChanged();
            }
        }
        private int InternalMinValue
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.List;

            Initialize();
        }

        /// <summary>
        /// Applies style to Picker.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            var pickerStyle = viewStyle as PickerStyle;

            if (pickerStyle == null) return;

            pickerScroller?.SetPickerStyle(pickerStyle);

            //Apply StartScrollOffset style.
            if (pickerStyle.StartScrollOffset != null)
            {
                startScrollOffset = (int)pickerStyle.StartScrollOffset.Height;
            }

            //Apply ItemTextLabel style.
            if (pickerStyle.ItemTextLabel != null)
            {
                if (itemTextLabel == null)
                {
                    itemTextLabel = (TextLabelStyle)pickerStyle.ItemTextLabel.Clone();
                }
                else
                {
                    itemTextLabel.MergeDirectly(pickerStyle.ItemTextLabel);
                }

                itemHeight = (int)(pickerStyle.ItemTextLabel.Size?.Height ?? 0);

                if (itemList != null)
                    foreach (TextLabel textLabel in itemList)
                        textLabel.ApplyStyle(pickerStyle.ItemTextLabel);

                if (UpperMask != null && LowerMask != null)
                {
                    UpperMask.SizeHeight = itemHeight * middleItemIdx;
                    LowerMask.SizeHeight = itemHeight * middleItemIdx;
                    LowerMask.PositionY = itemHeight * (middleItemIdx + 1);
                    UpperMask.BackgroundColor = pickerStyle.ItemTextLabel.BackgroundColor.All;
                    LowerMask.BackgroundColor = pickerStyle.ItemTextLabel.BackgroundColor.All;
                }
            }

            startScrollY = (itemHeight * dummyItemsForLoop) + startScrollOffset;
            startY = startScrollOffset;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            if (size == null) return;

            if (size.Equals(this.size))
            {
                return;
            }

            this.size = new Vector2(size);

            if (pickerScroller != null && itemList != null)
            {
                pickerScroller.ScrollAvailableArea = new Vector2(0, (itemList.Count * itemHeight) - (itemHeight * scrollVisibleItems));
            }
        }

        private void AccessibilityEnabled()
        {
            if (loopEnabled) ShowItemsForAccessibility(currentIdx - middleItemIdx);
            else
            {
                //Exception case handling condition state.
                //If user sets 4 items it can scroll but not loop.
                if (currentIdx > (middleItemIdx * 2)) ShowItemsForAccessibility(middleItemIdx + 1);
                else ShowItemsForAccessibility(middleItemIdx);
            }
        }

        private void Initialize()
        {
            //Picker Using scroller internally. actually it is a kind of scroller which has infinity loop,
            //and item center align features.
            pickerScroller = new PickerScroller()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                //FIXME: Need to expand as many as possible;
                //       When user want to start list middle of the list item. currently confused how to create list before render.
                ScrollAvailableArea = new Vector2(0, 30000),
                Name = "pickerScroller",
            };

            pickerScroller.Scrolling += OnScroll;
            pickerScroller.ScrollAnimationEnded += OnScrollAnimationEnded;
            pickerScroller.ScrollAnimationStarted += OnScrollAnimationStarted;

            itemList = new List<TextLabel>();

            minValue = maxValue = currentValue = currentIdx = 0;
            displayedValues = null;
            //Those many flags for min, max, value method calling sequence dependency.
            needItemUpdate = true;
            displayedValuesUpdate = false;
            onAnimation = false;
            loopEnabled = false;
            lastScrollPosion = (int)pickerScroller.ScrollAvailableArea.Y;

            Add(pickerScroller);
            AddMasks();

            Focusable = true;
            KeyEvent += OnKeyEvent;

            Accessibility.Accessibility.Enabled += (s, e) => {
                isAtspiEnabled = true;
                if (!needItemUpdate) AccessibilityEnabled();
            };
            Accessibility.Accessibility.Disabled += (s, e) => {
                isAtspiEnabled = false;
                if (!needItemUpdate) HideItemsForAccessibility();
            };
            Accessibility.Accessibility.ScreenReaderEnabled += (s, e) => {
                isScreenReaderEnabled = true;
            };
            Accessibility.Accessibility.ScreenReaderDisabled += (s, e) => {
                isScreenReaderEnabled = false;
            };

            isAtspiEnabled = Accessibility.Accessibility.IsEnabled;
            isScreenReaderEnabled = Accessibility.Accessibility.IsScreenReaderEnabled;

        }

        private void HideItemsForAccessibility()
        {
            if (loopEnabled)
                for (int i = accessibilityHiddenStartIdx; i < (accessibilityHiddenStartIdx + scrollVisibleItems); i++)
                    itemList[i].AccessibilityHidden = true;
            else
            {
                if (currentIdx > (middleItemIdx * 2))
                    for (int i = accessibilityHiddenStartIdx; i < (accessibilityHiddenStartIdx + (maxValue - minValue)); i++)
                        itemList[i].AccessibilityHidden = true;
                else
                    for (int i = accessibilityHiddenStartIdx; i < (accessibilityHiddenStartIdx + (maxValue - minValue + 1)); i++)
                        itemList[i].AccessibilityHidden = true;
            }
        }

        private void ShowItemsForAccessibility(int startIdx)
        {
            if (startIdx < 0) {
                Tizen.Log.Error("NUI", "ScreenReaderEnabled signal emitted before picker value initialize");
                return;
            }

            accessibilityHiddenStartIdx = startIdx;
            if (loopEnabled)
                for (int i = accessibilityHiddenStartIdx; i < (accessibilityHiddenStartIdx + scrollVisibleItems); i++)
                    itemList[i].AccessibilityHidden = false;
            else
            {
                if (currentIdx > (middleItemIdx * 2))
                    for (int i = accessibilityHiddenStartIdx; i < (accessibilityHiddenStartIdx + (maxValue - minValue)); i++)
                        itemList[i].AccessibilityHidden = false;
                else
                    for (int i = accessibilityHiddenStartIdx; i < (accessibilityHiddenStartIdx + (maxValue - minValue + 1)); i++)
                        itemList[i].AccessibilityHidden = false;
            }
        }

        private void OnValueChanged()
        {
            if (isAtspiEnabled)
            {
                if (loopEnabled) {
                    HideItemsForAccessibility();
                    ShowItemsForAccessibility(currentIdx - middleItemIdx);
                }
                if (isScreenReaderEnabled) itemList[currentIdx].GrabAccessibilityHighlight();
            }

            currentValue = displayedValuesUpdate ? Int32.Parse(itemList[currentIdx].Name) : Int32.Parse(itemList[currentIdx].Text);
            ValueChangedEventArgs eventArgs =
                new ValueChangedEventArgs(displayedValuesUpdate ? Int32.Parse(itemList[currentIdx].Name) : Int32.Parse(itemList[currentIdx].Text));
            ValueChanged?.Invoke(this, eventArgs);
        }

        private void PageAdjust(float positionY)
        {
            //Check the scroll is going out to the dummies if so, bring it back to page.
            if (positionY > -(startScrollY - (itemHeight * middleItemIdx)))
                pickerScroller.ScrollTo(-positionY + pageSize, false);
            else if (positionY < -(startScrollY + pageSize - (itemHeight * middleItemIdx)))
                pickerScroller.ScrollTo(-positionY - pageSize, false);
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            if (!loopEnabled || onAnimation || onAlignAnimation) return;

            if (isAtspiEnabled) Accessibility.Accessibility.ClearCurrentlyHighlightedView();

            PageAdjust(e.Position.Y);
        }

        private void OnScrollAnimationStarted(object sender, ScrollEventArgs e)
        {
            onAnimation = true;
        }

        private void OnScrollAnimationEnded(object sender, ScrollEventArgs e)
        {
            //Ignore if the scroll position was not changed. (called it from this function)
            if (lastScrollPosion == (int)e.Position.Y && !onAlignAnimation) return;

            //Calc offset from closest item.
            int offset = (int)(e.Position.Y + startScrollOffset) % itemHeight;
            if (offset < -(itemHeight / 2)) offset += itemHeight;

            lastScrollPosion = (int)(-e.Position.Y + offset);

            onAnimation = false;
            if (onAlignAnimation)
            {
                onAlignAnimation = false;
                if (loopEnabled == true)
                {
                    PageAdjust(e.Position.Y);
                }
                if (currentIdx != ((int)(-e.Position.Y / itemHeight) + middleItemIdx))
                {
                    currentIdx = ((int)(-e.Position.Y / itemHeight) + middleItemIdx);
                    OnValueChanged();
                }

                return;
            }

            //Item center align with animation, otherwise changed event emit.
            if (offset != 0)
            {
                onAlignAnimation = true;
                pickerScroller.ScrollTo(-e.Position.Y + offset, true);
            }
            else
            {
                if (currentIdx != ((int)(-e.Position.Y / itemHeight) + middleItemIdx))
                {
                    currentIdx = ((int)(-e.Position.Y / itemHeight) + middleItemIdx);
                    OnValueChanged();
                }
            }
        }

        //This is an UX requirement. It gives highlight on center item area.
        private void AddMasks()
        {
            UpperMask = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Opacity = 0.7f,
                AccessibilityHidden = true,
            };

            LowerMask = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Opacity = 0.7f,
                AccessibilityHidden = true,
            };

            Add(UpperMask);
            Add(LowerMask);
        }

        private String GetItemText(bool loopEnabled, int idx)
        {
            if (!loopEnabled) return " ";
            else
            {
                if (displayedValuesUpdate)
                {
                    idx = idx - MinValue;
                    if (idx <= displayedValues.Count)
                    {
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
            TextLabel temp = new TextLabel(itemTextLabel)
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = GetItemText(loopEnabled, idx),
                Name = idx.ToString(),
            };

            temp.AccessibilitySuppressedEvents[AccessibilityEvent.MovedOut] = true;
            // Hide on Accessibility tree
            if (isAtspiEnabled) temp.AccessibilityHidden = true;
            itemList.Add(temp);
            pickerScroller.Add(temp);
        }

        private void UpdateCurrentValue()
        {
            // -2 for center align
            int startItemIdx = (currentValue == 0) ? -middleItemIdx : currentValue - minValue - middleItemIdx;

            if (loopEnabled)
            {
                startY = ((dummyItemsForLoop + startItemIdx) * itemHeight) + startScrollOffset;
                currentIdx = dummyItemsForLoop + startItemIdx + middleItemIdx;

                if (isAtspiEnabled)
                {
                    HideItemsForAccessibility();
                    ShowItemsForAccessibility(dummyItemsForLoop + startItemIdx);
                }
            }
            // + 2 for non loop picker center align
            else
            {
                startY = ((middleItemIdx + startItemIdx) * itemHeight) + startScrollOffset;
                currentIdx = currentValue - minValue + middleItemIdx;

                if (isAtspiEnabled)
                {
                    HideItemsForAccessibility();
                    AccessibilityEnabled();
                }
            }
            pickerScroller.ScrollTo(startY, false);
        }

        private void UpdateValueList()
        {
            if (!needItemUpdate) return;
            if (minValue > maxValue) return;

            //FIXME: This is wrong.
            //       But scroller can't update item property after added please fix me.
            if (itemList.Count > 0)
            {
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

                for (int i = 0; i < middleItemIdx; i++)
                    AddPickerItem(loopEnabled, 0);
                for (int i = minValue; i <= maxValue; i++)
                    AddPickerItem(!loopEnabled, i);
                for (int i = 0; i < middleItemIdx; i++)
                    AddPickerItem(loopEnabled, 0);

            }
            pageSize = itemHeight * (maxValue - minValue + 1);

            UpdateCurrentValue();

            //Give a correct scroll area.
            if (size != null)
            {
                pickerScroller.ScrollAvailableArea = new Vector2(0, (itemList.Count * itemHeight) - (itemHeight * scrollVisibleItems));
            }

            needItemUpdate = false;
        }

        private bool OnKeyEvent(object o, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    if (keyEditMode)
                    {
                        //set keyEditMode false (toggle the mode)
                        keyEditMode = false;
                        FocusManager.Instance.FocusIndicator = recoverIndicator;
                        return true;
                    }
                    else
                    {
                        //set keyEditMode true (toggle the mode)
                        keyEditMode = true;
                        if (keyEditModeIndicator == null)
                        {
                            keyEditModeIndicator = new View()
                            {
                                PositionUsesPivotPoint = true,
                                PivotPoint = new Position(0, 0, 0),
                                WidthResizePolicy = ResizePolicyType.FillToParent,
                                HeightResizePolicy = ResizePolicyType.FillToParent,
                                BorderlineColor = Color.Red,
                                BorderlineWidth = 6.0f,
                                BorderlineOffset = -1f,
                                BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 0.4f),
                            };
                        }
                        recoverIndicator = FocusManager.Instance.FocusIndicator;
                        FocusManager.Instance.FocusIndicator = keyEditModeIndicator;

                        return true;
                    }
                }

                else if (keyEditMode && (e.Key.KeyPressedName == "Up" || e.Key.KeyPressedName == "Down"))
                {
                    if (e.Key.KeyPressedName == "Up")
                    {
                        currentValue += 1;
                        if (currentValue > maxValue)
                        {
                            if (loopEnabled) currentValue = minValue;
                            else
                            {
                                currentValue--;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        currentValue -= 1;
                        if (currentValue < minValue)
                        {
                            if (loopEnabled) currentValue = maxValue;
                            else
                            {
                                currentValue++;
                                return true;
                            }
                        }
                    }

                    UpdateCurrentValue();
                    OnValueChanged();

                    return true;
                }

                if (keyEditMode)
                {
                    return true;
                }
            }

            return false;
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

            public PickerScroller() : base()
            {
                //Default rate is 0.998. this is for reduce scroll animation length.
                decelerationRate = 0.991f;
                logValueOfDeceleration = (float)Math.Log(decelerationRate);
            }

            public void SetPickerStyle(PickerStyle pickerStyle)
            {
                if (pickerStyle.StartScrollOffset != null)
                {
                    startScrollOffset = (int)pickerStyle.StartScrollOffset.Height;
                }

                if (pickerStyle.ItemTextLabel?.Size is var itemSize && itemSize != null)
                {
                    itemHeight = (int)itemSize.Height;
                }

                if (pickerStyle.Size is var pSize && pSize != null)
                {
                    Size = new Size(-1, pSize.Height);
                }
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

                    // This is hot-fix for if the velocity has very small value, result is not updated even progress done.
                    if (progress > 0.99) result = 1.0f;

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
                GC.KeepAlive(customScrollAlphaFunction);
                animation.Duration = (int)panAnimationDuration;
                animation.AnimateTo(ContentContainer, "PositionY", (int)destination);
                animation.Play();
            }
        }
    }
}
