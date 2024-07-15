using System;
using System.Collections.Generic;
using System.Text;

namespace AIAvatar
{
    public static class Utils
    {
        static public string LogTag = "AvatarSample";
        static public string TTSText = "감정을 담은 영어 한 문장을 알려줘.";
        static public string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        static public void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }
    }
}
