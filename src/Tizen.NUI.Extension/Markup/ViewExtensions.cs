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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Extension
{
    /// <summary>
    /// Markup extensions for View.
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
        public static T Self<T>(this T view, out T self) where T : View
        {
            self = view;
            return view;
        }

        /// <summary>
        /// Sets the color of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T Color<T>(this T view, float r, float g, float b, float a = 1f) where T : View
        {
            view.Color = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// Sets the color of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="value">The value of 0xRRGGBB format.</param>
        /// <param name="alpha">The alpha value between 0.0 and 1.0.</param>
        /// <example>
        /// <code>
        ///     new UIColor(0xFF0000, 1f); // Solid red
        ///     new UIColor(0x00FF00, 0.5f) // Half transparent green
        /// </code>
        /// </example>
        /// <returns>The view itself.</returns>
        public static T Color<T>(this T view, uint value, float alpha) where T : View
        {
            view.Color = (new UIColor(value, alpha)).ToReferenceType();
            return view;
        }

        /// <summary>
        /// Sets the color of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T Color<T>(this T view, UIColor color) where T : View
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.Color = color.ToReferenceType();
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
            return view.BackgroundColor(new UIColor(r, g, b, a));
        }

        /// <summary>
        /// Sets the background color of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="value">The value of 0xRRGGBB format.</param>
        /// <param name="alpha">The alpha value between 0.0 and 1.0.</param>
        /// <example>
        /// <code>
        ///     new UIColor(0xFF0000, 1f); // Solid red
        ///     new UIColor(0x00FF00, 0.5f) // Half transparent green
        /// </code>
        /// </example>
        /// <returns>The view itself.</returns>
        public static T BackgroundColor<T>(this T view, uint value, float alpha) where T : View
        {
            return view.BackgroundColor(new UIColor(value, alpha));
        }

        /// <summary>
        /// Sets the background color of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T BackgroundColor<T>(this T view, UIColor color) where T : View
        {
            view.SetBackgroundColor(color);
            return view;
        }

        /// <summary>
        /// Sets the background image of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="url">The resource url.</param>
        /// <returns>The view itself.</returns>
        public static T BackgroundImage<T>(this T view, string url) where T : View
        {
            view.BackgroundImage = url;
            return view;
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
        /// Sets the size of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="size">The size value.</param>
        /// <returns>The view itself.</returns>
        public static T Size<T>(this T view, UIVector2 size) where T : View
        {
            return Size(view, size.Width, size.Height);
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
        /// Sets the position of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="position">The position value.</param>
        /// <returns>The view itself.</returns>
        public static T Position<T>(this T view, UIVector2 position) where T : View
        {
            return Position(view, position.X, position.Y);
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
        /// <remarks>This sets both <see cref="View.CornerRadius"/> and <see cref="View.CornerRadiusPolicy"/> at once.</remarks>
        public static T CornerRadius<T>(this T view, float uniform, bool isRelative = false) where T : View
        {
            return view.CornerRadius(new UICorner(uniform, isRelative));
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
        /// <remarks>This sets both <see cref="View.CornerRadius"/> and <see cref="View.CornerRadiusPolicy"/> at once.</remarks>
        public static T CornerRadius<T>(this T view, float topLeft, float topRight, float bottomRight, float bottomLeft, bool isRelative = false) where T : View
        {
            return view.CornerRadius(new UICorner(topLeft, topRight, bottomRight, bottomLeft, isRelative));
        }

        /// <summary>
        /// Sets the corner radius of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="corner">The corner value.</param>
        /// <returns>The view itself.</returns>
        /// <remarks>This sets both <see cref="View.CornerRadius"/> and <see cref="View.CornerRadiusPolicy"/> at once.</remarks>
        public static T CornerRadius<T>(this T view, UICorner corner) where T : View
        {
            // TODO Do not create Vector4 here
            view.CornerRadius = corner.ToReferenceType();
            view.CornerRadiusPolicy = corner.IsRelative ? VisualTransformPolicyType.Relative : VisualTransformPolicyType.Absolute;
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
        /// <returns>The view itself.</returns>
        public static T BoxShadow<T>(this T view, float blurRadius, float offsetX = 0, float offsetY = 0) where T : View
        {
            return view.BoxShadow(new UIShadow(blurRadius, offsetX, offsetY));
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
        /// <returns>The view itself.</returns>
        public static T BoxShadow<T>(this T view, float blurRadius, UIColor color, float offsetX = 0, float offsetY = 0) where T : View
        {
            return view.BoxShadow(new UIShadow(blurRadius, color, offsetX, offsetY));
        }

        /// <summary>
        /// Sets the box shadow of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="shadow">The shadow value.</param>
        /// <returns>The view itself.</returns>
        public static T BoxShadow<T>(this T view, UIShadow shadow) where T : View
        {
            view.SetBoxShadow(shadow);
            return view;
        }

        /// <summary>
        /// Sets the image shadow of the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="shadow">The image shadow value.</param>
        /// <returns>The view itself.</returns>
        public static T ImageShadow<T>(this T view, ImageShadow shadow) where T : View
        {
            view.ImageShadow = shadow;
            return view;
        }

        /// <summary>
        /// Sets the width for the borderline of the View.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="width">The width value.</param>
        /// <returns>The view itself.</returns>
        public static T BorderlineWidth<T>(this T view, float width) where T : View
        {
            view.BorderlineWidth = width;
            return view;
        }

        /// <summary>
        /// Sets the color for the borderline of the View.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T BorderlineColor<T>(this T view, float r, float g, float b, float a = 1f) where T : View
        {
            view.BorderlineColor = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// Sets the color for the borderline of the View.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="value">The value of 0xRRGGBB format.</param>
        /// <param name="alpha">The alpha value between 0.0 and 1.0.</param>
        /// <example>
        /// <code>
        ///     new UIColor(0xFF0000, 1f); // Solid red
        ///     new UIColor(0x00FF00, 0.5f) // Half transparent green
        /// </code>
        /// </example>
        /// <returns>The view itself.</returns>
        public static T BorderlineColor<T>(this T view, uint value, float alpha) where T : View
        {
            view.BorderlineColor = (new UIColor(value, alpha)).ToReferenceType();
            return view;
        }


        /// <summary>
        /// Sets the color for the borderline of the View.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T BorderlineColor<T>(this T view, UIColor color) where T : View
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.BorderlineColor = color.ToReferenceType();
            return view;
        }

        /// <summary>
        /// Sets the offset for the borderline of the View.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="offset">The offset value.</param>
        /// <returns>The view itself.</returns>
        public static T BorderlineOffset<T>(this T view, float offset) where T : View
        {
            view.BorderlineOffset = offset;
            return view;
        }

        /// <summary>
        /// Sets the borderline of the View.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="width">The width value.</param>
        /// <param name="color">The color value.</param>
        /// <param name="offset">The offset value.</param>
        /// <returns>The view itself.</returns>
        public static T Borderline<T>(this T view, float width, UIColor color, float offset) where T : View
        {
            view.BorderlineWidth = width;
            //FIXME: we need to set UI value type directly without converting reference value.
            view.BorderlineColor = color.ToReferenceType();
            view.BorderlineOffset = offset;
            return view;
        }

        /// <summary>
        /// Sets the view's opacity
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="opacity">The opacity value.</param>
        /// <returns>The view itself.</returns>
        public static T Opacity<T>(this T view, float opacity) where T : View
        {
            view.Opacity = opacity;
            return view;
        }

        /// <summary>
        /// Sets the scale X factor applied to the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns>The view itself.</returns>
        public static T ScaleX<T>(this T view, float scale) where T : View
        {
            view.ScaleX = scale;
            return view;
        }

        /// <summary>
        /// Sets the scale Y factor applied to the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns>The view itself.</returns>
        public static T ScaleY<T>(this T view, float scale) where T : View
        {
            view.ScaleY = scale;
            return view;
        }

        /// <summary>
        /// Sets the scale factor applied to the view.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="scaleX">The scale x value.</param>
        /// <param name="scaleY">The scale y value.</param>
        /// <returns>The view itself.</returns>
        public static T Scale<T>(this T view, float scaleX, float scaleY) where T : View
        {
            view.ScaleX = scaleX;
            view.ScaleY = scaleY;
            return view;
        }

        /// <summary>
        /// Sets the visibility of the view.
        /// <see cref="Tizen.NUI.BaseComponents.View.Visibility"/>
        /// <seealso cref="Tizen.NUI.BaseComponents.View.Show()"/>
        /// <seealso cref="Tizen.NUI.BaseComponents.View.Hide()"/>
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="visiblity">The visibility value.</param>
        /// <returns>The view itself.</returns>
        public static T Visibility<T>(this T view, bool visiblity) where T : View
        {
            if (view.Visibility != visiblity)
            {
                if (visiblity)
                {
                    view.Show();
                }
                else
                {
                    view.Hide();
                }
            }
            return view;
        }

        /// <summary>
        /// Sets the status of whether the view should emit touch or hover signals.
        /// If a View is made insensitive, then the View and its children are not hittable.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="sensitive">The sensitive value.</param>
        /// <returns>The view itself.</returns>
        public static T Sensitive<T>(this T view, bool sensitive) where T : View
        {
            view.Sensitive = sensitive;
            return view;
        }

        /// <summary>
        /// Sets the status of whether the view should be enabled user interactions.
        /// If a View is made disabled, then user interactions including touch, focus, and actiavation is disabled.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="enable">The enable value.</param>
        /// <returns>The view itself.</returns>
        public static T IsEnabled<T>(this T view, bool enable) where T : View
        {
            view.IsEnabled = enable;
            return view;
        }

        /// <summary>
        /// Sets the clipping behavior (mode) of it's children.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="type">The clipping mode type value.</param>
        /// <returns>The view itself.</returns>
        public static T ClippingMode<T>(this T view, ClippingModeType type) where T : View
        {
            view.ClippingMode = type;
            return view;
        }

        /// <summary>
        /// Set the layout on this View. Replaces any existing Layout.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="layout">The layout for the view.</param>
        /// <returns>The view itself.</returns>
        public static T Layout<T>(this T view, LayoutItem layout) where T : View
        {
            view.Layout = layout;
            return view;
        }

        /// <summary>
        /// Sets focusable of the view
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="focusable">The focusable value.</param>
        /// <returns>The view itself.</returns>
        public static T Focusable<T>(this T view, bool focusable) where T : View
        {
            view.Focusable = focusable;
            return view;
        }

        /// <summary>
        /// Sets whether the children of this view can be focusable by keyboard navigation.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="focusable">The focusable value.</param>
        /// <returns>The view itself.</returns>
        public static T FocusableChildren<T>(this T view, bool focusable) where T : View
        {
            view.FocusableChildren = focusable;
            return view;
        }

        /// <summary>
        /// Sets whether the view can focus by touch.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="focusable">The focusable value.</param>
        /// <returns>The view itself.</returns>
        public static T FocusableInTouch<T>(this T view, bool focusable) where T : View
        {
            view.FocusableInTouch = focusable;
            return view;
        }

        /// <summary>
        /// Set voice interaction name for Voice Touch.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="name">The name value.</param>
        /// <returns>The view itself.</returns>
        public static T VoiceInteractionName<T>(this T view, string name) where T : View
        {
            view.VoiceInteractionName = name;
            return view;
        }

/* Getters */

        /// <summary>
        /// Gets the color for the View.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The color value.</returns>
        public static UIColor Color(this View view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return new UIColor(view.Color);
        }

        /// <summary>
        /// Experimental getter for background color
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The background color value.</returns>
        public static UIColor BackgroundColor(this View view)
        {
            return Object.InternalRetrievingVisualPropertyColor(view.SwigCPtr, View.Property.BACKGROUND, ColorVisualProperty.MixColor);
        }

        /// <summary>
        /// Experimental getter for size
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The size value.</returns>
        public static UIVector2 Size(this View view)
        {
            return new UIVector2(view.SizeWidth, view.SizeHeight);
        }

        /// <summary>
        /// Experimental getter for position
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The position value.</returns>
        public static UIVector2 Position(this View view)
        {
            return new UIVector2(view.PositionX, view.PositionY);
        }

        /// <summary>
        /// Gets the corner radius of the view.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The corner radius value.</returns>
        public static UICorner CornerRadius(this View view)
        {
            // TODO Do not use Vector4 here
            var corner = view.CornerRadius;
            return new UICorner(corner.X, corner.Y, corner.Z, corner.W, view.CornerRadiusPolicy == VisualTransformPolicyType.Relative);
        }

        /// <summary>
        /// Gets the color for the borderline of the View.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The borderline color value.</returns>
        public static UIColor BorderlineColor(this View view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return new UIColor(view.BorderlineColor);
        }

        /// <summary>
        /// Sets the width of the view used to size the view within its parent layout container. It can be set to a fixed value, wrap content, or match parent.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="layoutWidth">The layout dimension of the width of the view.</param>
        /// <returns>The view itself.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T LayoutWidth<T>(this T view, LayoutDimension layoutWidth) where T : View
        {
            view.LayoutWidth = layoutWidth;
            return view;
        }

        /// <summary>
        /// Sets the height of the view used to size the view within its parent layout container. It can be set to a fixed value, wrap content, or match parent.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="layoutHeight">The layout dimension of the height of the view.</param>
        /// <returns>The view itself.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T LayoutHeight<T>(this T view, LayoutDimension layoutHeight) where T : View
        {
            view.LayoutHeight = layoutHeight;
            return view;
        }

        /// <summary>
        /// Sets the minimum width of the view used to size the view within its parent layout container.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="minimumWidth">The minimum width value.</param>
        /// <returns>The view itself.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T MinimumWidth<T>(this T view, float minimumWidth) where T : View
        {
            view.SetMinimumWidth(minimumWidth, true);
            return view;
        }

        /// <summary>
        /// Sets the minimum height of the view used to size the view within its parent layout container.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="minimumHeight">The minimum height value.</param>
        /// <returns>The view itself.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T MinimumHeight<T>(this T view, float minimumHeight) where T : View
        {
            view.SetMinimumHeight(minimumHeight, true);
            return view;
        }

        /// <summary>
        /// Sets the maximum width of the view used to size the view within its parent layout container.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="maximumWidth">The maximum width value.</param>
        /// <returns>The view itself.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T MaximumWidth<T>(this T view, float maximumWidth) where T : View
        {
            view.SetMaximumWidth(maximumWidth, true);
            return view;
        }

        /// <summary>
        /// Sets the maximum height of the view used to size the view within its parent layout container.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="maximumHeight">The maximum height value.</param>
        /// <returns>The view itself.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T MaximumHeight<T>(this T view, float maximumHeight) where T : View
        {
            view.SetMaximumHeight(maximumHeight, true);
            return view;
        }
    }
}
