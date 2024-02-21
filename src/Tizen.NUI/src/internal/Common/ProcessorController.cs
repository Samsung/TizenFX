/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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

using System.Runtime.InteropServices;
using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Singleton class.
    /// ProcessorController handles ProcessorCallbacks those are requested to be called for each end of event process.
    /// If there are works those required to be called after all of the event process for the efficiency, add them ProcessorController.
    /// The calling order is not guaranteed but ProcessorCallbackes of LayoutController those are added by using AddLayoutControllerProcessor,
    /// are called after ordinaly ProcessCallbacks added by AddProcessor.
    ///
    /// The added callbacks will be called every time of event tick.
    /// If the callback is not be wanted to be called anymore, remove it.
    /// </summary>
    internal sealed class ProcessorController : Disposable
    {
        private static ProcessorController instance = null;
        private bool initialized = false;

        private ProcessorController() : this(true)
        {
        }

        private ProcessorController(bool initializeOnConstructor) : this(Interop.ProcessorController.NewWithoutInitialize(), true)
        {
            if (initializeOnConstructor)
            {
                Initialize();
            }
        }

        internal ProcessorController(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ProcessorEventHandler();

        private ProcessorEventHandler processorCallback = null;

        private uint onceEventIndex;
        // Double buffered once event processing
        private WeakEvent<EventHandler>[] internalProcessorOnceEvent;

        public event EventHandler ProcessorOnceEvent
        {
            add
            {
                if(internalProcessorOnceEvent[onceEventIndex] == null)
                {
                    internalProcessorOnceEvent[onceEventIndex] = new WeakEvent<EventHandler>();
                }
                internalProcessorOnceEvent[onceEventIndex].Add(value);
            }
            remove
            {
                if(internalProcessorOnceEvent[onceEventIndex] != null)
                {
                    internalProcessorOnceEvent[onceEventIndex].Remove(value);
                }
            }
        }
        public event EventHandler ProcessorEvent;
        public event EventHandler LayoutProcessorEvent;

        public bool Initialized => initialized;

        public static ProcessorController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProcessorController(false);
                }
                return instance;
            }
        }

        public void Initialize()
        {
            if (initialized == false)
            {
                initialized = true;

                Interop.ProcessorController.Initialize(SwigCPtr);

                onceEventIndex = 0u;
                internalProcessorOnceEvent = new WeakEvent<EventHandler>[2];
                internalProcessorOnceEvent[0] = null;
                internalProcessorOnceEvent[1] = null;

                processorCallback = new ProcessorEventHandler(Process);
                Interop.ProcessorController.SetCallback(SwigCPtr, processorCallback);
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
        }

        public void Process()
        {
            // Let us add once event into 1 index during 0 event invoke
            onceEventIndex = 1;
            internalProcessorOnceEvent[0]?.Invoke(this, null);
            internalProcessorOnceEvent[0] = null;

            ProcessorEvent?.Invoke(this, null);
            LayoutProcessorEvent?.Invoke(this, null);

            // Let us add once event into 0 index during 1 event invoke
            // Note : To avoid ImageView's properties mismatched problem,
            // We need to invoke events now which attached during internalProcessorOnceEvent[0] and LayoutProcessor.
            onceEventIndex = 0;
            internalProcessorOnceEvent[1]?.Invoke(this, null);
            internalProcessorOnceEvent[1] = null;
        }

        /// <summary>
        /// Dispose ProcessorController.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            Interop.ProcessorController.RemoveCallback(SwigCPtr, processorCallback);
            internalProcessorOnceEvent[0] = null;
            internalProcessorOnceEvent[1] = null;
            ProcessorEvent = null;
            LayoutProcessorEvent = null;
            initialized = false;

            GC.SuppressFinalize(this);

            base.Dispose(type);
        }

        /// <summary>
        /// Awake ProcessorController.
        /// It will call ProcessController.processorCallback and ProcessController.processorPostCallback hardly.
        /// </summary>
        /// <note>
        /// When event thread is not in idle state, This function will be ignored.
        /// </note>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Awake()
        {
            Interop.ProcessorController.Awake(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }
    } // class ProcessorController
} // namespace Tizen.NUI
