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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.Network.Mtp
{
    /// <summary>
    /// A class for MTP management. It allows applications to use MTP service.
    /// </summary>
    /// <remarks>
    /// http://tizen.org/privilege/mediastorage is needed if input or output path are relevant to media storage.
    /// http://tizen.org/privilege/externalstorage is needed if input or output path are relevant to external storage.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    static public class MtpManager
    {
        /// <summary>
        /// Gets the list of MTP devices.
        /// </summary>
        /// <returns>List of MtpDevice objects.</returns>
        /// <feature>http://tizen.org/feature/network.mtp</feature>
        /// <exception cref="NotSupportedException">Thrown when Mtp is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <since_tizen> 4 </since_tizen>
        static public IEnumerable<MtpDevice> GetDevices()
        {
            try
            {
                return MtpManagerImpl.Instance.GetDevices();
            }
            catch (TypeInitializationException e)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// MtpStateChanged is raised when the Mtp device state is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        static public event EventHandler<MtpStateChangedEventArgs> MtpStateChanged
        {
            add
            {
                try
                {
                    MtpManagerImpl.Instance.MtpStateChanged += value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
            remove
            {
                try
                {
                    MtpManagerImpl.Instance.MtpStateChanged -= value;
                }
                catch (TypeInitializationException e)
                {
                    throw e.InnerException;
                }
            }
        }
    }
}
