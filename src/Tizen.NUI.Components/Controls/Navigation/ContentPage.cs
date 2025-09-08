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
using Tizen.NUI.Binding;

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

        private void Initialize()
        {
            Layout = new ContentPageLayout();

            // ContentPage matches to parent by default.
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
        }

        static ContentPage()
        {
            if (NUIApplication.IsUsingXaml)
            {
                AppBarProperty = BindableProperty.Create(nameof(AppBar), typeof(AppBar), typeof(ContentPage), null,
                    propertyChanged: SetInternalAppBarProperty, defaultValueCreator: GetInternalAppBarProperty);
                ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(ContentPage), null,
                    propertyChanged: SetInternalContentProperty, defaultValueCreator: GetInternalContentProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of a ContentPage.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ContentPage() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of ContentPage with style.
        /// </summary>
        /// <param name="style">Creates ContentPage by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentPage(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a ContentPage with style.
        /// </summary>
        /// <param name="style">A style applied to the newly created ContentPage.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentPage(ControlStyle style) : base(style)
        {
            Initialize();
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

            AccessibilityRole = Role.PageTab;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string AccessibilityGetName()
        {
            return AppBar?.Title;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(AppBarProperty) as AppBar;
                }
                else
                {
                    return InternalAppBar;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AppBarProperty, value);
                }
                else
                {
                    InternalAppBar = value;
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ContentProperty) as View;
                }
                else
                {
                    return InternalContent;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ContentProperty, value);
                }
                else
                {
                    InternalContent =  value;
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// for the case of ContentPage, it sets key focus on AppBar's NavigationContent
        /// </summary>
        protected internal override void RestoreKeyFocus()
        {
            if (FocusManager.Instance.IsDefaultAlgorithmEnabled())
            {
                if (LastFocusedView)
                {
                    FocusManager.Instance.SetCurrentFocusView(LastFocusedView);
                }
                else
                {
                    if (AppBar is var bar && bar != null)
                    {
                        FocusManager.Instance.SetCurrentFocusView(bar.PassFocusableViewInsideIfNeeded());
                    }
                    else
                    {
                        FocusManager.Instance.ClearFocus();
                    }
                }
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

                bool measureAppBarLayout = false;

                if ((appBar != null) && (appBar.Layout != null) && (LayoutChildren.Contains(appBar.Layout)) && appBar.Layout.SetPositionByLayout)
                {
                    MeasureChildWithoutPadding(appBar.Layout, widthMeasureSpec, heightMeasureSpec);
                    measureAppBarLayout = true;
                }

                foreach (var childLayout in LayoutChildren)
                {
                    if (!childLayout.SetPositionByLayout)
                    {
                        continue;
                    }

                    if ((content != null) && (content == childLayout.Owner) && (content.HeightSpecification == LayoutParamPolicies.MatchParent) && measureAppBarLayout)
                    {
                        var contentSizeH = heightMeasureSpec.Size.AsDecimal() - Padding.Top - Padding.Bottom - content.Margin.Top - content.Margin.Bottom - (appBar?.Layout.MeasuredHeight.Size.AsDecimal() ?? 0);
                        MeasureSpecification contentHeightSpec = new MeasureSpecification(new LayoutLength(contentSizeH), MeasureSpecification.ModeType.Exactly);
                        MeasureChildWithoutPadding(childLayout, widthMeasureSpec, contentHeightSpec);
                    }
                    else if (!measureAppBarLayout || (appBar != childLayout.Owner)) // if childLayout is not appBar.Layout
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
