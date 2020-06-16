using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    public partial class FlexibleView
    {
        /// <summary>
        /// A LayoutManager is responsible for measuring and positioning item views within a FlexibleView
        /// as well as determining the policy for when to recycle item views that are no longer visible to the user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract class LayoutManager
        {
            /// <summary>
            /// Direction
            /// </summary>
            public enum Direction
            {
                /// <summary>
                /// Left
                /// </summary>
                Left,

                /// <summary>
                /// Right
                /// </summary>
                Right,

                /// <summary>
                /// Up
                /// </summary>
                Up,

                /// <summary>
                /// Down
                /// </summary>
                Down
            }

            private readonly int SCROLL_ANIMATION_DURATION = 500;

            private FlexibleView mFlexibleView;
            private ChildHelper mChildHelper;

            private List<ViewHolder> mPendingRecycleViews = new List<ViewHolder>();

            private Animation mScrollAni;

            /// <summary>
            /// Layout all relevant child views from the given adapter.
            /// </summary>
            /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public abstract void OnLayoutChildren(Recycler recycler);

            /// <summary>
            /// Called after a full layout calculation is finished.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void OnLayoutCompleted()
            {
            }

            /// <summary>
            /// Gets the current focus position in adapter.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int FocusPosition
            {
                get
                {
                    return mFlexibleView.mFocusedItemIndex;
                }
            }

            /// <summary>
            /// Gets the datas count in data sets.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ItemCount
            {
                get
                {
                    Adapter b = mFlexibleView != null ? mFlexibleView.mAdapter : null;

                    return b != null ? b.GetItemCount() : 0;
                }
            }

            /// <summary>
            /// Query if horizontal scrolling is currently supported. The default implementation returns false.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual bool CanScrollHorizontally()
            {
                return false;
            }

            /// <summary>
            /// Query if vertical scrolling is currently supported. The default implementation returns false.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual bool CanScrollVertically()
            {
                return false;
            }

            /// <summary>
            /// Scroll horizontally by dy pixels in screen coordinates.
            /// </summary>
            /// <param name="dy">distance to scroll in pixels. Y increases as scroll position approaches the top.</param>
            /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
            /// <param name="immediate">Specify if the scroll need animation</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ScrollHorizontallyBy(float dy, Recycler recycler, bool immediate)
            {
                return 0;
            }

            /// <summary>
            /// Scroll vertically by dy pixels in screen coordinates.
            /// </summary>
            /// <param name="dy">distance to scroll in pixels. Y increases as scroll position approaches the top.</param>
            /// <param name="recycler">Recycler to use for fetching potentially cached views for a position</param>
            /// <param name="immediate">Specify if the scroll need animation</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ScrollVerticallyBy(float dy, Recycler recycler, bool immediate)
            {
                return 0;
            }

            /// <summary>
            /// Compute the extent of the scrollbar's thumb within the range.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollExtent()
            {
                return 0;
            }

            /// <summary>
            /// Compute the offset of the scrollbar's thumb within the range.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollOffset()
            {
                return 0;
            }

            /// <summary>
            /// Compute the range that the scrollbar represents.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual float ComputeScrollRange()
            {
                return 0;
            }

            /// <summary>
            /// Scroll the FlexibleView to make the position visible.
            /// </summary>
            /// <param name="position">Scroll to this adapter position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void ScrollToPosition(int position)
            {

            }

            /// <summary>
            /// Scroll to the specified adapter position with the given offset from resolved layout start.
            /// </summary>
            /// <param name="position">Scroll to this adapter position</param>
            /// <param name="offset">The distance (in pixels) between the start edge of the item view and start edge of the FlexibleView.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public virtual void ScrollToPositionWithOffset(int position, int offset)
            {

            }

            internal void MoveFocus(FlexibleView.LayoutManager.Direction direction, Recycler recycler)
            {
                int prevFocusPosition = FocusPosition;
                int nextFocusPosition = GetNextPosition(FocusPosition, direction);
                if (nextFocusPosition == NO_POSITION)
                {
                    return;
                }

                FlexibleView.ViewHolder nextFocusChild = FindItemViewByPosition(nextFocusPosition);
                if (nextFocusChild == null)
                {
                    nextFocusChild = OnFocusSearchFailed(null, direction, recycler);
                }

                if (nextFocusChild != null)
                {
                    RequestChildRectangleOnScreen(mFlexibleView, nextFocusChild, recycler, false);

                    ChangeFocus(nextFocusPosition);
                }
            }

            /**
             * Requests that the given child of the RecyclerView be positioned onto the screen. This
             * method can be called for both unfocusable and focusable child views. For unfocusable
             * child views, focusedChildVisible is typically true in which case, layout manager
             * makes the child view visible only if the currently focused child stays in-bounds of RV.
             * @param parent The parent RecyclerView.
             * @param child The direct child making the request.
             * @param rect The rectangle in the child's coordinates the child
             *              wishes to be on the screen.
             * @param immediate True to forbid animated or delayed scrolling,
             *                  false otherwise
             * @param focusedChildVisible Whether the currently focused view must stay visible.
             * @return Whether the group scrolled to handle the operation
             */
            internal bool RequestChildRectangleOnScreen(FlexibleView parent, FlexibleView.ViewHolder child, Recycler recycler, bool immediate)
            {
                Vector2 scrollAmount = GetChildRectangleOnScreenScrollAmount(parent, child);
                float dx = scrollAmount[0];
                float dy = scrollAmount[1];
                if (dx != 0 || dy != 0)
                {
                    if (dx != 0 && CanScrollHorizontally())
                    {
                        ScrollHorizontallyBy(dx, recycler, immediate);
                    }
                    else if (dy != 0 && CanScrollVertically())
                    {
                        ScrollVerticallyBy(dy, recycler, immediate);
                    }
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Calls {@code FlexibleView#RelayoutRequest} on the underlying FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RelayoutRequest()
            {
                if (mFlexibleView != null)
                {
                    mFlexibleView.RelayoutRequest();
                }
            }

            /// <summary>
            /// Lay out the given child view within the FlexibleView using coordinates that include view margins.
            /// </summary>
            /// <param name="child">Child to lay out</param>
            /// <param name="left">Left edge, with item view left margin included</param>
            /// <param name="top">Top edge, with item view top margin included</param>
            /// <param name="width">Width, with item view left and right margin included</param>
            /// <param name="height">Height, with item view top and bottom margin included</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void LayoutChild(ViewHolder child, float left, float top, float width, float height)
            {
                if (null == child) return;
                View itemView = child.ItemView;
                itemView.SizeWidth = width - itemView.Margin.Start - itemView.Margin.End;
                itemView.SizeHeight = height - itemView.Margin.Top - itemView.Margin.Bottom;
                itemView.PositionX = left + itemView.Margin.Start;
                itemView.PositionY = top + itemView.Margin.Top;
            }

            /// <summary>
            /// Change the ViewHolder with focusPosition to focus.
            /// </summary>
            /// <param name="focusPosition">the newly focus position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ChangeFocus(int focusPosition)
            {
                if (mFlexibleView != null)
                {
                    mFlexibleView.DispatchFocusChanged(focusPosition);
                }
            }

            /// <summary>
            /// Return the current number of child views attached to the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int ChildCount
            {
                get
                {
                    return mChildHelper != null ? mChildHelper.GetChildCount() : 0;
                }
            }

            /// <summary>
            /// Return the child view at the given index.
            /// </summary>
            /// <param name="index">child index</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder GetChildAt(int index)
            {
                return mChildHelper != null ? mChildHelper.GetChildAt(index) : null;
            }

            /// <summary>
            /// Finds the view which represents the given adapter position.
            /// </summary>
            /// <param name="position">adapter position</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ViewHolder FindItemViewByPosition(int position)
            {
                return mFlexibleView.FindViewHolderForLayoutPosition(position);
            }

            /// <summary>
            /// Offset all child views attached to the parent FlexibleView by dx pixels along the horizontal axis.
            /// </summary>
            /// <param name="dx">Pixels to offset by </param>
            /// <param name="immediate">specify if the offset need animation</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void OffsetChildrenHorizontal(float dx, bool immediate)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                if (dx == 0)
                {
                    return;
                }

                int childCount = mChildHelper.GetChildCount();
                if (immediate == true)
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        v.ItemView.PositionX += dx;
                    }
                }
                else
                {
                    if (mScrollAni == null)
                    {
                        mScrollAni = new Animation();
                        mScrollAni.Duration = SCROLL_ANIMATION_DURATION;
                        mScrollAni.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSquare);
                    }

                    // avoid out of boundary of flexibleview. delta value might be used for shadow.
                    // this must be done before animation clear.
                    if (childCount > 0)
                    {
                        ViewHolder vh = mChildHelper.GetChildAt(0);
                        if (vh.LayoutPosition == 0)
                        {
                            if ((int)(vh.Left + dx) > 0)
                            {
                                dx = 0 - vh.Left;
                            }
                        }

                        vh = mChildHelper.GetChildAt(childCount - 1);
                        if (vh.LayoutPosition == ItemCount - 1)
                        {
                            if ((int)(vh.Right + dx) < (int)Width + PaddingRight)
                            {
                                dx = Width + PaddingRight - vh.Right;
                            }
                        }
                    }

                    // save position before animation clear.
                    float[] childrenPositon = new float[childCount];
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        childrenPositon[i] = v.ItemView.PositionX;
                    }

                    mScrollAni.Clear();
                    mScrollAni.Finished += OnScrollAnimationFinished;

                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        // set position again because position might be changed after animation clear.
                        v.ItemView.PositionX = childrenPositon[i];
                        mScrollAni.AnimateTo(v.ItemView, "PositionX", v.ItemView.PositionX + dx);
                    }
                    mScrollAni.Play();
                }
            }

            /// <summary>
            /// Offset all child views attached to the parent FlexibleView by dy pixels along the vertical axis.
            /// </summary>
            /// <param name="dy">Pixels to offset by </param>
            /// <param name="immediate">specify if the offset need animation</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void OffsetChildrenVertical(float dy, bool immediate)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                if (dy == 0)
                {
                    return;
                }

                int childCount = mChildHelper.GetChildCount();
                if (immediate == true)
                {
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        v.ItemView.PositionY += dy;
                    }
                }
                else
                {
                    if (mScrollAni == null)
                    {
                        mScrollAni = new Animation();
                        mScrollAni.Duration = SCROLL_ANIMATION_DURATION;
                        mScrollAni.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSquare);
                    }

                    // avoid out of boundary of flexibleview. delta value might be used for shadow.
                    // this must be done before animation clear.
                    if (childCount > 0)
                    {
                        ViewHolder vh = mChildHelper.GetChildAt(0);
                        if (vh.LayoutPosition == 0)
                        {
                            if ((int)(vh.Top + dy) > 0)
                            {
                                dy = 0 - vh.Top;
                            }
                        }

                        vh = mChildHelper.GetChildAt(childCount - 1);
                        if (vh.LayoutPosition == ItemCount - 1)
                        {
                            if ((int)(vh.Bottom + dy) < (int)Height + PaddingBottom)
                            {
                                dy = Height + PaddingBottom - vh.Bottom;
                            }
                        }
                    }

                    // save position before animation clear.
                    float[] childPositon = new float[childCount];
                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        childPositon[i] = v.ItemView.PositionY;
                    }

                    mScrollAni.Clear();
                    mScrollAni.Finished += OnScrollAnimationFinished;

                    for (int i = childCount - 1; i >= 0; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        // set position again because position might be changed after animation clear.
                        v.ItemView.PositionY = childPositon[i];
                        mScrollAni.AnimateTo(v.ItemView, "PositionY", v.ItemView.PositionY + dy);
                    }
                    mScrollAni.Play();
                }
            }

            /// <summary>
            /// Return the width of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Width
            {
                get
                {
                    return mFlexibleView != null ? mFlexibleView.SizeWidth : 0;
                }
            }

            /// <summary>
            /// Return the height of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float Height
            {
                get
                {
                    return mFlexibleView != null ? mFlexibleView.SizeHeight : 0;
                }
            }

            /// <summary>
            /// Return the left padding of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int PaddingLeft
            {
                get
                {
                    return mFlexibleView?.Padding?.Start ?? 0;
                }
            }

            /// <summary>
            /// Return the top padding of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int PaddingTop
            {
                get
                {
                    return mFlexibleView?.Padding?.Top ?? 0;
                }
            }

            /// <summary>
            /// Return the right padding of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int PaddingRight
            {
                get
                {
                    return mFlexibleView?.Padding?.End ?? 0;
                }
            }

            /// <summary>
            /// Return the bottom padding of the parent FlexibleView.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int PaddingBottom
            {
                get
                {
                    return mFlexibleView?.Padding?.Bottom ?? 0;
                }
            }

            /// <summary>
            /// Add a view to the currently attached FlexibleView if needed.<br />
            /// LayoutManagers should use this method to add views obtained from a FlexibleView.Recycler using getViewForPosition(int).<br />
            /// </summary>
            /// <param name="holder">view to add</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddView(ViewHolder holder)
            {
                AddView(holder, -1);
            }

            /// <summary>
            /// Add a view to the currently attached FlexibleView if needed.<br />
            /// LayoutManagers should use this method to add views obtained from a FlexibleView.Recycler using getViewForPosition(int).<br />
            /// </summary>
            /// <param name="holder">view to add</param>
            /// <param name="index">index to add child at</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void AddView(ViewHolder holder, int index)
            {
                AddViewInternal(holder, index, false);
            }

            /// <summary>
            /// Temporarily detach and scrap all currently attached child views.
            /// Views will be scrapped into the given Recycler.
            /// The Recycler may prefer to reuse scrap views before other views that were previously recycled.
            /// </summary>
            /// <param name="recycler">Recycler to scrap views into</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void ScrapAttachedViews(Recycler recycler)
            {
                if (null == mChildHelper || null == recycler)
                {
                    return;
                }

                recycler.Clear();

                mChildHelper.ScrapViews(recycler);
            }

            /**
             * Remove a child view and recycle it using the given Recycler.
             *
             * @param index Index of child to remove and recycle
             * @param recycler Recycler to use to recycle child
             */
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RemoveAndRecycleViewAt(int index, Recycler recycler)
            {
                if (null == recycler) return;
                ViewHolder v = mChildHelper.GetChildAt(index);
                mChildHelper.RemoveViewAt(index);
                recycler.RecycleView(v);
            }

            /// <summary>
            /// ecycles children between given indices..
            /// </summary>
            /// <param name="recycler">Recycler to recycle views into</param>
            /// <param name="startIndex">inclusive</param>
            /// <param name="endIndex">exclusive</param>
            /// <param name="immediate">recycle immediately or add to pending list and recycle later.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public void RecycleChildren(FlexibleView.Recycler recycler, int startIndex, int endIndex, bool immediate)
            {
                if (startIndex == endIndex)
                {
                    return;
                }
                if (endIndex > startIndex)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        if (v.PendingRecycle == false)
                        {
                            v.PendingRecycle = true;
                            mPendingRecycleViews.Add(v);
                        }
                    }
                }
                else
                {
                    for (int i = startIndex; i > endIndex; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        if (v.PendingRecycle == false)
                        {
                            v.PendingRecycle = true;
                            mPendingRecycleViews.Add(v);
                        }
                    }
                }
                if (immediate == true)
                {
                    RecycleChildrenInt(recycler);
                }
            }

            /// <summary>
            /// Retrieves a position that neighbor to current position by direction.
            /// </summary>
            /// <param name="position">The anchor adapter position</param>
            /// <param name="direction">The direction.</param>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected abstract int GetNextPosition(int position, FlexibleView.LayoutManager.Direction direction);

            /// <summary>
            /// Retrieves the first visible item view.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected virtual ViewHolder FindFirstVisibleItemView()
            {
                return null;
            }

            /// <summary>
            /// Retrieves the last visible item view.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected virtual ViewHolder FindLastVisibleItemView()
            {
                return null;
            }

            internal virtual ViewHolder OnFocusSearchFailed(FlexibleView.ViewHolder focused, LayoutManager.Direction direction, Recycler recycler)
            {
                return null;
            }

            internal void SetRecyclerView(FlexibleView recyclerView)
            {
                mFlexibleView = recyclerView;
                mChildHelper = recyclerView.mChildHelper;
            }

            internal void StopScroll(bool doSomethingAfterAnimationStopped)
            {
                if (mScrollAni != null && mScrollAni.State == Animation.States.Playing)
                {
                    mScrollAni.Finished -= OnScrollAnimationFinished;
                    mScrollAni.Stop();

                    if (doSomethingAfterAnimationStopped)
                    {
                        OnScrollAnimationFinished(mScrollAni, null);
                    }
                }
            }

            /**
             * Returns the scroll amount that brings the given rect in child's coordinate system within
             * the padded area of RecyclerView.
             * @param parent The parent RecyclerView.
             * @param child The direct child making the request.
             * @param rect The rectangle in the child's coordinates the child
             *             wishes to be on the screen.
             * @param immediate True to forbid animated or delayed scrolling,
             *                  false otherwise
             * @return The array containing the scroll amount in x and y directions that brings the
             * given rect into RV's padded area.
             */
            private Vector2 GetChildRectangleOnScreenScrollAmount(FlexibleView parent, FlexibleView.ViewHolder child)
            {
                Vector2 ret = new Vector2(0, 0);
                int parentLeft = PaddingLeft;
                int parentTop = PaddingTop;
                int parentRight = (int)Width - PaddingRight;
                int parentBottom = (int)Height - PaddingBottom;
                int childLeft = (int)child.Left;
                int childTop = (int)child.Top;
                int childRight = (int)child.Right;
                int childBottom = (int)child.Bottom;

                int offScreenLeft = Math.Min(0, childLeft - parentLeft);
                int offScreenTop = Math.Min(0, childTop - parentTop);
                int offScreenRight = Math.Max(0, childRight - parentRight);
                int offScreenBottom = Math.Max(0, childBottom - parentBottom);

                // Favor the "start" layout direction over the end when bringing one side or the other
                // of a large rect into view. If we decide to bring in end because start is already
                // visible, limit the scroll such that start won't go out of bounds.
                int dx = offScreenLeft != 0 ? offScreenLeft
                            : Math.Min(childLeft - parentLeft, offScreenRight);

                // Favor bringing the top into view over the bottom. If top is already visible and
                // we should scroll to make bottom visible, make sure top does not go out of bounds.
                int dy = offScreenTop != 0 ? offScreenTop
                        : Math.Min(childTop - parentTop, offScreenBottom);

                ret.X = -dx;
                ret.Y = -dy;

                return ret;
            }

            private void OnScrollAnimationFinished(object sender, EventArgs e)
            {
                foreach (ViewHolder holder in mPendingRecycleViews)
                {
                    holder.PendingRecycle = false;
                }
                mPendingRecycleViews.Clear();

                int start = NO_POSITION;
                ViewHolder firstItemView = FindFirstVisibleItemView();
                if (firstItemView != null)
                    start = firstItemView.LayoutPosition;
                else
                    start = 0;

                int itemCount = ChildCount;

                int end = NO_POSITION;
                ViewHolder lastItemView = FindLastVisibleItemView();
                if (lastItemView != null)
                    end = lastItemView.LayoutPosition;
                else
                    end = itemCount - 1;

                List<ViewHolder> removedViewList = new List<ViewHolder>();
                for (int i = 0; i < itemCount; i++)
                {
                    ViewHolder v = GetChildAt(i);

                    //if item view of holder is visible, it should not be recycled.
                    if (v.LayoutPosition >= start && v.LayoutPosition <= end)
                        continue;

                    removedViewList.Add(v);
                }

                for (int i = 0; i < removedViewList.Count; i++)
                {
                    ViewHolder v = removedViewList[i];
                    v.PendingRecycle = false;
                    mFlexibleView.mRecycler.RecycleView(v);
                    mChildHelper.RemoveView(v);
                }

                // relayout
            }

            private void AddViewInternal(ViewHolder holder, int index, bool disappearing)
            {
                if (null == holder) return;
                if (holder.IsScrap())
                {
                    holder.Unscrap();
                    mChildHelper.AttachView(holder, index);
                }
                else
                {
                    mChildHelper.AddView(holder, index);
                }
            }

            private void RecycleChildrenInt(FlexibleView.Recycler recycler)
            {
                if (null == recycler) return;
                foreach (ViewHolder holder in mPendingRecycleViews)
                {
                    holder.PendingRecycle = false;
                    recycler.RecycleView(holder);
                    mChildHelper.RemoveView(holder);
                }
                mPendingRecycleViews.Clear();
            }

            private void ScrapOrRecycleView(Recycler recycler, ViewHolder itemView)
            {
                recycler.ScrapView(itemView);
            }

        }
    }
}
