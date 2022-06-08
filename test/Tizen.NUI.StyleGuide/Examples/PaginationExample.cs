/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.StyleGuide
{
    // IExample inehrited class will be automatically added in the main examples list.
    internal class PaginationExample : ContentPage, IExample
    {
        private View rootContent;
        private Button buttonLeft, buttonRight;
        private TextLabel[] board = new TextLabel[2];
        private Pagination[] pagination = new Pagination[2];
        private View[] layout = new View[3];
        private readonly int PAGE_COUNT = 5;



        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public PaginationExample() : base()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Pagination Default Style",
            };

            // Example root content view.
            // you can decorate, add children on this view.
            rootContent = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 20),
                },
            };

            createBorads();

            buttonLeft = new Button
            {
                Name = "buttonLeft",
                Text = "Left",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            rootContent.Add(buttonLeft);

            buttonLeft.Clicked += (s, e) =>
            {
                if (pagination[0].SelectedIndex > 0)
                {
                    pagination[0].SelectedIndex = pagination[0].SelectedIndex - 1;
                }
                if (pagination[1].SelectedIndex > 0)
                {
                    pagination[1].SelectedIndex = pagination[1].SelectedIndex - 1;
                }
            };

            buttonRight = new Button
            {
                Name = "buttonRight",
                Text = "Right",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            rootContent.Add(buttonRight);

            buttonRight.Clicked += (s, e) =>
            {
                if (pagination[0].SelectedIndex < pagination[0].IndicatorCount - 1)
                {
                    pagination[0].SelectedIndex = pagination[0].SelectedIndex + 1;
                }
                if (pagination[1].SelectedIndex < pagination[1].IndicatorCount - 1)
                {
                    pagination[1].SelectedIndex = pagination[1].SelectedIndex + 1;
                }
            };

            Content = rootContent;
        }
        void createBorads()
        {
            board[0] = new TextLabel();
            board[0].Size = new Size(300, 50);
            board[0].PointSize = 15;
            board[0].HorizontalAlignment = HorizontalAlignment.Center;
            board[0].VerticalAlignment = VerticalAlignment.Center;
            board[0].BackgroundColor = Color.Magenta;
            board[0].Text = "Property construction";
            rootContent.Add(board[0]);

            // Create by Properties
            pagination[0] = new Pagination();
            var path = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            var indicatorImageUrlStyle = new PaginationStyle()
            {
                IndicatorSize = new Size(64, 8),
                IndicatorSpacing = 8,
                IndicatorImageUrl = new Selector<string>
                {
                    Normal = path + "/pagination/pagination_ic_nor.png",
                    Selected = path + "/pagination/pagination_ic_sel.png"
                }
            };
            pagination[0].ApplyStyle(indicatorImageUrlStyle);
            pagination[0].Name = "Pagination1";
            pagination[0].Size = new Size(450, 50);
            pagination[0].BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination[0].IndicatorCount = PAGE_COUNT;
            pagination[0].SelectedIndex = 0;
            rootContent.Add(pagination[0]);

            board[1] = new TextLabel();
            board[1].Size = new Size(300, 50);
            board[1].PointSize = 15;
            board[1].HorizontalAlignment = HorizontalAlignment.Center;
            board[1].VerticalAlignment = VerticalAlignment.Center;
            board[1].BackgroundColor = Color.Magenta;
            board[1].Text = "Attribute construction";
            rootContent.Add(board[1]);

            // Create by Attributes
            PaginationStyle style = new PaginationStyle()
            {
                IndicatorSize = new Size(32, 4),
                IndicatorSpacing = 20,
                IndicatorImageUrl = new Selector<string>
                {
                    Normal = path + "/pagination/pagination_ic_nor.png",
                    Selected = path + "/pagination/pagination_ic_sel.png"
                }
            };
            pagination[1] = new Pagination(style);
            pagination[1].Name = "Pagination2";
            pagination[1].Size = new Size(400, 50);
            pagination[1].BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.6f);
            pagination[1].IndicatorCount = PAGE_COUNT;
            pagination[1].SelectedIndex = 0;
            rootContent.Add(pagination[1]);
        }
    }
}
