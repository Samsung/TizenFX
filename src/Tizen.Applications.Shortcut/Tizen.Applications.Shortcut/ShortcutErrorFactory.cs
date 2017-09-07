/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Tizen.Applications.Shortcut
{
    using System;

    internal static class ShortcutErrorFactory
    {
        private const string LogTag = "Tizen.Applications.Shortcut";

        internal static Exception GetException(Interop.Shortcut.ErrorCode err, string msg)
        {
            switch (err)
            {
                case Interop.Shortcut.ErrorCode.InvalidParameter:
                    return new ArgumentException(err + " error occurred.");
                case Interop.Shortcut.ErrorCode.PermissionDenied:
                    return new UnauthorizedAccessException(err + " Permission denied (http://tizen.org/privilege/shortcut)");
                case Interop.Shortcut.ErrorCode.NotSupported:
                    return new NotSupportedException(err + " Not Supported (http://tizen.org/feature/shortcut)");
                case Interop.Shortcut.ErrorCode.OutOfMemory:
                    return new OutOfMemoryException(err + " error occurred.");
                default:
                    Log.Error(LogTag, msg);
                    return new InvalidOperationException(err + " error occurred.");
            }
        }
    }
}
