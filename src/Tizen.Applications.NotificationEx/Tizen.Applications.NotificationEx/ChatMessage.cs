using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class ChatMessage : AbstractItem
        {
            private Text _text;
            private Text _name;
            private Image _image;
            private Time _time;

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
