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

        public Box(EvasObject parent) : base(parent) { }
        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_box_horizontal_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_box_horizontal_set(Handle, value);
            }
        }

        public void PackEnd(EvasObject content)
        {
            Interop.Elementary.elm_box_pack_end(Handle, content);
            AddChild(content);
        }

        public void PackStart(EvasObject content)
        {
            Interop.Elementary.elm_box_pack_start(Handle, content);
            AddChild(content);
        }

        public void PackAfter(EvasObject content, EvasObject after)
        {
            Interop.Elementary.elm_box_pack_after(Handle, content, after);
            AddChild(content);
        }

        public void UnPack(EvasObject content)
        {
            Interop.Elementary.elm_box_unpack(Handle, content);
            RemoveChild(content);
        }

        public void UnPackAll()
        {
            Interop.Elementary.elm_box_unpack_all(Handle);
            ClearChildren();
        }

        public void SetLayoutCallback(Action action)
        {
            _layoutCallback = (obj, priv, data) =>
            {
                action();
            };
            Interop.Elementary.elm_box_layout_set(Handle, _layoutCallback, IntPtr.Zero, null);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_box_add(parent);
        }
    }
}
