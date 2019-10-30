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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Pagination shows the number of pages available and the currently active page.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    public class Pagination: Control
    {
        private PaginationAttributes paginationAttributes;

        private VisualView container;

        private List<ImageVisual> indicatorList = new List<ImageVisual>();
        private ImageVisual selectIndicator;

        private int indicatorCount = 0;
        private int selectedIndex = -1;

        /// <summary>
        /// Creates a new instance of a Pagination.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
	    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public Pagination() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Pagination using style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Pagination using attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination(PaginationAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public Size IndicatorSize
        {
            get
            {
                return paginationAttributes?.IndicatorSize;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSize = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets the background resource of indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public string IndicatorBackgroundURL
        {
            get
            {
                return paginationAttributes?.IndicatorBackgroundURL;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorBackgroundURL = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets the resource of the select indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public string IndicatorSelectURL
        {
            get
            {
                return paginationAttributes?.IndicatorSelectURL;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSelectURL = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Gets or sets the space of the indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int IndicatorSpacing
        {
            get
            {
                return (int)paginationAttributes?.IndicatorSpacing;
            }
            set
            {
                if (paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSpacing = value;
                RelayoutRequest();
            }
        }


        /// <summary>
        /// Gets or sets the count of the pages/indicators.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    if(value <= 0)
                    {
                        container.RemoveVisual("SelectIndicator");
                    }
                    else if(selectedIndex >= value)
                    {
                        selectedIndex = 0;
                        SelectIn(indicatorList[selectedIndex]);
                    }
                }
                indicatorCount = value;

                UpdateContainer();
            }
        }

        /// <summary>
        /// Gets or sets the index of the select indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public Position2D GetIndicatorPosition(int index)
        {
            if (index < 0 || index >= indicatorList.Count)
            {
                return null;
            }
            return new Vector2(indicatorList[index].Position.X + container.PositionX, indicatorList[index].Position.Y + container.PositionY);
        }

        /// <summary>
        /// You can override it to do your select out operation.
        /// </summary>
        /// <param name="selectOutIndicator">The indicator will be selected out</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        protected virtual void SelectOut(VisualMap selectOutIndicator)
        {

        }

        /// <summary>
        /// You can override it to do your select in operation.
        /// </summary>
        /// <param name="selectInIndicator">The indicator will be selected in</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        protected virtual void SelectIn(VisualMap selectInIndicator)
        {
            selectIndicator.Position = selectInIndicator.Position;
        }

        /// <summary>
        /// you can override it to create your own default attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new PaginationAttributes();
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// <summary>
        /// you can override it to update your own resources.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {

            for (int i = 0; i < indicatorList.Count; i++)
            {
                ImageVisual indicator = indicatorList[i];
                indicator.URL = paginationAttributes.IndicatorBackgroundURL;
                indicator.Size = new Size2D((int)paginationAttributes.IndicatorSize.Width, (int)paginationAttributes.IndicatorSize.Height);
                indicator.Position = new Position2D((int)(paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * i, 0);
            }

            selectIndicator.URL = paginationAttributes.IndicatorSelectURL;
            selectIndicator.Size = new Size2D((int)paginationAttributes.IndicatorSize.Width, (int)paginationAttributes.IndicatorSize.Height);

            //UpdateContainer();
        }

        private void Initialize()
        {
            paginationAttributes = attributes as PaginationAttributes;
            if (paginationAttributes == null)
            {
                throw new Exception("Pagination attributes is null.");
            }

            container = new VisualView()
            {
                Name = "Container",
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
                //BackgroundColor = Color.Yellow
            };
            this.Add(container);

            selectIndicator = new ImageVisual()
            {
                URL = " "
            };
            container.AddVisual("SelectIndicator", selectIndicator);
        }

        private void CreateIndicator()
        {
            if (paginationAttributes == null)
            {
                return;
            }
            ImageVisual indicator = new ImageVisual
            {
                URL = paginationAttributes.IndicatorBackgroundURL,
                Size = new Size2D((int)paginationAttributes.IndicatorSize.Width, (int)paginationAttributes.IndicatorSize.Height)
            };
            indicator.Position = new Position2D((int)(paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * indicatorList.Count, 0);
            container.AddVisual("Indicator" + indicatorList.Count, indicator);
            indicatorList.Add(indicator);
        }

        private void UpdateContainer()
        {
            if (paginationAttributes == null)
            {
                return;
            }
            if (indicatorList.Count > 0)
            {
                container.SizeWidth = (paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * indicatorList.Count - paginationAttributes.IndicatorSpacing;
            }
            else
            {
                container.SizeWidth = 0;
            }
            container.SizeHeight = paginationAttributes.IndicatorSize.Height;
            container.PositionX = (int)((this.SizeWidth - container.SizeWidth) / 2);
        }
    }
}
