/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    // Event arguments that passed via NUIApplicationInit signal
    internal class NUIApplicationInitEventArgs : EventArgs
    {
        private Application application;

        // Application - is the application that is being initialized
        public Application Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationTerminate signal
    internal class NUIApplicationTerminatingEventArgs : EventArgs
    {
        private Application application;

        // Application - is the application that is being Terminated
        public Application Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationPause signal
    internal class NUIApplicationPausedEventArgs : EventArgs
    {
        private Application application;

        // Application - is the application that is being Paused
        public Application Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationResume signal
    internal class NUIApplicationResumedEventArgs : EventArgs
    {
        private Application application;
        // Application - is the application that is being Resumed
        public Application Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationReset signal
    internal class NUIApplicationResetEventArgs : EventArgs
    {
        private Application application;

        // Application - is the application that is being Reset
        public Application Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationLanguageChanged signal
    internal class NUIApplicationLanguageChangedEventArgs : EventArgs
    {
        private Application application;

        // Application - is the application that is being affected with Device's language change
        public Application Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationRegionChanged signal
    internal class NUIApplicationRegionChangedEventArgs : EventArgs
    {
        private Application application;

        // Application - is the application that is being affected with Device's region change
        public Application Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationBatteryLow signal
    internal class NUIApplicationBatteryLowEventArgs : EventArgs
    {
        private Application.BatteryStatus status;

        // Application - is the application that is being affected when the battery level of the device is low
        public Application.BatteryStatus BatteryStatus
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationMemoryLow signal
    internal class NUIApplicationMemoryLowEventArgs : EventArgs
    {
        private Application.MemoryStatus status;

        // Application - is the application that is being affected when the memory level of the device is low
        public Application.MemoryStatus MemoryStatus
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationDeviceOrientationChanged signal
    internal class NUIApplicationDeviceOrientationChangedEventArgs : EventArgs
    {
        private Application.DeviceOrientationStatus status;

        // Application - is the application that is being affected when the device orientation is changed.
        public Application.DeviceOrientationStatus DeviceOrientationStatus
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
    }

    // Event arguments that passed via NUIApplicationAppControl	 signal
    internal class NUIApplicationAppControlEventArgs : EventArgs
    {
        private Application application;
        private IntPtr voidp;

        // Application - is the application that is receiving the launch request from another application
        public Application Application
        {
            get
            {
                return application;
            }
            set
            {
                application = value;
            }
        }

        // VoidP - contains the information about why the application is launched
        public IntPtr VoidP
        {
            get
            {
                return voidp;
            }
            set
            {
                voidp = value;
            }
        }
    }

    /// <summary>
    /// A class to get resources in current application.
    /// </summary>
    public sealed class GetResourcesProvider
    {
        /// <summary>
        /// Get resources in current application.
        /// </summary>
        static public IResourcesProvider Get()
        {
            return Tizen.NUI.Application.Current;
        }
    }

    internal class Application : BaseHandle, IResourcesProvider, IElementConfiguration<Application>
    {
        static Application s_current;

        ReadOnlyCollection<Element> logicalChildren;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetCurrentApplication(Application value) => Current = value;

        public static Application Current
        {
            get { return s_current; }
            set
            {
                if (s_current == value)
                    return;
                s_current = value;
            }
        }

        internal override ReadOnlyCollection<Element> LogicalChildrenInternal
        {
            get { return logicalChildren ?? (logicalChildren = new ReadOnlyCollection<Element>(InternalChildren)); }
        }

        internal IResourceDictionary SystemResources { get; }

        ObservableCollection<Element> InternalChildren { get; } = new ObservableCollection<Element>();

        ResourceDictionary resources;
        public bool IsResourcesCreated => resources != null;

        public delegate void resChangeCb(object sender, ResourcesChangedEventArgs e);

        internal override void OnResourcesChanged(object sender, ResourcesChangedEventArgs e)
        {
            base.OnResourcesChanged(sender, e);
        }

        public ResourceDictionary XamlResources
        {
            get
            {
                if (resources == null)
                {
                    resources = new ResourceDictionary();
                    int hashCode = resources.GetHashCode();
                    ((IResourceDictionary)resources).ValuesChanged += OnResourcesChanged;
                }
                return resources;
            }
            set
            {
                if (resources == value)
                    return;
                OnPropertyChanging();

                if (resources != null)
                    ((IResourceDictionary)resources).ValuesChanged -= OnResourcesChanged;
                resources = value;
                OnResourcesChanged(value);
                if (resources != null)
                    ((IResourceDictionary)resources).ValuesChanged += OnResourcesChanged;

                OnPropertyChanged();
            }
        }

        protected override void OnParentSet()
        {
            throw new InvalidOperationException("Setting a Parent on Application is invalid.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsApplicationOrNull(Element element)
        {
            return element == null || element is Application;
        }

        internal override void OnParentResourcesChanged(IEnumerable<KeyValuePair<string, object>> values)
        {
            if (values == null)
                return;

            if (!((IResourcesProvider)this).IsResourcesCreated || XamlResources.Count == 0)
            {
                base.OnParentResourcesChanged(values);
                return;
            }

            var innerKeys = new HashSet<string>();
            var changedResources = new List<KeyValuePair<string, object>>();
            foreach (KeyValuePair<string, object> c in XamlResources)
                innerKeys.Add(c.Key);
            foreach (KeyValuePair<string, object> value in values)
            {
                if (innerKeys.Add(value.Key))
                    changedResources.Add(value);
            }
            if (changedResources.Count != 0)
                OnResourcesChanged(changedResources);
        }

        internal Application(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            SetCurrentApplication(this);
            s_current = this;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (applicationInitEventCallbackDelegate != null)
            {
                initSignal?.Disconnect(applicationInitEventCallbackDelegate);
                initSignal?.Dispose();
                initSignal = null;
            }

            if (applicationTerminateEventCallbackDelegate != null)
            {
                terminateSignal?.Disconnect(applicationTerminateEventCallbackDelegate);
                terminateSignal?.Dispose();
                terminateSignal = null;
            }

            if (applicationPauseEventCallbackDelegate != null)
            {
                pauseSignal?.Disconnect(applicationPauseEventCallbackDelegate);
                pauseSignal?.Dispose();
                pauseSignal = null;
            }

            if (applicationResumeEventCallbackDelegate != null)
            {
                resumeSignal?.Disconnect(applicationResumeEventCallbackDelegate);
                resumeSignal?.Dispose();
                resumeSignal = null;
            }

            if (applicationResetEventCallbackDelegate != null)
            {
                resetSignal?.Disconnect(applicationResetEventCallbackDelegate);
                resetSignal?.Dispose();
                resetSignal = null;
            }

            if (applicationLanguageChangedEventCallbackDelegate != null)
            {
                languageChangedSignal?.Disconnect(applicationLanguageChangedEventCallbackDelegate);
                languageChangedSignal?.Dispose();
                languageChangedSignal = null;
            }

            if (applicationRegionChangedEventCallbackDelegate != null)
            {
                regionChangedSignal?.Disconnect(applicationRegionChangedEventCallbackDelegate);
                regionChangedSignal?.Dispose();
                regionChangedSignal = null;
            }

            if (applicationBatteryLowEventCallbackDelegate != null)
            {
                batteryLowSignal?.Disconnect(applicationBatteryLowEventCallbackDelegate);
                batteryLowSignal?.Dispose();
                batteryLowSignal = null;
            }

            if (applicationMemoryLowEventCallbackDelegate != null)
            {
                memoryLowSignal?.Disconnect(applicationMemoryLowEventCallbackDelegate);
                memoryLowSignal?.Dispose();
                memoryLowSignal = null;
            }

            if (applicationDeviceOrientationChangedEventCallback != null)
            {
                deviceOrientationChangedSignal?.Disconnect(applicationDeviceOrientationChangedEventCallback);
                deviceOrientationChangedSignal?.Dispose();
                deviceOrientationChangedSignal = null;
            }

            if (applicationAppControlEventCallbackDelegate != null)
            {
                appControlSignal?.Disconnect(applicationAppControlEventCallbackDelegate);
                appControlSignal?.Dispose();
                appControlSignal = null;
            }

            //Task
            if (applicationTaskInitEventCallbackDelegate != null)
            {
                taskInitSignal?.Disconnect(applicationTaskInitEventCallbackDelegate);
                taskInitSignal?.Dispose();
                taskInitSignal = null;
            }

            if (applicationTaskTerminateEventCallbackDelegate != null)
            {
                taskTerminateSignal?.Disconnect(applicationTaskTerminateEventCallbackDelegate);
                taskTerminateSignal?.Dispose();
                taskTerminateSignal = null;
            }

            if (applicationTaskLanguageChangedEventCallbackDelegate != null)
            {
                taskLanguageChangedSignal?.Disconnect(applicationTaskLanguageChangedEventCallbackDelegate);
                taskLanguageChangedSignal?.Dispose();
                taskLanguageChangedSignal = null;
            }

            if (applicationTaskRegionChangedEventCallbackDelegate != null)
            {
                taskRegionChangedSignal?.Disconnect(applicationTaskRegionChangedEventCallbackDelegate);
                taskRegionChangedSignal?.Dispose();
                taskRegionChangedSignal = null;
            }

            if (applicationTaskBatteryLowEventCallbackDelegate != null)
            {
                taskBatteryLowSignal?.Disconnect(applicationTaskBatteryLowEventCallbackDelegate);
                taskBatteryLowSignal?.Dispose();
                taskBatteryLowSignal = null;
            }

            if (applicationTaskMemoryLowEventCallbackDelegate != null)
            {
                taskMemoryLowSignal?.Disconnect(applicationTaskMemoryLowEventCallbackDelegate);
                taskMemoryLowSignal?.Dispose();
                taskMemoryLowSignal = null;
            }

            if (applicationTaskDeviceOrientationChangedEventCallback != null)
            {
                taskDeviceOrientationChangedSignal?.Disconnect(applicationTaskDeviceOrientationChangedEventCallback);
                taskDeviceOrientationChangedSignal?.Dispose();
                taskDeviceOrientationChangedSignal = null;
            }

            if (applicationTaskAppControlEventCallbackDelegate != null)
            {
                taskAppControlSignal?.Disconnect(applicationTaskAppControlEventCallbackDelegate);
                taskAppControlSignal?.Dispose();
                taskAppControlSignal = null;
            }

            window?.Dispose();
            window = null;

            base.Dispose(type);
        }
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Application.DeleteApplication(swigCPtr);
        }

        public enum BatteryStatus
        {
            Normal,
            CriticallyLow,
            PowerOff
        };

        public enum MemoryStatus
        {
            Normal,
            Low,
            CriticallyLow
        };

        public enum DeviceOrientationStatus
        {
            Orientation_0 = 0,
            Orientation_90 = 90,
            Orientation_180 = 180,
            Orientation_270 = 270
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationInitEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationInitEventArgs> applicationInitEventHandler;
        private NUIApplicationInitEventCallbackDelegate applicationInitEventCallbackDelegate;
        private ApplicationSignal initSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationTerminateEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationTerminatingEventArgs> applicationTerminateEventHandler;
        private NUIApplicationTerminateEventCallbackDelegate applicationTerminateEventCallbackDelegate;
        private ApplicationSignal terminateSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationPauseEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationPausedEventArgs> applicationPauseEventHandler;
        private NUIApplicationPauseEventCallbackDelegate applicationPauseEventCallbackDelegate;
        private ApplicationSignal pauseSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationResumeEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationResumedEventArgs> applicationResumeEventHandler;
        private NUIApplicationResumeEventCallbackDelegate applicationResumeEventCallbackDelegate;
        private ApplicationSignal resumeSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationResetEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationResetEventArgs> applicationResetEventHandler;
        private NUIApplicationResetEventCallbackDelegate applicationResetEventCallbackDelegate;
        private ApplicationSignal resetSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationLanguageChangedEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationLanguageChangedEventArgs> applicationLanguageChangedEventHandler;
        private NUIApplicationLanguageChangedEventCallbackDelegate applicationLanguageChangedEventCallbackDelegate;
        private ApplicationSignal languageChangedSignal;


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationRegionChangedEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationRegionChangedEventArgs> applicationRegionChangedEventHandler;
        private NUIApplicationRegionChangedEventCallbackDelegate applicationRegionChangedEventCallbackDelegate;
        private ApplicationSignal regionChangedSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationBatteryLowEventCallbackDelegate(BatteryStatus status);
        private DaliEventHandler<object, NUIApplicationBatteryLowEventArgs> applicationBatteryLowEventHandler;
        private NUIApplicationBatteryLowEventCallbackDelegate applicationBatteryLowEventCallbackDelegate;
        private LowBatterySignalType batteryLowSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationMemoryLowEventCallbackDelegate(MemoryStatus status);
        private DaliEventHandler<object, NUIApplicationMemoryLowEventArgs> applicationMemoryLowEventHandler;
        private NUIApplicationMemoryLowEventCallbackDelegate applicationMemoryLowEventCallbackDelegate;
        private LowMemorySignalType memoryLowSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationDeviceOrientationChangedEventCallback(DeviceOrientationStatus status);
        private DaliEventHandler<object, NUIApplicationDeviceOrientationChangedEventArgs> applicationDeviceOrientationChangedEventHandler;
        private NUIApplicationDeviceOrientationChangedEventCallback applicationDeviceOrientationChangedEventCallback;
        private DeviceOrientationChangedSignalType deviceOrientationChangedSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationAppControlEventCallbackDelegate(IntPtr application, IntPtr voidp);
        private DaliEventHandler<object, NUIApplicationAppControlEventArgs> applicationAppControlEventHandler;
        private NUIApplicationAppControlEventCallbackDelegate applicationAppControlEventCallbackDelegate;
        private ApplicationControlSignal appControlSignal;

        private DaliEventHandler<object, NUIApplicationInitEventArgs> applicationTaskInitEventHandler;
        private NUIApplicationInitEventCallbackDelegate applicationTaskInitEventCallbackDelegate;
        private ApplicationSignal taskInitSignal;

        private DaliEventHandler<object, NUIApplicationTerminatingEventArgs> applicationTaskTerminateEventHandler;
        private NUIApplicationTerminateEventCallbackDelegate applicationTaskTerminateEventCallbackDelegate;
        private ApplicationSignal taskTerminateSignal;

        private DaliEventHandler<object, NUIApplicationLanguageChangedEventArgs> applicationTaskLanguageChangedEventHandler;
        private NUIApplicationLanguageChangedEventCallbackDelegate applicationTaskLanguageChangedEventCallbackDelegate;
        private ApplicationSignal taskLanguageChangedSignal;

        private DaliEventHandler<object, NUIApplicationRegionChangedEventArgs> applicationTaskRegionChangedEventHandler;
        private NUIApplicationRegionChangedEventCallbackDelegate applicationTaskRegionChangedEventCallbackDelegate;
        private ApplicationSignal taskRegionChangedSignal;

        private DaliEventHandler<object, NUIApplicationBatteryLowEventArgs> applicationTaskBatteryLowEventHandler;
        private NUIApplicationBatteryLowEventCallbackDelegate applicationTaskBatteryLowEventCallbackDelegate;
        private LowBatterySignalType taskBatteryLowSignal;

        private DaliEventHandler<object, NUIApplicationMemoryLowEventArgs> applicationTaskMemoryLowEventHandler;
        private NUIApplicationMemoryLowEventCallbackDelegate applicationTaskMemoryLowEventCallbackDelegate;
        private LowMemorySignalType taskMemoryLowSignal;

        private DaliEventHandler<object, NUIApplicationDeviceOrientationChangedEventArgs> applicationTaskDeviceOrientationChangedEventHandler;
        private NUIApplicationDeviceOrientationChangedEventCallback applicationTaskDeviceOrientationChangedEventCallback;
        private DeviceOrientationChangedSignalType taskDeviceOrientationChangedSignal;

        private DaliEventHandler<object, NUIApplicationAppControlEventArgs> applicationTaskAppControlEventHandler;
        private NUIApplicationAppControlEventCallbackDelegate applicationTaskAppControlEventCallbackDelegate;
        private ApplicationControlSignal taskAppControlSignal;

        private Window window;

        // Event for Initialized signal which can be used to subscribe/unsubscribe the event handler
        // provided by the user. Initialized signal is emitted when application is initialized
        public event DaliEventHandler<object, NUIApplicationInitEventArgs> Initialized
        {
            add
            {
                // Restricted to only one listener
                if (applicationInitEventHandler == null)
                {
                    applicationInitEventHandler += value;
                    applicationInitEventCallbackDelegate = new NUIApplicationInitEventCallbackDelegate(OnApplicationInit);
                    initSignal = this.InitSignal();
                    initSignal?.Connect(applicationInitEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationInitEventHandler != null)
                {
                    initSignal?.Disconnect(applicationInitEventCallbackDelegate);
                    initSignal?.Dispose();
                    initSignal = null;
                }

                applicationInitEventHandler -= value;
            }
        }

        // Callback for Application InitSignal
        private void OnApplicationInit(IntPtr data)
        {
            Log.Info("NUI", "[NUI] OnApplicationInit: DisposeQueue Initialize");
            Tizen.Tracer.Begin("[NUI] OnApplicationInit: DisposeQueue Initialize");
            // Initialize DisposeQueue Singleton class. This is also required to create DisposeQueue on main thread.
            DisposeQueue.Instance.Initialize();
            Tizen.Tracer.End();

            Log.Info("NUI", "[NUI] OnApplicationInit: GetWindow");
            Tizen.Tracer.Begin("[NUI] OnApplicationInit: GetWindow");
            Window.Instance = GetWindow();
#if !PROFILE_TV
            //tv profile never use default focus indicator, so this is not needed!
            _ = FocusManager.Instance;
#endif
            Tizen.Tracer.End();

            Log.Info("NUI", "[NUI] OnApplicationInit: Window Show");
            Tizen.Tracer.Begin("[NUI] OnApplicationInit: Window Show");
            // Notify that the window is displayed to the app core.
            if (NUIApplication.IsPreload)
            {
                Window.Instance.Show();
            }
            Tizen.Tracer.End();

            Log.Info("NUI", "[NUI] OnApplicationInit: applicationInitEventHandler Invoke");
            Tizen.Tracer.Begin("[NUI] OnApplicationInit: applicationInitEventHandler Invoke");
            if (applicationInitEventHandler != null)
            {
                NUIApplicationInitEventArgs e = new NUIApplicationInitEventArgs();
                e.Application = this;
                applicationInitEventHandler.Invoke(this, e);
            }
            Tizen.Tracer.End();
        }

        // Event for Terminated signal which can be used to subscribe/unsubscribe the event handler
        //  provided by the user. Terminated signal is emitted when application is terminating
        public event DaliEventHandler<object, NUIApplicationTerminatingEventArgs> Terminating
        {
            add
            {
                // Restricted to only one listener
                if (applicationTerminateEventHandler == null)
                {
                    applicationTerminateEventHandler += value;

                    applicationTerminateEventCallbackDelegate = new NUIApplicationTerminateEventCallbackDelegate(OnNUIApplicationTerminate);
                    terminateSignal = this.TerminateSignal();
                    terminateSignal?.Connect(applicationTerminateEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationTerminateEventHandler != null)
                {
                    terminateSignal?.Disconnect(applicationTerminateEventCallbackDelegate);
                    terminateSignal?.Dispose();
                    terminateSignal = null;
                }

                applicationTerminateEventHandler -= value;
            }
        }

        // Callback for Application TerminateSignal
        private void OnNUIApplicationTerminate(IntPtr data)
        {
            if (applicationTerminateEventHandler != null)
            {
                NUIApplicationTerminatingEventArgs e = new NUIApplicationTerminatingEventArgs();
                e.Application = this;
                applicationTerminateEventHandler.Invoke(this, e);
            }

            List<Window> windows = GetWindowList();
            foreach (Window window in windows)
            {
                window?.DisconnectNativeSignals();
            }
        }

        // Event for Paused signal which can be used to subscribe/unsubscribe the event handler
        // provided by the user. Paused signal is emitted when application is paused
        public event DaliEventHandler<object, NUIApplicationPausedEventArgs> Paused
        {
            add
            {
                // Restricted to only one listener
                if (applicationPauseEventHandler == null)
                {
                    applicationPauseEventHandler += value;

                    applicationPauseEventCallbackDelegate = new NUIApplicationPauseEventCallbackDelegate(OnNUIApplicationPause);
                    pauseSignal = this.PauseSignal();
                    pauseSignal?.Connect(applicationPauseEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationPauseEventHandler != null)
                {
                    pauseSignal?.Disconnect(applicationPauseEventCallbackDelegate);
                    pauseSignal?.Dispose();
                    pauseSignal = null;
                }

                applicationPauseEventHandler -= value;
            }
        }

        // Callback for Application PauseSignal
        private void OnNUIApplicationPause(IntPtr data)
        {
            if (applicationPauseEventHandler != null)
            {
                NUIApplicationPausedEventArgs e = new NUIApplicationPausedEventArgs();
                e.Application = this;
                applicationPauseEventHandler.Invoke(this, e);
            }
        }

        // Event for Resumed signal which can be used to subscribe/unsubscribe the event handler
        //  provided by the user. Resumed signal is emitted when application is resumed
        public event DaliEventHandler<object, NUIApplicationResumedEventArgs> Resumed
        {
            add
            {
                // Restricted to only one listener
                if (applicationResumeEventHandler == null)
                {
                    applicationResumeEventHandler += value;

                    applicationResumeEventCallbackDelegate = new NUIApplicationResumeEventCallbackDelegate(OnNUIApplicationResume);
                    resumeSignal = this.ResumeSignal();
                    resumeSignal?.Connect(applicationResumeEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationResumeEventHandler != null)
                {
                    resumeSignal?.Disconnect(applicationResumeEventCallbackDelegate);
                    resumeSignal?.Dispose();
                    resumeSignal = null;
                }

                applicationResumeEventHandler -= value;
            }
        }

        // Callback for Application ResumeSignal
        private void OnNUIApplicationResume(IntPtr data)
        {
            if (applicationResumeEventHandler != null)
            {
                NUIApplicationResumedEventArgs e = new NUIApplicationResumedEventArgs();
                e.Application = this;
                applicationResumeEventHandler.Invoke(this, e);
            }
        }

        // Event for Reset signal which can be used to subscribe/unsubscribe the event handler
        //  provided by the user. Reset signal is emitted when application is reset
        public new event DaliEventHandler<object, NUIApplicationResetEventArgs> Reset
        {
            add
            {
                // Restricted to only one listener
                if (applicationResetEventHandler == null)
                {
                    applicationResetEventHandler += value;

                    applicationResetEventCallbackDelegate = new NUIApplicationResetEventCallbackDelegate(OnNUIApplicationReset);
                    resetSignal = this.ResetSignal();
                    resetSignal?.Connect(applicationResetEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationResetEventHandler != null)
                {
                    resetSignal?.Disconnect(applicationResetEventCallbackDelegate);
                    resetSignal?.Dispose();
                    resetSignal = null;
                }

                applicationResetEventHandler -= value;
            }
        }

        // Callback for Application ResetSignal
        private void OnNUIApplicationReset(IntPtr data)
        {
            if (applicationResetEventHandler != null)
            {
                NUIApplicationResetEventArgs e = new NUIApplicationResetEventArgs();
                e.Application = this;
                applicationResetEventHandler.Invoke(this, e);
            }
        }

        // Event for LanguageChanged signal which can be used to subscribe/unsubscribe the event handler
        //  provided by the user. LanguageChanged signal is emitted when the region of the device is changed.
        public event DaliEventHandler<object, NUIApplicationLanguageChangedEventArgs> LanguageChanged
        {
            add
            {
                // Restricted to only one listener
                if (applicationLanguageChangedEventHandler == null)
                {
                    applicationLanguageChangedEventHandler += value;

                    applicationLanguageChangedEventCallbackDelegate = new NUIApplicationLanguageChangedEventCallbackDelegate(OnNUIApplicationLanguageChanged);
                    languageChangedSignal = this.LanguageChangedSignal();
                    languageChangedSignal?.Connect(applicationLanguageChangedEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationLanguageChangedEventHandler != null)
                {
                    languageChangedSignal?.Disconnect(applicationLanguageChangedEventCallbackDelegate);
                    languageChangedSignal?.Dispose();
                    languageChangedSignal = null;
                }

                applicationLanguageChangedEventHandler -= value;
            }
        }

        // Callback for Application LanguageChangedSignal
        private void OnNUIApplicationLanguageChanged(IntPtr data)
        {
            if (applicationLanguageChangedEventHandler != null)
            {
                NUIApplicationLanguageChangedEventArgs e = new NUIApplicationLanguageChangedEventArgs();
                e.Application = this;
                applicationLanguageChangedEventHandler.Invoke(this, e);
            }
        }

        // Event for RegionChanged signal which can be used to subscribe/unsubscribe the event handler
        //  provided by the user. RegionChanged signal is emitted when the region of the device is changed.
        public event DaliEventHandler<object, NUIApplicationRegionChangedEventArgs> RegionChanged
        {
            add
            {
                // Restricted to only one listener
                if (applicationRegionChangedEventHandler == null)
                {
                    applicationRegionChangedEventHandler += value;

                    applicationRegionChangedEventCallbackDelegate = new NUIApplicationRegionChangedEventCallbackDelegate(OnNUIApplicationRegionChanged);
                    regionChangedSignal = this.RegionChangedSignal();
                    regionChangedSignal?.Connect(applicationRegionChangedEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationRegionChangedEventHandler != null)
                {
                    regionChangedSignal?.Disconnect(applicationRegionChangedEventCallbackDelegate);
                    regionChangedSignal?.Dispose();
                    regionChangedSignal = null;
                }

                applicationRegionChangedEventHandler -= value;
            }
        }

        // Callback for Application RegionChangedSignal
        private void OnNUIApplicationRegionChanged(IntPtr data)
        {
            if (applicationRegionChangedEventHandler != null)
            {
                NUIApplicationRegionChangedEventArgs e = new NUIApplicationRegionChangedEventArgs();
                e.Application = this;
                applicationRegionChangedEventHandler.Invoke(this, e);
            }
        }

        // Event for BatteryLow signal which can be used to subscribe/unsubscribe the event handler
        // provided by the user. BatteryLow signal is emitted when the battery level of the device is low.
        public event DaliEventHandler<object, NUIApplicationBatteryLowEventArgs> BatteryLow
        {
            add
            {
                // Restricted to only one listener
                if (applicationBatteryLowEventHandler == null)
                {
                    applicationBatteryLowEventHandler += value;

                    applicationBatteryLowEventCallbackDelegate = new NUIApplicationBatteryLowEventCallbackDelegate(OnNUIApplicationBatteryLow);
                    batteryLowSignal = this.BatteryLowSignal();
                    batteryLowSignal?.Connect(applicationBatteryLowEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationBatteryLowEventHandler != null)
                {
                    batteryLowSignal?.Disconnect(applicationBatteryLowEventCallbackDelegate);
                    batteryLowSignal?.Dispose();
                    batteryLowSignal = null;
                }

                applicationBatteryLowEventHandler -= value;
            }
        }

        // Callback for Application BatteryLowSignal
        private void OnNUIApplicationBatteryLow(BatteryStatus status)
        {
            NUIApplicationBatteryLowEventArgs e = new NUIApplicationBatteryLowEventArgs();

            // Populate all members of "e" (NUIApplicationBatteryLowEventArgs) with real data
            e.BatteryStatus = status;
            applicationBatteryLowEventHandler?.Invoke(this, e);
        }

        // Event for MemoryLow signal which can be used to subscribe/unsubscribe the event handler
        //  provided by the user. MemoryLow signal is emitted when the memory level of the device is low.
        public event DaliEventHandler<object, NUIApplicationMemoryLowEventArgs> MemoryLow
        {
            add
            {
                // Restricted to only one listener
                if (applicationMemoryLowEventHandler == null)
                {
                    applicationMemoryLowEventHandler += value;

                    applicationMemoryLowEventCallbackDelegate = new NUIApplicationMemoryLowEventCallbackDelegate(OnNUIApplicationMemoryLow);
                    memoryLowSignal = this.MemoryLowSignal();
                    memoryLowSignal?.Connect(applicationMemoryLowEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationMemoryLowEventHandler != null)
                {
                    memoryLowSignal?.Disconnect(applicationMemoryLowEventCallbackDelegate);
                    memoryLowSignal?.Dispose();
                    memoryLowSignal = null;
                }

                applicationMemoryLowEventHandler -= value;
            }
        }

        // Callback for Application MemoryLowSignal
        private void OnNUIApplicationMemoryLow(MemoryStatus status)
        {
            NUIApplicationMemoryLowEventArgs e = new NUIApplicationMemoryLowEventArgs();

            // Populate all members of "e" (NUIApplicationMemoryLowEventArgs) with real data
            e.MemoryStatus = status;
            applicationMemoryLowEventHandler?.Invoke(this, e);
        }

        // Event for changing Device orientation signal which can be used to subscribe/unsubscribe the event handler
        //  provided by the user. DeviceOrientationChanged signal is emitted when the device orientation is changed.
        public event DaliEventHandler<object, NUIApplicationDeviceOrientationChangedEventArgs> DeviceOrientationChanged
        {
            add
            {
                // Restricted to only one listener
                if (applicationDeviceOrientationChangedEventHandler == null)
                {
                    applicationDeviceOrientationChangedEventHandler += value;

                    applicationDeviceOrientationChangedEventCallback = new NUIApplicationDeviceOrientationChangedEventCallback(OnNUIApplicationDeviceOrientationChanged);
                    deviceOrientationChangedSignal = this.DeviceOrientationChangedSignal();
                    deviceOrientationChangedSignal?.Connect(applicationDeviceOrientationChangedEventCallback);
                }
            }

            remove
            {
                if (applicationDeviceOrientationChangedEventHandler != null)
                {
                    deviceOrientationChangedSignal?.Disconnect(applicationDeviceOrientationChangedEventCallback);
                    deviceOrientationChangedSignal?.Dispose();
                    deviceOrientationChangedSignal = null;
                }

                applicationDeviceOrientationChangedEventHandler -= value;
            }
        }

        // Callback for Application DeviceOrientationChangedSignal
        private void OnNUIApplicationDeviceOrientationChanged(DeviceOrientationStatus status)
        {
            NUIApplicationDeviceOrientationChangedEventArgs e = new NUIApplicationDeviceOrientationChangedEventArgs();

            e.DeviceOrientationStatus = status;
            applicationDeviceOrientationChangedEventHandler?.Invoke(this, e);
        }

        // Event for AppControl signal which can be used to subscribe/unsubscribe the event handler
        //  provided by the user. AppControl signal is emitted when another application sends a launch request to the application.
        public event DaliEventHandler<object, NUIApplicationAppControlEventArgs> AppControl
        {
            add
            {
                // Restricted to only one listener
                if (applicationAppControlEventHandler == null)
                {
                    applicationAppControlEventHandler += value;

                    applicationAppControlEventCallbackDelegate = new NUIApplicationAppControlEventCallbackDelegate(OnNUIApplicationAppControl);
                    appControlSignal = this.AppControlSignal();
                    appControlSignal?.Connect(applicationAppControlEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationAppControlEventHandler != null)
                {
                    appControlSignal?.Disconnect(applicationAppControlEventCallbackDelegate);
                    appControlSignal?.Dispose();
                    appControlSignal = null;
                }

                applicationAppControlEventHandler -= value;
            }
        }

        // Callback for Application AppControlSignal
        private void OnNUIApplicationAppControl(IntPtr application, IntPtr voidp)
        {
            if (applicationAppControlEventHandler != null)
            {
                NUIApplicationAppControlEventArgs e = new NUIApplicationAppControlEventArgs();
                e.VoidP = voidp;
                e.Application = this;
                applicationAppControlEventHandler.Invoke(this, e);
            }
        }

        /// <summary>
        /// Event for Initialized signal which can be used to subscribe/unsubscribe the event handler
        ///  provided by the user. Initialized signal is emitted when application is initialized
        /// </summary>
        public event DaliEventHandler<object, NUIApplicationInitEventArgs> TaskInitialized
        {
            add
            {
                // Restricted to only one listener
                if (applicationTaskInitEventHandler == null)
                {
                    Tizen.Log.Fatal("NUI", "TaskInitialized Property adding");
                    applicationTaskInitEventHandler += value;
                    applicationTaskInitEventCallbackDelegate = new NUIApplicationInitEventCallbackDelegate(OnApplicationTaskInit);
                    taskInitSignal = this.TaskInitSignal();
                    taskInitSignal?.Connect(applicationTaskInitEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationTaskInitEventHandler != null)
                {
                    taskInitSignal?.Disconnect(applicationTaskInitEventCallbackDelegate);
                    taskInitSignal?.Dispose();
                    taskInitSignal = null;
                }

                applicationTaskInitEventHandler -= value;
            }
        }

        private void OnApplicationTaskInit(IntPtr data)
        {
            if (applicationTaskInitEventHandler != null)
            {
                NUIApplicationInitEventArgs e = new NUIApplicationInitEventArgs();
                e.Application = this;
                applicationTaskInitEventHandler.Invoke(this, e);
            }

        }

        /// <summary>
        /// Event for Terminated signal which can be used to subscribe/unsubscribe the event handler
        ///  provided by the user. Terminated signal is emitted when application is terminating
        /// </summary>
        public event DaliEventHandler<object, NUIApplicationTerminatingEventArgs> TaskTerminating
        {
            add
            {
                // Restricted to only one listener
                if (applicationTaskTerminateEventHandler == null)
                {
                    applicationTaskTerminateEventHandler += value;

                    applicationTaskTerminateEventCallbackDelegate = new NUIApplicationTerminateEventCallbackDelegate(OnNUIApplicationTaskTerminate);
                    taskTerminateSignal = this.TaskTerminateSignal();
                    taskTerminateSignal?.Connect(applicationTaskTerminateEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationTaskTerminateEventHandler != null)
                {
                    taskTerminateSignal?.Disconnect(applicationTaskTerminateEventCallbackDelegate);
                    taskTerminateSignal?.Dispose();
                    taskTerminateSignal = null;
                }

                applicationTaskTerminateEventHandler -= value;
            }
        }

        private void OnNUIApplicationTaskTerminate(IntPtr data)
        {
            if (applicationTaskTerminateEventHandler != null)
            {
                NUIApplicationTerminatingEventArgs e = new NUIApplicationTerminatingEventArgs();
                e.Application = this;
                applicationTaskTerminateEventHandler.Invoke(this, e);
            }
        }

        /// <summary>
        /// Event for TaskLanguageChanged signal which can be used to subscribe/unsubscribe the event handler
        ///  provided by the user. TaskLanguageChanged signal is emitted when the region of the device is changed.
        /// </summary>
        public event DaliEventHandler<object, NUIApplicationLanguageChangedEventArgs> TaskLanguageChanged
        {
            add
            {
                // Restricted to only one listener
                if (applicationTaskLanguageChangedEventHandler == null)
                {
                    applicationTaskLanguageChangedEventHandler += value;

                    applicationTaskLanguageChangedEventCallbackDelegate = new NUIApplicationLanguageChangedEventCallbackDelegate(OnNUIApplicationTaskLanguageChanged);
                    taskLanguageChangedSignal = this.TaskLanguageChangedSignal();
                    taskLanguageChangedSignal?.Connect(applicationTaskLanguageChangedEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationTaskLanguageChangedEventHandler != null)
                {
                    taskLanguageChangedSignal?.Disconnect(applicationTaskLanguageChangedEventCallbackDelegate);
                    taskLanguageChangedSignal?.Dispose();
                    taskLanguageChangedSignal = null;
                }

                applicationTaskLanguageChangedEventHandler -= value;
            }
        }

        private void OnNUIApplicationTaskLanguageChanged(IntPtr data)
        {
            if (applicationTaskLanguageChangedEventHandler != null)
            {
                NUIApplicationLanguageChangedEventArgs e = new NUIApplicationLanguageChangedEventArgs();
                e.Application = this;
                applicationTaskLanguageChangedEventHandler.Invoke(this, e);
            }
        }

        /// <summary>
        /// Event for TaskRegionChanged signal which can be used to subscribe/unsubscribe the event handler
        ///  provided by the user. TaskRegionChanged signal is emitted when the region of the device is changed.
        /// </summary>
        public event DaliEventHandler<object, NUIApplicationRegionChangedEventArgs> TaskRegionChanged
        {
            add
            {
                // Restricted to only one listener
                if (applicationTaskRegionChangedEventHandler == null)
                {
                    applicationTaskRegionChangedEventHandler += value;

                    applicationTaskRegionChangedEventCallbackDelegate = new NUIApplicationRegionChangedEventCallbackDelegate(OnNUIApplicationTaskRegionChanged);
                    taskRegionChangedSignal = this.TaskRegionChangedSignal();
                    taskRegionChangedSignal?.Connect(applicationTaskRegionChangedEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationTaskRegionChangedEventHandler != null)
                {
                    taskRegionChangedSignal?.Disconnect(applicationTaskRegionChangedEventCallbackDelegate);
                    taskRegionChangedSignal?.Dispose();
                    taskRegionChangedSignal = null;
                }

                applicationTaskRegionChangedEventHandler -= value;
            }
        }

        private void OnNUIApplicationTaskRegionChanged(IntPtr data)
        {
            if (applicationTaskRegionChangedEventHandler != null)
            {
                NUIApplicationRegionChangedEventArgs e = new NUIApplicationRegionChangedEventArgs();
                e.Application = this;
                applicationTaskRegionChangedEventHandler.Invoke(this, e);
            }
        }

        /// <summary>
        /// Event for TaskBatteryLow signal which can be used to subscribe/unsubscribe the event handler
        /// provided by the user. TaskBatteryLow signal is emitted when the battery level of the device is low.
        /// </summary>
        public event DaliEventHandler<object, NUIApplicationBatteryLowEventArgs> TaskBatteryLow
        {
            add
            {
                // Restricted to only one listener
                if (applicationTaskBatteryLowEventHandler == null)
                {
                    applicationTaskBatteryLowEventHandler += value;

                    applicationTaskBatteryLowEventCallbackDelegate = new NUIApplicationBatteryLowEventCallbackDelegate(OnNUIApplicationTaskBatteryLow);
                    taskBatteryLowSignal = this.TaskBatteryLowSignal();
                    taskBatteryLowSignal?.Connect(applicationTaskBatteryLowEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationTaskBatteryLowEventHandler != null)
                {
                    taskBatteryLowSignal?.Disconnect(applicationTaskBatteryLowEventCallbackDelegate);
                    taskBatteryLowSignal?.Dispose();
                    taskBatteryLowSignal = null;
                }

                applicationTaskBatteryLowEventHandler -= value;
            }
        }

        private void OnNUIApplicationTaskBatteryLow(BatteryStatus status)
        {
            NUIApplicationBatteryLowEventArgs e = new NUIApplicationBatteryLowEventArgs();

            // Populate all members of "e" (NUIApplicationBatteryLowEventArgs) with real data
            e.BatteryStatus = status;
            applicationTaskBatteryLowEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Event for TaskMemoryLow signal which can be used to subscribe/unsubscribe the event handler
        /// provided by the user. TaskMemoryLow signal is emitted when the memory level of the device is low.
        /// </summary>
        public event DaliEventHandler<object, NUIApplicationMemoryLowEventArgs> TaskMemoryLow
        {
            add
            {
                // Restricted to only one listener
                if (applicationTaskMemoryLowEventHandler == null)
                {
                    applicationTaskMemoryLowEventHandler += value;

                    applicationTaskMemoryLowEventCallbackDelegate = new NUIApplicationMemoryLowEventCallbackDelegate(OnNUIApplicationTaskMemoryLow);
                    taskMemoryLowSignal = this.TaskMemoryLowSignal();
                    taskMemoryLowSignal?.Connect(applicationTaskMemoryLowEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationTaskMemoryLowEventHandler != null)
                {
                    taskMemoryLowSignal?.Disconnect(applicationTaskMemoryLowEventCallbackDelegate);
                    taskMemoryLowSignal?.Dispose();
                    taskMemoryLowSignal = null;
                }

                applicationTaskMemoryLowEventHandler -= value;
            }
        }

        private void OnNUIApplicationTaskMemoryLow(MemoryStatus status)
        {
            NUIApplicationMemoryLowEventArgs e = new NUIApplicationMemoryLowEventArgs();

            // Populate all members of "e" (NUIApplicationMemoryLowEventArgs) with real data
            e.MemoryStatus = status;
            applicationTaskMemoryLowEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Event for TaskDeviceOrientationChanged signal which can be used to subscribe/unsubscribe the event handler
        /// provided by the user. TaskDeviceOrientationChanged signal is emitted when the device orientation is changed.
        /// </summary>
        public event DaliEventHandler<object, NUIApplicationDeviceOrientationChangedEventArgs> TaskDeviceOrientationChanged
        {
            add
            {
                if (applicationTaskDeviceOrientationChangedEventHandler == null)
                {
                    applicationTaskDeviceOrientationChangedEventHandler += value;

                    applicationTaskDeviceOrientationChangedEventCallback = new NUIApplicationDeviceOrientationChangedEventCallback(OnNUIApplicationTaskDeviceOrientationChanged);
                    taskDeviceOrientationChangedSignal = this.TaskDeviceOrientationChangedSignal();
                    taskDeviceOrientationChangedSignal?.Connect(applicationTaskDeviceOrientationChangedEventCallback);
                }
            }

            remove
            {
                if (applicationTaskDeviceOrientationChangedEventHandler != null)
                {
                    taskDeviceOrientationChangedSignal?.Disconnect(applicationTaskDeviceOrientationChangedEventCallback);
                    taskDeviceOrientationChangedSignal?.Dispose();
                    taskDeviceOrientationChangedSignal = null;
                }

                applicationTaskDeviceOrientationChangedEventHandler -= value;
            }
        }

        private void OnNUIApplicationTaskDeviceOrientationChanged(DeviceOrientationStatus status)
        {
            NUIApplicationDeviceOrientationChangedEventArgs e = new NUIApplicationDeviceOrientationChangedEventArgs();

            e.DeviceOrientationStatus = status;
            applicationTaskDeviceOrientationChangedEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Event for TaskAppControl signal which can be used to subscribe/unsubscribe the event handler
        /// provided by the user. TaskAppControl signal is emitted when another application sends a launch request to the application.
        /// </summary>
        public event DaliEventHandler<object, NUIApplicationAppControlEventArgs> TaskAppControl
        {
            add
            {
                // Restricted to only one listener
                if (applicationTaskAppControlEventHandler == null)
                {
                    applicationTaskAppControlEventHandler += value;

                    applicationTaskAppControlEventCallbackDelegate = new NUIApplicationAppControlEventCallbackDelegate(OnNUIApplicationTaskAppControl);
                    taskAppControlSignal = this.TaskAppControlSignal();
                    taskAppControlSignal?.Connect(applicationTaskAppControlEventCallbackDelegate);
                }
            }

            remove
            {
                if (applicationTaskAppControlEventHandler != null)
                {
                    taskAppControlSignal?.Disconnect(applicationTaskAppControlEventCallbackDelegate);
                    taskAppControlSignal?.Dispose();
                    taskAppControlSignal = null;
                }

                applicationTaskAppControlEventHandler -= value;
            }
        }

        private void OnNUIApplicationTaskAppControl(IntPtr application, IntPtr voidp)
        {
            if (applicationTaskAppControlEventHandler != null)
            {
                NUIApplicationAppControlEventArgs e = new NUIApplicationAppControlEventArgs();
                e.VoidP = voidp;
                e.Application = this;
                applicationTaskAppControlEventHandler.Invoke(this, e);
            }
        }

        protected static Application instance; // singleton

        public static Application Instance
        {
            get
            {
                return instance;
            }
        }

        public static Application GetApplicationFromPtr(global::System.IntPtr cPtr)
        {
            if (cPtr == global::System.IntPtr.Zero)
            {
                return null;
            }

            Application ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Application;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application NewApplication()
        {
            return NewApplication("", NUIApplication.WindowMode.Opaque);
        }

        public static Application NewApplication(string stylesheet)
        {
            return NewApplication(stylesheet, NUIApplication.WindowMode.Opaque);
        }

        public static Application NewApplication(string stylesheet, NUIApplication.WindowMode windowMode)
        {
            // register all Views with the type registry, so that can be created / styled via JSON
            //ViewRegistryHelper.Initialize(); //moved to Application side.
            if (instance != null)
            {
                return instance;
            }

            Application ret = New(1, stylesheet, windowMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            instance = ret;
            return ret;
        }

        public static Application NewApplication(string stylesheet, NUIApplication.WindowMode windowMode, Rectangle positionSize)
        {
            if (instance != null)
            {
                return instance;
            }
            Application ret = New(1, stylesheet, windowMode, positionSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            instance = ret;
            return ret;
        }

        public static Application NewApplication(string[] args, string stylesheet, NUIApplication.WindowMode windowMode)
        {
            if (instance != null)
            {
                return instance;
            }
            Application ret = New(args, stylesheet, windowMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            instance = ret;
            return instance;
        }

        public static Application NewApplication(string[] args, string stylesheet, NUIApplication.WindowMode windowMode, Rectangle positionSize)
        {
            if (instance != null)
            {
                return instance;
            }
            Application ret = New(args, stylesheet, windowMode, positionSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            instance = ret;
            return instance;
        }

        public static Application NewApplication(string stylesheet, NUIApplication.WindowMode windowMode, WindowType type)
        {
            if (instance != null)
            {
                return instance;
            }
            Application ret = New(1, stylesheet, windowMode, type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            instance = ret;
            return instance;
        }

        public static Application NewApplication(string[] args, string stylesheet, NUIApplication.WindowMode windowMode, Rectangle positionSize, bool useUIThread)
        {
            if (instance != null)
            {
                return instance;
            }
            Application ret = New(args, stylesheet, windowMode, positionSize, useUIThread);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            instance = ret;
            return instance;
        }

        public static Application NewApplication(string[] args, string stylesheet, bool useUIThread, WindowData windowData)
        {
            if (instance != null)
            {
                return instance;
            }
            Application ret = New(args, stylesheet, useUIThread, windowData);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            instance = ret;
            return instance;
        }

        /// <summary>
        /// Ensures that the function passed in is called from the main loop when it is idle.
        /// </summary>
        /// <param name="func">The function to call</param>
        /// <returns>true if added successfully, false otherwise</returns>
        /// <remarks>
        /// It will return false when one of the following conditions is met.
        /// 1) the <see cref="Window"/> is hidden.
        /// 2) the <see cref="Window"/> is iconified.
        /// </remarks>
        public bool AddIdle(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            System.IntPtr ip2 = Interop.Application.MakeCallback(new System.Runtime.InteropServices.HandleRef(this, ip));

            bool ret = Interop.Application.AddIdle(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip2));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /**
        * Outer::outer_method(int)
        */
        public static Application New()
        {
            Application ret = new Application(Interop.Application.New(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(int argc)
        {
            Application ret = new Application(Interop.Application.New(argc), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(int argc, string stylesheet)
        {
            Application ret = new Application(Interop.Application.New(argc, stylesheet), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(int argc, string stylesheet, NUIApplication.WindowMode windowMode)
        {
            Application ret = new Application(Interop.Application.New(argc, stylesheet, (int)windowMode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            s_current = ret;
            return ret;
        }

        public static Application New(string[] args, string stylesheet, NUIApplication.WindowMode windowMode)
        {
            Application ret = null;
            int argc = 0;
            string argvStr = "";
            try
            {
                argc = args.Length;
                argvStr = string.Join(" ", args);
            }
            catch (Exception exception)
            {
                Tizen.Log.Fatal("NUI", "[Error] got exception during Application New(), this should not occur, message : " + exception.Message);
                Tizen.Log.Fatal("NUI", "[Error] error line number : " + new StackTrace(exception, true).GetFrame(0).GetFileLineNumber());
                Tizen.Log.Fatal("NUI", "[Error] Stack Trace : " + exception.StackTrace);
                throw;
            }

            ret = new Application(NDalicPINVOKE.ApplicationNewManual4(argc, argvStr, stylesheet, (int)windowMode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        public static Application New(int argc, string stylesheet, NUIApplication.WindowMode windowMode, Rectangle positionSize)
        {
            Application ret = new Application(Interop.Application.New(argc, stylesheet, (int)windowMode, Rectangle.getCPtr(positionSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(string[] args, string stylesheet, NUIApplication.WindowMode windowMode, Rectangle positionSize)
        {
            Application ret = null;
            int argc = 0;
            string argvStr = "";
            try
            {
                argc = args.Length;
                argvStr = string.Join(" ", args);
            }
            catch (Exception exception)
            {
                Tizen.Log.Fatal("NUI", "[Error] got exception during Application New(), this should not occur, message : " + exception.Message);
                Tizen.Log.Fatal("NUI", "[Error] error line number : " + new StackTrace(exception, true).GetFrame(0).GetFileLineNumber());
                Tizen.Log.Fatal("NUI", "[Error] Stack Trace : " + exception.StackTrace);
                throw;
            }

            ret = new Application(NDalicPINVOKE.ApplicationNewWithWindowSizePosition(argc, argvStr, stylesheet, (int)windowMode, Rectangle.getCPtr(positionSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        public static Application New(int argc, string stylesheet, NUIApplication.WindowMode windowMode, WindowType type)
        {
            // It will be removed until dali APIs are prepared.
            Rectangle initRectangle = new Rectangle(0, 0, 0, 0);

            Application ret = new Application(Interop.Application.New(argc, stylesheet, (int)windowMode, Rectangle.getCPtr(initRectangle), (int)type), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(string[] args, string stylesheet, NUIApplication.WindowMode windowMode, Rectangle positionSize, bool useUIThread)
        {
            Application ret = null;
            int argc = 0;
            string argvStr = "";
            try
            {
                argc = args.Length;
                argvStr = string.Join(" ", args);

                ret = new Application(Interop.Application.New(argc, stylesheet, (int)windowMode, Rectangle.getCPtr(positionSize), useUIThread), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            catch (Exception exception)
            {
                Tizen.Log.Fatal("NUI", "[Error] got exception during Application New(), this should not occur, message : " + exception.Message);
                Tizen.Log.Fatal("NUI", "[Error] error line number : " + new StackTrace(exception, true).GetFrame(0).GetFileLineNumber());
                Tizen.Log.Fatal("NUI", "[Error] Stack Trace : " + exception.StackTrace);
                throw;
            }

            return ret;
        }

        public static Application New(string[] args, string stylesheet, bool useUIThread, WindowData windowData)
        {
            Application ret = null;
            int argc = 0;
            string argvStr = "";
            try
            {
                argc = args.Length;
                argvStr = string.Join(" ", args);

                ret = new Application(Interop.Application.New(argc, argvStr, stylesheet, useUIThread, WindowData.getCPtr(windowData)), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            catch (Exception exception)
            {
                Tizen.Log.Fatal("NUI", "[Error] got exception during Application New(), this should not occur, message : " + exception.Message);
                Tizen.Log.Fatal("NUI", "[Error] error line number : " + new StackTrace(exception, true).GetFrame(0).GetFileLineNumber());
                Tizen.Log.Fatal("NUI", "[Error] Stack Trace : " + exception.StackTrace);
                throw;
            }

            return ret;
        }

        public Application() : this(Interop.Application.NewApplication(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Application(Application application) : this(Interop.Application.NewApplication(Application.getCPtr(application)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Application Assign(Application application)
        {
            Application ret = new Application(Interop.Application.Assign(SwigCPtr, Application.getCPtr(application)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void MainLoop()
        {
            NDalicPINVOKE.ApplicationMainLoop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Lower()
        {
            Interop.Application.Lower(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Quit()
        {
            Interop.Application.Quit(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool AddIdle(SWIGTYPE_p_Dali__CallbackBase callback)
        {
            bool ret = Interop.Application.AddIdle(SwigCPtr, SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Window GetWindow()
        {
            if (window != null)
            {
                return window;
            }

            var nativeWindow = Interop.Application.GetWindow(SwigCPtr);
            window = Registry.GetManagedBaseHandleFromNativePtr(nativeWindow) as Window;
            if (window != null)
            {
                HandleRef CPtr = new HandleRef(this, nativeWindow);
                Interop.BaseHandle.DeleteBaseHandle(CPtr);
                CPtr = new HandleRef(null, IntPtr.Zero);
            }
            else
            {
                window = new Window(nativeWindow, true);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return window;
        }

        public static string GetResourcePath()
        {
            string ret = Interop.Application.GetResourcePath();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetLanguage()
        {
            string ret = Interop.Application.GetLanguage(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetRegion()
        {
            string ret = Interop.Application.GetRegion(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static List<Window> GetWindowList()
        {
            uint ListSize = Interop.Application.GetWindowsListSize();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            List<Window> WindowList = new List<Window>();
            for (uint i = 0; i < ListSize; ++i)
            {
                Window currWin = WindowList.GetInstanceSafely<Window>(Interop.Application.GetWindowsFromList(i));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                if (currWin != null)
                {
                    WindowList.Add(currWin);
                }
            }
            return WindowList;
        }

        internal ApplicationSignal InitSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationInitSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal TerminateSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationTerminateSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal PauseSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationPauseSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal ResumeSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationResumeSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal ResetSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationResetSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationControlSignal AppControlSignal()
        {
            ApplicationControlSignal ret = new ApplicationControlSignal(NDalicPINVOKE.ApplicationAppControlSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal LanguageChangedSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationLanguageChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal RegionChangedSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationRegionChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LowBatterySignalType BatteryLowSignal()
        {
            LowBatterySignalType ret = new LowBatterySignalType(NDalicPINVOKE.ApplicationLowBatterySignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LowMemorySignalType MemoryLowSignal()
        {
            LowMemorySignalType ret = new LowMemorySignalType(NDalicPINVOKE.ApplicationLowMemorySignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal DeviceOrientationChangedSignalType DeviceOrientationChangedSignal()
        {
            DeviceOrientationChangedSignalType ret = new DeviceOrientationChangedSignalType(NDalicPINVOKE.ApplicationDeviceOrientationChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        //Task
        internal ApplicationSignal TaskInitSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationTaskInitSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal TaskTerminateSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationTaskTerminateSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationControlSignal TaskAppControlSignal()
        {
            ApplicationControlSignal ret = new ApplicationControlSignal(NDalicPINVOKE.ApplicationTaskAppControlSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal TaskLanguageChangedSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationTaskLanguageChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ApplicationSignal TaskRegionChangedSignal()
        {
            ApplicationSignal ret = new ApplicationSignal(NDalicPINVOKE.ApplicationTaskRegionChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LowBatterySignalType TaskBatteryLowSignal()
        {
            LowBatterySignalType ret = new LowBatterySignalType(NDalicPINVOKE.ApplicationTaskLowBatterySignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LowMemorySignalType TaskMemoryLowSignal()
        {
            LowMemorySignalType ret = new LowMemorySignalType(NDalicPINVOKE.ApplicationTaskLowMemorySignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal DeviceOrientationChangedSignalType TaskDeviceOrientationChangedSignal()
        {
            DeviceOrientationChangedSignalType ret = new DeviceOrientationChangedSignalType(NDalicPINVOKE.ApplicationTaskDeviceOrientationChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
