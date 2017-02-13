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
    public class Box : Container
    {
        private Interop.Elementary.BoxLayoutCallback _layoutCallback;

        public Box(EvasObject parent) : base(parent)
        {
        }

        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_box_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_box_horizontal_set(RealHandle, value);
            }
        }

        public void PackEnd(EvasObject content)
        {
            Interop.Elementary.elm_box_pack_end(RealHandle, content);
            AddChild(content);
        }

        public void PackStart(EvasObject content)
        {
            Interop.Elementary.elm_box_pack_start(RealHandle, content);
            AddChild(content);
        }

        public void PackAfter(EvasObject content, EvasObject after)
        {
            Interop.Elementary.elm_box_pack_after(RealHandle, content, after);
            AddChild(content);
        }

        public void UnPack(EvasObject content)
        {
            Interop.Elementary.elm_box_unpack(RealHandle, content);
            RemoveChild(content);
        }

        public void UnPackAll()
        {
            Interop.Elementary.elm_box_unpack_all(RealHandle);
            ClearChildren();
        }

        public void SetLayoutCallback(Action action)
        {
            _layoutCallback = (obj, priv, data) =>
            {
                action();
            };
            Interop.Elementary.elm_box_layout_set(RealHandle, _layoutCallback, IntPtr.Zero, null);
        }

        public override void SetPartColor(string part, Color color)
        {
            Interop.Elementary.elm_object_color_class_color_set(Handle, part, color.R * color.A / 255,
                                                                              color.G * color.A / 255,
                                                                              color.B * color.A / 255,
                                                                              color.A);
        }

        public override Color GetPartColor(string part)
        {
            int r, g, b, a;
            Interop.Elementary.elm_object_color_class_color_get(Handle, part, out r, out g, out b, out a);
            return new Color((int)(r / (a / 255.0)), (int)(g / (a / 255.0)), (int)(b / (a / 255.0)), a);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "background", "default");

            RealHandle = Interop.Elementary.elm_box_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}
