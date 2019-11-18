using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Image : AbstractItem
        {
            public Image(string id, string imagePath) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ImageCreate(out handle, id, imagePath);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Image(IntPtr ptr) : base(ptr)
            {
            }

            public string Path
            {
                get
                {
                    string imagePath;
                    Interop.NotificationEx.ImageGetImagePath(NativeHandle, out imagePath);
                    return imagePath;
                }
            }
        }
    }
}
