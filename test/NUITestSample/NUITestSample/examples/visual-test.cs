/*
* Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace VisualTest
{
    class Example : NUIApplication
    {
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            ImageVisual image = new ImageVisual()
            {
                URL = resourcePath + "/images/gallery-5.jpg",
                FittingMode = FittingModeType.ShrinkToFit,
                DesiredWidth = 400,
                DesiredHeight = 300,
                VisualFittingMode = VisualFittingModeType.FitKeepAspectRatio,
            };

            ImageView imageV = new ImageView()
            {
                Size2D = new Size2D(500, 400),
                BackgroundColor = Color.Cyan,
                Image = image.OutputVisualMap,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                Position2D = new Position2D(-300, 0),
                PositionUsesPivotPoint = true,
            };

            window.Add(imageV);

            PropertyMap outline = new PropertyMap();
            outline.Add("color", new PropertyValue(Color.Red));
            outline.Add("width", new PropertyValue(2.0f));

            PropertyMap underline = new PropertyMap();
            underline.Add("enable", new PropertyValue(true));
            underline.Add("color", new PropertyValue("blue"));
            underline.Add("height", new PropertyValue(2));

            PropertyMap shadow = new PropertyMap();
            shadow.Add("offset", new PropertyValue(new Vector2(2.0f, 2.0f)));
            shadow.Add("color", new PropertyValue(Color.Green));
            shadow.Add("blurRadius", new PropertyValue(5.0f));

            PropertyMap bg = new PropertyMap();
            bg.Add("enable", new PropertyValue(true));
            bg.Add("color", new PropertyValue(Color.Cyan));

            TextVisual text = new TextVisual()
            {
                Text = "I'm a text visual",
                PointSize = 52,
                Outline = outline,
                Underline = underline,
                Shadow = shadow,
                Background = bg,
            };

            View view = new View()
            {
                Size2D = new Size2D(500, 400),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                Background = text.OutputVisualMap,
                Position2D = new Position2D(300, 0),
            };
            window.Add(view);
        }
    }
}
