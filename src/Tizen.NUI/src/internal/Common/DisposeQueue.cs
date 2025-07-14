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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Tizen.NUI
{
    [SuppressMessage("Microsoft.Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is a singleton class and is not disposed")]
    internal class DisposeQueue
    {
        private static readonly DisposeQueue disposableQueue = new DisposeQueue();
        private List<IDisposable> disposables = new List<IDisposable>();
        private System.Object listLock = new object();

        // Dispose incrementally at least max(100, incrementallyDisposedQueue * 20%) for each 1 event callback
        private const long minimumIncrementalCount = 100;
        private const long minimumIncrementalRate = 20;
        private List<IDisposable> incrementallyDisposedQueue = new List<IDisposable>();

        private EventThreadCallback eventThreadCallback;
        private EventThreadCallback.CallbackDelegate disposeQueueProcessDisposablesDelegate;

        private Dictionary<string, uint> typeCounter; // Only be used for debug

        private bool initialized;
        private bool processorRegistered;
        private bool eventThreadCallbackTriggered;

        private bool incrementalDisposeSupported;
        private bool fullCollectRequested;

        private DisposeQueue()
        {
        }

        ~DisposeQueue()
        {
            Tizen.Log.Debug("NUI", $"DisposeQueue is destroyed\n");
            initialized = false;
            if (processorRegistered && ProcessorController.Initialized)
            {
                processorRegistered = false;
                ProcessorController.Instance.ProcessorOnceEvent -= TriggerProcessDisposables;
            }
        }

        public static DisposeQueue Instance
        {
            get { return disposableQueue; }
        }

        public bool IncrementalDisposeSupported
        {
            get => incrementalDisposeSupported;
            set => incrementalDisposeSupported = value;
        }

        public bool FullyDisposeNextCollect
        {
            get => fullCollectRequested;
            set => fullCollectRequested = value;
        }

        public void Initialize()
        {
            if (!initialized)
            {
                disposeQueueProcessDisposablesDelegate = new EventThreadCallback.CallbackDelegate(ProcessDisposables);
                eventThreadCallback = new EventThreadCallback(disposeQueueProcessDisposablesDelegate);
                initialized = true;
            }
        }

        public void Add(IDisposable disposable)
        {
            lock (listLock)
            {
                disposables.Add(disposable);
            }

            if (initialized && eventThreadCallback != null)
            {
                if (!eventThreadCallbackTriggered)
                {
                    eventThreadCallbackTriggered = true;
                    eventThreadCallback.Trigger();
                }
            }
            else
            {
                // Flush Disposable queue synchronously if it is not initialized yet.
                // TODO : Need to check thread here if we need.

                // 2023-12-18 Block this logic since some APP call some thread-dependency objects before application start.
                // ProcessDisposables();
            }
        }

        public void TriggerProcessDisposables(object o, EventArgs e)
        {
            processorRegistered = false;

            if (initialized && eventThreadCallback != null)
            {
                if (!eventThreadCallbackTriggered)
                {
                    eventThreadCallbackTriggered = true;
                    eventThreadCallback.Trigger();
                }
            }
            else
            {
                // Flush Disposable queue synchronously if it is not initialized yet.
                // TODO : Need to check thread here if we need.

                // 2023-12-18 Block this logic since some APP call some thread-dependency objects before application start.
                // ProcessDisposables();
            }
        }

        public void ProcessDisposables()
        {
            eventThreadCallbackTriggered = false;

            lock (listLock)
            {
                if (disposables.Count > 0)
                {
                    // Move item from end, due to the performance issue.
                    while (disposables.Count > 0)
                    {
                        var disposable = disposables.Last();
                        disposables.RemoveAt(disposables.Count - 1);
                        incrementallyDisposedQueue.Add(disposable);
                    }
                    disposables.Clear();
                }
            }

            if (incrementallyDisposedQueue.Count > 0)
            {
                if (!incrementalDisposeSupported ||
                    (!fullCollectRequested && !ProcessorController.Initialized))
                {
                    // Full Dispose if IncrementalDisposeSupported is false, or ProcessorController is not initialized yet.
                    fullCollectRequested = true;
                }
                ProcessDisposablesIncrementally();
            }
        }

        private void ProcessDisposablesIncrementally()
        {
            var disposeCount = fullCollectRequested ? incrementallyDisposedQueue.Count
                                                    : Math.Min(incrementallyDisposedQueue.Count, Math.Max(minimumIncrementalCount, incrementallyDisposedQueue.Count * minimumIncrementalRate / 100));

            NUILog.Debug($"DisposeCount : {disposeCount} FullGC required : {fullCollectRequested}");

            fullCollectRequested = false;

            // Dispose item from end, due to the performance issue.
            while (disposeCount > 0 && incrementallyDisposedQueue.Count > 0)
            {
                --disposeCount;
                var disposable = incrementallyDisposedQueue.Last();
                incrementallyDisposedQueue.RemoveAt(incrementallyDisposedQueue.Count - 1);

                AppendTypeCounter(disposable.GetType().FullName);
                disposable.Dispose();
            }
            PrintAndResetTypeCounter();

            if (incrementallyDisposedQueue.Count > 0)
            {
                if (ProcessorController.Initialized && !processorRegistered)
                {
                    processorRegistered = true;
                    ProcessorController.Instance.ProcessorOnceEvent += TriggerProcessDisposables;
                    ProcessorController.Instance.Awake();
                }
            }
        }

        [Conditional("NUI_DEBUG_ON")]
        private void AppendTypeCounter(string typeName)
        {
            if (typeCounter == null)
            {
                typeCounter = new();
            }

            if (typeCounter.TryGetValue(typeName, out uint counter))
            {
                typeCounter[typeName] = ++counter;
            }
            else
            {
                typeCounter.Add(typeName, 1u);
            }
        }

        [Conditional("NUI_DEBUG_ON")]
        private void PrintAndResetTypeCounter()
        {
            foreach (var keyvalue in typeCounter)
            {
                Tizen.Log.Debug("NUI", $" --- Type [{keyvalue.Key}] dispose [{keyvalue.Value}] times");
            }
            typeCounter = null;
        }
    }
}
