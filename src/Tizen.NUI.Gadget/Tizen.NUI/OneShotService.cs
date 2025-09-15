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
using System.ComponentModel;
using Tizen.Applications;
using Tizen.Core;

namespace Tizen.NUI
{
    /// <summary>
    /// OneShotService performs tasks
    /// that the NUIGadget processes in parallel
    /// during the PreCreate state.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class OneShotService : IDisposable
    {
        /// <summary>
        /// Initializes the OneShotService.
        /// </summary>
        /// <param name="name">Unique identifier for the service instance</param>
        /// <param name="autoClose">Whether to automatically close the service after execution</param>
        /// <since_tizen> 13 </since_tizen>
        public OneShotService(string name, bool autoClose)
        {
            Name = name;
            AutoClose = autoClose;
            State = OneShotServiceLifecycleState.Initialized;
            NotifyLifecycleChanged();
            TizenCore.Initialize();
        }

        /// <summary>
        /// Finalizer of the OneShotService  class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        ~OneShotService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the current lifecycle state of OneShotService
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public OneShotServiceLifecycleState State
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the OneShotService's name
        /// </summary>
        /// <remarks>
        /// This property is the name(identifier)
        /// of the worker thread on which
        /// `OneShotService` operates.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public string Name
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the AutoClose
        /// </summary>
        /// <remarks>
        /// This property is a variable
        /// as to whether to automatically make
        /// OneShotService Destroy after execution
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public bool AutoClose
        {
            get;
            private set;
        }

        private Task _task;

        /// <summary>
        /// Occurs when the lifecycle of the OneShotService is changed.
        /// </summary>
        /// <remarks>
        /// This event is raised when the state of OneShotService changes.
        /// It provides information about the current state through the 
        /// OneShotServiceLifecycleChangedEventArgs argument.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public event EventHandler<OneShotServiceLifecycleChangedEventArgs> LifecycleStateChanged;

        private void Create()
        {
            if (State == OneShotServiceLifecycleState.Initialized)
            {
                OnCreate();
                State = OneShotServiceLifecycleState.Running;
                NotifyLifecycleChanged();
            }
        }

        private void Destroy()
        {
            if (State != OneShotServiceLifecycleState.Destroyed)
            {
                OnDestroy();
            }
        }

        /// <summary>
        /// Override this method to define the behavior when the OneShotService is created.
        /// Calling 'base.OnCreate()' is necessary in order to
        /// emit the 'OneShotServiceLifecycleState.Created` state
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnCreate()
        {
            Log.Info("[OnCreate]");
            State = OneShotServiceLifecycleState.Created;
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Override this method to define the behavior when the OneShotService is destroyed.
        /// Calling 'base.OnDestroyed()' is necessary in order to
        /// emit the 'OneShotServiceLifecycleState.Destroyed` state
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnDestroy()
        {
            Log.Info("[OnDestroy]");
            State = OneShotServiceLifecycleState.Destroyed;
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Starts the OneShotService execution on a worker thread.
        /// Initializes the service task and triggers the OnCreate event.
        /// If AutoClose is enabled, automatically destroys the service after execution.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void Run()
        {
            Log.Warn($"Name = {Name}");
            if (_task != null && _task.Running)
            {
                Log.Info($"{Name} is already running");
                return;
            }

            if (State == OneShotServiceLifecycleState.Initialized)
            {
                _task = TizenCore.Spawn(Name);
                _task.Post(() =>
                {
                    Create();
                });

                if (AutoClose)
                {
                    _task.Post(() =>
                    {
                        Destroy();
                        _task.Quit();
                    });
                }
            }
        }

        /// <summary>
        /// Stops the OneShotService execution and releases resources.
        /// </summary>
        /// <param name="waitForJoin">Whether to wait for complete service termination</param>
        /// <since_tizen> 13 </since_tizen>
        public void Quit(bool waitForJoin)
        {
            Log.Warn($"Name = {Name}");
            if (_task == null || State == OneShotServiceLifecycleState.Destroyed)
            {
                Log.Info($"{Name} was already destroyed");
                return;
            }

            _task.Post(() =>
            {
                Destroy();
                _task.Quit();
            });

            if (waitForJoin && _task != null)
            {
                _task.Dispose();
                _task = null;
            }
        }

        private void NotifyLifecycleChanged()
        {
            CoreApplication.Post(() =>
            {
                var args = new OneShotServiceLifecycleChangedEventArgs();
                args.State = State;
                args.OneShotService = this;
                LifecycleStateChanged?.Invoke(this, args);
            });
        }

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        private bool _disposedValue = false;

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">if true, dispose any disposable objets. If false, does not dispose disposable objects</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_task != null)
                    {
                        _task.Dispose();
                        TizenCore.Shutdown();
                    }
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the OneShotService class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
