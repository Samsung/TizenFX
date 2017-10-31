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
    /// This is a container widget that takes a standard Edje design file and wraps it very thinly in a widget.
    /// Inherits Widget
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Layout : Container
    {
        SmartEvent _languageChanged;
        SmartEvent _themeChanged;

        IntPtr _edjeHandle;

        /// <summary>
        /// Creates and initializes a new instance of Layout class.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by Layout as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public Layout(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of Layout class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected Layout() : base()
        {
        }

        /// <summary>
        /// LanguageChanged will be triggered when the program's language is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler LanguageChanged;

        /// <summary>
        /// ThemeChanged will be triggered when the theme is changed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler ThemeChanged;

        /// <summary>
        /// Gets the edje layout.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public EdjeObject EdjeObject
        {
            get
            {
                if (_edjeHandle == IntPtr.Zero)
                    _edjeHandle = Interop.Elementary.elm_layout_edje_get(RealHandle);
                return new EdjeObject(_edjeHandle);
            }
        }

        /// <summary>
        /// Gets or sets accessibility state of texblock(text) parts in the layout object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool TextBlockAccessibility
        {
            get
            {
                return Interop.Elementary.elm_layout_edje_object_can_access_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_layout_edje_object_can_access_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Freezes the Elementary layout object.
        /// This function puts all changes on hold.
        /// Successive freezes will nest, requiring an equal number of thaws.
        /// </summary>
        /// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
        /// <since_tizen> preview </since_tizen>
        public int Freeze()
        {
            return Interop.Elementary.elm_layout_freeze(RealHandle);
        }

        /// <summary>
        /// Thaws the Elementary object.
        /// If sucessives freezes were done, an equal number of thaws will be required.
        /// </summary>
        /// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
        /// <since_tizen> preview </since_tizen>
        public int Thaw()
        {
            return Interop.Elementary.elm_layout_thaw(RealHandle);
        }

        /// <summary>
        /// Eval sizing.
        /// Manually forces a sizing re-evaluation.
        /// This is useful when the minimum size required by the edje theme of this layout has changed.
        /// The change on the minimum size required by the edje theme is not immediately reported to the elementary layout, so one needs to call this function in order to tell the widget (layout) that it needs to reevaluate its own size.
        /// The minimum size of the theme is calculated based on minimum size of parts, the size of elements inside containers like box and table, etc.
        /// All of this can change due to state changes, and that's when this function should be called.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Resizing()
        {
            Interop.Elementary.elm_layout_sizing_eval(RealHandle);
        }

        /// <summary>
        /// Request sizing reevaluation, restricted to current width and/or height.
        /// Useful mostly when there are TEXTBLOCK parts defining the height of the object and nothing else restricting it to a minimum width.Calling this function will restrict the minimum size in the Edje calculation to whatever size it the layout has at the moment.
        /// </summary>
        /// <param name="width">Restrict minimum size ot the current width.</param>
        /// <param name="height">Restrict minimum size ot the current height.</param>
        /// <since_tizen> preview </since_tizen>
        public void Resizing(bool width, bool height)
        {
            Interop.Elementary.elm_layout_sizing_restricted_eval(RealHandle, width, height);
        }

        /// <summary>
        /// Get the edje data from the given layout.
        /// This function fetches data specified inside the edje theme of this layout.
        /// This function return NULL if data is not found.
        /// </summary>
        /// <param name="key">The data key</param>
        /// <returns>The data</returns>
        /// <since_tizen> preview </since_tizen>
        public string GetEdjeData(string key)
        {
            return Interop.Elementary.elm_layout_data_get(RealHandle, key);
        }

        /// <summary>
        /// Gets the text set in the given part.
        /// </summary>
        /// <param name="part">The TEXT part to retrieve the text off.</param>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public override string GetPartText(string part)
        {
            return Interop.Elementary.elm_layout_text_get(RealHandle, part);
        }

        /// <summary>
        /// Sets the text set in the given part.
        /// </summary>
        /// <param name="part">The TEXT part to retrieve the text off.</param>
        /// <param name="text">The text to set.</param>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public override bool SetPartText(string part, string text)
        {
            return Interop.Elementary.elm_layout_text_set(RealHandle, part, text);
        }

        /// <summary>
        /// Append child to layout box part.
        /// Once the object is appended, it will become child of the layout.
        /// Its lifetime will be bound to the layout, whenever the layout dies the child will be deleted automatically.
        /// </summary>
        /// <param name="part">The part</param>
        /// <param name="child">The Object to append</param>
        /// <returns>Sucess is true</returns>
        /// <since_tizen> preview </since_tizen>
        public bool BoxAppend(string part, EvasObject child)
        {
            AddChild(child);
            return Interop.Elementary.elm_layout_box_append(RealHandle, part, child.Handle);
        }

        /// <summary>
        /// Prepend child to layout box part.
        /// Once the object is prepended, it will become child of the layout.
        /// Its lifetime will be bound to the layout, whenever the layout dies the child will be deleted automatically.
        /// </summary>
        /// <param name="part">The part</param>
        /// <param name="child">The Object to prepend</param>
        /// <returns>Sucess is true</returns>
        /// <since_tizen> preview </since_tizen>
        public bool BoxPrepend(string part, EvasObject child)
        {
            AddChild(child);
            return Interop.Elementary.elm_layout_box_prepend(RealHandle, part, child.Handle);
        }

        /// <summary>
        /// Remove a child of the given part box.
        /// The object will be removed from the box part and its lifetime will not be handled by the layout anymore.
        /// </summary>
        /// <param name="part">The part</param>
        /// <param name="child">The Object to remove</param>
        /// <returns>Sucess is true</returns>
        /// <since_tizen> preview </since_tizen>
        public bool BoxRemove(string part, EvasObject child)
        {
            RemoveChild(child);
            return Interop.Elementary.elm_layout_box_remove(RealHandle, part, child.Handle) != null;
        }

        /// <summary>
        /// Remove all children of the given part box.
        /// The objects will be removed from the box part and their lifetime will not be handled by the layout anymore.
        /// </summary>
        /// <param name="part">The part</param>
        /// <param name="clear">If true, then all objects will be deleted as well, otherwise they will just be removed and will be dangling on the canvas.</param>
        /// <returns>Sucess is true</returns>
        /// <since_tizen> preview </since_tizen>
        public bool BoxRemoveAll(string part, bool clear)
        {
            ClearChildren();
            return Interop.Elementary.elm_layout_box_remove_all(RealHandle, part, clear);
        }

        /// <summary>
        /// Insert child to layout box part at a given position.
        /// Once the object is inserted, it will become child of the layout.
        /// Its lifetime will be bound to the layout, whenever the layout dies the child will be deleted automatically.
        /// </summary>
        /// <param name="part">The part</param>
        /// <param name="child">The child object to insert into box.</param>
        /// <param name="position">The numeric position >=0 to insert the child.</param>
        /// <returns>Sucess is true</returns>
        /// <since_tizen> preview </since_tizen>
        public bool BoxInsertAt(string part, EvasObject child, uint position)
        {
            AddChild(child);
            return Interop.Elementary.elm_layout_box_insert_at(RealHandle, part, child.Handle, position);
        }

        /// <summary>
        /// Insert child to layout box part before a reference object.
        /// Once the object is inserted, it will become child of the layout.
        /// Its lifetime will be bound to the layout, whenever the layout dies the child will be deleted automatically.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="child">The child object to insert into box.</param>
        /// <param name="reference">Another reference object to insert before in box.</param>
        /// <returns>Sucess is true</returns>
        /// <since_tizen> preview </since_tizen>
        public bool BoxInsertBefore(string part, EvasObject child, EvasObject reference)
        {
            AddChild(child);
            return Interop.Elementary.elm_layout_box_insert_before(RealHandle, part, child.Handle, reference.Handle);
        }

        /// <summary>
        /// Sets the layout content.
        /// </summary>
        /// <param name="part">The swallow part name in the edje file</param>
        /// <param name="content">The child that will be added in this layout object.</param>
        /// <returns>TRUE on success, FALSE otherwise</returns>
        /// <since_tizen> preview </since_tizen>
        public override bool SetPartContent(string part, EvasObject content)
        {
            return SetPartContent(part, content, false);
        }

        /// <summary>
        /// Sets the layout content.
        /// </summary>
        /// <param name="part">The name of particular part</param>
        /// <param name="content">The content</param>
        /// <param name="preserveOldContent">true, preserve old content will be unset. false, preserve old content will not be unset.</param>
        /// <returns>TRUE on success, FALSE otherwise</returns>
        /// <since_tizen> preview </since_tizen>
        public override bool SetPartContent(string part, EvasObject content, bool preserveOldContent)
        {
            if (preserveOldContent)
            {
                Interop.Elementary.elm_layout_content_unset(RealHandle, part);
            }
            UpdatePartContents(content, part);
            return Interop.Elementary.elm_layout_content_set(RealHandle, part, content);
        }

        /// <summary>
        /// Sets the edje group from the elementary theme that is used as a layout.
        /// </summary>
        /// <param name="klass">The class of the group</param>
        /// <param name="group">The group</param>
        /// <param name="style">The style to use</param>
        /// <since_tizen> preview </since_tizen>
        public void SetTheme(string klass, string group, string style)
        {
            Interop.Elementary.elm_layout_theme_set(RealHandle, klass, group, style);
        }

        /// <summary>
        /// Sets the file that is used as a layout.
        /// </summary>
        /// <param name="file">The path to the file (edj) that is used as a layout</param>
        /// <param name="group">The group that the layout belongs to in the edje file</param>
        /// <since_tizen> preview </since_tizen>
        public void SetFile(string file, string group)
        {
            Interop.Elementary.elm_layout_file_set(RealHandle, file, group);
        }

        /// <summary>
        /// Sets the back ground color of layout
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public override Color BackgroundColor
        {
            set
            {
                if (value.IsDefault && ClassName != null)
                {
                    string part = ClassName.ToLower().Replace("elm_", "") + "/" + "bg";
                    EdjeObject.DeleteColorClass(part);
                }
                else
                {
                    SetPartColor("bg", value);
                }
                _backgroundColor = value;
            }
        }

        /// <summary>
        /// Sets the vertical text alignment of layout's text part
        /// </summary>
        /// <remarks>
        /// API, elm_layout_text_valign_set, is an internal API only in Tizen. Avalilable since Tizen_4.0.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public virtual void SetVerticalTextAlignment(string part, double valign)
        {
            Interop.Elementary.elm_layout_text_valign_set(RealHandle, part, valign);
        }

        /// <summary>
        /// Gets the vertical text alignment of layout's text part
        /// </summary>
        /// <remarks>
        /// API, elm_layout_text_valign_get, is internal API only in Tizen. Avalilable since Tizen_4.0.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public virtual double GetVerticalTextAlignment(string part)
        {
            return Interop.Elementary.elm_layout_text_valign_get(RealHandle, part);
        }

        /// <summary>
        /// The callback of Realized Event
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void OnRealized()
        {
            base.OnRealized();
            _languageChanged = new SmartEvent(this, this.RealHandle, "language,changed");
            _languageChanged.On += (s, e) =>
            {
                LanguageChanged?.Invoke(this, EventArgs.Empty);
            };

            _themeChanged = new SmartEvent(this, this.RealHandle, "theme,changed");
            _themeChanged.On += (s, e) =>
            {
                ThemeChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// Sets the content at a part of a given container widget.
        /// </summary>
        /// <param name="parent">The parent is a given container which will be attached by Layout as a child. It's <see cref="EvasObject"/> type.</param>
        /// <returns>The new object, otherwise null if it cannot be created</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_layout_add(parent.Handle);
        }
    }
}