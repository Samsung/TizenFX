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
using CommandLine;

namespace GenDummy
{
    class Program
    {
        public void Run(Options options)
        {
            if (options.Verbose)
            {
                Log.Level = LogLevel.VERBOSE;
            }

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

                Regex rgx = new Regex("^" + options.InputPath.Replace("\\", "\\\\"));
                foreach (var f in inputFiles)
                {
                    Log.Info($"Processing {f.FullName} ...");
                    Converter conv = new Converter(f.FullName);
                    conv.ConvertTo(rgx.Replace(f.FullName, options.OutputPath));
                }
            }
            else
            {
                if (!File.Exists(options.InputPath))
                {
                    throw new FileNotFoundException("Couldn't find the input file : " + options.InputPath);
                }
                Converter conv = new Converter(options.InputPath);
                conv.ConvertTo(options.OutputPath);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Program program = new Program();
                Parser.Default.ParseArguments<Options>(args).WithParsed(opts => program.Run(opts));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
