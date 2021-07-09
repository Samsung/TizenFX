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

using System.Collections.Generic;

using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI;

namespace NUITizenGallery
{
    public partial class IndicatorViewTest1Page : View
    {
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";
        private readonly int PagesCount = 5;
        private List<Position> IndicatorPositions;

        public IndicatorViewTest1Page()
        {
            InitializeComponent();
            Scroller.ScrollAnimationEnded += OnScrollAnimationEnded;

            PaginationStyle paginationStyle = new PaginationStyle()
            {
                IndicatorSize = new Size(26, 26),
                IndicatorSpacing = 8,
            };

            Index.ApplyStyle(paginationStyle);
            Index.PositionUsesPivotPoint = true;
            Index.ParentOrigin = new Position(0.5f, 0.05f, 0.5f);
            Index.IndicatorCount = PagesCount;
            Index.SelectedIndex = 0;

            IndicatorPositions = new List<Position>();
            for (int i = 0; i < PagesCount; ++i)
            {
                IndicatorPositions.Add(Index.GetIndicatorPosition(i));
            }

            Index.BackgroundColor = Tizen.NUI.Color.Gray;
            Index.TouchEvent += OnIndexTouchEvent;
        }

        private bool OnIndexTouchEvent(object sender, TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == Tizen.NUI.PointStateType.Finished)
            {
                for (int i = PagesCount -1 ; i >= 0; i--)
                {
                    if (args.Touch.GetLocalPosition(0).X >= IndicatorPositions[i].X)
                    {
                        Scroller.ScrollToIndex(i);
                        break;
                    }
                }
            }

            return true;
        }

        private void OnScrollAnimationEnded(object sender, ScrollEventArgs args)
        {
            Index.SelectedIndex = Scroller.CurrentPage;
        }
    }
}
