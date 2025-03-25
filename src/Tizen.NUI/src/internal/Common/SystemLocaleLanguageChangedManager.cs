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
    /// A static class which adds user handler to the SystemSettings.LocaleLanguageChanged event.
    /// This class also adds user handler to the last of the SystemSettings.LocaleLanguageChanged event.
    /// </summary>
    internal static class SystemLocaleLanguageChangedManager
    {
        private static string localeLanguage = string.Empty;
        private static WeakEvent<EventHandler<LocaleLanguageChangedEventArgs>> proxy = new WeakEvent<EventHandler<LocaleLanguageChangedEventArgs>>();

        static SystemLocaleLanguageChangedManager()
        {
            SystemSettings.LocaleLanguageChanged += SystemLocaleLanguageChanged;
        }

        /// <summary>
        /// The handler invoked last after all handlers added to the SystemSettings.LocaleLanguageChanged event are invoked.
        /// </summary>
        public static event EventHandler<LocaleLanguageChangedEventArgs> Finished;

        /// <summary>
        /// Adds the given handler to the SystemSettings.LocaleLanguageChanged event.
        /// </summary>
        /// <param name="handler">A handler to be added to the event</param>
        public static void Add(EventHandler<LocaleLanguageChangedEventArgs> handler)
        {
            proxy.Add(handler);
        }

        /// <summary>
        /// Removes the given handler from the SystemSettings.LocaleLanguageChanged event.
        /// </summary>
        /// <param name="handler">A handler to be added to the event</param>
        public static void Remove(EventHandler<LocaleLanguageChangedEventArgs> handler)
        {
            proxy.Remove(handler);
        }

        private static void SystemLocaleLanguageChanged(object sender, LocaleLanguageChangedEventArgs args)
        {
            localeLanguage = args.Value;
            proxy.Invoke(sender, args);
            Finished?.Invoke(sender, args);
        }

        public static string LocaleLanguage
        {
            get
            {
                if (string.IsNullOrEmpty(localeLanguage))
                {
                    localeLanguage = SystemSettings.LocaleLanguage;
                }
                return localeLanguage;
            }
        }
    }
}