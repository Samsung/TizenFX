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

using System;

namespace Tizen.PhonenumberUtils
{
    /// <summary>
    /// The PhonenumberUtils class provides the methods for parsing, formatting, and normalizing the phone numbers.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PhonenumberUtils : IDisposable
    {
        private bool disposed = false;

        /// <summary>
        /// Creates a PhonenumberUtils.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public PhonenumberUtils()
        {
            int ret;

            ret = Interop.PhonenumberUtils.Connect();
            if (ret != (int)PhonenumberUtilsError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect, Error - " + (PhonenumberUtilsError)ret);
                PhonenumberUtilsErrorFactory.ThrowPhonenumberUtilsException(ret);
            }
        }

        /// <summary>
        /// The destructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~PhonenumberUtils()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all the resources used by the PhonenumberUtils.
        /// It should be called after it has finished using the object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            // Free unmanaged objects
            int ret;

            ret = Interop.PhonenumberUtils.Disconnect();
            if (ret != (int)PhonenumberUtilsError.None)
                Log.Error(Globals.LogTag, "Failed to disconnect, Error - " + (PhonenumberUtilsError)ret);

            disposed = true;
        }

        /// <summary>
        /// Gets the location string from the number, region, and language.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="region">The region of number.</param>
        /// <param name="language">The language of location.</param>
        /// <returns>The location string.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the input coordinates are invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 3 </since_tizen>
        public string GetLocationFromNumber(string number, Region region, Language language)
        {
            int ret;
            string result;

            ret = Interop.PhonenumberUtils.GetLocationFromNumber(number, (int)region, (int)language, out result);
            if (ret != (int)PhonenumberUtilsError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get location, Error - " + (PhonenumberUtilsError)ret);
                PhonenumberUtilsErrorFactory.ThrowPhonenumberUtilsException(ret);
            }

            return result;
        }

        /// <summary>
        /// Gets the formatted number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="region">The region of number.</param>
        /// <returns>The formatted number string.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the input coordinates are invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 3 </since_tizen>
        public string GetFormattedNumber(string number, Region region)
        {
            int ret;
            string result;

            ret = Interop.PhonenumberUtils.GetFormmatedNumber(number, (int)region, out result);
            if (ret != (int)PhonenumberUtilsError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get formatted number, Error - " + (PhonenumberUtilsError)ret);
                PhonenumberUtilsErrorFactory.ThrowPhonenumberUtilsException(ret);
            }

            return result;
        }

        /// <summary>
        /// Gets the normalized number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The normalized number.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the input coordinates are invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privileges.</exception>
        /// <remarks>
        /// Normalized number starts with plus('+') and country code, and excludes the separators such as dash or space.
        /// It is a format of the E.164 standard including the country code based on the current network.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public string GetNormalizedNumber(string number)
        {
            int ret;
            string result;

            ret = Interop.PhonenumberUtils.GetNormailizedNumber(number, out result);
            if (ret != (int)PhonenumberUtilsError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get normalized number, Error - " + (PhonenumberUtilsError)ret);
                PhonenumberUtilsErrorFactory.ThrowPhonenumberUtilsException(ret);
            }

            return result;
        }
    }
}
