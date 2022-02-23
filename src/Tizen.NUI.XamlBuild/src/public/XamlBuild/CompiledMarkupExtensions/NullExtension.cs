using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Tizen.NUI.EXaml;
using Tizen.NUI.EXaml.Build.Tasks;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    class NullExtension : ICompiledMarkupExtension
    {
        public IEnumerable<Instruction> ProvideValue(IElementNode node, ModuleDefinition module, ILContext context, out TypeReference typeRef)
        {
            typeRef = module.TypeSystem.Object;
            return new[] { Instruction.Create(OpCodes.Ldnull) };
        }

        public EXamlCreateObject ProvideValue(IElementNode node, ModuleDefinition module, EXamlContext Context)
        {
            return null;
        }
    }
}