/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.IO;
using System.Xml;
using System.ComponentModel;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class XamlGTask : Task
    {
        [Required]
        public ITaskItem[] XamlFiles { get; set; }

        [Required]
        public ITaskItem[] OutputFiles { get; set; }

        public string Language { get; set; }
        public string AssemblyName { get; set; }
        public string DependencyPaths { get; set; }
        public string ReferencePath { get; set; }
        public bool AddXamlCompilationAttribute { get; set; }
        public bool PrintReferenceAssemblies { get; set; }

        private void PrintParam(string logFileName, string log)
        {
            FileStream stream = null;
            if (false == File.Exists(logFileName))
            {
                stream = File.Create(logFileName);
            }
            else
            {
                stream = File.Open(logFileName, FileMode.Append);
            }

            byte[] buffer = System.Text.Encoding.Default.GetBytes(log + "\n");
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
        }

        public override bool Execute()
        {
            if (true == PrintReferenceAssemblies)
            {
                PrintParam(@"XamlG_Log.txt", "ReferencePath is " + ReferencePath);
            }

            //PrintParam(@"G:\XamlG_Log.txt", "ReferencePath is " + ReferencePath);
            bool success = true;
            //Log.LogMessage(MessageImportance.Normal, "Generating code behind for XAML files");

            //NOTE: should not happen due to [Required], but there appears to be a place this is class is called directly
            if (XamlFiles == null || OutputFiles == null) {
                //Log.LogMessage("Skipping XamlG");
                return true;
            }

            if (XamlFiles.Length != OutputFiles.Length) {
                Log.LogError("\"{2}\" refers to {0} item(s), and \"{3}\" refers to {1} item(s). They must have the same number of items.", XamlFiles.Length, OutputFiles.Length, "XamlFiles", "OutputFiles");
                return false;
            }

            for (int i = 0; i < XamlFiles.Length; i++) {
                var xamlFile = XamlFiles[i];
                var outputFile = OutputFiles[i].ItemSpec;
                if (System.IO.Path.DirectorySeparatorChar == '/' && outputFile.Contains(@"\"))
                    outputFile = outputFile.Replace('\\','/');
                else if (System.IO.Path.DirectorySeparatorChar == '\\' && outputFile.Contains(@"/"))
                    outputFile = outputFile.Replace('/', '\\');

                var generator = new XamlGenerator(xamlFile, Language, AssemblyName, outputFile, ReferencePath, Log);
                generator.AddXamlCompilationAttribute = AddXamlCompilationAttribute;
                generator.ReferencePath = ReferencePath;

                try {
                    if (!generator.Execute()) {
                        //If Execute() fails, the file still needs to exist because it is added to the <Compile/> ItemGroup
                        File.WriteAllText (outputFile, string.Empty);
                    }
                }
                catch (XmlException xe) {
                    Log.LogError(null, null, null, xamlFile.ItemSpec, xe.LineNumber, xe.LinePosition, 0, 0, xe.Message, xe.HelpLink, xe.Source);
                    success = false;
                }
                catch (Exception e) {
                    Log.LogError(null, null, null, xamlFile.ItemSpec, 0, 0, 0, 0, e.Message, e.HelpLink, e.Source);
                    success = false;
                }
            }

            return success;
        }
    }
}
 
