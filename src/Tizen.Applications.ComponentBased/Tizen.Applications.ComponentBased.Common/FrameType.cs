using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    internal class FrameType : BaseType
    {
        private Interop.CBApplication.FrameLifecycleCallbacks _callbacks;

        internal FrameType(Type ctype, string id) : base(ctype, id, BaseComponent.ComponentType.Frame)
        {
            _callbacks.OnAction = new Interop.CBApplication.FrameActionCallback(OnActionCallback);
            _callbacks.OnDeviceOrientationChanged = new Interop.CBApplication.FrameDeviceOrientationChangedCallback(OnDeviceOrientationChangedCallback);
            _callbacks.OnLanguageChanged = new Interop.CBApplication.FrameLanguageChangedCallback(OnLanguageChangedCallback);
            _callbacks.OnLowBattery = new Interop.CBApplication.FrameLowBatteryCallback(OnLowBatteryCallback);
            _callbacks.OnLowMemory = new Interop.CBApplication.FrameLowMemoryCallback(OnLowMemoryCallback);
            _callbacks.OnRegionFormatChanged = new Interop.CBApplication.FrameRegionFormatChangedCallback(OnRegionFormatChangedCallback);
            _callbacks.OnRestore = new Interop.CBApplication.FrameRestoreCallback(OnRestoreCallback);
            _callbacks.OnSave = new Interop.CBApplication.FrameSaveCallback(OnSaveCallback);
            _callbacks.OnSuspendedState = new Interop.CBApplication.FrameSuspendedStateCallback(OnSuspendedStateCallback);
            _callbacks.OnCreate = new Interop.CBApplication.FrameCreateCallback(OnCreateCallback);
            _callbacks.OnDestroy = new Interop.CBApplication.FrameDestroyCallback(OnDestroyCallback);
            _callbacks.OnPause = new Interop.CBApplication.FramePauseCallback(OnPauseCallback);
            _callbacks.OnResume = new Interop.CBApplication.FrameResumeCallback(OnResumeCallback);
            _callbacks.OnStart = new Interop.CBApplication.FrameStartCallback(OnStartCallback);
            _callbacks.OnStop = new Interop.CBApplication.FrameStopCallback(OnStopCallback);
        }

        private IntPtr OnCreateCallback(IntPtr context, IntPtr userData)
        {
            FrameComponent fc = Activator.CreateInstance(_classType) as FrameComponent;
            if (fc == null)
                return IntPtr.Zero;

            fc.Bind(context, _id);
            IntPtr winHandle;
            IWindow win = fc.OnCreate();
            Interop.CBApplication.BaseFrameCreateWindow(out winHandle, win.GetResId(), win.GetRaw());
            _compInstances.Add(fc);
            return winHandle;
        }

        private void OnStartCallback(IntPtr context, IntPtr appControl, bool restarted, IntPtr userData)
        {
            foreach (FrameComponent fc in _compInstances)
            {
                if (fc.Handle == context)
                {
                    SafeAppControlHandle handle = new SafeAppControlHandle(appControl, false);
                    AppControl control = new AppControl(handle);
                    fc.OnStart(control, restarted);
                    break;
                }
            }
        }

        private void OnResumeCallback(IntPtr context, IntPtr userData)
        {
            foreach (FrameComponent fc in _compInstances)
            {
                if (fc.Handle == context)
                {
                    fc.OnResume();
                    break;
                }
            }
        }

        private void OnPauseCallback(IntPtr context, IntPtr userData)
        {
            foreach (FrameComponent fc in _compInstances)
            {
                if (fc.Handle == context)
                {
                    fc.OnPause();
                    break;
                }
            }
        }

        private void OnStopCallback(IntPtr context, IntPtr userData)
        {
            foreach (FrameComponent fc in _compInstances)
            {
                if (fc.Handle == context)
                {
                    fc.OnStop();
                    break;
                }
            }
        }

        private void OnDestroyCallback(IntPtr context, IntPtr userData)
        {
            foreach (FrameComponent fc in _compInstances)
            {
                if (fc.Handle == context)
                {
                    fc.OnDestroy();
                    _compInstances.Remove(fc);
                    break;
                }
            }
            return;
        }

        private void OnActionCallback(IntPtr context, string action, IntPtr appControl, IntPtr userData)
        {
        }

        internal new IntPtr Bind(IntPtr h)
        {
            return Interop.CBApplication.BaseAddFrameComponent(h, _id, ref _callbacks, IntPtr.Zero);
        }
    }
}
