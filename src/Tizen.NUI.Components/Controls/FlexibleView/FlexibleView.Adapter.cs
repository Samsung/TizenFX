using System;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    public partial class FlexibleView
    {
        /// <summary>
        /// Adapters provide a binding from an app-specific data set to views that are displayed within a FlexibleView.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract class Adapter
        {
            private EventHandler<ItemEventArgs> itemEventHandlers;

            internal event EventHandler<ItemEventArgs> ItemEvent
            {
                add
                {
                    itemEventHandlers += value;
                }

                remove
                {
                    itemEventHandlers -= value;
                }
            }

            internal enum ItemEventType
            {
                Insert = 0,
                Remove,
                Move,
                Change
            }

            /// <summary>
            /// Called when FlexibleView needs a new FlexibleView.ViewHolder of the given type to represent an item.
            /// </summary>
            /// <param name="viewType">The view type of the new View</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract ViewHolder OnCreateViewHolder(int viewType);

            /// <summary>
            /// Called by FlexibleView to display the data at the specified position.
            /// </summary>
            /// <param name="holder">The ViewHolder which should be updated to represent the contents of the item at the given position in the data set.</param>
            /// <param name="position">The position of the item within the adapter's data set.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnBindViewHolder(ViewHolder holder, int position);

            /// <summary>
            /// Called when a ViewHolder is never used.
            /// </summary>
            /// <param name="holder">The ViewHolder which need to be disposed</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnDestroyViewHolder(ViewHolder holder);

            /// <summary>
            /// Returns the total number of items in the data set held by the adapter.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract int GetItemCount();

            /// <summary>
            /// Return the view type of the item at position for the purposes of view recycling.
            /// </summary>
            /// <param name="position">The position of the item within the adapter's data set.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual int GetItemViewType(int position)
            {
                return 0;
            }

            /// <summary>
            /// Called by FlexibleView when it starts observing this Adapter.
            /// Keep in mind that same adapter may be observed by multiple FlexibleView.
            /// </summary>
            /// <param name="flexibleView">The FlexibleView instance which started observing this adapter.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnAttachedToRecyclerView(FlexibleView flexibleView)
            {
            }

            /// <summary>
            /// Called by FlexibleView when it stops observing this Adapter.
            /// </summary>
            /// <param name="flexibleView">The FlexibleView instance which stopped observing this adapter.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnDetachedFromRecyclerView(FlexibleView flexibleView)
            {
            }

            /// <summary>
            /// Called when FlexibleView focus changed.
            /// </summary>
            /// <param name="flexibleView">The FlexibleView into which the focus ViewHolder changed.</param>
            /// <param name="previousFocus">The position of previous focus</param>
            /// <param name="currentFocus">The position of current focus</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnFocusChange(FlexibleView flexibleView, int previousFocus, int currentFocus)
            {
            }

            /// <summary>
            /// Called when a view created by this adapter has been recycled.
            /// If an item view has large or expensive data bound to it such as large bitmaps, this may be a good place to release those resources
            /// </summary>
            /// <param name="holder">The ViewHolder will be recycled.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewRecycled(ViewHolder holder)
            {
            }

            /// <summary>
            /// Called when a view created by this adapter has been attached to a window.
            /// This can be used as a reasonable signal that the view is about to be seen by the user.
            /// </summary>
            /// <param name="holder">Holder of the view being attached.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewAttachedToWindow(ViewHolder holder)
            {
            }

            /// <summary>
            /// Called when a view created by this adapter has been detached from its window.
            /// </summary>
            /// <param name="holder">Holder of the view being detached.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnViewDetachedFromWindow(ViewHolder holder)
            {
            }

            /// <summary>
            /// Notify any registered observers that the data set has changed.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyDataSetChanged()
            {
            }

            /// <summary>
            /// Notify any registered observers that the data set has changed.
            /// It indicates that any reflection of the data at position is out of date and should be updated.
            /// </summary>
            /// <param name="position">Position of the item that has changed</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemChanged(int position)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Change,
                };
                args.param[0] = position;
                args.param[1] = 1;
                OnItemEvent(this, args);
            }

            /// <summary>
            /// Notify any registered observers that the itemCount items starting at position positionStart have changed.
            /// An optional payload can be passed to each changed item.
            /// </summary>
            /// <param name="positionStart">Position of the first item that has changed</param>
            /// <param name="itemCount">Number of items that have changed</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeChanged(int positionStart, int itemCount)
            {
            }

            /// <summary>
            /// Notify any registered observers that the data set has been newly inserted.
            /// It indicates that any reflection of the data at position is out of date and should be updated.
            /// </summary>
            /// <param name="position">Position of the item that has been newly inserted</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemInserted(int position)
            {
                NotifyItemRangeInserted(position, 1);
            }

            /// <summary>
            /// Notify any registered observers that the itemCount items starting at position positionStart have been newly inserted.
            /// </summary>
            /// <param name="positionStart">Position of the first item that was inserted</param>
            /// <param name="itemCount">Number of items inserted</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeInserted(int positionStart, int itemCount)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Insert,
                };
                args.param[0] = positionStart;
                args.param[1] = itemCount;
                OnItemEvent(this, args);
            }

            /// <summary>
            /// Notify any registered observers that the item previously located at position has been removed from the data set. 
            /// </summary>
            /// <param name="position">Previous position of the first item that was removed</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRemoved(int position)
            {
                NotifyItemRangeRemoved(position, 1);
            }

            /// <summary>
            /// Notify any registered observers that the itemCount items previously located at positionStart have been removed from the data set.
            /// </summary>
            /// <param name="positionStart">Previous position of the first item that was removed</param>
            /// <param name="itemCount">Number of items removed from the data set </param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemRangeRemoved(int positionStart, int itemCount)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Remove,
                };
                args.param[0] = positionStart;
                args.param[1] = itemCount;
                OnItemEvent(this, args);
            }

            /// <summary>
            /// Notify any registered observers that the item reflected at fromPosition has been moved to toPosition.
            /// </summary>
            /// <param name="fromPosition">Previous position of the item</param>
            /// <param name="toPosition">New position of the item. </param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void NotifyItemMoved(int fromPosition, int toPosition)
            {

            }

            private void OnItemEvent(object sender, ItemEventArgs e)
            {
                itemEventHandlers?.Invoke(sender, e);
            }

            internal class ItemEventArgs : EventArgs
            {

                /// <summary>
                /// Data change event parameters.
                /// </summary>
                public int[] param = new int[4];

                /// <summary>
                /// Data changed event type.
                /// </summary>
                public ItemEventType EventType
                {
                    get;
                    set;
                }
            }
        }

    }
}
