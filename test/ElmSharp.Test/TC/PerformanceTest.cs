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
using ElmSharp;

namespace ElmSharp.Test
{
    public class PerformanceTest : TestCaseBase
    {
        public override string TestName => "PerformanceTest";
        public override string TestDescription => "To test Performance of GenList";

        const int TestItemMax = 2000;
        const double TimeSet = 5.0;

        string[] arrLabel = {
            "Time Warner Cable(Cable)",
            "ComCast (Cable)",
            "Dish (Satellite)",
            "DirecTV (Satellite)",
            "Tata Sky (Satellite)",
            "Nextra Cable(Cable)",
            "DD Plus (Cable)",
            "Tikona Cable(Cable)",
            "True Provider (Cable)",
            "Vodafone (Satellite)",
            "Sample Text"
        };

        GenList list;
        Box box;
        Box box2;
        GenListItem ItemTarget = null;
        double _enteringSpeed = 0;
        int _frameCount = 0;
        int _ecoreCount = 0;
        double _frameSet = 0;
        IntPtr _anim = IntPtr.Zero;
        double FrameFPS = 0;
        double AnimatorFPS = 0;

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Naviframe navi = new Naviframe(window)
            {
                PreserveContentOnPop = true,
                DefaultBackButtonEnabled = true
            };

            box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();

            box2 = new Box(box);
            //elm_box_padding_set(box2, ELM_SCALE_SIZE(10), ELM_SCALE_SIZE(10)); ºÎºÐ ºüÁü.
            box2.Show();
            box.PackEnd(box2);

            list = new GenList(window)
            {
                Homogeneous = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Style = "solid/default"
            };
            box.PackEnd(list);
            navi.Push(box, "Performance");

            InitializeListItem();

            list.Changed += List_Changed;
            list.ScrollAnimationStarted += List_ScrollAnimationStarted;
            list.ScrollAnimationStopped += List_ScrollAnimationStopped;
            list.Show();

            navi.Show();
            conformant.SetContent(navi);
        }

        private void InitializeListItem()
        {
            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (obj, part) =>
                {
                    return (string)obj;
                }
            };

            for (int i = 0; i < TestItemMax; ++i)
            {
                if (i == 999)
                    ItemTarget = list.Append(defaultClass, new string(arrLabel[i % 10].ToCharArray()));
                else
                    list.Append(defaultClass, new string(arrLabel[i % 10].ToCharArray()));
            }
        }

        private void List_ScrollAnimationStopped(object sender, EventArgs e)
        {
            list.RenderPost -= List_RenderPostFrame;
            list.ScrollAnimationStarted -= List_ScrollAnimationStarted;
            list.ScrollAnimationStopped -= List_ScrollAnimationStopped;

            EcoreAnimator.RemoveAnimator(_anim);
            Elementary.BringInScrollFriction = _frameSet;

            FrameFPS = _frameCount / TimeSet;
            AnimatorFPS = _ecoreCount / TimeSet;

            Button btn1 = new Button(box2)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            btn1.Text = string.Format("Entering Speed : {0:f1} msec", _enteringSpeed);
            btn1.Show();
            box2.PackEnd(btn1);
            Button btn2 = new Button(box2)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            btn2.Text = string.Format("Animator FPS : {0:f1} fps", AnimatorFPS);
            btn2.Show();
            box2.PackEnd(btn2);
            Button btn3 = new Button(box2)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            btn3.Text = string.Format("Evas FPS : {0:f1} fps", FrameFPS);
            btn3.Show();
            box2.PackEnd(btn3);
            box2.SetAlignment(-1, -1);
            box2.SetWeight(1, 0.07);
        }

        private void List_RenderPost(object sender, EventArgs e)
        {
            list.RenderPost -= List_RenderPost;
            _enteringSpeed = (EcoreAnimator.GetCurrentTime() - _enteringSpeed) * 1000;

            _frameSet = Elementary.BringInScrollFriction;
            Elementary.BringInScrollFriction = TimeSet;
            list.ScrollTo(ItemTarget, ScrollToPosition.In, true);
        }

        private void List_ScrollAnimationStarted(object sender, EventArgs e)
        {
            _ecoreCount = 0;
            _anim = EcoreAnimator.AddAmimator(OnEcoreCheck);
            list.RenderPost += List_RenderPostFrame;
        }

        private bool OnEcoreCheck()
        {
            _ecoreCount++;
            return true;
        }

        private void List_RenderPostFrame(object sender, EventArgs e)
        {
            _frameCount++;
        }

        private void List_Changed(object sender, EventArgs e)
        {
            _enteringSpeed = EcoreAnimator.GetCurrentTime();
            list.Changed -= List_Changed;
            list.RenderPost += List_RenderPost;
        }
    }
}