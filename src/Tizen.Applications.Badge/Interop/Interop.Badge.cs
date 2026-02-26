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
using System.Runtime.InteropServices.Marshalling;
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

        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ForeachCallback(string appId, uint count, IntPtr userData);

        internal delegate void ChangedCallback(Action action, string appId, uint count, IntPtr userData);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_add", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError Add(string appId);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_remove", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError Remove(string appId);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_set_count", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError SetCount(string appId, uint count);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_get_count", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError GetCount(string appId, out uint count);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_set_display", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError SetDisplay(string appId, uint isDisplay);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_get_display", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError GetDisplay(string appId, out uint isDisplay);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_foreach", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError Foreach(ForeachCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_register_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError SetChangedCallback(ChangedCallback callback, IntPtr userData);

        [LibraryImport(Libraries.Badge, EntryPoint = "badge_unregister_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial BadgeError UnsetChangedCallback(ChangedCallback callback);
    }
}




