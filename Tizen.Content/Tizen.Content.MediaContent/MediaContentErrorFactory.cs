using System;

namespace Tizen.Content.MediaContent
{
    internal class MediaContentErrorFactory
    {
        internal const string LogTag = "Tizen.Content.MediaContent";

        internal static Exception CreateException(MediaContentError err, string msg)
        {
            Exception exp;
            switch (err)
            {
                case MediaContentError.InavlidParameter:
                    {
                        exp = new ArgumentException("Invalid Parameters Provided");
                        break;
                    }
                case MediaContentError.OotOfMemory:
                    {
                        exp = new InvalidOperationException("Out Of Memory");
                        break;
                    }
                case MediaContentError.InavlidOperation:
                    {
                        exp = new InvalidOperationException("Inavlid operation");
                        break;
                    }
                case MediaContentError.NoSpaceOnDevice:
                    {
                        exp = new InvalidOperationException("No Space Left on Device");
                        break;
                    }
                case MediaContentError.PermissionDenied:
                    {
                        exp = new InvalidOperationException("Permission Denied");
                        break;
                    }
                case MediaContentError.DBFailed:
                    {
                        exp = new InvalidOperationException("DataBase Failed");
                        break;
                    }
                case MediaContentError.DBBusy:
                    {
                        exp = new InvalidOperationException("DataBase Busy");
                        break;
                    }
                case MediaContentError.NetworkError:
                    {
                        exp = new InvalidOperationException("Network Error");
                        break;
                    }
                case MediaContentError.UnsupportedContent:
                    {
                        exp = new ArgumentException("Content Not Supported");
                        break;
                    }
                default:
                    {
                        exp = new InvalidOperationException("");
                        break;
                    }
            }
            return exp;
        }
    }
}
