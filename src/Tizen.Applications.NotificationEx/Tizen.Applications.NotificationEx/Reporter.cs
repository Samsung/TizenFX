using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        private const string LogTag = "Tizen.Applications.NotificationEx";
        abstract public class Reporter
        {
            private IntPtr _handle;
            private Interop.NotificationEx.ReporterEventCallbacks _callbacks;

            public Reporter()
            {
                _callbacks.OnEvent = new Interop.NotificationEx.ReporterEventsEventCallback(OnEventNative);
                _callbacks.OnError = new Interop.NotificationEx.ReporterEventsErrorCallback(OnErrorNative);

                ErrorCode err = Interop.NotificationEx.ReporterCreate(out _handle, _callbacks, IntPtr.Zero);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            ~Reporter()
            {
                ErrorCode err = Interop.NotificationEx.ReporterDestroy(_handle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy reporter");
            }

            private void OnErrorNative(IntPtr handle, ErrorCode error, int requestId, IntPtr userData)
            {
                OnError(error, requestId);
            }

            private void OnEventNative(IntPtr handle, IntPtr eventInfo, IntPtr items, int count, IntPtr userData)
            {
                IList<AbstractItem> list = Util.IntPtrToList(items, count);
                OnEvent(new EventInfo(eventInfo), list);
            }

            protected virtual void OnError(ErrorCode error, int requestId)
            {
            }

            protected virtual void OnEvent(EventInfo info, IList<AbstractItem> items)
            {
            }

            public void SendError(EventInfo info, ErrorCode code)
            {
                ErrorCode err = Interop.NotificationEx.ReporterSendError(_handle, info.NativeHandle, code);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            public int Post(AbstractItem noti)
            {
                int reqId;
                noti.Serialize();
                ErrorCode err = Interop.NotificationEx.ReporterPost(_handle, noti.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            public int PostList(IList<AbstractItem> list)
            {
                int reqId;

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Serialize();
                }
                IntPtr nativeList = Util.ListToIntPtr(list);
                ErrorCode err = Interop.NotificationEx.ReporterPostList(_handle, nativeList, list.Count, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                Marshal.FreeHGlobal(nativeList);

                return reqId;
            }

            public int Update(AbstractItem noti)
            {
                int reqId;
                noti.Serialize();
                ErrorCode err = Interop.NotificationEx.ReporterUpdate(_handle, noti.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            public int Delete(AbstractItem noti)
            {
                int reqId;
                ErrorCode err = Interop.NotificationEx.ReporterDelete(_handle, noti.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            public int DeleteAll()
            {
                int reqId;
                ErrorCode err = Interop.NotificationEx.ReporterDeleteAll(_handle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            public AbstractItem FindByRootId(string rootId)
            {
                int reqId;
                IntPtr ptr;
                ErrorCode err = Interop.NotificationEx.ReporterFindByRootId(_handle, rootId, out ptr);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return FactoryManager.CreateItem(ptr);
            }
        }
    }
}
