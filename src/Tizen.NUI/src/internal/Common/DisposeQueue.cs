/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI
{
    [SuppressMessage("Microsoft.Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is a singleton class and is not disposed")]
    internal class DisposeQueue
    {
        private static readonly DisposeQueue disposableQueue = new DisposeQueue();
        private List<IDisposable> disposables = new List<IDisposable>();
        private System.Object listLock = new object();
        private EventThreadCallback eventThreadCallback;
        private EventThreadCallback.CallbackDelegate disposeQueueProcessDisposablesDelegate;

        private bool isCalled = false;

        private DisposeQueue()
        {
        }

        ~DisposeQueue()
        {
            Tizen.Log.Debug("NUI", $"DisposeQueue is destroyed\n");
        }

        public static DisposeQueue Instance
        {
            get { return disposableQueue; }
        }

        public void Initialize()
        {
            if (isCalled == false)
            {
                disposeQueueProcessDisposablesDelegate = new EventThreadCallback.CallbackDelegate(ProcessDisposables);
                eventThreadCallback = new EventThreadCallback(disposeQueueProcessDisposablesDelegate);
                isCalled = true;
            }
        }

        public void Add(IDisposable disposable)
        {
            lock (listLock)
            {
                disposables.Add(disposable);
            }

            if (eventThreadCallback != null)
            {
                eventThreadCallback.Trigger();
            }
        }

        public void ProcessDisposables()
        {
            lock (listLock)
            {
                foreach (IDisposable disposable in disposables)
                {
                    disposable.Dispose();
                }
                disposables.Clear();
            }
        }
    }
}
