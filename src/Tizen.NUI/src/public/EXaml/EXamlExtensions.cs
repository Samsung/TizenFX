using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace Tizen.NUI.EXaml
{
    /// Internal used, will never be opened.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EXamlExtensions
    {
        /// Internal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TXaml LoadFromEXamlPath<TXaml>(this TXaml view, string path)
        {
            //This EXaml file will be converted by Tizen.NUI.XamlBuild from the .xaml
            string xamlScript = GetXamlFromPath(path);
            LoadEXaml.Load(view, xamlScript);
            return view;
        }

        /// Internal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TXaml LoadFromEXamlPath<TXaml>(this TXaml view, Type callingType)
        {
            if (null == callingType)
            {
                return view;
            }

            MainAssembly = view.GetType().Assembly;

            string resourceName = callingType.Name + ".examl";
            string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            Tizen.Log.Fatal("NUI", "the resource path: " + resource);
            int windowWidth = NUIApplication.GetDefaultWindow().Size.Width;
            int windowHeight = NUIApplication.GetDefaultWindow().Size.Height;

            string likelyResourcePath = resource + "layout/" + windowWidth.ToString() + "x" + windowHeight.ToString() + "/" + resourceName;
            Tizen.Log.Fatal("NUI", "the resource path: " + likelyResourcePath);

            if (!File.Exists(likelyResourcePath))
            {
                likelyResourcePath = resource + "layout/" + resourceName;
            }

            //Find the xaml file in the layout folder
            if (File.Exists(likelyResourcePath))
            {
                StreamReader reader = new StreamReader(likelyResourcePath);
                var xaml = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();

                LoadEXaml.Load(view, xaml);
            }
                
            return view;
        }

        /// Internal used, will never be opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Assembly MainAssembly
        {
            get;
            set;
        }

        private static string GetXamlFromPath(string path)
        {
            string xaml;

            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                xaml = reader.ReadToEnd();
                reader.Dispose();
                return xaml;
            }
            return null;
        }
    }
}
