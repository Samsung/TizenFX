/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Linq;
using System.Text.RegularExpressions;
using CommandLine;

namespace APITool
{
    class Program
    {
        public int RunListAndReturnExitCode(ListOptions options)
        {
            if (options.Verbose)
            {
                Log.Level = LogLevel.VERBOSE;
            }

            APIPrinter printer = new APIPrinter(options);
            
            string absTarget = Path.GetFullPath(options.Target);
            if (Directory.Exists(absTarget))
            {
                DirectoryInfo targetDir = new DirectoryInfo(absTarget);
                var targetFiles = targetDir.GetFiles("*.dll").OrderBy(f => f.Name);
                foreach (var file in targetFiles)
                {
                    printer.Run(file.FullName);
                }
            }
            else if (File.Exists(absTarget))
            {
                printer.Run(absTarget);
            }
            else
            {
                Log.Error($"No such file found: {absTarget}");
                return 1;
            }

            return 0;
        }

        public int RunDummyAndReturnExitCode(DummyOptions options)
        {
            if (options.Verbose)
            {
                Log.Level = LogLevel.VERBOSE;
            }

            DummyGenerator dummyGenerator = new DummyGenerator();

            // Convert to absolute path
            if (!string.IsNullOrEmpty(options.InputPath))
            {
                options.InputPath = Path.GetFullPath(options.InputPath);
            }
            if (!string.IsNullOrEmpty(options.OutputPath))
            {
                options.OutputPath = Path.GetFullPath(options.OutputPath);
            }            

            if (Directory.Exists(options.InputPath))
            {
                if (string.IsNullOrEmpty(options.OutputPath) || !Directory.Exists(options.OutputPath))
                {
                    throw new DirectoryNotFoundException("Directory should be set as the output path.");
                }

                if (!options.OutputPath.EndsWith(Path.DirectorySeparatorChar))
                {
                    options.OutputPath += Path.DirectorySeparatorChar;
                }

                DirectoryInfo inputDirInfo = new DirectoryInfo(options.InputPath);
                FileInfo[] inputFiles = inputDirInfo.GetFiles("*.dll", SearchOption.AllDirectories);

                Regex rgx = new Regex("^" + options.InputPath.Replace("\\", "\\\\").Replace("+", "\\+"));
                foreach (var f in inputFiles)
                {
                    Log.Info($"Processing {f.FullName} ...");
                    dummyGenerator.Run(f.FullName, rgx.Replace(f.FullName, options.OutputPath));
                }
            }
            else
            {
                if (!File.Exists(options.InputPath))
                {
                    throw new FileNotFoundException("Couldn't find the input file : " + options.InputPath);
                }
                dummyGenerator.Run(options.InputPath, options.OutputPath);
            }

            return 0;
        }

        static int Main(string[] args)
        {
            try
            {
                Program program = new Program();
                return Parser.Default.ParseArguments<ListOptions, DummyOptions>(args).MapResult(
                        (ListOptions opts) => program.RunListAndReturnExitCode(opts),
                        (DummyOptions opts) => program.RunDummyAndReturnExitCode(opts),
                        errs => 1);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                Log.Error(ex.StackTrace);
                Environment.Exit(1);
            }
            return 0;
        }
    }
}
