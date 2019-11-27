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

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The Group class.
        /// Using this class, developers are able to create notification items which can have other notification items as children.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Group : AbstractItem
        {
            private IList<AbstractItem> _children;

            /// <summary>
            /// Initializes Group class.
            /// </summary>
            /// <param name="id"> An ID of the Group item. </param>
            /// <since_tizen> 7 </since_tizen>
            public Group(string id) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                Interop.NotificationEx.GroupCreate(out handle, id);                
                return handle;
            }))())
            {
            }

            internal Group(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            /// A display direction of children items.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public bool IsVertical
            {
                get
                {
                    bool isVertical;
                    Interop.NotificationEx.GroupIsVertical(NativeHandle, out isVertical);
                    return isVertical;
                }
                set
                {
                    Interop.NotificationEx.GroupSetDirection(NativeHandle, value);
                }
            }

            /// <summary>
            /// An application label.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public string AppLabel
            {
                get
                {
                    string label = "";
                    Interop.NotificationEx.GroupGetAppLabel(NativeHandle, out label);                    
                    return label;
                }
            }

            internal override void Serialize()
            {
                base.Serialize();
                if (_children != null)
                    Children = _children;
            }

            /// <summary>
            /// The children notification items.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public IList<AbstractItem> Children
            {
                get
                {
                    if (_children != null)
                        return _children;

                    _children = new List<AbstractItem>();
                    Interop.NotificationEx.GroupForeachChildCallback callback = (IntPtr handle, IntPtr userData) =>
                    {
                        _children.Add(FactoryManager.CreateItem(handle));
                        return 0;
                    };
                    Interop.NotificationEx.GroupForeachChild(NativeHandle, callback, IntPtr.Zero);
                    return _children;
                }
                set
                {                    
                    Interop.NotificationEx.GroupRemoveChildren(NativeHandle);
                    if (value != null)
                    {
                        for (int i = 0; i < value.Count; i++)
                        {
                            if (value[i] != null)
                                Interop.NotificationEx.GroupAddChild(NativeHandle, value[i].NativeHandle);
                        }
                    }                    
                    _children = value;
                }
            }

            /// <summary>
            /// Adds a child notification item.
            /// </summary>
            /// <param name="item">A notification item.</param>
            /// <exception cref="ArgumentException">Thrown when the item parameter is invalid. 
            /// <since_tizen> 7 </since_tizen>
            public void AddChild(AbstractItem item)
            {
                if (item == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                if (_children == null)
                    _children = new List<AbstractItem>();
                Interop.NotificationEx.GroupAddChild(NativeHandle, item.NativeHandle);
                _children.Add(item);
            }

            /// <summary>
            /// Removes a child notification item.
            /// </summary>
            /// <param name="itemId">A notification item ID.</param>
            /// <since_tizen> 7 </since_tizen>
            public void RemoveChild(string itemId)
            {
                if (_children == null)
                    _children = new List<AbstractItem>();
                Interop.NotificationEx.GroupRemoveChild(NativeHandle, itemId);
                for (int i = 0; i < _children.Count; i++)
                {
                    if (_children[i].Id == itemId)
                    {
                        _children.Remove(_children[i]);
                        break;
                    }                        
                }
            }
        }
    }
}
