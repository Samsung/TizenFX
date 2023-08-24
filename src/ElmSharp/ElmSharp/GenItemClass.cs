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
using System.Runtime.InteropServices;

using Tizen.Internals;

namespace ElmSharp
{
    /// <summary>
    /// It represents the GenGrid or GenList item class definition field details.
    /// It has some display styles, such as "default", "full", and "group_index".
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class GenItemClass : IDisposable
    {
        static Dictionary<IntPtr, EvasObject> s_HandleToEvasObject = new Dictionary<IntPtr, EvasObject>();

        /// <summary>
        /// The delegate to define <see cref="GetTextHandler"/>.
        /// </summary>
        /// <param name="data">The item data.</param>
        /// <param name="part">The part where the data should be shown.</param>
        /// <returns>Return string that should be shown.</returns>
        /// <since_tizen> preview </since_tizen>
        public delegate string GetTextDelegate(object data, string part);

        /// <summary>
        /// The delegate to define <see cref="GetContentHandler"/>.
        /// </summary>
        /// <param name="data">The item data.</param>
        /// <param name="part">The part where the data should be shown.</param>
        /// <returns>Return content that should be shown.</returns>
        /// <since_tizen> preview </since_tizen>
        public delegate EvasObject GetContentDelegate(object data, string part);

        /// <summary>
        /// The delegate to define <see cref="DeleteHandler"/>.
        /// </summary>
        /// <param name="data">The item data.</param>
        /// <since_tizen> preview </since_tizen>
        public delegate void DeleteDelegate(object data);

        /// <summary>
        /// The delegate to define <see cref="ReusableContentHandler"/>.
        /// </summary>
        /// <param name="data">The item data.</param>
        /// <param name="part">The part where the data should be shown.</param>
        /// <param name="old">The content that has been added in gengrid.</param>
        /// <returns>Return content that should be shown.</returns>
        /// <since_tizen> preview </since_tizen>
        public delegate EvasObject GetReusableContentDelegate(object data, string part, EvasObject old);

        ItemClass _itemClass;
        IntPtr _unmanagedPtr = IntPtr.Zero;
        string _style;

        /// <summary>
        /// Creates and initializes a new instance of the GenItemClass.
        /// </summary>
        /// <param name="style">The item display style.</param>
        /// <since_tizen> preview </since_tizen>
        public GenItemClass(string style)
        {
            _style = style;
            IntPtr unmanaged = CreateItemClass();

            _itemClass = Marshal.PtrToStructure<ItemClass>(unmanaged);
            _itemClass.itemStyle = style;
            _itemClass.textCallback = GetTextCallback;
            _itemClass.contentCallback = GetContentCallback;
            _itemClass.stateCallback = null;
            _itemClass.delCallback = DelCallback;
            _itemClass.reusableContentCallback = GetReusableContentCallback;

            ReleaseItemClass(unmanaged);
        }

        /// <summary>
        /// Destroys the GenItemClass object.
        /// </summary>
        ~GenItemClass()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the item style.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string ItemStyle { get { return _style; } }

        /// <summary>
        /// Gets or sets the callback that defines how to display the item text.
        /// If get, return <see cref="GetTextDelegate"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GetTextDelegate GetTextHandler { get; set; }

        /// <summary>
        /// Gets or sets the callback that defines how to display the item content.
        /// If get, return <see cref="GetContentDelegate"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GetContentDelegate GetContentHandler { get; set; }

        /// <summary>
        /// Gets or sets the callback that defines how to delete the item text and content.
        /// If get, return <see cref="DeleteDelegate"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public DeleteDelegate DeleteHandler { get; set; }

        /// <summary>
        /// Gets or sets the callback that defines how to reuse the item content.
        /// If get, return <see cref="GetReusableContentDelegate"/>.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public GetReusableContentDelegate ReusableContentHandler { get; set; }

        internal IntPtr UnmanagedPtr
        {
            get
            {
                if (_unmanagedPtr == IntPtr.Zero)
                {
                    _unmanagedPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_itemClass));
                    Marshal.StructureToPtr(_itemClass, _unmanagedPtr, false);
                }
                return _unmanagedPtr;
            }
        }

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if the managed resources should be disposed,
        /// otherwise false.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_unmanagedPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_unmanagedPtr);
                _unmanagedPtr = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void SendItemDeleted(object data)
        {
            // data is user inserted value with GenItem
            DeleteHandler?.Invoke(data);
        }

        /// <summary>
        /// Creates a new GenList item class in a given GenList widget.
        /// </summary>
        /// <returns>The new item class object.</returns>
        /// <since_tizen> preview </since_tizen>
        protected virtual IntPtr CreateItemClass()
        {
            return Interop.Elementary.elm_genlist_item_class_new();
        }

        /// <summary>
        /// Removes an item class in a given GenList widget.
        /// </summary>
        /// <param name="unmanagedPtr">The object to be removed.</param>
        /// <since_tizen> preview </since_tizen>
        protected virtual void ReleaseItemClass(IntPtr unmanagedPtr)
        {
            Interop.Elementary.elm_genlist_item_class_free(unmanagedPtr);
        }

        string GetTextCallback(IntPtr data, IntPtr obj, IntPtr part)
        {
            GenItem item = ItemObject.GetItemById((int)data) as GenItem;
            return GetTextHandler?.Invoke(item?.Data, Marshal.PtrToStringAnsi(part));
        }

        IntPtr GetContentCallback(IntPtr data, IntPtr obj, IntPtr part)
        {
            GenItem item = ItemObject.GetItemById((int)data) as GenItem;
            EvasObject evasObject = GetContentHandler?.Invoke(item?.Data, Marshal.PtrToStringAnsi(part));
            if (evasObject != null)
            {
                s_HandleToEvasObject[evasObject.Handle] = evasObject;
                evasObject.Deleted += EvasObjectDeleted;
            }
            return evasObject;
        }

        void EvasObjectDeleted(object sender, EventArgs e)
        {
            if(sender is EvasObject evasObject)
                s_HandleToEvasObject.Remove(evasObject);
        }

        IntPtr GetReusableContentCallback(IntPtr data, IntPtr obj, IntPtr part, IntPtr old)
        {
            IntPtr reusedHandle = IntPtr.Zero;
            GenItem item = ItemObject.GetItemById((int)data) as GenItem;
            if (s_HandleToEvasObject.ContainsKey(old))
            {
                reusedHandle = ReusableContentHandler?.Invoke(item?.Data, Marshal.PtrToStringAnsi(part), s_HandleToEvasObject[old]);
            }
            return reusedHandle;
        }

        void DelCallback(IntPtr data, IntPtr obj)
        {
            // We can't use this callback
            // because, when item was deleted
            // First, ItemObject deleted callback was called
            // and We need to clean up ItemObject related objects
            // This callback was called after ItemObject deleted callback was completed.
            // So, We can't get resource reletated with ItemObject
        }
    }

    /// <summary>
    /// It represents the gengrid item class definition field details.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class GenGridItemClass : GenItemClass
    {
        /// <summary>
        /// Create the GenGridItemClass instance.
        /// </summary>
        /// <param name="style">The item display style.</param>
        /// <since_tizen> preview </since_tizen>
        public GenGridItemClass(string style) : base(style)
        {
        }

        /// <summary>
        /// Adds a new gengrid item class in a given GenGrid widget.
        /// </summary>
        /// <returns>The new instance.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateItemClass()
        {
            return Interop.Elementary.elm_gengrid_item_class_new();
        }

        /// <summary>
        /// Removes the item class in a given GenGrid widget.
        /// </summary>
        /// <param name="unmanagedPtr">The object to be removed.</param>
        /// <since_tizen> preview </since_tizen>
        protected override void ReleaseItemClass(IntPtr unmanagedPtr)
        {
            Interop.Elementary.elm_gengrid_item_class_free(unmanagedPtr);
        }
    }

    [NativeStruct("Elm_Gen_Item_Class", Include="Elementary.h", PkgConfig="elementary")]
    [StructLayout(LayoutKind.Sequential)]
    internal class ItemClass
    {
        /// <since_tizen> preview </since_tizen>
        public delegate string GetTextCallback(IntPtr data, IntPtr obj, IntPtr part);

        /// <since_tizen> preview </since_tizen>
        public delegate IntPtr GetContentCallback(IntPtr data, IntPtr obj, IntPtr part);

        /// <since_tizen> preview </since_tizen>
        public delegate int GetStateCallback(IntPtr data, IntPtr obj, IntPtr part);

        /// <since_tizen> preview </since_tizen>
        public delegate void DelCallback(IntPtr data, IntPtr obj);

        /// <since_tizen> preview </since_tizen>
        public delegate int FilterCallback(IntPtr data, IntPtr obj, IntPtr key);

        /// <since_tizen> preview </since_tizen>
        public delegate IntPtr GetReusableContentCallback(IntPtr data, IntPtr obj, IntPtr part, IntPtr old);

        public int version;
        public uint refCount;
        public int deleteMe;
        public string itemStyle;
        public readonly string decorateItemStyle;
        public readonly string decorateAllItemStyle;
        public GetTextCallback textCallback;
        public GetContentCallback contentCallback;
        public GetStateCallback stateCallback;
        public DelCallback delCallback;
        public FilterCallback filterCallback;
        public GetReusableContentCallback reusableContentCallback;
    }
}