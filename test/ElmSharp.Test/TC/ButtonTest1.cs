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
    class ButtonTest1 : TestCaseBase
    {
        public override string TestName => "ButtonTest1";
        public override string TestDescription => "To test basic operation of Button";

        public override void Run(Window window)
        {
            Button button1 = new Button(window) {
                Text = "Button 1",
            };

            button1.SetPartColor("bg", Color.Red);

            button1.Clicked += (s, e) =>
            {
                Console.WriteLine("Button1 Clicked! : {0}", button1.ClassName);
                Console.WriteLine("Button1 Clicked! : {0}", button1.ClassName.ToLower());
                Console.WriteLine("Button1 Clicked! : {0}", button1.ClassName.ToLower().Replace("elm_",""));
                Console.WriteLine("Button1 Clicked! : {0}", button1.ClassName.ToLower().Replace("elm_", "")+ "/" + "bg");
            };

            button1.Pressed += (s, e) =>
            {
                Console.WriteLine("Button1 Pressed!");
            };

            button1.Released += (s, e) =>
            {
                Console.WriteLine("Button1 Released!");
            };

            button1.Repeated += (s, e) =>
            {
                Console.WriteLine("Button1 Repeated!");
            };

            button1.Show();
            button1.Resize(500, 100);
            button1.Move(0, 0);
        }

    }
}
