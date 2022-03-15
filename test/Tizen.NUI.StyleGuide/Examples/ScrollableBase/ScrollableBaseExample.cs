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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.StyleGuide
{
    // IExample inehrited class will be automatically added in the main examples list.
    internal class ScrollableBaseExample : ContentPage, IExample
    {
        private Window window;
        private List<DirectionOption> directionMenu;
        public void Activate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()\n");
        }
        public void Deactivate()
        {
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()\n");
            window = null;
            directionMenu = null;
        }

        /// Modify this method for adding other examples.
        public ScrollableBaseExample() : base()
        {
            Log.Info(this.GetType().Name, $"{this.GetType().Name} is contructed\n");

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "ScrollableBase Default Style",
            };

            directionMenu = new List<DirectionOption>();
            directionMenu.Add(new DirectionOption("Vertical"));
            directionMenu.Add(new DirectionOption("Horizontal"));

            // Example root content view.
            // you can decorate, add children on this view.
            // ScrollableBase need two different style guide.
            // so here we adding new CollectionView for 2-depth option.
            var directionListView = new CollectionView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ItemsSource = directionMenu,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    DefaultLinearItem item = new DefaultLinearItem()
                    {
                        WidthSpecification = LayoutParamPolicies.MatchParent,
                    };
                    item.Label.SetBinding(TextLabel.TextProperty, "Direction");
                    item.Label.HorizontalAlignment = HorizontalAlignment.Begin;
                    item.EnableFocus();
                    return item;
                }),
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                SelectionMode = ItemSelectionMode.SingleAlways,
            };
            directionListView.SelectionChanged += (object colView, SelectionChangedEventArgs ev) =>
            {
                if (ev.CurrentSelection.Count == 0) return;
                if (ev.CurrentSelection[0] is DirectionOption directionItem)
                {
                    Log.Info(this.GetType().Name, $"{directionItem.Direction} will be activated!\n");
                    Page scrollDirPage = new ScrollableBaseDirectionExample(directionItem.Direction);
                    window = NUIApplication.GetDefaultWindow();
                    window.GetDefaultNavigator().Push(scrollDirPage);
                    FocusableExtension.SetFocusOnPage(scrollDirPage);
                }
                directionListView.SelectedItem = null;
            };

            Content = directionListView;
        }
    }

    internal class DirectionOption
    {
        private string direction;
        public string Direction { get => direction; }

        public DirectionOption(string dir)
        {
            direction = dir;
        }
    }
}
