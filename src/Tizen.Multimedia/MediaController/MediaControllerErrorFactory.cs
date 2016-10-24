/// Media Controller Error factory
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

namespace Tizen.Multimedia.MediaController
{
	internal enum MediaControllerError
	{
		None = ErrorCode.None,
		InvalidParameter = ErrorCode.InvalidParameter,
		OutOfMemory = ErrorCode.OutOfMemory,
		InvalidOperation = ErrorCode.InvalidOperation,
		NoSpaceOnDevice = ErrorCode.FileNoSpaceOnDevice,
		PermissionDenied = ErrorCode.PermissionDenied,
	};
	internal static class MediaControllerErrorFactory
	{
		internal static void ThrowException(MediaControllerError errorCode, string errorMessage = null, string paramName = null)
		{
			MediaControllerError err = errorCode;
			if(string.IsNullOrEmpty(errorMessage))
			{
				errorMessage = err.ToString();
			}
			switch(errorCode)
			{
			case MediaControllerError.InvalidParameter:
				throw new ArgumentException(errorMessage, paramName);

			case MediaControllerError.OutOfMemory:
			case MediaControllerError.InvalidOperation:
			case MediaControllerError.NoSpaceOnDevice:
			case MediaControllerError.PermissionDenied:
				throw new InvalidOperationException(errorMessage);
			}
		}
	}
}

