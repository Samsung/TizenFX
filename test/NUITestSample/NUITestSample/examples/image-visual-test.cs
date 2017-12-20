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
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

namespace ImageVisualTest
{
    class Example : NUIApplication
    {
        private const string _resPath = "/home/owner/apps_rw/NUISamples/res";

        private VisualView _contentView;
        private ImageVisual _icon;

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
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            // make visual position animation
            _contentView = new VisualView();
            _contentView.ParentOrigin = ParentOrigin.Center;
            _contentView.PivotPoint = PivotPoint.Center;
            _contentView.Size2D = new Size2D(500, 500);
            _contentView.BackgroundImage = _resPath + "/images/background-blocks.jpg";

            _icon = new ImageVisual();
            _icon.URL = _resPath + "/images/button-up.9.png";
            _icon.AuxiliaryImageURL = _resPath + "application-icon-0.png";
            _icon.AuxiliaryImageAlpha = 0.9f;
            _icon.Size = new Size2D(450, 450);
            _icon.SizePolicy = VisualTransformPolicyType.Absolute;
            _icon.Position = new Position2D(25, 25);
            _icon.PositionPolicy = VisualTransformPolicyType.Absolute;
            _icon.Origin = Visual.AlignType.TopBegin;
            _icon.AnchorPoint = Visual.AlignType.TopBegin;
            //_icon.MixColor = new Color(0, 1, 0, 0.5f);
            //_icon.Opacity = 0.5f;
            _contentView.AddVisual("icon_visual", _icon);

            window.Add(_contentView);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
