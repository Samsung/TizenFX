/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the complication setup for a setup application.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class ComplicationProviderSetup
    {
        /// <summary>
        /// Gets the received appcontrol containing information about edit.
        /// </summary>
        /// <param name="recvAppCtrl">The received appcontrol.</param>
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
        /// <returns>The boolean value.</returns>
        /// <since_tizen> 6 </since_tizen>
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
        /// <param name="recvAppCtrl">The received appcontrol.</param>
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
        /// <since_tizen> 6 </since_tizen>
        public static void ReplyToEditor(ReceivedAppControl recvAppCtrl, Bundle context)
        {
            ComplicationError err = Interop.WatchfaceComplication.SetupReplyToEditor(recvAppCtrl.SafeAppControlHandle, context.SafeBundleHandle);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to check editing");
        }

        /// <summary>
        /// Gets complication's setup context.
        /// </summary>
        /// <param name="recvAppCtrl">The received appcontrol.</param>
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
        /// <returns>The setup context.</returns>
        /// <since_tizen> 6 </since_tizen>
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
