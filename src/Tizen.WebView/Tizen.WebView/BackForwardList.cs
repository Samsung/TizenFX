/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.WebView
{
    /// <summary>
    /// This class provides the properties of Back Forward list item of a specific WebView.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class BackForwardListItem
    {
        private IntPtr _item_handle;

        /// <summary>
        /// Creates a Back Forward List Item object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal BackForwardListItem(IntPtr handle)
        {
            _item_handle = handle;
        }

        /// <summary>
        /// Url of the back forward list item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Url
        {
            get
            {
                return Interop.ChromiumEwk.ewk_back_forward_list_item_url_get(_item_handle);
            }
        }

        /// <summary>
        /// Title of the back forward list item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Title
        {
            get
            {
                return Interop.ChromiumEwk.ewk_back_forward_list_item_title_get(_item_handle);
            }
        }

        /// <summary>
        /// Original Url of the back forward list item.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string OriginalUrl
        {
            get
            {
                return Interop.ChromiumEwk.ewk_back_forward_list_item_original_url_get(_item_handle);
            }
        }
    }

    /// <summary>
    /// This class provides the properties of Back Forward list of a specific WebView.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class BackForwardList
    {
        private IntPtr _list_handle;

        /// <summary>
        /// Creates a Back Forward List object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal BackForwardList(IntPtr handle)
        {
            _list_handle = handle;
        }

        /// <summary>
        /// Current item of the back forward list.
        /// </summary>
        /// <remarks>
        /// BackForward List can be null if there is no current item.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        public BackForwardListItem CurrentItem
        {
            get
            {
                IntPtr itemPtr = Interop.ChromiumEwk.ewk_back_forward_list_current_item_get(_list_handle);
                if(itemPtr != null) {
                    BackForwardListItem item = new BackForwardListItem(itemPtr);
                    return item;
                }
                else {
                   return null;
                }
            }
        }

        /// <summary>
        /// Previous item of the back forward list and null if no previous item.
        /// </summary>
        /// <remarks>
        /// BackForward List can be null if there is no previous item.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        public BackForwardListItem PreviousItem
        {
            get
            {
                IntPtr itemPtr = Interop.ChromiumEwk.ewk_back_forward_list_previous_item_get(_list_handle);
                if(itemPtr != null) {
                    BackForwardListItem item = new BackForwardListItem(itemPtr);
                    return item;
                }
                else {
                   return null;
                }
            }
        }

        /// <summary>
        /// Gets the back forward list count.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Count
        {
            get
            {
                return Interop.ChromiumEwk.ewk_back_forward_list_count(_list_handle);
            }
        }
        /// <summary>
        /// Gets the list containing the items preceding the current item
        /// limited by limit.
        /// </summary>
        /// <param name="limit"> limit The number of items to retrieve, if limit -1 all items preceding current item are returned.</param>
        /// <returns>The list of the BackForwardListItem of back items.</returns>
        /// <since_tizen> 6 </since_tizen>
        public IList<BackForwardListItem> BackItems(int limit)
        {
            IntPtr backList = Interop.ChromiumEwk.ewk_back_forward_list_n_back_items_copy(_list_handle, limit);
            List<BackForwardListItem> backItemsList = new List<BackForwardListItem>();

            uint count = Interop.Eina.eina_list_count(backList);

            for(uint i=0; i < count; i++) {
              IntPtr data = Interop.Eina.eina_list_nth(backList, i);
              backItemsList.Add(new BackForwardListItem(data));
            }
            return backItemsList;
        }

        /// <summary>
        /// Gets the list containing the items following the current item
        /// limited by limit.
        /// </summary>
        /// <param name="limit"> limit The number of items to retrieve, if limit is -1 all items following current item are returned.</param>
        /// <returns>The list of the BackForwardListItem of forward items.</returns>
        /// <since_tizen> 6 </since_tizen>
        public IList<BackForwardListItem> ForwardItems(int limit)
        {
            IntPtr forwardList = Interop.ChromiumEwk.ewk_back_forward_list_n_forward_items_copy(_list_handle, limit);
            List<BackForwardListItem> forwardItemsList = new List<BackForwardListItem>();

            uint count = Interop.Eina.eina_list_count(forwardList);

            for(uint i = 0; i < count; i++) {
              IntPtr data = Interop.Eina.eina_list_nth(forwardList, i);
              forwardItemsList.Add(new BackForwardListItem(data));
            }
            return forwardItemsList;
        }
    }
}
