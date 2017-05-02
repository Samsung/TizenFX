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
    static public class MtpManager
    {
        /// <summary>
        /// Gets the list of available Secure Element readers.
        /// </summary>
        /// <returns>List of SmartcardReader objects.</returns>
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
        /// The Activation changed event.
        /// </summary>
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
