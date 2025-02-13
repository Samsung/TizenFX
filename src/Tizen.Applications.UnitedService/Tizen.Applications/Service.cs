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
using System.ComponentModel;
using Tizen.Core;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a Service controlled lifecycle.
    /// </summary>
    /// <remarks>
    /// This class provides functionality related to managing the lifecycle of a Service.
    /// It enables developers to handle events such as initialization, activation, deactivation, and destruction of the service.
    /// By implementing this class, developers can define their own behavior for these events and customize the lifecycle of their services accordingly.
    /// </remarks>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class Service : IDisposable
    {
        private Tizen.Core.Task _task = null;
        private bool _disposed = false;
        private object _eventLock = new object();
        private EventHandler<ServiceLifecycleChangedEventArgs> _serviceLifecycleChanged;

        /// <summary>
        /// Initializes the service.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the Service class.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public Service()
        {
            State = ServiceLifecycleState.Initialized;
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Finalizer of the service class.
        /// </summary>
        ~Service()
        {
            Dispose(false);
        }

        /// <summary>
        /// The Id.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string Id
        {
            get
            {
                return ServiceInfo?.Id;
            }
        }

        /// <summary>
        /// The name.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string Name
        {
            get
            {
                return ServiceInfo?.Name;
            }
        }

        internal event EventHandler<ServiceLifecycleChangedEventArgs> LifecycleChanged
        {
            add
            {
                lock (_eventLock)
                {
                    _serviceLifecycleChanged += value;
                }
            }
            remove
            {
                lock (_eventLock)
                {
                    _serviceLifecycleChanged -= value;
                }
            }
        }

        private void Service_LifecycleChanged(object sender, ServiceLifecycleChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The information of the service.
        /// </summary>
        /// <remarks>
        /// This property is set before the OnCreate() is called, after the instance has been created.
        /// It provides details about the current service such as its ID, name, version, and  other relevant information.
        /// By accessing this property, developers can retrieve the necessary information about the service they are working on.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public ServiceInfo ServiceInfo { get; internal set; }

        /// <summary>
        /// The lifecycle state of the service.
        /// </summary>
        public ServiceLifecycleState State { get; internal set; }

        /// <summary>
        /// Runs the main loop of the service.
        /// </summary>
        /// <param name="args">The argument of the app control received event.</param>
        /// <since_tizen> 13 </since_tizen>
        public void Run(AppControlReceivedEventArgs args)
        {
            if (_task != null && _task.Running)
            {
                Log.Info("Already running");
                return;
            }

            TizenCore.Initialize();
            if (ServiceInfo.UseThread)
            {
                _task = TizenCore.Spawn(Name);
                _task.Run();
            }
            else
            {
                _task = TizenCore.Find("main");
            }

            _task.Post(() => { OnCreate(); });
            SendAppcOntrolReceivedEvent(args);
        }

        /// <summary>
        /// Quits the main loop of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void Quit()
        {
            if (_task == null || !_task.Running)
            {
                return;
            }

            _task.Post(() => { OnDestroy(); });
            if (ServiceInfo.UseThread)
            {
                _task.Quit();
                _task.Dispose();
            }
            _task = null;
            TizenCore.Shutdown();
        }

        internal void SendAppcOntrolReceivedEvent(AppControlReceivedEventArgs args)
        {
            _task.Post(() =>
            {
                if (args == null)
                {
                    var appControl = new AppControl();
                    var receivedAppControl = new ReceivedAppControl(appControl.SafeAppControlHandle);
                    OnAppControlReceived(new AppControlReceivedEventArgs(receivedAppControl));
                }
                else
                {
                    OnAppControlReceived(args);
                }
            });
        }

        internal void SendSystemEvent(ServiceEventType eventType, EventArgs args)
        {
            _task.Post(() =>
            {
                switch (eventType)
                {
                    case ServiceEventType.LocaleChanged:
                        OnLocaleChanged((LocaleChangedEventArgs)args);
                        break;
                    case ServiceEventType.LowMemory:
                        OnLowMemory((LowMemoryEventArgs)args);
                        break;
                    case ServiceEventType.LowBattery:
                        OnLowBattery((LowBatteryEventArgs)args);
                        break;
                    case ServiceEventType.RegionFormatChanged:
                        OnRegionFormatChanged((RegionFormatChangedEventArgs)args);
                        break;
                    default:
                        Log.Warn("Unknown Event Type: " + eventType);
                        break;
                }
            });
        }

        private void NotifyLifecycleChanged()
        {
            CoreApplication.Post(() =>
            {
                var args = new ServiceLifecycleChangedEventArgs();
                args.Service = this;
                args.State = State;
                lock (_eventLock)
                {
                    _serviceLifecycleChanged?.Invoke(this, args);
                }
            });
        }

        /// <summary>
        /// Override this method to define the behavior when the service is created.
        /// Calling 'base.OnCreate()' is necessary in order to emit the 'ServiceLifecycleChanged' event with the 'ServiceLifecycleState.Created' state.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnCreate()
        {
            State = ServiceLifecycleState.Created;
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the service receives the appcontrol message.
        /// </summary>
        /// <remarks>
        /// This method provides a way to customize the response when the service receives an appcontrol message.
        /// By overriding this method in your derived class, you can define specific actions based on the incoming arguments.
        /// </remarks>
        /// <param name="e">The appcontrol received event argument containing details about the received message.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            if (State == ServiceLifecycleState.Created)
            {
                State = ServiceLifecycleState.Running;
                NotifyLifecycleChanged();
            }
        }

        /// <summary>
        /// Override this method to handle the behavior when the service is destroyed.
        /// If 'base.OnDestroy()' is not called, the 'ServiceLifecycleChanged' event with the 'ServiceLifecycleState.Destroyed' state will not be emitted.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnDestroy()
        {
            State = ServiceLifecycleState.Destroyed;
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system language is changed.
        /// </summary>
        /// <param name="e">The locale changed event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e) { }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system battery is low.
        /// </summary>
        /// <param name="e">The low batter event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnLowBattery(LowBatteryEventArgs e) { }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system memory is low.
        /// </summary>
        /// <param name="e">The low memory event argument.</param>
        /// <since_tizen> 13 </since_tizen>c
        protected virtual void OnLowMemory(LowMemoryEventArgs e) { }

        /// <summary>
        /// Overrides this method if want to handle behavior when the region format is changed.
        /// </summary>
        /// <param name="e">The region format changed event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e) { }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (ServiceInfo.UseThread && _task != null)
                    {
                        _task.Dispose();
                    }
                    _task = null;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the service class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}