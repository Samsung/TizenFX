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

using System.Diagnostics;

namespace Tizen.Multimedia
{
    internal class MultimediaDebug
    {
        [Conditional("DEBUG")]
        internal static void AssertNoError(int errorCode)
        {
            Debug.Assert(errorCode == (int)Internals.Errors.ErrorCode.None,
                $"The API is supposed not to return an error! But it returns error({ errorCode }).",
                "Implementation of core may have been changed, modify the call to throw if the return code is not ok.");
        }
    }
}
