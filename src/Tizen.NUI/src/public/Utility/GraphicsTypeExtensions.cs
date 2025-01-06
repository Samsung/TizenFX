/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
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
        public static float Dp(this float dp)
        {
            return GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp);
        }

        /// <summary>
        /// Converter float dp to pixel.
        /// </summary>
        /// <param name="dp">The float dp unit value to be converted pixel unit.</param>
        /// <returns>The float pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float DpToPx(this float dp)
        {
            return Dp(dp);
        }

        /// <summary>
        /// Converter float scaled dp to pixel.
        /// </summary>
        /// <param name="sp">The float scaled dp unit value to be converted pixel unit.</param>
        /// <returns>The float pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float Sp(this float sp)
        {
            return GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp);
        }

        /// <summary>
        /// Converter float scaled dp to pixel.
        /// </summary>
        /// <param name="sp">The float scaled dp unit value to be converted pixel unit.</param>
        /// <returns>The float pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float SpToPx(this float sp)
        {
            return Sp(sp);
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
            return PxToDp(pixel);
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
            return PxToSp(pixel);
        }

        /// <summary>
        /// Converter int dp to pixel.
        /// </summary>
        /// <param name="dp">The int dp unit value to be converted pixel unit.</param>
        /// <returns>The int pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int Dp(this int dp)
        {
            return (int)GraphicsTypeManager.Instance.Dp.ConvertToPixel(dp);
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
            return Dp(dp);
        }

        /// <summary>
        /// Converter int dp to pixel.
        /// </summary>
        /// <param name="sp">The int sp unit value to be converted pixel unit.</param>
        /// <returns>The int pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int Sp(this int sp)
        {
            return (int)GraphicsTypeManager.Instance.Sp.ConvertToPixel(sp);
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
            return Sp(sp);
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
            return (int)PxToDp(pixel);
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
            return (int)PxToSp(pixel);
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
            return new Size(Dp(dp.Width), Dp(dp.Height));
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
            return new Size(Sp(sp.Width), Sp(sp.Height));
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
            return new Size(PxToDp(pixel.Width), PxToDp(pixel.Height));
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
            return new Size(PxToSp(pixel.Width), PxToSp(pixel.Height));
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
            return new Size2D(PxToDp(pixel.Width), PxToDp(pixel.Height));
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
            return new Size2D(PxToSp(pixel.Width), PxToSp(pixel.Height));
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
            return new Size2D(Dp(dp.Width), Dp(dp.Height));
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
            return new Size2D(Sp(sp.Width), Sp(sp.Height));
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
            return new Position(PxToDp(pixel.X), PxToDp(pixel.Y));
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
            return new Position(PxToSp(pixel.X), PxToSp(pixel.Y));
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
            return new Position(Dp(dp.X), Dp(dp.Y));
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
            return new Position(Sp(sp.X), Sp(sp.Y));
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
            return new Position2D(PxToDp(pixel.X), PxToDp(pixel.Y));
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
            return new Position2D(PxToSp(pixel.X), PxToSp(pixel.Y));
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
            return new Position2D(Dp(dp.X), Dp(dp.Y));
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
            return new Position2D(Sp(sp.X), Sp(sp.Y));
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
            return new Rectangle(PxToDp(pixel.X), PxToDp(pixel.Y), PxToDp(pixel.Width), PxToDp(pixel.Height));
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
            return new Rectangle(PxToSp(pixel.X), PxToSp(pixel.Y), PxToSp(pixel.Width), PxToSp(pixel.Height));
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
            return new Rectangle(Dp(dp.X), Dp(dp.Y), Dp(dp.Width), Dp(dp.Height));
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
            return new Rectangle((int)Sp(sp.X), Sp(sp.Y), Sp(sp.Width), Sp(sp.Height));
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
            return new Extents((ushort)PxToDp((int)pixel.Start),
                               (ushort)PxToDp((int)pixel.End),
                               (ushort)PxToDp((int)pixel.Top),
                               (ushort)PxToDp((int)pixel.Bottom));
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
            return new Extents((ushort)PxToSp((int)pixel.Start),
                               (ushort)PxToSp((int)pixel.End),
                               (ushort)PxToSp((int)pixel.Top),
                               (ushort)PxToSp((int)pixel.Bottom));
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
            return new Extents((ushort)Dp(dp.Start),
                               (ushort)Dp(dp.End),
                               (ushort)Dp(dp.Top),
                               (ushort)Dp(dp.Bottom));
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
            return new Extents((ushort)Sp(sp.Start),
                               (ushort)Sp(sp.End),
                               (ushort)Sp(sp.Top),
                               (ushort)Sp(sp.Bottom));
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
        public static float PtToPx(this float pt)
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

        /// <summary>
        /// Converter float font sp size to point size.
        /// </summary>
        /// <param name="sp">The float sp unit value to be converted point unit.</param>
        /// <returns>The float point unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float SpToPt(this float sp)
        {
            return GraphicsTypeManager.Instance.Point.ConvertSpToPoint(sp);
        }

        /// <summary>
        /// Converter float font point size to sp size.
        /// </summary>
        /// <param name="pt">The float point unit value to be converted sp unit.</param>
        /// <returns>The float dp unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float PtToSp(this float pt)
        {
            return GraphicsTypeManager.Instance.Point.ConvertPointToSp(pt);
        }

        /// <summary>
        /// Converter float pixel to scaled pixel.
        /// </summary>
        /// <param name="px">The float pixel value to be scaled.</param>
        /// <returns>The float scaled pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float Scale(this float px)
        {
            return px * GraphicsTypeManager.Instance.ScalingFactor;
        }

        /// <summary>
        /// Converter int pixel to scaled pixel.
        /// </summary>
        /// <param name="px">The int pixel value to be scaled.</param>
        /// <returns>The int scaled pixel unit value.</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int Scale(this int px)
        {
            return (int)(px * GraphicsTypeManager.Instance.ScalingFactor);
        }

    }
}
