using System;
using Tizen;

namespace Tizen.Content.MediaContent
{
    internal class MediaContentErrorFactory
    {
        internal const string LogTag = "Tizen.Content.MediaContent";

        internal static Exception CreateException(MediaContentError err, string msg)
        {
            Log.Info(Globals.LogTag, "Got Error " + err + " throwing Exception with msg " + msg);
            Exception exp;
            switch (err)
            {
                case MediaContentError.InvalidParameter:
                    {
                        exp = new ArgumentException(msg + " Invalid Parameters Provided");
                        break;
                    }
                case MediaContentError.OutOfMemory:
                    {
                        exp = new InvalidOperationException(msg + " Out Of Memory");
                        break;
                    }
                case MediaContentError.InvalidOperation:
                    {
                        exp = new InvalidOperationException(msg + " Inavlid operation");
                        break;
                    }
                case MediaContentError.NoSpaceOnDevice:
                    {
                        exp = new InvalidOperationException(msg + " No Space Left on Device");
                        break;
                    }
                case MediaContentError.PermissionDenied:
                    {
                        exp = new InvalidOperationException(msg + " Permission Denied");
                        break;
                    }
                case MediaContentError.DBFailed:
                    {
                        exp = new InvalidOperationException(msg + " DataBase Failed");
                        break;
                    }
                case MediaContentError.DBBusy:
                    {
                        exp = new InvalidOperationException(msg + " DataBase Busy");
                        break;
                    }
                case MediaContentError.NetworkError:
                    {
                        exp = new InvalidOperationException(msg + " Network Error");
                        break;
                    }
                case MediaContentError.UnsupportedContent:
                    {
                        exp = new ArgumentException(msg + " Content Not Supported");
                        break;
                    }
                default:
                    {
                        exp = new InvalidOperationException(msg);
                        break;
                    }
            }
            return exp;
        }
    }
}
