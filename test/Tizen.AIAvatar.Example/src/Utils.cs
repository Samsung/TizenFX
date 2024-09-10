using System;
using System.Collections.Generic;
using System.Text;

namespace AIAvatar
{
    public static class Utils
    {
        static public string LogTag = "AvatarSample";
        static public string TTSText = "Select an avatar that will guide you through the functions of your age.";
        static public string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        static public void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }
    }
}
