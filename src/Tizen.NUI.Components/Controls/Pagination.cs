/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Pagination shows the number of pages available and the currently active page.
    /// </summary>
    /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Pagination : Control
    {
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorImageURLProperty = BindableProperty.Create(nameof(IndicatorImageURL), typeof(Selector<string>), typeof(Pagination), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.indicatorImageURL = (Selector<string>)newValue;
                instance.UpdateVisual();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Pagination)bindable;
            return instance.indicatorImageURL;
        });

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSizeProperty = BindableProperty.Create(nameof(IndicatorSize), typeof(Size), typeof(Pagination), new Size(0, 0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.indicatorSize = (Size)newValue;
                instance.UpdateVisual();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Pagination)bindable;
            return instance.indicatorSize;
        });

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorSpacingProperty = BindableProperty.Create(nameof(IndicatorSpacing), typeof(int), typeof(Pagination), (int) 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Pagination)bindable;
            if (newValue != null)
            {
                instance.indicatorSpacing = (int)newValue;
                instance.UpdateVisual();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Pagination)bindable;
            return instance.indicatorSpacing;
        });

        private VisualView container = null;

        private List<ImageVisual> indicatorList = new List<ImageVisual>();

        private int indicatorCount = 0;
        private int selectedIndex = -1;
        private Size indicatorSize = null;
        private Selector<string> indicatorImageURL = new Selector<string>();
        private int indicatorSpacing = 0;

        static Pagination() { }

        /// <summary>
        /// Creates a new instance of a Pagination.
        /// </summary>
	    /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
	    [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Pagination using style.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Pagination using style.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination(PaginationStyle paginationStyle) : base(paginationStyle)
        {
            Initialize();
        }

        /// <summary>
        /// Return a copied Style instance of Pagination
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Pagination.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        public new PaginationStyle Style
        {
            get
            {
                return new PaginationStyle(ViewStyle as PaginationStyle);
            }
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size IndicatorSize
        {
            get
            {
                return (Size)GetValue(IndicatorSizeProperty);
            }
            set
            {
                SetValue(IndicatorSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the background resource of indicator.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> IndicatorImageURL
        {
            get
            {
                return (Selector<string>)GetValue(IndicatorImageURLProperty);
            }
            set
            {
                SetValue(IndicatorImageURLProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the space of the indicator.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndicatorSpacing
        {
            get
            {
                return (int)GetValue(IndicatorSpacingProperty);
            }
            set
            {
                SetValue(IndicatorSpacingProperty, value);
            }
        }


        /// <summary>
        /// Gets or sets the count of the pages/indicators.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndicatorCount
        {
            get
            {
                return indicatorCount;
            }
            set
            {
                if (indicatorCount == value || indicatorCount < 0)
                {
                    return;
                }
                if (indicatorCount < value)
                {
                    for (int i = indicatorCount; i < value; i++)
                    {
                        CreateIndicator();
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
                    //if(value <= 0)
                    //{
                    //    container.RemoveVisual("SelectIndicator");
                    //}
                    //else
                    if (selectedIndex >= value)
                    {
                        selectedIndex = 0;
                        SelectIn(indicatorList[selectedIndex]);
                    }
                }
                indicatorCount = value;

                UpdateContainer();
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the index of the select indicator.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (selectedIndex == value)
                {
                    return;
                }
                if (selectedIndex >= 0 && selectedIndex < indicatorCount)
                {
                    SelectOut(indicatorList[selectedIndex]);
                }
                selectedIndex = value;
                if (selectedIndex >= 0 && selectedIndex < indicatorCount)
                {
                    SelectIn(indicatorList[selectedIndex]);
                }
            }
        }

        /// <summary>
        /// Retrieves the position of a indicator by index.
        /// </summary>
        /// <param name="index">Indicator index</param>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position GetIndicatorPosition(int index)
        {
            if (index < 0 || index >= indicatorList.Count)
            {
                return null;
            }
            return new Position(indicatorList[index].Position.X + container.PositionX, indicatorList[index].Position.Y + container.PositionY);
        }

        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);
            PaginationStyle style = viewStyle as PaginationStyle;
            if (null != style)
            {
                UpdateVisual();
            }
        }

        /// <summary>
        /// You can override it to do your select out operation.
        /// </summary>
        /// <param name="selectOutIndicator">The indicator will be selected out</param>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SelectOut(VisualMap selectOutIndicator)
        {
            if (!(selectOutIndicator is ImageVisual visual)) return;
            visual.URL = indicatorImageURL.Normal;
            visual.Opacity = 0.5f;
        }

        /// <summary>
        /// You can override it to do your select in operation.
        /// </summary>
        /// <param name="selectInIndicator">The indicator will be selected in</param>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SelectIn(VisualMap selectInIndicator)
        {
            if (!(selectInIndicator is ImageVisual visual)) return;
            visual.URL = indicatorImageURL.Selected;
            visual.Opacity = 1.0f;
        }

        /// <summary>
        /// you can override it to create your own default style.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new PaginationStyle();
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        private void Initialize()
        {
            container = new VisualView()
            {
                Name = "Container",
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
            };
            this.Add(container);
        }

        private void CreateIndicator()
        {
            ImageVisual indicator = new ImageVisual
            {
                URL = indicatorImageURL.Normal,
                Size = new Size((int)indicatorSize.Width, (int)indicatorSize.Height),
                Opacity = 0.5f,
            };
            indicator.Position = new Position2D((int)(indicatorSize.Width + indicatorSpacing) * indicatorList.Count, 0);
            container.AddVisual("Indicator" + indicatorList.Count, indicator);
            indicatorList.Add(indicator);
        }

        private void UpdateContainer()
        {
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
            if (null == indicatorSize) return;
            if (null == indicatorImageURL) return;
            if (indicatorCount < 0) return;

            for (int i = 0; i < indicatorList.Count; i++)
            {
                ImageVisual indicator = indicatorList[i];
                indicator.URL = indicatorImageURL.Normal;
                indicator.Size = new Size((int)indicatorSize.Width, (int)indicatorSize.Height);
                indicator.Position = new Position2D((int)(indicatorSize.Width + indicatorSpacing) * i, 0);
            }
        }
    }
}
