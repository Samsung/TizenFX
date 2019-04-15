/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using Tizen.WebView;

internal static partial class Interop
{
    internal static partial class ChromiumEwk
    {
        [DllImport(Libraries.ChromiumEwk)]
        internal static extern int ewk_context_menu_item_tag_get(IntPtr contextMenuItem);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern int ewk_context_menu_item_count(IntPtr contextMenu);

        [DllImport(Libraries.ChromiumEwk)]
        internal static extern IntPtr ewk_context_menu_nth_item_get(IntPtr contextMenu, int n);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_context_menu_item_remove(IntPtr contextMenu, IntPtr contextMenuItem);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_context_menu_item_append_as_action(IntPtr contextMenu, ContextMenuItemTag tag, string title, bool enabled);

        [DllImport(Libraries.ChromiumEwk)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ewk_context_menu_item_append(IntPtr contextMenu, ContextMenuItemTag tag, string title, string iconPath, bool enabled);
    }
}
