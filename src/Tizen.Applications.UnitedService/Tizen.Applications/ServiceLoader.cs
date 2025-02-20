/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Tizen.Core;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the service loader.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ServiceLoader : ServiceApplication
    {
        /// <summary>
        /// Initializes the ServiceLoader class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public ServiceLoader()
        {
            Log.Debug("ServiceLoader");
        }

        /// <summary>
        /// Overrides this method if you want to handle specific behavior when the application is created.
        /// Calling base.OnCreate() ensures that the default implementation is executed before any custom code in this method.
        /// If base.OnCreate() is not called, the event 'Created' will not be emitted.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnCreate()
        {
            Log.Debug("OnCreate");
            base.OnCreate();
            ServiceManager.Initialize();
            ServiceManager.ServiceLifecycleChanged += OnServiceLifecycleChangedEvent;
        }

        /// <summary>
        /// Override this method to define specific actions that occur when the application terminates.
        /// Calling base.OnTerminate() ensures that the default termination process takes place and the 'Terminated' event is emitted.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnTerminate()
        {
            Log.Debug("OnTerminate");
            base.OnTerminate();
            ServiceManager.ServiceLifecycleChanged -= OnServiceLifecycleChangedEvent;
            ServiceManager.Shutdown();
        }

        /// <summary>
        /// Override this method to handle changes in the service lifecycle.
        /// Make sure to call base.OnServiceLifecycleChanged() to ensure that the ServiceLifecycleChanged event is raised.
        /// </summary>
        /// <param name="e">The service lifecycle changed event arguments</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnServiceLifecycleChanged(ServiceLifecycleChangedEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            Log.Info("Service=" + e.Service.Name + ", State=" + e.State);
        }

        /// <summary>
        /// Retrieves the instance of currently running Services.
        /// </summary>
        /// <returns>An enumarable list containing all the active Services.</returns>
        /// <since_tizen> 13 </since_tizen>
        public IEnumerable<Service> GetServices()
        {
            return ServiceManager.GetServices();
        }

        /// <summary>
        /// Retrieves the information about available Services.
        /// </summary>
        /// <remarks>
        /// This method provides details on services that are currently accessible rather than listing all installed services.
        /// A NUIGadget's resource package may specify which applications have access through the "allowed-packages" setting.
        /// During execution, the platform mounts the resource package in the application's resources directory.
        /// </remarks>
        /// <returns>An enumerable list of ServiceInfo objects.</returns>
        /// <since_tizen> 13 </since_tizen>
        public IEnumerable<ServiceInfo> GetServiceInfos()
        {
            return ServiceManager.GetServiceInfos();
        }
        
        private void OnServiceLifecycleChangedEvent(object sender, ServiceLifecycleChangedEventArgs args)
        {
            OnServiceLifecycleChanged(args);
        }

        /// <summary>
        /// Loads an assembly of the Service.
        /// </summary>
        /// <param name="resourceType">The resource type of the Service package.</param>
        /// <remarks>
        /// This method loads an assembly of the Service based on the specified resource type.
        /// It throws an ArgumentException if the argument is invalid, or an InvalidOperationException if the operation fails due to any reason.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void Load(string resourceType)
        {
            ServiceManager.Load(resourceType);
        }

        /// <summary>
        /// Unloads the specified Service assembly from memory.
        /// </summary>
        /// <remarks>
        /// To use this method properly, the assembly of the gadget must be loaded using Load() with the custom context.
        /// </remarks>
        /// <param name="resourceType">The resource type of the Service package to unload.</param>
        /// <exception cref="ArgumentException">Thrown when the argument passed is not valid.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void Unload(string resourceType)
        {
            ServiceManager.Unload(resourceType);
        }

        /// <summary>
        /// Runs the main loop of the service.
        /// </summary>
        /// <remarks>
        /// If the service is already running, this method sends the args to the running service.
        /// </remarks>
        /// <param name="resourceType">The resource type of the Service package.</param>
        /// <param name="args">The arguments passed in the appcontrol message.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void Run(string resourceType, AppControlReceivedEventArgs args)
        {
            ServiceManager.Run(resourceType, args);
        }

        /// <summary>
        /// Quits the main loop of the service.
        /// </summary>
        /// <param name="resourceType">The resource type of the Service package.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void Quit(string resourceType)
        {
            ServiceManager.Quit(resourceType);
        }

        /// <summary>
        /// Runs the main loop of all services.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void RunAll()
        {
            ServiceManager.RunAll();
        }

        /// <summary>
        /// Quits the main loop of all running services.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void QuitAll()
        {
            ServiceManager.QuitAll();
        }
    }
}