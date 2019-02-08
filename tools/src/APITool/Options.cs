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

using CommandLine;

namespace APITool
{
    [Verb("list", HelpText = "Show public exposed API list.")]
    public class ListOptions
    {
        [Option('v', "verbose", Default = false, HelpText = "Print verbose messages.")]
        public bool Verbose { get; set; }

        [Option('t', "types", Default = false, HelpText = "Print types.")]
        public bool PrintTypes { get; set; }

        [Option('f', "fields", Default = false, HelpText = "Print fields.")]
        public bool PrintFields { get; set; }

        [Option('p', "properties", Default = false, HelpText = "Print properties.")]
        public bool PrintProperties { get; set; }

        [Option('e', "events", Default = false, HelpText = "Print events.")]
        public bool PrintEvents { get; set; }

        [Option('m', "methods", Default = false, HelpText = "Print methods.")]
        public bool PrintMethods { get; set; }

        [Option('h', "include-hidden", Default = false, HelpText = "Print hidden(internal API) entries.")]
        public bool PrintHiddens { get; set; }

        [Option('o', "output", Required=false, HelpText = "Output file path")]
        public string OutputFile {get; set;}

        [Value(0, MetaName = "target", Required = true, HelpText = "Target assembly or directory")]
        public string Target { get; set; }
    }

    [Verb("dummy", HelpText = "Generate dummy assemblies")]
    public class DummyOptions
    {
        [Option('v', "verbose", Default = false, HelpText = "Print verbose messages.")]
        public bool Verbose { get; set; }

        [Value(0, MetaName = "InputPath", Required = true, HelpText = "Input file or directory to process.")]
        public string InputPath { get; set; }

        [Value(1, MetaName = "OutputPath", HelpText = "Output path for generated files.")]
        public string OutputPath { get; set; }
    }

}
