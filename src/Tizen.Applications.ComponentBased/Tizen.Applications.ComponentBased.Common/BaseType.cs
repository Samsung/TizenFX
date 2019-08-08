using System;
using System.Collections.Generic;
using System.Text;
using Tizen.Applications.CoreBackend;
using static Interop.CBApplication;
using static Tizen.Applications.CoreBackend.DefaultCoreBackend;

namespace Tizen.Applications.ComponentBased.Common
{
    internal class BaseType
    {
        internal readonly Type _classType;
        internal readonly string _id;
        internal IList<BaseComponent> _compInstances = new List<BaseComponent>();
        internal IDictionary<EventType, object> _handlers = new Dictionary<EventType, object>();
        private Interop.CBApplication.BaseLifecycleCallbacks _callbacks;
        private NativeComponentType _comp_type;

        internal BaseType(Type ctype, string id, NativeComponentType comp_type)
        {
            _comp_type = comp_type;
            _classType = ctype;
            _id = id;
            _callbacks.OnDeviceOrientationChanged = new Interop.CBApplication.BaseDeviceOrientationChangedCallback(OnDeviceOrientationChangedCallback);
            _callbacks.OnLanguageChanged = new Interop.CBApplication.BaseLanguageChangedCallback(OnLanguageChangedCallback);
            _callbacks.OnLowBattery = new Interop.CBApplication.BaseLowBatteryCallback(OnLowBatteryCallback);
            _callbacks.OnLowMemory = new Interop.CBApplication.BaseLowMemoryCallback(OnLowMemoryCallback);
            _callbacks.OnRegionFormatChanged = new Interop.CBApplication.BaseRegionFormatChangedCallback(OnRegionFormatChangedCallback);
            _callbacks.OnRestore = new Interop.CBApplication.BaseRestoreCallback(OnRestoreCallback);
            _callbacks.OnSave = new Interop.CBApplication.BaseSaveCallback(OnSaveCallback);
            _callbacks.OnSuspendedState = new Interop.CBApplication.BaseSuspendedStateCallback(OnSuspendedStateCallback);
        }

        internal NativeComponentType GetComponentType()
        {
            return _comp_type;
        }

        internal void AddEventHandler(EventType evType, Action handler)
        {
            _handlers.Add(evType, handler);
        }

        internal void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs
        {
            _handlers.Add(evType, handler);
        }

        protected void OnLanguageChangedCallback(IntPtr context, string language, IntPtr userData)
        {
            if (_handlers.ContainsKey(EventType.LocaleChanged))
            {
                var handler = _handlers[EventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
                handler?.Invoke(new LocaleChangedEventArgs(language));
            }
        }

        protected void OnDeviceOrientationChangedCallback(IntPtr context, int orientation, IntPtr userData)
        {
            if (_handlers.ContainsKey(EventType.DeviceOrientationChanged))
            {
                var handler = _handlers[EventType.DeviceOrientationChanged] as Action<DeviceOrientationEventArgs>;
                handler?.Invoke(new DeviceOrientationEventArgs((DeviceOrientation)orientation));
            }
        }

        protected void OnLowBatteryCallback(IntPtr context, int status, IntPtr userData)
        {
            if (_handlers.ContainsKey(EventType.LowBattery))
            {
                var handler = _handlers[EventType.LowBattery] as Action<LowBatteryEventArgs>;
                handler?.Invoke(new LowBatteryEventArgs((LowBatteryStatus)status));
            }
        }

        protected void OnLowMemoryCallback(IntPtr context, int status, IntPtr userData)
        {
            if (_handlers.ContainsKey(EventType.LowMemory))
            {
                var handler = _handlers[EventType.LowMemory] as Action<LowMemoryEventArgs>;
                handler?.Invoke(new LowMemoryEventArgs((LowMemoryStatus)status));
            }
        }

        protected void OnRegionFormatChangedCallback(IntPtr context, string region, IntPtr userData)
        {
            if (_handlers.ContainsKey(EventType.RegionFormatChanged))
            {
                var handler = _handlers[EventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
                handler?.Invoke(new RegionFormatChangedEventArgs(region));
            }
        }

        protected void OnRestoreCallback(IntPtr context, IntPtr content, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    Bundle bundle = null;

                    if (content != IntPtr.Zero)
                        bundle = new Bundle(new SafeBundleHandle(content, false));
                    com.OnRestoreContents(bundle);
                    break;
                }
            }
        }

        protected void OnSaveCallback(IntPtr context, IntPtr content, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    Bundle bundle = null;

                    if (content != IntPtr.Zero)
                        bundle = new Bundle(new SafeBundleHandle(content, false));
                    com.OnSaveContent(bundle);
                    break;
                }
            }
        }

        protected void OnSuspendedStateCallback(IntPtr context, int state, IntPtr userData)
        {
        }

        internal IntPtr Bind(IntPtr h)
        {
            return Interop.CBApplication.BaseAddComponent(h, _comp_type, _id, ref _callbacks, IntPtr.Zero);
        }

        private int OnCreate(IntPtr context, IntPtr content, int w, int h, IntPtr userData)
        {
            BaseComponent b = Activator.CreateInstance(_classType) as BaseComponent;
            Bundle bundle = null;

            if (b == null)
                return 0;

            b.Bind(context, _id);
            _compInstances.Add(b);
            if (content != IntPtr.Zero)
                bundle = new Bundle(new SafeBundleHandle(content, false));

            return 0;
        }

        private int OnDestroy(IntPtr context, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    _compInstances.Remove(com);
                    break;
                }
            }

            return 0;
        }
    }
}
