using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The GraphicTypeExtensions class is graphics type coverter for pixel based object.
    /// Density independent pixel(dp) unit is our basic target type and you can get converted value by ToDp(),
    /// and you can get original pixel by ToDp().
    /// One dp is a virtual pixel unit that's roughly equal to one pixel on a medium-density(160dpi) screen.
    /// See <see cref="Tizen.NUI.GraphicsTypeManager" /> and <see cref="Tizen.NUI.GraphicsTypeConverter" /> also.
    /// </summary>
    /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class GraphicsTypeExtensions
    {
        /// <summary>
        /// Converter float pixel to dp.
        /// 100.0f.ToDp() = 50.0f in 320dpi display.
        /// </summary>
        /// <param name="pixel">The float pixel unit value to be converted dp unit.</param>
        /// <returns>The float dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float ToDp(this float pixel)
        {
            return GraphicsTypeManager.Instance.ConvertFromPixel(pixel);
        }

        /// <summary>
        /// Converter float dp to pixel.
        /// 100.0f.ToPixel() = 200.0f in 320dpi display.
        /// </summary>
        /// <param name="dp">The float dp unit value to be converted pixel unit.</param>
        /// <returns>The float pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float ToPixel(this float dp)
        {
            return GraphicsTypeManager.Instance.ConvertToPixel(dp);
        }

        /// <summary>
        /// Converter int pixel to dp.
        /// 100.ToDp() = 50 in 320dpi display.
        /// </summary>
        /// <param name="pixel">The int pixel unit value to be converted dp unit.</param>
        /// <returns>The int dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int ToDp(this int pixel)
        {
            return (int)GraphicsTypeManager.Instance.ConvertFromPixel(pixel);
        }

        /// <summary>
        /// Converter int dp to pixel.
        /// 100.ToPixel() = 200 in 320dpi display.
        /// </summary>
        /// <param name="dp">The int dp unit value to be converted pixel unit.</param>
        /// <returns>The int pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int ToPixel(this int dp)
        {
            return (int)GraphicsTypeManager.Instance.ConvertToPixel(dp);
        }

        /// <summary>
        /// Converter Size pixel to dp.
        /// Size(100.0f, 100.0f).ToDp() = Size(50.0f, 50.0f) in 320dpi display.
        /// </summary>
        /// <param name="pixel">The Size pixel unit value to be converted dp unit.</param>
        /// <returns>The Size dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size ToDp(this Size pixel)
        {
            return new Size(GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Width),
                            GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Height));
        }

        /// <summary>
        /// Converter Size dp to pixel.
        /// Size(100.0f, 100.0f).ToPixel() = Size(200.0f, 200.0f) in 320dpi display.
        /// </summary>
        /// <param name="dp">The Size dp unit value to be converted pixel unit.</param>
        /// <returns>The Size pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size ToPixel(this Size dp)
        {
            return new Size(GraphicsTypeManager.Instance.ConvertToPixel(dp.Width),
                            GraphicsTypeManager.Instance.ConvertToPixel(dp.Height));
        }

        /// <summary>
        /// Converter Position pixel to dp.
        /// Position(100.0f, 100.0f).ToDp() = Position(50.0f, 50.0f) in 320dpi display.
        /// </summary>
        /// <param name="pixel">The Position pixel unit value to be converted dp unit.</param>
        /// <returns>The Position dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position ToDp(this Position pixel)
        {
            return new Position(GraphicsTypeManager.Instance.ConvertFromPixel(pixel.X),
                                GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Y));
        }

        /// <summary>
        /// Converter Position dp to pixel.
        /// Position(100.0f, 100.0f).ToPixel() = Position(200.0f, 200.0f) in 320dpi display.
        /// </summary>
        /// <param name="dp">The Position dp unit value to be converted pixel unit.</param>
        /// <returns>The Position pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position ToPixel(this Position dp)
        {
            return new Position(GraphicsTypeManager.Instance.ConvertToPixel(dp.X),
                                GraphicsTypeManager.Instance.ConvertToPixel(dp.Y));
        }

        /// <summary>
        /// Converter Rectangle pixel to dp.
        /// Rectangle(100, 100, 100, 100).ToDp() = Rectangle(50, 50, 50, 50) in 320dpi display.
        /// </summary>
        /// <param name="pixel">The Rectangle pixel unit value to be converted dp unit.</param>
        /// <returns>The Rectangle dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Rectangle ToDp(this Rectangle pixel)
        {
            return new Rectangle((int)GraphicsTypeManager.Instance.ConvertFromPixel(pixel.X),
                                 (int)GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Y),
                                 (int)GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Width),
                                 (int)GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Height));
        }

        /// <summary>
        /// Converter Rectangle dp to pixel.
        /// Rectangle(100, 100, 100, 100).ToPixel() = Rectangle(200, 200, 200, 200) in 320dpi display.
        /// </summary>
        /// <param name="dp">The Rectangle dp unit value to be converted pixel unit.</param>
        /// <returns>The Rectangle pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Rectangle ToPixel(this Rectangle dp)
        {
            return new Rectangle((int)GraphicsTypeManager.Instance.ConvertToPixel(dp.X),
                                 (int)GraphicsTypeManager.Instance.ConvertToPixel(dp.Y),
                                 (int)GraphicsTypeManager.Instance.ConvertToPixel(dp.Width),
                                 (int)GraphicsTypeManager.Instance.ConvertToPixel(dp.Height));
        }

        /// <summary>
        /// Converter Extents pixel to dp.
        /// Extents(2, 2, 2, 2).ToDp() = Extents(1, 1, 1, 1) in 320dpi display.
        /// </summary>
        /// <param name="pixel">The Extents pixel unit value to be converted dp unit.</param>
        /// <returns>The Extents dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Extents ToDp(this Extents pixel)
        {
            return new Extents((ushort)GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Start),
                               (ushort)GraphicsTypeManager.Instance.ConvertFromPixel(pixel.End),
                               (ushort)GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Top),
                               (ushort)GraphicsTypeManager.Instance.ConvertFromPixel(pixel.Bottom));
        }

        /// <summary>
        /// Converter Extents dp to pixel.
        /// Extents(2, 2, 2, 2).ToPixel() = Extents(4, 4, 4, 4) in 320dpi display.
        /// </summary>
        /// <param name="dp">The Extents dp unit value to be converted pixel unit.</param>
        /// <returns>The Extents pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Extents ToPixel(this Extents dp)
        {
            return new Extents((ushort)GraphicsTypeManager.Instance.ConvertToPixel(dp.Start),
                               (ushort)GraphicsTypeManager.Instance.ConvertToPixel(dp.End),
                               (ushort)GraphicsTypeManager.Instance.ConvertToPixel(dp.Top),
                               (ushort)GraphicsTypeManager.Instance.ConvertToPixel(dp.Bottom));
        }
    }
}
