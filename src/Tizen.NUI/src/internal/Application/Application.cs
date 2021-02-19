/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using System.Threading;
using System.Threading.Tasks;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI
{
    /**
      * @brief Event arguments that passed via NUIApplicationInit signal
      *
      */
    internal class NUIApplicationInitEventArgs : EventArgs
    {
        private Application _application;

        /**
          * @brief Application - is the application that is being initialized
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationTerminate signal
      *
      */
    internal class NUIApplicationTerminatingEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Terminated
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationPause signal
      *
      */
    internal class NUIApplicationPausedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Paused
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationResume signal
      *
      */
    internal class NUIApplicationResumedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Resumed
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationReset signal
      *
      */
    internal class NUIApplicationResetEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being Reset
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationLanguageChanged signal
      *
      */
    internal class NUIApplicationLanguageChangedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being affected with Device's language change
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationRegionChanged signal
      *
      */
    internal class NUIApplicationRegionChangedEventArgs : EventArgs
    {
        private Application _application;
        /**
          * @brief Application - is the application that is being affected with Device's region change
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationBatteryLow signal
      *
      */
    internal class NUIApplicationBatteryLowEventArgs : EventArgs
    {
        private Application.BatteryStatus _status;
        /**
          * @brief Application - is the application that is being affected when the battery level of the device is low
          *
          */
        public Application.BatteryStatus BatteryStatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationMemoryLow signal
      *
      */
    internal class NUIApplicationMemoryLowEventArgs : EventArgs
    {
        private Application.MemoryStatus _status;
        /**
          * @brief Application - is the application that is being affected when the memory level of the device is low
          *
          */
        public Application.MemoryStatus MemoryStatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
    }

    /**
      * @brief Event arguments that passed via NUIApplicationAppControl	 signal
      *
      */
    internal class NUIApplicationAppControlEventArgs : EventArgs
    {
        private Application _application;
        private IntPtr _voidp;
        /**
          * @brief Application - is the application that is receiving the launch request from another application
          *
          */
        public Application Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
            }
        }
        /**
          * @brief VoidP - contains the information about why the application is launched
          *
          */
        public IntPtr VoidP
        {
            get
            {
                return _voidp;
            }
            set
            {
                _voidp = value;
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

        ReadOnlyCollection<Element> _logicalChildren;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetCurrentApplication(Application value) => Current = value;

        public static Application Current
        {
            get { return s_current; }
            set
            {
                if (s_current == value)
                    return;
                if (value == null)
                    s_current = null; //Allow to reset current for unittesting
                s_current = value;
            }
        }

        internal override ReadOnlyCollection<Element> LogicalChildrenInternal
        {
            get { return _logicalChildren ?? (_logicalChildren = new ReadOnlyCollection<Element>(InternalChildren)); }
        }

        internal IResourceDictionary SystemResources { get; }

        ObservableCollection<Element> InternalChildren { get; } = new ObservableCollection<Element>();

        ResourceDictionary _resources;
        public bool IsResourcesCreated => _resources != null;

        public delegate void resChangeCb(object sender, ResourcesChangedEventArgs e);

        static private Dictionary<object, Dictionary<resChangeCb, int>> resourceChangeCallbackDict = new Dictionary<object, Dictionary<resChangeCb, int>>();
        static public void AddResourceChangedCallback(object handle, resChangeCb cb)
        {
            Dictionary<resChangeCb, int> cbDict;
            resourceChangeCallbackDict.TryGetValue(handle, out cbDict);

            if (null == cbDict)
            {
                cbDict = new Dictionary<resChangeCb, int>();
                resourceChangeCallbackDict.Add(handle, cbDict);
            }

            if (false == cbDict.ContainsKey(cb))
            {
                cbDict.Add(cb, 0);
            }
        }

        internal override void OnResourcesChanged(object sender, ResourcesChangedEventArgs e)
        {
            base.OnResourcesChanged(sender, e);

            foreach (KeyValuePair<object, Dictionary<resChangeCb, int>> resourcePair in resourceChangeCallbackDict)
            {
                foreach (KeyValuePair<resChangeCb, int> cbPair in resourcePair.Value)
                {
                    cbPair.Key(sender, e);
                }
            }
        }

        public ResourceDictionary XamlResources
        {
            get
            {
                if (_resources != null)
                    return _resources;

                _resources = new ResourceDictionary();
                int hashCode = _resources.GetHashCode();
                ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                return _resources;
            }
            set
            {
                if (_resources == value)
                    return;
                OnPropertyChanging();

                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged -= OnResourcesChanged;
                _resources = value;
                OnResourcesChanged(value);
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;

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
            OnResourcesChanged(changedResources);
        }


        internal Application(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            SetCurrentApplication(this);


            s_current = this;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Application obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
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

            if (_applicationInitEventCallbackDelegate != null)
            {
                initSignal?.Disconnect(_applicationInitEventCallbackDelegate);
                initSignal?.Dispose();
                initSignal = null;
            }

            if (_applicationTerminateEventCallbackDelegate != null)
            {
                terminateSignal?.Disconnect(_applicationTerminateEventCallbackDelegate);
                terminateSignal?.Dispose();
                terminateSignal = null;
            }

            if (_applicationPauseEventCallbackDelegate != null)
            {
                pauseSignal?.Disconnect(_applicationPauseEventCallbackDelegate);
                pauseSignal?.Dispose();
                pauseSignal = null;
            }

            if (_applicationResumeEventCallbackDelegate != null)
            {
                resumeSignal?.Disconnect(_applicationResumeEventCallbackDelegate);
                resumeSignal?.Dispose();
                resumeSignal = null;
            }

            if (_applicationResetEventCallbackDelegate != null)
            {
                resetSignal?.Disconnect(_applicationResetEventCallbackDelegate);
                resetSignal?.Dispose();
                resetSignal = null;
            }

            if (_applicationLanguageChangedEventCallbackDelegate != null)
            {
                languageChangedSignal?.Disconnect(_applicationLanguageChangedEventCallbackDelegate);
                languageChangedSignal?.Dispose();
                languageChangedSignal = null;
            }

            if (_applicationRegionChangedEventCallbackDelegate != null)
            {
                regionChangedSignal?.Disconnect(_applicationRegionChangedEventCallbackDelegate);
                regionChangedSignal?.Dispose();
                regionChangedSignal = null;
            }

            if (_applicationBatteryLowEventCallbackDelegate != null)
            {
                batteryLowSignal?.Disconnect(_applicationBatteryLowEventCallbackDelegate);
                batteryLowSignal?.Dispose();
                batteryLowSignal = null;
            }

            if (_applicationMemoryLowEventCallbackDelegate != null)
            {
                memoryLowSignal?.Disconnect(_applicationMemoryLowEventCallbackDelegate);
                memoryLowSignal?.Dispose();
                memoryLowSignal = null;
            }

            if (_applicationAppControlEventCallbackDelegate != null)
            {
                appControlSignal?.Disconnect(_applicationAppControlEventCallbackDelegate);
                appControlSignal?.Dispose();
                appControlSignal = null;
            }

            win?.Dispose();
            win = null;

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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationInitEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationInitEventArgs> _applicationInitEventHandler;
        private NUIApplicationInitEventCallbackDelegate _applicationInitEventCallbackDelegate;
        private ApplicationSignal initSignal;


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationTerminateEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationTerminatingEventArgs> _applicationTerminateEventHandler;
        private NUIApplicationTerminateEventCallbackDelegate _applicationTerminateEventCallbackDelegate;
        private ApplicationSignal terminateSignal;


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationPauseEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationPausedEventArgs> _applicationPauseEventHandler;
        private NUIApplicationPauseEventCallbackDelegate _applicationPauseEventCallbackDelegate;
        private ApplicationSignal pauseSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationResumeEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationResumedEventArgs> _applicationResumeEventHandler;
        private NUIApplicationResumeEventCallbackDelegate _applicationResumeEventCallbackDelegate;
        private ApplicationSignal resumeSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationResetEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationResetEventArgs> _applicationResetEventHandler;
        private NUIApplicationResetEventCallbackDelegate _applicationResetEventCallbackDelegate;
        private ApplicationSignal resetSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationLanguageChangedEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationLanguageChangedEventArgs> _applicationLanguageChangedEventHandler;
        private NUIApplicationLanguageChangedEventCallbackDelegate _applicationLanguageChangedEventCallbackDelegate;
        private ApplicationSignal languageChangedSignal;


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationRegionChangedEventCallbackDelegate(IntPtr application);
        private DaliEventHandler<object, NUIApplicationRegionChangedEventArgs> _applicationRegionChangedEventHandler;
        private NUIApplicationRegionChangedEventCallbackDelegate _applicationRegionChangedEventCallbackDelegate;
        private ApplicationSignal regionChangedSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationBatteryLowEventCallbackDelegate(BatteryStatus status);
        private DaliEventHandler<object, NUIApplicationBatteryLowEventArgs> _applicationBatteryLowEventHandler;
        private NUIApplicationBatteryLowEventCallbackDelegate _applicationBatteryLowEventCallbackDelegate;
        private LowBatterySignalType batteryLowSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationMemoryLowEventCallbackDelegate(MemoryStatus status);
        private DaliEventHandler<object, NUIApplicationMemoryLowEventArgs> _applicationMemoryLowEventHandler;
        private NUIApplicationMemoryLowEventCallbackDelegate _applicationMemoryLowEventCallbackDelegate;
        private LowMemorySignalType memoryLowSignal;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void NUIApplicationAppControlEventCallbackDelegate(IntPtr application, IntPtr voidp);
        private DaliEventHandler<object, NUIApplicationAppControlEventArgs> _applicationAppControlEventHandler;
        private NUIApplicationAppControlEventCallbackDelegate _applicationAppControlEventCallbackDelegate;
        private ApplicationControlSignal appControlSignal;

        private Window win;

        /**
          * @brief Event for Initialized signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Initialized signal is emitted when application is initialised
          */
        public event DaliEventHandler<object, NUIApplicationInitEventArgs> Initialized
        {
            add
            {
                // Restricted to only one listener
                if (_applicationInitEventHandler == null)
                {
                    _applicationInitEventHandler += value;
                    _applicationInitEventCallbackDelegate = new NUIApplicationInitEventCallbackDelegate(OnApplicationInit);
                    initSignal = this.InitSignal();
                    initSignal?.Connect(_applicationInitEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationInitEventHandler != null)
                {
                    initSignal?.Disconnect(_applicationInitEventCallbackDelegate);
                    initSignal?.Dispose();
                    initSignal = null;
                }

                _applicationInitEventHandler -= value;
            }
        }

        // Callback for Application InitSignal
        private void OnApplicationInit(IntPtr data)
        {
            // Initialize DisposeQueue Singleton class. This is also required to create DisposeQueue on main thread.
            DisposeQueue.Instance.Initialize();

            // Notify that the window is displayed to the app core.
            if (NUIApplication.IsPreload)
            {
                Window.Instance.Show();
            }

            if (_applicationInitEventHandler != null)
            {
                NUIApplicationInitEventArgs e = new NUIApplicationInitEventArgs();
                e.Application = this;
                _applicationInitEventHandler.Invoke(this, e);
            }

        }

        /**
          * @brief Event for Terminated signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Terminated signal is emitted when application is terminating
          */
        public event DaliEventHandler<object, NUIApplicationTerminatingEventArgs> Terminating
        {
            add
            {
                // Restricted to only one listener
                if (_applicationTerminateEventHandler == null)
                {
                    _applicationTerminateEventHandler += value;

                    _applicationTerminateEventCallbackDelegate = new NUIApplicationTerminateEventCallbackDelegate(OnNUIApplicationTerminate);
                    terminateSignal = this.TerminateSignal();
                    terminateSignal?.Connect(_applicationTerminateEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationTerminateEventHandler != null)
                {
                    terminateSignal?.Disconnect(_applicationTerminateEventCallbackDelegate);
                    terminateSignal?.Dispose();
                    terminateSignal = null;
                }

                _applicationTerminateEventHandler -= value;
            }
        }

        // Callback for Application TerminateSignal
        private void OnNUIApplicationTerminate(IntPtr data)
        {
            if (_applicationTerminateEventHandler != null)
            {
                NUIApplicationTerminatingEventArgs e = new NUIApplicationTerminatingEventArgs();
                e.Application = this;
                _applicationTerminateEventHandler.Invoke(this, e);
            }

            List<Window> windows = GetWindowList();
            foreach (Window window in windows)
            {
                window?.DisconnectNativeSignals();
            }
        }

        /**
          * @brief Event for Paused signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. Paused signal is emitted when application is paused
          */
        public event DaliEventHandler<object, NUIApplicationPausedEventArgs> Paused
        {
            add
            {
                // Restricted to only one listener
                if (_applicationPauseEventHandler == null)
                {
                    _applicationPauseEventHandler += value;

                    _applicationPauseEventCallbackDelegate = new NUIApplicationPauseEventCallbackDelegate(OnNUIApplicationPause);
                    pauseSignal = this.PauseSignal();
                    pauseSignal?.Connect(_applicationPauseEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationPauseEventHandler != null)
                {
                    pauseSignal?.Disconnect(_applicationPauseEventCallbackDelegate);
                    pauseSignal?.Dispose();
                    pauseSignal = null;
                }

                _applicationPauseEventHandler -= value;
            }
        }

        // Callback for Application PauseSignal
        private void OnNUIApplicationPause(IntPtr data)
        {
            if (_applicationPauseEventHandler != null)
            {
                NUIApplicationPausedEventArgs e = new NUIApplicationPausedEventArgs();
                e.Application = this;
                _applicationPauseEventHandler.Invoke(this, e);
            }
        }

        /**
          * @brief Event for Resumed signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Resumed signal is emitted when application is resumed
          */
        public event DaliEventHandler<object, NUIApplicationResumedEventArgs> Resumed
        {
            add
            {
                // Restricted to only one listener
                if (_applicationResumeEventHandler == null)
                {
                    _applicationResumeEventHandler += value;

                    _applicationResumeEventCallbackDelegate = new NUIApplicationResumeEventCallbackDelegate(OnNUIApplicationResume);
                    resumeSignal = this.ResumeSignal();
                    resumeSignal?.Connect(_applicationResumeEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationResumeEventHandler != null)
                {
                    resumeSignal?.Disconnect(_applicationResumeEventCallbackDelegate);
                    resumeSignal?.Dispose();
                    resumeSignal = null;
                }

                _applicationResumeEventHandler -= value;
            }
        }

        // Callback for Application ResumeSignal
        private void OnNUIApplicationResume(IntPtr data)
        {
            if (_applicationResumeEventHandler != null)
            {
                NUIApplicationResumedEventArgs e = new NUIApplicationResumedEventArgs();
                e.Application = this;
                _applicationResumeEventHandler.Invoke(this, e);
            }
        }

        /**
          * @brief Event for Reset signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. Reset signal is emitted when application is reset
          */
        public new event DaliEventHandler<object, NUIApplicationResetEventArgs> Reset
        {
            add
            {
                // Restricted to only one listener
                if (_applicationResetEventHandler == null)
                {
                    _applicationResetEventHandler += value;

                    _applicationResetEventCallbackDelegate = new NUIApplicationResetEventCallbackDelegate(OnNUIApplicationReset);
                    resetSignal = this.ResetSignal();
                    resetSignal?.Connect(_applicationResetEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationResetEventHandler != null)
                {
                    resetSignal?.Disconnect(_applicationResetEventCallbackDelegate);
                    resetSignal?.Dispose();
                    resetSignal = null;
                }

                _applicationResetEventHandler -= value;
            }
        }

        // Callback for Application ResetSignal
        private void OnNUIApplicationReset(IntPtr data)
        {
            if (_applicationResetEventHandler != null)
            {
                NUIApplicationResetEventArgs e = new NUIApplicationResetEventArgs();
                e.Application = this;
                _applicationResetEventHandler.Invoke(this, e);
            }
        }

        /**
          * @brief Event for LanguageChanged signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. LanguageChanged signal is emitted when the region of the device is changed.
          */
        public event DaliEventHandler<object, NUIApplicationLanguageChangedEventArgs> LanguageChanged
        {
            add
            {
                // Restricted to only one listener
                if (_applicationLanguageChangedEventHandler == null)
                {
                    _applicationLanguageChangedEventHandler += value;

                    _applicationLanguageChangedEventCallbackDelegate = new NUIApplicationLanguageChangedEventCallbackDelegate(OnNUIApplicationLanguageChanged);
                    languageChangedSignal = this.LanguageChangedSignal();
                    languageChangedSignal?.Connect(_applicationLanguageChangedEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationLanguageChangedEventHandler != null)
                {
                    languageChangedSignal?.Disconnect(_applicationLanguageChangedEventCallbackDelegate);
                    languageChangedSignal?.Dispose();
                    languageChangedSignal = null;
                }

                _applicationLanguageChangedEventHandler -= value;
            }
        }

        // Callback for Application LanguageChangedSignal
        private void OnNUIApplicationLanguageChanged(IntPtr data)
        {
            if (_applicationLanguageChangedEventHandler != null)
            {
                NUIApplicationLanguageChangedEventArgs e = new NUIApplicationLanguageChangedEventArgs();
                e.Application = this;
                _applicationLanguageChangedEventHandler.Invoke(this, e);
            }
        }

        /**
          * @brief Event for RegionChanged signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. RegionChanged signal is emitted when the region of the device is changed.
          */
        public event DaliEventHandler<object, NUIApplicationRegionChangedEventArgs> RegionChanged
        {
            add
            {
                // Restricted to only one listener
                if (_applicationRegionChangedEventHandler == null)
                {
                    _applicationRegionChangedEventHandler += value;

                    _applicationRegionChangedEventCallbackDelegate = new NUIApplicationRegionChangedEventCallbackDelegate(OnNUIApplicationRegionChanged);
                    regionChangedSignal = this.RegionChangedSignal();
                    regionChangedSignal?.Connect(_applicationRegionChangedEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationRegionChangedEventHandler != null)
                {
                    regionChangedSignal?.Disconnect(_applicationRegionChangedEventCallbackDelegate);
                    regionChangedSignal?.Dispose();
                    regionChangedSignal = null;
                }

                _applicationRegionChangedEventHandler -= value;
            }
        }

        // Callback for Application RegionChangedSignal
        private void OnNUIApplicationRegionChanged(IntPtr data)
        {
            if (_applicationRegionChangedEventHandler != null)
            {
                NUIApplicationRegionChangedEventArgs e = new NUIApplicationRegionChangedEventArgs();
                e.Application = this;
                _applicationRegionChangedEventHandler.Invoke(this, e);
            }
        }

        /**
          * @brief Event for BatteryLow signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. BatteryLow signal is emitted when the battery level of the device is low.
          */
        public event DaliEventHandler<object, NUIApplicationBatteryLowEventArgs> BatteryLow
        {
            add
            {
                // Restricted to only one listener
                if (_applicationBatteryLowEventHandler == null)
                {
                    _applicationBatteryLowEventHandler += value;

                    _applicationBatteryLowEventCallbackDelegate = new NUIApplicationBatteryLowEventCallbackDelegate(OnNUIApplicationBatteryLow);
                    batteryLowSignal = this.BatteryLowSignal();
                    batteryLowSignal?.Connect(_applicationBatteryLowEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationBatteryLowEventHandler != null)
                {
                    batteryLowSignal?.Disconnect(_applicationBatteryLowEventCallbackDelegate);
                    batteryLowSignal?.Dispose();
                    batteryLowSignal = null;
                }

                _applicationBatteryLowEventHandler -= value;
            }
        }

        // Callback for Application BatteryLowSignal
        private void OnNUIApplicationBatteryLow(BatteryStatus status)
        {
            NUIApplicationBatteryLowEventArgs e = new NUIApplicationBatteryLowEventArgs();

            // Populate all members of "e" (NUIApplicationBatteryLowEventArgs) with real data
            e.BatteryStatus = status;
            _applicationBatteryLowEventHandler?.Invoke(this, e);
        }

        /**
          * @brief Event for MemoryLow signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. MemoryLow signal is emitted when the memory level of the device is low.
          */
        public event DaliEventHandler<object, NUIApplicationMemoryLowEventArgs> MemoryLow
        {
            add
            {
                // Restricted to only one listener
                if (_applicationMemoryLowEventHandler == null)
                {
                    _applicationMemoryLowEventHandler += value;

                    _applicationMemoryLowEventCallbackDelegate = new NUIApplicationMemoryLowEventCallbackDelegate(OnNUIApplicationMemoryLow);
                    memoryLowSignal = this.MemoryLowSignal();
                    memoryLowSignal?.Connect(_applicationMemoryLowEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationMemoryLowEventHandler != null)
                {
                    memoryLowSignal?.Disconnect(_applicationMemoryLowEventCallbackDelegate);
                    memoryLowSignal?.Dispose();
                    memoryLowSignal = null;
                }

                _applicationMemoryLowEventHandler -= value;
            }
        }

        // Callback for Application MemoryLowSignal
        private void OnNUIApplicationMemoryLow(MemoryStatus status)
        {
            NUIApplicationMemoryLowEventArgs e = new NUIApplicationMemoryLowEventArgs();

            // Populate all members of "e" (NUIApplicationMemoryLowEventArgs) with real data
            e.MemoryStatus = status;
            _applicationMemoryLowEventHandler?.Invoke(this, e);
        }

        /**
          * @brief Event for AppControl signal which can be used to subscribe/unsubscribe the event handler
          *  provided by the user. AppControl signal is emitted when another application sends a launch request to the application.
          */
        public event DaliEventHandler<object, NUIApplicationAppControlEventArgs> AppControl
        {
            add
            {
                // Restricted to only one listener
                if (_applicationAppControlEventHandler == null)
                {
                    _applicationAppControlEventHandler += value;

                    _applicationAppControlEventCallbackDelegate = new NUIApplicationAppControlEventCallbackDelegate(OnNUIApplicationAppControl);
                    appControlSignal = this.AppControlSignal();
                    appControlSignal?.Connect(_applicationAppControlEventCallbackDelegate);
                }
            }

            remove
            {
                if (_applicationAppControlEventHandler != null)
                {
                    appControlSignal?.Disconnect(_applicationAppControlEventCallbackDelegate);
                    appControlSignal?.Dispose();
                    appControlSignal = null;
                }

                _applicationAppControlEventHandler -= value;
            }
        }

        // Callback for Application AppControlSignal
        private void OnNUIApplicationAppControl(IntPtr application, IntPtr voidp)
        {
            if (_applicationAppControlEventHandler != null)
            {
                NUIApplicationAppControlEventArgs e = new NUIApplicationAppControlEventArgs();
                e.VoidP = voidp;
                e.Application = this;
                _applicationAppControlEventHandler.Invoke(this, e);
            }
        }

        protected static Application _instance; // singleton

        public static Application Instance
        {
            get
            {
                return _instance;
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
            return NewApplication("", Application.WindowMode.Opaque);
        }

        public static Application NewApplication(string stylesheet)
        {
            return NewApplication(stylesheet, Application.WindowMode.Opaque);
        }

        public static Application NewApplication(string stylesheet, Application.WindowMode windowMode)
        {
            // register all Views with the type registry, so that can be created / styled via JSON
            //ViewRegistryHelper.Initialize(); //moved to Application side.
            if (_instance)
            {
                return _instance;
            }

            Application ret = New(1, stylesheet, windowMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            _instance = ret;
            return ret;
        }

        public static Application NewApplication(string stylesheet, Application.WindowMode windowMode, Rectangle positionSize)
        {
            if (_instance)
            {
                return _instance;
            }
            Application ret = New(1, stylesheet, windowMode, positionSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            _instance = ret;
            return ret;
        }

        public static Application NewApplication(string[] args, string stylesheet, Application.WindowMode windowMode)
        {
            if (_instance)
            {
                return _instance;
            }
            Application ret = New(args, stylesheet, (Application.WindowMode)windowMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            _instance = ret;
            return _instance;
        }

        public static Application NewApplication(string[] args, string stylesheet, Application.WindowMode windowMode, Rectangle positionSize)
        {
            if (_instance)
            {
                return _instance;
            }
            Application ret = New(args, stylesheet, (Application.WindowMode)windowMode, positionSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            // set the singleton
            _instance = ret;
            return _instance;
        }

        /// <summary>
        /// Ensures that the function passed in is called from the main loop when it is idle.
        /// </summary>
        /// <param name="func">The function to call</param>
        /// <returns>true if added successfully, false otherwise</returns>
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

        public static Application New(int argc, string stylesheet, Application.WindowMode windowMode)
        {
            Application ret = new Application(Interop.Application.New(argc, stylesheet, (int)windowMode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            s_current = ret;
            return ret;
        }

        public static Application New(string[] args, string stylesheet, Application.WindowMode windowMode)
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
                Tizen.Log.Fatal("NUI", "[Error] got exception during Application New(), this should not occur, msg : " + exception.Message);
                Tizen.Log.Fatal("NUI", "[Error] error line number : " + new StackTrace(exception, true).GetFrame(0).GetFileLineNumber());
                Tizen.Log.Fatal("NUI", "[Error] Stack Trace : " + exception.StackTrace);
                throw;
            }

            ret = new Application(NDalicPINVOKE.ApplicationNewManual4(argc, argvStr, stylesheet, (int)windowMode), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        public static Application New(int argc, string stylesheet, Application.WindowMode windowMode, Rectangle positionSize)
        {
            Application ret = new Application(Interop.Application.New(argc, stylesheet, (int)windowMode, Rectangle.getCPtr(positionSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static Application New(string[] args, string stylesheet, Application.WindowMode windowMode, Rectangle positionSize)
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
                Tizen.Log.Fatal("NUI", "[Error] got exception during Application New(), this should not occur, msg : " + exception.Message);
                Tizen.Log.Fatal("NUI", "[Error] error line number : " + new StackTrace(exception, true).GetFrame(0).GetFileLineNumber());
                Tizen.Log.Fatal("NUI", "[Error] Stack Trace : " + exception.StackTrace);
                throw;
            }

            ret = new Application(NDalicPINVOKE.ApplicationNewWithWindowSizePosition(argc, argvStr, stylesheet, (int)windowMode, Rectangle.getCPtr(positionSize)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

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
            win = Registry.GetManagedBaseHandleFromNativePtr(Interop.Application.GetWindow(SwigCPtr)) as Window;
            if (win == null)
            {
                win = new Window(Interop.Application.GetWindow(SwigCPtr), true);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return win;
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
                Window currWin = Registry.GetManagedBaseHandleFromNativePtr(Interop.Application.GetWindowsFromList(i)) as Window;
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                if (currWin)
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

        public enum WindowMode
        {
            Opaque = 0,
            Transparent = 1
        }
    }
}
