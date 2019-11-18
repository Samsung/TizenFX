using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        abstract public class Manager
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            private IntPtr _handle;
            private Interop.NotificationEx.ManagerEventCallbacks _callbacks;

            public Manager(string receiverGroup)
            {
                _callbacks.OnAdd = new Interop.NotificationEx.ManagerEventsAddCallback(OnAddNative);
                _callbacks.OnUpdate = new Interop.NotificationEx.ManagerEventsUpdateCallback(OnUpdateNative);
                _callbacks.OnDelete = new Interop.NotificationEx.ManagerEventsDeleteCallback(OnDeleteNative);
                _callbacks.OnError = new Interop.NotificationEx.ManagerEventsErrorCallback(OnErrorNative);

                ErrorCode err = Interop.NotificationEx.ManagerCreate(out _handle, receiverGroup, _callbacks, IntPtr.Zero);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            ~Manager()
            {
                ErrorCode err = Interop.NotificationEx.ManagerDestroy(_handle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy manager : " + err);
            }

            private void OnAddNative(IntPtr handle, IntPtr info, IntPtr addedItems, int count, IntPtr userData)
            {
                IList<AbstractItem> itemList = Util.IntPtrToList(addedItems, count);
                OnAdd(new EventInfo(info), itemList);
            }

            private void OnUpdateNative(IntPtr handle, IntPtr info, IntPtr updatedItem, IntPtr userData)
            {
                OnUpdate(new EventInfo(handle), FactoryManager.CreateItem(updatedItem));
            }

            private void OnDeleteNative(IntPtr handle, IntPtr info, IntPtr deletedItem, IntPtr userData)
            {
                OnDelete(new EventInfo(handle), FactoryManager.CreateItem(deletedItem));
            }

            private void OnErrorNative(IntPtr handle, ErrorCode error, int requestId, IntPtr userData)
            {
                OnError(error, requestId);
            }

            protected virtual void OnAdd(EventInfo info, IList<AbstractItem> addedItems)
            {
            }

            protected virtual void OnUpdate(EventInfo info, AbstractItem updatedItem)
            {
            }

            protected virtual void OnDelete(EventInfo info, AbstractItem deletedItem)
            {
            }

            protected virtual void OnError(ErrorCode error, int requestId)
            {
            }

            public IList<AbstractItem> Get()
            {
                IntPtr ptr;
                int count;

                ErrorCode err = Interop.NotificationEx.ManagerGet(_handle, out ptr, out count);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                IList<AbstractItem> itemList = Util.IntPtrToList(ptr, count);
                Interop.Libc.Free(ptr);

                return itemList;
            }

            public IList<AbstractItem> Get(string channel)
            {
                IntPtr ptr;
                int count;

                ErrorCode err = Interop.NotificationEx.ManagerGetByChannel(_handle, channel, out ptr, out count);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                IList<AbstractItem> itemList = Util.IntPtrToList(ptr, count);
                Interop.Libc.Free(ptr);

                return itemList;
            }

            public int Update(AbstractItem item)
            {
                int reqId;
                item.Serialize();
                ErrorCode err = Interop.NotificationEx.ManagerUpdate(_handle, item.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            public int Delete(AbstractItem item)
            {
                int reqId;
                ErrorCode err = Interop.NotificationEx.ManagerDelete(_handle, item.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            public int DeleteAll()
            {
                int reqId;
                ErrorCode err = Interop.NotificationEx.ManagerDeleteAll(_handle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            public int Hide(AbstractItem item)
            {
                int reqId;
                item.Serialize();
                ErrorCode err = Interop.NotificationEx.ManagerHide(_handle, item.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            public AbstractItem FindByRootId(string rootId)
            {
                IntPtr ptr;
                ErrorCode err = Interop.NotificationEx.ManagerFindByRootID(_handle, rootId, out ptr);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return FactoryManager.CreateItem(ptr);
            }

            public void SendError(EventInfo info, ErrorCode err)
            {
                ErrorCode ret = Interop.NotificationEx.ManagerSendError(_handle, info.NativeHandle, err);
                if (ret != ErrorCode.None)
                    ErrorFactory.ThrowException(ret);
            }

            public int GetNotificationCount()
            {
                int count;
                ErrorCode err = Interop.NotificationEx.ManagerGetNotificationCount(_handle, out count);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return count;
            }
        }
    }
}
