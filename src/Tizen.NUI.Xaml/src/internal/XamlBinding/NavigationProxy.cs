using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// For internal use.
    /// </summary>
    internal class NavigationProxy : INavigation
    {
        INavigation _inner;
        Lazy<List<Page>> _modalStack = new Lazy<List<Page>>(() => new List<Page>());

        Lazy<List<Page>> _pushStack = new Lazy<List<Page>>(() => new List<Page>());

        internal INavigation Inner
        {
            get { return _inner; }
            set
            {
                if (_inner == value)
                    return;
                _inner = value;
                // reverse so that things go into the new stack in the same order
                // null out to release memory that will likely never be needed again

                if (ReferenceEquals(_inner, null))
                {
                    _pushStack = new Lazy<List<Page>>(() => new List<Page>());
                    _modalStack = new Lazy<List<Page>>(() => new List<Page>());
                }
                else
                {
                    if (_pushStack != null && _pushStack.IsValueCreated)
                    {
                        foreach (Page page in _pushStack.Value)
                        {
                            _inner.PushAsync(page);
                        }
                    }

                    if (_modalStack != null && _modalStack.IsValueCreated)
                    {
                        foreach (Page page in _modalStack.Value)
                        {
                            _inner.PushModalAsync(page);
                        }
                    }

                    _pushStack = null;
                    _modalStack = null;
                }
            }
        }

        /// <summary>
        /// Inserts a page in the navigation stack before an existing page in the stack.
        /// </summary>
        /// <param name="page">The page to add.</param>
        /// <param name="before">The existing page, before which page will be inserted.</param>
        public void InsertPageBefore(Page page, Page before)
        {
            OnInsertPageBefore(page, before);
        }

        /// <summary>
        /// Gets the modal navigation stack.
        /// </summary>
        public IReadOnlyList<Page> ModalStack
        {
            get { return GetModalStack(); }
        }

        /// <summary>
        /// Gets the stack of pages in the navigation.
        /// </summary>
        public IReadOnlyList<Page> NavigationStack
        {
            get { return GetNavigationStack(); }
        }

        /// <summary>
        /// Asynchronously removes the most recent Page from the navigation stack.
        /// </summary>
        /// <returns>The Page that had been at the top of the navigation stack.</returns>
        public Task<Page> PopAsync()
        {
            return OnPopAsync(true);
        }

        /// <summary>
        /// Asynchronously removes the top Page from the navigation stack, with optional animation.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>The Page that had been at the top of the navigation stack.</returns>
        public Task<Page> PopAsync(bool animated)
        {
            return OnPopAsync(animated);
        }

        /// <summary>
        /// Asynchronously dismisses the most recent modally presented Page.
        /// </summary>
        /// <returns>An awaitable instance, indicating the PopModalAsync completion. The Task.Result is the Page that has been popped.</returns>
        public Task<Page> PopModalAsync()
        {
            return OnPopModal(true);
        }

        /// <summary>
        /// Asynchronously removes the top Page from the navigation stack, with optional animation.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>The Page that had been at the top of the navigation stack.</returns>
        public Task<Page> PopModalAsync(bool animated)
        {
            return OnPopModal(animated);
        }

        /// <summary>
        /// Pops all but the root Page off the navigation stack.
        /// </summary>
        /// <returns>A task representing the asynchronous dismiss operation.</returns>
        public Task PopToRootAsync()
        {
            return OnPopToRootAsync(true);
        }

        /// <summary>
        /// Pops all but the root Page off the navigation stack, with optional animation.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>A task representing the asynchronous dismiss operation.</returns>
        public Task PopToRootAsync(bool animated)
        {
            return OnPopToRootAsync(animated);
        }

        /// <summary>
        /// Asynchronously adds a Page to the top of the navigation stack.
        /// </summary>
        /// <param name="root">The Page to be pushed on top of the navigation stack.</param>
        /// <returns>A task that represents the asynchronous push operation.</returns>
        public Task PushAsync(Page root)
        {
            return PushAsync(root, true);
        }

        /// <summary>
        /// Asynchronously adds a Page to the top of the navigation stack, with optional animation.
        /// </summary>
        /// <param name="root">The page to push.</param>
        /// <param name="animated">Whether to animate the push.</param>
        /// <returns>A task that represents the asynchronous push operation.</returns>
        public Task PushAsync(Page root, bool animated)
        {
            if (root.RealParent != null)
                throw new InvalidOperationException("Page must not already have a parent.");
            return OnPushAsync(root, animated);
        }

        /// <summary>
        /// Presents a Page modally.
        /// </summary>
        /// <param name="modal">The Page to present modally.</param>
        /// <returns>An awaitable Task, indicating the PushModal completion.</returns>
        public Task PushModalAsync(Page modal)
        {
            return PushModalAsync(modal, true);
        }

        /// <summary>
        /// Presents a Page modally, with optional animation.
        /// </summary>
        /// <param name="modal">The page to push.</param>
        /// <param name="animated">Whether to animate the push.</param>
        /// <returns>An awaitable Task, indicating the PushModal completion.</returns>
        public Task PushModalAsync(Page modal, bool animated)
        {
            if (modal.RealParent != null)
                throw new InvalidOperationException("Page must not already have a parent.");
            return OnPushModal(modal, animated);
        }

        /// <summary>
        /// Removes the specified page from the navigation stack.
        /// </summary>
        /// <param name="page">The page to remove.</param>
        public void RemovePage(Page page)
        {
            OnRemovePage(page);
        }

        /// <summary>
        /// For internal use. Returns the modal navigation stack.
        /// </summary>
        /// <returns>The modal navigation stack.</returns>
        protected virtual IReadOnlyList<Page> GetModalStack()
        {
            INavigation currentInner = Inner;
            return currentInner == null ? _modalStack.Value : currentInner.ModalStack;
        }

        /// <summary>
        /// For internal use. Returns the stack of pages in the navigation.
        /// </summary>
        /// <returns>The stack of pages in the navigation.</returns>
        protected virtual IReadOnlyList<Page> GetNavigationStack()
        {
            INavigation currentInner = Inner;
            return currentInner == null ? _pushStack.Value : currentInner.NavigationStack;
        }

        /// <summary>
        /// The method called when insert a page in the navigation stack before an existing page in the stack.
        /// </summary>
        /// <param name="page">The page to add.</param>
        /// <param name="before">The existing page, before which page will be inserted.</param>
        protected virtual void OnInsertPageBefore(Page page, Page before)
        {
            INavigation currentInner = Inner;
            if (currentInner == null)
            {
                int index = _pushStack.Value.IndexOf(before);
                if (index == -1)
                    throw new ArgumentException("before must be in the pushed stack of the current context");
                _pushStack.Value.Insert(index, page);
            }
            else
            {
                currentInner.InsertPageBefore(page, before);
            }
        }

        /// <summary>
        /// This method calls when removes the top Page from the navigation stack
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns></returns>
        protected virtual Task<Page> OnPopAsync(bool animated)
        {
            INavigation inner = Inner;
            return inner == null ? Task.FromResult(Pop()) : inner.PopAsync(animated);
        }

        /// <summary>
        /// This method calls when removes the top Page from the navigation stack
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>An awaitable instance, indicating the PopModalAsync completion</returns>
        protected virtual Task<Page> OnPopModal(bool animated)
        {
            INavigation innerNav = Inner;
            return innerNav == null ? Task.FromResult(PopModal()) : innerNav.PopModalAsync(animated);
        }

        /// <summary>
        /// This method calls when Pops all but the root Page off the navigation stack.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>A task representing the asynchronous dismiss operation.</returns>
        protected virtual Task OnPopToRootAsync(bool animated)
        {
            INavigation currentInner = Inner;
            if (currentInner == null)
            {
                Page root = _pushStack.Value.Last();
                _pushStack.Value.Clear();
                _pushStack.Value.Add(root);
                return Task.FromResult(root);
            }
            return currentInner.PopToRootAsync(animated);
        }

        /// <summary>
        /// This method calls when adds a Page to the top of the navigation stack, with optional animation.
        /// </summary>
        /// <param name="page">The page to add</param>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>A task that represents the asynchronous push operation.</returns>
        protected virtual Task OnPushAsync(Page page, bool animated)
        {
            INavigation currentInner = Inner;
            if (currentInner == null)
            {
                _pushStack.Value.Add(page);
                return Task.FromResult(page);
            }
            return currentInner.PushAsync(page, animated);
        }

        /// <summary>
        /// This method calls when Presents a Page modally, with optional animation.
        /// </summary>
        /// <param name="modal">The page to push.</param>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>An awaitable Task, indicating the PushModal completion.</returns>
        protected virtual Task OnPushModal(Page modal, bool animated)
        {
            INavigation currentInner = Inner;
            if (currentInner == null)
            {
                _modalStack.Value.Add(modal);
                return Task.FromResult<object>(null);
            }
            return currentInner.PushModalAsync(modal, animated);
        }

        /// <summary>
        /// This method calls when Removes the specified page from the navigation stack.
        /// </summary>
        /// <param name="page">The page to add.</param>
        protected virtual void OnRemovePage(Page page)
        {
            INavigation currentInner = Inner;
            if (currentInner == null)
            {
                _pushStack.Value.Remove(page);
            }
            else
            {
                currentInner.RemovePage(page);
            }
        }

        Page Pop()
        {
            List<Page> list = _pushStack.Value;
            Page result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }

        Page PopModal()
        {
            List<Page> list = _modalStack.Value;
            Page result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }
    }
}