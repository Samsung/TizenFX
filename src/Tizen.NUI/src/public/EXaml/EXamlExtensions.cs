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
