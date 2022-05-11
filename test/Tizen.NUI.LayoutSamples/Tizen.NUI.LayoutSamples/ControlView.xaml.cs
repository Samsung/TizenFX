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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.LayoutSamples
{
    public partial class ControlView : View
    {
        private ObjectView objectView = null;
        private LinearLayoutControlView linearLayoutControlView = null;
        private ObjectControlView objectControlView = null;

        public ControlView()
        {
            InitializeComponent();

            SetLayoutControlView();
            SetObjectControlView();
        }

        public event EventHandler<EventArgs> ViewAdded;
        public event EventHandler<EventArgs> ViewRemoved;

        public void SetView(IObjectView view)
        {
            if (!(view is View)) return;

            if (objectView == view as ObjectView) return;

            objectView = view as ObjectView;

            linearLayoutControlView.SetLayout(objectView.Layout as IObjectLayout);

            objectControlView.SetView(objectView);

            var parent = objectView.GetParent() as ObjectView;
            if (parent == null)
            {
                removeViewButton.IsEnabled = false;
            }
            else
            {
                removeViewButton.IsEnabled = true;
            }
        }

        private void SetLayoutControlView()
        {
            var layoutTab = new TabButton()
            {
                Text = "Layout",
            };

            var layoutContent = new TabContent()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 40),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            LayoutType selectedLayoutType = LayoutType.LinearLayout;

            var layoutType = new LayoutTypeView();
            layoutType.LayoutType = selectedLayoutType;
            layoutType.LayoutTypeChanged += (object sender, LayoutTypeChangedEventArgs args) =>
            {
                if (args.LayoutType == LayoutType.LinearLayout)
                {
                    if (linearLayoutControlView == null)
                    {
                        linearLayoutControlView = new LinearLayoutControlView();
                    }
                }
            };
            layoutContent.Add(layoutType);

            linearLayoutControlView = new LinearLayoutControlView();
            layoutContent.Add(linearLayoutControlView);

            tabView.AddTab(layoutTab, layoutContent);
        }

        private void SetObjectControlView()
        {
            var viewTab = new TabButton()
            {
                Text = "View",
            };

            var viewContent = new TabContent()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            objectControlView = new ObjectControlView();
            viewContent.Add(objectControlView);

            tabView.AddTab(viewTab, viewContent);
        }

        private void AddViewButtonClicked(object sender, ClickedEventArgs args)
        {
            ViewAdded?.Invoke(objectView, new EventArgs());
        }

        private void RemoveViewButtonClicked(object sender, ClickedEventArgs args)
        {
            ViewRemoved?.Invoke(objectView, new EventArgs());
        }
    }
}
