using System;
using ElmSharp;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The MediaView class allows application developers to display the video output on screen.
    /// </summary>
    /// <remarks>
    /// This view should not be instantiated directly.\n
    /// Use <see cref="Tizen.Xamarin.Forms.Extension.MediaView"/> to create the view.
    /// </remarks>
    /// <example>
    /// <code>
    /// Tizen.Xamarin.Forms.Extension.MediaView mediaView = ...
    /// ...
    /// var display = new Display((Tizen.Multimedia.MediaView)MediaView.NativeView);
    /// </code>
    /// </example>
    public class MediaView : EvasObject
    {
        /// <summary>
        /// This constructor is used by the infrastructure and is not intended to be used directly from application code.
        /// </summary>
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

