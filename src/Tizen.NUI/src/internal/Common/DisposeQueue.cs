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
using System.Linq;

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

        private bool initialized = false;
        private bool processorRegistered = false;
        private bool eventThreadCallbackTriggered = false;

        private bool incrementalDisposeSupported = false;
        private bool fullCollectRequested = false;

        private DisposeQueue()
        {
        }

        ~DisposeQueue()
        {
            Tizen.Log.Debug("NUI", $"DisposeQueue is destroyed\n");
            initialized = false;
            if (processorRegistered && ProcessorController.Instance.Initialized)
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

                DebugFileLogging.Instance.WriteLog("DiposeTest START");
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
                ProcessDisposables();
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
                ProcessDisposables();
            }
        }

        public void ProcessDisposables()
        {
            eventThreadCallbackTriggered = false;

            lock (listLock)
            {
                if (disposables.Count > 0)
                {
                    DebugFileLogging.Instance.WriteLog($"Newly add {disposables.Count} count of disposables. Total disposables count is {incrementallyDisposedQueue.Count + disposables.Count}.\n");
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
                    (!fullCollectRequested && !ProcessorController.Instance.Initialized))
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

            DebugFileLogging.Instance.WriteLog((fullCollectRequested ? "Fully" : "Incrementally") + $" dispose {disposeCount} disposables. Will remained disposables count is {incrementallyDisposedQueue.Count - disposeCount}.\n");

            fullCollectRequested = false;

            // Dispose item from end, due to the performance issue.
            while (disposeCount > 0 && incrementallyDisposedQueue.Count > 0)
            {
                --disposeCount;
                var disposable = incrementallyDisposedQueue.Last();
                incrementallyDisposedQueue.RemoveAt(incrementallyDisposedQueue.Count - 1);

                DebugFileLogging.Instance.WriteLog($"disposable.Dispose(); type={disposable.GetType().FullName}, hash={disposable.GetHashCode()}");
                disposable.Dispose();
            }

            if (incrementallyDisposedQueue.Count > 0)
            {
                if (ProcessorController.Instance.Initialized && !processorRegistered)
                {
                    processorRegistered = true;
                    ProcessorController.Instance.ProcessorOnceEvent += TriggerProcessDisposables;
                    ProcessorController.Instance.Awake();
                }
            }

            DebugFileLogging.Instance.WriteLog($"Incrementally dispose finished.\n");
        }
    }
}
