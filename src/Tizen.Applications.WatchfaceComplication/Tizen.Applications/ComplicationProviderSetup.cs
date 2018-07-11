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
        /// Checks the provider setup application is launched by editor.
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>true if the provider is launched by touch launch operation, ortherwise false</returns>
        /// <since_tizen> 5 </since_tizen>
        public static bool IsEditing(ReceivedAppControl recvAppCtrl)
        {
            return false;
        }

        /// <summary>
        /// Sends setup information to the editor.
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <param name="context">The setup information.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public static void ReplyToEditor(ReceivedAppControl recvAppCtrl, Bundle context)
        {
        }

        /// <summary>
        /// Gets complication's setup context.
        /// </summary>
        /// <param name="recvAppCtrl">The appcontrol received event args.</param>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>Setup context</returns>
        /// <since_tizen> 5 </since_tizen>
        public static Bundle GetContext(ReceivedAppControl recvAppCtrl)
        {
            return null;
        }
    }
}
