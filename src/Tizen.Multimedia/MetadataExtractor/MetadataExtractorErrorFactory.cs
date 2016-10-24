/// Metadata Extractor Error factory
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.using System;
///

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
			MetadataExtractorError err = (MetadataExtractorError)errorCode;
			if(string.IsNullOrEmpty(errorMessage))
			{
				errorMessage = err.ToString();
			}
			switch ((MetadataExtractorError)errorCode)
			{
				case MetadataExtractorError.InvalidParameter:
					throw new ArgumentException(errorMessage, paramName);

				case MetadataExtractorError.OutOfMemory:
				case MetadataExtractorError.FileExists:
				case MetadataExtractorError.PermissionDenied:
				case MetadataExtractorError.MetadataExtractorErrorOperationFailed:
					throw new InvalidOperationException(errorMessage);
			}
		}
	}
}

