using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp
{
    /// <summary>
    /// Interface for all other scrollable widgets
    /// </summary>
    public interface IScrollable
    {

        /// <summary>
        /// Scrolled will be triggered when the content has been scrolled.
        /// </summary>
        event EventHandler Scrolled;

        /// <summary>
        /// DragStart will be triggered when dragging the contents around has started.
        /// </summary>
        event EventHandler DragStart;

        /// <summary>
        /// DragStop will be triggered when dragging the contents around has stopped.
        /// </summary>
        event EventHandler DragStop;

        /// <summary>
        /// PageScrolled will be triggered when the visible page has changed.
        /// </summary>
        event EventHandler PageScrolled;

        /// <summary>
        /// Set scrolling gravity values for a scroller.
        /// The gravity, defines how the scroller will adjust its view when the size of the scroller contents increase.
        /// The scroller will adjust the view to glue itself as follows.
        /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the rigth edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
        /// Default values for x and y are 0.0
        /// </summary>
        double VerticalGravity { get; set; }

        /// <summary>
        /// Set scrolling gravity values for a scroller.
        /// The gravity, defines how the scroller will adjust its view when the size of the scroller contents increase.
        /// The scroller will adjust the view to glue itself as follows.
        /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the rigth edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
        /// Default values for x and y are 0.0
        /// </summary>
        double HorizontalGravity { get; set; }

        /// <summary>
        /// Sets or gets the vertical bounce behaviour.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate the end has been reached.
        /// This is enabled by default for both axis.
        /// This API will set if it is enabled for the given axis with the boolean parameters for each axis.
        /// </summary>
        bool VerticalBounce { get; set; }

        /// <summary>
        /// Sets or gets the horizontal bounce behaviour.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate the end has been reached.
        /// This is enabled by default for both axis.
        /// This API will set if it is enabled for the given axis with the boolean parameters for each axis.
        /// </summary>
        bool HorizontalBounce { get; set; }

        /// <summary>
        /// Gets or sets a value whether mouse wheel is enabled or not over the scroller.
        /// </summary>
        bool WheelDisabled { get; set; }

        /// <summary>
        /// Sets or gets the value of ScrollBlock.
        /// </summary>
        /// <remarks>
        /// This function will block scrolling movement  in a given direction.One can disable movements in the X axis, the Y axis or both.
        /// The default value is ScrollBlock.None, where movements are allowed in both directions.
        /// </remarks>
        ScrollBlock ScrollBlock { get; set; }

        /// <summary>
        /// Sets or gets the value of VerticalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the vertical scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy { get; set; }

        /// <summary>
        /// Sets or gets the value of HorizontalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the horizontal scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy { get; set; }

        /// <summary>
        /// Gets the current region in the content object that is visible through the Scroller.
        /// </summary>
        Rect CurrentRegion { get; }

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at vertical direction.
        /// </summary>
        int VerticalPageScrollLimit { get; set; }

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at horizontal direction.
        /// </summary>
        int HorizontalPageScrollLimit { get; set; }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        int HorizontalPageSize { get; set; }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        int VerticalPageSize { get; set; }

        /// <summary>
        /// Gets or Sets the page snapping behavior of a scroller.
        /// </summary>
        /// <remarks>
        /// When scrolling, if a scroller is paged (see VerticalRelativePageSize),
        /// the scroller may snap to pages when being scrolled, i.e., even if it had momentum to scroll further,
        /// it will stop at the next page boundaries. This is disabled, by default, for both axis.
        /// This function will set if it that is enabled or not, for each axis.
        /// </remarks>
        bool VerticalSnap { get; set; }

        /// <summary>
        /// Gets or Sets the page snapping behavior of a scroller.
        /// </summary>
        /// <remarks>
        /// When scrolling, if a scroller is paged (see HorizontalRelativePageSize),
        /// the scroller may snap to pages when being scrolled, i.e., even if it had momentum to scroll further,
        /// it will stop at the next page boundaries. This is disabled, by default, for both axis.
        /// This function will set if it that is enabled or not, for each axis.
        /// </remarks>
        bool HorizontalSnap { get; set; }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        int PageHeight { get; set; }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        int PageWidth { get; set; }

        /// <summary>
        /// Gets or sets the type of single direction scroll.
        /// </summary>
        ScrollSingleDirection SingleDirection { get; set; }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        int HorizontalStepSize { get; set; }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        int VerticalStepSize { get; set; }

        /// <summary>
        /// Set an infinite loop_ for a scroller.
        /// This function sets the infinite loop vertically.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        bool VerticalLoop { get; set; }

        /// <summary>
        /// Set an infinite loop_ for a scroller.
        /// This function sets the infinite loop horizontally.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        bool HorizontalLoop { get; set; }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        double VerticalRelativePageSize { get; set; }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        double HorizontalRelativePageSize { get; set; }

        /// <summary>
        /// Get scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        int LastVerticalPageNumber { get; }

        /// <summary>
        /// Get scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        int LastHorizontalPageNumber { get; }

        /// <summary>
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the top of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the top of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        int VerticalPageIndex { get; }

        /// <summary>
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the left of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the left of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        int HorizontalPageIndex { get; }

        /// <summary>
        /// Gets the width of the content object of the scroller.
        /// </summary>
        int ChildWidth { get; }

        /// <summary>
        /// Gets the height of the content object of the scroller.
        /// </summary>
        int ChildHeight { get; }

        /// <summary>
        /// Sets the scroller minimum size limited to the minimum size of the content.
        /// By default the scroller will be as small as its design allows, irrespective of its content.
        /// This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.
        /// </summary>
        /// <param name="horizontal">Enable limiting minimum size horizontally</param>
        /// <param name="vertical">Enable limiting minimum size vertically</param>
        void MinimumLimit(bool horizontal, bool vertical);

        /// <summary>
        /// Shows a specific virtual region within the scroller content object by the page number.
        /// (0, 0) of the indicated page is located at the top-left corner of the viewport.
        /// </summary>
        /// <param name="horizontalPageIndex">The horizontal page number.</param>
        /// <param name="verticalPageIndex">The vertical page number.</param>
        /// <param name="animated">True means slider with animation.</param>
        void ScrollTo(int horizontalPageIndex, int verticalPageIndex, bool animated);

        /// <summary>
        /// Shows a specific virtual region within the scroller content object.
        /// </summary>
        /// <remarks>
        /// This ensures that all (or part, if it does not fit) of the designated region in the virtual content object ((0, 0)
        /// starting at the top-left of the virtual content object) is shown within the scroller.
        /// If set "animated" to true, it will allows the scroller to "smoothly slide" to this location
        /// (if configuration in general calls for transitions).
        /// It may not jump immediately to the new location and may take a while and show other content along the way.
        /// </remarks>
        /// <param name="region">Rect struct of region.</param>
        /// <param name="animated">True means allows the scroller to "smoothly slide" to this location.</param>
        void ScrollTo(Rect region, bool animated);
    }

    /// <summary>
    /// Enumeration for visible type of scrollbar.
    /// </summary>
    public enum ScrollBarVisiblePolicy
    {
        /// <summary>
        /// Show scrollbars as needed
        /// </summary>
        Auto = 0,

        /// <summary>
        /// Always show scrollbars
        /// </summary>
        Visible,

        /// <summary>
        /// Never show scrollbars
        /// </summary>
        Invisible
    }

    /// <summary>
    /// Enumeration for visible type of scrollbar.
    /// </summary>
    public enum ScrollBlock
    {
        /// <summary>
        /// Scrolling movement is allowed in both direction.(X axis and Y axis)
        /// </summary>
        None = 1,

        /// <summary>
        /// Scrolling movement is not allowed in Y axis direction.
        /// </summary>
        Vertical = 2,

        /// <summary>
        /// Scrolling movement is not allowed in X axis direction.
        /// </summary>
        Horizontal = 4
    }

    /// <summary>
    /// Type that controls how the content is scrolled.
    /// </summary>
    public enum ScrollSingleDirection
    {
        /// <summary>
        /// Scroll every direction.
        /// </summary>
        None,

        /// <summary>
        /// Scroll single direction if the direction is certain.
        /// </summary>
        Soft,

        /// <summary>
        /// Scroll only single direction.
        /// </summary>
        Hard,
    }
}
