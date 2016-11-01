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

namespace ElmSharp
{
    public class Background : Layout
    {
        public Background(EvasObject parent) : base(parent)
        {
            Style = "transparent";
        }

        public override Color Color
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                var swallowContent = GetPartContent("elm.swallow.rectangle");
                if (swallowContent != IntPtr.Zero)
                {
                    Interop.Evas.evas_object_color_get(swallowContent, out r, out g, out b, out a);
                }
                return new Color(r, g, b, a);
            }
            set
            {
                var swallowContent = GetPartContent("elm.swallow.rectangle");
                if(swallowContent == IntPtr.Zero)
                {
                    Interop.Elementary.elm_bg_color_set(Handle, value.R, value.G, value.B);
                    swallowContent = GetPartContent("elm.swallow.rectangle");
                }
                Interop.Evas.evas_object_color_set(swallowContent, value.R, value.G, value.B, value.A);
            }
        }

        public string File
        {
            get
            {
                return Interop.Elementary.BackgroundFileGet(Handle);
            }
            set
            {
                Interop.Elementary.elm_bg_file_set(Handle, value, IntPtr.Zero);
            }
        }

        public BackgroundOptions BackgroundOption
        {
            get
            {
                return (BackgroundOptions) Interop.Elementary.elm_bg_option_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_bg_option_set(Handle, (Interop.Elementary.BackgroundOptions) value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_bg_add(parent.Handle);
        }
    }

    public enum BackgroundOptions
    {
        Center,
        Scale,
        Stretch,
        Tile
    }
}
