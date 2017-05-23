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
using System.Collections.Generic;

namespace ElmSharp
{
    /// <summary>
    /// The ItemObject is used to manage item object
    /// </summary>
    public class ItemObject
    {
        private static Dictionary<int, ItemObject> s_IdToItemTable = new Dictionary<int, ItemObject>();
        private static Dictionary<IntPtr, ItemObject> s_HandleToItemTable = new Dictionary<IntPtr, ItemObject>();
        private static int s_globalId = 0;

        readonly Dictionary<string, EvasObject> _partContents = new Dictionary<string, EvasObject>();
        Interop.Evas.SmartCallback _deleteCallback;
        IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Creates and initializes a new instance of ItemObject class.
        /// </summary>
        /// <param name="handle">IntPtr</param>
        protected ItemObject(IntPtr handle)
        {
            _deleteCallback = DeleteCallbackHandler;
            Id = GetNextId();
            s_IdToItemTable[Id] = this;
            Handle = handle;
        }

        // C# Finalizer was called on GC thread
        // So, We can't access to EFL object
        // And When Finalizer was called, Field can be already released.
        //~ItemObject()
        //{
        //    if (Handle != IntPtr.Zero)
        //        Interop.Elementary.elm_object_item_del(Handle);
        //}

        /// <summary>
        /// Gets the id of item object
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Sets or gets whether the item object is enabled
        /// </summary>
        public bool IsEnabled
        {
            get { return !Interop.Elementary.elm_object_item_disabled_get(Handle); }
            set { Interop.Elementary.elm_object_item_disabled_set(Handle, !value); }
        }

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }
            set
            {
                if (_handle == value)
                    return;

                if (_handle != IntPtr.Zero)
                {
                    UnsetDeleteCallback();
                }
                _handle = value;
                SetDeleteCallback();
                s_HandleToItemTable[Handle] = this;
            }
        }

        /// <summary>
        /// Deleted will be triggered when the item object is deleted
        /// </summary>
        public event EventHandler Deleted;

        /// <summary>
        /// Delete the item object
        /// </summary>
        public void Delete()
        {
            Interop.Elementary.elm_object_item_del(Handle);
            _handle = IntPtr.Zero;
        }

        /// <summary>
        /// Set a content of an object item and delete old content
        /// </summary>
        /// <param name="part">The content part name (null for the default content)</param>
        /// <param name="content">The content of the object item</param>
        public void SetPartContent(string part, EvasObject content)
        {
            SetPartContent(part, content, false);
        }

        /// <summary>
        /// Set a content of an object item
        /// </summary>
        /// <param name="part">The content part name (null for the default content)</param>
        /// <param name="content">The content of the object item</param>
        /// <param name="preserveOldContent">judge whether delete old content</param>
        public void SetPartContent(string part, EvasObject content, bool preserveOldContent)
        {
            IntPtr oldContent = Interop.Elementary.elm_object_item_part_content_unset(Handle, part);
            if (oldContent != IntPtr.Zero && !preserveOldContent)
            {
                Interop.Evas.evas_object_del(oldContent);
            }
            Interop.Elementary.elm_object_item_part_content_set(Handle, part, content);
            _partContents[part ?? "__default__"] = content;
        }

        /// <summary>
        /// Set a label of an object item
        /// </summary>
        /// <param name="part">The text part name (null for the default label)</param>
        /// <param name="text">Text of the label</param>
        public void SetPartText(string part, string text)
        {
            Interop.Elementary.elm_object_item_part_text_set(Handle, part, text);
        }

        /// <summary>
        /// Gets a label of an object item
        /// </summary>
        /// <param name="part">The text part name (null for the default label)</param>
        /// <returns></returns>
        public string GetPartText(string part)
        {
            return Interop.Elementary.elm_object_item_part_text_get(Handle, part);
        }

        /// <summary>
        /// Sets color of an object item
        /// </summary>
        /// <param name="part">The text part name (null for the default label)</param>
        /// <param name="color">the color</param>
        public void SetPartColor(string part, Color color)
        {
            Interop.Elementary.elm_object_item_color_class_color_set(Handle, part, color.R * color.A / 255,
                                                                              color.G * color.A / 255,
                                                                              color.B * color.A / 255,
                                                                              color.A);
        }

        /// <summary>
        /// Gets color of an object item
        /// </summary>
        /// <param name="part">The text part name (null for the default label)</param>
        /// <returns>the color of object item</returns>
        public Color GetPartColor(string part)
        {
            int r, g, b, a;
            Interop.Elementary.elm_object_item_color_class_color_get(Handle, part, out r, out g, out b, out a);
            return new Color((int)(r / (a / 255.0)), (int)(g / (a / 255.0)), (int)(b / (a / 255.0)), a);
        }

        /// <summary>
        /// Deletes color of an object item
        /// </summary>
        /// <param name="part">The text part name</param>
        public void DeletePartColor(string part)
        {
            Interop.Elementary.elm_object_item_color_class_del(Handle, part);
        }

        /// <summary>
        /// Gets the handle of object item
        /// </summary>
        /// <param name="obj">ItemObject</param>
        public static implicit operator IntPtr(ItemObject obj)
        {
            if (obj == null)
                return IntPtr.Zero;
            return obj.Handle;
        }

        /// <summary>
        /// OnInvalidate of object item
        /// </summary>
        protected virtual void OnInvalidate() { }

        internal static ItemObject GetItemById(int id)
        {
            ItemObject value;
            s_IdToItemTable.TryGetValue(id, out value);
            return value;
        }

        internal static ItemObject GetItemByHandle(IntPtr handle)
        {
            ItemObject value = null;
            s_HandleToItemTable.TryGetValue(handle, out value);
            if (value == null)
            {
                int id = (int)Interop.Elementary.elm_object_item_data_get(handle);
                return GetItemById(id);
            }
            return value;
        }

        void DeleteCallbackHandler(IntPtr data, IntPtr obj, IntPtr info)
        {
            Deleted?.Invoke(this, EventArgs.Empty);
            OnInvalidate();
            if (s_IdToItemTable.ContainsKey(Id))
            {
                s_IdToItemTable.Remove(Id);
            }
            if (s_HandleToItemTable.ContainsKey(_handle))
            {
                s_HandleToItemTable.Remove(_handle);
            }
            _partContents.Clear();
            _handle = IntPtr.Zero;
        }

        void UnsetDeleteCallback()
        {
            Interop.Elementary.elm_object_item_del_cb_set(Handle, null);
        }

        void SetDeleteCallback()
        {
            if (Handle != IntPtr.Zero)
                Interop.Elementary.elm_object_item_del_cb_set(Handle, _deleteCallback);
        }

        static int GetNextId()
        {
            return s_globalId++;
        }
    }
}
