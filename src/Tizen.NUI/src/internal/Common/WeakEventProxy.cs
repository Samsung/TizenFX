/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd.
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
    /// Internal class that helps to make a proxy weak event connecting to a normal source event.
    /// Note that the source event will have a strong reference of the WeakEventProxy instance instead of handler's.
    /// Please replace it to WeakEventManager after version up.
    /// </summary>
    internal abstract class WeakEventProxy<EventArgsT> : WeakEvent<EventHandler<EventArgsT>>
    {
        protected abstract void ConnectToEvent(EventHandler<EventArgsT> handler);

        protected abstract void DisconnectToEvent(EventHandler<EventArgsT> handler);

        protected override void OnCountIncreased()
        {
            if (Count == 1)
            {
                ConnectToEvent(OnEventInvoked);
            }
        }

        protected override void OnCountDecreased()
        {
            if (Count == 0)
            {
                DisconnectToEvent(OnEventInvoked);
            }
        }

        private void OnEventInvoked(object sender, EventArgsT args)
        {
            Invoke(sender, args as EventArgs);
        }
    }

    /// <summary>
    /// The non-generic version of <see cref="WeakEventProxy"/>.
    /// </summary>
    internal abstract class WeakEventProxy : WeakEvent<EventHandler>
    {
        protected abstract void ConnectToEvent(EventHandler handler);

        protected abstract void DisconnectToEvent(EventHandler handler);

        protected override void OnCountIncreased()
        {
            if (Count == 1)
            {
                ConnectToEvent(OnEventInvoked);
            }
        }

        protected override void OnCountDecreased()
        {
            if (Count == 0)
            {
                DisconnectToEvent(OnEventInvoked);
            }
        }

        private void OnEventInvoked(object sender, EventArgs args)
        {
            Invoke(sender, args);
        }
    }

    internal class SystemFontTypeChanged : WeakEventProxy<FontTypeChangedEventArgs>
    {
        protected override void ConnectToEvent(EventHandler<FontTypeChangedEventArgs> handler)
        {
            SystemSettings.FontTypeChanged += handler;
        }

        protected override void DisconnectToEvent(EventHandler<FontTypeChangedEventArgs> handler)
        {
            SystemSettings.FontTypeChanged -= handler;
        }
    }

    internal class SystemFontSizeChanged : WeakEventProxy<FontSizeChangedEventArgs>
    {
        protected override void ConnectToEvent(EventHandler<FontSizeChangedEventArgs> handler)
        {
            SystemSettings.FontSizeChanged += handler;
        }

        protected override void DisconnectToEvent(EventHandler<FontSizeChangedEventArgs> handler)
        {
            SystemSettings.FontSizeChanged -= handler;
        }
    }

    internal class SystemLocaleLanguageChanged : WeakEventProxy<LocaleLanguageChangedEventArgs>
    {
        protected override void ConnectToEvent(EventHandler<LocaleLanguageChangedEventArgs> handler)
        {
            SystemSettings.LocaleLanguageChanged += handler;
        }

        protected override void DisconnectToEvent(EventHandler<LocaleLanguageChangedEventArgs> handler)
        {
            SystemSettings.LocaleLanguageChanged -= handler;
        }
    }
}
