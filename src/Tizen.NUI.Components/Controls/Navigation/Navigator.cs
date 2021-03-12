/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Navigator is a class which navigates pages with stack methods such
    /// as Push and Pop.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Navigator : Control
    {
        //This will be replaced with view transition class instance.
        private Animation _curAnimation = null;

        //This will be replaced with view transition class instance.
        private Animation _newAnimation = null;

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
        /// List of pages of Navigator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<Page> NavigationPages { get; } = new List<Page>();

        /// <summary>
        /// Pushes a page to Navigator.
        /// If the page is already in Navigator, then it is not pushed.
        /// </summary>
        /// <param name="page">The page to push to Navigator.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument page is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Push(Page page)
        {
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
            if (_curAnimation)
            {
                _curAnimation.Stop();
                _curAnimation.Clear();
            }

            if (_newAnimation)
            {
                _newAnimation.Stop();
                _newAnimation.Clear();
            }

            _curAnimation = new Animation(1000);
            using (var scaleVec = new Vector3(0.0f, 0.0f, 1.0f))
            {
                _curAnimation.AnimateTo(curTop, "Scale", scaleVec, 0, 1000);
            }
            _curAnimation.AnimateTo(curTop, "Opacity", 0.0f, 0, 1000);
            _curAnimation.EndAction = Animation.EndActions.Discard;
            _curAnimation.Play();

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
            _newAnimation = new Animation(1000);
            using (var scaleVec = new Vector3(1.0f, 1.0f, 1.0f))
            {
                _newAnimation.AnimateTo(page, "Scale", scaleVec, 0, 1000);
            }
            _newAnimation.AnimateTo(page, "Opacity", 1.0f, 0, 1000);
            _newAnimation.Play();
        }

        /// <summary>
        /// Pops the top page from Navigator.
        /// </summary>
        /// <returns>The popped page.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is no page in Navigator.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page Pop()
        {
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
            if (_curAnimation)
            {
                _curAnimation.Stop();
                _curAnimation.Clear();
            }

            if (_newAnimation)
            {
                _newAnimation.Stop();
                _newAnimation.Clear();
            }

            _curAnimation = new Animation(1000);
            using (var scaleVec = new Vector3(0.0f, 0.0f, 1.0f))
            {
                _curAnimation.AnimateTo(curTop, "Scale", scaleVec, 0, 1000);
            }
            _curAnimation.AnimateTo(curTop, "Opacity", 0.0f, 0, 1000);
            _curAnimation.Play();
            _curAnimation.Finished += (object sender, EventArgs e) =>
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
            _newAnimation = new Animation(1000);
            using (var scaleVec = new Vector3(1.0f, 1.0f, 1.0f))
            {
                _newAnimation.AnimateTo(newTop, "Scale", scaleVec, 0, 1000);
            }
            _newAnimation.AnimateTo(newTop, "Opacity", 1.0f, 0, 1000);
            _newAnimation.Play();

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
    }
} //namespace Tizen.NUI
