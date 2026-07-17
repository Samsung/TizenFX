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
using System.Runtime.CompilerServices;

namespace Tizen.Multimedia
{
    internal static class AudioIOUtil
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ValidateState(AudioIOState curState, AudioIOState desired)
        {
            if (curState == desired)
            {
                return;
            }

            ThrowInvalidState(curState, desired);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ValidateState(AudioIOState curState, AudioIOState desired1, AudioIOState desired2)
        {
            if (curState == desired1 || curState == desired2)
            {
                return;
            }

            ThrowInvalidState(curState, desired1, desired2);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowInvalidState(AudioIOState curState, AudioIOState desired) =>
            throw new InvalidOperationException($"The audio is not in a valid state. " +
                $"Current State : { curState }, Valid State : { desired }.");

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowInvalidState(AudioIOState curState, AudioIOState desired1, AudioIOState desired2) =>
            throw new InvalidOperationException($"The audio is not in a valid state. " +
                $"Current State : { curState }, Valid State : { desired1 }, { desired2 }.");
    }
}
