/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for supporting multi-components based application model.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class ComponentBasedApplication : Application
    {
        private const string LogTag = "Tizen.Applications";
        private Dictionary<Type, ComponentStateManger> _componentFactories = new Dictionary<Type, ComponentStateManger>();
        private Interop.CBApplication.CBAppLifecycleCallbacks _callbacks;

        /// <summary>
        /// Initializes the ComponentBasedApplicationBase class.
        /// </summary>
        /// <param name="typeInfo">The component type information.
        /// The key should be a class type of FrameComponent or SubComponent subclass.
        /// The value should be a component id which is declared in tizen-manifest.xml.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public ComponentBasedApplication(IDictionary<Type, string> typeInfo)
        {
            _callbacks.OnInit = new Interop.CBApplication.CBAppInitCallback(OnInitNative);
            _callbacks.OnFinished = new Interop.CBApplication.CBAppFiniCallback(OnFinishedNative);
            _callbacks.OnRun = new Interop.CBApplication.CBAppRunCallback(OnRunNative);
            _callbacks.OnExit = new Interop.CBApplication.CBAppExitCallback(OnExitNative);
            _callbacks.OnCreate = new Interop.CBApplication.CBAppCreateCallback(OnCreateNative);
            _callbacks.OnTerminate = new Interop.CBApplication.CBAppTerminateCallback(OnTerminateNative);

            foreach (var component in typeInfo)
            {
                RegisterComponent(component.Key, component.Value);
            }
        }

        /// <summary>
        /// Registers a component.
        /// </summary>
        /// <param name="compType">Class type</param>
        /// <param name="compId">Component ID</param>
        /// <exception cref="ArgumentException">Thrown when component type is already added or not sub-class of FrameComponent or ServiceComponent</exception>
        /// <since_tizen> 6 </since_tizen>
        public void RegisterComponent(Type compType, string compId)
        {
            if (_componentFactories.ContainsKey(compType))
            {
                throw new ArgumentException("Already exist type");
            }

            foreach (var stateManager in _componentFactories)
            {
                if (stateManager.Value.ComponentId == compId)
                {
                    throw new ArgumentException("Already exist component ID(" + compId + ")");
                }
            }

            if (typeof(FrameComponent).IsAssignableFrom(compType))
            {
                Log.Info(LogTag, "Add frame component");
                _componentFactories.Add(compType, new FrameComponentStateManager(compType, compId, this));
            }
            else if (typeof(ServiceComponent).IsAssignableFrom(compType))
            {
                Log.Info(LogTag, "Add service component");
                _componentFactories.Add(compType, new ServiceComponentStateManager(compType, compId, this));
            }
            else if (typeof(WidgetComponent).IsAssignableFrom(compType))
            {
                Log.Info(LogTag, "Add widget component");
                _componentFactories.Add(compType, new WidgetComponentStateManager(compType, compId, this));
            }
            else
            {
                throw new ArgumentException("compType must be sub type of FrameComponent or ServiceComponent", "compType");
            }
        }

        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <exception cref="InvalidOperationException">Thrown when component type is already added to the component.</exception>
        /// <since_tizen> 6 </since_tizen>
        public override void Run(string[] args)
        {
            base.Run(args);

            string[] argsClone = new string[args.Length + 1];
            if (args.Length > 1)
            {
                args.CopyTo(argsClone, 1);
            }
            argsClone[0] = string.Empty;

            Interop.CBApplication.ErrorCode err = Interop.CBApplication.BaseMain(argsClone.Length, argsClone, ref _callbacks, IntPtr.Zero);
            if (err != Interop.CBApplication.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to run the application. Err = " + err);
                throw new InvalidOperationException("Fail to run application : err(" + err + ")");
            }
        }

        /// <summary>
        /// Exits the main loop of the application.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override void Exit()
        {
            Interop.CBApplication.BaseExit();
        }

        private IntPtr OnCreateNative(IntPtr data)
        {
            Log.Debug(LogTag, "On create");
            IntPtr nativeComponentFactoryMap = IntPtr.Zero;
            foreach (KeyValuePair<Type, ComponentStateManger> entry in _componentFactories)
            {
                nativeComponentFactoryMap = entry.Value.Bind(nativeComponentFactoryMap);
            }

            return nativeComponentFactoryMap;
        }

        private void OnTerminateNative(IntPtr data)
        {
        }

        private void OnRunNative(IntPtr data)
        {
            OnRun();
        }

        private void OnExitNative(IntPtr data)
        {
            OnExit();
        }

        private void OnInitNative(int argc, string[] argv, IntPtr userData)
        {
            OnInit(argv);
        }

        private void OnFinishedNative(IntPtr data)
        {
            OnFinished();
        }

        /// <summary>
        /// This method will be called before running main-loop
        /// </summary>
        /// <param name="args"></param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnInit(string[] args)
        {
        }

        /// <summary>
        /// This method will be called after exiting main-loop
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFinished()
        {
        }

        /// <summary>
        /// This method will be called to start main-loop
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected abstract void OnRun();

        /// <summary>
        /// This method will be called to exit main-loop
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnExit()
        {
        }
    }
}
