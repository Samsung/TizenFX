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

namespace Tizen.Applications
{
    /// <summary>
    /// DataLoader performs tasks
    /// that the Gadget processes in parallel
    /// during the PreCreate state.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class DataLoader : IDisposable
    {
        /// <summary>
        /// Initializes the DataLoader.
        /// </summary>
        /// <param name="name">Unique identifier for the loader instance</param>
        /// <param name="autoClose">Whether to automatically close the loader after execution</param>
        /// <since_tizen> 13 </since_tizen>
        public DataLoader(string name, bool autoClose)
        {
            Name = name;
            AutoClose = autoClose;
            State = DataLoaderLifecycleState.Initialized;
            TizenCore.Initialize();
        }

        /// <summary>
        /// Finalizer of the DataLoader class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        ~DataLoader()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the current lifecycle state of DataLoader
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public DataLoaderLifecycleState State
        {
            get;
            internal set;
        }

        /// <summary>
        /// The name of the loader
        /// </summary>
        /// <remarks>
        /// This property is the name(identifier)
        /// of the worker thread on which
        /// `DataLoader` operates.
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

        internal event EventHandler<DataLoaderLifecycleChangedEventArgs> LifecycleStateChanged;

        private void Create()
        {
            if (State == DataLoaderLifecycleState.Initialized)
            {
                OnCreate();
                State = DataLoaderLifecycleState.Running;
                NotifyLifecycleChanged(DataLoaderLifecycleState.Running);
            }
        }

        private void Destroy()
        {
            if (State != DataLoaderLifecycleState.Destroyed)
            {
                OnDestroy();
            }
        }

        /// <summary>
        /// Override this method to define the behavior when the DataLoader is created.
        /// Calling 'base.OnCreate()' is necessary in order to
        /// emit the 'DataLoaderLifecycleState.Created` state
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnCreate()
        {
            Log.Info("[OnCreate]");
            State = DataLoaderLifecycleState.Created;
            NotifyLifecycleChanged(DataLoaderLifecycleState.Created);
        }

        /// <summary>
        /// Override this method to define the behavior when the DataLoader is destroyed.
        /// Calling 'base.OnDestroyed()' is necessary in order to
        /// emit the 'DataLoaderServiceLifecycleState.Destroyed` state
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnDestroy()
        {
            Log.Info("[OnDestroy]");
            State = DataLoaderLifecycleState.Destroyed;
            NotifyLifecycleChanged(DataLoaderLifecycleState.Destroyed);
        }

        /// <summary>
        /// Starts the DataLoader execution on a worker thread.
        /// Initializes the loader task and triggers the OnCreate event.
        /// If AutoClose is enabled, automatically destroys the loader after execution.
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

            if (State == DataLoaderLifecycleState.Initialized)
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
        /// Stops the DataLoader execution and releases resources.
        /// </summary>
        /// <param name="waitForJoin">Whether to wait for complete service termination</param>
        /// <since_tizen> 13 </since_tizen>
        public void Quit(bool waitForJoin)
        {
            Log.Warn($"Name = {Name}");
            if (_task == null)
            {
                Log.Info($"{Name} was already destroyed");
                return;
            }

            if (State == DataLoaderLifecycleState.Destroyed)
            {
                if (waitForJoin)
                {
                    _task.Dispose();
                }
                return;
            }

            _task.Post(() =>
            {
                Destroy();
                _task.Quit();
            });

            if (waitForJoin)
            {
                _task.Dispose();
            }
        }

        private void NotifyLifecycleChanged(DataLoaderLifecycleState state)
        {
            CoreApplication.Post(() =>
            {
                var args = new DataLoaderLifecycleChangedEventArgs
                {
                    State = state,
                    DataLoader = this
                };
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
                        _task = null;
                        TizenCore.Shutdown();
                    }
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the DataLoader class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
