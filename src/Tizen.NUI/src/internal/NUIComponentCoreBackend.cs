/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.Applications.CoreBackend;
using Tizen.Applications;
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.NUI
{
    class NUIComponentCoreBackend : ICoreBackend
    {
        private Dictionary<Type, ComponentStateManger> _componentFactories;
        public Dictionary<Type, ComponentStateManger> ComponentFactories
        {
            set
            {
                _componentFactories = value;
            }
            get
            {
                return _componentFactories;
            }
        }

        /// <summary>
        /// Application instance to connect event.
        /// </summary>
        protected ComponentApplication _application;
        private string _stylesheet = "";

        /// <summary>
        /// Dictionary to contain each type of event callback.
        /// </summary>
        protected IDictionary<EventType, object> Handlers = new Dictionary<EventType, object>();

        /// <summary>
        /// Adds NUIApplication event to Application.
        /// Puts each type of event callback in Dictionary.
        /// </summary>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The event callback.</param>
        public void AddEventHandler(EventType evType, Action handler)
        {
            Handlers.Add(evType, handler);
        }

        /// <summary>
        /// Adds NUIApplication event to Application.
        /// Puts each type of event callback in Dictionary.
        /// </summary>
        /// <typeparam name="TEventArgs">The argument type for the event.</typeparam>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The event callback.</param>
        public void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs
        {
            Handlers.Add(evType, handler);
        }

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public NUIComponentCoreBackend()
        {
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIComponentCoreBackend(string stylesheet)
        {
            _stylesheet = stylesheet;
        }

        /// <summary>
        /// Dispose function.
        /// </summary>
        public void Dispose()
        {
            if (_application != null)
            {
                _application.Dispose();
            }
        }

        /// <summary>
        /// Exit Application.
        /// </summary>
        public void Exit()
        {
            if (_application != null)
            {
                _application.Quit();
            }
        }

        /// <summary>
        /// Run Application.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public void Run(string[] args)
        {
            TizenSynchronizationContext.Initialize();

            args[0] = Tizen.Applications.Application.Current.ApplicationInfo.ExecutablePath;
            _application = ComponentApplication.NewComponentApplication(args, _stylesheet);

            _application.Initialized += OnInitialized;
            _application.CreateNative += OnCreateNative;
            _application.Terminating += OnTerminated;

            _application.MainLoop();
        }


        /// <summary>
        /// Callback for Component Application CreateSignal
        /// </summary>
        private IntPtr OnCreateNative()
        {
            IntPtr nativeComponentFactoryMap = IntPtr.Zero;
            int n = 0;
            foreach (KeyValuePair<Type, ComponentStateManger> entry in _componentFactories)
            {
                nativeComponentFactoryMap = entry.Value.Bind(nativeComponentFactoryMap);
                n++;
            }
            return nativeComponentFactoryMap;
        }

        /// <summary>
        /// The Initialized event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Initialized.</param>
        private void OnInitialized(object source, NUIApplicationInitEventArgs e)
        {
            var createHandler = Handlers[EventType.Created] as Action;
            createHandler?.Invoke();
        }

        /// <summary>
        /// The Terminated event callback function.
        /// </summary>
        /// <param name="source">The application instance.</param>
        /// <param name="e">The event argument for Terminated.</param>
        private void OnTerminated(object source, NUIApplicationTerminatingEventArgs e)
        {
            var handler = Handlers[EventType.Terminated] as Action;
            handler?.Invoke();
        }

    }
}

