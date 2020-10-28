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
using System.ComponentModel;

namespace Tizen.Multimedia
{
    public partial class Player
    {
        private static List<Action<Player, int, string>> _errorHandlers;

        private static object _errorHandlerLock = new object();

        /// <summary>
        /// This method supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static void AddErrorHandler(Action<Player, int, string> errorHandler)
        {
            if (errorHandler == null)
            {
                throw new ArgumentNullException(nameof(errorHandler));
            }

            lock (_errorHandlerLock)
            {
                if (_errorHandlers == null)
                {
                    _errorHandlers = new List<Action<Player, int, string>>();
                }

                _errorHandlers.Add(errorHandler);
            }
        }

        /// <summary>
        /// This method supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static void RemoveErrorHandler(Action<Player, int, string> errorHandler)
        {
            lock (_errorHandlerLock)
            {
                _errorHandlers?.Remove(errorHandler);
            }
        }

        internal static void NotifyError(Player player, int errorCode, string message)
        {
            if (_errorHandlers == null)
            {
                return;
            }

            lock (_errorHandlerLock)
            {
                foreach (var handler in _errorHandlers)
                {
                    handler(player, errorCode, message);
                }
            }
        }
    }
}