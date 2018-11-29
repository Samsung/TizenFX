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

using System.IO;

namespace ElmSharp.Test
{
    class AnimationViewTest1 : TestCaseBase
    {
        public override string TestName => "AnimationViewTest1";
        public override string TestDescription => "To test basic operation of AnimationView";

        public override void Run(Window window)
        {
            int screenW = window.ScreenSize.Width;
            int screenH = window.ScreenSize.Height;

            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.White
            };
            bg.Show();
            window.AddResizeObject(bg);

            AnimationView lottie = new AnimationView(window);
            lottie.Size = new Size(300, 300);
            lottie.SetFile(Path.Combine(TestRunner.ResourceDir, "a_mountain.json"));
            lottie.Move((screenW - 300) / 2, screenH / 100);
            lottie.Resize(300, 300);
            lottie.AutoPlay = true;
            lottie.Show();

            Check check1 = new Check(window);
            check1.Text = "AutoRepeat";
            check1.Resize(screenW, 50);
            check1.Move(10, screenH - 170);
            check1.Show();
            check1.StateChanged += (s, e) =>
            {
                lottie.AutoRepeat = !lottie.AutoRepeat;
            };

            Button button1 = new Button(window);
            Button button2 = new Button(window);

            button1.Text = "Play";
            button1.Resize((screenW - 60) / 3, 100);
            button1.Move(15, screenH - 110);
            button1.Show();
            button1.Clicked += (s, e) =>
            {
                if (lottie.State == AnimationState.Stop || lottie.State == AnimationState.PlayBack)
                {
                    lottie.Play();
                    button1.Text = "Pause";
                    button2.Text = "PlayBack";
                }
                else if (lottie.State == AnimationState.Pause)
                {
                    if (button1.Text == "Resume")
                    {
                        lottie.Resume();
                        button1.Text = "Pause";
                    }
                }
                else if (lottie.State == AnimationState.Play)
                {
                    lottie.Pause();
                    button1.Text = "Resume";
                }
            };

            button2.Text = "PlayBack";
            button2.Resize((screenW - 60) / 3, 100);
            button2.Move(30 + (screenW - 60) / 3, screenH - 110);
            button2.Show();
            button2.Clicked += (s, e) =>
            {
                if (lottie.State == AnimationState.Stop || lottie.State == AnimationState.Play)
                {
                    lottie.PlayBack();
                    button2.Text = "Pause";
                    button1.Text = "Play";
                }
                else if (lottie.State == AnimationState.Pause)
                {
                    if (button2.Text == "Resume")
                    {
                        lottie.Resume();
                        button2.Text = "Pause";
                    }
                }
                else if (lottie.State == AnimationState.PlayBack)
                {
                    lottie.Pause();
                    button2.Text = "Resume";
                }
            };

            Button button3 = new Button(window);
            button3.Text = "Stop";
            button3.Resize((screenW - 60) / 3, 100);
            button3.Move(45 + (2 * (screenW - 60) / 3), screenH - 110);
            button3.Show();
            button3.Clicked += (s, e) =>
            {
                lottie.Stop();
            };

            lottie.Finished += (s, e) =>
            {
                button1.Text = "Play";
                button2.Text = "PlayBack";
            };

            lottie.Stopped += (s, e) =>
            {
                button1.Text = "Play";
                button2.Text = "PlayBack";
            };
        }
    }
}
