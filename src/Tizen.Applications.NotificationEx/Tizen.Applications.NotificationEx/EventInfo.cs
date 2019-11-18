using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class EventInfo
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal IntPtr NativeHandle { get; set; }

            internal EventInfo(IntPtr ptr)
            {
                IntPtr cloned;
                ErrorCode err = Interop.NotificationEx.EventInfoClone(ptr, out cloned);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = cloned;
            }

            ~EventInfo()
            {
                ErrorCode err = Interop.NotificationEx.EventInfoDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy event info : " + err);
            }

            public EventInfoType Type
            {
                get
                {
                    int nativeType;
                    Interop.NotificationEx.EventInfoGetEventType(NativeHandle, out nativeType);
                    return (EventInfoType)nativeType;
                }
            }

            public string Owner
            {
                get
                {
                    string owner = "";
                    Interop.NotificationEx.EventInfoGetOwner(NativeHandle, out owner);
                    return owner;
                }
            }

            public string Channel
            {
                get
                {
                    string channel = "";
                    Interop.NotificationEx.EventInfoGetChannel(NativeHandle, out channel);
                    return channel;
                }
            }

            public string ItemId
            {
                get
                {
                    string itemId = "";
                    Interop.NotificationEx.EventInfoGetItemId(NativeHandle, out itemId);
                    return itemId;
                }
            }

            public int RequestId
            {
                get
                {
                    int requestId;
                    Interop.NotificationEx.EventInfoGetRequestId(NativeHandle, out requestId);
                    return requestId;
                }
            }
        }
    }
}
