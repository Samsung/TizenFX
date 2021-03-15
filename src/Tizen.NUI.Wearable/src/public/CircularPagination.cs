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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// CircularPagination shows the number of pages available and the currently active page.
    /// Especially, CircularPagination provides indicators specific to wearable device.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularPagination: Control
    {
        private CircularPaginationStyle circularPaginationStyle;

        private VisualView container;

        private List<ImageVisual> indicatorList = new List<ImageVisual>();

        private bool isSymmetrical = true;
        private int middleIndex = 9;
        private int indicatorCount = 0;
        private int leftIndicatorCount = 0;
        private int rightIndicatorCount = 0;
        private int selectedIndex = -1;
        private bool isCenterImageSet = false; // When CenterIndicatorImageURL is set, this variable becomes true.
        private bool isCurrentIndicatorCentered = false; // When the current indicator is the center one, this variable becomes true.
        private bool isOddNumber = true;
        private bool uninitializedLeftIndicator = true; // Need it when the indicators are asymmetry and the right indicator count is set earlier than left one.
        private Animation selectAnimation = null;
        private bool isNeedAnimation = false; // TODO : Animation will support using override function later.

        Position2D[] oddArray = new Position2D[] { new Position2D(36, 74), new Position2D(47, 60), new Position2D(60, 47), new Position2D(74, 36),
                                                   new Position2D(89, 26), new Position2D(105, 18), new Position2D(122, 11), new Position2D(139, 7),
                                                   new Position2D(157, 4), new Position2D(175, 3), new Position2D(193, 4), new Position2D(211, 7),
                                                   new Position2D(228, 11), new Position2D(245, 18), new Position2D(261, 26), new Position2D(276, 36),
                                                   new Position2D(290, 47), new Position2D(303, 60), new Position2D(314, 73) };

        Position2D[] evenArray = new Position2D[] { new Position2D(41, 67), new Position2D(53, 53), new Position2D(67, 41), new Position2D(81, 31),
                                                   new Position2D(97, 22), new Position2D(113, 14), new Position2D(131, 9), new Position2D(148, 5),
                                                   new Position2D(166, 3), new Position2D(184, 3), new Position2D(202, 5), new Position2D(220, 9),
                                                   new Position2D(237, 14), new Position2D(253, 22), new Position2D(269, 31), new Position2D(283, 41),
                                                   new Position2D(297, 53), new Position2D(309, 67) };

        static CircularPagination()
        {
            ThemeManager.AddPackageTheme(DefaultThemeCreator.Instance);
        }

        /// <summary>
        /// Creates a new instance of a CircularPagination.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularPagination() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a CircularPagination using style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularPagination(CircularPaginationStyle style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size IndicatorSize
        {
            get
            {
                return circularPaginationStyle?.IndicatorSize;
            }
            set
            {
                if (value == null || circularPaginationStyle == null)
                {
                    return;
                }
                circularPaginationStyle.IndicatorSize = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the background resource of indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> IndicatorImageURL
        {
            get
            {
                return circularPaginationStyle?.IndicatorImageURL;
            }
            set
            {
                if (value == null || circularPaginationStyle == null)
                {
                    return;
                }
                circularPaginationStyle.IndicatorImageURL = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the background resource of the center indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> CenterIndicatorImageURL
        {
            get
            {
                if (isCenterImageSet)
                {
                    return circularPaginationStyle?.CenterIndicatorImageURL;
                }
                else
                {
                    Log.Info("NUI", "CenterIndicatorImageURL is not set yet. \n");
                    return "";
                }

            }
            set
            {
                if (value == null || circularPaginationStyle == null)
                {
                    return;
                }
                circularPaginationStyle.CenterIndicatorImageURL = value;
                isCenterImageSet = true;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Checks whether the indicators are symmetrical or not.
        ///
        /// The default value is true.
        /// If the value is true, the user just can set IndicatorCount.
        /// If false, the user should set both the number of Left Indicators and the number of Right Indicators.
        /// Please refer to LeftIndicatorCount and RightIndicatorCount.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSymmetrical
        {
            get
            {
                return isSymmetrical;
            }
            set
            {
                if (isSymmetrical == value)
                {
                    return;
                }
                if (value == false)
                {
                    isOddNumber = true;
                    CreateIndicator(middleIndex);
                }

                isSymmetrical = value;
                UpdateContainer();
                UpdateVisual();
            }
        }


        /// <summary>
        /// Gets or sets the number of the pages/indicators.
        ///
        /// This value is for symmetrical indicators.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndicatorCount
        {
            get
            {
                return indicatorCount;
            }
            set
            {
                if (indicatorCount == value || indicatorCount < 0 || value <= 0)
                {
                    return;
                }
                if (isSymmetrical == false)
                {
                    Log.Info("NUI", "This property is not for asymmetric pagination. Change to symmetrical pagination.\n");
                    isSymmetrical = true;
                }

                if (value % 2 == 1) // Odd number
                {
                    isOddNumber = true;
                }
                else // Even number
                {
                    isOddNumber = false;
                }

                if (indicatorCount < value)
                {
                    int arrayIndex = 0;
                    if (isOddNumber)
                    {
                        arrayIndex = (19 - value) / 2;
                    }
                    else
                    {
                        arrayIndex = (18 - value) / 2;
                    }
                    if (arrayIndex < 0) return;

                    for (int i = (indicatorCount + 1); i <= value; i++)
                    {
                        CreateIndicator( arrayIndex );
                        arrayIndex++;
                    }

                    // If selectedIndex is not set yet, the default value is middle index.
                    if (selectedIndex == -1)
                    {
                        selectedIndex = value / 2;
                        SelectIn(indicatorList[selectedIndex]);
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
                        selectedIndex = value - 1;
                        SelectIn(indicatorList[selectedIndex]);
                    }
                }
                indicatorCount = value;

                UpdateContainer();
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the number of the left pages/indicators.
        ///
        /// This value can be set when IsSymmetrical API is false.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LeftIndicatorCount
        {
            get
            {
                return leftIndicatorCount;
            }
            set
            {
                if (isSymmetrical == true)
                {
                    Log.Info("NUI", "This variable is not for symmetric pagination. \n");
                    isSymmetrical = false;
                    //return;
                }
                if (leftIndicatorCount == value || leftIndicatorCount < 0 || value > 9 || value < 0)
                {
                    return;
                }

                isOddNumber = true;

                if (leftIndicatorCount < value)
                {
                    for (int i = (middleIndex - value); i < (middleIndex - leftIndicatorCount); i++)
                    {
                        CreateIndicator( i );
                        selectedIndex++;
                    }
                }
                else
                {
                    for (int i = 0; i < (leftIndicatorCount - value); i++)
                    {
                        ImageVisual indicator = indicatorList[i];
                        container.RemoveVisual("Indicator" + i);
                    }
                    indicatorList.RemoveRange(0, (leftIndicatorCount - value)); // LeftIndicator starts from index 0.

                    if (selectedIndex == 0)
                    {
                        selectedIndex++;
                        SelectIn(indicatorList[selectedIndex]);
                    }
                    else
                    {
                        selectedIndex--;
                        SelectIn(indicatorList[selectedIndex]);
                    }
                }
                leftIndicatorCount = value;
                indicatorCount = leftIndicatorCount + rightIndicatorCount + 1;

                // When RightIndicatorCount is set before, then selectedIndex should be updated using the current LeftIndicatorCount.
                if (uninitializedLeftIndicator && selectedIndex == 0)
                {
                    selectedIndex = leftIndicatorCount;
                }
                uninitializedLeftIndicator = false;

                UpdateContainer();
                UpdateAsymmetry();
            }
        }

        /// <summary>
        /// Gets or sets the number of the right pages/indicators.
        ///
        /// This value can be set when IsSymmetrical API is false.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int RightIndicatorCount
        {
            get
            {
                return rightIndicatorCount;
            }
            set
            {
                if (isSymmetrical == true)
                {
                    Log.Info("NUI", "This variable is not for symmetric pagination. \n");
                    isSymmetrical = false;
                    //return;
                }
                if (rightIndicatorCount == value || rightIndicatorCount < 0 || value > 9 || value < 0)
                {
                    return;
                }

                isOddNumber = true;

                if (rightIndicatorCount < value)
                {
                    for (int i = (middleIndex + rightIndicatorCount + 1); i <= (middleIndex + value); i++)
                    {
                        CreateIndicator( i );
                    }
                }
                else
                {
                    for (int i = (leftIndicatorCount + value + 1); i < (leftIndicatorCount + rightIndicatorCount); i++)
                    {
                        ImageVisual indicator = indicatorList[i];
                        container.RemoveVisual("Indicator" + i);
                    }
                    indicatorList.RemoveRange((leftIndicatorCount + value), (rightIndicatorCount - value));

                    if (selectedIndex >= (leftIndicatorCount + rightIndicatorCount))
                    {
                        selectedIndex--;
                        SelectIn(indicatorList[selectedIndex]);
                    }
                }
                rightIndicatorCount = value;
                indicatorCount = leftIndicatorCount + rightIndicatorCount + 1;

                UpdateContainer();
                UpdateAsymmetry();
            }
        }

        /// <summary>
        /// Gets or sets the index of the select indicator.
        ///
        /// If no value is set, the default value is the center indicator.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (selectedIndex == value || value < 0 || value >= indicatorCount)
                {
                    return;
                }

                // TODO : Here it needs to add virtual function for Animation.

                if (selectedIndex >= 0)
                {
                    if ( (isSymmetrical && selectedIndex < indicatorCount) ||
                         (!isSymmetrical && selectedIndex <= (middleIndex + rightIndicatorCount) ) )
                    {
                        CheckCenterIndicator(selectedIndex);
                        SelectOut(indicatorList[selectedIndex]);
                    }
                }
                selectedIndex = value;
                if (selectedIndex >= 0)
                {
                    if ( (isSymmetrical && selectedIndex < indicatorCount) ||
                         (!isSymmetrical && selectedIndex <= (middleIndex + rightIndicatorCount) ) )
                    {
                        CheckCenterIndicator(selectedIndex);
                        SelectIn(indicatorList[selectedIndex]);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the position of a indicator by index.
        /// </summary>
        /// <param name="index">Indicator index</param>
        /// <returns>The position of a indicator by index</returns>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position GetIndicatorPosition(int index)
        {
            if (index < 0 || index >= indicatorList.Count)
            {
                return null;
            }
            return new Position(indicatorList[index].Position.X, indicatorList[index].Position.Y);
        }

        /// <summary>
        /// Sets the position of a indicator by index.
        /// </summary>
        /// <param name="index">Indicator index</param>
        /// <param name="position">The position of a indicator by index</param>
        /// <exception cref="ArgumentNullException">This exception can occur by the position is null.</exception>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void SetIndicatorPosition(int index, Position position)
        {
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            // Update odd / even Array and List by each converted index.
            if (isOddNumber)
            {
                if (isSymmetrical)
                {
                    oddArray[(middleIndex - (indicatorCount / 2) + index)] = position;
                }
                else // IsSymmetrical is false and it means the number of left indicators is different from that of right ones.
                {
                    oddArray[(middleIndex - leftIndicatorCount) + index] = position;
                }
                indicatorList[index].Position = new Vector2(position.X, position.Y);
            }
            else // Only symmetry circular pagination can be even number.
            {
                evenArray[(middleIndex - (indicatorCount / 2) + index)] = position;
                indicatorList[index].Position = new Vector2(position.X, position.Y);
            }
            UpdateVisual();
        }

        private void CreateSelectAnimation()
        {
            if (selectAnimation == null)
            {
                selectAnimation = new Animation(250);
            }
        }

        /// <summary>
        /// You can override it to do your select out operation.
        /// </summary>
        /// <param name="selectOutIndicator">The indicator will be selected out</param>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SelectOut(VisualMap selectOutIndicator)
        {
            if (!(selectOutIndicator is ImageVisual visual)) return;
            if (isCurrentIndicatorCentered)
            {
                visual.URL = circularPaginationStyle?.CenterIndicatorImageURL?.Normal;
            }
            else
            {
                visual.URL = circularPaginationStyle?.IndicatorImageURL?.Normal;
            }
            visual.Opacity = 0.5f;
        }

        /// <summary>
        /// You can override it to do your select in operation.
        /// </summary>
        /// <param name="selectInIndicator">The indicator will be selected in</param>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SelectIn(VisualMap selectInIndicator)
        {
            if (!(selectInIndicator is ImageVisual visual)) return;
            if (isCurrentIndicatorCentered)
            {
                visual.URL = circularPaginationStyle?.CenterIndicatorImageURL?.Selected;
            }
            else
            {
                visual.URL = circularPaginationStyle?.IndicatorImageURL?.Selected;
            }
            visual.Opacity = 1.0f;
        }

        /// <summary>
        /// you can override it to create your own default style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new CircularPaginationStyle();
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (selectAnimation != null)
                {
                    if (selectAnimation.State == Animation.States.Playing)
                    {
                        selectAnimation.Stop();
                    }
                    selectAnimation.Dispose();
                    selectAnimation = null;
                }

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
            circularPaginationStyle = ViewStyle as CircularPaginationStyle;
            if (circularPaginationStyle == null)
            {
                throw new Exception("CircularPagination style is null.");
            }

            container = new VisualView()
            {
                Name = "Container",
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                PositionUsesPivotPoint = true,
            };
            this.Add(container);
        }

        // The parameter, index, is for the index of either oddArray or evenArray.
        private void CreateIndicator(int index)
        {
            if (circularPaginationStyle == null || circularPaginationStyle.IndicatorSize == null)
            {
                return;
            }

            ImageVisual indicator = new ImageVisual
            {
                URL = circularPaginationStyle.IndicatorImageURL?.Normal,
                Size = new Size2D((int)circularPaginationStyle.IndicatorSize.Width, (int)circularPaginationStyle.IndicatorSize.Height),
                Opacity = 0.5f,
            };

            if (isOddNumber)
            {
                indicator.Position = oddArray[index];
            }
            else
            {
                indicator.Position = evenArray[index];
            }

            container.AddVisual("Indicator" + indicatorList.Count, indicator);
            indicatorList.Add(indicator);
        }

        private void CheckCenterIndicator(int index)
        {
            if (isCenterImageSet &&
                (isSymmetrical && (index == indicatorCount / 2)) ||
                (!isSymmetrical && (index == leftIndicatorCount)) )
            {
                isCurrentIndicatorCentered  = true;
            }
            else
            {
                isCurrentIndicatorCentered = false;
            }
        }

        private void UpdateContainer()
        {
            if (circularPaginationStyle == null || circularPaginationStyle.IndicatorSize == null || container == null)
            {
                return;
            }
            if (indicatorList.Count > 0)
            {
                container.SizeWidth = (circularPaginationStyle.IndicatorSize.Width) * indicatorList.Count;
            }
            else
            {
                container.SizeWidth = 0;
            }
            container.SizeHeight = circularPaginationStyle.IndicatorSize.Height;
        }

        private void UpdateVisual()
        {
            if (null == circularPaginationStyle.IndicatorSize) return;
            if (null == circularPaginationStyle.IndicatorImageURL) return;
            if (indicatorCount <= 0) return;

            for (int i = 0; i < indicatorList.Count; i++)
            {
                ImageVisual indicator = indicatorList[i];
                indicator.Size = new Size2D((int)circularPaginationStyle.IndicatorSize.Width, (int)circularPaginationStyle.IndicatorSize.Height);

                CheckCenterIndicator(i);

                if (i == selectedIndex)
                {
                    // If the center image is set before, then should update the center visual separately.
                    if (isCurrentIndicatorCentered)
                    {
                        indicator.URL = circularPaginationStyle.CenterIndicatorImageURL.Selected;
                    }
                    else
                    {
                        indicator.URL = circularPaginationStyle.IndicatorImageURL.Selected;
                    }
                    indicator.Opacity = 1.0f;
                }
                else
                {
                    // If the center image is set before, then should update the center visual separately.
                    if (isCurrentIndicatorCentered)
                    {
                        indicator.URL = circularPaginationStyle.CenterIndicatorImageURL.Normal;
                    }
                    else
                    {
                        indicator.URL = circularPaginationStyle.IndicatorImageURL.Normal;
                    }
                    indicator.Opacity = 0.5f;
                }

                if (isOddNumber)
                {
                    if (isSymmetrical)
                    {
                        indicator.Position = oddArray[middleIndex - (indicatorCount / 2) + i];
                    }
                    else
                    {
                        indicator.Position = oddArray[(middleIndex - leftIndicatorCount) + i];
                    }

                }
                else
                {
                    indicator.Position = evenArray[middleIndex - (indicatorCount / 2) + i];
                }
            }
        }

        private void UpdateAsymmetry()
        {
            if (null == circularPaginationStyle.IndicatorSize) return;
            if (null == circularPaginationStyle.IndicatorImageURL) return;

            int listCount = indicatorList.Count;

            for (int i = 0; i < listCount; i++)
            {
                container.RemoveVisual("Indicator" + i);
            }
            container.RemoveAll();
            indicatorList.Clear();

            for (int i = 0; i < listCount; i++)
            {
                ImageVisual newOne = new ImageVisual
                {
                    Size = new Size2D((int)circularPaginationStyle.IndicatorSize.Width, (int)circularPaginationStyle.IndicatorSize.Height),
                    Position = oddArray[i + (middleIndex - leftIndicatorCount)]
                };

                if (isCenterImageSet && !isSymmetrical && (i == leftIndicatorCount))
                {
                    newOne.URL = circularPaginationStyle.CenterIndicatorImageURL.Normal;
                }
                else
                {
                    newOne.URL = circularPaginationStyle.IndicatorImageURL.Normal;
                }
                newOne.Opacity  = 0.5f;
                container.AddVisual("Indicator" + i, newOne);
                indicatorList.Add(newOne);
            }

            // If selectedIndex is not set yet, the default value is middle index.
            if (selectedIndex == -1)
            {
                selectedIndex = leftIndicatorCount;
            }

            if (isCenterImageSet && (selectedIndex == leftIndicatorCount))
            {
                indicatorList[selectedIndex].URL = circularPaginationStyle.CenterIndicatorImageURL.Selected;
                indicatorList[selectedIndex].Opacity = 1.0f;
            }
            else
            {
                indicatorList[selectedIndex].URL = circularPaginationStyle.IndicatorImageURL.Selected;
                indicatorList[selectedIndex].Opacity = 1.0f;
            }
        }
    }
}
