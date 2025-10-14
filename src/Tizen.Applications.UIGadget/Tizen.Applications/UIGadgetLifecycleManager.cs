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
using Tizen.Applications;

namespace Tizen.Applications
{
    internal static class UIGadgetLifecycleManager
    {
        private static ConcurrentQueue<LifecycleEvent> _lifecycleEvents = new ConcurrentQueue<LifecycleEvent>();
        private static bool _processing = false;
        private static readonly Thread _mainThread = Thread.CurrentThread;
        internal static void DispatchLifecycleEvent(IUIGadget gadget, UIGadgetLifecycleState state)
        {
            if (gadget == null)
            {
                throw new ArgumentNullException(nameof(gadget));
            }

            Log.Info("ResourceType=" + gadget.UIGadgetInfo.ResourceType + ", State=" + gadget.State + " -> " + state);
            if (_mainThread.Equals(Thread.CurrentThread))
            {
                ProcessLifecycleEvent(gadget, state);
            }
            else
            {
                CoreApplication.Post(() =>
                {
                    ProcessLifecycleEvent(gadget, state);
                });
            }
        }

        private static void ProcessLifecycleEvent(IUIGadget gadget, UIGadgetLifecycleState state)
        {
            if (gadget.State == state)
            {
                Log.Warn("Skip event=" + state);
                return;
            }

            switch (state)
            {
                case UIGadgetLifecycleState.PreCreated:
                    if (gadget.State == UIGadgetLifecycleState.Initialized)
                    {
                        gadget.OnPreCreate();
                    }
                    break;
                case UIGadgetLifecycleState.Created:
                    if (gadget.State == UIGadgetLifecycleState.PreCreated)
                    {
                        gadget.MainView = gadget.OnCreate();
                    }
                    break;
                case UIGadgetLifecycleState.Destroyed:
                    if (gadget.State == UIGadgetLifecycleState.Resumed)
                    {
                        gadget.OnPause();
                    }
                    if (gadget.State == UIGadgetLifecycleState.PreCreated || gadget.State == UIGadgetLifecycleState.Created || gadget.State == UIGadgetLifecycleState.Paused)
                    {
                        gadget.OnDestroy();
                    }
                    break;
                case UIGadgetLifecycleState.Resumed:
                    if (gadget.State == UIGadgetLifecycleState.Created || gadget.State == UIGadgetLifecycleState.Paused)
                    {
                        gadget.OnResume();
                    }
                    break;
                case UIGadgetLifecycleState.Paused:
                    if (gadget.State == UIGadgetLifecycleState.Resumed)
                    {
                        gadget.OnPause();
                    }
                    break;
            }
        }

        internal class LifecycleEvent
        {
            internal LifecycleEvent(IUIGadget gadget, UIGadgetLifecycleState state)
            {
                UIGadget = gadget;
                State = state;
            }

            internal IUIGadget UIGadget { get; set; }

            internal UIGadgetLifecycleState State { get; set; }
        }
    }
}
