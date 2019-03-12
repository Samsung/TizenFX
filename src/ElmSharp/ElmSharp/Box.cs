/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp
{
    /// <summary>
    /// The Box is a container that is used to arrange UI components in a linear order.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Box : Container
    {
        private Interop.Elementary.BoxLayoutCallback _layoutCallback;

        /// <summary>
        /// Creates and initializes a new instance of the Box class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new Box will be attached as a child.</param>
        /// <since_tizen> preview </since_tizen>
        public Box(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets or gets the IsHorizontal value, which describe the pack direction. Vertical is default.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsHorizontal
        {
            get
            {
                return Interop.Elementary.elm_box_horizontal_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_box_horizontal_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the box has to arrange its children homogeneously.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsHomogeneous
        {
            get
            {
                return Interop.Elementary.elm_box_homogeneous_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_box_homogeneous_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Adds an object at the end of the pack list.
        /// </summary>
        /// <remarks>
        /// Packs the "content" object into the Box, placing it last in the list of children objects.
        /// The actual position of the object will get on the screen depending on the layout used.
        /// If no custom layout is set, it will be at the bottom or right,
        /// depending if the Box is vertical or horizontal, respectively.
        /// </remarks>
        /// <param name="content">The oject to be packed.</param>
        /// <since_tizen> preview </since_tizen>
        public void PackEnd(EvasObject content)
        {
            Interop.Elementary.elm_box_pack_end(RealHandle, content);
            AddChild(content);
        }

        /// <summary>
        /// Adds a "content" object to the beginning of the pack list.
        /// </summary>
        /// <remarks>
        /// Packs the "content" object into the box object, placing it first in the list of children objects.
        /// The actual position of the object will get on the screen depending on the layout used.
        /// If no custom layout is set, it will be at the top or left,
        /// depending if the Box is vertical or horizontal, respectively.
        /// </remarks>
        /// <param name="content">The object to be packed.</param>
        /// <since_tizen> preview </since_tizen>
        public void PackStart(EvasObject content)
        {
            Interop.Elementary.elm_box_pack_start(RealHandle, content);
            AddChild(content);
        }

        /// <summary>
        /// Adds a "content" object to the box after the "after" object.
        /// </summary>
        /// <remarks>
        /// This will add the "content" to the box indicated after the object indicated with "after".
        /// If "after" is not already in the box, the results are undefined.
        /// After means either to the right of the "after" object or below it, depending on orientation.
        /// </remarks>
        /// <param name="content">The object will be added in the box.</param>
        /// <param name="after">The object has been added in the box.</param>
        /// <since_tizen> preview </since_tizen>
        public void PackAfter(EvasObject content, EvasObject after)
        {
            Interop.Elementary.elm_box_pack_after(RealHandle, content, after);
            AddChild(content);
        }

        /// <summary>
        /// Adds a "content" object to the box before the "before" object.
        /// </summary>
        /// <remarks>
        /// This will add the "content" to the box indicated before the object indicated with "before".
        /// If "before" is not already in the box, the results are undefined.
        /// Before means either to the left of the "before" object or below it, depending on orientation.
        /// </remarks>
        /// <param name="content">The object will be added in the box.</param>
        /// <param name="before">The object has been added in the box.</param>
        /// <since_tizen> preview </since_tizen>
        public void PackBefore(EvasObject content, EvasObject before)
        {
            Interop.Elementary.elm_box_pack_before(RealHandle, content, before);
            AddChild(content);
        }

        /// <summary>
        /// Removes the "content" object from the box without deleting it.
        /// </summary>
        /// <param name="content">The object to unpack.</param>
        /// <since_tizen> preview </since_tizen>
        public void UnPack(EvasObject content)
        {
            Interop.Elementary.elm_box_unpack(RealHandle, content);
            RemoveChild(content);
        }

        /// <summary>
        /// Removes all the objects from the Box container.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void UnPackAll()
        {
            Interop.Elementary.elm_box_unpack_all(RealHandle);
            ClearChildren();
        }

        /// <summary>
        /// Whenever any changes that requires the box in object to recalculate the size and position of its elements,
        /// the function cb will be called to determine what the layout of the children will be.
        /// </summary>
        /// <param name="action">The callback function used for layout.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetLayoutCallback(Action action)
        {
            _layoutCallback = (obj, priv, data) =>
            {
                action();
            };
            Interop.Elementary.elm_box_layout_set(RealHandle, _layoutCallback, IntPtr.Zero, null);
        }

        /// <summary>
        /// Sets the color of the exact part to the box's layout parent.
        /// </summary>
        /// <param name="part">The name of part class, it could be 'bg', 'elm.swllow.content'.</param>
        /// <param name="color">The color value.</param>
        /// <since_tizen> preview </since_tizen>
        public override void SetPartColor(string part, Color color)
        {
            Interop.Elementary.elm_object_color_class_color_set(Handle, part, color.R * color.A / 255,
                                                                              color.G * color.A / 255,
                                                                              color.B * color.A / 255,
                                                                              color.A);
        }

        /// <summary>
        /// Gets the color of the exact part of the box's layout parent.
        /// </summary>
        /// <param name="part">The name of part class, it could be 'bg', 'elm.swllow.content'.</param>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public override Color GetPartColor(string part)
        {
            int r, g, b, a;
            Interop.Elementary.elm_object_color_class_color_get(Handle, part, out r, out g, out b, out a);
            return new Color((int)(r / (a / 255.0)), (int)(g / (a / 255.0)), (int)(b / (a / 255.0)), a);
        }

        /// <summary>
        /// Forces the box to recalculate its children packing.
        /// If any children were added or removed, the box will not calculate the values immediately, rather leaving it to the next main loop iteration.
        /// While this is great as it would save lots of recalculation, whenever you need to get the position of a just added item, you must force recalculate before doing so.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Recalculate()
        {
            Interop.Elementary.elm_box_recalculate(RealHandle);
        }

        /// <summary>
        /// Clears the box's of all the children.
        /// Remove all the elements contained by the box, deleting the respective objects.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Clear()
        {
            Interop.Elementary.elm_box_clear(RealHandle);
            ClearChildren();
        }

        /// <summary>
        /// Sets or gets the alignment of the whole bounding box of contents.
        /// </summary>
        /// <param name="horizontal">Horizontal alignment.</param>
        /// <param name="vertical">Vertical alignment.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetBoxAlignment(double horizontal, double vertical)
        {
            Interop.Elementary.elm_box_align_set(RealHandle, horizontal, vertical);
        }

        /// <summary>
        /// Sets or gets the space (padding) between the box's elements.
        /// </summary>
        /// <param name="horizontal">Horizontal padding.</param>
        /// <param name="vertical">Vertical padding.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetPadding(int horizontal, int vertical)
        {
            Interop.Elementary.elm_box_padding_set(RealHandle, horizontal, vertical);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "background", "default");

            RealHandle = Interop.Elementary.elm_box_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }
}