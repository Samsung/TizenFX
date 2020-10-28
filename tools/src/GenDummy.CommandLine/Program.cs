/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommandLine;

namespace GenDummy.CommandLine
{
    class Program
    {
        FileInfo[] inputFiles;

        public async Task Run(Options options)
        {
            if (Directory.Exists(options.InputPath))
            {
                options.IsMultiple = true;
            }

            if (options.IsMultiple)
            {
                if (string.IsNullOrEmpty(options.OutputPath) || !Directory.Exists(options.OutputPath))
                {
                    ExitWithError("Directory should be set as the output path.");
                }
                DirectoryInfo inputDirInfo = new DirectoryInfo(options.InputPath);
                inputFiles = inputDirInfo.GetFiles("*.cs", SearchOption.AllDirectories);
            }
            else
            {
                if (!File.Exists(options.InputPath))
                {
                    ExitWithError("Couldn't find the input file : " + options.InputPath);
                }
                FileInfo fileInfo = new FileInfo(options.InputPath);
                inputFiles = new FileInfo[] { fileInfo };
            }

            DummyProject project = new DummyProject();

            Regex rgx = new Regex("^" + options.InputPath.Replace("\\", "\\\\"));
            foreach (var f in inputFiles)
            {
                if (string.IsNullOrEmpty(options.OutputPath))
                {
                    await project.GenerateDummy(f.FullName);
                }
                else if (Directory.Exists(options.OutputPath))
                {
                    var outputFile = rgx.Replace(f.FullName, options.OutputPath);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                    await project.GenerateDummy(f.FullName, outputFile);
                }
                else
                {
                    await project.GenerateDummy(f.FullName, options.OutputPath);
                }
                
                if (options.Verbose)
                {
                    Console.WriteLine($"Processed : {f.FullName}");
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opts => program.Run(opts).Wait());
        }

        static void ExitWithError(string err)
        {
            Console.Error.WriteLine("Error: " + err);
            Environment.Exit(1);
        }

    }
}
