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
    /// Represents the base class for a multi-component based application.
    /// This class allows the creation and management of multiple application components, such as Frame, Service, and Widget components.
    /// </summary>
    /// <remarks>
    /// This abstract class provides the core structure for applications that consist of multiple components.
    /// Each component has its own lifecycle, and the framework handles these lifecycles independently.
    /// </remarks>
    /// <since_tizen> 6 </since_tizen>
    public abstract class ComponentBasedApplication : Application
    {
        private const string LogTag = "Tizen.Applications";
        private Dictionary<Type, ComponentStateManger> _componentFactories = new Dictionary<Type, ComponentStateManger>();
        private Interop.CBApplication.CBAppLifecycleCallbacks _callbacks;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentBasedApplication"/> class with the specified component type information.
        /// </summary>
        /// <param name="typeInfo">A dictionary where the key is the component class type (FrameComponent, ServiceComponent or WidgetComponent subclass),
        /// and the value is the component ID defined in the tizen-manifest.xml file.</param>
        /// <remarks>
        /// This constructor sets up the necessary callbacks for the application lifecycle and registers the provided components.
        /// </remarks>
        /// <example>
        /// <code>
        /// IDictionary&lt;Type, string&gt; components = new Dictionary&lt;Type, string&gt;()
        /// {
        ///     { typeof(MyFrameComponent), "frameComponentId" },
        ///     { typeof(MyServiceComponent), "serviceComponentId" }
        /// };
        /// ComponentBasedApplication app = new MyApplication(components);
        /// app.Run(args);
        /// </code>
        /// </example>
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
        /// Registers a component with the specified type and ID.
        /// </summary>
        /// <param name="compType">The type of the component to register. Must be a subclass of FrameComponent, ServiceComponent, or WidgetComponent.</param>
        /// <param name="compId">The ID of the component, defined in the tizen-manifest.xml file.</param>
        /// <exception cref="ArgumentException">Thrown when the component type is already registered or not sub-class of FrameComponent, ServiceComponent or WidgetComponent.</exception>
        /// <remarks>
        /// This method ensures that only valid component types are registered. The component ID must be unique.
        /// </remarks>
        /// <example>
        /// <code>
        /// app.RegisterComponent(typeof(MyFrameComponent), "frameComponentId");
        /// </code>
        /// </example>
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
        /// <param name="args">The arguments passed from the command line.</param>
        /// <exception cref="InvalidOperationException">Thrown when component type is already added to the component.</exception>
        /// <example>
        /// <code>
        /// app.Run(args);
        /// </code>
        /// </example>
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
        /// Exits the application's main loop.
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
        /// Called before the main loop starts.
        /// </summary>
        /// <param name="args">The arguments passed from the command line.</param>
        /// <remarks>
        /// Override this method to handle any initialization logic before the application enters the main event loop.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnInit(string[] args)
        {
        }

        /// <summary>
        /// Called after the main loop exits.
        /// </summary>
        /// <remarks>
        /// Override this method to handle any cleanup logic after the application has finished running.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFinished()
        {
        }

        /// <summary>
        /// Called to start the main loop of the application.
        /// </summary>
        /// <remarks>
        /// This is an abstract method that must be implemented by derived classes to define the behavior when the application starts.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        protected abstract void OnRun();

        /// <summary>
        /// Called to exit the main loop of the application.
        /// </summary>
        /// <remarks>
        /// Override this method to handle any logic needed before the application exits.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnExit()
        {
        }
    }
}
