/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.IO;

namespace Tizen.MachineLearning.Nnstreamer
{
    internal enum NNStreamerError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        StreamsPipe = Tizen.Internals.Errors.ErrorCode.StreamsPipe,
        TryAgain = Tizen.Internals.Errors.ErrorCode.TryAgain,
    }

    internal class NNStreamerExceptionFactory
    {
        internal static Exception CreateException(NNStreamerError err, string msg)
        {
            Exception exp;

            switch (err)
            {
                case NNStreamerError.InvalidParameter:
                    exp = new ArgumentException(msg);
                    break;

                case NNStreamerError.NotSupported:
                    exp = new NotSupportedException(msg);
                    break;

                case NNStreamerError.StreamsPipe:
                case NNStreamerError.TryAgain:
                    exp = new IOException(msg);
                    break;

                default:
                    exp = new InvalidOperationException(msg);
                    break;
            }
            return exp;
        }
    }
}
