/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Tizen.NUI.Accessibility;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Pagination shows the number of pages available and the currently active page.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public partial class Pagination : Control, IAtspiValue
    {
        // Depending on Tizen 7.0 Pagination UX guide
        private const int DefaultIndicatorWidth = 64;
        private const int DefaultIndicatorHeight = 8;
        private const int DefaultIndicatorSpacing = 16;
        private const string DefaultIndicatorColor = "#FAFAFA";
        private const string DefaultSelectedIndicatorColor = "#FFA166";

        private View container;
        private Size indicatorSize = new Size(DefaultIndicatorWidth, DefaultIndicatorHeight);
        private Selector<string> indicatorImageUrl;
        private int indicatorSpacing = DefaultIndicatorSpacing;
        private List<ImageView> indicatorList = new List<ImageView>();

        private int indicatorCount = 0;
        private int selectedIndex = 0;

        private Color indicatorColor;
        private Color selectedIndicatorColor;
        private Selector<string> lastIndicatorImageUrl;

        static Pagination()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IndicatorSizeProperty = BindableProperty.Create(nameof(IndicatorSize), typeof(Size), typeof(Pagination), null,
                    propertyChanged: SetInternalIndicatorSizeProperty, defaultValueCreator: GetInternalIndicatorSizeProperty);
                IndicatorImageUrlProperty = BindableProperty.Create(nameof(IndicatorImageUrl), typeof(Selector<string>), typeof(Pagination), null,
                    propertyChanged: SetInternalIndicatorImageUrlProperty, defaultValueCreator: GetInternalIndicatorImageUrlProperty);
                IndicatorSpacingProperty = BindableProperty.Create(nameof(IndicatorSpacing), typeof(int), typeof(Pagination), default(int),
                    propertyChanged: SetInternalIndicatorSpacingProperty, defaultValueCreator: GetInternalIndicatorSpacingProperty);
                LastIndicatorImageUrlProperty = BindableProperty.Create(nameof(LastIndicatorImageUrl), typeof(Tizen.NUI.BaseComponents.Selector<string>), typeof(Pagination), null,
                    propertyChanged: SetInternalLastIndicatorImageUrlProperty, defaultValueCreator: GetInternalLastIndicatorImageUrlProperty);
                IndicatorCountProperty = BindableProperty.Create(nameof(IndicatorCount), typeof(int), typeof(Pagination), default(int),
                    propertyChanged: SetInternalIndicatorCountProperty, defaultValueCreator: GetInternalIndicatorCountProperty);
                IndicatorColorProperty = BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(Pagination), null,
                    propertyChanged: SetInternalIndicatorColorProperty, defaultValueCreator: GetInternalIndicatorColorProperty);
                SelectedIndicatorColorProperty = BindableProperty.Create(nameof(SelectedIndicatorColor), typeof(Color), typeof(Pagination), null,
                    propertyChanged: SetInternalSelectedIndicatorColorProperty, defaultValueCreator: GetInternalSelectedIndicatorColorProperty);
                SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(Pagination), default(int),
                    propertyChanged: SetInternalSelectedIndexProperty, defaultValueCreator: GetInternalSelectedIndexProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of a Pagination.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Pagination() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a Pagination using style.
        /// </summary>
        /// <param name="style">The string to initialize the Pagination</param>
        /// <since_tizen> 8 </since_tizen>
        public Pagination(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of a Pagination using style.
        /// </summary>
        /// <param name="paginationStyle">The style object to initialize the Pagination</param>
        /// <since_tizen> 8 </since_tizen>
        public Pagination(PaginationStyle paginationStyle) : base(paginationStyle)
        {
        }

        /// <summary>
        /// Return currently applied style.
        /// </summary>
        /// <remarks>
        /// Modifying contents in style may cause unexpected behaviour.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public PaginationStyle Style => (PaginationStyle)(ViewStyle as PaginationStyle)?.Clone();

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Size IndicatorSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size)GetValue(IndicatorSizeProperty);
                }
                else
                {
                    return GetInternalIndicatorSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IndicatorSizeProperty, value);
                }
                else
                {
                    SetInternalIndicatorSize(value);
                }
            }
        }

        private void SetInternalIndicatorSize(Size newValue)
        {
            if (newValue != null)
            {
                indicatorSize = new Size(newValue);
                UpdateVisual();
                UpdateContainer();
            }
        }

        private Size GetInternalIndicatorSize()
        {
            return indicatorSize;
        }

        /// <summary>
        /// Gets or sets the background resource of indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Selector<string> IndicatorImageUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<string>)GetValue(IndicatorImageUrlProperty);
                }
                else
                {
                    return GetInternalIndicatorImageUrl();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IndicatorImageUrlProperty, value);
                }
                else
                {
                    SetInternalIndicatorImageUrl(value);
                }
            }
        }

        private void SetInternalIndicatorImageUrl(Selector<string> newValue)
        {
            indicatorImageUrl = newValue?.Clone();
            UpdateVisual();
        }

        private Selector<string> GetInternalIndicatorImageUrl()
        {
            return indicatorImageUrl;
        }

        /// <summary>
        /// This is experimental API.
        /// Make the last indicator has exceptional image, not common image in the Pagination.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> LastIndicatorImageUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(LastIndicatorImageUrlProperty) as Selector<string>;
                }
                else
                {
                    return InternalLastIndicatorImageUrl;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LastIndicatorImageUrlProperty, value);
                }
                else
                {
                    InternalLastIndicatorImageUrl = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Selector<string> InternalLastIndicatorImageUrl
        {
            get => lastIndicatorImageUrl;
            set
            {
                lastIndicatorImageUrl = value;
                if (value != null && indicatorCount > 0)
                {
                    indicatorList[LastIndicatorIndex].ResourceUrl = IsLastSelected ? value.Selected : value.Normal;
                }
            }
        }

        /// <summary>
        /// Gets or sets the space of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int IndicatorSpacing
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(IndicatorSpacingProperty);
                }
                else
                {
                    return GetInternalIndicatorSpacing();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IndicatorSpacingProperty, value);
                }
                else
                {
                    SetInternalIndicatorSpacing(value);
                }
            }
        }

        private void SetInternalIndicatorSpacing(int newValue)
        {
            indicatorSpacing = newValue;
            UpdateVisual();
        }

        private int GetInternalIndicatorSpacing()
        {
            return indicatorSpacing;
        }

        /// <summary>
        /// Gets or sets the count of the pages/indicators.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when the given value is negative.</exception>
        public int IndicatorCount
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(IndicatorCountProperty);
                }
                else
                {
                    return InternalIndicatorCount;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IndicatorCountProperty, value);
                }
                else
                {
                    InternalIndicatorCount = value;
                }
                NotifyPropertyChanged();
            }
        }
        private int InternalIndicatorCount
        {
            get
            {
                return indicatorCount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Setting {nameof(IndicatorCount)} to negative is not allowed.");
                }

                if (indicatorCount == value)
                {
                    return;
                }

                int prevLastIndex = -1;

                if (indicatorCount < value)
                {
                    prevLastIndex = LastIndicatorIndex;
                    for (int i = indicatorCount; i < value; i++)
                    {
                        CreateIndicator(i);
                    }
                }
                else
                {
                    for (int i = value; i < indicatorCount; i++)
                    {
                        container.Remove(indicatorList[i]);
                    }
                    indicatorList.RemoveRange(value, indicatorCount - value);

                    if (selectedIndex >= value)
                    {
                        selectedIndex = Math.Max(0, value - 1);

                        if (value > 0)
                        {
                            UpdateSelectedIndicator(indicatorList[selectedIndex]);
                        }
                    }
                }
                indicatorCount = value;

                if (lastIndicatorImageUrl != null && indicatorImageUrl != null && indicatorCount > 0)
                {
                    if (prevLastIndex >= 0)
                    {
                        indicatorList[prevLastIndex].ResourceUrl = prevLastIndex == selectedIndex ? indicatorImageUrl.Selected : indicatorImageUrl.Normal;
                    }
                    indicatorList[LastIndicatorIndex].ResourceUrl = IsLastSelected ? lastIndicatorImageUrl.Selected : lastIndicatorImageUrl.Normal;
                }

                UpdateContainer();
            }
        }

        private void OnIndicatorColorChanged(float r, float g, float b, float a)
        {
            IndicatorColor = new Color(r, g, b, a);
        }

        /// <summary>
        /// Color of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Color IndicatorColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(IndicatorColorProperty) as Color;
                }
                else
                {
                    return InternalIndicatorColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IndicatorColorProperty, value);
                }
                else
                {
                    InternalIndicatorColor = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalIndicatorColor
        {
            get
            {
                return new Color(OnIndicatorColorChanged, indicatorColor);
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                if (indicatorColor == null)
                {
                    indicatorColor = new Color((Color)value);
                }
                else
                {
                    if (indicatorColor == value)
                    {
                        return;
                    }

                    indicatorColor = value;
                }

                if (indicatorCount == 0)
                {
                    return;
                }

                for (int i = 0; i < indicatorCount; i++)
                {
                    if (i == selectedIndex)
                    {
                        continue;
                    }

                    indicatorList[i].Color = indicatorColor;
                }
            }
        }

        private void OnSelectedIndicatorColorChanged(float r, float g, float b, float a)
        {
            SelectedIndicatorColor = new Color(r, g, b, a);
        }

        /// <summary>
        /// Color of the selected indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Color SelectedIndicatorColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(SelectedIndicatorColorProperty) as Color;
                }
                else
                {
                    return InternalSelectedIndicatorColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectedIndicatorColorProperty, value);
                }
                else
                {
                    InternalSelectedIndicatorColor = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalSelectedIndicatorColor
        {
            get
            {
                return new Color(OnSelectedIndicatorColorChanged, selectedIndicatorColor);
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                if (selectedIndicatorColor == null)
                {
                    selectedIndicatorColor = new Color((Color)value);
                }
                else
                {
                    if (selectedIndicatorColor == value)
                    {
                        return;
                    }

                    selectedIndicatorColor = value;
                }

                if (indicatorList.Count > selectedIndex)
                {
                    indicatorList[selectedIndex].Color = selectedIndicatorColor;
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the select indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int SelectedIndex
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(SelectedIndexProperty);
                }
                else
                {
                    return InternalSelectedIndex;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectedIndexProperty, value);
                }
                else
                {
                    InternalSelectedIndex =  value;
                }
                NotifyPropertyChanged();
            }
        }
        private int InternalSelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                var refinedValue = Math.Max(0, Math.Min(value, indicatorCount - 1));

                if (selectedIndex == refinedValue)
                {
                    return;
                }

                Debug.Assert(refinedValue >= 0 && refinedValue < indicatorCount);
                Debug.Assert(selectedIndex >= 0 && selectedIndex < indicatorCount);

                UpdateUnselectedIndicator(indicatorList[selectedIndex]);

                selectedIndex = refinedValue;

                UpdateSelectedIndicator(indicatorList[selectedIndex]);

                if (Accessibility.Accessibility.IsEnabled && IsHighlighted)
                {
                    EmitAccessibilityEvent(AccessibilityPropertyChangeEvent.Value);
                }
            }
        }

        /// <summary>
        /// Retrieves the position of a indicator by index.
        /// </summary>
        /// <param name="index">Indicator index</param>
        /// <returns>The position of a indicator by index.</returns>
        /// <since_tizen> 8 </since_tizen>
        public Position GetIndicatorPosition(int index)
        {
            if (index < 0 || index >= indicatorList.Count)
            {
                return null;
            }
            return new Position(indicatorList[index].Position.X + container.PositionX, indicatorList[index].Position.Y + container.PositionY);
        }

        /// <summary>
        /// Minimum value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMinimum()
        {
            return 0.0;
        }

        /// <summary>
        /// Current value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetCurrent()
        {
            return (double)SelectedIndex;
        }

        /// <summary>
        /// Formatted current value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string IAtspiValue.AccessibilityGetValueText()
        {
            return $"{SelectedIndex}";
        }

        /// <summary>
        /// Maximum value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMaximum()
        {
            return (double)IndicatorCount;
        }

        /// <summary>
        /// Current value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IAtspiValue.AccessibilitySetCurrent(double value)
        {
            int integerValue = (int)value;

            if (integerValue >= 0 && integerValue <= IndicatorCount)
            {
                SelectedIndex = integerValue;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Minimum increment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMinimumIncrement()
        {
            return 1.0;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.ScrollBar;
            AccessibilityHighlightable = true;
            AccessibilityAttributes["style"] = "pagecontrolbyvalue";

            container = new View()
            {
                Name = "Container",
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size2D(indicatorSpacing, 0),
                },
                Padding = new Extents(8, 8, 0, 0),
            };
            this.Add(container);

            //TODO: Apply color properties from PaginationStyle class.
            indicatorColor = new Color(DefaultIndicatorColor);
            selectedIndicatorColor = new Color(DefaultSelectedIndicatorColor);
        }

        /// <summary>
        /// You can override it to do your select out operation.
        /// </summary>
        /// <param name="selectOutIndicator">The indicator will be selected out</param>
        /// <since_tizen> 8 </since_tizen>
        protected virtual void SelectOut(VisualMap selectOutIndicator)
        {
            // Currently, this method is not used in this file anymore.
            // However, the implementation inside should remain because someone could be used by overriding it.
            if (!(selectOutIndicator is ImageVisual visual)) return;
            visual.URL = ((IsLastSelected && lastIndicatorImageUrl != null) ? lastIndicatorImageUrl : indicatorImageUrl)?.Normal;

            if (indicatorColor == null)
            {
                visual.MixColor = new Color(DefaultIndicatorColor);
                visual.Opacity = 1.0f;
            }
            else
            {
                visual.MixColor = indicatorColor;
                visual.Opacity = indicatorColor.A;
            }
        }

        /// <summary>
        /// You can override it to do your select in operation.
        /// </summary>
        /// <param name="selectInIndicator">The indicator will be selected in</param>
        /// <since_tizen> 8 </since_tizen>
        protected virtual void SelectIn(VisualMap selectInIndicator)
        {
            // Currently, this method is not used in this file anymore.
            // However, the implementation inside should remain because someone could be used by overriding it.
            if (!(selectInIndicator is ImageVisual visual)) return;
            visual.URL = ((IsLastSelected && lastIndicatorImageUrl != null) ? lastIndicatorImageUrl : indicatorImageUrl)?.Selected;

            if (selectedIndicatorColor == null)
            {
                visual.MixColor = new Color(DefaultSelectedIndicatorColor);
                visual.Opacity = 1.0f;
            }
            else
            {
                visual.MixColor = selectedIndicatorColor;
                visual.Opacity = selectedIndicatorColor.A;
            }
        }

        /// <summary>
        /// you can override it to create your own default style.
        /// </summary>
        /// <returns>The default pagination style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle CreateViewStyle()
        {
            return new PaginationStyle();
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 8 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                for (int i = 0; i < indicatorCount; i++)
                {
                    container.Remove(indicatorList[i]);
                }
                indicatorList.Clear();

                this.Remove(container);
                container.Dispose();
                container = null;
            }

            base.Dispose(type);
        }

        private void UpdateUnselectedIndicator(ImageView indicator)
        {
            if (indicator == null) return;

            if (IsLastSelected && lastIndicatorImageUrl != null)
            {
                indicator.ResourceUrl = lastIndicatorImageUrl.Normal;
            }
            else
            {
                indicator.ResourceUrl = indicatorImageUrl.Normal;
            }

            if (indicatorColor == null)
            {
                indicator.Color = new Color(DefaultIndicatorColor);
            }
            else
            {
                indicator.Color = indicatorColor;
            }
        }

        private void UpdateSelectedIndicator(ImageView indicator)
        {
            if (indicator == null) return;

            if (IsLastSelected && lastIndicatorImageUrl != null)
            {
                indicator.ResourceUrl = lastIndicatorImageUrl.Selected;
            }
            else
            {
                indicator.ResourceUrl = indicatorImageUrl.Selected;
            }

            if (indicatorColor == null)
            {
                indicator.Color = new Color(DefaultSelectedIndicatorColor);
            }
            else
            {
                indicator.Color = indicatorColor;
            }
        }

        private void CreateIndicator(int index)
        {
            Debug.Assert(indicatorSize != null);

            ImageView indicator = new ImageView
            {
                ResourceUrl = indicatorImageUrl?.Normal,
                Size = indicatorSize,
                Color = (indicatorColor == null) ? new Color(DefaultIndicatorColor) : indicatorColor,
            };
            indicatorList.Add(indicator);
            container.Add(indicator);

            if (index == selectedIndex)
            {
                UpdateSelectedIndicator(indicatorList[selectedIndex]);
            }
        }

        private void UpdateContainer()
        {
            Debug.Assert(indicatorSize != null);

            if (indicatorList.Count > 0)
            {
                container.SizeWidth = (indicatorSize.Width + indicatorSpacing) * indicatorList.Count - indicatorSpacing;
            }
            else
            {
                container.SizeWidth = 0;
            }
            container.SizeHeight = indicatorSize.Height;
            container.PositionX = (int)((this.SizeWidth - container.SizeWidth) / 2);
        }

        private void UpdateVisual()
        {
            Debug.Assert(indicatorSize != null);

            if (indicatorImageUrl == null)
            {
                return;
            }

            if (container != null && (container.Layout is LinearLayout linearLayout))
            {
                linearLayout.CellPadding = new Size2D(indicatorSpacing, 0);
            }

            for (int i = 0; i < indicatorList.Count; i++)
            {
                ImageView indicator = indicatorList[i];
                indicator.ResourceUrl = selectedIndex == i ? indicatorImageUrl.Selected : indicatorImageUrl.Normal;
                indicator.Size = indicatorSize;
            }

            if (lastIndicatorImageUrl != null && indicatorCount > 0)
            {
                indicatorList[LastIndicatorIndex].ResourceUrl = IsLastSelected ? lastIndicatorImageUrl.Selected : lastIndicatorImageUrl.Normal;
            }
        }

        private int LastIndicatorIndex => IndicatorCount - 1;
        private bool IsLastSelected => LastIndicatorIndex == selectedIndex;
    }
}
