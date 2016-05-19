using System;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
	internal enum PlayerError
	{
		None = ErrorCode.None,
		InvalidParameter = ErrorCode.InvalidParameter,
		InvalidState,
		OutOfMemory,
		NoSuchFile,
		InvalidOperation,
		NoSpaceOnDevice,
		FeatureNotSupported,
		SeekFailed,
		FileNotSupported,
		InvalidUri,
		SoundPolicyError,
		ConnectionFailed,
		VideoCaptureFailed,
		DrmExpired,
		DrmNoLicense,
		DrmFutureUse,
		DrmNotPermitted,
		ResourceLimit,
		PermissionDenied
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

