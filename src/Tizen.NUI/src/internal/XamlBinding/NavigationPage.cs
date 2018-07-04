using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// A Page that manages the navigation and user-experience of a stack of other pages.
    /// </summary>
    // [RenderWith(typeof(_NavigationPageRenderer))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class NavigationPage : Page, IPageContainer<Page>, INavigationPageController, IElementConfiguration<NavigationPage>
    {
        /// <summary>
        /// Identifies the property associated with the title of the back button.
        /// </summary>
        public static readonly BindableProperty BackButtonTitleProperty = BindableProperty.CreateAttached("BackButtonTitle", typeof(string), typeof(Page), null);

        /// <summary>
        /// Backing store for the HasNavigationBar property.
        /// </summary>
        public static readonly BindableProperty HasNavigationBarProperty = BindableProperty.CreateAttached("HasNavigationBar", typeof(bool), typeof(Page), true);

        /// <summary>
        /// Backing store for the HasBackButton property.
        /// </summary>
        public static readonly BindableProperty HasBackButtonProperty = BindableProperty.CreateAttached("HasBackButton", typeof(bool), typeof(NavigationPage), true);

        /// <summary>
        /// Identifies the Tint bindable property.
        /// </summary>
        [Obsolete("TintProperty is obsolete as of version 1.2.0. Please use BarBackgroundColorProperty and BarTextColorProperty to change NavigationPage bar color properties.")] 
        public static readonly BindableProperty TintProperty = BindableProperty.Create("Tint", typeof(Color), typeof(NavigationPage), /*Color.Default*/Color.Black);

        /// <summary>
        /// Identifies the property associated with the color of the NavigationPage's bar background color.
        /// </summary>
        public static readonly BindableProperty BarBackgroundColorProperty = BindableProperty.Create("BarBackgroundColor", typeof(Color), typeof(NavigationPage), /*Color.Default*/Color.Black);

        /// <summary>
        /// Identifies the property associated with the color of the NavigationPage's bar text color.
        /// </summary>
        public static readonly BindableProperty BarTextColorProperty = BindableProperty.Create("BarTextColor", typeof(Color), typeof(NavigationPage), /*Color.Default*/Color.Black);

        /// <summary>
        /// Indicates the NavigationPage.SetTitleIcon/NavigationPage.GetTitleIcon property.
        /// </summary>
        public static readonly BindableProperty TitleIconProperty = BindableProperty.CreateAttached("TitleIcon", typeof(FileImageSource), typeof(NavigationPage), default(FileImageSource));

        static readonly BindablePropertyKey CurrentPagePropertyKey = BindableProperty.CreateReadOnly("CurrentPage", typeof(Page), typeof(NavigationPage), null);

        /// <summary>
        /// Identifies the property associated with NavigationPage.CurrentPage
        /// </summary>
        public static readonly BindableProperty CurrentPageProperty = CurrentPagePropertyKey.BindableProperty;

        static readonly BindablePropertyKey RootPagePropertyKey = BindableProperty.CreateReadOnly(nameof(RootPage), typeof(Page), typeof(NavigationPage), null);
        /// <summary>
        /// Identifies the property associated with NavigationPage.RootPage
        /// </summary>
        public static readonly BindableProperty RootPageProperty = RootPagePropertyKey.BindableProperty;

        /// <summary>
        /// Initializes a new NavigationPage object.
        /// </summary>
        public NavigationPage()
        {
            _platformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<NavigationPage>>(() => new PlatformConfigurationRegistry<NavigationPage>(this));

            Navigation = new NavigationImpl(this);
        }

        /// <summary>
        /// Creates a new NavigationPage element with root as its root element.
        /// </summary>
        /// <param name="root">The root page.</param>
        public NavigationPage(Page root) : this()
        {
            PushPage(root);
        }

        /// <summary>
        /// Gets or sets the background color for the bar at the top of the NavigationPage.
        /// </summary>
        public Color BarBackgroundColor
        {
            get { return (Color)GetValue(BarBackgroundColorProperty); }
            set { SetValue(BarBackgroundColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the text that appears on the bar at the top of the NavigationPage.
        /// </summary>
        public Color BarTextColor
        {
            get { return (Color)GetValue(BarTextColorProperty); }
            set { SetValue(BarTextColorProperty, value); }
        }

        /// <summary>
        /// The color to be used as the Tint of the NavigationPage.
        /// </summary>
        [Obsolete("Tint is obsolete as of version 1.2.0. Please use BarBackgroundColor and BarTextColor to change NavigationPage bar color properties.")]
        public Color Tint
        {
            get { return (Color)GetValue(TintProperty); }
            set { SetValue(TintProperty, value); }
        }

        internal Task CurrentNavigationTask { get; set; }

        /// <summary>
        /// For internal use
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <returns>The page instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Page Peek(int depth)
        {
            if (depth < 0)
            {
                return null;
            }

            if (InternalChildren.Count <= depth)
            {
                return null;
            }

            return (Page)InternalChildren[InternalChildren.Count - depth - 1];
        }

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerable<Page> Pages => InternalChildren.Cast<Page>();

        /// <summary>
        /// For internal use
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StackDepth
        {
            get { return InternalChildren.Count; }
        }

        /// <summary>
        /// The Page that is currently top-most on the navigation stack.
        /// </summary>
        public Page CurrentPage
        {
            get { return (Page)GetValue(CurrentPageProperty); }
            private set { SetValue(CurrentPagePropertyKey, value); }
        }

        /// <summary>
        /// The Page that is the root of the navigation stack.
        /// </summary>
        public Page RootPage
        {
            get { return (Page)GetValue(RootPageProperty); }
            private set { SetValue(RootPagePropertyKey, value); }
        }

        /// <summary>
        /// The title of the back button for the specified page.
        /// </summary>
        /// <param name="page">The Page whose back-button's title is being requested.</param>
        /// <returns>The title of the back button that would be shown if the specified page were the Xamarin.Forms.CurrentPage.</returns>
        public static string GetBackButtonTitle(BindableObject page)
        {
            return (string)page.GetValue(BackButtonTitleProperty);
        }

        /// <summary>
        /// Returns a value that indicates whether page has a back button.
        /// </summary>
        /// <param name="page">The page to be checked</param>
        /// <returns>true if the page has a back button.</returns>
        public static bool GetHasBackButton(Page page)
        {
            if (page == null)
                throw new ArgumentNullException("page");
            return (bool)page.GetValue(HasBackButtonProperty);
        }

        /// <summary>
        /// Returns a value that indicates whether the page has a navigation bar.
        /// </summary>
        /// <param name="page">The Page being queried.</param>
        /// <returns>true if page would display a navigation bar were it the CurrentPage.</returns>
        public static bool GetHasNavigationBar(BindableObject page)
        {
            return (bool)page.GetValue(HasNavigationBarProperty);
        }

        internal static FileImageSource GetTitleIcon(BindableObject bindable)
        {
            return (FileImageSource)bindable.GetValue(TitleIconProperty);
        }

        /// <summary>
        /// Asynchronously removes the top Page from the navigation stack.
        /// </summary>
        /// <returns>The Page that had been at the top of the navigation stack.</returns>
        public Task<Page> PopAsync()
        {
            return PopAsync(true);
        }

        /// <summary>
        /// Asynchronously removes the top Page from the navigation stack, with optional animation.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>The Page that had been at the top of the navigation stack.</returns>
        public async Task<Page> PopAsync(bool animated)
        {
            var tcs = new TaskCompletionSource<bool>();
            if (CurrentNavigationTask != null && !CurrentNavigationTask.IsCompleted)
            {
                var oldTask = CurrentNavigationTask;
                CurrentNavigationTask = tcs.Task;
                await oldTask;
            }
            else
                CurrentNavigationTask = tcs.Task;

            var result = await PopAsyncInner(animated, false);
            tcs.SetResult(true);
            return result;
        }

        /// <summary>
        /// Event that is raised after a page is popped from this NavigationPage element.
        /// </summary>
        public event EventHandler<NavigationEventArgs> Popped;

        /// <summary>
        /// Event that is raised when the last nonroot element is popped from this NavigationPage element.
        /// </summary>
        public event EventHandler<NavigationEventArgs> PoppedToRoot;

        /// <summary>
        /// Pops all but the root Page off the navigation stack.
        /// </summary>
        /// <returns>A task that represents the asynchronous dismiss operation.</returns>
        public Task PopToRootAsync()
        {
            return PopToRootAsync(true);
        }

        /// <summary>
        /// A task for asynchronously popping all pages off of the navigation stack.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>A task that represents the asynchronous dismiss operation.</returns>
        public async Task PopToRootAsync(bool animated)
        {
            if (CurrentNavigationTask != null && !CurrentNavigationTask.IsCompleted)
            {
                var tcs = new TaskCompletionSource<bool>();
                Task oldTask = CurrentNavigationTask;
                CurrentNavigationTask = tcs.Task;
                await oldTask;

                await PopToRootAsyncInner(animated);
                tcs.SetResult(true);
                return;
            }

            Task result = PopToRootAsyncInner(animated);
            CurrentNavigationTask = result;
            await result;
        }

        /// <summary>
        /// Presents a Page modally.
        /// </summary>
        /// <param name="page">The Page to present modally.</param>
        /// <returns>An awaitable Task, indicating the PushModal completion.</returns>
        public Task PushAsync(Page page)
        {
            return PushAsync(page, true);
        }

        /// <summary>
        /// A task for asynchronously pushing a page onto the navigation stack, with optional animation.
        /// </summary>
        /// <param name="page">The Page to present modally.</param>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>An awaitable Task, indicating the PushModal completion.</returns>
        public async Task PushAsync(Page page, bool animated)
        {
            if (CurrentNavigationTask != null && !CurrentNavigationTask.IsCompleted)
            {
                var tcs = new TaskCompletionSource<bool>();
                Task oldTask = CurrentNavigationTask;
                CurrentNavigationTask = tcs.Task;
                await oldTask;

                await PushAsyncInner(page, animated);
                tcs.SetResult(true);
                return;
            }

            CurrentNavigationTask = PushAsyncInner(page, animated);
            await CurrentNavigationTask;
        }

        /// <summary>
        /// Event that is raised when a page is pushed onto this NavigationPage element.
        /// </summary>
        public event EventHandler<NavigationEventArgs> Pushed;

        /// <summary>
        /// Sets the title that appears on the back button for page.
        /// </summary>
        /// <param name="page">The BindableObject object.</param>
        /// <param name="value">The value to set.</param>
        public static void SetBackButtonTitle(BindableObject page, string value)
        {
            page.SetValue(BackButtonTitleProperty, value);
        }

        /// <summary>
        /// Adds or removes a back button to page, with optional animation.
        /// </summary>
        /// <param name="page">The page object.</param>
        /// <param name="value">The value to set.</param>
        public static void SetHasBackButton(Page page, bool value)
        {
            if (page == null)
                throw new ArgumentNullException("page");
            page.SetValue(HasBackButtonProperty, value);
        }

        /// <summary>
        /// Sets a value that indicates whether or not this NavigationPage element has a navigation bar.
        /// </summary>
        /// <param name="page">The BindableObject object</param>
        /// <param name="value">The value to set</param>
        public static void SetHasNavigationBar(BindableObject page, bool value)
        {
            page.SetValue(HasNavigationBarProperty, value);
        }

        internal static void SetTitleIcon(BindableObject bindable, FileImageSource value)
        {
            bindable.SetValue(TitleIconProperty, value);
        }

        /// <summary>
        /// Event that is raised when the hardware back button is pressed.
        /// </summary>
        /// <returns>true if consumed</returns>
        protected override bool OnBackButtonPressed()
        {
            if (CurrentPage.SendBackButtonPressed())
                return true;

            if (StackDepth > 1)
            {
                SafePop();
                return true;
            }

            return base.OnBackButtonPressed();
        }

        /// <summary>
        /// For internal use
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<NavigationRequestedEventArgs> InsertPageBeforeRequested;

        /// <summary>
        /// For internal use
        /// </summary>
        /// <param name="animated">Whether animate the pop.</param>
        /// <param name="fast"></param>
        /// <returns>A task that represents the asynchronous dismiss operation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<Page> PopAsyncInner(bool animated, bool fast)
        {
            if (StackDepth == 1)
            {
                return null;
            }

            var page = (Page)InternalChildren.Last();

            return await (this as INavigationPageController).RemoveAsyncInner(page, animated, fast);
        }

        async Task<Page> INavigationPageController.RemoveAsyncInner(Page page, bool animated, bool fast)
        {
            if (StackDepth == 1)
            {
                return null;
            }

            var args = new NavigationRequestedEventArgs(page, animated);

            var removed = true;

            EventHandler<NavigationRequestedEventArgs> requestPop = PopRequested;
            if (requestPop != null)
            {
                requestPop(this, args);

                if (args.Task != null && !fast)
                    removed = await args.Task;
            }

            if (!removed && !fast)
                return CurrentPage;

            InternalChildren.Remove(page);

            CurrentPage = (Page)InternalChildren.Last();

            if (Popped != null)
                Popped(this, args);

            return page;
        }

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<NavigationRequestedEventArgs> PopRequested;

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<NavigationRequestedEventArgs> PopToRootRequested;

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<NavigationRequestedEventArgs> PushRequested;

        /// <summary>
        /// For internal use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<NavigationRequestedEventArgs> RemovePageRequested;

        void InsertPageBefore(Page page, Page before)
        {
            if (page == null)
                throw new ArgumentNullException($"{nameof(page)} cannot be null.");

            if (before == null)
                throw new ArgumentNullException($"{nameof(before)} cannot be null.");

            if (!InternalChildren.Contains(before))
                throw new ArgumentException($"{nameof(before)} must be a child of the NavigationPage", nameof(before));

            if (InternalChildren.Contains(page))
                throw new ArgumentException("Cannot insert page which is already in the navigation stack");

            EventHandler<NavigationRequestedEventArgs> handler = InsertPageBeforeRequested;
            handler?.Invoke(this, new NavigationRequestedEventArgs(page, before, false));

            int index = InternalChildren.IndexOf(before);
            InternalChildren.Insert(index, page);

            if (index == 0)
                RootPage = page;

            // Shouldn't be required?
            // if (Width > 0 && Height > 0)
                ForceLayout();
        }

        async Task PopToRootAsyncInner(bool animated)
        {
            if (StackDepth == 1)
                return;

            Element[] childrenToRemove = InternalChildren.Skip(1).ToArray();
            foreach (Element child in childrenToRemove)
                InternalChildren.Remove(child);

            CurrentPage = RootPage;

            var args = new NavigationRequestedEventArgs(RootPage, animated);

            EventHandler<NavigationRequestedEventArgs> requestPopToRoot = PopToRootRequested;
            if (requestPopToRoot != null)
            {
                requestPopToRoot(this, args);

                if (args.Task != null)
                    await args.Task;
            }

            // PoppedToRoot?.Invoke(this, new PoppedToRootEventArgs(RootPage, childrenToRemove.OfType<Page>().ToList()));
        }

        async Task PushAsyncInner(Page page, bool animated)
        {
            if (InternalChildren.Contains(page))
                return;

            PushPage(page);

            var args = new NavigationRequestedEventArgs(page, animated);

            EventHandler<NavigationRequestedEventArgs> requestPush = PushRequested;
            if (requestPush != null)
            {
                requestPush(this, args);

                if (args.Task != null)
                    await args.Task;
            }

            Pushed?.Invoke(this, args);
        }

        void PushPage(Page page)
        {
            InternalChildren.Add(page);

            if (InternalChildren.Count == 1)
                RootPage = page;

            CurrentPage = page;
        }

        void RemovePage(Page page)
        {
            if (page == null)
                throw new ArgumentNullException($"{nameof(page)} cannot be null.");

            if (page == CurrentPage && CurrentPage == RootPage)
                throw new InvalidOperationException("Cannot remove root page when it is also the currently displayed page.");
            if (page == CurrentPage)
            {
                // Log.Warning("NavigationPage", "RemovePage called for CurrentPage object. This can result in undesired behavior, consider calling PopAsync instead.");
                PopAsync();
                return;
            }

            if (!InternalChildren.Contains(page))
                throw new ArgumentException("Page to remove must be contained on this Navigation Page");

            EventHandler<NavigationRequestedEventArgs> handler = RemovePageRequested;
            handler?.Invoke(this, new NavigationRequestedEventArgs(page, true));

            InternalChildren.Remove(page);
            if (RootPage == page)
                RootPage = (Page)InternalChildren.First();
        }

        void SafePop()
        {
            PopAsync(true).ContinueWith(t =>
            {
                if (t.IsFaulted)
                    throw t.Exception;
            });
        }

        class NavigationImpl : NavigationProxy
        {
            // readonly Lazy<ReadOnlyCastingList<Page, Element>> _castingList;

            public NavigationImpl(NavigationPage owner)
            {
                Owner = owner;
                // _castingList = new Lazy<ReadOnlyCastingList<Page, Element>>(() => new ReadOnlyCastingList<Page, Element>(Owner.InternalChildren));
            }

            NavigationPage Owner { get; }

            protected override IReadOnlyList<Page> GetNavigationStack()
            {
                // return _castingList.Value;
                return null;
            }

            protected override void OnInsertPageBefore(Page page, Page before)
            {
                Owner.InsertPageBefore(page, before);
            }

            protected override Task<Page> OnPopAsync(bool animated)
            {
                return Owner.PopAsync(animated);
            }

            protected override Task OnPopToRootAsync(bool animated)
            {
                return Owner.PopToRootAsync(animated);
            }

            protected override Task OnPushAsync(Page root, bool animated)
            {
                return Owner.PushAsync(root, animated);
            }

            protected override void OnRemovePage(Page page)
            {
                Owner.RemovePage(page);
            }
        }

        readonly Lazy<PlatformConfigurationRegistry<NavigationPage>> _platformConfigurationRegistry;

        /// <summary>
        /// Returns the platform-specific instance of this NavigationPage, on which a platform-specific method may be called.
        /// </summary>
        /// <typeparam name="T">The platform for which to return an instance.</typeparam>
        /// <returns>The platform-specific instance of this NavigationPage</returns>
        public new IPlatformElementConfiguration<T, NavigationPage> On<T>() where T : IConfigPlatform
        {
            return _platformConfigurationRegistry.Value.On<T>();
        }
    }
}
