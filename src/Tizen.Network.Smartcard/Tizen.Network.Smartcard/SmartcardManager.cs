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

namespace Tizen.Network.Smartcard
{
    /// <summary>
    /// The class for Smartcard management. It allows applications to use the Smartcard service.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/secureelement</privilege>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    static public class SmartcardManager
    {
        /// <summary>
        /// Gets the list of available secure element readers.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>List of SmartcardReader objects.</returns>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        static public IEnumerable<SmartcardReader> GetReaders()
        {
            try
            {
                return SmartcardManagerImpl.Instance.GetReaders();
            }
            catch (TypeInitializationException e)
            {
                throw e.InnerException;
            }
        }
    }
}
