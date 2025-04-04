using System;
using System.ComponentModel;

namespace Tizen.Applications
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class WatchdogTimer
    {
        /// <summary>
        /// Sends a disable request to deactivate the watchdog timer.
        /// </summary>
        /// <remarks>
        /// After this function is called, the system doesn't detect a timeout error.
        /// If the running application has to process a lot of operations, the application should disable or reset the watchdog timer.
        /// Trying to disable watchdog timer already disabled will generate error.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Invalid watchdog context</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void Disable()
        {
            Interop.AppCommon.AppCommonErrorCode err = Interop.AppCommon.AppWatchdogTimerDisable();
            if (err == Interop.AppCommon.AppCommonErrorCode.InvalidContext)
            {
                throw new InvalidOperationException("Invalid watchdog context");
            }
            return;
        }

        /// <summary>
        /// Sends an enable request to activate the watchdog timer.
        /// </summary>
        /// <remarks>
        /// After this function is called, the system detects a timeout error.
        /// If, due to a program error as ANR (Application Not Responding), the system fails to reset the watchdog,
        /// the timer will elapse and generate a signal to terminate the running application.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Invalid watchdog context</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void Enable()
        {
            Interop.AppCommon.AppCommonErrorCode err = Interop.AppCommon.AppWatchdogTimerEnable();
            if (err == Interop.AppCommon.AppCommonErrorCode.InvalidContext)
            {
                throw new InvalidOperationException("Invalid watchdog context");
            }
            return;
        }

        /// <summary>
        /// Sends a kick request to the watchdog timer.
        /// </summary>
        /// <exception cref="InvalidOperationException">Invalid watchdog context</exception>
        /// <since_tizen> 10 </since_tizen>
        public static void Kick()
        {
            Interop.AppCommon.AppCommonErrorCode err = Interop.AppCommon.AppWatchdogTimerKick();
            if (err == Interop.AppCommon.AppCommonErrorCode.InvalidContext)
            {
                throw new InvalidOperationException("Invalid watchdog context");
            }
            return;
        }
    }
}
