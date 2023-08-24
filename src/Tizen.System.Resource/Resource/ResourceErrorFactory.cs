/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;

namespace Tizen.System
{
	internal enum ResourceError
	{
		None             = ErrorCode.None,
		NotSupported     = ErrorCode.NotSupported,
		InvalidParameter = ErrorCode.InvalidParameter,
		PermissionDenied = ErrorCode.PermissionDenied,
		Io               = ErrorCode.IoError,
		OutOfMemory      = ErrorCode.OutOfMemory,
		NoSuchFile       = ErrorCode.NoSuchFile
	}

	internal static class ResourceErrorFactory
	{
		internal const string LogTag = "Tizen.System.Resource";

		internal static void ThrowException(ResourceError err)
		{
			ResourceError error = (ResourceError)err;
			if (error == ResourceError.NotSupported)
			{
				throw new NotSupportedException("Not supported");
			}
			else if (error == ResourceError.InvalidParameter)
			{
				throw new ArgumentException("Invalid paramter");
			}
			else if (error == ResourceError.PermissionDenied)
			{
				throw new UnauthorizedAccessException("Permission denied");
			}
			else if (error == ResourceError.Io)
			{
				throw new IOException("I/O Error");
			}
			else if (error == ResourceError.OutOfMemory)
			{
				throw new OutOfMemoryException("Out of memory");
			}
			else if (error == ResourceError.NoSuchFile)
			{
				throw new InvalidOperationException("No such file");
			}
		}
	}
}
