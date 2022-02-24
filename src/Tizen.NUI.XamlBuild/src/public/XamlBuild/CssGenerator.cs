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
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.CSharp;

using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    class CssGenerator
    {
        internal CssGenerator()
        {
        }

        public CssGenerator(
            ITaskItem taskItem,
            string language,
            string assemblyName,
            string outputFile,
            TaskLoggingHelper logger)
            : this(
                taskItem.ItemSpec,
                language,
                taskItem.GetMetadata("ManifestResourceName"),
                taskItem.GetMetadata("TargetPath"),
                assemblyName,
                outputFile,
                logger)
        {
        }

        internal static CodeDomProvider Provider = new CSharpCodeProvider();

        public string CssFile { get; }
        public string Language { get; }
        public string ResourceId { get; }
        public string TargetPath { get; }
        public string AssemblyName { get; }
        public string OutputFile { get; }
        public TaskLoggingHelper Logger { get; }

        public CssGenerator(
            string cssFile,
            string language,
            string resourceId,
            string targetPath,
            string assemblyName,
            string outputFile,
            TaskLoggingHelper logger = null)
        {
            CssFile = cssFile;
            Language = language;
            ResourceId = resourceId;
            TargetPath = targetPath;
            AssemblyName = assemblyName;
            OutputFile = outputFile;
            Logger = logger;
        }

        //returns true if a file is generated
        public bool Execute()
        {
            Logger?.LogMessage(MessageImportance.Low, "Source: {0}", CssFile);
            Logger?.LogMessage(MessageImportance.Low, " Language: {0}", Language);
            Logger?.LogMessage(MessageImportance.Low, " ResourceID: {0}", ResourceId);
            Logger?.LogMessage(MessageImportance.Low, " TargetPath: {0}", TargetPath);
            Logger?.LogMessage(MessageImportance.Low, " AssemblyName: {0}", AssemblyName);
            Logger?.LogMessage(MessageImportance.Low, " OutputFile {0}", OutputFile);

            GenerateCode();

            return true;
        }

        void GenerateCode()
        {
            //Create the target directory if required
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(OutputFile));

            var ccu = new CodeCompileUnit();
            ccu.AssemblyCustomAttributes.Add(
               new CodeAttributeDeclaration(new CodeTypeReference($"global::{typeof(XamlResourceIdAttribute).FullName}"),
                                            new CodeAttributeArgument(new CodePrimitiveExpression(ResourceId)),
                                            new CodeAttributeArgument(new CodePrimitiveExpression(TargetPath.Replace('\\', '/'))),
                                            new CodeAttributeArgument(new CodePrimitiveExpression(null))
                                           ));

            //write the result
            using (var writer = new StreamWriter(OutputFile))
                Provider.GenerateCodeFromCompileUnit(ccu, writer, new CodeGeneratorOptions());
        }
    }
}
 
