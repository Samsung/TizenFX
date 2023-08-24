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
using System.Collections.Generic;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.LayoutSamples
{
    class Program : NUIApplication
    {
        private const int WIN_WIDTH = 720;
        private const int WIN_HEIGHT = 720;
        private const int INIT_VIEW_COUNT = 3;
        private Window displayWindow = null;
        private Window controlWindow = null;

        private List<ObjectView> objectViewList = new List<ObjectView>();
        private ObjectView rootObjectView = null;
        private ObjectView selectedObjectView = null;
        private ControlView controlView = null;

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "BackSpace")
                {
                    Exit();
                }
            }
        }

        public ObjectView SelectedObjectView
        {
            get
            {
                return selectedObjectView;
            }

            set
            {
                if (selectedObjectView != value)
                {
                    selectedObjectView = value;

                    if (controlView != null)
                    {
                        controlView.SetView(selectedObjectView);
                    }
                }
            }
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {
            SetDisplayView();
            SetControlView();
        }

        private void SetDisplayWindow()
        {
            if (displayWindow != null) return;

            displayWindow = GetDefaultWindow();
            displayWindow.Title = "Display Window";
            displayWindow.WindowSize = new Size2D(WIN_WIDTH, WIN_HEIGHT);
            displayWindow.KeyEvent += OnKeyEvent;
        }

        private ObjectView CreateObjectView(string name)
        {
            var view = new ObjectView()
            {
                Text = name,
            };

            view.SelectedChanged += (object sender, SelectedChangedEventArgs args) =>
            {
                if (args.IsSelected)
                {
                    SelectedObjectView = view;
                }
            };

            view.ChildRemoved += (object sender, View.ChildRemovedEventArgs args) =>
            {
                SelectedObjectView = view;
            };

            objectViewList.Add(view);

            return view;
        }

        private void SetDisplayView()
        {
            SetDisplayWindow();

            if (rootObjectView != null) return;

            rootObjectView = CreateObjectView("root");
            rootObjectView.ParentOrigin = new Position(0.5f, 0.5f, 0.5f);
            rootObjectView.PivotPoint = new Position(0.5f, 0.5f, 0.5f);
            rootObjectView.PositionUsesPivotPoint = true;
            rootObjectView.WidthSpecification = 600;
            rootObjectView.HeightSpecification = 600;
            rootObjectView.BackgroundColor = Color.White;
            rootObjectView.IsSelected = true;

            displayWindow.Add(rootObjectView);

            for (int i = 0; i < INIT_VIEW_COUNT; i++)
            {
                rootObjectView.Add(CreateObjectView(objectViewList.Count.ToString()));
            }
        }

        private void SetControlWindow()
        {
            if (controlWindow != null) return;

            controlWindow = new Window();
            controlWindow.Title = "Control Window";
            controlWindow.WindowSize = new Size2D(WIN_WIDTH, WIN_HEIGHT);
            controlWindow.KeyEvent += OnKeyEvent;
        }

        private void SetControlView()
        {
            SetControlWindow();

            if (controlView != null) return;

            controlView = new ControlView();
            controlView.SetView(rootObjectView);

            controlView.ViewAdded += (object sender, EventArgs args) =>
            {
                SelectedObjectView.Add(CreateObjectView(objectViewList.Count.ToString()));
            };

            controlView.ViewRemoved += (object sender, EventArgs args) =>
            {
                var parent = SelectedObjectView.GetParent() as ObjectView;
                if (parent != null)
                {
                    objectViewList.Remove(SelectedObjectView);
                    parent.Remove(SelectedObjectView);
                    SelectedObjectView = parent;
                }
            };

            controlWindow.Add(controlView);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
