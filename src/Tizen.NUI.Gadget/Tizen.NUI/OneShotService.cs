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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tizen.Core;
using Tizen.NUI.Gadget.Tizen.NUI;

namespace Tizen.NUI
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class OneShotService
    {

        public OneShotServiceLifecycleState State
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            internal set;
        }

        public bool AutoClose{
            get;
            private set;
        }

        private Task _task;

        public event EventHandler<OneShotServiceLifecycleChangedEventArgs> LifecycleStateChanged;

        public OneShotService(string name,bool autoClose)
        {
            Name = name;
            AutoClose = autoClose;
            State = OneShotServiceLifecycleState.Initialized;
        }

        protected virtual void OnCreate()
        {
            Log.Info("[OnCreate]");
            if (State == OneShotServiceLifecycleState.Initialized)
            {
                State = OneShotServiceLifecycleState.Created;
                NotifyLifecycleChanged();
            }
        }

        protected virtual void OnDestroy()
        {
            Log.Info("[OnDestroy]");
            if (State == OneShotServiceLifecycleState.Created)
            {
                State = OneShotServiceLifecycleState.Destroyed;
                NotifyLifecycleChanged();
            }
        }

        public void Run()
        {
            Log.Warn($"Name = {Name}");
            if(_task != null && _task.Running)
            {
                Log.Info($"{Name} is already running");
                return;
            }

            _task = TizenCore.Spawn(Name);
            _task.Post(() => { OnCreate(); });

            if (AutoClose)
            {
                _task.Post(() => { OnDestroy(); });
                _task.Quit();
            }
        }

        public void Quit(bool waitForJoin)
        {
            Log.Warn($"Name = {Name}");
            if(_task == null || State == OneShotServiceLifecycleState.Destroyed)
            {
                Log.Info($"{Name} was already destroyed");
                return;
            }

            _task.Post(() => { OnDestroy(); });
            _task.Quit();
            if (waitForJoin)
            {
                _task.Dispose();
                _task = null;
            }
        }

        private void NotifyLifecycleChanged()
        {
            var args = new OneShotServiceLifecycleChangedEventArgs();
            args.State = State;
            args.OneShotService = this;
            LifecycleStateChanged?.Invoke(this, args);
        }
    }
}
