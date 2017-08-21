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

namespace ElmSharp.Test.Wearable
{
    public class ImageTest1 : WearableTestCase
    {
        public override string TestName => "ImageTest1";
        public override string TestDescription => "To test basic operation of Image";

        Image image;
        Label lbInfo;
        string[] btn_names = new string[] {"File1", "File2", "Uri", "Strm", "FileA1", "FileA2", "UriA", "StrmA"};

        public override void Run(Window window)
        {
            Rect square = window.GetInnerSquare();

            Button[] btns = new Button[8];
            Size btnSize = new Size(square.Width / 4 - 2, square.Height / 5 - 1);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    btns[i * 4 + j] = new Button(window)
                    {
                        Text = "<span color=#ffffff font_size=12>" + btn_names[i * 4 + j] + "</span>",
                    };
                    int x = j * btnSize.Width + j *2;
                    int y = i * btnSize.Height + i;
                    btns[i * 4 + j].Geometry = new Rect(square.X + x, square.Y + y, btnSize.Width, btnSize.Height);
                    btns[i * 4 + j].Show();
                }
            }

            lbInfo = new Label(window)
            {
                Color = Color.White,
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1
            };
            lbInfo.Show();
            lbInfo.Geometry = new Rect(square.X,  square.Y + square.Height, square.Width, 15);

            image = new Image(window)
            {
                IsFixedAspect = true,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            image.Show();
            image.Load(Path.Combine(TestRunner.ResourceDir, "picture.png"));
            image.Geometry = new Rect(square.X, square.Y + btnSize.Height * 2 + 2 , square.Width, btnSize.Height * 3);
            image.Clicked += (s, e) =>
            {
                Console.WriteLine("Image has been clicked. (IsFixedAspect = {0}", image.IsFixedAspect);
                image.IsFixedAspect = image.IsFixedAspect == true ? false : true;
            };

            btns[0].Clicked += (s, e) => LoadFile("TED/large/a.jpg");
            btns[1].Clicked += (s, e) => LoadFile("TED/large/b.jpg");
            btns[2].Clicked += (s, e) => LoadUri("http://pe.tedcdn.com/images/ted/2e306b9655267cee35e45688ace775590b820510_615x461.jpg");
            btns[3].Clicked += (s, e) => LoadStream(new FileStream(Path.Combine(TestRunner.ResourceDir, "TED/large/c.jpg"), FileMode.Open, FileAccess.Read));

            btns[4].Clicked += (s, e) => LoadFileAsync("TED/large/d.jpg");
            btns[5].Clicked += (s, e) => LoadFileAsync("TED/large/e.jpg");
            btns[6].Clicked += (s, e) => LoadUriAsync("http://pe.tedcdn.com/images/ted/2e306b9655267cee35e45688ace775590b820510_615x461.jpg");
            btns[7].Clicked += (s, e) => LoadStreamAsync(new FileStream(Path.Combine(TestRunner.ResourceDir, "TED/large/f.jpg"), FileMode.Open, FileAccess.Read));
        }

        void LoadFile(string file)
        {
            bool ret = image.Load(Path.Combine(TestRunner.ResourceDir, file));
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        void LoadUri(string uri)
        {
            bool ret = image.Load(uri);
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        void LoadStream(Stream stream)
        {
            bool ret = image.Load(stream);
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        async void LoadFileAsync(string file)
        {
            var ret = await image.LoadAsync(Path.Combine(TestRunner.ResourceDir, file));
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        async void LoadUriAsync(string uri)
        {
            var ret = await image.LoadAsync(uri);
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        async void LoadStreamAsync(Stream stream)
        {
            var ret = await image.LoadAsync(stream);
            if (ret)
                UpdateLabelText(lbInfo, image.File);
            else
                UpdateLabelText(lbInfo, "Loading Failed.");
        }

        void UpdateLabelText(Label lable, string text)
        {
            lable.Text = "<span color=#ffffff font_size=12>" + text + "</span>";
        }
    }
}
