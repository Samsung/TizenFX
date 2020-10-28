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
using System.Collections.Generic;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace GenDummy.Tasks
{
    public class GenDummyTask : ITask
    {
        readonly List<ITaskItem> _generatedFiles = new List<ITaskItem>();

        public IBuildEngine BuildEngine { get; set; }
        public ITaskHost HostObject { get; set; }

        [Required]
        public ITaskItem[] Sources { get; set; }

        [Required]
        public string OutputDirectory { get; set; }

        [Output]
        public ITaskItem[] GeneratedFiles => _generatedFiles.ToArray();

        public bool Execute()
        {
            try
            {
                ExecuteCore().Wait();
            } catch(Exception e)
            {
                Console.Error.WriteLine($"{e.ToString()} : {e.Message}");
                return false;
            }
            return true;
        }

        public async System.Threading.Tasks.Task ExecuteCore()
        {
            if (string.IsNullOrEmpty(OutputDirectory))
            {
                throw new ArgumentException("OutputDirectory is not set.");
            }

            DummyProject project = new DummyProject();

            foreach (var source in Sources)
            {
                string sourceFile = source.ItemSpec;
                if (!File.Exists(sourceFile))
                {
                    throw new FileNotFoundException(sourceFile);
                }
                
                string generatedFile = Path.Combine(OutputDirectory, sourceFile);

                string targetDirectory = Path.GetDirectoryName(generatedFile);
                Directory.CreateDirectory(targetDirectory);

                await project.GenerateDummy(source.ItemSpec, generatedFile);
                _generatedFiles.Add(new TaskItem(generatedFile));
            }
        }
    }
}
