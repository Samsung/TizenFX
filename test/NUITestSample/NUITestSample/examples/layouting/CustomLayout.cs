
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace SimpleLayout
{
    public class CustomLayout : LayoutGroup
    {
        protected override void OnMeasure( LayoutMeasureSpec widthMeasureSpec, LayoutMeasureSpec heightMeasureSpec )
        {
            var accumulatedWidth = new LayoutLength( 0 );
            var maxHeight = 0;
            var measuredWidth = new LayoutLength( 0 );
            LayoutLength measuredHeight = new LayoutLength( 0) ;
            LayoutMeasureSpec.ModeType widthMode = widthMeasureSpec.Mode;
            LayoutMeasureSpec.ModeType heightMode = heightMeasureSpec.Mode;

            bool isWidthExact = (widthMode == LayoutMeasureSpec.ModeType.EXACTLY);
            bool isHeightExact = (heightMode == LayoutMeasureSpec.ModeType.EXACTLY);

            // In this layout we will:
            //  Measuring the layout with the children in a horizontal configuration, one after another
            //  Set the required width to be the accumulated width of our children
            //  Set the required height to be the maximum height of any of our children

            for( uint i = 0; i < ChildCount; ++i )
            {
                var childLayout = GetChildAt( i );
                if( childLayout )
                {
                    MeasureChild( childLayout, widthMeasureSpec, heightMeasureSpec );
                    accumulatedWidth += childLayout.MeasuredWidth;
                    maxHeight = System.Math.Max( childLayout.MeasuredHeight.Value, maxHeight );
                }
            }

            measuredHeight.Value = maxHeight ;
            measuredWidth = accumulatedWidth;

            if( isWidthExact )
            {
                measuredWidth = new LayoutLength( widthMeasureSpec.Size );
            }

            if( isHeightExact )
            {
                measuredHeight = new LayoutLength( heightMeasureSpec.Size );
            }

            // Finally, call this method to set the dimensions we would like
            SetMeasuredDimensions( new MeasuredSize( measuredWidth ), new MeasuredSize( measuredHeight ) );
        }

        protected override void OnLayout( bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom )
        {
            LayoutLength childTop = new LayoutLength( 0 );
            LayoutLength childLeft = new LayoutLength( 0 );

            // We want to vertically align the children to the middle
            var height = bottom - top;
            var middle = height / 2;

            // Horizontally align the children to the middle of the space they are given too
            var width = right - left;
            uint count = ChildCount;
            var childIncrement = 0;
            if (count > 0)
            {
                childIncrement = width.Value / System.Convert.ToInt32( count );
            }
            var center = childIncrement / 2;

            // Check layout direction
            var view = GetOwner();
            ViewLayoutDirectionType layoutDirection = view.LayoutDirection;

            for ( uint i = 0; i < count; i++ )
            {
                uint itemIndex;
                // If RTL, then layout the last item first
                if (layoutDirection == ViewLayoutDirectionType.RTL)
                {
                    itemIndex = count - 1 - i;
                }
                else
                {
                    itemIndex = i;
                }

                LayoutItem childLayout = GetChildAt( itemIndex );
                if( childLayout )
                {
                    var childWidth = childLayout.MeasuredWidth;
                    var childHeight = childLayout.MeasuredHeight;

                    childTop = middle - (childHeight / 2);

                    var leftPosition = childLeft + center - childWidth / 2;

                    childLayout.Layout( leftPosition, childTop, leftPosition + childWidth, childTop + childHeight );
                    childLeft += childIncrement;
                }
            }
        }
    }
}
