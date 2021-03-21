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
        private int flags;
        private int preLayoutPosition = FlexibleView.NO_POSITION;

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
                return preLayoutPosition == FlexibleView.NO_POSITION ? AdapterPosition : preLayoutPosition;
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
            if (preLayoutPosition == FlexibleView.NO_POSITION)
            {
                preLayoutPosition = AdapterPosition;
            }
            if (applyToPreLayout)
            {
                preLayoutPosition += offset;
            }
            AdapterPosition += offset;
        }

        internal void ClearOldPosition()
        {
            OldPosition = FlexibleView.NO_POSITION;
            preLayoutPosition = FlexibleView.NO_POSITION;
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
            this.flags = (this.flags & ~mask) | (flags & mask);
        }

        private void AddFlags(int flags)
        {
            this.flags |= flags;
        }
    }
}
