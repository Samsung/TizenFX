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
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
	/// <summary>
	/// Enumeration for metadata extractor's error codes.
	/// </summary>
	internal enum MetadataExtractorError
	{
		None = ErrorCode.None,						  // Success
		InvalidParameter = ErrorCode.InvalidParameter,  // Invalid parameter
		OutOfMemory = ErrorCode.OutOfMemory,			// Out of memory
		FileExists = ErrorCode.FileExists,			  // File does not exist
		PermissionDenied = ErrorCode.PermissionDenied,  // Permission deny
		TizenMetadataExtractorError = -0x01930000,
		MetadataExtractorErrorOperationFailed = TizenMetadataExtractorError | 0x01  // Invalid operation
	};

	internal static class MetadataExtractorErrorFactory
	{
		internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
		{
			switch ((MetadataExtractorError)errorCode)
			{
				case MetadataExtractorError.InvalidParameter:
					throw new ArgumentException("[" + errorCode.ToString() + "]" + errorMessage, paramName);

				case MetadataExtractorError.OutOfMemory:
				case MetadataExtractorError.FileExists:
				case MetadataExtractorError.PermissionDenied:
				case MetadataExtractorError.MetadataExtractorErrorOperationFailed:
					throw new InvalidOperationException("[" + errorCode.ToString() + "]" + errorMessage);
			}
		}
	}
}

