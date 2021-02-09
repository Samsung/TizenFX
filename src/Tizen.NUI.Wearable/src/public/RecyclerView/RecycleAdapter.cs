/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// [Draft] Defalt adapter for RecyclerView.
    /// Managing RecycleItem and Data for RecyclerView.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RecycleAdapter
    {
        private List<object> mData = new List<object>();

        /// <summary>
        /// Create recycle item for RecyclerView.
        /// RecyclerView will make its children using this api.
        /// </summary>
        /// <returns>Item for RecyclerView</returns>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual RecycleItem CreateRecycleItem()
        {
            return new RecycleItem();
        }

        /// <summary>
        /// Bind data with recycler item.
        /// This function is called when RecyclerItem is used again with new data.
        /// Can update content of recycle item with new data at DataIndex of item. 
        /// </summary>
        /// <param name="item">Reused RecycleItem which needs data binding.</param>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void BindData(RecycleItem item)
        {

        }

        /// <summary>
        /// Notify when data of adapter is changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Notify()
        {
            OnDataChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Triggered when user called Notify().
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<EventArgs> OnDataChanged;

        /// <summary>
        /// Triggered when user called Notify().
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This may be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<object> Data
        {
            get
            {
                return mData;
            }
            set
            {
                mData = value;
                Notify();
            }
        }
    }
}
