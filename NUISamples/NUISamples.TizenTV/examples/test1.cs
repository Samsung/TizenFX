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
using System.Runtime.InteropServices;
using Tizen.NUI;
using System.Collections.Generic;


// 1) sibling order test
namespace Test1
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

        Stage _stage;
        public void Initialize()
        {
            _stage = Stage.Instance;
            _stage.BackgroundColor = Color.White;

            // 1) sibling order test
            SiblingTest();


        }

        public void SiblingTest()
        {
            View _prev = null;
            Position2D _myPos = new Position2D(100, 100);
            List<View> list_view = new List<View>();
            TextLabel _txt = new TextLabel();

            for (int i = 0; i < 10; i++)
            {
                View _view0 = new PushButton();
                PushButton _view = _view0 as PushButton;

                _view.Name = "sibling" + i;
                _view.MinimumSize = new Size2D(100, 50);
                _view.LabelText = "sibling" + i;
                _view.ParentOrigin = ParentOrigin.TopLeft;
                _view.AnchorPoint = AnchorPoint.TopLeft;
                _view.Position2D = _myPos + new Position2D(20 * i, 10 * i);
                _view.Clicked += (sender, ee) =>
                {
                    View curr = sender as View;
                    Tizen.Log.Debug("NUI", "clicked curr view name=" + curr.Name + "  sibling=" + curr.SiblingOrder);
                    curr.RaiseToTop();
                    if (_prev)
                    {
                        _prev.LowerToBottom();
                        Tizen.Log.Debug("NUI", "raise on top is called!curr sibling=" + curr.SiblingOrder + " prev name=" + _prev.Name + " sibling=" + _prev.SiblingOrder);
                    }
                    _prev = curr;
                    _txt.Text = "on top: " + curr.Name + ", sibling order=" + curr.SiblingOrder;
                    return true;
                };
                list_view.Add(_view);
            }

            for (int i = 0; i < 10; i++)
            {
                _stage.GetDefaultLayer().Add(list_view[i]);
                Tizen.Log.Debug("NUI", list_view[i].Name + "'s sibling order=" + list_view[i].SiblingOrder);
            }

            _txt.ParentOrigin = ParentOrigin.TopLeft;
            _txt.AnchorPoint = AnchorPoint.TopLeft;
            _txt.Text = "on top: sibling#, sibling order=?";
            _txt.Position2D = _myPos + new Position2D(-50, 200);
            _txt.TextColor = Color.Blue;
            _stage.GetDefaultLayer().Add(_txt);
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
