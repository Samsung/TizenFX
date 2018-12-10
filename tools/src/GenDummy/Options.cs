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

using CommandLine;

namespace GenDummy
{
    class Options
    {
        [Option('v', "verbose", Default = false, HelpText = "Print verbose messages.")]
        public bool Verbose { get; set; }

        [Value(0, MetaName = "InputPath", Required = true, HelpText = "Input file or directory to process.")]
        public string InputPath { get; set; }

        [Value(1, MetaName = "OutputPath", HelpText = "Output path for generated files.")]
        public string OutputPath { get; set; }
    }
}
