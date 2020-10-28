using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// A FlexibleViewViewHolder describes an item view and metadata about its place within the FlexibleView.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FlexibleViewViewHolder
    {
        // This FlexibleViewViewHolder has been bound to a position; AdapterPosition, mItemId and mItemViewType
        // are all valid.
        //static readonly int FLAG_BOUND = 1 << 0;

        // The data this FlexibleViewViewHolder's view reflects is stale and needs to be rebound
        // by the adapter. AdapterPosition and mItemId are consistent.
        //static readonly int FLAG_UPDATE = 1 << 1;

        // This FlexibleViewViewHolder's data is invalid. The identity implied by AdapterPosition and mItemId
        // are not to be trusted and may no longer match the item view type.
        // This FlexibleViewViewHolder must be fully rebound to different data.
        //static readonly int FLAG_INVALID = 1 << 2;

        // This FlexibleViewViewHolder points at data that represents an item previously removed from the
        // data set. Its view may still be used for things like outgoing animations.
        //static readonly int FLAG_REMOVED = 1 << 3;

        // This FlexibleViewViewHolder should not be recycled. This flag is set via setIsRecyclable()
        // and is intended to keep views around during animations.
        //static readonly int FLAG_NOT_RECYCLABLE = 1 << 4;

        // This FlexibleViewViewHolder is returned from scrap which means we are expecting an addView call
        // for this itemView. When returned from scrap, FlexibleViewViewHolder stays in the scrap list until
        // the end of the layout pass and then recycled by FlexibleViewRecyclerView if it is not added back to
        // the FlexibleViewRecyclerView.
        //static readonly int FLAG_RETURNED_FROM_SCRAP = 1 << 5;

        // This FlexibleViewViewHolder is fully managed by the FlexibleViewLayoutManager. We do not scrap, recycle or remove
        // it unless FlexibleViewLayoutManager is replaced.
        // It is still fully visible to the FlexibleViewLayoutManager.
        //static readonly int FLAG_IGNORE = 1 << 7;

        private int mFlags;
        private int mPreLayoutPosition = FlexibleView.NO_POSITION;

        /// <summary>
        /// FlexibleViewViewHolder constructor.
        /// </summary>
        /// <param name="itemView">View</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlexibleViewViewHolder(View itemView)
        {
            if (itemView == null)
            {
                throw new ArgumentNullException("itemView may not be null");
            }
            this.ItemView = itemView;
        }

        /// <summary>
        /// Returns the view.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View ItemView { get; }

        /// <summary>
        /// Returns the left edge includes the view left margin.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Left
        {
            get
            {
                return ItemView.PositionX - ItemView.Margin.Start;
            }
        }

        /// <summary>
        /// Returns the right edge includes the view right margin.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Right
        {
            get
            {
                return ItemView.PositionX + ItemView.SizeWidth + ItemView.Margin.End;
            }
        }

        /// <summary>
        /// Returns the top edge includes the view top margin.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Top
        {
            get
            {
                return ItemView.PositionY - ItemView.Margin.Top;
            }
        }

        /// <summary>
        /// Returns the bottom edge includes the view bottom margin.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Bottom
        {
            get
            {
                return ItemView.PositionY + ItemView.SizeHeight + ItemView.Margin.Bottom;
            }
        }

        /// <summary>
        /// Returns the position of the FlexibleViewViewHolder in terms of the latest layout pass.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LayoutPosition
        {
            get
            {
                return mPreLayoutPosition == FlexibleView.NO_POSITION ? AdapterPosition : mPreLayoutPosition;
            }
        }

        /// <summary>
        /// Returns the FlexibleViewAdapter position of the item represented by this FlexibleViewViewHolder.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int AdapterPosition { get; internal set; } = FlexibleView.NO_POSITION;

        /// <summary>
        /// Get old position of item view.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int OldPosition { get; private set; } = FlexibleView.NO_POSITION;

        /// <summary>
        /// Gets or sets item view type.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ItemViewType { get; set; } = FlexibleView.INVALID_TYPE;

        internal bool IsBound
        {
            get;
            set;
        }

        internal FlexibleViewRecycler ScrapContainer { get; set; }

        internal bool PendingRecycle
        {
            get;
            set;
        } = false;


        internal bool IsScrap()
        {
            return ScrapContainer != null;
        }

        internal void Unscrap()
        {
            ScrapContainer.UnscrapView(this);
        }


        internal void FlagRemovedAndOffsetPosition(int mNewPosition, int offset, bool applyToPreLayout)
        {
            //AddFlags(FlexibleViewViewHolder.FLAG_REMOVED);
            OffsetPosition(offset, applyToPreLayout);
            AdapterPosition = mNewPosition;
        }

        internal void OffsetPosition(int offset, bool applyToPreLayout)
        {
            if (OldPosition == FlexibleView.NO_POSITION)
            {
                OldPosition = AdapterPosition;
            }
            if (mPreLayoutPosition == FlexibleView.NO_POSITION)
            {
                mPreLayoutPosition = AdapterPosition;
            }
            if (applyToPreLayout)
            {
                mPreLayoutPosition += offset;
            }
            AdapterPosition += offset;
        }

        internal void ClearOldPosition()
        {
            OldPosition = FlexibleView.NO_POSITION;
            mPreLayoutPosition = FlexibleView.NO_POSITION;
        }

        internal void SaveOldPosition()
        {
            if (OldPosition == FlexibleView.NO_POSITION)
            {
                OldPosition = AdapterPosition;
            }
        }

        private void SetFlags(int flags, int mask)
        {
            mFlags = (mFlags & ~mask) | (flags & mask);
        }

        private void AddFlags(int flags)
        {
            mFlags |= flags;
        }
    }
}
