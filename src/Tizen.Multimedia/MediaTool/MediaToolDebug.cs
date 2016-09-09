
using System.Diagnostics;
using Tizen.Internals.Errors;

namespace Tizen.Multimedia
{
    internal class MediaToolDebug
    {

        [ConditionalAttribute("DEBUG")]
        internal static void AssertNoError(int errorCode)
        {
            Debug.Assert(errorCode == (int)ErrorCode.None, "The API is supposed not to return an error!",
                "Implementation of core may have been changed, modify code to throw if the return code is not zero.");
        }
    }
}
