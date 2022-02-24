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
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Tizen.NUI.Binding;
using Tizen.NUI.EXaml.Build.Tasks;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.EXaml
{
    internal abstract class EXamlOperation
    {
        public EXamlOperation(EXamlContext eXamlContext)
        {
            this.eXamlContext = eXamlContext;
        }

        internal EXamlContext eXamlContext;

        internal static void WriteOpertions(string filePath, EXamlContext eXamlContext)
        {
            var ret = eXamlContext.GenerateEXamlString();
            if(string.IsNullOrEmpty(filePath))
            {
                throw new Exception("filePath is empty or null!");
            }
            /*Avoid the difference of '/' in file path on windows and linux*/
            filePath = filePath.Replace("\\", "/");
            if (filePath.Contains("/"))
            {
                OutputDir = filePath.Substring(0, filePath.LastIndexOf("/"));
            }
            if (!Directory.Exists(OutputDir))
            {
                Directory.CreateDirectory(OutputDir);
            }

            var stream = File.CreateText(filePath);
            stream.Write(ret);
            stream.Close();
        }

        public static string OutputDir
        {
            get;
            private set;
        }

        internal abstract string Write();
    }
}
 
