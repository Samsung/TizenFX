using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class PushClient
    {
        internal static string LogTag = "Tizen.Messaging.Push";

        internal enum Result
        {
            Success = 0,
            Timeout = 1,
            ServerError = 2,
            SystemError = 3
        };

        internal enum ServiceError
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            NotConnected = Tizen.Internals.Errors.ErrorCode.EndpointNotConnected,
            NoData = Tizen.Internals.Errors.ErrorCode.NoData,
            OpearationFailed = Tizen.Internals.Errors.ErrorCode.Unknown,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported
        };

        internal enum State
        {
            Registered,
            Unregistered,
            ProvisioningIPChange,
            PingChange,
            StateError
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VoidStateChangedCallback(int state, string err, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VoidNotifyCallback(IntPtr notification, IntPtr userData);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VoidResultCallback(Result result, IntPtr msg, IntPtr userData);

        [DllImport(Libraries.Push, EntryPoint = "push_service_connect", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError ServiceConnect(string pushAppID, VoidStateChangedCallback stateCallback, VoidNotifyCallback notifyCallback, IntPtr userData, out IntPtr connection);

        [DllImport(Libraries.Push, EntryPoint = "push_service_disconnect", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ServiceDisconnect(IntPtr connection);

        [DllImport(Libraries.Push, EntryPoint = "push_service_register", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError ServiceRegister(IntPtr connection, VoidResultCallback callback, IntPtr UserData);

        [DllImport(Libraries.Push, EntryPoint = "push_service_deregister", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError ServiceDeregister(IntPtr connection, VoidResultCallback callback, IntPtr UserData);

        [DllImport(Libraries.Push, EntryPoint = "push_service_app_control_to_noti_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern string AppControlToNotiData(IntPtr appControl, string operation);

        [DllImport(Libraries.Push, EntryPoint = "push_service_app_control_to_notification", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError AppControlToNotification(IntPtr appControl, string operation, out IntPtr noti);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_notification_data", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetNotificationData(IntPtr notification, out string data);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_notification_message", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetNotificationMessage(IntPtr notification, out string data);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_notification_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetNotificationTime(IntPtr notification, out int receivedTime);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_notification_sender", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetNotificationSender(IntPtr notification, out string sender);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_notification_session_info", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetNotificationSessionInfo(IntPtr notification, out string sessionInfo);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_notification_request_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetNotificationRequestId(IntPtr notification, out string requestID);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_notification_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetNotificationType(IntPtr notification, out int type);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_unread_notification", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetUnreadNotification(IntPtr connection, out IntPtr noti);

        [DllImport(Libraries.Push, EntryPoint = "push_service_request_unread_notification", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError RequestUnreadNotification(IntPtr connection);

        [DllImport(Libraries.Push, EntryPoint = "push_service_get_registration_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError GetRegistrationId(IntPtr connection, out string regID);

        [DllImport(Libraries.Push, EntryPoint = "push_service_free_notification", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Interop.PushClient.ServiceError FreeNotification(IntPtr connection);
    }
}