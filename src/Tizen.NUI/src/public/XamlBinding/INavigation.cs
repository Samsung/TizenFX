using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Interface abstracting platform-specific navigation.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface INavigation
	{
        /// <summary>
        /// Gets the modal navigation stack.
        /// </summary>
        IReadOnlyList<Page> ModalStack { get; }

        /// <summary>
        /// Gets the stack of pages in the navigation.
        /// </summary>
		IReadOnlyList<Page> NavigationStack { get; }

        /// <summary>
        /// Inserts a page in the navigation stack before an existing page in the stack.
        /// </summary>
        /// <param name="page">The page to add.</param>
        /// <param name="before">The existing page, before which page will be inserted.</param>
		void InsertPageBefore(Page page, Page before);

        /// <summary>
        /// Asynchronously removes the most recent Page from the navigation stack.
        /// </summary>
        /// <returns>The Page that had been at the top of the navigation stack.</returns>
		Task<Page> PopAsync();

        /// <summary>
        /// Asynchronously removes the most recent Page from the navigation stack, with optional animation.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>The Page that had been at the top of the navigation stack.</returns>
		Task<Page> PopAsync(bool animated);

        /// <summary>
        /// Asynchronously dismisses the most recent modally presented Page.
        /// </summary>
        /// <returns>An awaitable instance, indicating the PopModalAsync completion. The Task.Result is the Page that has been popped.</returns>
		Task<Page> PopModalAsync();

        /// <summary>
        /// Asynchronously dismisses the most recent modally presented Page, with optional animation.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>An awaitable, indicating the PopModalAsync completion. The Task.Result is the Page that has been popped.</returns>
		Task<Page> PopModalAsync(bool animated);

        /// <summary>
        /// Pops all but the root Page off the navigation stack.
        /// </summary>
        /// <returns>A task representing the asynchronous dismiss operation.</returns>
		Task PopToRootAsync();

        /// <summary>
        /// Pops all but the root Page off the navigation stack, with optional animation.
        /// </summary>
        /// <param name="animated">Whether to animate the pop.</param>
        /// <returns>A task representing the asynchronous dismiss operation.</returns>
		Task PopToRootAsync(bool animated);

        /// <summary>
        /// Asynchronously adds a Page to the top of the navigation stack.
        /// </summary>
        /// <param name="page">The Page to be pushed on top of the navigation stack.</param>
        /// <returns>A task that represents the asynchronous push operation.</returns>
		Task PushAsync(Page page);

        /// <summary>
        /// Asynchronously adds a Page to the top of the navigation stack, with optional animation.
        /// </summary>
        /// <param name="page">The page to push.</param>
        /// <param name="animated">Whether to animate the push.</param>
        /// <returns>A task that represents the asynchronous push operation.</returns>
		Task PushAsync(Page page, bool animated);

        /// <summary>
        /// Presents a Page modally.
        /// </summary>
        /// <param name="page">The Page to present modally.</param>
        /// <returns>An awaitable Task, indicating the PushModal completion.</returns>
		Task PushModalAsync(Page page);

        /// <summary>
        /// Presents a Page modally, with optional animation.
        /// </summary>
        /// <param name="page">The page to push.</param>
        /// <param name="animated">Whether to animate the push.</param>
        /// <returns>An awaitable Task, indicating the PushModal completion.</returns>
		Task PushModalAsync(Page page, bool animated);

        /// <summary>
        /// Removes the specified page from the navigation stack.
        /// </summary>
        /// <param name="page">The page to remove.</param>
		void RemovePage(Page page);
	}
}