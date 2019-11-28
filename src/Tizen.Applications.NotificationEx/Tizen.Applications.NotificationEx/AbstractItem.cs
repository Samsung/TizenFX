/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The AbstractItem class.
        /// This class contains base information about notification item.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public abstract class AbstractItem
        {
            private LEDInfo _ledInfo;
            private IList<string> _receiverGroups;
            private AbstractAction _action;
            private Style _style;
            internal AbstractItem(IntPtr ptr)
            {
                NativeHandle = ptr;
                IntPtr listPtr;
                int count;

                Interop.NotificationEx.ItemGetReceiverList(NativeHandle, out listPtr, out count);
                if (count == 0)
                    return;

                string[] receiverList = Util.IntPtrToStringArray(listPtr, count);
                Interop.NotificationEx.ItemFreeStringList(listPtr, count);
                _receiverGroups = receiverList.ToList();
            }

            /// <summary>
            /// Destructor of the AbstractItem class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~AbstractItem()
            {
                Interop.NotificationEx.ItemDestroy(NativeHandle);
            }

            internal IntPtr NativeHandle { get; set; }

            /// <summary>
            /// The item ID.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// The item type.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public ItemType ItemType
            {
                get
                {
                    int nativeType;
                    Interop.NotificationEx.ItemGetType(NativeHandle, out nativeType);
                    return (ItemType)nativeType;
                }
            }

            /// <summary>
            /// The notification item's action.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// The notification item's style.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// Whether the notification item is visible or not.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// Whether the notification item is enabled or not.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// Adds notification item receiver group.
            /// </summary>
            /// <param name="receiverGroup">The receiver group of the notification item.
            /// If the reciever group is added to the notification item, 
            /// only managers which are included in added groups, are able to receive the notification item.
            /// The manager will be created with specific receiver group. 
            /// Predefined receiver group is declared in the ReceiverGroup class.
            /// </param>
            /// <exception cref="ArgumentException">Thrown when the receiverGroup parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public void AddReceiverGroup(string receiverGroup)
            {
                if (receiverGroup == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                if (_receiverGroups == null)
                    _receiverGroups = new List<string>();
                Interop.NotificationEx.ItemAddReceiver(NativeHandle, receiverGroup);
                _receiverGroups.Add(receiverGroup);
            }

            /// <summary>
            /// Removes notification item receiver group.
            /// </summary>
            /// <param name="receiverGroup">The receiver group of the notification item. </param>
            /// <exception cref="ArgumentException">Thrown when the receiverGroup parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public void RemoveReceiverGroup(string receiverGroup)
            {
                if (receiverGroup == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                if (_receiverGroups == null)
                    _receiverGroups = new List<string>();
                Interop.NotificationEx.ItemRemoveReceiver(NativeHandle, receiverGroup);
                _receiverGroups.Remove(receiverGroup);
            }

            /// <summary>
            /// Receiver group list
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public IList<string> ReceiverGroups
            {
                get
                {
                    if (_receiverGroups != null)
                        return _receiverGroups;

                    IntPtr ptr;
                    int count;

                    Interop.NotificationEx.ItemGetReceiverList(NativeHandle, out ptr, out count);
                    if (count == 0)
                        return new List<string>();                    

                    string[] receiverList = Util.IntPtrToStringArray(ptr, count);
                    Interop.NotificationEx.ItemFreeStringList(ptr, count);
                    _receiverGroups = receiverList.ToList();
                    return _receiverGroups;
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

                    if (value != null)
                    {
                        foreach (var group in value)
                        {
                            if (group != null)
                                Interop.NotificationEx.ItemAddReceiver(NativeHandle, group);
                        }
                    }                    
                    _receiverGroups = value;
                }
            }

            /// <summary>
            /// Notification item policy
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Policies Policies
            {
                get
                {
                    int nativePolicy;
                    Interop.NotificationEx.ItemGetPolicy(NativeHandle, out nativePolicy);
                    return (Policies)nativePolicy;
                }
                set
                {
                    Interop.NotificationEx.ItemSetPolicy(NativeHandle, (int)value);
                }
            }

            /// <summary>
            /// Notification item channel
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// The notification item sender application ID.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public string SenderAppId
            {
                get
                {
                    string sender = "";
                    Interop.NotificationEx.ItemGetSenderAppId(NativeHandle, out sender);
                    return sender;
                }
            }

            /// <summary>
            /// The notification item tag.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// The notification item hide time in second.
            /// The veiwer of this notification item will hide it after HideTime seconds.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// The notification item delete time in second.
            /// The veiwer of this notification item will delete it after HideTime seconds.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// The notification item created time.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public DateTime CreatedTime
            {
                get
                {
                    IntPtr info;
                    int insertTime;
                    Interop.NotificationEx.ItemGetInfo(NativeHandle, out info);
                    Interop.NotificationEx.InfoGetTime(info, out insertTime);

                    return new DateTime(1970, 1, 1).AddSeconds(insertTime);
                }
            }

            /// <summary>
            /// The notification item LED information.            
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// The notification item sound path.            
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// The notification item vibration path.            
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
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

            /// <summary>
            /// Gets the notification item main type.            
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public MainType GetMainType()
            {
                int nativeType;
                Interop.NotificationEx.ItemGetMainType(NativeHandle, out nativeType);
                return (MainType)nativeType;
            }

            /// <summary>
            /// Sets main item.            
            /// </summary>
            /// <remarks>
            /// The main type Title and Contents are valid for Text item type.
            /// The main type Icon is valid for Image item type.
            /// The main type Button is valid for Button item type.
            /// </remarks>
            /// <param name="id">The ID of main item.</param>
            /// <param name="type">The main item type. Only item types which declared in a MainType class are able to have a main item.</param>
            /// <exception cref="ArgumentException">Thrown when id and type are invalid. </exception>
            /// The id parameter must be the notification item's ID, which has the valid type for a type parameter.</exception>
            /// <since_tizen> 7 </since_tizen>
            public void SetMainType(string id, MainType type)
            {
                ErrorCode err = Interop.NotificationEx.ItemSetMainType(NativeHandle, id, (int)type);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            /// <summary>
            /// Finds the notification item by ID
            /// </summary>
            /// <param name="id">The ID of the notification item.</param>
            /// <returns>If this function is working successfully, returns an abstract item otherwise null.</returns>
            /// <since_tizen> 7 </since_tizen>
            public virtual AbstractItem FindById(string id)
            {
                if (id == Id)
                    return this;

                IntPtr ptr;
                Interop.NotificationEx.ItemFindById(NativeHandle, id, out ptr);
                if (ptr == IntPtr.Zero)
                    return null;

                return FactoryManager.CreateItem(ptr);
            }

            /// <summary>
            /// Finds the notification item by main type
            /// </summary>
            /// <param name="mainType">A main type.</param>
            /// <returns>If this function is working successfully, returns an abstract item otherwise null.</returns>
            /// <since_tizen> 7 </since_tizen>
            public virtual AbstractItem FindByMainType(MainType mainType)
            {
                IntPtr ptr;
                Interop.NotificationEx.ItemFindByMainType(NativeHandle, (int)mainType, out ptr);
                if (ptr == IntPtr.Zero)
                    return null;

                return FactoryManager.CreateItem(ptr);
            }

            internal virtual void Serialize()
            {
                if (_action != null)
                    Action = _action;
                if (_ledInfo != null)
                    LEDInfo = _ledInfo;
                if (_receiverGroups != null)
                    ReceiverGroups = _receiverGroups;
                if (_style != null)
                    Style = _style;
            }
        }
    }
}
