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

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the service loader.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ServiceLoader : ServiceApplication
    {
        private const string AulOrgAppId = "__AUL_ORG_APPID__";
        private readonly Dictionary<string, ServiceInfo> _serviceInfos = new Dictionary<string, ServiceInfo>();
        private readonly Dictionary<string, Service> _services = new Dictionary<string, Service>();

        /// <summary>
        /// Initializes the ServiceLoader class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public ServiceLoader() {}

        /// <summary>
        /// Overrides this method if you want to handle specific behavior when the application is created.
        /// Calling base.OnCreate() ensures that the default implementation is executed before any custom code in this method.
        /// If base.OnCreate() is not called, the event 'Created' will not be emitted.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnCreate()
        {
            base.OnCreate();
            CreateServiceInfos();
        }

        /// <summary>
        /// Override this method to customize the behavior when the application receives the appcontrol message.
        /// If base.OnAppControlReceived() is not called, the event 'AppControlReceived' will not be triggered.
        /// </summary>
        /// <param name="e">The arguments passed in the appcontrol message</param>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            base.OnAppControlReceived(e);
            HandleAppControlReceivedEvent(e);
        }

        /// <summary>
        /// Override this method to define specific actions that occur when the application terminates.
        /// Calling base.OnTerminate() ensures that the default termination process takes place and the 'Terminated' event is emitted.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnTerminate()
        {
            base.OnTerminate();
        }

        /// <summary>
        /// Override this method to handle behavior when the system memory is low.
        /// Calling base.OnLowMemory() ensures that the 'LowMemory' event is emitted.
        /// </summary>
        /// <param name="e">The low memory event argument</param>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            base.OnLowMemory(e);
            SendSystemEvent(ServiceEventType.LowMemory, e);
        }

        /// <summary>
        /// Override this method to handle the behavior when the system battery level drops.
        /// If base.OnLowBattery() is not called, the LowBattery event will not be raised.
        /// </summary>
        /// <param name="e">The arguments for the low battery event</param>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            base.OnLowBattery(e);
            SendSystemEvent(ServiceEventType.LowBattery, e);
        }

        /// <summary>
        /// Override this method to handle changes in the system language.
        /// If base.OnLocaleChanged() is not called, the LocaleChanged event will not be triggered.
        /// </summary>
        /// <param name="e">The arguments passed with the LocaleChanged event</param>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
            SendSystemEvent(ServiceEventType.LocaleChanged, e);
        }

        /// <summary>
        /// Override this method to handle changes in the region format.
        /// Make sure to call base.OnRegionFormatChanged() to ensure that the RegionFormatChanged event is raised.
        /// </summary>
        /// <param name="e">The region format changed event arguments</param>
        /// <since_tizen> 13 </since_tizen>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            base.OnRegionFormatChanged(e);
            SendSystemEvent(ServiceEventType.RegionFormatChanged, e);
        }

        /// <summary>
        /// Override this method to handle changes in the service lifecycle.
        /// Make sure to call base.OnServiceLifecycleChanged() to ensure that the ServiceLifecycleChanged event is raised.
        /// </summary>
        /// <param name="e">The service lifecycle changed event arguments</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnServiceLifecycleChanged(ServiceLifecycleChangedEventArgs e)
        {
            Log.Info("Service=" + e.Service.Name + ", State=" + e.State);
        }

        private void CreateServiceInfos()
        {
            IntPtr servicePackages = Interop.Libc.GetEnviornmentVariable("SERVICE_PACKAGES");
            if (servicePackages == IntPtr.Zero)
            {
                Log.Error("Failed to get environment variable");
                return;
            }

            string packages = Marshal.PtrToStringAnsi(servicePackages);
            if (string.IsNullOrEmpty(packages))
            {
                Log.Error("There is no resource packages");
                return;
            }

            foreach (string packageId in packages.Split(':').ToList())
            {
                ServiceInfo info = ServiceInfo.Create(packageId);
                if (info != null)
                {
                    _serviceInfos.Add(info.ResourceType, info);
                }
            }
        }

        private void HandleAppControlReceivedEvent(AppControlReceivedEventArgs e)
        {
            var applicationId = e.ReceivedAppControl.ApplicationId;
            string resourceType = string.Empty;
            lock (_serviceInfos)
            {
                foreach (var info in _serviceInfos.Values)
                {
                    if (info.Id == applicationId)
                    {
                        resourceType = info.ResourceType;
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(resourceType))
            {
                Run(resourceType, e);
            }
        }

        /// <summary>
        /// Retrieves the instance of currently running Services.
        /// </summary>
        /// <returns>An enumarable list containing all the active Services.</returns>
        /// <since_tizen> 13 </since_tizen>
        public IEnumerable<Service> GetServices()
        {
            return _services.Values.ToList();
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
            return _serviceInfos.Values.ToList();
        }
        
        private void SendSystemEvent(ServiceEventType eventType, EventArgs args)
        {
            lock (_services)
            {
                foreach (var service in _services.Values)
                {
                    service.SendSystemEvent(eventType, args);
                }
            }
        }

        private void OnServiceLifecycleChangedEvent(object sender, ServiceLifecycleChangedEventArgs args)
        {
            OnServiceLifecycleChanged(args);
            if (args.State == ServiceLifecycleState.Destroyed)
            {
                lock (_services)
                {
                    args.Service.LifecycleChanged -= OnServiceLifecycleChangedEvent;
                    _services.Remove(args.Service.ServiceInfo.ResourceType);
                }
            }
        }

        private ServiceInfo Find(string resourceType)
        {
            if (!_serviceInfos.TryGetValue(resourceType, out var info))
            {
                throw new ArgumentException("Failed to find ServiceInfo. resource type=" + resourceType);
            }

            return info;
        }

        private void Load(ServiceInfo info)
        {
            if (info == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            try
            {
                lock (info)
                {
                    if (info.Assembly.IsLoaded)
                    {
                        return;
                    }

                    Log.Warn("ServiceAssembly.Load()=" + info.ResourcePath + info.DllFile + " ++");
                    info.Assembly.Load();
                    Log.Warn("ServiceAssembly.Load()=" + info.ResourcePath + info.DllFile + " --");
                }
            }
            catch (FileLoadException e)
            {
                throw new InvalidOperationException(e.Message);
            }
            catch (BadImageFormatException e)
            {
                throw new InvalidOperationException(e.Message);
            }
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
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            ServiceInfo info = Find(resourceType);
            Load(info);
        }

        private void Unload(ServiceInfo info)
        {
            if (info == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            lock (info)
            {
                if (info.Assembly.IsLoaded)
                {
                    info.Assembly.Unload();
                }
            }
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
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            ServiceInfo info = Find(resourceType);
            Unload(info);
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
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            Service service = null;
            lock (_services)
            {
                if (_services.TryGetValue(resourceType, out service))
                {
                    if (service.State != ServiceLifecycleState.Destroyed)
                    {
                        service.SendAppcOntrolReceivedEvent(args);
                        return;
                    }
                }
            }

            ServiceInfo info = Find(resourceType);
            Load(info);

            service = info.Assembly.CreateInstance(info.ClassName);
            if (service == null)
            {
                throw new InvalidOperationException("Failed to create instance. class name=" + info.ClassName);
            }

            service.ServiceInfo = info;
            service.LifecycleChanged += OnServiceLifecycleChangedEvent;

            lock (_services)
            {
                _services[resourceType] = service;
                service.Run(args);
            }          
        }

        /// <summary>
        /// Quits the main loop of the service.
        /// </summary>
        /// <param name="resourceType">The resource type of the Service package.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void Quit(string resourceType)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            Service service = null;
            lock (_services)
            {
                if (!_services.TryGetValue(resourceType, out service))
                {
                    return;
                }

                service.Quit();
            }
        }

        /// <summary>
        /// Runs the main loop of all services.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void RunAll()
        {
            lock (_serviceInfos)
            {
                foreach (var resourceType in _serviceInfos.Keys)
                {
                    Run(resourceType, null);
                }
            }
        }

        /// <summary>
        /// Quits the main loop of all running services.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void QuitAll()
        {
            lock (_services)
            {
                foreach (var service in _services.Values)
                {
                    service.Quit();
                }
            }
        }
    }
}