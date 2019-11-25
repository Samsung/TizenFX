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
using Tizen.Applications;
using Tizen.Applications.ComponentBased;
using Tizen.Applications.ComponentBased.Common;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    /// <summary>
    /// The class for supporting multi-components based application model.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class NUIComponentBasedApplication : CoreApplication
    {

        private Dictionary<Type, ComponentStateManger> _componentFactories = new Dictionary<Type, ComponentStateManger>();
        /// <summary>
        /// Initializes the ComponentBasedApplicationBase class.
        /// </summary>
        /// <param name="typeInfo">The component type information.
        /// The key should be a class type of FrameComponent or SubComponent subclass.
        /// The value should be a component id which is declared in tizen-manifest.xml.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public NUIComponentBasedApplication(IDictionary<Type, string> typeInfo) : base(new NUIComponentBasedCoreBackend())
        {
            foreach (var component in typeInfo)
            {
                RegisterComponent(component.Key, component.Value);
            }
            (Backend as NUIComponentBasedCoreBackend).ComponentFactories = _componentFactories;
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

            if (typeof(FrameComponent).IsAssignableFrom(compType))
            {
                _componentFactories.Add(compType, new FrameComponentStateManager(compType, compId, null));
            }
            else if (typeof(ServiceComponent).IsAssignableFrom(compType))
            {
                _componentFactories.Add(compType, new ServiceComponentStateManager(compType, compId, null));
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
            //Register Callback.
            base.Run(args);
        }

        /// <summary>
        /// Exits the main loop of the application.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override void Exit()
        {
            base.Exit();
        }

        /// <summary>
        /// This method will be called before running main-loop
        /// </summary>
        /// <param name="args"></param>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnCreate()
        {
            base.OnCreate();
        }

        /// <summary>
        /// This method will be called after exiting main-loop
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnTerminate()
        {
            base.OnTerminate();
        }
    }
}

