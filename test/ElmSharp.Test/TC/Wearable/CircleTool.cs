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
using System.Collections.Generic;
using System.Text;

namespace ElmSharp.Test.Wearable
{
    public static class CircleTool
    {
        static Rect _inSquare;
        public static Rect GetInnerSquare(this Window window)
        {
            Size screenSize = window.ScreenSize;
            int min = Math.Min(screenSize.Height, screenSize.Width);
            int width = (int)(min * Math.Cos(Math.PI / 4));
            int x = screenSize.Width / 2 - width / 2;
            int y = screenSize.Height / 2 - width / 2;

            return _inSquare == default(Rect) ? (_inSquare = new Rect(x, y, width, width)) : _inSquare;
        }
    }
}
