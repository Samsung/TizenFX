/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Concurrent;
using System.Threading;

namespace Tizen.Applications
{
    internal static class UIGadgetLifecycleManager
    {
        private static ConcurrentQueue<LifecycleEvent> _lifecycleEvents = new ConcurrentQueue<LifecycleEvent>();
        private static readonly Thread _mainThread = Thread.CurrentThread;
        private static bool _processing = false;

        internal static void DispatchLifecycleEvent(IUIGadget gadget, Action action, bool useIdler = true)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            Log.Info("ResourceType=" + gadget.UIGadgetInfo.ResourceType + ", State=" + gadget.State);
            _lifecycleEvents.Enqueue(new LifecycleEvent(gadget, action));

            if (useIdler)
            {
                CoreApplication.Post(() =>
                {
                    ProcessLifecycleEvent();
                });
            }
            else
            {
                ProcessLifecycleEvent();
            }
        }

        private static void ProcessLifecycleEvent()
        {
            if (_processing)
            {
                Log.Info("Already processing");
                return;
            }

            _processing = true;
            while (!_lifecycleEvents.IsEmpty)
            {
                if (!_lifecycleEvents.TryDequeue(out LifecycleEvent lifecycleEvent))
                {
                    return;
                }

                var action = lifecycleEvent.Action;
                action?.Invoke();
            }
            _processing = false;
        }

        internal class LifecycleEvent
        {
            internal LifecycleEvent(IUIGadget gadget, Action action)
            {
                UIGadget = gadget;
                Action = action;
            }

            internal IUIGadget UIGadget { get; set; }

            internal Action Action { get; set; }
        }
    }
}
