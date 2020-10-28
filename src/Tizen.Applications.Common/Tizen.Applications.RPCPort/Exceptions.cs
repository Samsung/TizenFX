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

namespace Tizen.Applications.RPCPort
{
    /// <summary>
    /// Exception class for invalid IO
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class InvalidIOException : InvalidOperationException { }

    /// <summary>
    /// Exception class for invalid ID
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class InvalidIDException : InvalidOperationException { }

    /// <summary>
    /// Exception class for permission denied
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class PermissionDeniedException : InvalidOperationException { }

    /// <summary>
    /// Exception class for invalid protocol
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class InvalidProtocolException : InvalidOperationException { }

    /// <summary>
    /// Exception class which will be thrown when not connected socket is used
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class NotConnectedSocketException : InvalidOperationException { }

    /// <summary>
    /// Exception class which will be thrown when invalid callback object is used
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class InvalidCallbackException : InvalidOperationException { }
}
