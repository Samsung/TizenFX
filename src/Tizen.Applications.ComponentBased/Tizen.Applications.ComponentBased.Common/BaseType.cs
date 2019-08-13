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
        private Interop.CBApplication.BaseLifecycleCallbacks _callbacks;
        private BaseComponent.ComponentType _comp_type;

        internal BaseType(Type ctype, string id, BaseComponent.ComponentType comp_type)
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

        internal BaseComponent.ComponentType GetComponentType()
        {
            return _comp_type;
        }

        protected void OnLanguageChangedCallback(IntPtr context, string language, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLanguageChangedCallback(language);
                }
            }
        }

        protected void OnDeviceOrientationChangedCallback(IntPtr context, int orientation, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnDeviceOrientationChangedCallback(orientation);
                }
            }
        }

        protected void OnLowBatteryCallback(IntPtr context, int status, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLowBatteryCallback(status);
                }
            }
        }

        protected void OnLowMemoryCallback(IntPtr context, int status, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnLowMemoryCallback(status);
                }
            }
        }

        protected void OnRegionFormatChangedCallback(IntPtr context, string region, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnRegionFormatChangedCallback(region);
                }
            }
        }

        protected void OnSuspendedStateCallback(IntPtr context, int state, IntPtr userData)
        {
            foreach (BaseComponent com in _compInstances)
            {
                if (com.Handle == context)
                {
                    com.OnSuspendedStateCallback(state);
                }
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

        internal IntPtr Bind(IntPtr h)
        {
            return Interop.CBApplication.BaseAddComponent(h, (NativeComponentType)_comp_type, _id, ref _callbacks, IntPtr.Zero);
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
