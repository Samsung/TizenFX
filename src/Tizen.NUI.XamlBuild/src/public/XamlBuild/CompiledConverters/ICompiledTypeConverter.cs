using System.Collections.Generic;
using Mono.Cecil.Cil;
using Mono.Cecil;
using Tizen.NUI.Xaml;
using System;
using Tizen.NUI.Xaml.Build.Tasks;
using System.Linq;

namespace Tizen.NUI.Xaml
{
    interface ICompiledTypeConverter
    {
        IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node);
    }
}

namespace Tizen.NUI.Xaml.Core.XamlC
{
    //only used in unit tests to make sure the compiled InitializeComponent is invoked
    class IsCompiledTypeConverter : ICompiledTypeConverter
    {
        public IEnumerable<Instruction> ConvertFromString(string value, ILContext context, BaseNode node)
        {
            if (value != "IsCompiled?")
                throw new Exception();
            yield return Instruction.Create(OpCodes.Ldc_I4_1);
        }
    }
}