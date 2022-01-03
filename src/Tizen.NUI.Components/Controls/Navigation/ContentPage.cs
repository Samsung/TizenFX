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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The ContentPage class is a class which is a formatted full screen page.
    /// ContentPage contains title app bar and content.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class ContentPage : Page
    {
        private AppBar appBar = null;
        private View content = null;

        /// <summary>
        /// Creates a new instance of a ContentPage.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ContentPage() : base()
        {
            Layout = new ContentPageLayout();

            // ContentPage matches to parent by default.
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
        }

        /// <summary>
        /// Dispose ContentPage and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (appBar != null)
                {
                    Utility.Dispose(appBar);
                }

                if (content != null)
                {
                    Utility.Dispose(content);
                }
            }

            base.Dispose(type);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            SetAccessibilityConstructor(Role.PageTab);
        }

        /// <summary>
        /// AppBar of ContentPage.
        /// AppBar is added as a child of ContentPage automatically.
        /// AppBar is positioned at the top of the Page.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public AppBar AppBar
        {
            get
            {
                return GetValue(AppBarProperty) as AppBar;
            }
            set
            {
                SetValue(AppBarProperty, value);
                NotifyPropertyChanged();
            }
        }
        private AppBar InternalAppBar
        {
            get
            {
                return appBar;
            }
            set
            {
                if (appBar == value)
                {
                    return;
                }

                if (appBar != null)
                {
                    Remove(appBar);
                }

                appBar = value;
                if (appBar == null)
                {
                    return;
                }

                Add(appBar);
            }
        }

        /// <summary>
        /// Content of ContentPage.
        /// Content is added as a child of ContentPage automatically.
        /// Content is positioned below AppBar.
        /// Content is resized to fill the full screen except AppBar.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public View Content
        {
            get
            {
                return GetValue(ContentProperty) as View;
            }
            set
            {
                SetValue(ContentProperty, value);
                NotifyPropertyChanged();
            }
        }
        private View InternalContent
        {
            get
            {
                return content;
            }
            set
            {
                if (content == value)
                {
                    return;
                }

                if (content != null)
                {
                    Remove(content);
                }

                content = value;
                if (content == null)
                {
                    return;
                }

                Add(content);
            }
        }

        private class ContentPageLayout : AbsoluteLayout
        {
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                float maxWidth = SuggestedMinimumWidth.AsDecimal();
                float maxHeight = SuggestedMinimumHeight.AsDecimal();

                MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
                MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

                var appBar = (Owner as ContentPage)?.AppBar;
                var content = (Owner as ContentPage)?.Content;

                foreach (var childLayout in LayoutChildren)
                {
                    if (!childLayout.SetPositionByLayout)
                    {
                        continue;
                    }

                    if ((content != null) && (content == childLayout.Owner) && (content.HeightSpecification == LayoutParamPolicies.MatchParent))
                    {
                        var contentSizeH = heightMeasureSpec.Size.AsDecimal() - Padding.Top - Padding.Bottom - content.Margin.Top - content.Margin.Bottom - (appBar?.Layout.MeasuredHeight.Size.AsDecimal() ?? 0);
                        MeasureSpecification contentHeightSpec = new MeasureSpecification(new LayoutLength(contentSizeH), MeasureSpecification.ModeType.Exactly);
                        MeasureChildWithoutPadding(childLayout, widthMeasureSpec, contentHeightSpec);
                    }
                    else
                    {
                        MeasureChildWithoutPadding(childLayout, widthMeasureSpec, heightMeasureSpec);
                    }

                    float childRight = childLayout.MeasuredWidth.Size.AsDecimal() + childLayout.Owner.PositionX;
                    float childBottom = childLayout.MeasuredHeight.Size.AsDecimal() + childLayout.Owner.PositionY;

                    if (maxWidth < childRight)
                        maxWidth = childRight;

                    if (maxHeight < childBottom)
                        maxHeight = childBottom;

                    if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                    {
                        childWidthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                    }
                    if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                    {
                        childHeightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                    }
                }

                SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(maxWidth), widthMeasureSpec, childWidthState),
                                      ResolveSizeAndState(new LayoutLength(maxHeight), heightMeasureSpec, childHeightState));
            }

            protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                foreach (var childLayout in LayoutChildren)
                {
                    if (!childLayout.SetPositionByLayout)
                    {
                        continue;
                    }

                    LayoutLength childWidth = childLayout.MeasuredWidth.Size;
                    LayoutLength childHeight = childLayout.MeasuredHeight.Size;

                    LayoutLength childLeft = new LayoutLength(childLayout.Owner.PositionX);
                    LayoutLength childTop = new LayoutLength(childLayout.Owner.PositionY);

                    var appBar = (Owner as ContentPage)?.AppBar;
                    var content = (Owner as ContentPage)?.Content;

                    if ((content != null) && (content == childLayout.Owner))
                    {
                        childTop = new LayoutLength(Padding.Top + content.Margin.Top + (appBar?.Layout.MeasuredHeight.Size.AsDecimal() ?? 0));
                        childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight, false);
                    }
                    else
                    {
                        childLayout.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight, true);
                    }
                }
            }
        }
    }
}
