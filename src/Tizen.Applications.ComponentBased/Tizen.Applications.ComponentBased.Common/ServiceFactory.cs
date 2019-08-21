using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    internal class ServiceFactory : ComponentFactoryBase
    {
        private Interop.CBApplication.ServiceLifecycleCallbacks _callbacks;
        private ComponentBasedApplicationBase _parent;

        internal ServiceFactory(Type ctype, string id, ComponentBasedApplicationBase parent) : base(ctype, id, ComponentType.Service, parent)
        {
            _callbacks.OnAction = new Interop.CBApplication.ServiceActionCallback(OnActionCallback);
            _callbacks.OnDeviceOrientationChanged = new Interop.CBApplication.ServiceDeviceOrientationChangedCallback(OnDeviceOrientationChangedCallback);
            _callbacks.OnLanguageChanged = new Interop.CBApplication.ServiceLanguageChangedCallback(OnLanguageChangedCallback);
            _callbacks.OnLowBattery = new Interop.CBApplication.ServiceLowBatteryCallback(OnLowBatteryCallback);
            _callbacks.OnLowMemory = new Interop.CBApplication.ServiceLowMemoryCallback(OnLowMemoryCallback);
            _callbacks.OnRegionFormatChanged = new Interop.CBApplication.ServiceRegionFormatChangedCallback(OnRegionFormatChangedCallback);
            _callbacks.OnRestore = new Interop.CBApplication.ServiceRestoreCallback(OnRestoreCallback);
            _callbacks.OnSave = new Interop.CBApplication.ServiceSaveCallback(OnSaveCallback);
            _callbacks.OnSuspendedState = new Interop.CBApplication.ServiceSuspendedStateCallback(OnSuspendedStateCallback);
            _callbacks.OnCreate = new Interop.CBApplication.ServiceCreateCallback(OnCreateCallback);
            _callbacks.OnDestroy = new Interop.CBApplication.ServiceDestroyCallback(OnDestroyCallback);
            _callbacks.OnStart = new Interop.CBApplication.ServiceStartCommandCallback(OnStartCallback);
            _parent = parent;
        }

        private bool OnCreateCallback(IntPtr context, IntPtr userData)
        {
            ServiceComponent sc = Activator.CreateInstance(_classType) as ServiceComponent;
            if (sc == null)
                return false;

            string id;
            Interop.CBApplication.GetInstanceId(context, out id);
            sc.Bind(context, _compId, id, _parent);

            bool result = sc.OnCreate();
            if (!result)
            {
                return false;
            }

            _compInstances.Add(sc);
            return true;
        }

        private void OnStartCallback(IntPtr context, IntPtr appControl, bool restarted, IntPtr userData)
        {
            foreach (ServiceComponent sc in _compInstances)
            {
                if (sc.Handle == context)
                {
                    SafeAppControlHandle handle = new SafeAppControlHandle(appControl, false);
                    AppControl control = new AppControl(handle);
                    sc.OnStartCommand(control, restarted);
                    break;
                }
            }
        }

        private void OnDestroyCallback(IntPtr context, IntPtr userData)
        {
            foreach (ServiceComponent sc in _compInstances)
            {
                if (sc.Handle == context)
                {
                    sc.OnDestroy();
                    _compInstances.Remove(sc);
                    break;
                }
            }
            return;
        }

        private void OnActionCallback(IntPtr context, string action, IntPtr appControl, IntPtr userData)
        {
        }

        internal override IntPtr Bind(IntPtr h)
        {
            return Interop.CBApplication.BaseAddServiceComponent(h, _compId, ref _callbacks, IntPtr.Zero);
        }
    }
}
