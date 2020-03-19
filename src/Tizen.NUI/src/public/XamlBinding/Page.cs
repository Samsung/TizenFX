/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// A BaseHandle that occupies the entire screen.
    /// </summary>
    // [RenderWith(typeof(_PageRenderer))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Page : BaseHandle, IPageController, IElementConfiguration<Page>
    {
        /// <summary>
        /// For internal use.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const string BusySetSignalName = "NUI.BusySet";

        /// <summary>
        /// For internal use.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const string AlertSignalName = "NUI.SendAlert";

        /// <summary>
        /// For internal use.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const string ActionSheetSignalName = "NUI.ShowActionSheet";

        /// <summary>
        /// Save current window.
        /// </summary>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Window window;

        internal static readonly BindableProperty IgnoresContainerAreaProperty = BindableProperty.Create("IgnoresContainerArea", typeof(bool), typeof(Page), false);

        /// <summary>
        /// Identifies the IsBusy property.
        /// </summary>
        internal static readonly BindableProperty IsBusyProperty = BindableProperty.Create("IsBusy", typeof(bool), typeof(Page), false, propertyChanged: (bo, o, n) => ((Page)bo).OnPageBusyChanged());

        Rectangle _containerArea;

        bool _hasAppeared;

        ReadOnlyCollection<Element> _logicalChildren;

        /// <summary>
        /// Creates a new Page element with default values.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page(Window win)
        {
            window = win;
            // ToolbarItems = toolbarItems;
            InternalChildren.CollectionChanged += InternalChildrenOnCollectionChanged;
            window.AddPage(this);
        }

        /// <summary>
        /// Marks the Page as busy. This will cause the platform specific global activity indicator to show a busy state.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle ContainerArea
        {
            get { return _containerArea; }
            set
            {
                if (_containerArea == value)
                    return;

                _containerArea = value;
                ForceLayout();
            }
        }

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IgnoresContainerArea
        {
            get { return (bool)GetValue(IgnoresContainerAreaProperty); }
            set { SetValue(IgnoresContainerAreaProperty, value); }
        }

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ObservableCollection<Element> InternalChildren { get; } = new ObservableCollection<Element>();

        internal override ReadOnlyCollection<Element> LogicalChildrenInternal =>
            _logicalChildren ?? (_logicalChildren = new ReadOnlyCollection<Element>(InternalChildren));

        /// <summary>
        /// ndicates that the Page is about to appear.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Appearing;

        /// <summary>
        /// Indicates that the Page is about to cease displaying.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler Disappearing;

        /// <summary>
        /// Displays a native platform action sheet, allowing the application user to choose from several buttons.
        /// </summary>
        /// <param name="title">Title of the displayed action sheet. Must not be null.</param>
        /// <param name="cancel">Text to be displayed in the 'Cancel' button. Can be null to hide the cancel action.</param>
        /// <param name="destruction">Text to be displayed in the 'Destruct' button. Can be null to hide the destructive option.</param>
        /// <param name="buttons">Text labels for additional buttons. Must not be null.</param>
        /// <returns>An awaitable Task that displays an action sheet and returns the Text of the button pressed by the user.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            var args = new ActionSheetArguments(title, cancel, destruction, buttons);
            MessagingCenter.Send(this, ActionSheetSignalName, args);
            return args.Result.Task;
        }

        /// <summary>
        /// Presents an alert dialog to the application user with a single cancel button.
        /// </summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The body text of the alert dialog.</param>
        /// <param name="cancel">Text to be displayed on the 'Cancel' button.</param>
        /// <returns></returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task DisplayAlert(string title, string message, string cancel)
        {
            return DisplayAlert(title, message, null, cancel);
        }

        /// <summary>
        /// resents an alert dialog to the application user with an accept and a cancel button.
        /// </summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The body text of the alert dialog.</param>
        /// <param name="accept">Text to be displayed on the 'Accept' button.</param>
        /// <param name="cancel">Text to be displayed on the 'Cancel' button.</param>
        /// <returns></returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            if (string.IsNullOrEmpty(cancel))
                throw new ArgumentNullException("cancel");

            var args = new AlertArguments(title, message, accept, cancel);
            MessagingCenter.Send(this, AlertSignalName, args);
            return args.Result.Task;
        }

        /// <summary>
        /// Forces the Page to perform a layout pass.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ForceLayout()
        {
        }

        /// <summary>
        /// Calls OnBackButtonPressed().
        /// </summary>
        /// <returns></returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SendBackButtonPressed()
        {
            return OnBackButtonPressed();
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Page x, Page y)
        {
            // if the C# objects are the same return true
            if (Page.ReferenceEquals(x, y))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Inequality operator. Returns Null if either operand is Null
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Page x, Page y)
        {
            return !(x == y);
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the Page becoming visible.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnAppearing()
        {
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>true if consumed</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnBackButtonPressed()
        {
            var application = RealParent as Application;

            var canceled = false;
            EventHandler handler = (sender, args) => { canceled = true; };

            return !canceled;
        }

        /// <summary>
        /// Invoked whenever the binding context of the Page changes. Override this method to add class handling for this event.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        /// <summary>
        /// Indicates that the preferred size of a child Element has changed.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnChildMeasureInvalidated(object sender, EventArgs e)
        {
            InvalidationTrigger trigger = (e as InvalidationEventArgs)?.Trigger ?? InvalidationTrigger.Undefined;
            OnChildMeasureInvalidated((BaseHandle)sender, trigger);
        }

        /// <summary>
        /// When overridden, allows the application developer to customize behavior as the Page disappears.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnDisappearing()
        {
        }

        /// <summary>
        /// Called when the Page's Parent property has changed.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnParentSet()
        {
            base.OnParentSet();
        }

        internal virtual void OnChildMeasureInvalidated(BaseHandle child, InvalidationTrigger trigger)
        {
            var container = this as IPageContainer<Page>;
            if (container != null)
            {
                Page page = container.CurrentPage;
                if (page != null)
                {
                    return;
                }
            }
            else
            {
                for (var i = 0; i < LogicalChildren.Count; i++)
                {
                    var v = LogicalChildren[i] as BaseHandle;
                    if (v != null)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// For intarnal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendAppearing()
        {
            if (_hasAppeared)
                return;

            _hasAppeared = true;

            if (IsBusy)
                MessagingCenter.Send(this, BusySetSignalName, true);

            OnAppearing();
            Appearing?.Invoke(this, EventArgs.Empty);

            var pageContainer = this as IPageContainer<Page>;
            pageContainer?.CurrentPage?.SendAppearing();
        }

        /// <summary>
        /// For intarnal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendDisappearing()
        {
            if (!_hasAppeared)
                return;

            _hasAppeared = false;

            if (IsBusy)
                MessagingCenter.Send(this, BusySetSignalName, false);

            var pageContainer = this as IPageContainer<Page>;
            pageContainer?.CurrentPage?.SendDisappearing();

            OnDisappearing();
            Disappearing?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// To make the ContentPage instance be disposed.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            window.RemovePage(this);
            base.Dispose(type);
        }

        Application FindApplication(Element element)
        {
            if (element == null)
                return null;

            return (element.Parent is Application app) ? app : FindApplication(element.Parent);
        }

        void InternalChildrenOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (BaseHandle item in e.OldItems.OfType<BaseHandle>())
                {
                    OnInternalRemoved(item);
                }
            }

            if (e.NewItems != null)
            {
                foreach (BaseHandle item in e.NewItems.OfType<BaseHandle>())
                {
                    OnInternalAdded(item);
                }
            }
        }

        private void OnInternalAdded(BaseHandle view)
        {
            OnChildAdded(view);
        }

        private void OnInternalRemoved(BaseHandle view)
        {
            OnChildRemoved(view);
        }

        void OnPageBusyChanged()
        {
            if (!_hasAppeared)
                return;

            MessagingCenter.Send(this, BusySetSignalName, IsBusy);
        }

        void OnToolbarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action != NotifyCollectionChangedAction.Add)
                return;
            foreach (IElement item in args.NewItems)
                item.Parent = this;
        }

        bool ShouldLayoutChildren()
        {
            if (!LogicalChildren.Any())
            {
                return false;
            }

            var container = this as IPageContainer<Page>;
            if (container?.CurrentPage != null)
            {
                return true;
            }

            var any = false;
            for (var i = 0; i < LogicalChildren.Count; i++)
            {
                var v = LogicalChildren[i] as BaseHandle;
                if (v != null)
                {
                    any = true;
                    break;
                }
            }
            return !any;
        }
    }
}