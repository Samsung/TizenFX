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
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Navigator is a class which navigates pages with stack methods such as Push and Pop.
    ///
    /// With Transition class, Navigator supports smooth transition of View pair between two Pages
    /// by using PushWithTransition(Page) and PopWithTransition() methods.
    /// If there is View pair of current top Page and next top Page those have same View.TransitionOptions.TransitionTag,
    /// Navigator creates smooth transition motion for them.
    /// Navigator.Transition property can be used to set properties of the Transition such as TimePeriod and AlphaFunction.
    /// When all transitions are finished, Navigator calls a callback methods those connected on the "TransitionFinished" event.
    /// 
    /// <example>
    /// <code>
    /// Navigator.Transition = new Transition()
    /// {
    ///     TimePeriod = new TimePeriod(0.5),
    ///     AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine)
    /// }
    ///
    /// Navigator.PushWithTransition(newPage);
    /// </code>
    /// </example>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Navigator : Control
    {
        private static readonly float DefaultTransitionDuration = 0.5f;

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

        /// <summary>
        /// Creates a new instance of a Navigator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Navigator() : base()
        {
            Layout = new AbsoluteLayout();
        }
        
        /// <summary>
        /// An event for the page disappearing signal which can be used to subscribe or unsubscribe the event handler provided by the user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<EventArgs> TransitionFinished;

        /// <summary>
        /// List of pages of Navigator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<Page> NavigationPages { get; } = new List<Page>();

        /// <summary>
        /// Transition properties for the transition of View pair those have same transition tag.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Transition Transition
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            if (NavigationPages.Contains(page)) return;

            var topPage = Peek();

            if (!topPage)
            {
                Insert(0, page);
                return;
            }

            NavigationPages.Add(page);
            Add(page);

            //Invoke Page events
            page.InvokeAppearing();
            topPage.InvokeDisappearing();

            transitionSet = CreateTransition(topPage, page, true);
            transitionSet.Finished += (object sender, EventArgs e) =>
            {
                topPage.SetVisible(false);
            };
            transitionFinished = false;
        }

        /// <summary>
        /// Pops the top page from Navigator.
        /// </summary>
        /// <returns>The popped page.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is no page in Navigator.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page PopWithTransition()
        {
            if (!transitionFinished)
            {
                Tizen.Log.Error("NUI", "Transition is still not finished.\n");
                return null;
            }

            if (NavigationPages.Count == 0)
            {
                throw new InvalidOperationException("There is no page in Navigator.");
            }

            var topPage = Peek();

            if (NavigationPages.Count == 1)
            {
                Remove(topPage);
                return topPage;
            }
            var newTopPage = NavigationPages[NavigationPages.Count - 2];

//            newTopPage.RaiseAbove(topPage);

            //Invoke Page events
            newTopPage.InvokeAppearing();
            topPage.InvokeDisappearing();

            transitionSet = CreateTransition(topPage, newTopPage, false);
            transitionSet.Finished += (object sender, EventArgs e) =>
            {
                Remove(topPage);
                topPage.SetVisible(true);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            if (NavigationPages.Contains(page)) return;

            var curTop = Peek();

            if (!curTop)
            {
                Insert(0, page);
                return;
            }

            NavigationPages.Add(page);
            Add(page);

            //Invoke Page events
            page.InvokeAppearing();
            curTop.InvokeDisappearing();

            //TODO: The following transition codes will be replaced with view transition.
            if (curAnimation)
            {
                curAnimation.Stop();
                curAnimation.Clear();
            }

            if (newAnimation)
            {
                newAnimation.Stop();
                newAnimation.Clear();
            }

            curAnimation = new Animation(1000);
            using (var scaleVec = new Vector3(0.0f, 0.0f, 1.0f))
            {
                curAnimation.AnimateTo(curTop, "Scale", scaleVec, 0, 1000);
            }
            curAnimation.AnimateTo(curTop, "Opacity", 0.0f, 0, 1000);
            curAnimation.EndAction = Animation.EndActions.Discard;
            curAnimation.Play();

            using (var scaleVec = new Vector3(0.0f, 0.0f, 1.0f))
            {
                using (var scaleProp = new Tizen.NUI.PropertyValue(scaleVec))
                {
                    Tizen.NUI.Object.SetProperty(page.SwigCPtr, Page.Property.SCALE, scaleProp);
                }
            }
            using (var scaleProp = new Tizen.NUI.PropertyValue(0.0f))
            {
                Tizen.NUI.Object.SetProperty(page.SwigCPtr, Page.Property.OPACITY, scaleProp);
            }
            newAnimation = new Animation(1000);
            using (var scaleVec = new Vector3(1.0f, 1.0f, 1.0f))
            {
                newAnimation.AnimateTo(page, "Scale", scaleVec, 0, 1000);
            }
            newAnimation.AnimateTo(page, "Opacity", 1.0f, 0, 1000);
            newAnimation.Play();
        }

        /// <summary>
        /// Pops the top page from Navigator.
        /// </summary>
        /// <returns>The popped page.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is no page in Navigator.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page Pop()
        {
            if (!transitionFinished)
            {
                Tizen.Log.Error("NUI", "Transition is still not finished.\n");
                return null;
            }

            if (NavigationPages.Count == 0)
            {
                throw new InvalidOperationException("There is no page in Navigator.");
            }

            var curTop = Peek();

            if (NavigationPages.Count == 1)
            {
                Remove(curTop);
                return curTop;
            }

            var newTop = NavigationPages[NavigationPages.Count - 2];

            //Invoke Page events
            newTop.InvokeAppearing();
            curTop.InvokeDisappearing();

            //TODO: The following transition codes will be replaced with view transition.
            if (curAnimation)
            {
                curAnimation.Stop();
                curAnimation.Clear();
            }

            if (newAnimation)
            {
                newAnimation.Stop();
                newAnimation.Clear();
            }

            curAnimation = new Animation(1000);
            using (var scaleVec = new Vector3(0.0f, 0.0f, 1.0f))
            {
                curAnimation.AnimateTo(curTop, "Scale", scaleVec, 0, 1000);
            }
            curAnimation.AnimateTo(curTop, "Opacity", 0.0f, 0, 1000);
            curAnimation.Play();
            curAnimation.Finished += (object sender, EventArgs e) =>
            {
                //Removes the current top page after transition is finished.
                Remove(curTop);
            };

            using (var scaleVec = new Vector3(0.0f, 0.0f, 1.0f))
            {
                using (var scaleProp = new Tizen.NUI.PropertyValue(scaleVec))
                {
                    Tizen.NUI.Object.SetProperty(newTop.SwigCPtr, Page.Property.SCALE, scaleProp);
                }
            }
            using (var opacityProp = new Tizen.NUI.PropertyValue(0.0f))
            {
                Tizen.NUI.Object.SetProperty(newTop.SwigCPtr, Page.Property.OPACITY, opacityProp);
            }
            newAnimation = new Animation(1000);
            using (var scaleVec = new Vector3(1.0f, 1.0f, 1.0f))
            {
                newAnimation.AnimateTo(newTop, "Scale", scaleVec, 0, 1000);
            }
            newAnimation.AnimateTo(newTop, "Opacity", 1.0f, 0, 1000);
            newAnimation.Play();

            return curTop;
        }

        /// <summary>
        /// Inserts a page at the specified index of Navigator.
        /// If the page is already in Navigator, then it is not inserted.
        /// </summary>
        /// <param name="index">The index of Navigator where a page will be inserted.</param>
        /// <param name="page">The page to insert to Navigator.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the argument index is less than 0, or greater than the number of pages.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the argument page is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Insert(int index, Page page)
        {
            if ((index < 0) || (index > NavigationPages.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should be greater than or equal to 0, and less than or equal to the number of pages.");
            }

            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "page should not be null.");
            }

            //Duplicate page is not pushed.
            if (NavigationPages.Contains(page)) return;

            NavigationPages.Insert(index, page);
            Add(page);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            int beforeIndex = NavigationPages.FindIndex(x => x == before);

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page), "page should not be null.");
            }

            NavigationPages.Remove(page);
            base.Remove(page);
        }

        /// <summary>
        /// Removes a page at the specified index of Navigator.
        /// </summary>
        /// <param name="index">The index of Navigator where a page will be removed.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0, or greater than or equal to the number of pages.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= NavigationPages.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should be greater than or equal to 0, and less than the number of pages.");
            }

            Remove(NavigationPages[index]);
        }

        /// <summary>
        /// Returns the page at the top of Navigator.
        /// </summary>
        /// <returns>The page at the top of Navigator.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page Peek()
        {
            if (NavigationPages.Count == 0) return null;

            return NavigationPages[NavigationPages.Count - 1];
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
                foreach (Page page in NavigationPages)
                {
                    Utility.Dispose(page);
                }
                NavigationPages.Clear();

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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Shows a dialog by pushing a page containing dialog to default navigator.
        /// </summary>
        /// <param name="content">The content of Dialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The pushed views are added to NavigationPages and are disposed in Navigator.Dispose().")]
        public static void ShowDialog(View content = null)
        {
            var window = NUIApplication.GetDefaultWindow();
            var defaultNavigator = window.GetDefaultNavigator();

            var dialog = new Dialog(content);
            SetDialogScrim(dialog);

            var dialogPage = new Page(dialog);
            defaultNavigator.Push(dialogPage);
        }

        /// <summary>
        /// Shows an alert dialog by pushing a page containing the alert dialog
        /// to default navigator.
        /// </summary>
        /// <param name="titleContent">The title content of AlertDialog.</param>
        /// <param name="content">The content of AlertDialog.</param>
        /// <param name="actionContent">The action content of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The pushed views are added to NavigationPages and are disposed in Navigator.Dispose().")]
        public static void ShowAlertDialog(View titleContent, View content, View actionContent)
        {
            var window = NUIApplication.GetDefaultWindow();
            var defaultNavigator = window.GetDefaultNavigator();

            var dialog = new AlertDialog(titleContent, content, actionContent);
            SetDialogScrim(dialog);

            var dialogPage = new Page(dialog);
            defaultNavigator.Push(dialogPage);
        }

        /// <summary>
        /// Shows an alert dialog by pushing a page containing the alert dialog
        /// to default navigator.
        /// </summary>
        /// <param name="title">The title of AlertDialog.</param>
        /// <param name="message">The message of AlertDialog.</param>
        /// <param name="positiveButtonText">The positive button text in the action content of AlertDialog.</param>
        /// <param name="positiveButtonClickedHandler">The clicked callback of the positive button in the action content of AlertDialog.</param>
        /// <param name="negativeButtonText">The negative button text in the action content of AlertDialog.</param>
        /// <param name="negativeButtonClickedHandler">The clicked callback of the negative button in the action content of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The pushed views are added to NavigationPages and are disposed in Navigator.Dispose().")]
        public static void ShowAlertDialog(string title = null, string message = null, string positiveButtonText = null, EventHandler<ClickedEventArgs> positiveButtonClickedHandler = null, string negativeButtonText = null, EventHandler<ClickedEventArgs> negativeButtonClickedHandler = null)
        {
            var window = NUIApplication.GetDefaultWindow();
            var defaultNavigator = window.GetDefaultNavigator();

            var dialog = new AlertDialog(title, message, positiveButtonText, positiveButtonClickedHandler, negativeButtonText, negativeButtonClickedHandler);
            SetDialogScrim(dialog);

            var dialogPage = new Page(dialog);
            defaultNavigator.Push(dialogPage);
        }

        /// <summary>
        /// Create Transition between currentTopPage and newTopPage
        /// </summary>
        /// <param name="currentTopPage">The top page of Navigator.</param>
        /// <param name="newTopPage">The new top page after transition.</param>
        /// <param name="pushTransition">True if this transition is for push new page</param>
        private TransitionSet CreateTransition(Page currentTopPage, Page newTopPage, bool pushTransition)
        {
            currentTopPage.SetVisible(true);
            newTopPage.SetVisible(true);

            List<View> taggedViewsInNewTopPage = new List<View>();
            RetrieveTaggedViews(taggedViewsInNewTopPage, newTopPage.Content);
            List<View> taggedViewsInCurrentTopPage = new List<View>();
            RetrieveTaggedViews(taggedViewsInCurrentTopPage, currentTopPage.Content);

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
                TransitionItem pairTransition = transition.CreateTransition(pair.Key, pair.Value);
                if(pair.Value.TransitionOptions?.TransitionWithChild ?? false)
                {
                    pairTransition.TransitionWithChild = true;
                }
                newTransitionSet.AddTransition(pairTransition);
            }
            newTransitionSet.Play();

            newTransitionSet.Finished += (object sender, EventArgs e) =>
            {
                transitionFinished = true;
                InvokeTransitionFinished();
                transitionSet.Dispose();
                currentTopPage.Opacity = 1.0f;
            };

            // default entering/exit transition - fast fade (half duration compaired with that of view pair transition)
            float duration = (transition.TimePeriod.DurationSeconds + transition.TimePeriod.DelaySeconds) * 0.8f;
            Animation fade = new Animation(duration);
            fade.AnimateTo(currentTopPage, "Opacity", 0.0f);
            KeyFrames keyframes = new KeyFrames();
            keyframes.Add(0.0f, 0.0f);
            keyframes.Add(1.0f, 1.0f);
            fade.AnimateBetween(newTopPage, "Opacity", keyframes);
            fade.Play();

            return newTransitionSet;
        }

        private static void SetDialogScrim(Dialog dialog)
        {
            if (dialog == null)
            {
                return;
            }

            var window = NUIApplication.GetDefaultWindow();
            var defaultNavigator = window.GetDefaultNavigator();
            var defaultScrim = dialog.Scrim;

            //Copies default scrim's GUI properties.
            var scrim = new VisualView();
            scrim.BackgroundColor = defaultScrim.BackgroundColor;
            scrim.Size = defaultScrim.Size;
            scrim.TouchEvent += (object source, View.TouchEventArgs e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    defaultNavigator.Pop();
                }

                return true;
            };

            dialog.Scrim = scrim;
        }


        /// <summary>
        /// Retrieve Tagged Views in the view tree.
        /// </summary>
        /// <param name="taggedViews">Returned tagged view list..</param>
        /// <param name="view">Root View to get tagged child View.</param>
        private void RetrieveTaggedViews(List<View> taggedViews, View view)
        {
            if (!string.IsNullOrEmpty(view.TransitionOptions?.TransitionTag))
            {
                taggedViews.Add((view as View));
            }

            if (view.ChildCount == 0)
            {
                return;
            }

            if (view.TransitionOptions?.TransitionWithChild ?? false)
            {
                return;
            }

            foreach (View child in view.Children)
            {
                RetrieveTaggedViews(taggedViews, child);
            }
        }

        internal void InvokeTransitionFinished()
        {
            TransitionFinished?.Invoke(this, new EventArgs());
        }
    }
} //namespace Tizen.NUI
