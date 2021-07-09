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
    public partial class IndicatorViewTest4Page : View
    {
        public IndicatorViewTest4Page()
        {
            InitializeComponent();
            List<Pagination> indexers = new List<Pagination>();

            PaginationStyle paginationStyle = new PaginationStyle()
            {
                IndicatorSize = new Size(26, 26),
                IndicatorSpacing = 8,
            };

            indexers.Add(Index0);
            indexers.Add(Index1);
            indexers.Add(Index2);
            indexers.Add(Index3);
            indexers.Add(Index4);
            indexers.Add(Index5);

            for (int i = 0; i < 6; ++i)
            {
                indexers[i].ApplyStyle(paginationStyle);
                indexers[i].PositionUsesPivotPoint = true;
                indexers[i].BackgroundColor = Tizen.NUI.Color.Gray;
            }

            indexers[0].IndicatorCount = 3;
            indexers[1].IndicatorCount = 4;
            indexers[2].IndicatorCount = 5;
            indexers[3].IndicatorCount = 3;
            indexers[4].IndicatorCount = 4;
            indexers[5].IndicatorCount = 5;
        }
    }
}
