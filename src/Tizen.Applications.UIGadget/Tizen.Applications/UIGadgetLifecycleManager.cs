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
        private static readonly object _processingLock = new object();

        internal static void DispatchLifecycleEvent(IUIGadget gadget, Action action, bool useIdler = true)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            Log.Info("ResourceType=" + gadget.UIGadgetInfo.ResourceType + ", State=" + gadget.State + ", UseIdler = " + useIdler);
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
            if (!Monitor.TryEnter(_processingLock))
            {
                Log.Info("Already processing");
                return;
            }

            try
            {
                var retry = 3;
                while (!_lifecycleEvents.IsEmpty)
                {
                    if (!_lifecycleEvents.TryDequeue(out LifecycleEvent lifecycleEvent))
                    {
                        if ((!_lifecycleEvents.IsEmpty) && (retry-- > 0))
                        {
                            Log.Warn("Fail to deque lifecycle events, retry " + retry);
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    var action = lifecycleEvent.Action;
                    action?.Invoke();
                    retry = 3;
                }
            }
            finally
            {
                Monitor.Exit(_processingLock);
            }
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
