/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd.
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

extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;

using System;

namespace Tizen.NUI
{
    /// <summary>
    /// A static class which adds user handler to the SystemSettings.FontTypeChanged event.
    /// This class also adds user handler to the last of the SystemSettings.FontTypeChanged event.
    /// </summary>
    internal static class SystemFontTypeChangedManager
    {
        static SystemFontTypeChangedManager()
        {
            SystemSettings.FontTypeChanged += SystemFontTypeChanged;
        }

        /// <summary>
        /// The handler invoked last after all handlers added to the SystemSettings.FontTypeChanged event are invoked.
        /// </summary>
        public static event EventHandler<FontTypeChangedEventArgs> Finished;

        /// <summary>
        /// Adds the given handler to the SystemSettings.FontTypeChanged event.
        /// </summary>
        /// <param name="handler">A handler to be added to the event</param>
        public static void Add(EventHandler<FontTypeChangedEventArgs> handler)
        {
            proxy.Add(handler);
        }

        /// <summary>
        /// Removes the given handler from the SystemSettings.FontTypeChanged event.
        /// </summary>
        /// <param name="handler">A handler to be added to the event</param>
        public static void Remove(EventHandler<FontTypeChangedEventArgs> handler)
        {
            proxy.Remove(handler);
        }

        private static void SystemFontTypeChanged(object sender, FontTypeChangedEventArgs args)
        {
            fontType = args.Value;
            proxy.Invoke(sender, args);
            Finished?.Invoke(sender, args);
        }

        public static string FontType
        {
            get
            {
                if (string.IsNullOrEmpty(fontType))
                {
                    fontType = SystemSettings.FontType;
                }
                return fontType;
            }
        }

        private static string fontType = string.Empty;
        private static WeakEvent<EventHandler<FontTypeChangedEventArgs>> proxy = new WeakEvent<EventHandler<FontTypeChangedEventArgs>>();
    }
}