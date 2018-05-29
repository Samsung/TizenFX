/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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


using static Interop.InputMethodManager;

namespace Tizen.Uix.InputMethodManager
{
    /// <summary>
    /// This class provides the function for launching the input method editor (IME) list and selector settings. A user can manage the installed IMEs in the system.
    /// The input method editor (IME) is an input panel that lets users provide an input and the platform to receive the text data entered.
    /// The manager is a module for managing the installed IMEs.
    /// IME developers can use this module to open the installed IME list or the selector menu after their IME installation, and then guide to select the installed IME.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class Manager
    {
        /// <summary>
        /// Requests to open the installed IME list menu.
        /// This API provides the installed IME list menu for IME developers who might want to open it to enable their IME.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/imemanager
        /// </privilege>
        /// <exception cref="T:System.InvalidOperationException">
        /// This exception can occur if:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public static void ShowIMEList()
        {
            ErrorCode error = ImeManagerShowImeList();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "ShowIMEList Failed with error " + error);
                throw InputMethodManagerExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Requests to open the IME selector menu.
        /// This API provides the IME selector menu for the IME or other application developers who might want to change the default IME.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/imemanager
        /// </privilege>
        /// <exception cref="T:System.InvalidOperationException">
        /// This exception can occur if:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public static void ShowIMESelector()
        {
            ErrorCode error = ImeManagerShowImeSelector();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "ShowIMESelector Failed with error " + error);
                throw InputMethodManagerExceptionFactory.CreateException(error);
            }
        }

        /// <summary>
        /// Checks if the specific IME is enabled or disabled in the system keyboard setting.
        /// The IME developers can use this property to check if their IME is enabled or not.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/imemanager
        /// </privilege>
        /// <param name="appId">The application ID of the IME.</param>
        /// <returns>The On (enabled) and Off (disabled) state of the IME.</returns>
        /// <exception cref="T:System.ArgumentException">
        /// This exception can occur if an invalid parameter is provided.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// This exception can occur if:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool IsIMEEnabled(string appId)
        {
            bool isIMEEnabled;
            ErrorCode error = ImeManagerIsImeEnabled(appId, out isIMEEnabled);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "IsIMEEnabled Failed with error " + error);
                throw InputMethodManagerExceptionFactory.CreateException(error);
            }

            return isIMEEnabled;
        }

        /// <summary>
        /// Checks which IME is the current activated (selected) IME.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/imemanager
        /// </privilege>
        /// <returns>
        /// The current activated (selected) IME.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">
        /// This exception can occur if:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public static string GetActiveIME()
        {
            string activeIME;
            ErrorCode error = ImeManagerGetActiveIme(out activeIME);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetActiveIME Failed with error " + error);
                throw InputMethodManagerExceptionFactory.CreateException(error);
            }

            return activeIME;
        }

        /// <summary>
        /// Gets the number of IMEs that are enabled (usable).
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/imemanager
        /// </privilege>
        /// <returns>
        /// The number of enabled IMEs.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">
        /// This exception can occur if:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public static int GetEnabledIMECount()
        {
            int activeIME = ImeManagerGetEnabledImeCount();
            ErrorCode error = (ErrorCode)Tizen.Internals.Errors.ErrorFacts.GetLastResult();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetEnabledIMECount Failed with error " + error);
                throw InputMethodManagerExceptionFactory.CreateException(error);
            }

            return activeIME;
        }

        /// <summary>
        /// Requests to pre-launch the IME.
        /// The developers can use this function to launch IME in On-demand mode.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/imemanager
        /// </privilege>
        /// <exception cref="InvalidOperationException">
        /// This exception can occur if:
        /// 1) The application does not have the privilege to call this function.
        /// 2) Operation failed.
        /// </exception>
        public static void PrelaunchIME()
        {
            ErrorCode error = ImeManagerPrelaunchIme();
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "PrelaunchIME Failed with error " + error);
                throw InputMethodManagerExceptionFactory.CreateException(error);
            }
        }
    }
}
