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
using Tizen.NUI.BaseComponents;

namespace VisualViewTest3
{
    // An example of Visual View control.
    class Example : NUIApplication
    {
        private VisualView _visualView = null;
        private const string resources = "/home/owner/apps_rw/NUISamples.TizenTV/res";
        private Window _window;

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

        private ImageVisual imageVisualMap1;
        private ImageVisual imageVisualMap2;
        private int cnt;

        public void Initialize()
        {
            Window window = Window.Instance;

            /* Create a visual view. */
            _visualView = new VisualView();
            _visualView.ParentOrigin = ParentOrigin.TopLeft;
            _visualView.PivotPoint = PivotPoint.TopLeft;
            _visualView.Size2D = new Size2D(window.Size.Width, window.Size.Height);

            /* color visual */
            ColorVisual colorVisualMap1 = new ColorVisual();
            colorVisualMap1.Color = Color.Green;
            _visualView.Background = colorVisualMap1.OutputVisualMap;

            window.Add(_visualView);

            /* image visual 1. No transform setting case. */
            imageVisualMap1 = new ImageVisual();
            imageVisualMap1.URL = resources + "/images/image-1.jpg";
            imageVisualMap1.DepthIndex = 1;
            //_visualView.AddVisual("imageVisual1", imageVisualMap1);

            /* image visual 2. Using RelativePosition and SizePolicyWidth setting case. */
            imageVisualMap2 = new ImageVisual();
            imageVisualMap2.URL = resources + "/images/image-2.jpg";
            /* Using Size, you can set SizePolicyWidth and SizePolicyHeight separately, default by relative. */
            imageVisualMap2.Size = new Vector2(400.0f, 0.3f);
            /* Using RelativePosition, then PositionPolicyX and PositionPolicyY will be relative. */
            imageVisualMap2.RelativePosition = new Vector2(0.1f, 0.1f);
            imageVisualMap2.SizePolicyWidth = VisualTransformPolicyType.Absolute;
            imageVisualMap2.Origin = Visual.AlignType.TopBegin;
            imageVisualMap2.AnchorPoint = Visual.AlignType.TopBegin;
            /* Ensure imageVisual show  */
            imageVisualMap2.DepthIndex = 9;
            _visualView.AddVisual("imageVisual2", imageVisualMap2);
            /* If imageVisual2 added first, the it will be covered by imageVisual1.
               so, we need to set their depth index to ensure they all can be showed.
             */
            _visualView.AddVisual("imageVisual1", imageVisualMap1);

            _window = Window.Instance;
            _window.FocusChanged += (sender, ee) =>
            {
                cnt++;
                Tizen.Log.Debug("NUI", "[WindowFocusTest] WindowFocusChanged event comes! focus gained=" + ee.FocusGained);
            };

            Tizen.Log.Debug("NUI", "[WindowFocusTest] is focus acceptable=" + _window.IsFocusAcceptable());
            _window.SetAcceptFocus(false);
            Tizen.Log.Debug("NUI", "[WindowFocusTest] set focus acceptable=false!!!");
            Tizen.Log.Debug("NUI", "[WindowFocusTest] is focus acceptable=" + _window.IsFocusAcceptable());
            _window.SetAcceptFocus(true);
            Tizen.Log.Debug("NUI", "[WindowFocusTest] set focus acceptable=true!!!");
            Tizen.Log.Debug("NUI", "[WindowFocusTest] is focus acceptable=" + _window.IsFocusAcceptable());
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
