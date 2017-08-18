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
    internal static partial class AudioEffect
    {
        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_bands_count")]
        internal static extern PlayerErrorCode GetEqualizerBandsCount(IntPtr player, out int count);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_set_equalizer_band_level")]
        internal static extern PlayerErrorCode SetEqualizerBandLevel(IntPtr player, int index, int level);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_level")]
        internal static extern PlayerErrorCode GetEqualizerBandLevel(IntPtr player, int index, out int level);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_set_equalizer_all_bands")]
        internal static extern PlayerErrorCode SetEqualizerAllBands(IntPtr player, out int band_levels, int length);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_level_range")]
        internal static extern PlayerErrorCode GetEqualizerLevelRange(IntPtr player, out int min, out int max);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_frequency")]
        internal static extern PlayerErrorCode GetEqualizerBandFrequency(IntPtr player, int index, out int frequency);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_frequency_range")]
        internal static extern PlayerErrorCode GetEqualizerBandFrequencyRange(IntPtr player, int index, out int range);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_equalizer_clear")]
        internal static extern PlayerErrorCode EqualizerClear(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_equalizer_is_available")]
        internal static extern PlayerErrorCode EqualizerIsAvailable(IntPtr player, out bool available);
    }
}
