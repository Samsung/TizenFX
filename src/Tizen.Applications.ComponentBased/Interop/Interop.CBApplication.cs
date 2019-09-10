using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class CBApplication
    {
        internal delegate void CBAppInitCallback(int argc, string[] argv, IntPtr userData);
        internal delegate void CBAppFiniCallback(IntPtr userData);
        internal delegate void CBAppRunCallback(IntPtr userData);
        internal delegate void CBAppExitCallback(IntPtr userData);
        internal delegate IntPtr CBAppCreateCallback(IntPtr userData);
        internal delegate void CBAppTerminateCallback(IntPtr userData);
        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct CBAppLifecycleCallbacks
        {
            public CBAppInitCallback OnInit;
            public CBAppFiniCallback OnFinished;
            public CBAppRunCallback OnRun;
            public CBAppExitCallback OnExit;
            public CBAppCreateCallback OnCreate;
            public CBAppTerminateCallback OnTerminate;
        }

        internal enum ErrorCode : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            InvalidContext = -0x03030000 | 0x01,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
            NotFound = -0x03030000 | 0x02,
            LaunchRejected = -0x03030000 | 0x03,
            LaunchFailed = -0x03030000 | 0x04,
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        }

        internal enum NativeComponentType
        {
            Frame = 0,
            Service
        }

        internal enum NativeDisplayStatus {
            On,
            Off
        }

        internal delegate IntPtr FrameCreateCallback(IntPtr context, IntPtr userData);
        internal delegate void FrameStartCallback(IntPtr context, IntPtr appControl, bool restarted, IntPtr userData);
        internal delegate void FrameResumeCallback(IntPtr context, IntPtr userData);
        internal delegate void FramePauseCallback(IntPtr context, IntPtr userData);
        internal delegate void FrameStopCallback(IntPtr context, IntPtr userData);
        internal delegate void FrameDestroyCallback(IntPtr context, IntPtr userData);
        internal delegate void FrameRestoreCallback(IntPtr context, IntPtr content, IntPtr userData);
        internal delegate void FrameSaveCallback(IntPtr context, IntPtr content, IntPtr userData);
        internal delegate void FrameActionCallback(IntPtr context, string action, IntPtr appControl, IntPtr userData);
        internal delegate void FrameDeviceOrientationChangedCallback(IntPtr context, int orientation, IntPtr userData);
        internal delegate void FrameLanguageChangedCallback(IntPtr context, string language, IntPtr userData);
        internal delegate void FrameRegionFormatChangedCallback(IntPtr context, string region, IntPtr userData);
        internal delegate void FrameLowBatteryCallback(IntPtr context, int status, IntPtr userData);
        internal delegate void FrameLowMemoryCallback(IntPtr context, int status, IntPtr userData);
        internal delegate void FrameSuspendedStateCallback(IntPtr context, int state, IntPtr userData);

        internal struct FrameLifecycleCallbacks
        {
            public FrameCreateCallback OnCreate;
            public FrameStartCallback OnStart;
            public FrameResumeCallback OnResume;
            public FramePauseCallback OnPause;
            public FrameStopCallback OnStop;
            public FrameDestroyCallback OnDestroy;
            public FrameRestoreCallback OnRestore;
            public FrameSaveCallback OnSave;
            public FrameActionCallback OnAction;
            public FrameDeviceOrientationChangedCallback OnDeviceOrientationChanged;
            public FrameLanguageChangedCallback OnLanguageChanged;
            public FrameRegionFormatChangedCallback OnRegionFormatChanged;
            public FrameLowBatteryCallback OnLowBattery;
            public FrameLowMemoryCallback OnLowMemory;
            public FrameSuspendedStateCallback OnSuspendedState;
        }

        internal delegate bool ServiceCreateCallback(IntPtr context, IntPtr userData);
        internal delegate void ServiceStartCommandCallback(IntPtr context, IntPtr appControl, bool restarted, IntPtr userData);
        internal delegate void ServiceDestroyCallback(IntPtr context, IntPtr userData);
        internal delegate void ServiceRestoreCallback(IntPtr context, IntPtr content, IntPtr userData);
        internal delegate void ServiceSaveCallback(IntPtr context, IntPtr content, IntPtr userData);
        internal delegate void ServiceActionCallback(IntPtr context, string action, IntPtr appControl, IntPtr userData);
        internal delegate void ServiceDeviceOrientationChangedCallback(IntPtr context, int orientation, IntPtr userData);
        internal delegate void ServiceLanguageChangedCallback(IntPtr context, string language, IntPtr userData);
        internal delegate void ServiceRegionFormatChangedCallback(IntPtr context, string region, IntPtr userData);
        internal delegate void ServiceLowBatteryCallback(IntPtr context, int status, IntPtr userData);
        internal delegate void ServiceLowMemoryCallback(IntPtr context, int status, IntPtr userData);
        internal delegate void ServiceSuspendedStateCallback(IntPtr context, int state, IntPtr userData);

        internal struct ServiceLifecycleCallbacks
        {
            public ServiceCreateCallback OnCreate;
            public ServiceStartCommandCallback OnStart;
            public ServiceDestroyCallback OnDestroy;
            public ServiceRestoreCallback OnRestore;
            public ServiceSaveCallback OnSave;
            public ServiceActionCallback OnAction;
            public ServiceDeviceOrientationChangedCallback OnDeviceOrientationChanged;
            public ServiceLanguageChangedCallback OnLanguageChanged;
            public ServiceRegionFormatChangedCallback OnRegionFormatChanged;
            public ServiceLowBatteryCallback OnLowBattery;
            public ServiceLowMemoryCallback OnLowMemory;
            public ServiceSuspendedStateCallback OnSuspendedState;
        }

        internal delegate IntPtr BaseCreateCallback(IntPtr context, IntPtr userData);
        internal delegate void BaseDestroyCallback(IntPtr context, IntPtr userData);
        internal delegate void BaseRestoreCallback(IntPtr context, IntPtr content, IntPtr userData);
        internal delegate void BaseSaveCallback(IntPtr context, IntPtr content, IntPtr userData);
        internal delegate void BaseDeviceOrientationChangedCallback(IntPtr context, int orientation, IntPtr userData);
        internal delegate void BaseLanguageChangedCallback(IntPtr context, string language, IntPtr userData);
        internal delegate void BaseRegionFormatChangedCallback(IntPtr context, string region, IntPtr userData);
        internal delegate void BaseLowBatteryCallback(IntPtr context, int status, IntPtr userData);
        internal delegate void BaseLowMemoryCallback(IntPtr context, int status, IntPtr userData);
        internal delegate void BaseSuspendedStateCallback(IntPtr context, int state, IntPtr userData);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "component_based_app_base_main")]
        internal static extern ErrorCode BaseMain(int argc, string[] argv, ref CBAppLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "component_based_app_base_exit")]
        internal static extern ErrorCode BaseExit();

        [DllImport(Libraries.CompCoreBase, EntryPoint = "component_based_app_base_add_frame_component")]
        internal static extern IntPtr BaseAddFrameComponent(IntPtr comp_class, string compId, ref FrameLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "component_based_app_base_add_service_component")]
        internal static extern IntPtr BaseAddServiceComponent(IntPtr comp_class, string compId, ref ServiceLifecycleCallbacks callback, IntPtr userData);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "base_frame_create_window")]
        internal static extern IntPtr BaseFrameCreateWindow(out IntPtr winHandle, int winId, IntPtr raw);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "base_frame_window_get_compId")]
        internal static extern IntPtr BaseFrameWindowGetId(IntPtr winHandle, out int winId);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "base_frame_window_get_raw")]
        internal static extern IntPtr BaseFrameWindowGetRaw(IntPtr winHandle, out IntPtr raw);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "base_frame_get_display_status")]
        internal static extern ErrorCode BaseFrameGetDisplayStatus(IntPtr context, out NativeDisplayStatus status);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "component_get_instance_id")]
        internal static extern ErrorCode GetInstanceId(IntPtr context, out string instanceId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ReplyCallback(IntPtr request, IntPtr reply, int result, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ResultCallback(IntPtr request, int result, IntPtr userData);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "component_send_launch_request_async")]
        internal static extern ErrorCode SendLaunchRequestAsync(IntPtr context, SafeAppControlHandle appControl,
            ResultCallback resultCallback, ReplyCallback replyCallback, IntPtr userData);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "component_send_launch_request_sync")]
        internal static extern ErrorCode SendLaunchRequestSync(IntPtr context, SafeAppControlHandle appControl,
            SafeAppControlHandle replyControl, out int result);

        [DllImport(Libraries.CompCoreBase, EntryPoint = "component_finish")]
        internal static extern ErrorCode ComponentFinish(IntPtr context);
    }
}
