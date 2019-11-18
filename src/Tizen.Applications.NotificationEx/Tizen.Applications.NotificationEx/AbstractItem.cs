using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Interop.NotificationEx;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public abstract class AbstractItem
        {
            private LEDInfo _ledInfo;
            private IList<string> _receiverGroup;
            private AbstractAction _action;
            private Style _style;
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal AbstractItem(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            ~AbstractItem()
            {
                Interop.NotificationEx.ItemDestroy(NativeHandle);
            }

            internal IntPtr NativeHandle { get; set; }

            public string Id
            {
                get
                {
                    string id;
                    Interop.NotificationEx.ItemGetId(NativeHandle, out id);
                    return id;
                }
                set
                {
                    Interop.NotificationEx.ItemSetId(NativeHandle, value);
                }
            }

            public ItemType ItemType
            {
                get
                {
                    int nativeType;
                    Interop.NotificationEx.ItemGetType(NativeHandle, out nativeType);
                    return (ItemType)nativeType;
                }
            }

            public AbstractAction Action
            {
                get
                {
                    if (_action != null)
                        return _action;

                    IntPtr actionNativeHandle;
                    int nativeType;
                    Interop.NotificationEx.ItemGetAction(NativeHandle, out actionNativeHandle);
                    if (actionNativeHandle == IntPtr.Zero)
                        return null;
                    Interop.NotificationEx.ActionGetType(actionNativeHandle, out nativeType);
                    switch ((ActionType)nativeType)
                    {
                        case ActionType.AppControl:
                            _action = new AppControlAction(actionNativeHandle);
                            return _action;
                        case ActionType.Visibility:
                            _action = new VisibilityAction(actionNativeHandle);
                            return _action;
                        default:
                            break;
                    }
                    return null;
                }
                set
                {
                    if (value == null)
                        Interop.NotificationEx.ItemSetAction(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.ItemSetAction(NativeHandle, value.NativeHandle);
                    _action = value;
                }
            }

            public Style Style
            {
                get
                {
                    if (_style != null)
                        return _style;

                    IntPtr styleNativeHandle;
                    Interop.NotificationEx.ItemGetStyle(NativeHandle, out styleNativeHandle);
                    if (styleNativeHandle == IntPtr.Zero)
                        return null;
                    _style = new Style(styleNativeHandle);
                    return _style;
                }
                set
                {
                    if (value == null)
                        Interop.NotificationEx.ItemSetStyle(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.ItemSetStyle(NativeHandle, value.NativeHandle);
                    _style = value;
                }
            }

            public bool IsVisible
            {
                get
                {
                    bool visible;
                    Interop.NotificationEx.ItemGetVisible(NativeHandle, out visible);
                    return visible;
                }
                set
                {
                    Interop.NotificationEx.ItemSetVisible(NativeHandle, value);
                }
            }

            public bool IsEnabled
            {
                get
                {
                    bool enabled;
                    Interop.NotificationEx.ItemGetEnable(NativeHandle, out enabled);
                    return enabled;
                }
                set
                {
                    Interop.NotificationEx.ItemSetEnable(NativeHandle, value);
                }
            }

            public void AddReceiver(string receiver)
            {
                if (_receiverGroup == null)
                    _receiverGroup = new List<string>();
                Interop.NotificationEx.ItemAddReceiver(NativeHandle, receiver);
                _receiverGroup.Add(receiver);
            }

            public void RemoveReceiver(string receiver)
            {
                if (_receiverGroup == null)
                    _receiverGroup = new List<string>();
                Interop.NotificationEx.ItemRemoveReceiver(NativeHandle, receiver);
                _receiverGroup.Remove(receiver);
            }

            public IList<string> ReceiverGroup
            {
                get
                {
                    if (_receiverGroup != null)
                        return _receiverGroup;

                    IntPtr ptr;
                    int count;

                    Interop.NotificationEx.ItemGetReceiverList(NativeHandle, out ptr, out count);
                    if (count == 0)
                        return new List<string>();                    

                    string[] receiverList = Util.IntPtrToStringArray(ptr, count);
                    Interop.NotificationEx.ItemFreeStringList(ptr, count);
                    _receiverGroup = receiverList.ToList();
                    return _receiverGroup;
                }
                set
                {
                    IntPtr ptr;
                    int count;

                    Interop.NotificationEx.ItemGetReceiverList(NativeHandle, out ptr, out count);
                    if (count > 0)
                    {
                        string[] receiverList = Util.IntPtrToStringArray(ptr, count);
                        Interop.NotificationEx.ItemFreeStringList(ptr, count);
                        foreach (var group in receiverList)
                        {
                            Interop.NotificationEx.ItemRemoveReceiver(NativeHandle, group);
                        }
                    }

                    foreach (var group in value)
                    {
                        Interop.NotificationEx.ItemAddReceiver(NativeHandle, group);
                    }
                    _receiverGroup = value;
                }
            }

            public Policy Policy
            {
                get
                {
                    int nativePolicy;
                    Interop.NotificationEx.ItemGetPolicy(NativeHandle, out nativePolicy);
                    return (Policy)nativePolicy;
                }
                set
                {
                    Interop.NotificationEx.ItemSetPolicy(NativeHandle, (int)value);
                }
            }

            public string Channel
            {
                get
                {
                    string channel;
                    Interop.NotificationEx.ItemGetChannel(NativeHandle, out channel);
                    return channel;
                }
                set
                {
                    Interop.NotificationEx.ItemSetChannel(NativeHandle, value);
                }
            }

            public string SenderAppId
            {
                get
                {
                    string sender = "";
                    Interop.NotificationEx.ItemGetSenderAppId(NativeHandle, out sender);
                    return sender;
                }
            }

            public string Tag
            {
                get
                {
                    string tag;
                    Interop.NotificationEx.ItemGetTag(NativeHandle, out tag);
                    return tag;
                }
                set
                {
                    Interop.NotificationEx.ItemSetTag(NativeHandle, value);
                }
            }

            public int HideTime
            {
                get
                {
                    IntPtr info;
                    int hideTime;
                    Interop.NotificationEx.ItemGetInfo(NativeHandle, out info);
                    Interop.NotificationEx.InfoGetHideTime(info, out hideTime);
                    return hideTime;
                }
            }

            public int DeleteTime
            {
                get
                {
                    IntPtr info;
                    int deleteTime;
                    Interop.NotificationEx.ItemGetInfo(NativeHandle, out info);
                    Interop.NotificationEx.InfoGetDeleteTime(info, out deleteTime);
                    return deleteTime;
                }
                set
                {
                    IntPtr info;
                    Interop.NotificationEx.ItemGetInfo(NativeHandle, out info);
                    Interop.NotificationEx.InfoSetDeleteTime(info, value);
                }
            }

            public int InsertTime
            {
                get
                {
                    IntPtr info;
                    int insertTime;
                    Interop.NotificationEx.ItemGetInfo(NativeHandle, out info);
                    Interop.NotificationEx.InfoGetTime(info, out insertTime);

                    return insertTime;
                }
            }

            public LEDInfo LEDInfo
            {
                get
                {
                    if (_ledInfo != null)
                        return _ledInfo;

                    IntPtr handle;
                    Interop.NotificationEx.ItemGetLedInfo(NativeHandle, out handle);
                    if (handle == IntPtr.Zero)
                        return null;
                    _ledInfo = new LEDInfo(handle);
                    return _ledInfo;
                }
                set
                {
                    if (value == null)
                        Interop.NotificationEx.ItemSetLedInfo(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.ItemSetLedInfo(NativeHandle, value.NativeHandle);
                    _ledInfo = value;
                }
            }

            public string SoundPath
            {
                get
                {
                    string path;
                    Interop.NotificationEx.ItemGetSoundPath(NativeHandle, out path);
                    return path;
                }
                set
                {
                    Interop.NotificationEx.ItemSetSoundPath(NativeHandle, value);
                }
            }

            public string VibrationPath
            {
                get
                {
                    string path;
                    Interop.NotificationEx.ItemGetVibrationPath(NativeHandle, out path);
                    return path;
                }
                set
                {
                    Interop.NotificationEx.ItemSetVibrationPath(NativeHandle, value);
                }
            }

            public MainType GetMainType()
            {
                int nativeType;
                Interop.NotificationEx.ItemGetMainType(NativeHandle, out nativeType);
                return (MainType)nativeType;
            }

            public void SetMainType(string id, MainType type)
            {
                ErrorCode err = Interop.NotificationEx.ItemSetMainType(NativeHandle, id, (int)type);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            public virtual AbstractItem FindById(string id)
            {
                if (id == Id)
                    return this;

                IntPtr ptr;
                Interop.NotificationEx.ItemFindById(NativeHandle, id, out ptr);

                int type;
                ErrorCode err = Interop.NotificationEx.ItemGetType(ptr, out type);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                if (type != 0)
                    return FactoryManager.CreateItem(ptr);

                return null;
            }

            public virtual AbstractItem FindByMainType(MainType mainType)
            {
                IntPtr ptr;
                Interop.NotificationEx.ItemFindByMainType(NativeHandle, (int)mainType, out ptr);

                int type;
                ErrorCode err = Interop.NotificationEx.ItemGetType(ptr, out type);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                if (type != 0)
                    return FactoryManager.CreateItem(ptr);

                return null;
            }

            internal virtual void Serialize()
            {
                if (_action != null)
                    Action = _action;
                if (_ledInfo != null)
                    LEDInfo = _ledInfo;
                if (_receiverGroup != null)
                    ReceiverGroup = _receiverGroup;
                if (_style != null)
                    Style = _style;
            }
        }
    }
}
