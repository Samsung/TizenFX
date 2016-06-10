/// Player Error factory
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
	internal enum PlayerError
	{
		None = ErrorCode.None,
		InvalidParameter = ErrorCode.InvalidParameter,
		OutOfMemory = ErrorCode.OutOfMemory,
		NoSuchFile = ErrorCode.NoSuchFile,
		InvalidOperation = ErrorCode.InvalidOperation,
		NoSpaceOnDevice = ErrorCode.FileNoSpaceOnDevice,
		FeatureNotSupported = ErrorCode.NotSupported,
		PermissionDenied = ErrorCode.PermissionDenied,
		BufferSpace = ErrorCode.BufferSpace,
		TizenPlayerError = -0x01940000,
		PlayerErrorClass = TizenPlayerError | 0x20,
		SeekFailed = PlayerErrorClass | 0x01,
		InvalidState = PlayerErrorClass | 0x02,
		FileNotSupported = PlayerErrorClass | 0x03,
		InvalidUri = PlayerErrorClass | 0x04,
		SoundPolicyError = PlayerErrorClass | 0x05,
		ConnectionFailed = PlayerErrorClass | 0x06,
		VideoCaptureFailed = PlayerErrorClass | 0x07,
		DrmExpired = PlayerErrorClass | 0x08,
		DrmNoLicense = PlayerErrorClass | 0x09,
		DrmFutureUse = PlayerErrorClass | 0x0a,
		DrmNotPermitted = PlayerErrorClass | 0x0b,
		ResourceLimit = PlayerErrorClass | 0x0c,
		ServiceDisconnected = PlayerErrorClass | 0x0d
	};

	internal static class PlayerErrorFactory
	{
		internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
		{
			PlayerError err = (PlayerError) errorCode;
			if(string.IsNullOrEmpty(errorMessage))
			{
				errorMessage = err.ToString();
			}
			switch((PlayerError)errorCode)
			{
			case PlayerError.InvalidParameter:
				throw new ArgumentException(errorMessage, paramName);

			case PlayerError.InvalidState:
			case PlayerError.OutOfMemory:
			case PlayerError.NoSuchFile:
			case PlayerError.InvalidOperation:
			case PlayerError.NoSpaceOnDevice:
			case PlayerError.FeatureNotSupported:
			case PlayerError.SeekFailed:
			case PlayerError.FileNotSupported:
			case PlayerError.InvalidUri:
			case PlayerError.SoundPolicyError:
			case PlayerError.ConnectionFailed:
			case PlayerError.VideoCaptureFailed:
			case PlayerError.DrmExpired:
			case PlayerError.DrmNoLicense:
			case PlayerError.DrmFutureUse:
			case PlayerError.DrmNotPermitted:
			case PlayerError.ResourceLimit:
			case PlayerError.PermissionDenied:
				throw new InvalidOperationException(errorMessage);
			}
		}
	}
}

