using System;
using ElmSharp;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The MediaView class allows application developers to display the video output on screen.
    /// </summary>
    public class MediaView : EvasObject
    {
        public MediaView(EvasObject parent) : base(parent)
        {
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr evas = Interop.EvasObject.evas_object_evas_get(parent);
            return Interop.EvasObject.evas_object_image_add(evas);
        }
    }
}

