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
    public class ComponentBasedApplicationBase : Application
    {
        private const string LogTag = "Tizen.Applications.ComponentBasedApplicationBase";
        private IList<ComponentFactoryBase> _componentFactories = new List<ComponentFactoryBase>();
        private Interop.CBApplication.CBAppLifecycleCallbacks _callbacks;
        private bool _disposedValue = false;

        /// <summary>
        /// Initializes the ComponentBasedApplicationBase class.
        /// </summary>
        /// <param name="typeInfo">The component type information.
        /// The key should be a class type of BaseComponent subclass.
        /// The value should be a component id which is declared in tizen-manifest.xml.
        /// </param>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <since_tizen> 6 </since_tizen>
        public ComponentBasedApplicationBase(IDictionary<Type, string> typeInfo)
        {
            _callbacks.OnInit = new Interop.CBApplication.CBAppInitCallback(OnInitNative);
            _callbacks.OnFini = new Interop.CBApplication.CBAppFiniCallback(OnFiniNative);
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
        /// <exception cref="InvalidOperationException">Thrown when component type is already added.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void RegisterComponent(Type compType, string compId)
        {
            foreach (ComponentFactoryBase factory in _componentFactories)
            {
                if (compType.BaseType == factory._classType)
                    throw new InvalidOperationException("Already exist type");
            }

            if (typeof(BaseComponent).IsAssignableFrom(compType))
            {
                Log.Info(LogTag, "Add base comp");
                BaseComponent b = Activator.CreateInstance(compType) as BaseComponent;
                _componentFactories.Add(new BaseFactory(compType, compId, b.ComponentType, this));
            }
            else if (typeof(FrameComponent).IsAssignableFrom(compType))
            {
                Log.Info(LogTag, "Add frame comp");
                _componentFactories.Add(new FrameFactory(compType, compId, this));
            }
            else if (typeof(ServiceComponent).IsAssignableFrom(compType))
            {
                Log.Info(LogTag, "Add service comp");
                _componentFactories.Add(new ServiceFactory(compType, compId, this));
            }
        }

        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
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
            IntPtr h = IntPtr.Zero;
            foreach (ComponentFactoryBase factory in _componentFactories)
            {
                h = factory.Bind(h);
            }

            return h;
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

        private void OnFiniNative(IntPtr data)
        {
            OnFini();
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
        protected virtual void OnFini()
        {
        }

        /// <summary>
        /// This method will be called to start main-loop
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnRun()
        {
        }

        /// <summary>
        /// This method will be called to exit main-loop
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnExit()
        {
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _disposedValue = true;
            }
            base.Dispose(disposing);
        }
    }
}
