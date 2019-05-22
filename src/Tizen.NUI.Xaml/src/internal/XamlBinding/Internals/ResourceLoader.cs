﻿using System;
using System.IO;
using System.Reflection;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding.Internals
{
    public static class ResourceLoader
    {
        static Func<AssemblyName, string, string> resourceProvider = (asmName, path) =>
        {
            return null;
            //string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            //path = resource + path;

            //string ret = File.ReadAllText(path);
            //return ret;
        };

        //takes a resource path, returns string content
        public static Func<AssemblyName, string, string> ResourceProvider123
        {
            get => resourceProvider;
            internal set
            {
                DesignMode.IsDesignModeEnabled = true;
                resourceProvider = value;
            }
        }

        //takes a resource path, returns string content
        public static Func<AssemblyName, string, string> ResourceProvider {
            get => resourceProvider;
            internal set {
                DesignMode.IsDesignModeEnabled = true;
                resourceProvider = value;
            }
        }

        internal static Action<Exception> ExceptionHandler { get; set; }
    }
}