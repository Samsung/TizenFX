/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
    /// It is a class for context menu of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebContextMenu : Disposable
    {
        internal WebContextMenu(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebContextMenu.DeleteWebContextMenu(swigCPtr);
        }

        /// <summary>
        /// Counts items of the context menu.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ItemCount
        {
            get
            {
                return Interop.WebContextMenu.GetItemCount(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the list of items.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebContextMenuItemList ItemList
        {
            get
            {
                IntPtr result = Interop.WebContextMenu.GetItemList(SwigCPtr);
                return new WebContextMenuItemList(result, true);
            }
        }

        /// <summary>
        /// Gets position of the context menu.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Position
        {
            get
            {
                IntPtr result = Interop.WebContextMenu.GetPosition(SwigCPtr);
                return new Vector2(result, true);
            }
        }

        /// <summary>
        /// Returns the nth item in a context menu.
        /// <param name="index">The position of the item</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebContextMenuItem GetItemAtIndex(uint index)
        {
            IntPtr result = Interop.WebContextMenu.GetItemAt(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new WebContextMenuItem(result, true);
        }

        /// <summary>
        /// Removes the item from the context menu.
        /// <param name="item">The item to be removed</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveItem(WebContextMenuItem item)
        {
            bool result = Interop.WebContextMenu.RemoveItem(SwigCPtr, WebContextMenuItem.getCPtr(item));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Adds the item with a title to the context menu.
        /// <param name="tag">The tag of context menu item</param>
        /// <param name="title">The title of context menu item</param>
        /// <param name="enabled">Whether context menu item is enabled or not</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AppendItem(WebContextMenuItem.ItemTag tag, string title, bool enabled)
        {
            bool result = Interop.WebContextMenu.AppendItemAsAction(SwigCPtr, (int)tag, title, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Adds the item with a title and an icon to the context menu.
        /// <param name="tag">The tag of context menu item</param>
        /// <param name="title">The title of context menu item</param>
        /// <param name="iconFile">The path of icon to be set on context menu item</param>
        /// <param name="enabled">Whether context menu item is enabled or not</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AppendItem(WebContextMenuItem.ItemTag tag, string title, string iconFile, bool enabled)
        {
            bool result = Interop.WebContextMenu.AppendItem(SwigCPtr, (int)tag, title, iconFile, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Selects the item from the context menu.
        /// <param name="item">The item to be selected</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SelectItem(WebContextMenuItem item)
        {
            bool result = Interop.WebContextMenu.SelectItem(SwigCPtr, WebContextMenuItem.getCPtr(item));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Hides the context menu.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Hide()
        {
            bool result = Interop.WebContextMenu.Hide(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
    }
}
