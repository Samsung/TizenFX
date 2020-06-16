using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    public partial class FlexibleView
    {
        /// <summary>
        /// A Recycler is responsible for managing scrapped or detached item views for reuse.
        /// A "scrapped" view is a view that is still attached to its parent FlexibleView but that has been marked for removal or reuse.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class Recycler
        {
            private FlexibleView mFlexibleView;
            private RecycledViewPool mRecyclerPool;

            private List<ViewHolder> mAttachedScrap = new List<ViewHolder>();
            private List<ViewHolder> mChangedScrap = null;
            //private List<ItemView> mCachedViews = new List<ItemView>();

            //private List<ViewHolder> mUnmodifiableAttachedScrap;

            private int mCacheSizeMax = 2;

            /// <summary>
            /// Recycler constructor.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Recycler(FlexibleView recyclerView)
            {
                mFlexibleView = recyclerView;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void SetViewCacheSize(int viewCount)
            {
                mCacheSizeMax = viewCount;
            }

            /// <summary>
            /// Obtain a view initialized for the given position.
            /// </summary>
            /// <param name="position">Position to obtain a view for</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetViewForPosition(int position)
            {
                Adapter b = mFlexibleView != null ? mFlexibleView.mAdapter : null;
                if (b == null)
                {
                    return null;
                }
                if (position < 0 || position >= b.GetItemCount())
                {
                    return null;
                }

                int type = b.GetItemViewType(position);
                ViewHolder itemView = null;
                for (int i = 0; i < mAttachedScrap.Count; i++)
                {
                    if (mAttachedScrap[i].LayoutPosition == position && mAttachedScrap[i].ItemViewType == type)
                    {
                        itemView = mAttachedScrap[i];
                        break;
                    }
                }
                if (itemView == null)
                {
                    itemView = mRecyclerPool.GetRecycledView(type);
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
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RecycleView(ViewHolder itemView)
            {
                if (null == itemView) return;
                itemView.ScrapContainer = null;
                mRecyclerPool.PutRecycledView(itemView);
            }

            /// <summary>
            /// Returns the count in scrap list.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int GetScrapCount()
            {
                return mAttachedScrap.Count;
            }

            /// <summary>
            /// Gets the scrap view at index.
            /// </summary>
            /// <param name="index">index</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetScrapViewAt(int index)
            {
                return mAttachedScrap[index];
            }

            /// <summary>
            /// Clear scrap views out of this recycler. Detached views contained within a recycled view pool will remain.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void Clear()
            {
                mAttachedScrap.Clear();
                if (mChangedScrap != null)
                {
                    mChangedScrap.Clear();
                }
            }

            internal void ScrapView(ViewHolder itemView)
            {
                mAttachedScrap.Add(itemView);
                itemView.ScrapContainer = this;
            }

            internal void UnscrapView(ViewHolder itemView)
            {
                mAttachedScrap.Remove(itemView);
                itemView.ScrapContainer = null;
            }

            internal void SetRecycledViewPool(RecycledViewPool pool)
            {
                mRecyclerPool = pool;
            }
        }
    }
}
