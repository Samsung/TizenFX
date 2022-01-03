using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The GraphicTypeExtensions class is graphics type converter for pixel based object.
    /// Density independent pixel(dp) unit is our basic target type and you can get converted value by PxToDp(),
    /// and you can get original pixel by PxToDp().
    /// One dp is a virtual pixel unit that's roughly equal to one pixel on a medium-density(160dpi) screen.
    /// See <see cref="Tizen.NUI.GraphicsTypeManager" /> and <see cref="Tizen.NUI.GraphicsTypeConverter" /> also.
    /// </summary>
    /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class GraphicsTypeExtensions
    {
        /// <summary>
        /// Converter float dp to pixel.
        /// </summary>
        /// <param name="dp">The float dp unit value to be converted pixel unit.</param>
        /// <returns>The float pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float DpToPx(this float dp)
        {
            return GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp);
        }

        /// <summary>
        /// Converter float sp to pixel.
        /// </summary>
        /// <param name="sp">The float sp unit value to be converted pixel unit.</param>
        /// <returns>The float pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float SpToPx(this float sp)
        {
            return GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp);
        }

        /// <summary>
        /// Converter float pixel to dp.
        /// </summary>
        /// <param name="pixel">The float pixel unit value to be converted dp unit.</param>
        /// <returns>The float dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float PxToDp(this float pixel)
        {
            return GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel);
        }

        /// <summary>
        /// Converter float pixel to sp.
        /// </summary>
        /// <param name="pixel">The float pixel unit value to be converted sp unit.</param>
        /// <returns>The float sp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float PxToSp(this float pixel)
        {
            return GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel);
        }

        /// <summary>
        /// Converter int dp to pixel.
        /// </summary>
        /// <param name="dp">The int dp unit value to be converted pixel unit.</param>
        /// <returns>The int pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int DpToPx(this int dp)
        {
            return (int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp);
        }

        /// <summary>
        /// Converter int dp to pixel.
        /// </summary>
        /// <param name="sp">The int sp unit value to be converted pixel unit.</param>
        /// <returns>The int pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int SpToPx(this int sp)
        {
            return (int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp);
        }

        /// <summary>
        /// Converter int pixel to dp.
        /// </summary>
        /// <param name="pixel">The int pixel unit value to be converted dp unit.</param>
        /// <returns>The int dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int PxToDp(this int pixel)
        {
            return (int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel);
        }

        /// <summary>
        /// Converter int pixel to sp.
        /// </summary>
        /// <param name="pixel">The int pixel unit value to be converted sp unit.</param>
        /// <returns>The int sp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int PxToSp(this int pixel)
        {
            return (int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel);
        }


        /// <summary>
        /// Converter Size pixel to dp.
        /// </summary>
        /// <param name="pixel">The Size pixel unit value to be converted dp unit.</param>
        /// <returns>The Size dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size PxToDp(this Size pixel)
        {
            if (pixel == null) return null;
            return new Size(GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Width),
                            GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Height));
        }

        /// <summary>
        /// Converter Size pixel to sp.
        /// </summary>
        /// <param name="pixel">The Size pixel unit value to be converted sp unit.</param>
        /// <returns>The Size sp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size PxToSp(this Size pixel)
        {
            if (pixel == null) return null;
            return new Size(GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Width),
                            GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Height));
        }

        /// <summary>
        /// Converter Size dp to pixel.
        /// </summary>
        /// <param name="dp">The Size dp unit value to be converted pixel unit.</param>
        /// <returns>The Size pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size DpToPx(this Size dp)
        {
            if (dp == null) return null;
            return new Size(GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Width),
                            GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Height));
        }

        /// <summary>
        /// Converter Size sp to pixel.
        /// </summary>
        /// <param name="sp">The Size sp unit value to be converted pixel unit.</param>
        /// <returns>The Size pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size SpToPx(this Size sp)
        {
            if (sp == null) return null;
            return new Size(GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Width),
                            GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Height));
        }

        /// <summary>
        /// Converter Size2D pixel to dp.
        /// </summary>
        /// <param name="pixel">The Size2D pixel unit value to be converted dp unit.</param>
        /// <returns>The Size2D dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D PxToDp(this Size2D pixel)
        {
            if (pixel == null) return null;
            return new Size2D((int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Width),
                              (int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Height));
        }

        /// <summary>
        /// Converter Size2D pixel to sp.
        /// </summary>
        /// <param name="pixel">The Size2D pixel unit value to be converted sp unit.</param>
        /// <returns>The Size2D sp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D PxToSp(this Size2D pixel)
        {
            if (pixel == null) return null;
            return new Size2D((int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Width),
                              (int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Height));
        }

        /// <summary>
        /// Converter Size2D dp to pixel.
        /// </summary>
        /// <param name="dp">The Size2D dp unit value to be converted pixel unit.</param>
        /// <returns>The Size2D pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D DpToPx(this Size2D dp)
        {
            if (dp == null) return null;
            return new Size2D((int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Width),
                              (int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Height));
        }

        /// <summary>
        /// Converter Size2D sp to pixel.
        /// </summary>
        /// <param name="sp">The Size2D sp unit value to be converted pixel unit.</param>
        /// <returns>The Size2D pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Size2D SpToPx(this Size2D sp)
        {
            if (sp == null) return null;
            return new Size2D((int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Width),
                              (int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Height));
        }

        /// <summary>
        /// Converter Position pixel to dp.
        /// </summary>
        /// <param name="pixel">The Position pixel unit value to be converted dp unit.</param>
        /// <returns>The Position dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position PxToDp(this Position pixel)
        {
            if (pixel == null) return null;
            return new Position(GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.X),
                                GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Y));
        }

        /// <summary>
        /// Converter Position pixel to sp.
        /// </summary>
        /// <param name="pixel">The Position pixel unit value to be converted sp unit.</param>
        /// <returns>The Position sp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position PxToSp(this Position pixel)
        {
            if (pixel == null) return null;
            return new Position(GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.X),
                                GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Y));
        }

        /// <summary>
        /// Converter Position dp to pixel.
        /// </summary>
        /// <param name="dp">The Position dp unit value to be converted pixel unit.</param>
        /// <returns>The Position pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position DpToPx(this Position dp)
        {
            if (dp == null) return null;
            return new Position(GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.X),
                                GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Y));
        }

        /// <summary>
        /// Converter Position sp to pixel.
        /// </summary>
        /// <param name="sp">The Position sp unit value to be converted pixel unit.</param>
        /// <returns>The Position pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position SpToPx(this Position sp)
        {
            if (sp == null) return null;
            return new Position(GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.X),
                                GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Y));
        }

        /// <summary>
        /// Converter Position2D pixel to dp.
        /// </summary>
        /// <param name="pixel">The Position2D pixel unit value to be converted dp unit.</param>
        /// <returns>The Position2D dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position2D PxToDp(this Position2D pixel)
        {
            if (pixel == null) return null;
            return new Position2D((int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.X),
                                  (int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Y));
        }

        /// <summary>
        /// Converter Position2D pixel to sp.
        /// </summary>
        /// <param name="pixel">The Position2D pixel unit value to be converted sp unit.</param>
        /// <returns>The Position2D sp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position2D PxToSp(this Position2D pixel)
        {
            if (pixel == null) return null;
            return new Position2D((int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.X),
                                  (int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Y));
        }

        /// <summary>
        /// Converter Position2D dp to pixel.
        /// </summary>
        /// <param name="dp">The Position2D dp unit value to be converted pixel unit.</param>
        /// <returns>The Position2D pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position2D DpToPx(this Position2D dp)
        {
            if (dp == null) return null;
            return new Position2D((int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.X),
                                  (int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Y));
        }

        /// <summary>
        /// Converter Position2D sp to pixel.
        /// </summary>
        /// <param name="sp">The Position2D sp unit value to be converted pixel unit.</param>
        /// <returns>The Position2D pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Position2D SpToPx(this Position2D sp)
        {
            if (sp == null) return null;
            return new Position2D((int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.X),
                                  (int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Y));
        }

        /// <summary>
        /// Converter Rectangle pixel to dp.
        /// </summary>
        /// <param name="pixel">The Rectangle pixel unit value to be converted dp unit.</param>
        /// <returns>The Rectangle dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Rectangle PxToDp(this Rectangle pixel)
        {
            if (pixel == null) return null;
            return new Rectangle((int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.X),
                                 (int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Y),
                                 (int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Width),
                                 (int)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Height));
        }

        /// <summary>
        /// Converter Rectangle pixel to sp.
        /// </summary>
        /// <param name="pixel">The Rectangle pixel unit value to be converted sp unit.</param>
        /// <returns>The Rectangle sp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Rectangle PxToSp(this Rectangle pixel)
        {
            if (pixel == null) return null;
            return new Rectangle((int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.X),
                                 (int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Y),
                                 (int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Width),
                                 (int)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Height));
        }

        /// <summary>
        /// Converter Rectangle dp to pixel.
        /// </summary>
        /// <param name="dp">The Rectangle dp unit value to be converted pixel unit.</param>
        /// <returns>The Rectangle pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Rectangle DpToPx(this Rectangle dp)
        {
            if (dp == null) return null;
            return new Rectangle((int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.X),
                                 (int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Y),
                                 (int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Width),
                                 (int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Height));
        }

        /// <summary>
        /// Converter Rectangle sp to pixel.
        /// </summary>
        /// <param name="sp">The Rectangle sp unit value to be converted pixel unit.</param>
        /// <returns>The Rectangle pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Rectangle SpToPx(this Rectangle sp)
        {
            if (sp == null) return null;
            return new Rectangle((int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.X),
                                 (int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Y),
                                 (int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Width),
                                 (int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Height));
        }

        /// <summary>
        /// Converter Extents pixel to dp.
        /// </summary>
        /// <param name="pixel">The Extents pixel unit value to be converted dp unit.</param>
        /// <returns>The Extents dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Extents PxToDp(this Extents pixel)
        {
            if (pixel == null) return null;
            return new Extents((ushort)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Start),
                               (ushort)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.End),
                               (ushort)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Top),
                               (ushort)GraphicsTypeManager.Instance.Dp.ConvertFromPixel(pixel.Bottom));
        }

        /// <summary>
        /// Converter Extents pixel to sp.
        /// </summary>
        /// <param name="pixel">The Extents pixel unit value to be converted sp unit.</param>
        /// <returns>The Extents sp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Extents PxToSp(this Extents pixel)
        {
            if (pixel == null) return null;
            return new Extents((ushort)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Start),
                               (ushort)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.End),
                               (ushort)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Top),
                               (ushort)GraphicsTypeManager.Instance.Sp.ConvertFromPixel(pixel.Bottom));
        }

        /// <summary>
        /// Converter Extents dp to pixel.
        /// </summary>
        /// <param name="dp">The Extents dp unit value to be converted pixel unit.</param>
        /// <returns>The Extents pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Extents DpToPx(this Extents dp)
        {
            if (dp == null) return null;
            return new Extents((ushort)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Start),
                               (ushort)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.End),
                               (ushort)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Top),
                               (ushort)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp.Bottom));
        }

        /// <summary>
        /// Converter Extents sp to pixel.
        /// </summary>
        /// <param name="sp">The Extents sp unit value to be converted pixel unit.</param>
        /// <returns>The Extents pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Extents SpToPx(this Extents sp)
        {
            if (sp == null) return null;
            return new Extents((ushort)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Start),
                               (ushort)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.End),
                               (ushort)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Top),
                               (ushort)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp.Bottom));
        }

        /// <summary>
        /// Converter float font pixel size to point size.
        /// </summary>
        /// <param name="pixel">The float pixel unit value to be converted point unit.</param>
        /// <returns>The float point unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float PxToPt(this float pixel)
        {
            return GraphicsTypeManager.Instance.Point.ConvertFromPixel(pixel);
        }

        /// <summary>
        /// Converter float font point size to pixel size.
        /// </summary>
        /// <param name="pt">The float point unit value to be converted pixel unit.</param>
        /// <returns>The float pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float PtToPixel(this float pt)
        {
            return GraphicsTypeManager.Instance.Point.ConvertToPixel(pt);
        }

        /// <summary>
        /// Converter float font dp size to point size.
        /// 16.0f.DpToPt() = 7.2f.
        /// </summary>
        /// <param name="dp">The float dp unit value to be converted point unit.</param>
        /// <returns>The float point unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float DpToPt(this float dp)
        {
            return GraphicsTypeManager.Instance.Point.ConvertDpToPoint(dp);
        }

        /// <summary>
        /// Converter float font point size to dp size.
        /// 7.2f.PtToDp() = 16.0f.
        /// </summary>
        /// <param name="pt">The float point unit value to be converted dp unit.</param>
        /// <returns>The float dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float PtToDp(this float pt)
        {
            return GraphicsTypeManager.Instance.Point.ConvertPointToDp(pt);
        }
    }
}
