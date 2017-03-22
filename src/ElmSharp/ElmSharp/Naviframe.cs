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
    public class NaviframeEventArgs : EventArgs
    {
        public EvasObject Content { get; set; }
    }
    public class Naviframe : Widget
    {
        SmartEvent _transitionFinished;
        readonly List<NaviItem> _itemStack = new List<NaviItem>();
        public Naviframe(EvasObject parent) : base(parent)
        {
            _transitionFinished = new SmartEvent(this, this.RealHandle, "transition,finished");
            _transitionFinished.On += (s, e) => AnimationFinished?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// It is always called when NaviItem was removed.
        /// (even if removed by NaviItem.Delete())
        /// This event will be invoked in progress of Pop/Delete operation. 
        /// After called Popped event, Pop/Delete method will be returned
        /// </remarks>
        public event EventHandler<NaviframeEventArgs> Popped;
        public event EventHandler AnimationFinished;
        public IReadOnlyList<NaviItem> NavigationStack
        {
            get { return _itemStack; }
        }

        public bool PreserveContentOnPop
        {
            get
            {
                return Interop.Elementary.elm_naviframe_content_preserve_on_pop_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_naviframe_content_preserve_on_pop_set(RealHandle, value);
            }
        }

        public bool DefaultBackButtonEnabled
        {
            get
            {
                return Interop.Elementary.elm_naviframe_prev_btn_auto_pushed_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_naviframe_prev_btn_auto_pushed_set(RealHandle, value);
            }
        }

        public NaviItem Push(EvasObject content)
        {
            return Push(content, null);
        }

        public NaviItem Push(EvasObject content, string title)
        {
            return Push(content, title, null);
        }

        public NaviItem Push(EvasObject content, string title, string style)
        {
            IntPtr item = Interop.Elementary.elm_naviframe_item_push(RealHandle, title, IntPtr.Zero, IntPtr.Zero, content.Handle, style);
            NaviItem naviItem = NaviItem.FromNativeHandle(item, content);
            _itemStack.Add(naviItem);
            naviItem.Popped += ItemPoppedHandler;
            return naviItem;
        }

        public NaviItem InsertBefore(NaviItem before, EvasObject content)
        {
            return InsertBefore(before, content, "");
        }

        public NaviItem InsertBefore(NaviItem before, EvasObject content, string title)
        {
            return InsertBefore(before, content, title, null);
        }

        public NaviItem InsertBefore(NaviItem before, EvasObject content, string title, string style)
        {
            IntPtr item = Interop.Elementary.elm_naviframe_item_insert_before(RealHandle, before, title, IntPtr.Zero, IntPtr.Zero, content, null);
            NaviItem naviItem = NaviItem.FromNativeHandle(item, content);
            int idx = _itemStack.IndexOf(before);
            _itemStack.Insert(idx, naviItem);
            naviItem.Popped += ItemPoppedHandler;
            return naviItem;
        }

        public NaviItem InsertAfter(NaviItem after, EvasObject content)
        {
            return InsertAfter(after, content, "");
        }

        public NaviItem InsertAfter(NaviItem after, EvasObject content, string title)
        {
            return InsertAfter(after, content, title, null);
        }

        public NaviItem InsertAfter(NaviItem after, EvasObject content, string title, string style)
        {
            IntPtr item = Interop.Elementary.elm_naviframe_item_insert_after(RealHandle, after, title, IntPtr.Zero, IntPtr.Zero, content, null);
            NaviItem naviItem = NaviItem.FromNativeHandle(item, content);
            int idx = _itemStack.IndexOf(after);
            _itemStack.Insert(idx + 1, naviItem);
            naviItem.Popped += ItemPoppedHandler;
            return naviItem;
        }

        public void Pop()
        {
            Interop.Elementary.elm_naviframe_item_pop(RealHandle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_naviframe_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }

        void ItemPoppedHandler(object sender, EventArgs e)
        {
            NaviItem item = sender as NaviItem;
            if (item == null)
                return;
            _itemStack.Remove(item);
            Popped?.Invoke(this, new NaviframeEventArgs() { Content = item.Content });
        }
    }
}
