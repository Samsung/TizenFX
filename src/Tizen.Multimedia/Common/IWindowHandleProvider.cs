using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The IWindowHandleProvider interface provides the window handle and information about the window's position, size, and rotation.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public interface IWindowHandleProvider
    {
        /// <summary>
        /// Gets the window handle
        /// </summary>
        IntPtr WindowHandle { get; }

        /// <summary>
        /// Gets the x-coordinate of the window's position.
        /// </summary>
        float X { get; }
        /// <summary>
        /// Gets the y-coordinate of the window's position.
        /// </summary>
        float Y { get; }

        /// <summary>
        /// Gets the width of the window.
        /// </summary>
        float Width { get; }

        /// <summary>
        /// Gets the height of the window.
        /// </summary>
        float Height { get; }

        /// <summary>
        /// Gets the rotation of the window in degrees. The value can only be 0, 90, 180, or 270.
        /// </summary>
        int Rotation { get; }
    }
}
