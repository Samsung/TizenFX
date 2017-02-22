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

namespace MyCSharpExample
{
    // A spin control (for continously changing values when users can easily predict a set of values)

    class Example
    {
        private Application _application;
        private VisualView _visualView;

        public Example(Application application)
        {
            _application = application;
            _application.Initialized += Initialize;
        }

        public void Initialize(object source, NUIApplicationInitEventArgs e)
        {
            Stage stage = Stage.GetCurrent();
            stage.BackgroundColor = Color.White;

            // Create a conttent view
            _visualView = new VisualView();
            _visualView.ParentOrigin = NDalic.ParentOriginTopLeft;
            _visualView.AnchorPoint = NDalic.AnchorPointTopLeft;
            _visualView.Size = new Vector3(80.0f, 50.0f, 0.0f);
            _visualView.BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            _visualView.Position = new Position(100.0f, 100.0f, 0.0f);
            stage.Add(_visualView);

            ImageVisual imageVisual1 = new ImageVisual("/home/owner/apps_rw/NUISamples.TizenTV/res/images/image-1.jpg");
            imageVisual1.Size = new Vector2(30.0f, 30.0f);
            imageVisual1.Position = new Vector2(50.0f, 50.0f);
            imageVisual1.OffsetSizeMode = new Vector4( 1.0f, 1.0f, 1.0f, 1.0f);
            imageVisual1.Origin = AlignType.TOP_BEGIN;
            imageVisual1.AnchorPoint = AlignType.TOP_BEGIN;
            imageVisual1.ParentSize = new Vector2(80.0f, 50.0f);
            imageVisual1.Instantiate();

            _visualView.AddVisual(imageVisual1);

            ImageVisual imageVisual2 = new ImageVisual("/home/owner/apps_rw/NUISamples.TizenTV/res/images/image-2.jpg");
            imageVisual2.Size = new Vector2(350.0f, 300.0f);
            imageVisual2.Position = new Vector2(400.0f, 50.0f);
            imageVisual2.OffsetSizeMode = new Vector4( 1.0f, 1.0f, 1.0f, 1.0f);
            imageVisual2.Origin = AlignType.TOP_BEGIN;
            imageVisual2.AnchorPoint = AlignType.TOP_BEGIN;
            imageVisual2.ParentSize = new Vector2(80.0f, 50.0f);
            imageVisual2.Instantiate();

            _visualView.AddVisual(imageVisual2);

            TextVisual textVisual1 = new TextVisual("Hello Goodbye");
            textVisual1.Size = new Vector2(40.0f, 50.0f);
            textVisual1.Position = new Vector2(250.0f, 400.0f);
            textVisual1.OffsetSizeMode = new Vector4( 1.0f, 1.0f, 1.0f, 1.0f);
            textVisual1.Origin = AlignType.TOP_BEGIN;
            textVisual1.AnchorPoint = AlignType.TOP_BEGIN;
            textVisual1.ParentSize = new Vector2(80.0f, 50.0f);
            textVisual1.Instantiate();

            _visualView.AddVisual(textVisual1);
        }

        public void MainLoop()
        {
            _application.MainLoop ();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example(Application.NewApplication());
            example.MainLoop ();
        }
    }
}