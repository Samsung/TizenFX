/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// Manages state name and bit mask.
    /// </summary>
    internal static class ControlStateUtility
    {
        private const int MaxBitWidth = 62;
        private static readonly Dictionary<string, ulong> registeredStates = new Dictionary<string, ulong>();
        private static int nextBitPosition;

        /// <summary>
        /// </summary>
        public static ulong FullMask => (1UL << MaxBitWidth) - 1UL;

        /// <summary>
        /// </summary>
        public static IEnumerable<(string, ulong)> RegisteredStates()
        {

            foreach (var (key, value) in registeredStates)
            {
                yield return (key, value);
            }
        }

        public static ulong Register(string stateName)
        {
            if (stateName == null)
                throw new ArgumentNullException($"{nameof(stateName)} cannot be null.", nameof(stateName));

            if (string.IsNullOrWhiteSpace(stateName))
                throw new ArgumentException($"{nameof(stateName)} cannot be whitespace.", nameof(stateName));

            string trimmed = stateName.Trim();
            ulong bitMask = 0UL;

            if (trimmed == "All") return FullMask;

            if (trimmed != "Normal" && !registeredStates.TryGetValue(trimmed, out bitMask))
            {
                if (nextBitPosition + 1 > MaxBitWidth)
                {
                    throw new ArgumentException($"The given state name '{stateName}' is not acceptable since there is no more room to register a new state.");
                }

                bitMask = 1UL << nextBitPosition;
                registeredStates.Add(trimmed, bitMask);
                nextBitPosition++;
            }

            return bitMask;
        }
    }
}