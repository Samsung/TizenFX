/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.Core;
using System.Collections.Concurrent;

namespace Tizen.Applications
{
    /// <summary>
    /// The ServiceManager provides methods and events related to managing services in the application.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ServiceManager
    {
        private static readonly ConcurrentDictionary<string, ServiceInfo> _serviceInfos = new ConcurrentDictionary<string, ServiceInfo>();
        private static readonly ConcurrentDictionary<string, Service> _services = new ConcurrentDictionary<string, Service>();

        static ServiceManager()
        {
        }

        /// <summary>
        /// Initializes the Service Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public static void Initialize()
        {
            TizenCore.Initialize();
            CreateServiceInfos();

            var context = (CoreApplication)CoreApplication.Current;
            context.AppControlReceived += OnAppControlReceived;
            context.LowMemory += OnLowMemory;
            context.LowBattery += OnLowBattery;
            context.LocaleChanged += OnLocaleChanged;
            context.RegionFormatChanged += OnRegionFormatChanged;
        }

        /// <summary>
        /// Shuts down the Service Manager.
        /// </summary>
        /// <since_tize> 13 </since_tize>
        public static void Shutdown()
        {
            QuitAll();
            _serviceInfos.Clear();
            _services.Clear();
            TizenCore.Shutdown();
        }

        private static void CreateServiceInfos()
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
                    _serviceInfos[info.ResourceType] = info;
                }
            }
        }

        private static void OnAppControlReceived(object sender, AppControlReceivedEventArgs args)
        {
            Log.Debug("OnAppControlReceived");
            HandleAppControlReceivedEvent(args);
        }

        private static void OnLowMemory(object sender, LowMemoryEventArgs args)
        {
            SendSystemEvent(ServiceEventType.LowMemory, args);
        }

        private static void OnLowBattery(object sender, LowBatteryEventArgs args)
        {
            SendSystemEvent(ServiceEventType.LowBattery, args);
        }

        private static void OnLocaleChanged(object sender, LocaleChangedEventArgs args)
        {
            SendSystemEvent(ServiceEventType.LocaleChanged, args);
        }

        private static void OnRegionFormatChanged(object sender, RegionFormatChangedEventArgs args)
        {
            SendSystemEvent(ServiceEventType.RegionFormatChanged, args);
        }

        /// <summary>
        /// Occurs when the lifecycle of the Service is changed.
        /// </summary>
        /// <remarks>
        /// This event is raised when the state of the Service changes.
        /// It provides information about the current state through the ServiceLifecycleChangedEventArgs argument.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public static event EventHandler<ServiceLifecycleChangedEventArgs> ServiceLifecycleChanged;

        private static string GetCommand(ReceivedAppControl receivedAppControl)
        {
            string command = string.Empty;
            try
            {
                command = receivedAppControl.ExtraData.Get<string>("__K_SERVICE_COMMAND");
            }
            catch (ArgumentNullException e)
            {
                Log.Warn("ArgumentNullException=" + e.Message); ;
            }
            catch (KeyNotFoundException e)
            {
                Log.Warn("KeyNotFoundException=" + e.Message); ;
            }
            catch (ArgumentException e)
            {
                Log.Warn("KeyNotFoundException=" + e.Message); ;
            }

            return command;
        }

        private static string GetResourceTypeFromReceivedAppControl(ReceivedAppControl receivedAppControl)
        {
            string resourceType = string.Empty;
            try
            {
                var id = receivedAppControl.ExtraData.Get<string>("__K_SERVICE_ID");
                if (!string.IsNullOrEmpty(id))
                {
                    resourceType = GetResourceTypeFromId(id);
                }
            }
            catch (ArgumentNullException e)
            {
                Log.Warn("ArgumentNullException=" + e.Message); ;
            }
            catch (KeyNotFoundException e)
            {
                Log.Warn("KeyNotFoundException=" + e.Message); ;
            }
            catch (ArgumentException e)
            {
                Log.Warn("KeyNotFoundException=" + e.Message); ;
            }

            return resourceType;
        }

        private static string GetResourceTypeFromId(string id)
        {
            return _serviceInfos.Values.FirstOrDefault(info => info.Id == id)?.ResourceType ?? string.Empty;
        }

        private static void HandleAppControlReceivedEvent(AppControlReceivedEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            string resourceType = GetResourceTypeFromId(e.ReceivedAppControl.ApplicationId);
            if (string.IsNullOrEmpty(resourceType))
            {
                resourceType = GetResourceTypeFromReceivedAppControl(e.ReceivedAppControl);
            }

            if (!string.IsNullOrEmpty(resourceType))
            {
                string command = GetCommand(e.ReceivedAppControl);

                if (command == "QUIT")
                {
                    Service service = null;
                    lock (_services)
                    {
                        if (_services.TryGetValue(resourceType, out service))
                        {
                            if (service.State != ServiceLifecycleState.Destroyed)
                            {
                                service.Quit();
                            }
                        }
                    }
                    return;
                }

                Run(resourceType, e);
            }
        }

        /// <summary>
        /// Retrieves the instance of currently running Services.
        /// </summary>
        /// <returns>An enumarable list containing all the active Services.</returns>
        /// <since_tizen> 13 </since_tizen>
        public static IEnumerable<Service> GetServices()
        {
            return _services.Values.ToList();
        }

        /// <summary>
        /// Retrieves the information about available Services.
        /// </summary>
        /// <remarks>
        /// This method provides details on services that are currently accessible rather than listing all installed services.
        /// A Service's resource package may specify which applications have access through the "allowed-packages" setting.
        /// During execution, the platform mounts the resource package in the application's resources directory.
        /// </remarks>
        /// <returns>An enumerable list of ServiceInfo objects.</returns>
        /// <since_tizen> 13 </since_tizen>
        public static IEnumerable<ServiceInfo> GetServiceInfos()
        {
            return _serviceInfos.Values.ToList();
        }

        private static void SendSystemEvent(ServiceEventType eventType, EventArgs args)
        {
            foreach (var service in _services.Values)
            {
                service.SendSystemEvent(eventType, args);
            }
        }

        private static void OnServiceLifecycleChangedEvent(object sender, ServiceLifecycleChangedEventArgs args)
        {
            ServiceLifecycleChanged?.Invoke(sender, args);
            if (args.State == ServiceLifecycleState.Destroyed)
            {
                args.Service.LifecycleChanged -= OnServiceLifecycleChangedEvent;
                _services.TryRemove(args.Service.ServiceInfo.ResourceType, out _);
            }
        }

        private static ServiceInfo Find(string resourceType)
        {
            if (!_serviceInfos.TryGetValue(resourceType, out var info))
            {
                throw new ArgumentException($"Failed to find ServiceInfo. resource type={resourceType}");
            }

            return info;
        }

        private static void Load(ServiceInfo info)
        {
            if (info == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            try
            {
                if (!info.Assembly.IsLoaded)
                {
                    Log.Warn("ServiceAssembly.Load()=" + info.ExecutablePath + " ++");
                    info.Assembly.Load();
                    Log.Warn("ServiceAssembly.Load()=" + info.ExecutablePath + " --");
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
        public static void Load(string resourceType)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            ServiceInfo info = Find(resourceType);
            Load(info);
        }

        private static void Unload(ServiceInfo info)
        {
            if (info == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            if (info.Assembly.IsLoaded)
            {
                info.Assembly.Unload();
                for (int i = 0; info.Assembly.IsAlive && i < 10; i++)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
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
        public static void Unload(string resourceType)
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
        public static void Run(string resourceType, AppControlReceivedEventArgs args)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            if (_services.TryGetValue(resourceType, out var service) && service.State != ServiceLifecycleState.Destroyed)
            {
                service.SendAppControlReceivedEvent(args);
                return;
            }

            ServiceInfo info = Find(resourceType);
            Load(info);

            service = info.Assembly.CreateInstance(info.ClassName);
            if (service == null)
            {
                throw new InvalidOperationException($"Failed to create instance. class name={info.ClassName}");
            }

            service.ServiceInfo = info;
            service.LifecycleChanged += OnServiceLifecycleChangedEvent;
            _services[resourceType] = service;

            service.Run(args);
        }

        /// <summary>
        /// Quits the main loop of the service.
        /// </summary>
        /// <param name="resourceType">The resource type of the Service package.</param>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void Quit(string resourceType)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                throw new ArgumentException("Invalid argument");
            }

            if (_services.TryGetValue(resourceType, out var service))
            {
                service.Quit();
            }
        }

        /// <summary>
        /// Runs the main loop of all services.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static void RunAll()
        {
            foreach (var resourceType in _serviceInfos.Keys)
            {
                Run(resourceType, null);
            }
        }

        /// <summary>
        /// Quits the main loop of all running services.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public static void QuitAll()
        {
            foreach (var service in _services.Values)
            {
                service.Quit();
            }
        }
    }
}