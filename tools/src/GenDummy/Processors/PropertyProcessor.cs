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

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace GenDummy.Processors
{
    public class PropertyProcessor : IProcessor
    {
        public BlockSyntax DummyBlock { get; set; }

        public MemberDeclarationSyntax Process(MemberDeclarationSyntax member)
        {
            MemberDeclarationSyntax newMember = null;

            if (!(member is PropertyDeclarationSyntax property))
            {
                return null;
            }

            if (property.Modifiers.ToString().Contains("abstract") || property.Modifiers.ToString().Contains("override")
                || property.Modifiers.ToString().Contains("internal") || property.Modifiers.ToString().Contains("private")
                || property.Parent is InterfaceDeclarationSyntax)
            {
                return null;
            }

            if (property.AccessorList != null)
            {
                List<AccessorDeclarationSyntax> newAccessorSyntaxList = new List<AccessorDeclarationSyntax>();
                foreach (var accessor in property.AccessorList.Accessors)
                {
                    var newAccessor = accessor.WithBody(DummyBlock).WithSemicolonToken(new SyntaxToken()).WithTrailingTrivia(SyntaxFactory.Whitespace("\r\n"));
                    if (newAccessor.ExpressionBody != null)
                        newAccessor = newAccessor.WithExpressionBody(null);
                    newAccessorSyntaxList.Add(newAccessor);
                }

                var newaccessorListSyntax = SyntaxFactory.AccessorList().AddAccessors(newAccessorSyntaxList.ToArray());
                newMember = property.WithAccessorList(newaccessorListSyntax.WithTrailingTrivia(SyntaxFactory.Whitespace("\r\n")))
                    .WithInitializer(null).WithSemicolonToken(new SyntaxToken());
            }

            return newMember;
        }
    }
}
