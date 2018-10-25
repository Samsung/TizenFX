using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the ComplicationProviderSetup class for the complication provider setup application.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public static class ComplicationProviderSetup
    {
        /// <summary>
        /// Gets the received appctrl containing inforamtion about edit.
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <returns>The boolean value.</returns>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     if (ComplicationProviderSetup.IsEditing(e.ReceivedAppControl))
        ///     {
        ///         // do something
        ///     }
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Event target complication type</returns>
        /// <since_tizen> 5 </since_tizen>
        public static bool IsEditing(ReceivedAppControl recvAppCtrl)
        {
            bool isEditing = false;
            ComplicationError err = Interop.WatchfaceComplication.IsSetupEditing(recvAppCtrl.SafeAppControlHandle, out isEditing);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to check editing");
            return isEditing;
        }

        /// <summary>
        /// Replies the setup context to the editor
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <param name="context">The context created by complication setup app.</param>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     if (ComplicationProviderSetup.IsEditing(e.ReceivedAppControl))
        ///     {
        ///         Bundle context = ComplicationProviderSetup.GetContext(e.ReceivedAppControl);
        ///         context.AddItem("TEST_KEY", "NEW CONTEXT");
        ///         ComplicationProviderSetup.ReplyToEditor(e.ReceivedAppControl, context);
        ///     }
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Event target complication type</returns>
        /// <since_tizen> 5 </since_tizen>
        public static void ReplyToEditor(ReceivedAppControl recvAppCtrl, Bundle context)
        {
            ComplicationError err = Interop.WatchfaceComplication.SetupReplyToEditor(recvAppCtrl.SafeAppControlHandle, context.SafeBundleHandle);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to check editing");
        }

        /// <summary>
        /// Gets complication's setup context.
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <returns>The setup context.</returns>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     if (ComplicationProviderSetup.IsEditing(e.ReceivedAppControl))
        ///     {
        ///         Bundle context = ComplicationProviderSetup.GetContext(e.ReceivedAppControl);
        ///         context.AddItem("TEST_KEY", "NEW CONTEXT");
        ///         ComplicationProviderSetup.ReplyToEditor(e.ReceivedAppControl, context);
        ///     }
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>Setup context</returns>
        /// <since_tizen> 5 </since_tizen>
        public static Bundle GetContext(ReceivedAppControl recvAppCtrl)
        {
            SafeBundleHandle context;
            ComplicationError err = Interop.WatchfaceComplication.GetSetupContext(recvAppCtrl.SafeAppControlHandle, out context);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to check editing");
            if (context == null)
                return null;

            return new Bundle(context);
        }
    }
}
