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
using System.Runtime.InteropServices;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class Badge
    {
        internal enum Action : uint
        {
            Create = 0,
            Remove,
            Update,
            ChangedDisplay,
            ServiceReady
        }

        internal delegate void ForeachCallback(string appId, uint count, IntPtr userData);

        internal delegate void ChangedCallback(Action action, string appId, uint count, IntPtr userData);

        [DllImport(Libraries.Badge, EntryPoint = "badge_add")]
        internal static extern BadgeError Add(string appId);

        [DllImport(Libraries.Badge, EntryPoint = "badge_remove")]
        internal static extern BadgeError Remove(string appId);

        [DllImport(Libraries.Badge, EntryPoint = "badge_set_count")]
        internal static extern BadgeError SetCount(string appId, uint count);

        [DllImport(Libraries.Badge, EntryPoint = "badge_get_count")]
        internal static extern BadgeError GetCount(string appId, out uint count);

        [DllImport(Libraries.Badge, EntryPoint = "badge_set_display")]
        internal static extern BadgeError SetDisplay(string appId, uint isDisplay);

        [DllImport(Libraries.Badge, EntryPoint = "badge_get_display")]
        internal static extern BadgeError GetDisplay(string appId, out uint isDisplay);

        [DllImport(Libraries.Badge, EntryPoint = "badge_foreach")]
        internal static extern BadgeError Foreach(ForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.Badge, EntryPoint = "badge_register_changed_cb")]
        internal static extern BadgeError SetChangedCallback(ChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Badge, EntryPoint = "badge_unregister_changed_cb")]
        internal static extern BadgeError UnsetChangedCallback(ChangedCallback callback);
    }
}
