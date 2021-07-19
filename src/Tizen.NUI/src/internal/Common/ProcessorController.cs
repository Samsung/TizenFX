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

using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
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
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void ProcessorCallback();

        private ProcessorCallback callback = null;

        public event EventHandler ProcessorOnceEvent;

        public event EventHandler ProcessorEvent;

        public event EventHandler LayoutProcessorEvent;

        private ProcessorController() : this(Interop.ProcessorController.New(), true)
        {
        }

        internal ProcessorController(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            callback = new ProcessorCallback(Process);
            Interop.ProcessorController.SetCallback(SwigCPtr, callback);
        }

        private static ProcessorController instance = null;

        public static ProcessorController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ProcessorController();
                }
                return instance;
            }
        }

        public void Process()
        {
            ProcessorOnceEvent?.Invoke(this, null);
            ProcessorOnceEvent = null;
            ProcessorEvent?.Invoke(this, null);
            LayoutProcessorEvent?.Invoke(this, null);
        }

        /// <summary>
        /// Dispose ProcessorController.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            Interop.ProcessorController.RemoveCallback(SwigCPtr, callback);
            ProcessorOnceEvent = null;
            ProcessorEvent = null;
            LayoutProcessorEvent = null;
            GC.SuppressFinalize(this);

            base.Dispose(type);
        }
    } // class ProcessorController
} // namespace Tizen.NUI
