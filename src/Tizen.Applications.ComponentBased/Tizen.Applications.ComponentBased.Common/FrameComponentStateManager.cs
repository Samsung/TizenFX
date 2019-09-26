using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    internal class FrameComponentStateManager : ComponentStateManger
    {
        private Interop.CBApplication.FrameLifecycleCallbacks _callbacks;
        private const string LogTag = "Tizen.Applications.FrameComponentStateManager";
        private IDictionary<string, IWindowInfo> _winDic = new Dictionary<string, IWindowInfo>();

        internal FrameComponentStateManager(Type ctype, string id, ComponentBasedApplication parent) : base(ctype, id, parent)
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
            Parent = parent;
        }

        private IntPtr OnCreateCallback(IntPtr context, IntPtr userData)
        {
            FrameComponent fc = Activator.CreateInstance(ComponentClassType) as FrameComponent;
            if (fc == null)
            {
                Log.Error(LogTag, "Fail to create instance");
                return IntPtr.Zero;
            }

            string id;
            Interop.CBApplication.GetInstanceId(context, out id);
            fc.Bind(context, ComponentId, id, Parent);

            IntPtr winHandle;
            IWindowInfo win = fc.CreateWindowInfo();
            if (win == null)
                return IntPtr.Zero;

            _winDic.Add(id, win);
            if (!fc.OnCreate())
            {
                Log.Error(LogTag, "OnCreate fail");
                return IntPtr.Zero;
            }
            Interop.CBApplication.BaseFrameCreateWindow(out winHandle, win.ResourceId, IntPtr.Zero);

            AddComponent(fc);
            return winHandle;
        }

        private void OnStartCallback(IntPtr context, IntPtr appControl, bool restarted, IntPtr userData)
        {
            foreach (FrameComponent fc in Instances)
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
            foreach (FrameComponent fc in Instances)
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
            foreach (FrameComponent fc in Instances)
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
            foreach (FrameComponent fc in Instances)
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
            foreach (FrameComponent fc in Instances)
            {
                if (fc.Handle == context)
                {
                    fc.OnDestroy();
                    _winDic[fc.Id].Release();
                    RemoveComponent(fc);
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
            return Interop.CBApplication.BaseAddFrameComponent(h, ComponentId, ref _callbacks, IntPtr.Zero);
        }
    }
}
