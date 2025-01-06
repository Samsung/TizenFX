namespace AIAvatar
{

    public static class Utils
    {
        public static string LogTag = "Tizen.AIAvatar";
        public static string TTSText = "Hello, Who are you?";
        public static string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        public static void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }
    }
}
