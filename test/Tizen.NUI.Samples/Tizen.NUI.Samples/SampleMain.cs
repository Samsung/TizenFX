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
            return Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/Dali/";
        }

        public static string GetFHResourcePath()
        {
            return Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/FH3/";
        }

        public static string GetTVResourcePath()
        {
            return Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/VD/";
        }
    }
}

