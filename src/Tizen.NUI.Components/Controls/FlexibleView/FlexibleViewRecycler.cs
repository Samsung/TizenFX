/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// A FlexibleViewRecycler is responsible for managing scrapped or detached item views for reuse.
    /// A "scrapped" view is a view that is still attached to its parent FlexibleView but that has been marked for removal or reuse.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FlexibleViewRecycler
    {
        private FlexibleView flexibleView;
        private FlexibleView.RecycledViewPool recyclerPool;

        private List<FlexibleViewViewHolder> attachedScrap = new List<FlexibleViewViewHolder>();
        private List<FlexibleViewViewHolder> changedScrap = null;

        private int cacheSizeMax = 2;

        /// <summary>
        /// FlexibleViewRecycler constructor.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewRecycler(FlexibleView recyclerView)
        {
            flexibleView = recyclerView;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetViewCacheSize(int viewCount)
        {
            cacheSizeMax = viewCount;
        }

        /// <summary>
        /// Obtain a view initialized for the given position.
        /// </summary>
        /// <param name="position">Position to obtain a view for</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewViewHolder GetViewForPosition(int position)
        {
            FlexibleViewAdapter b = flexibleView != null ? flexibleView.GetAdapter() : null;
            if (b == null)
            {
                return null;
            }
            if (position < 0 || position >= b.GetItemCount())
            {
                return null;
            }

            int type = b.GetItemViewType(position);
            FlexibleViewViewHolder itemView = null;
            for (int i = 0; i < attachedScrap.Count; i++)
            {
                if (attachedScrap[i].LayoutPosition == position && attachedScrap[i].ItemViewType == type)
                {
                    itemView = attachedScrap[i];
                    break;
                }
            }
            if (itemView == null)
            {
                itemView = recyclerPool.GetRecycledView(type);
                if (itemView == null)
                {
                    itemView = b.OnCreateViewHolder(type);
                }

                if (!itemView.IsBound)
                {
                    b.OnBindViewHolder(itemView, position);
                    itemView.IsBound = true;
                }

                itemView.AdapterPosition = position;
                itemView.ItemViewType = type;
            }

            return itemView;
        }

        /// <summary>
        /// Recycle a detached view.
        /// </summary>
        /// <param name="itemView">Removed holder for recycling</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RecycleView(FlexibleViewViewHolder itemView)
        {
            if (null == itemView) return;
            itemView.ScrapContainer = null;
            recyclerPool.PutRecycledView(itemView);
        }

        /// <summary>
        /// Returns the count in scrap list.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetScrapCount()
        {
            return attachedScrap.Count;
        }

        /// <summary>
        /// Gets the scrap view at index.
        /// </summary>
        /// <param name="index">index</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewViewHolder GetScrapViewAt(int index)
        {
            return attachedScrap[index];
        }

        /// <summary>
        /// Clear scrap views out of this recycler. Detached views contained within a recycled view pool will remain.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            attachedScrap.Clear();
            if (changedScrap != null)
            {
                changedScrap.Clear();
            }
        }

        internal void ScrapView(FlexibleViewViewHolder itemView)
        {
            attachedScrap.Add(itemView);
            itemView.ScrapContainer = this;
        }

        internal void UnscrapView(FlexibleViewViewHolder itemView)
        {
            attachedScrap.Remove(itemView);
            itemView.ScrapContainer = null;
        }

        internal void SetRecycledViewPool(FlexibleView.RecycledViewPool pool)
        {
            recyclerPool = pool;
        }
    }
}
