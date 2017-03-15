/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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

namespace VisualViewTest
{
    // An example of Visual View control.
    class Example : NUIApplication
    {
        private VisualView _visualView;

        public Example() : base()
        {
        }

        public Example(string stylesheet) : base(stylesheet)
        {
        }

        public Example(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Stage stage = Stage.Instance;
            stage.BackgroundColor = Color.Green;
            Layer rootLayer = stage.GetDefaultLayer();

            /* Create a visual view. */
            _visualView = new VisualView();
            _visualView.ParentOrigin = ParentOrigin.TopLeft;
            _visualView.AnchorPoint = AnchorPoint.TopLeft;
            _visualView.Size = new Size(800.0f, 500.0f, 0.0f);
            _visualView.BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            _visualView.Position = new Position(100.0f, 100.0f, 0.0f);
            rootLayer.Add(_visualView);

            /* Add first image visual to visual view. */
            ImageVisualMap imageVisualMap1 = new ImageVisualMap();
            imageVisualMap1.URL = "/home/owner/apps_rw/NUISamples.TizenTV/res/images/image-1.jpg";
            imageVisualMap1.VisualSize = new Vector2(300.0f, 300.0f);
            imageVisualMap1.Offset = new Vector2(50.0f, 50.0f);
            imageVisualMap1.OffsetSizeMode = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            imageVisualMap1.Origin = AlignType.TOP_BEGIN;
            imageVisualMap1.AnchorPoint = AlignType.TOP_BEGIN;

            _visualView.AddVisual("imageVisual1", imageVisualMap1);

            /* Add second image visual to visual view. */
            ImageVisualMap imageVisualMap2 = new ImageVisualMap();
            imageVisualMap2.URL = "/home/owner/apps_rw/NUISamples.TizenTV/res/images/image-2.jpg";
            imageVisualMap2.VisualSize = new Vector2(350.0f, 300.0f);
            imageVisualMap2.Offset = new Vector2(400.0f, 50.0f);
            imageVisualMap2.OffsetSizeMode = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            imageVisualMap2.Origin = AlignType.TOP_BEGIN;
            imageVisualMap2.AnchorPoint = AlignType.TOP_BEGIN;

            _visualView.AddVisual("imageVisual2", imageVisualMap2);

            /* Modify imageVisual2, we just need do this. */
            //imageVisualMap2.URL = "./NUISample/images/image-3.jpg";
            //_visualView.AddVisual("imageVisual2", imageVisualMap2); //update a visual with same visual name.

            //_visualView.RemoveVisual( "imageVisual1" );
            //_visualView.RemoveVisual( imageVisualMap1 );

            //_visualView.RemoveAll(); //Delete all visuals of visual view.

            /* Add a text visual to visual view. */
            TextVisualMap textVisualMap1 = new TextVisualMap();
            textVisualMap1.Text = "Hello Goodbye";
            textVisualMap1.PointSize = 20.0f;

            textVisualMap1.VisualSize = new Vector2(400.0f, 50.0f);
            textVisualMap1.Offset = new Vector2(250.0f, 400.0f);
            textVisualMap1.OffsetSizeMode = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            textVisualMap1.Origin = AlignType.TOP_BEGIN;
            textVisualMap1.AnchorPoint = AlignType.TOP_BEGIN;

            _visualView.AddVisual("textVisual1", textVisualMap1);
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example("/home/owner/apps_rw/NUISamples.TizenTV/res/json/style-example-theme-one.json");
            example.Run(args);
        }
    }
}