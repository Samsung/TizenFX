using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.XamlBinding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.XamlBinding
{
    internal interface INavigationPageController
    {
        Task<Page> RemoveAsyncInner(Page page, bool animated, bool fast);

        Page Peek(int depth = 0);

        IEnumerable<Page> Pages { get; }

        int StackDepth { get; }

        Task<Page> PopAsyncInner(bool animated, bool fast = false);

        event EventHandler<NavigationRequestedEventArgs> InsertPageBeforeRequested;

        event EventHandler<NavigationRequestedEventArgs> PopRequested;

        event EventHandler<NavigationRequestedEventArgs> PopToRootRequested;

        event EventHandler<NavigationRequestedEventArgs> PushRequested;

        event EventHandler<NavigationRequestedEventArgs> RemovePageRequested;
    }
}