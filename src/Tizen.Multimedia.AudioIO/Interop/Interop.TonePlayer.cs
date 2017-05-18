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
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class TonePlayer
    {
        [DllImport(Libraries.TonePlayer, EntryPoint = "tone_player_start_new")]
        internal static extern int Start(ToneType tone, IntPtr streamInfoHandle, int durationMs, out int playerId);

        [DllImport(Libraries.TonePlayer, EntryPoint = "tone_player_stop")]
        internal static extern int Stop(int PlayerId);
    }
}

