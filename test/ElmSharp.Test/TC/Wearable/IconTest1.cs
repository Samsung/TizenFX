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
using System.Collections.Generic;

namespace ElmSharp.Test.Wearable
{
    public class IconTest1 : WearableTestCase
    {
        public override string TestName => "IconTest1";
        public override string TestDescription => "To test basic operation of Icon";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.Gray
            };
            bg.Show();
            window.AddResizeObject(bg);

            Conformant conformant = new Conformant(window);
            conformant.Show();
            Scroller scroller = new Scroller(window);
            scroller.Show();
            scroller.Geometry = window.GetInnerSquare();
            Box box = new Box(window);
            box.Show();
            scroller.SetContent(box);

            List<string> iconList = new List<string>{ "home", "close", "apps", "arrow_up", "arrow_down", "arrow_left", "arrow_right", "chat", "clock", "delete", "edit", "refresh", "folder", "file",
                "menu/home", "menu/close", "menu/apps", "menu/arrow_up", "menu/arrow_down", "menu/arrow_left", "menu/arrow_right", "menu/chat", "menu/clock", "menu/delete", "menu/edit", "menu/refresh", "menu/folder",
                "menu/file", "media_player/forward", "media_player/info", "media_player/next", "media_player/pause", "media_player/play", "media_player/prev", "media_player/rewind", "media_player/stop"};

            foreach (var iconName in iconList)
            {
                Label label = new Label(window)
                {
                    Text = iconName,
                };
                Icon icon = new Icon(window)
                {
                    IconLookupOrder = IconLookupOrder.ThemeFirst,
                    StandardIconName = iconName,
                    AlignmentX = -1,
                    AlignmentY = -1,
                    WeightX = 1,
                    WeightY = 1,
                    MinimumHeight = 100,
                    MinimumWidth = 100,
                };
                icon.Show();
                label.Show();
                box.PackEnd(icon);
                box.PackEnd(label);
            }


        }
    }
}
