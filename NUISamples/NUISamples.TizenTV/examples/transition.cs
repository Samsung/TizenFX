/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.Constants;

namespace MyCSharpExample
{
    // A spin control (for continously changing values when users can easily predict a set of values)
    class Example
    {
        private Application _application;
        private ContentView _contentView;
        private TextLabel _title;
        private PushButton _shadowButton;
        private bool _active = false;
        
        //Visual High level class
        private ContentView myContentView;
        private PushButton myButtonTest;
        private int myCount;

        public Example(Application application)
        {
            _application = application;
            _application.Initialized += Initialize;
        }

        public void Initialize(object source, NUIApplicationInitEventArgs e)
        {
            Stage stage = Stage.Instance;
            stage.BackgroundColor = Color.White;

            TableView contentLayout = new TableView(4, 1);
            contentLayout.Name = ("ContentLayout");
            contentLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.ParentOrigin = ParentOrigin.TopLeft;
            contentLayout.AnchorPoint = AnchorPoint.TopLeft;
            contentLayout.SetCellPadding(new Size2D(0.0f, 5.0f));
            contentLayout.BackgroundColor = new Color(0.949f, 0.949f, 0.949f, 1.0f);

            stage.GetDefaultLayer().Add(contentLayout);

            _title = new TextLabel("Custom Control Transition Example");
            _title.Name = ("Title");
            _title.StyleName = ("Title");
            _title.WidthResizePolicy = ResizePolicyType.FillToParent;
            _title.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            _title.HorizontalAlignment = "CENTER";
            _title.BackgroundColor = Color.Yellow;
            contentLayout.Add(_title);
            contentLayout.SetFitHeight(0);

            TableView buttonLayout = new TableView(3, 3);
            buttonLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            buttonLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            buttonLayout.SetFixedHeight(1, 100);
            buttonLayout.SetFixedHeight(0, 100);
            buttonLayout.SetFixedWidth(1, 500);
            contentLayout.Add(buttonLayout);

            _shadowButton = new PushButton();
            _shadowButton.LabelText = "Toggle Transition";
            _shadowButton.Name = ("ToggleTransition");
            _shadowButton.ParentOrigin = ParentOrigin.Center;
            _shadowButton.AnchorPoint = AnchorPoint.Center;
            _shadowButton.Clicked += (obj, ev) =>
            {
                _active = !_active;
                _contentView.ActiveContent = _active;
                return true;
            };
            _shadowButton.WidthResizePolicy = ResizePolicyType.FillToParent;
            _shadowButton.HeightResizePolicy = ResizePolicyType.FillToParent;
            buttonLayout.AddChild(_shadowButton, new TableView.CellPosition(1, 1));

            // Create a conttent view
            _contentView = new ContentView();
            _contentView.WidthResizePolicy = ResizePolicyType.Fixed;
            _contentView.HeightResizePolicy = ResizePolicyType.Fixed;
            _contentView.Size = new Size(250.0f, 250.0f, 0.0f);
            _contentView.IconVisual = "/home/owner/apps_rw/NUISamples.TizenTV/res/images/application-icon-0.png";

            PropertyMap background = new PropertyMap();
            background.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            background.Insert(ImageVisualProperty.URL, new PropertyValue("/home/owner/apps_rw/NUISamples.TizenTV/res/images/background-blocks.jpg"));
            _contentView.Background = background;
            contentLayout.Add(_contentView);


            // Visual High level class
            myContentView = new ContentView();
            myContentView.WidthResizePolicy = ResizePolicyType.Fixed;
            myContentView.HeightResizePolicy = ResizePolicyType.Fixed;
            myContentView.Size = new Size(250.0f, 250.0f, 0.0f);
            contentLayout.Add(myContentView);


            myButtonTest = new PushButton();
            myButtonTest.LabelText = "Make Visual";
            myButtonTest.Name = ("MakeVisual");
            myButtonTest.ParentOrigin = ParentOrigin.Center;
            myButtonTest.AnchorPoint = AnchorPoint.Center;
            myButtonTest.Clicked += (obj, ev) =>
            {
                if (++myCount > 5) myCount = 0;

                ImageVisualMap _imageViewMap = new ImageVisualMap();
                _imageViewMap.URL = "/home/owner/apps_rw/NUISamples.TizenTV/res/images/gallery-" + myCount + ".jpg";
                _imageViewMap.FittingMode = FittingModeType.ShrinkToFit;
                _imageViewMap.DepthIndex = 0;

                TextVisualMap _textVisualMap = new TextVisualMap();
                _textVisualMap.Text = "TEXT-" + myCount;
                _textVisualMap.PointSize = 20.0f; //20 + 2 * myCount;
                _textVisualMap.TextColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                _textVisualMap.DepthIndex = 1;

                myContentView.ImageVisual = _imageViewMap;
                //myContentView.TextVisual = _textVisualMap;
                return true;
            };
            myButtonTest.WidthResizePolicy = ResizePolicyType.FillToParent;
            myButtonTest.HeightResizePolicy = ResizePolicyType.FillToParent;
            buttonLayout.AddChild(myButtonTest, new TableView.CellPosition(0, 1));


        }

        public void MainLoop()
        {
            _application.MainLoop();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example(Application.NewApplication("/home/owner/apps_rw/NUISamples.TizenTV/res/json/style-example-theme-one.json"));
            example.MainLoop();
        }
    }
}