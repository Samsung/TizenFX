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
using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents an UIGadget controlled lifecycle.
    /// </summary>
    /// <remarks>
    /// This class provides functionality related to managing the lifecycle of an UIGadget.
    /// It enables developers to handle events such as initialization, activation, deactivation, and destruction of the UIGadget.
    /// By implementing this class, developers can define their own behavior for these events and customize the lifecycle of their UIGadget accordingly.
    /// </remarks>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class UIGadget
    {
        private static int s_DataLoaderNameSequence = 0;

        /// <summary>
        /// Initializes the UIGadget.
        /// </summary>
        /// <param name="type">The type of the UIGadget.</param>
        /// <remarks>
        /// This constructor initializes a new instance of the UIGadget class based on the specified type.
        /// It is important to provide the correct type argument in order to ensure proper functionality and compatibility with other components.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public UIGadget(UIGadgetType type)
        {
            Type = type;
            State = UIGadgetLifecycleState.Initialized;
            Log.Info("Type=" + Type + ", State=" + State);
        }

        /// <summary>
        /// Initializes the UIGadget with DataLoader factory.
        /// </summary>
        /// <param name="type">The type of the UIGadget.</param>
        /// <param name="loaderFactory">The factory that can create DataLoader object</param>
        /// <param name="autoClose">Whether to automatically close the loader after execution</param>
        /// <exception cref="ArgumentNullException">Thrown if either 'loaderFactory' is null.</exception>
        /// <remarks>
        /// This constructor initializes a new instance of the UIGadget class based on the specified type with DataLoader.
        /// It is important to provide the correct type argument in order to ensure proper functionality and compatibility with other components.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public UIGadget(UIGadgetType type, ILoaderFactory loaderFactory, bool autoClose = true) : this(type)
        {
            if (loaderFactory == null)
            {
                throw new ArgumentNullException(nameof(loaderFactory));
            }

            AutoClose = autoClose;
            LoaderFactory = loaderFactory;
            Loader = LoaderFactory.CreateInstance(GenerateDataLoaderName(), AutoClose);
            Loader.LifecycleStateChanged += OnDataLoaderLifecycleChanged;
        }

        internal event EventHandler<UIGadgetLifecycleChangedEventArgs> LifecycleChanged;

        /// <summary>
        /// Occurs when the lifecycle of the OneShotService is changed.
        /// </summary>
        /// <remarks>
        /// This event is raised when the state of OneShotService changes.
        /// It provides information about the current state through the 
        /// OneShotServiceLifecycleChangedEventArgs argument.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public event EventHandler<DataLoaderLifecycleChangedEventArgs> DataLoaderLifecycleChanged;

        /// <summary>
        /// Gets the class representing information of the current UIGadget.
        /// </summary>
        /// <remarks>
        /// This property is set before the OnCreate() is called, after the instance has been created.
        /// It provides details about the current UIGadget such as its ID, name, version, and other relevant information.
        /// By accessing this property, developers can retrieve the necessary information about the UIGadget they are working on.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public UIGadgetInfo UIGadgetInfo
        {
            protected internal set;
            get;
        }

        /// <summary>
        /// Gets the type of the UIGadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public UIGadgetType Type
        {
            protected internal set;
            get;
        }

        /// <summary>
        /// Gets the class name.
        /// </summary>
        /// <remarks>
        /// This property is set before the OnCreate() is called, after the instance has been created.
        /// It provides access to the name of the class that was used to create the current instance.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public string ClassName
        {
            protected internal set;
            get;
        }

        /// <summary>
        /// Gets the main view of the UIGadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public object MainView
        {
            protected internal set;
            get;
        }

        /// <summary>
        /// Gets the current lifecycle state of the UIGadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public UIGadgetLifecycleState State
        {
            protected internal set;
            get;
        }

        /// <summary>
        /// Gets the resource manager.
        /// </summary>
        /// <remarks> This property is set before the OnCreate() is called, after the instance has been created.
        /// It provides access to various resources such as images, sounds, and fonts that can be used in your application.
        /// By utilizing the resource manager, you can easily manage and retrieve these resources without having to manually handle their loading and unloading.
        /// Additionally, the resource manager ensures efficient memory management by automatically handling the caching and recycling of resources.
        /// </remarks>
        /// <since_tizen> 13 </since_tizen>
        public UIGadgetResourceManager UIGadgetResourceManager
        {
            protected internal set;
            get;
        }

        /// <summary>
        /// The DataLoader.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public DataLoader Loader
        {
            protected internal set;
            get;
        }

        private ILoaderFactory LoaderFactory
        {
            set; get;
        }

        private bool AutoClose
        {
            set; get;
        }

        internal void PreCreate()
        {
            if (State == UIGadgetLifecycleState.Initialized)
            {
                OnPreCreate();
                if (Loader != null)
                {
                    Log.Info($"PreCreate(), Loader.Name = {Loader.Name}");
                    Loader.Run();
                }
            }
        }

        internal bool Create()
        {
            if (State == UIGadgetLifecycleState.PreCreated)
            {
                this.MainView = OnCreate();
                if (this.MainView == null)
                {
                    return false;
                }
            }

            return true;
        }

        internal void Resume()
        {
            if (State == UIGadgetLifecycleState.Created || State == UIGadgetLifecycleState.Paused)
            {
                OnResume();
            }
        }

        internal void Pause()
        {
            if (State == UIGadgetLifecycleState.Resumed)
            {
                OnPause();
            }
        }

        internal void Destroy()
        {
            if (State == UIGadgetLifecycleState.PreCreated || State == UIGadgetLifecycleState.Created || State == UIGadgetLifecycleState.Paused)
            {
                OnDestroy();
            }
        }

        internal void HandleAppControlReceivedEvent(AppControlReceivedEventArgs args) => OnAppControlReceived(args);

        internal void HandleEvents(UIGadgetEventType eventType, EventArgs args)
        {
            switch (eventType)
            {
                case UIGadgetEventType.LocaleChanged:
                    OnLocaleChanged((LocaleChangedEventArgs)args);
                    break;
                case UIGadgetEventType.LowMemory:
                    OnLowMemory((LowMemoryEventArgs)args);
                    break;
                case UIGadgetEventType.LowBattery:
                    OnLowBattery((LowBatteryEventArgs)args);
                    break;
                case UIGadgetEventType.RegionFormatChanged:
                    OnRegionFormatChanged((RegionFormatChangedEventArgs)args);
                    break;
                case UIGadgetEventType.DeviceOrientationChanged:
                    OnDeviceOrientationChanged((DeviceOrientationEventArgs)args);
                    break;
                default:
                    Log.Warn("Unknown Event Type: " + eventType);
                    break;
            }
        }

        private void OnDataLoaderLifecycleChanged(object sender, DataLoaderLifecycleChangedEventArgs args)
        {
            DataLoaderLifecycleChanged?.Invoke(sender, args);

            if (args.State == DataLoaderLifecycleState.Destroyed)
            {
                args.DataLoader.LifecycleStateChanged -= OnDataLoaderLifecycleChanged;
            }
        }

        private void NotifyLifecycleChanged()
        {
            var args = new UIGadgetLifecycleChangedEventArgs()
            {
                State = State,
                UIGadget = this,
            };
            LifecycleChanged?.Invoke(null, args);
        }

        private static string GenerateDataLoaderName() => $"DataLoader+{s_DataLoaderNameSequence++}";

        /// <summary>
        /// Override this method to define the behavior when the UIGadget is pre-created.
        /// Calling 'base.OnPreCreate()' is necessary in order to emit the 'UIGadgetLifecycleChanged' event with the 'UIGadgetLifecycleState.PreCreated' state.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnPreCreate()
        {
            State = UIGadgetLifecycleState.PreCreated;
            Log.Debug("ClassName=" + ClassName);
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Override this method to define the behavior when the UIGadget is created.
        /// Calling 'base.OnCreate()' is necessary in order to emit the 'UIGadgetLifecycleChanged' event with the 'UIGadgetLifecycleState.Created' state.
        /// </summary>
        /// <returns>The main view object.</returns>
        /// <since_tizen> 13 </since_tizen>
        protected virtual object OnCreate()
        {
            State = UIGadgetLifecycleState.Created;
            Log.Debug("ClassName=" + ClassName);
            NotifyLifecycleChanged();
            return null;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the UIGadget receives the appcontrol message.
        /// </summary>
        /// <remarks>
        /// This method provides a way to customize the response when the UIGadget receives an appcontrol message.
        /// By overriding this method in your derived class, you can define specific actions based on the incoming arguments.
        /// </remarks>
        /// <param name="e">The appcontrol received event argument containing details about the received message.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            Log.Debug("ClassName=" + ClassName);
        }

        /// <summary>
        /// Override this method to handle the behavior when the UIGadget is destroyed.
        /// If 'base.OnDestroy()' is not called, the 'UIGadgetLifecycleChanged' event with the 'UIGadgetLifecycleState.Destroyed' state will not be emitted.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnDestroy()
        {
            State = UIGadgetLifecycleState.Destroyed;
            Log.Debug("ClassName=" + ClassName);
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the UIGadget is paused.
        /// If 'base.OnPause()' is not called. the event 'UIGadgetLifecycleChanged' with the 'UIGadgetLifecycleState.Paused' state will not be emitted.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnPause()
        {
            State = UIGadgetLifecycleState.Paused;
            Log.Debug("ClassName=" + ClassName);
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the UIGadget is resumed.
        /// If 'base.OnResume()' is not called. the event 'UIGadgetLifecycleChanged' with the 'UIGadgetLifecycleState.Resumed' state will not be emitted.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnResume()
        {
            State = UIGadgetLifecycleState.Resumed;
            Log.Debug("ClassName=" + ClassName);
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system language is changed.
        /// </summary>
        /// <param name="e">The locale changed event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system battery is low.
        /// </summary>
        /// <param name="e">The low batter event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnLowBattery(LowBatteryEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system memory is low.
        /// </summary>
        /// <param name="e">The low memory event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the region format is changed.
        /// </summary>
        /// <param name="e">The region format changed event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the device orientation is changed.
        /// </summary>
        /// <param name="e">The device orientation changed event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the message is received.
        /// </summary>
        /// <param name="e">The message received event argument.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void OnMessageReceived(UIGadgetMessageReceivedEventArgs e)
        {
        }

        /// <summary>
        /// Sends the message to the UIGadget.
        /// The message will be delived to the OnMessageReceived() method.
        /// </summary>
        /// <param name="message">The message</param>
        /// <exception cref="ArgumentNullException">Thrown if either 'message' is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public virtual void SendMessage(Bundle message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            CoreApplication.Post(() => OnMessageReceived(new UIGadgetMessageReceivedEventArgs(message)));
        }

        /// <summary>
        /// Finishes the UIGadget.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public virtual void Finish()
        {
            Pause();
            Destroy();
        }
    }
}
