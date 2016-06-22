using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Tizen;

namespace Tizen.Messaging.Push
{
    internal class PushImpl
    {
        private static readonly object _lock = new object();
        private static PushImpl _instance;

        internal static PushImpl Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        Log.Info(Interop.Push.LogTag, "Creating New Instance");
                        _instance = new PushImpl();
                    }
                }
                return _instance;
            }
        }

        internal PushImpl()
        {
            //Empty
        }

        private IntPtr _connection;

        internal void PushServiceConnect(string pushAppId)
        {
            Interop.Push.VoidStateChangedCallback stateDelegate = (int state, string err, IntPtr userData) =>
            {
                PushConnectionStateEventArgs args = new PushConnectionStateEventArgs((PushConnectionStateEventArgs.PushState)state, err);
                Push.StateChange(args);
            };
            Interop.Push.VoidNotifyCallback notifyDelegate = (IntPtr notification, IntPtr userData) =>
            {
                Interop.Push.ServiceError result;
                PushMessageEventArgs ob = new PushMessageEventArgs();
                string data;
                result = Interop.Push.GetNotificationData(notification, out data);
                if ((result == Interop.Push.ServiceError.None) && !(String.IsNullOrEmpty(data)))
                {
                    ob.AppData = data;
                }
		else
		{
			ob.AppData = "";
		}
                string message;
                result = Interop.Push.GetNotificationMessage(notification, out message);
                if ((result == Interop.Push.ServiceError.None) && !(String.IsNullOrEmpty(message)))
                {
                    ob.Message = message;
                }
		else
		{
			ob.Message = "";
		}
                string sender;
                result = Interop.Push.GetNotificationSender(notification, out sender);
                if ((result == Interop.Push.ServiceError.None) && !(String.IsNullOrEmpty(sender)))
                {
                    ob.Sender = sender;
                }
		else
		{
			ob.Sender = "";
		}
                string sessioninfo;
                result = Interop.Push.GetNotificationSessionInfo(notification, out sessioninfo);
                if ((result == Interop.Push.ServiceError.None) && !(String.IsNullOrEmpty(sessioninfo)))
                {
                    ob.SessionInfo = sessioninfo;
                }
		else
		{
			ob.SessionInfo = "";
		}
                string requestid;
                result = Interop.Push.GetNotificationRequestId(notification, out requestid);
                if ((result == Interop.Push.ServiceError.None) && !(String.IsNullOrEmpty(requestid)))
                {
                    ob.RequestId = requestid;
                }
		else
		{
			ob.RequestId = "";
		}
                int time;
                result = Interop.Push.GetNotificationTime(notification, out time);
                DateTime utc;
                if ((result == Interop.Push.ServiceError.None) && (time != 0))
                {
                    Log.Info(Interop.Push.LogTag, "Ticks received: " + time);
                    utc = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(time), DateTimeKind.Utc);
                    ob.ReceivedAt = utc.ToLocalTime();
                }
                else
                {
                    Log.Info(Interop.Push.LogTag, "No Date received");
                    ob.ReceivedAt = DateTime.Now;
                }
                int type = -1;
                result = Interop.Push.GetNotificationType(notification, out type);
                if (result == Interop.Push.ServiceError.None)
                {
                    ob.Type = type;
                }
                Push.Notify(ob);
                //Interop.Push.FreeNotification(notification);
                Log.Info(Interop.Push.LogTag, "Free Notification Done");
            };
            Interop.Push.ServiceError connectResult = Interop.Push.ServiceConnect(pushAppId, stateDelegate, notifyDelegate, IntPtr.Zero, out _connection);
            if (connectResult != Interop.Push.ServiceError.None)
            {
                Log.Error(Interop.Push.LogTag, "Connect failed with "+ connectResult);
                throw PushExceptionFactory.CreateResponseException(connectResult);
            }
        }

        internal void PushServiceDisconnect()
        {
            Interop.Push.ServiceDisconnect(_connection);
            Log.Info(Interop.Push.LogTag, "PushServiceDisconnect Completed");
        }

        internal async Task<ServerResponse> PushServerRegister()
        {
            Log.Info(Interop.Push.LogTag, "Register Called");
            var task = new TaskCompletionSource<ServerResponse>();
            Interop.Push.VoidResultCallback registerResult = (Interop.Push.Result regResult, IntPtr msgPtr, IntPtr userData) =>
            {
                Log.Info(Interop.Push.LogTag, "Register Callback Called");
                string msg = "";
                if (msgPtr != IntPtr.Zero)
                {
                    msg = Marshal.PtrToStringAnsi(msgPtr);
                }
                ServerResponse response = new ServerResponse();
                response.ServerResult = (ServerResponse.Result)regResult;
                response.ServerMessage = msg;
                if (task.TrySetResult(response) == false)
                {
                    Log.Error(Interop.Push.LogTag, "Unable to set the Result for register");
                }
            };
            Interop.Push.ServiceError result = Interop.Push.ServiceRegister(_connection, registerResult, IntPtr.Zero);
            Log.Info(Interop.Push.LogTag, "Interop.Push.ServiceRegister Completed");
            if (result != Interop.Push.ServiceError.None)
            {
                Log.Error(Interop.Push.LogTag, "Register failed with " + result);
                task.SetException(PushExceptionFactory.CreateResponseException(result));
            }
            return await task.Task;
        }

        internal async Task<ServerResponse> PushServerUnregister()
        {
            var task = new TaskCompletionSource<ServerResponse>();
            Interop.Push.VoidResultCallback registerResult = (Interop.Push.Result regResult, IntPtr msgPtr, IntPtr userData) =>
            {
                Log.Info(Interop.Push.LogTag, "Unregister Callback Called");
                string msg = "";
                if (msgPtr != IntPtr.Zero)
                {
                    msg = Marshal.PtrToStringAnsi(msgPtr);
                }
                ServerResponse response = new ServerResponse();
                response.ServerResult = (ServerResponse.Result)regResult;
                response.ServerMessage = msg;
                if (task.TrySetResult(response) == false)
                {
                    Log.Error(Interop.Push.LogTag, "Unable to set the Result for Unregister");
                }
            };
            Interop.Push.ServiceError result = Interop.Push.ServiceDeregister(_connection, registerResult, IntPtr.Zero);
            if (result != Interop.Push.ServiceError.None)
            {
                task.SetException(PushExceptionFactory.CreateResponseException(result));
            }
            return await task.Task;
        }

        internal string GetRegistrationId()
        {
            string regID = "";
            Interop.Push.ServiceError result = Interop.Push.GetRegistrationId(_connection, out regID);
            if (result != Interop.Push.ServiceError.None)
            {
                throw PushExceptionFactory.CreateResponseException(result);
            }
            Log.Info(Interop.Push.LogTag, "Returning Reg Id: " + regID);
            return regID;
        }

        internal void GetUnreadNotifications()
        {
            Interop.Push.ServiceError result = Interop.Push.RequestUnreadNotification(_connection);
            if (result != Interop.Push.ServiceError.None)
            {
                throw PushExceptionFactory.CreateResponseException(result);
            }
        }

        internal static void Reset()
        {
            lock (_lock)
            {
                Log.Info(Interop.Push.LogTag, "Making _instance as null");
                _instance = null;
            }
        }
    }
}
