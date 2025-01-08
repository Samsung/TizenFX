/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Markup
{
    /// <summary>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ViewExtensions
    {
        /// <summary>
        /// Assign this view reference to the given variable.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="self">The variable to save the reference to.</param>
        /// <returns>The view itself.</returns>
        public static T Self<T>(this T view, out T self)  where T : View
        {
            self = view;
            return view;
        }

        /// <summary>
        /// Sets the background color of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T BackgroundColor<T>(this T view, float r, float g, float b, float a = 1f) where T : View
        {
            return view.BackgroundColor(new L.Color(r, g, b, a));
        }

        /// <summary>
        /// Sets the background color of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="value">The value of 0xRRGGBB format.</param>
        /// <param name="alpha">The alpha value between 0.0 and 1.0.</param>
        /// <returns>The view itself.</returns>
        public static T BackgroundColor<T>(this T view, uint value, float alpha) where T : View
        {
            return view.BackgroundColor(new L.Color(value, alpha));
        }

        /// <summary>
        /// Sets the background color of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T BackgroundColor<T>(this T view, L.Color color) where T : View
        {
            view.SetBackgroundColor(color);
            return view;
        }

        /// <summary>
        /// Experimental getter for background color
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The background color value.</returns>
        public static L.Color BackgroundColor(this View view)
        {
            return Object.InternalRetrievingVisualPropertyColor(view.SwigCPtr, View.Property.BACKGROUND, ColorVisualProperty.MixColor);
        }

        /// <summary>
        /// Sets the size of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        /// <returns>The view itself.</returns>
        public static T Size<T>(this T view, float width, float height) where T : View
        {
            view.SizeWidth = width;
            view.SizeHeight = height;
            return view;
        }

        /// <summary>
        /// Sets the size width of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="width">The width value.</param>
        /// <returns>The view itself.</returns>
        public static T SizeWidth<T>(this T view, float width) where T : View
        {
            view.SizeWidth = width;
            return view;
        }

        /// <summary>
        /// Sets the size height of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="height">The width value.</param>
        /// <returns>The view itself.</returns>
        public static T SizeHeight<T>(this T view, float height) where T : View
        {
            view.SizeHeight = height;
            return view;
        }

        /// <summary>
        /// Sets the position of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <returns>The view itself.</returns>
        public static T Position<T>(this T view, float x, float y) where T : View
        {
            view.PositionX = x;
            view.PositionY = y;
            return view;
        }

        /// <summary>
        /// Sets the position x of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="x">The x value.</param>
        /// <returns>The view itself.</returns>
        public static T PositionX<T>(this T view, float x) where T : View
        {
            view.PositionX = x;
            return view;
        }

        /// <summary>
        /// Sets the position y of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="y">The y value.</param>
        /// <returns>The view itself.</returns>
        public static T PositionY<T>(this T view, float y) where T : View
        {
            view.PositionY = y;
            return view;
        }

        /// <summary>
        /// Sets the corner radius of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="uniform">The uniform corner value.</param>
        /// <param name="isRelative">Sets the corner radius policy to relative. The default is false.</param>
        /// <returns>The view itself.</returns>
        public static T CornerRadius<T>(this T view, float uniform, bool isRelative = false) where T : View
        {
            return view.CornerRadius(new L.Corner(uniform, uniform, uniform, uniform), isRelative);
        }

        /// <summary>
        /// Sets the corner radius of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="topLeft">The top-left value.</param>
        /// <param name="topRight">The top-right value.</param>
        /// <param name="bottomRight">The bottom-right value.</param>
        /// <param name="bottomLeft">The bottom-left value.</param>
        /// <param name="isRelative">Sets the corner radius policy to relative. The default is false.</param>
        /// <returns>The view itself.</returns>
        public static T CornerRadius<T>(this T view, float topLeft, float topRight, float bottomRight, float bottomLeft, bool isRelative = false) where T : View
        {
            return view.CornerRadius(new L.Corner(topLeft, topRight, bottomRight, bottomLeft), isRelative);
        }

        /// <summary>
        /// Sets the corner radius of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="corner">The corner value.</param>
        /// <param name="isRelative">Sets the corner radius policy to relative. The default is false.</param>
        /// <returns>The view itself.</returns>
        public static T CornerRadius<T>(this T view, L.Corner corner, bool isRelative = false) where T : View
        {
            // TODO Do not create Vector4 here
            view.CornerRadius = corner.ToReferenceType();
            view.CornerRadiusPolicy = isRelative ? VisualTransformPolicyType.Relative : VisualTransformPolicyType.Absolute;
            return view;
        }

        /// <summary>
        /// Sets the box shadow of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="offsetX">Optional. The x offset value from the top left corner. The default is 0.</param>
        /// <param name="offsetY">Optional. The y offset value from the top left corner. The default is 0.</param>
        /// <param name="extraWidth">Optional. The shadow will extend its size by specified amount of length. The default is 0.</param>
        /// <param name="extraHeight">Optional. The shadow will extend its size by specified amount of length. The default is 0.</param>
        /// <param name="cutoutPolicy">The policy of the shadow cutout. The default is <see cref="ColorVisualCutoutPolicyType.None"/>.</param>
        /// <returns>The view itself.</returns>
        public static T BoxShadow<T>(this T view, float blurRadius, float offsetX = 0, float offsetY = 0, float extraWidth = 0, float extraHeight = 0, ColorVisualCutoutPolicyType cutoutPolicy = ColorVisualCutoutPolicyType.None) where T : View
        {
            return view.BoxShadow(new L.Shadow(blurRadius, offsetX, offsetY, extraWidth, extraHeight, cutoutPolicy));
        }

        /// <summary>
        /// Sets the box shadow of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="color">The color for the shadow.</param>
        /// <param name="offsetX">Optional. The x offset value from the top left corner. The default is 0.</param>
        /// <param name="offsetY">Optional. The y offset value from the top left corner. The default is 0.</param>
        /// <param name="extraWidth">Optional. The shadow will extend its size by specified amount of length. The default is 0.</param>
        /// <param name="extraHeight">Optional. The shadow will extend its size by specified amount of length. The default is 0.</param>
        /// <param name="cutoutPolicy">The policy of the shadow cutout. The default is <see cref="ColorVisualCutoutPolicyType.None"/>.</param>
        /// <returns>The view itself.</returns>
        public static T BoxShadow<T>(this T view, float blurRadius, L.Color color, float offsetX = 0, float offsetY = 0, float extraWidth = 0, float extraHeight = 0, ColorVisualCutoutPolicyType cutoutPolicy = ColorVisualCutoutPolicyType.None) where T : View
        {
            return view.BoxShadow(new L.Shadow(blurRadius, color, offsetX, offsetY, extraWidth, extraHeight, cutoutPolicy));
        }

        /// <summary>
        /// Sets the box shadow of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="shadow">The shadow value.</param>
        /// <returns>The view itself.</returns>
        public static T BoxShadow<T>(this T view, L.Shadow shadow) where T : View
        {
            view.SetBoxShadow(shadow);
            return view;
        }
    }
}
