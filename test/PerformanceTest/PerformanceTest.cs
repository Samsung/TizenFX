using System.Net.Mime;
using System.Drawing;
using System.ComponentModel;
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
using System.Linq;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Reflection;

namespace PerformanceTest
{
    class Program : NUIApplication
    {
        private Window window;
        private Navigator navigator;
        private ContentPage page;
        private string path;

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            // FIXME:: Navigator should provide Back/Escape event processing.
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "BackSpace")
                {
                        navigator?.Pop();
                        Exit();
                }
            }
        }
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            SetMainPage();

            //enable FocusManger default algorithm
            //FocusManager.Instance.EnableDefaultAlgorithm(true);
        }
        private void Initialize()
        {
            window = GetDefaultWindow();
            window.Title = "세탁코스";
            window.KeyEvent += OnKeyEvent;
            path = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        }

        private View GetAILaundryCard()
        {

            var aiLaundry = new View()
            {
                BackgroundColor = new Tizen.NUI.Color(0.4f, 0.4f, 0.4f, 0.5f),
                CornerRadius = 10,
                WidthSpecification = 500,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(50, 50, 10, 10),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(0, 30),
                }
            };

            var laundryTitle = new TextLabel()
            {
                Text = "AI 맞춤세탁",
                PointSize = 30,
            };
            aiLaundry.Add(laundryTitle);

            var laundryDuration = new TextLabel()
            {
                Text = "1시간 20분",
                PointSize = 20,
            };
            aiLaundry.Add(laundryDuration);

            var aiLaundryIconView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 0),
                }
            };


            var tempIcon = new ImageView()
            {
                ResourceUrl = path + "temp.png",
                WidthSpecification = 50,
                HeightSpecification = 50,
            };
            aiLaundryIconView.Add(tempIcon);

            var cleaningIcon = new ImageView()
            {
                ResourceUrl = path + "cleaning.png",
                WidthSpecification = 50,
                HeightSpecification = 50,
            };
            aiLaundryIconView.Add(cleaningIcon);

            var dryIcon = new ImageView()
            {
                ResourceUrl = path + "dry.png",
                WidthSpecification = 50,
                HeightSpecification = 50,
            };
            aiLaundryIconView.Add(dryIcon);
            aiLaundry.Add(aiLaundryIconView);

            return aiLaundry;
        }

        private View GetStdLaundryCard()
        {

            var stdLaundry = new View()
            {
                BackgroundColor = new Tizen.NUI.Color(0.4f, 0.4f, 0.4f, 0.5f),
                CornerRadius = 10,
                WidthSpecification = 250,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(50, 50, 10, 10),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(0, 30),
                }
            };

            var laundryTitle = new TextLabel()
            {
                Text = "표준세탁",
                PointSize = 30,
            };
            stdLaundry.Add(laundryTitle);

            var laundryDuration = new TextLabel()
            {
                Text = "59분",
                PointSize = 20,
            };
            stdLaundry.Add(laundryDuration);

            return stdLaundry;
        }

        private View GetPetCareLaundryCard()
        {

            var petCareLaundry = new View()
            {
                BackgroundColor = new Tizen.NUI.Color(0.4f, 0.4f, 0.4f, 0.5f),
                CornerRadius = 10,
                WidthSpecification = 250,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(50, 50, 10, 10),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(0, 30),
                }
            };

            var laundryTitle = new TextLabel()
            {
                Text = "펫케어세탁",
                PointSize = 30,
            };
            petCareLaundry.Add(laundryTitle);

            var laundryDuration = new TextLabel()
            {
                Text = "2시간 30분",
                PointSize = 20,
            };
            petCareLaundry.Add(laundryDuration);

            return petCareLaundry;
        }

        private View GetLaundryView()
        {
            var aiCard = GetAILaundryCard();
            var stdCard = GetStdLaundryCard();
            var petCareCard = GetPetCareLaundryCard();


            var laundryContent = new View()
            {
                WidthSpecification = 1070,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(10, 10, 10, 10),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(20, 0),
                }
            };
            laundryContent.Add(aiCard);
            laundryContent.Add(stdCard);
            laundryContent.Add(petCareCard);

            return laundryContent;
        }

        private View GetDryerCard(string title, string duration, bool start, float progress = 0f)
        {
            var dryCard  = new View()
            {
                BackgroundColor = new Tizen.NUI.Color(0.4f, 0.4f, 0.4f, 0.5f),
                CornerRadius = 10,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(10, 10, 10, 10),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(0, 10),
                }
            };

            var laundryTitle = new TextLabel()
            {
                Text = title,
                PointSize = 30,
            };
            dryCard.Add(laundryTitle);

            var dryDurationPlay  = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                Padding = new Extents(0, 0, 10, 10),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(0, 10),
                }
            };

            var laundryDuration = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Text = duration,
                PointSize = 20,
            };
            dryDurationPlay.Add(laundryDuration);

            var laundryPauseIcon = new ImageView()
            {
                ResourceUrl = path + (start? "pause.png" :"play.png"),
                WidthSpecification = 50,
                HeightSpecification = 50,
            };
            dryDurationPlay.Add(laundryPauseIcon);
            dryCard.Add(dryDurationPlay);

            var dryProgress = new Progress()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                MinValue = 0f,
                MaxValue = 1f,
                CurrentValue = progress,
            };
            dryCard.Add(dryProgress);

            return dryCard;
        }

        private View GetDryerView()
        {
            var stdDryerdard = GetDryerCard("표준 건조", "1시간 20분", true, 0.35f);
            var aiDryerdard = GetDryerCard("AI 건조", "2시간 00분", false);

            var dryerContent = new View()
            {
                WidthSpecification = 1070,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(10, 10, 10, 10),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(0, 20),
                }
            };
            dryerContent.Add(stdDryerdard);
            dryerContent.Add(aiDryerdard);

            return dryerContent;
        }

        private void SetMainPage()
        {
            var rootView = new View()
            {
                BackgroundColor = Tizen.NUI.Color.Black,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(5, 5, 5, 5),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    CellPadding = new Size2D(0, 0),
                }
            };

            var luandryContent = GetLaundryView();
            var dryerContent = GetDryerView();

            var contentView = new ScrollableBase()
            {
                BackgroundColor = new Tizen.NUI.Color(0.2f,0.2f,0.2f,0.5f),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding = new Extents(5, 5, 5, 5),
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
                SnapToPage = true,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 0),
                }
            };
            contentView.Add(luandryContent);
            contentView.Add(dryerContent);

            var laundryBtn = new Button()
            {
                CornerRadius = 0,
                Text = "세탁기"
            };

            laundryBtn.Clicked += (object sender, ClickedEventArgs e) =>
            {
                contentView.ScrollToIndex(0);
            };

            var dryerBtn = new Button()
            {
                CornerRadius = 0,
                Text = "건조기"
            };

            dryerBtn.Clicked += (object sender, ClickedEventArgs e) =>
            {
                contentView.ScrollToIndex(1);
            };

            var buttonView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 80,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 0),
                }
            };

            buttonView.Add(laundryBtn);
            buttonView.Add(dryerBtn);

            rootView.Add(buttonView);
            rootView.Add(contentView);

            window.Add(rootView);
        }

/*
        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }
*/
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
