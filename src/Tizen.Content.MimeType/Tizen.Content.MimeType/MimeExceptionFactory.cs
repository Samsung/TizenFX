using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.Content.MimeType
{
    internal class MimeExceptionFactory
    {
        internal static Exception CreateException(MimeUtil.MimeError err)
        {
            Exception exp;
            switch (err)
            {
                case MimeUtil.MimeError.InvalidParameter:
                {
                    exp = new ArgumentException("Invalid Parameters Provided");
                    break;
                }

                case MimeUtil.MimeError.IoError:
                {
                    exp = new SystemException("I/O Error Occured");
                    break;
                }
                case MimeUtil.MimeError.OutOfMemory:
                {
                    exp = new SystemException("Out Of Memory");
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
