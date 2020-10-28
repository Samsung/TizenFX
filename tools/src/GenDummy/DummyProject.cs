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

using GenDummy.Processors;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Text;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GenDummy
{
    public class DummyProject
    {
        readonly Project _project;
        readonly IProcessor _processor;

        public DummyProject()
        {
            AdhocWorkspace workSpace = new AdhocWorkspace();
            ProjectInfo projectInfo = ProjectInfo.Create(ProjectId.CreateNewId(), VersionStamp.Create(), "DummyProject", "DummyAssembly", LanguageNames.CSharp);
            _project = workSpace.AddProject(projectInfo);

            _processor = new DummyProcessor();
        }

        public Task GenerateDummy(string source, string dest = null)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentNullException("source");

            return GenerateDummyInternal(source, dest);
        }

        async Task GenerateDummyInternal(string source, string dest = null)
        {
            var sourceText = File.ReadAllText(source);
            var document = _project.AddDocument(Path.GetFileName(source), SourceText.From(sourceText));
            document = await UpdateMembers(document);
            var destText = await document.GetTextAsync();

            string destPath = dest;
            if (string.IsNullOrEmpty(dest))
            {
                destPath = Path.ChangeExtension(source, "dummy.cs");
            }
            File.WriteAllText(destPath, destText.ToString());
        }
        
        async Task<Document> UpdateMembers(Document document)
        {
            var documentRoot = (CompilationUnitSyntax)await document.GetSyntaxRootAsync();
            var editor = await DocumentEditor.CreateAsync(document);

            foreach (var member in documentRoot.DescendantNodes())
            {
                var newMember = _processor.Process(member as MemberDeclarationSyntax);
                if (newMember != null)
                {
                    editor.ReplaceNode(member, newMember);
                }
            }
            return editor.GetChangedDocument();
        }
    }
}
