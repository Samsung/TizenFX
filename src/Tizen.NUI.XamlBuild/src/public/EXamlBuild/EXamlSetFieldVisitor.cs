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
using System.Linq;
using Mono.Cecil.Cil;
using Tizen.NUI.Xaml;
using Tizen.NUI.Xaml.Build.Tasks;

namespace Tizen.NUI.EXaml.Build.Tasks
{
    class EXamlSetFieldVisitor : IXamlNodeVisitor
    {
        public EXamlSetFieldVisitor(EXamlContext context)
        {
            Context = context;
        }

        public EXamlContext Context { get; }

        public TreeVisitingMode VisitingMode => TreeVisitingMode.TopDown;
        public bool StopOnDataTemplate => true;
        public bool StopOnResourceDictionary => false;
        public bool VisitNodeOnDataTemplate => false;
        public bool SkipChildren(INode node, INode parentNode) => false;

        public bool IsResourceDictionary(ElementNode node)
        {
            var parentVar = Context.Variables[(IElementNode)node];
            return parentVar.VariableType.FullName == "Tizen.NUI.Binding.ResourceDictionary"
                || parentVar.VariableType.Resolve().BaseType?.FullName == "Tizen.NUI.Binding.ResourceDictionary";
        }

        public void Visit(ValueNode node, INode parentNode)
        {
            //Fang: Need to deal set field
            //if (!IsXNameProperty(node, parentNode))
            //    return;
            //var field = Context.Body.Method.DeclaringType.Fields.SingleOrDefault(fd => fd.Name == (string)node.Value);
            //if (field == null)
            //    return;
            //Context.IL.Emit(OpCodes.Ldarg_0);
            //Context.IL.Emit(OpCodes.Ldloc, Context.Variables[(IElementNode)parentNode]);
            //Context.IL.Emit(OpCodes.Stfld, field);
        }

        public void Visit(MarkupNode node, INode parentNode)
        {
        }

        public void Visit(ElementNode node, INode parentNode)
        {
        }

        public void Visit(RootNode node, INode parentNode)
        {
        }

        public void Visit(ListNode node, INode parentNode)
        {
        }

        static bool IsXNameProperty(ValueNode node, INode parentNode)
        {
            var parentElement = parentNode as IElementNode;
            INode xNameNode;
            if (parentElement != null && parentElement.Properties.TryGetValue(XmlName.xName, out xNameNode) && xNameNode == node)
                return true;
            return false;
        }
    }
}
 
