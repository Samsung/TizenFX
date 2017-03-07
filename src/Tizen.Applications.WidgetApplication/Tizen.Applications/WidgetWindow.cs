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

using ElmSharp;
using System;
using System.Collections.Generic;

namespace Tizen.Applications
{
    internal class WidgetWindow : Widget
    {
        private IntPtr _handle;

        internal WidgetWindow(IntPtr handle) : base()
        {
            _handle = handle;
            Realize(null);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return _handle;
        }
    }

    internal class ConformantWindow : Widget
    {
        private IntPtr _handle;
        private IntPtr _conf;

        internal ConformantWindow(EvasObject parent, IntPtr handle) : base()
        {
            _handle = handle;
            Realize(parent);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            _conf = Interop.Widget.elm_conformant_add(_handle);
            Interop.Widget.evas_object_size_hint_weight_set(_conf, 1.0, 1.0);
            Interop.Widget.elm_win_conformant_set(_handle, true);
            Interop.Widget.elm_win_resize_object_add(_handle, _conf);
            return _conf;
        }

    }
}

