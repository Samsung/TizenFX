using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class CommonResource
    {
        public static string GetDaliResourcePath()
        {
            return @"/opt/usr/globalapps/org.tizen.example.Tizen.NUI.Samples/res/images/Dali/";
            //return @"/home/owner/apps_rw/org.tizen.example.Tizen.NUI.Samples/res/images/Dali/";
        }

        public static string GetFHResourcePath()
        {
            return @"/opt/usr/globalapps/org.tizen.example.Tizen.NUI.Samples/res/images/FH3/";
            //return @"/home/owner/apps_rw/org.tizen.example.Tizen.NUI.Samples/res/images/FH3/";
        }

        public static string GetTVResourcePath()
        {
            return @"/opt/usr/globalapps/org.tizen.example.Tizen.NUI.Samples/res/images/VD/";
            //return @"/home/owner/apps_rw/org.tizen.example.Tizen.NUI.Samples/res/images/VD/";
        }
    }
}

