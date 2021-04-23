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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Pagination shows the number of pages available and the currently active page.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class Pagination : Control
    {
        /// <summary>The IndicatorSize bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSizeProperty = BindableProperty.Create(nameof(IndicatorSize), typeof(Size), typeof(Pagination), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (newValue != null)
            {
                var pagination = (Pagination)bindable;
                pagination.indicatorSize = new Size((Size)newValue);
                pagination.UpdateVisual();
                pagination.UpdateContainer();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Pagination)bindable).indicatorSize;
        });

        /// <summary>The IndicatorImageUrlSelector bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorImageUrlProperty = BindableProperty.Create("IndicatorImageUrl", typeof(Selector<string>), typeof(Pagination), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var pagination = (Pagination)bindable;
            pagination.indicatorImageUrl = ((Selector<string>)newValue)?.Clone();
            pagination.UpdateVisual();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Pagination)bindable).indicatorImageUrl;
        });

        /// <summary>The IndicatorSpacing bindable property.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSpacingProperty = BindableProperty.Create(nameof(IndicatorSpacing), typeof(int), typeof(Pagination), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var pagination = (Pagination)bindable;
            pagination.indicatorSpacing = (int)newValue;
            pagination.UpdateVisual();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Pagination)bindable).indicatorSpacing;
        });

        private VisualView container;
        private Size indicatorSize = new Size(10, 10);
        private Selector<string> indicatorImageUrl;
        private int indicatorSpacing;
        private List<ImageVisual> indicatorList = new List<ImageVisual>();

        private int indicatorCount = 0;
        private int selectedIndex = 0;

        private Color indicatorColor;
        private Color selectedIndicatorColor;
        private Selector<string> lastIndicatorImageUrl;

        static Pagination() { }

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
            get => (Size)GetValue(IndicatorSizeProperty);
            set => SetValue(IndicatorSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the background resource of indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Selector<string> IndicatorImageUrl
        {
            get => (Selector<string>)GetValue(IndicatorImageUrlProperty);
            set => SetValue(IndicatorImageUrlProperty, value);
        }

        /// <summary>
        /// This is experimental API.
        /// Make the last indicator has exceptional image, not common image in the Pagination.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> LastIndicatorImageUrl
        {
            get => lastIndicatorImageUrl;
            set
            {
                lastIndicatorImageUrl = value;
                if (value != null && indicatorCount > 0)
                {
                    indicatorList[LastIndicatorIndex].URL = IsLastSelected ? value.Selected : value.Normal;
                }
            }
        }

        /// <summary>
        /// Gets or sets the space of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public int IndicatorSpacing
        {
            get => (int)GetValue(IndicatorSpacingProperty);
            set => SetValue(IndicatorSpacingProperty, value);
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
                        ImageVisual indicator = indicatorList[i];
                        container.RemoveVisual("Indicator" + i);
                    }
                    indicatorList.RemoveRange(value, indicatorCount - value);

                    if (selectedIndex >= value)
                    {
                        selectedIndex = Math.Max(0, value - 1);

                        if (value > 0)
                        {
                            SelectIn(indicatorList[selectedIndex]);
                        }
                    }
                }
                indicatorCount = value;

                if (lastIndicatorImageUrl != null && indicatorImageUrl != null && indicatorCount > 0)
                {
                    if (prevLastIndex >= 0)
                    {
                        indicatorList[prevLastIndex].URL = prevLastIndex == selectedIndex ? indicatorImageUrl.Selected : indicatorImageUrl.Normal;
                    }
                    indicatorList[LastIndicatorIndex].URL = IsLastSelected ? lastIndicatorImageUrl.Selected : lastIndicatorImageUrl.Normal;
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

                    ImageVisual indicator = indicatorList[i];
                    indicator.MixColor = indicatorColor;
                    indicator.Opacity = indicatorColor.A;
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
                    var indicator = indicatorList[selectedIndex];
                    indicator.MixColor = selectedIndicatorColor;
                    indicator.Opacity = selectedIndicatorColor.A;
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

                SelectOut(indicatorList[selectedIndex]);

                selectedIndex = refinedValue;

                SelectIn(indicatorList[selectedIndex]);
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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            container = new VisualView()
            {
                Name = "Container",
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
            };
            this.Add(container);

            //TODO: Apply color properties from PaginationStyle class.
            indicatorColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            selectedIndicatorColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        /// <summary>
        /// You can override it to do your select out operation.
        /// </summary>
        /// <param name="selectOutIndicator">The indicator will be selected out</param>
        /// <since_tizen> 8 </since_tizen>
        protected virtual void SelectOut(VisualMap selectOutIndicator)
        {
            if (!(selectOutIndicator is ImageVisual visual)) return;
            visual.URL = ((IsLastSelected && lastIndicatorImageUrl != null) ? lastIndicatorImageUrl : indicatorImageUrl)?.Normal;

            if (indicatorColor == null)
            {
                //TODO: Apply color properties from PaginationStyle class.
                visual.MixColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                visual.Opacity = 0.5f;
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
            if (!(selectInIndicator is ImageVisual visual)) return;
            visual.URL = ((IsLastSelected && lastIndicatorImageUrl != null) ? lastIndicatorImageUrl : indicatorImageUrl)?.Selected;

            if (selectedIndicatorColor == null)
            {
                //TODO: Apply color properties from PaginationStyle class.
                visual.MixColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
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
                container.RemoveAll();
                indicatorList.Clear();

                this.Remove(container);
                container.Dispose();
                container = null;
            }

            base.Dispose(type);
        }

        private void CreateIndicator(int index)
        {
            Debug.Assert(indicatorSize != null);

            ImageVisual indicator = new ImageVisual
            {
                URL = indicatorImageUrl?.Normal,
                Size = indicatorSize,
                //TODO: Apply color properties from PaginationStyle class.
                MixColor = (indicatorColor == null) ? new Color(1.0f, 1.0f, 1.0f, 0.5f) : indicatorColor,
                Opacity = (indicatorColor == null) ? 0.5f : indicatorColor.A
            };
            indicator.Position = new Vector2((int)(indicatorSize.Width + indicatorSpacing) * indicatorList.Count, 0);
            container.AddVisual("Indicator" + indicatorList.Count, indicator);
            indicatorList.Add(indicator);

            if (index == selectedIndex)
            {
                SelectIn(indicatorList[selectedIndex]);
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

            for (int i = 0; i < indicatorList.Count; i++)
            {
                ImageVisual indicator = indicatorList[i];
                indicator.URL = indicatorImageUrl?.Normal;
                indicator.Size = indicatorSize;
                indicator.Position = new Vector2((int)(indicatorSize.Width + indicatorSpacing) * i, 0);
            }

            if (lastIndicatorImageUrl != null && indicatorCount > 0)
            {
                indicatorList[LastIndicatorIndex].URL = lastIndicatorImageUrl.Normal;
            }
        }

        private int LastIndicatorIndex => IndicatorCount - 1;
        private bool IsLastSelected => LastIndicatorIndex == selectedIndex;
    }
}
