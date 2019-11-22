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

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The ChatMessage class.
        /// Using this class, developers are able to create chat-message style notification items.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class ChatMessage : AbstractItem
        {
            private Text _text;
            private Text _name;
            private Image _image;
            private Time _time;

            /// <summary>
            /// Initializes ChatMessage class.
            /// </summary>
            /// <param name="id"> An item ID. </param>
            /// <param name="name"> A message owner's name. </param>
            /// <param name="text"> A text of message. </param>
            /// <param name="image"> A image of message. </param>
            /// <param name="time"> A time that message is created. </param>
            /// <param name="type"> A message type. </param>
            /// <since_tizen> 7 </since_tizen>
            public ChatMessage(string id, Text name, Text text, Image image, Time time, ChatMessageType type) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ChatMessageCreate(out handle, id, name.NativeHandle, text.NativeHandle, image.NativeHandle, time.NativeHandle, type);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal ChatMessage(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            /// A text of chat-message.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Text Text
            {
                get
                {
                    if (_text != null)
                        return _text;

                    IntPtr text;
                    Interop.NotificationEx.ChatMessageGetText(NativeHandle, out text);
                    if (text == IntPtr.Zero)
                        return null;
                    _text = new Text(text);
                    return _text;
                }
            }

            /// <summary>
            /// A chat-message owner's name.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Text Name
            {
                get
                {
                    if (_name != null)
                        return _name;

                    IntPtr name;
                    Interop.NotificationEx.ChatMessageGetName(NativeHandle, out name);
                    if (name == IntPtr.Zero)
                        return null;
                    _name = new Text(name);
                    return _name;
                }
            }

            /// <summary>
            /// A image of chat-message.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Image Image
            {
                get
                {
                    if (_image != null)
                        return _image;

                    IntPtr image;
                    Interop.NotificationEx.ChatMessageGetImage(NativeHandle, out image);
                    if (image == IntPtr.Zero)
                        return null;
                    _image = new Image(image);
                    return _image;
                }
            }

            /// <summary>
            /// A time that message is created.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Time Time
            {
                get
                {
                    if (_time != null)
                        return _time;

                    IntPtr time;
                    Interop.NotificationEx.ChatMessageGetTime(NativeHandle, out time);
                    if (time == IntPtr.Zero)
                        return null;
                    _time = new Time(time);
                    return _time;
                }
            }

            /// <summary>
            /// A message type.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public ChatMessageType Type
            {
                get
                {
                    ChatMessageType type;
                    Interop.NotificationEx.ChatMessageGetMessageType(NativeHandle, out type);
                    return type;
                }
            }
        }
    }
}
