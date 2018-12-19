/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using ElmSharp;

namespace ElmSharp.Test
{
    class AnimationViewTest1 : TestCaseBase
    {
        public override string TestName => "AnimationViewTest1";
        public override string TestDescription => "To test basic operation of AnimationView";

        private enum AnimationState
        {
            NotReady,
            Play,
            PlayBack,
            Pause,
            Stop,
        }

        private AnimationState _state;
        private bool _isPlayingBack;

        void UpdateAnimationViewStateLabel(Label _stateLabel)
        {
            if (_state == AnimationState.NotReady)
            {
                _stateLabel.Text = "<font_size=32>State = Not Ready</font_size>";
            }
            else if (_state == AnimationState.Play)
            {
                _stateLabel.Text = "<font_size=32>State = Playing</font_size>";
            }
            else if (_state == AnimationState.PlayBack)
            {
                _stateLabel.Text = "<font_size=32>State = Playing Back</font_size>";
            }
            else if (_state == AnimationState.Pause)
            {
                _stateLabel.Text = "<font_size=32>State = Paused</font_size>";
            }
            else if (_state == AnimationState.Stop)
            {
                _stateLabel.Text = "<font_size=32>State = Stopped</font_size>";
            }
        }

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Naviframe navi = new Naviframe(conformant)
            {
                PreserveContentOnPop = true,
                DefaultBackButtonEnabled = true
            };
            navi.Show();
            conformant.SetContent(navi);

            Layout layout = new Layout(conformant)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            layout.SetTheme("layout", "application", "default");
            layout.Show();

            Background bg = new Background(layout)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1,
                Color = Color.Gray,
            };
            bg.Show();
            layout.SetPartContent("elm.swallow.bg", bg);

            Box box = new Box(conformant)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            box.Show();
            box.SetPadding(5, 5);
            layout.SetPartContent("elm.swallow.content", box);

            Label label = new Label(box)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = 0.5,
                AlignmentY = 0,
            };
            label.Show();
            box.PackEnd(label);

            AnimationView aniview = new AnimationView(box)
            {
                WeightX = 1,
                WeightY = 1,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            aniview.SetAnimation(Path.Combine(TestRunner.ResourceDir, "a_mountain.json"));
            aniview.Show();
            box.PackEnd(aniview);

            Label label2 = new Label(box)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = 1.0,
                AlignmentY = 0.5,
                Text = "Duration : " + Math.Round(Convert.ToDouble(aniview.DurationTime), 2),
            };
            label2.Show();
            box.PackEnd(label2);

            Box box2 = new Box(box)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = 1,
                IsHorizontal = true,
            };
            box2.Show();
            box.PackEnd(box2);

            Check check = new Check(box2)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = -1,
                Text = "Loop",
            };
            check.Show();
            box2.PackEnd(check);

            check.StateChanged += (s, e) =>
            {
                aniview.AutoRepeat = !aniview.AutoRepeat;
            };

            Check check2 = new Check(box2)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = -1,
                Text = "Speed: 0.25x",
            };
            check2.Show();
            box2.PackEnd(check2);

            check2.StateChanged += (s, e) =>
            {
                if (check2.IsChecked)
                {
                    aniview.Speed = 0.25;
                }
                else
                {
                    aniview.Speed = 1.0;
                }
            };

            Slider slider = new Slider(box)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = -1,
                IsIndicatorVisible = true,
                IndicatorFormat = "%1.1f",
                Minimum = 0,
                Maximum = 1,
            };
            slider.Show();
            box.PackEnd(slider);

            slider.ValueChanged += (s, e) =>
            {
                aniview.KeyFrame = slider.Value;
            };

            Box box3 = new Box(box)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = 1,
                IsHorizontal = true,
            };
            box3.Show();
            box.PackEnd(box3);

            Button btn1 = new Button(box3)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = -1,
                Text = "Play",
            };
            btn1.Show();
            box3.PackEnd(btn1);

            btn1.Clicked += (s, e) =>
            {
                _isPlayingBack = false;
                if (_state == AnimationState.PlayBack)
                {
                    UpdateAnimationViewStateLabel(label);
                }
                aniview.Play();
            };

            Button btn2 = new Button(box3)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = -1,
                Text = "Play Back",
            };
            btn2.Show();
            box3.PackEnd(btn2);

            btn2.Clicked += (s, e) =>
            {
                _isPlayingBack = true;
                if (_state == AnimationState.Play)
                {
                    UpdateAnimationViewStateLabel(label);
                }
                aniview.PlayBack();
            };

            Button btn3 = new Button(box3)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = -1,
                Text = "Stop",
            };
            btn3.Show();
            box3.PackEnd(btn3);

            btn3.Clicked += (s, e) =>
            {
                aniview.Stop();
            };

            Box box4 = new Box(box)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = 1,
                IsHorizontal = true,
            };
            box4.Show();
            box.PackEnd(box4);

            Button btn4 = new Button(box3)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = -1,
                Text = "Pause",
            };
            btn4.Show();
            box4.PackEnd(btn4);

            btn4.Clicked += (s, e) =>
            {
                aniview.Pause();
            };

            Button btn5 = new Button(box3)
            {
                WeightX = 1,
                WeightY = 0,
                AlignmentX = -1,
                AlignmentY = -1,
                Text = "Resume",
            };
            btn5.Show();
            box4.PackEnd(btn5);

            btn5.Clicked += (s, e) =>
            {
                aniview.Resume();
            };

            aniview.Started += (s, e) =>
            {
                if (!_isPlayingBack)
                {
                    _state = AnimationState.Play;
                }
                else
                {
                    _state = AnimationState.PlayBack;
                }
                UpdateAnimationViewStateLabel(label);
            };

            aniview.Stopped += (s, e) =>
            {
                _state = AnimationState.Stop;
                UpdateAnimationViewStateLabel(label);

                slider.Value = 0;
            };

            aniview.Paused += (s, e) =>
            {
                _state = AnimationState.Pause;
                UpdateAnimationViewStateLabel(label);
            };

            aniview.Resumed += (s, e) =>
            {
                if (!_isPlayingBack)
                {
                    _state = AnimationState.Play;
                }
                else
                {
                    _state = AnimationState.PlayBack;
                }
                UpdateAnimationViewStateLabel(label);
            };

            aniview.Updated += (s, e) =>
            {
                slider.Value = aniview.KeyFrame;
            };

            _state = AnimationState.NotReady;
            UpdateAnimationViewStateLabel(label);

            navi.Push(layout, "AnimationView Test");
        }
    }
}
