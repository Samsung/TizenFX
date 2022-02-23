using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using Tizen.NUI.EXaml;
using Tizen.NUI.EXaml.Build.Tasks;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    interface ICompiledMarkupExtension
    {
        IEnumerable<Instruction> ProvideValue(IElementNode node, ModuleDefinition module, ILContext context, out TypeReference typeRef);

        EXamlCreateObject ProvideValue(IElementNode node, ModuleDefinition module, EXamlContext Context);
    }
}