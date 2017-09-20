// Copyright (c) 2017 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;


// 1) sibling order test
namespace SiblingOrderTest
{
    class Example : NUIApplication
    {
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

        Window _window;

        public void Initialize()
        {
            _window = Window.Instance;
            _window.BackgroundColor = Color.White;

            // sibling order test
            // By default, the SiblingOrder is 0.
            SiblingTest1();

            // sibling order test
            // Set the SiblingOrder 0 -> 9
            SiblingTest2();

            // sibling order test
            // Set the SiblingOrder 10 -> 1
            SiblingTest3();

            // sibling order test
            // Set the SiblingOrder 5 -> 1 & 0 -> 4
            SiblingTest4();

            // sibling order test
            // Set the SiblingOrder 0 -> 4 & 5 -> 1
            SiblingTest5();
        }

        public void SiblingTest1()
        {
            Position2D _myPos = new Position2D(100, 30);

            for (int i = 0; i < 10; i++)
            {
                PushButton _view = new PushButton();

                _view.Name = "sibling" + i;
                _view.LabelText = "view" + i;
                _view.MinimumSize = new Size2D(100, 50);
                _view.ParentOrigin = ParentOrigin.TopLeft;
                _view.PivotPoint = PivotPoint.TopLeft;
                _view.Position2D = _myPos + new Position2D(20 * i, 10 * i);

                _window.Add(_view);
            }
        }

        public void SiblingTest2()
        {
            Position2D _myPos = new Position2D(100, 180);

            for (int i = 0; i < 10; i++)
            {
                PushButton _view = new PushButton();

                _view.Name = "sibling" + i;
                _view.LabelText = "view" + i;
                _view.MinimumSize = new Size2D(100, 50);
                _view.ParentOrigin = ParentOrigin.TopLeft;
                _view.PivotPoint = PivotPoint.TopLeft;
                _view.Position2D = _myPos + new Position2D(20 * i, 10 * i);

                _window.Add(_view);
                _view.SiblingOrder = i;
            }
        }

        public void SiblingTest3()
        {
            Position2D _myPos = new Position2D(100, 330);

            for (int i = 0; i < 10; i++)
            {
                PushButton _view = new PushButton();

                _view.Name = "sibling" + i;
                _view.LabelText = "view" + i;
                _view.MinimumSize = new Size2D(100, 50);
                _view.ParentOrigin = ParentOrigin.TopLeft;
                _view.PivotPoint = PivotPoint.TopLeft;
                _view.Position2D = _myPos + new Position2D(20 * i, 10 * i);

                _window.Add(_view);
                _view.SiblingOrder = 10-i;
            }
        }

        public void SiblingTest4()
        {
            Position2D _myPos = new Position2D(100, 480);

            for (int i = 0; i < 10; i++)
            {
                PushButton _view = new PushButton();

                _view.Name = "sibling" + i;
                _view.LabelText = "view" + i;
                _view.MinimumSize = new Size2D(100, 50);
                _view.ParentOrigin = ParentOrigin.TopLeft;
                _view.PivotPoint = PivotPoint.TopLeft;
                _view.Position2D = _myPos + new Position2D(20 * i, 10 * i);

                _window.Add(_view);

                if (i<5)
                {
                    _view.SiblingOrder = 5-i;
                }
                else
                {
                    _view.SiblingOrder = i-5;
                }
            }
        }

        public void SiblingTest5()
        {
            Position2D _myPos = new Position2D(100, 630);

            for (int i = 0; i < 10; i++)
            {
                PushButton _view = new PushButton();

                _view.Name = "sibling" + i;
                _view.LabelText = "view" + i;
                _view.MinimumSize = new Size2D(100, 50);
                _view.ParentOrigin = ParentOrigin.TopLeft;
                _view.PivotPoint = PivotPoint.TopLeft;
                _view.Position2D = _myPos + new Position2D(20 * i, 10 * i);

                _window.Add(_view);

                if (i<5)
                {
                    _view.SiblingOrder = i;
                }
                else
                {
                    _view.SiblingOrder = 10-i;
                }
            }
        }

        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
