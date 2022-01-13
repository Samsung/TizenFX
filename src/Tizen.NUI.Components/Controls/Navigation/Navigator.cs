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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// PoppedEventArgs is a class to record <see cref="Navigator.Popped"/> event arguments which will be sent to user.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class PoppedEventArgs : EventArgs
    {
        /// <summary>
        /// Page popped by Navigator.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Page Page { get; internal set; }
    }

    /// <summary>
    /// The Navigator is a class which navigates pages with stack methods such as Push and Pop.
    /// </summary>
    /// <remarks>
    /// With Transition class, Navigator supports smooth transition of View pair between two Pages
    /// by using <see cref="PushWithTransition(Page)"/> and <see cref="PopWithTransition()"/> methods.
    /// If current top Page and next top Page have <see cref="View"/>s those have same TransitionTag,
    /// Navigator creates smooth transition motion for them.
    /// Navigator.Transition property can be used to set properties of the Transition such as TimePeriod and AlphaFunction.
    /// When all transitions are finished, Navigator calls a callback methods those connected on the "TransitionFinished" event.
    /// </remarks>
    /// <example>
    /// <code>
    /// Navigator navigator = new Navigator()
    /// {
    ///     TimePeriod = new TimePeriod(500),
    ///     AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine)
    /// };
    ///
    /// View view = new View()
    /// {
    ///     TransitionOptions = new TransitionOptions()
    ///     {
    ///         /* Set properties for the transition of this View */
    ///     }
    /// };
    ///
    /// ContentPage newPage = new ContentPage()
    /// {
    ///     Content = view,
    /// };
    ///
    /// Navigator.PushWithTransition(newPage);
    /// </code>
    /// </example>
    /// <since_tizen> 9 </since_tizen>
    public class Navigator : Control
    {
        /// <summary>
        /// TransitionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionProperty = BindableProperty.Create(nameof(Transition), typeof(Transition), typeof(Navigator), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Navigator)bindable;
            if (newValue != null)
            {
                instance.InternalTransition = newValue as Transition;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Navigator)bindable;
            return instance.InternalTransition;
        });

        private const int DefaultTransitionDuration = 500;

        //This will be replaced with view transition class instance.
        private Animation curAnimation = null;

        //This will be replaced with view transition class instance.
        private Animation newAnimation = null;

        private TransitionSet transitionSet = null;

        private Transition transition = new Transition()
        {
            TimePeriod = new TimePeriod(DefaultTransitionDuration),
            AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default),
        };

        private bool transitionFinished = true;

        //TODO: Needs to consider how to remove disposed window from dictionary.
        //Two dictionaries are required to remove disposed navigator from dictionary.
        private static Dictionary<Window, Navigator> windowNavigator = new Dictionary<Window, Navigator>();
        private static Dictionary<Navigator, Window> navigatorWindow = new Dictionary<Navigator, Window>();

        private List<Page> navigationPages = new List<Page>();

        /// <summary>
        /// Creates a new instance of a Navigator.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Navigator() : base()
        {
            Layout = new AbsoluteLayout();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            SetAccessibilityConstructor(Role.PageTabList);
        }

        /// <summary>
        /// An event fired when Transition has been finished.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<EventArgs> TransitionFinished;

        /// <summary>
        /// An event fired when Pop of a page has been finished.
        /// </summary>
        /// <remarks>
        /// When you free resources in the Popped event handler, please make sure if the popped page is the page you find.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<PoppedEventArgs> Popped;

        /// <summary>
        /// Returns the count of pages in Navigator.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public int PageCount => navigationPages.Count;

        /// <summary>
        /// Transition properties for the transition of View pair having same transition tag.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Transition Transition
        {
            get
            {
                return GetValue(TransitionProperty) as Transition;
            }
            set
            {
                SetValue(TransitionProperty, value);
                NotifyPropertyChanged();
            }
        }
        private Transition InternalTransition
        {
            set
            {
                transition = value;
            }
            get
            {
                return transition;
            }
        }

        /// <summary>
        /// Pushes a page to Navigator.
        /// If the page is already in Navigator, then it is not pushed.
        /// </summary>
        /// <param name="page">The page to push to Navigator.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument page is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void PushWithTransition(Page page)
        {
            if (!transitionFinished)
            {
                Tizen.Log.Error("NUI", "Transition is still not finished.\n");
                return;
            }

            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "page should not be null.");
            }

            //Duplicate page is not pushed.
            if (navigationPages.Contains(page)) return;

            var topPage = Peek();

            if (!topPage)
            {
                Insert(0, page);
                return;
            }

            navigationPages.Add(page);
            Add(page);
            page.Navigator = this;

            //Invoke Page events
            page.InvokeAppearing();
            topPage.InvokeDisappearing();

            transitionSet = CreateTransitions(topPage, page, true);
            transitionSet.Finished += (object sender, EventArgs e) =>
            {
                if (page is DialogPage == false)
                {
                   topPage.SetVisible(false);
                }

                // Need to update Content of the new page
                ShowContentOfPage(page);

                //Invoke Page events
                page.InvokeAppeared();
                topPage.InvokeDisappeared();
                NotifyAccessibilityStatesChangeOfPages(topPage, page);
            };
            transitionFinished = false;
        }

        /// <summary>
        /// Pops the top page from Navigator.
        /// </summary>
        /// <returns>The popped page.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is no page in Navigator.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Page PopWithTransition()
        {
            if (!transitionFinished)
            {
                Tizen.Log.Error("NUI", "Transition is still not finished.\n");
                return null;
            }

            if (navigationPages.Count == 0)
            {
                throw new InvalidOperationException("There is no page in Navigator.");
            }

            var topPage = Peek();

            if (navigationPages.Count == 1)
            {
                Remove(topPage);

                //Invoke Popped event
                Popped?.Invoke(this, new PoppedEventArgs() { Page = topPage });

                return topPage;
            }
            var newTopPage = navigationPages[navigationPages.Count - 2];

            //Invoke Page events
            newTopPage.InvokeAppearing();
            topPage.InvokeDisappearing();

            transitionSet = CreateTransitions(topPage, newTopPage, false);
            transitionSet.Finished += (object sender, EventArgs e) =>
            {
                Remove(topPage);
                topPage.SetVisible(true);

                // Need to update Content of the new page
                ShowContentOfPage(newTopPage);

                //Invoke Page events
                newTopPage.InvokeAppeared();
                topPage.InvokeDisappeared();
                NotifyAccessibilityStatesChangeOfPages(topPage, newTopPage);

                //Invoke Popped event
                Popped?.Invoke(this, new PoppedEventArgs() { Page = topPage });
            };
            transitionFinished = false;

            return topPage;
        }

        /// <summary>
        /// Pushes a page to Navigator.
        /// If the page is already in Navigator, then it is not pushed.
        /// </summary>
        /// <param name="page">The page to push to Navigator.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument page is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Push(Page page)
        {
            if (!transitionFinished)
            {
                Tizen.Log.Error("NUI", "Transition is still not finished.\n");
                return;
            }

            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "page should not be null.");
            }

            //Duplicate page is not pushed.
            if (navigationPages.Contains(page)) return;

            var curTop = Peek();

            if (!curTop)
            {
                Insert(0, page);
                return;
            }

            navigationPages.Add(page);
            Add(page);
            page.Navigator = this;

            //Invoke Page events
            page.InvokeAppearing();
            curTop.InvokeDisappearing();

            //TODO: The following transition codes will be replaced with view transition.
            InitializeAnimation();

            if (page is DialogPage == false)
            {
                curAnimation = new Animation(1000);
                curAnimation.AnimateTo(curTop, "Opacity", 1.0f, 0, 1000);
                curAnimation.EndAction = Animation.EndActions.StopFinal;
                curAnimation.Finished += (object sender, EventArgs args) =>
                {
                    curTop.SetVisible(false);

                    //Invoke Page events
                    curTop.InvokeDisappeared();
                };
                curAnimation.Play();

                page.Opacity = 0.0f;
                page.SetVisible(true);
                newAnimation = new Animation(1000);
                newAnimation.AnimateTo(page, "Opacity", 1.0f, 0, 1000);
                newAnimation.EndAction = Animation.EndActions.StopFinal;
                newAnimation.Finished += (object sender, EventArgs e) =>
                {
                    // Need to update Content of the new page
                    ShowContentOfPage(page);

                    //Invoke Page events
                    page.InvokeAppeared();
                    NotifyAccessibilityStatesChangeOfPages(curTop, page);
                };
                newAnimation.Play();
            }
            else
            {
                ShowContentOfPage(page);
            }
        }

        /// <summary>
        /// Pops the top page from Navigator.
        /// </summary>
        /// <returns>The popped page.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is no page in Navigator.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Page Pop()
        {
            if (!transitionFinished)
            {
                Tizen.Log.Error("NUI", "Transition is still not finished.\n");
                return null;
            }

            if (navigationPages.Count == 0)
            {
                throw new InvalidOperationException("There is no page in Navigator.");
            }

            var curTop = Peek();

            if (navigationPages.Count == 1)
            {
                Remove(curTop);

                //Invoke Popped event
                Popped?.Invoke(this, new PoppedEventArgs() { Page = curTop });

                return curTop;
            }

            var newTop = navigationPages[navigationPages.Count - 2];

            //Invoke Page events
            newTop.InvokeAppearing();
            curTop.InvokeDisappearing();

            //TODO: The following transition codes will be replaced with view transition.
            InitializeAnimation();

            if (curTop is DialogPage == false)
            {
                curAnimation = new Animation(1000);
                curAnimation.AnimateTo(curTop, "Opacity", 0.0f, 0, 1000);
                curAnimation.EndAction = Animation.EndActions.StopFinal;
                curAnimation.Finished += (object sender, EventArgs e) =>
                {
                    //Removes the current top page after transition is finished.
                    Remove(curTop);
                    curTop.Opacity = 1.0f;

                    //Invoke Page events
                    curTop.InvokeDisappeared();

                    //Invoke Popped event
                    Popped?.Invoke(this, new PoppedEventArgs() { Page = curTop });
                };
                curAnimation.Play();

                newTop.Opacity = 1.0f;
                newTop.SetVisible(true);
                newAnimation = new Animation(1000);
                newAnimation.AnimateTo(newTop, "Opacity", 1.0f, 0, 1000);
                newAnimation.EndAction = Animation.EndActions.StopFinal;
                newAnimation.Finished += (object sender, EventArgs e) =>
                {
                    // Need to update Content of the new page
                    ShowContentOfPage(newTop);

                    //Invoke Page events
                    newTop.InvokeAppeared();
                    NotifyAccessibilityStatesChangeOfPages(curTop, newTop);
                };
                newAnimation.Play();
            }
            else
            {
                Remove(curTop);
            }

            return curTop;
        }

        /// <summary>
        /// Returns the page of the given index in Navigator.
        /// The indices of pages in Navigator are basically the order of pushing or inserting to Navigator.
        /// So a page's index in Navigator can be changed whenever push/insert or pop/remove occurs.
        /// </summary>
        /// <param name="index">The index of a page in Navigator.</param>
        /// <returns>The page of the given index in Navigator.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the argument index is less than 0, or greater than the number of pages.</exception>
        public Page GetPage(int index)
        {
            if ((index < 0) || (index > navigationPages.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should be greater than or equal to 0, and less than or equal to the number of pages.");
            }

            return navigationPages[index];
        }

        /// <summary>
        /// Returns the current index of the given page in Navigator.
        /// The indices of pages in Navigator are basically the order of pushing or inserting to Navigator.
        /// So a page's index in Navigator can be changed whenever push/insert or pop/remove occurs.
        /// </summary>
        /// <param name="page">The page in Navigator.</param>
        /// <returns>The index of the given page in Navigator. If the given page is not in the Navigator, then -1 is returned.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the argument page is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public int IndexOf(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "page should not be null.");
            }

            for (int i = 0; i < navigationPages.Count; i++)
            {
                if (navigationPages[i] == page)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Inserts a page at the specified index of Navigator.
        /// The indices of pages in Navigator are basically the order of pushing or inserting to Navigator.
        /// So a page's index in Navigator can be changed whenever push/insert or pop/remove occurs.
        /// To find the current index of a page in Navigator, please use IndexOf(page).
        /// If the page is already in Navigator, then it is not inserted.
        /// </summary>
        /// <param name="index">The index of a page in Navigator where the page will be inserted.</param>
        /// <param name="page">The page to insert to Navigator.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the argument index is less than 0, or greater than the number of pages.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the argument page is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Insert(int index, Page page)
        {
            if ((index < 0) || (index > navigationPages.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should be greater than or equal to 0, and less than or equal to the number of pages.");
            }

            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "page should not be null.");
            }

            //Duplicate page is not pushed.
            if (navigationPages.Contains(page)) return;

            //TODO: The following transition codes will be replaced with view transition.
            InitializeAnimation();

            ShowContentOfPage(page);

            if (index == PageCount)
            {
                page.Opacity = 1.0f;
                page.SetVisible(true);
            }
            else
            {
                page.SetVisible(false);
                page.Opacity = 0.0f;
            }

            navigationPages.Insert(index, page);
            Add(page);
            page.Navigator = this;
        }

        /// <summary>
        /// Inserts a page to Navigator before an existing page.
        /// If the page is already in Navigator, then it is not inserted.
        /// </summary>
        /// <param name="before">The existing page, before which a page will be inserted.</param>
        /// <param name="page">The page to insert to Navigator.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument before is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the argument page is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument before does not exist in Navigator.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void InsertBefore(Page before, Page page)
        {
            if (before == null)
            {
                throw new ArgumentNullException(nameof(before), "before should not be null.");
            }

            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "page should not be null.");
            }

            //Find the index of before page.
            int beforeIndex = navigationPages.FindIndex(x => x == before);

            //before does not exist in Navigator.
            if (beforeIndex == -1)
            {
                throw new ArgumentException("before does not exist in Navigator.", nameof(before));
            }

            Insert(beforeIndex, page);
        }

        /// <summary>
        /// Removes a page from Navigator.
        /// </summary>
        /// <param name="page">The page to remove from Navigator.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument page is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Remove(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "page should not be null.");
            }

            //TODO: The following transition codes will be replaced with view transition.
            InitializeAnimation();

            HideContentOfPage(page);

            if ((page == Peek()) && (PageCount >= 2))
            {
                navigationPages[PageCount - 2].Opacity = 1.0f;
                navigationPages[PageCount - 2].SetVisible(true);
            }

            page.Navigator = null;
            navigationPages.Remove(page);
            base.Remove(page);
        }

        /// <summary>
        /// Removes a page at the specified index of Navigator.
        /// The indices of pages in Navigator are basically the order of pushing or inserting to Navigator.
        /// So a page's index in Navigator can be changed whenever push/insert or pop/remove occurs.
        /// To find the current index of a page in Navigator, please use IndexOf(page).
        /// </summary>
        /// <param name="index">The index of a page in Navigator where the page will be removed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0, or greater than or equal to the number of pages.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= navigationPages.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should be greater than or equal to 0, and less than the number of pages.");
            }

            Remove(navigationPages[index]);
        }

        /// <summary>
        /// Returns the page at the top of Navigator.
        /// </summary>
        /// <returns>The page at the top of Navigator.</returns>
        /// <since_tizen> 9 </since_tizen>
        public Page Peek()
        {
            if (navigationPages.Count == 0) return null;

            return navigationPages[navigationPages.Count - 1];
        }

        /// <summary>
        /// Disposes Navigator and all children on it.
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
                foreach (Page page in navigationPages)
                {
                    Utility.Dispose(page);
                }
                navigationPages.Clear();

                Window window;

                if (navigatorWindow.TryGetValue(this, out window) == true)
                {
                    navigatorWindow.Remove(this);
                    windowNavigator.Remove(window);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Returns the default navigator of the given window.
        /// </summary>
        /// <returns>The default navigator of the given window.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the argument window is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static Navigator GetDefaultNavigator(Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window), "window should not be null.");
            }

            if (windowNavigator.ContainsKey(window) == true)
            {
                return windowNavigator[window];
            }

            var defaultNavigator = new Navigator();
            defaultNavigator.WidthResizePolicy = ResizePolicyType.FillToParent;
            defaultNavigator.HeightResizePolicy = ResizePolicyType.FillToParent;
            window.Add(defaultNavigator);
            windowNavigator.Add(window, defaultNavigator);
            navigatorWindow.Add(defaultNavigator, window);

            return defaultNavigator;
        }

        /// <summary>
        /// Create Transitions between currentTopPage and newTopPage
        /// </summary>
        /// <param name="currentTopPage">The top page of Navigator.</param>
        /// <param name="newTopPage">The new top page after transition.</param>
        /// <param name="pushTransition">True if this transition is for push new page</param>
        private TransitionSet CreateTransitions(Page currentTopPage, Page newTopPage, bool pushTransition)
        {
            currentTopPage.SetVisible(true);
            newTopPage.SetVisible(true);

            List<View> taggedViewsInNewTopPage = new List<View>();
            RetrieveTaggedViews(taggedViewsInNewTopPage, newTopPage, true);
            List<View> taggedViewsInCurrentTopPage = new List<View>();
            RetrieveTaggedViews(taggedViewsInCurrentTopPage, currentTopPage, true);

            List<KeyValuePair<View, View>> sameTaggedViewPair = new List<KeyValuePair<View, View>>();
            foreach(View currentTopPageView in taggedViewsInCurrentTopPage)
            {
                bool findPair = false;
                foreach(View newTopPageView in taggedViewsInNewTopPage)
                {
                    if((currentTopPageView.TransitionOptions != null) && (newTopPageView.TransitionOptions != null) &&
                        currentTopPageView.TransitionOptions?.TransitionTag == newTopPageView.TransitionOptions?.TransitionTag)
                    {
                        sameTaggedViewPair.Add(new KeyValuePair<View, View>(currentTopPageView, newTopPageView));
                        findPair = true;
                        break;
                    }
                }
                if(findPair)
                {
                    taggedViewsInNewTopPage.Remove(sameTaggedViewPair[sameTaggedViewPair.Count - 1].Value);
                }
            }
            foreach(KeyValuePair<View, View> pair in sameTaggedViewPair)
            {
                taggedViewsInCurrentTopPage.Remove(pair.Key);
            }

            TransitionSet newTransitionSet = new TransitionSet();
            foreach(KeyValuePair<View, View> pair in sameTaggedViewPair)
            {
                TransitionItem pairTransition = transition.CreateTransition(pair.Key, pair.Value, pushTransition);
                if(pair.Value.TransitionOptions?.TransitionWithChild ?? false)
                {
                    pairTransition.TransitionWithChild = true;
                }
                newTransitionSet.AddTransition(pairTransition);
            }

            newTransitionSet.Finished += (object sender, EventArgs e) =>
            {
                if(newTopPage.Layout != null)
                {
                    newTopPage.Layout.RequestLayout();
                }
                if(currentTopPage.Layout != null)
                {
                    currentTopPage.Layout.RequestLayout();
                }
                transitionFinished = true;
                InvokeTransitionFinished();
                transitionSet.Dispose();
                currentTopPage.Opacity = 1.0f;
            };

            if (!pushTransition || newTopPage is DialogPage == false)
            {
                View transitionView = (currentTopPage is ContentPage) ? (currentTopPage as ContentPage).Content : (currentTopPage as DialogPage).Content;
                if (currentTopPage.DisappearingTransition != null && transitionView != null)
                {
                    TransitionItemBase disappearingTransition = currentTopPage.DisappearingTransition.CreateTransition(transitionView, false);
                    disappearingTransition.TransitionWithChild = true;
                    newTransitionSet.AddTransition(disappearingTransition);
                }
                else
                {
                    currentTopPage.SetVisible(false);
                }
            }
            if (pushTransition || currentTopPage is DialogPage == false)
            {
                View transitionView = (newTopPage is ContentPage) ? (newTopPage as ContentPage).Content : (newTopPage as DialogPage).Content;
                if (newTopPage.AppearingTransition != null && transitionView != null)
                {
                    TransitionItemBase appearingTransition = newTopPage.AppearingTransition.CreateTransition(transitionView, true);
                    appearingTransition.TransitionWithChild = true;
                    newTransitionSet.AddTransition(appearingTransition);
                }
            }

            newTransitionSet.Play();

            return newTransitionSet;
        }

        /// <summary>
        /// Retrieve Tagged Views in the view tree.
        /// </summary>
        /// <param name="taggedViews">Returned tagged view list..</param>
        /// <param name="view">Root View to get tagged child View.</param>
        /// <param name="isRoot">Flag to check current View is page or not</param>
        private void RetrieveTaggedViews(List<View> taggedViews, View view, bool isRoot)
        {
            if (!isRoot && view.TransitionOptions != null)
            {
                if (!string.IsNullOrEmpty(view.TransitionOptions?.TransitionTag))
                {
                    taggedViews.Add((view as View));
                    if (view.TransitionOptions.TransitionWithChild)
                    {
                        return;
                    }
                }

            }

            foreach (View child in view.Children)
            {
                RetrieveTaggedViews(taggedViews, child, false);
            }
        }

        /// <summary>
        /// Notify accessibility states change of pages.
        /// </summary>
        /// <param name="disappearedPage">Disappeared page</param>
        /// <param name="appearedPage">Appeared page</param>
        private void NotifyAccessibilityStatesChangeOfPages(Page disappearedPage, Page appearedPage)
        {
            if (disappearedPage != null)
            {
                disappearedPage.UnregisterDefaultLabel();
                //We can call disappearedPage.NotifyAccessibilityStatesChange
                //To reduce accessibility events, we are using currently highlighted view instead
                View curHighlightedView = Accessibility.Accessibility.Instance.GetCurrentlyHighlightedView();
                if (curHighlightedView != null)
                {
                    curHighlightedView.NotifyAccessibilityStatesChange(AccessibilityStates.Visible | AccessibilityStates.Showing, AccessibilityStatesNotifyMode.Single);
                }
            }

            if (appearedPage != null)
            {
                appearedPage.RegisterDefaultLabel();
                appearedPage.NotifyAccessibilityStatesChange(AccessibilityStates.Visible | AccessibilityStates.Showing, AccessibilityStatesNotifyMode.Single);
            }
        }

        internal void InvokeTransitionFinished()
        {
            TransitionFinished?.Invoke(this, new EventArgs());
        }

        //TODO: The following transition codes will be replaced with view transition.
        private void InitializeAnimation()
        {
            if (curAnimation != null)
            {
                curAnimation.Stop();
                curAnimation.Clear();
                curAnimation = null;
            }

            if (newAnimation != null)
            {
                newAnimation.Stop();
                newAnimation.Clear();
                newAnimation = null;
            }
        }

        // Show and Register Content of Page to Accessibility bridge
        private void ShowContentOfPage(Page page)
        {
            View content = (page is DialogPage) ? (page as DialogPage)?.Content : (page as ContentPage)?.Content;
            if (content != null)
            {
                content.Show(); // Calls RegisterDefaultLabel()
            }
        }

        // Hide and Remove Content of Page from Accessibility bridge
        private void HideContentOfPage(Page page)
        {
            View content = (page is DialogPage) ? (page as DialogPage)?.Content : (page as ContentPage)?.Content;
            if (content != null)
            {
                content.Hide(); // Calls UnregisterDefaultLabel()
            }
        }
    }
}
