/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.ComponentModel;
using Mono.Cecil;
using Mono.Cecil.Cil;

using Tizen.NUI.Binding;
using Tizen.NUI.EXaml;
using Tizen.NUI.EXaml.Build.Tasks;
using static Microsoft.Build.Framework.MessageImportance;
using static Mono.Cecil.Cil.OpCodes;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class XamlCTask : XamlTask
    {
        bool hasCompiledXamlResources;
        public bool KeepXamlResources { get; set; }
        public bool OptimizeIL { get; set; }

        [Obsolete("OutputGeneratedILAsCode is obsolete as of version 2.3.4. This option is no longer available.")]
        public bool OutputGeneratedILAsCode { get; set; }

        public bool CompileByDefault { get; set; }
        public bool ForceCompile { get; set; }

        public bool UseInjection { get; set; }

        public IAssemblyResolver DefaultAssemblyResolver { get; set; }

        public string Type { get; set; }
        public MethodDefinition InitCompForType { get; private set; }
        internal bool ReadOnly { get; set; }

        public string outputRootPath { get; set; }

        public bool PrintReferenceAssemblies { get; set; }

        private void PrintParam(string logFileName, string log)
        {
            FileStream stream = null;
            if (false == File.Exists(logFileName))
            {
                stream = File.Create(logFileName);
            }
            else
            {
                stream = File.Open(logFileName, FileMode.Append);
            }

            byte[] buffer = System.Text.Encoding.Default.GetBytes(log + "\n");
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();
        }

        private void PrintParam(string logFileName)
        {
            FileStream stream = File.Create(logFileName);

            string str = "Assembly is " + Assembly + "\n";
            str += "DependencyPaths is " + DependencyPaths + "\n";
            str += "ReferencePath is " + ReferencePath + "\n";
            str += "DebugType is " + DebugType + "\n";
            str += "Type is " + Type + "\n";
            str += "ReadOnly is " + ReadOnly + "\n";

            byte[] buffer = Encoding.Default.GetBytes(str);
            stream.Write(buffer, 0, buffer.Length);

            stream.Close();
        }

        static private TypeDefinition baseTypeDefiniation = null;
        static public TypeDefinition BaseTypeDefiniation
        {
            get
            {
                return baseTypeDefiniation;
            }
        }

        private void GatherAssemblyInfo(string p)
        {
            try
            {
                ModuleDefinition module = ModuleDefinition.ReadModule(p);

                if (null == baseTypeDefiniation)
                {
                    baseTypeDefiniation = module.GetType("Tizen.NUI.Binding.BindableObject");
                }

                foreach (var attr in module.Assembly.CustomAttributes)
                {
                    if (attr.AttributeType.FullName == "Tizen.NUI.XmlnsDefinitionAttribute")
                    {
                        string xmlNamespace = attr.ConstructorArguments[0].Value as string;
                        string clrNamespace = attr.ConstructorArguments[1].Value as string;

                        int level = 0;
                        string assemblyName = module.Assembly.FullName;

                        if (true == attr.HasProperties)
                        {
                            foreach (var property in attr.Properties)
                            {
                                if ("Level" == property.Name)
                                {
                                    level = int.Parse(property.Argument.Value.ToString());
                                }
                                if ("AssemblyName" == property.Name)
                                {
                                    assemblyName = property.Argument.Value as string;
                                }
                            }
                        }

                        XmlnsDefinitionAttribute attribute = new XmlnsDefinitionAttribute(xmlNamespace, clrNamespace, level);
                        attribute.AssemblyName = assemblyName;
                        s_xmlnsDefinitions.Add(attribute);
                    }
                }

                module.Dispose();
            }
            catch (Exception e)
            {
                int temp = 0;
            }
        }

        public override bool Execute(out IList<Exception> thrownExceptions)
        {
            if (true == PrintReferenceAssemblies)
            {
                PrintParam(@"XamlC_Log.txt", "ReferencePath is " + ReferencePath);
            }

            LoggingHelper.LogWarning("Assembly is " + Assembly);

            thrownExceptions = null;

            LoggingHelper.LogMessage(Normal, $"{new string(' ', 0)}Compiling Xaml, assembly: {Assembly}");
            var skipassembly = !CompileByDefault;
            bool success = true;

            if (!File.Exists(Assembly))
            {
                throw new Exception(String.Format("Assembly file {0} is not exist", Assembly));
                //LoggingHelper.LogMessage(Normal, $"{new string(' ', 2)}Assembly file not found. Skipping XamlC.");
                //return true;
            }

            s_xmlnsDefinitions.Clear();

            var resolver = DefaultAssemblyResolver ?? new XamlCAssemblyResolver();
            if (resolver is XamlCAssemblyResolver xamlCResolver)
            {
                if (!string.IsNullOrEmpty(DependencyPaths))
                {
                    foreach (var dep in DependencyPaths.Split(';'))
                    {
                        LoggingHelper.LogMessage(Low, $"{new string(' ', 2)}Adding searchpath {dep}");
                        xamlCResolver.AddSearchDirectory(dep);
                    }
                }

                if (!string.IsNullOrEmpty(ReferencePath))
                {
                    var paths = ReferencePath.Replace("//", "/").Split(';');

                    foreach (var p in paths)
                    {
                        GatherAssemblyInfo(p);

                        var searchpath = System.IO.Path.GetDirectoryName(p);
                        LoggingHelper.LogMessage(Low, $"{new string(' ', 2)}Adding searchpath {searchpath}");
                        xamlCResolver.AddSearchDirectory(searchpath);
                    }
                }
            }
            else
                LoggingHelper.LogMessage(Low, $"{new string(' ', 2)}Ignoring dependency and reference paths due to an unsupported resolver");

            var debug = DebugSymbols || (!string.IsNullOrEmpty(DebugType) && DebugType.ToLowerInvariant() != "none");

            var readerParameters = new ReaderParameters
            {
                AssemblyResolver = resolver,
                ReadWrite = !ReadOnly,
                ReadSymbols = debug,
            };

            using (var assemblyDefinition = AssemblyDefinition.ReadAssembly(System.IO.Path.GetFullPath(Assembly), readerParameters))
            {
                if (null != XamlFilePath)
                {
                    return GenerateEXaml(XamlFilePath, assemblyDefinition.MainModule, out thrownExceptions);
                }

                CustomAttribute xamlcAttr;
                if (assemblyDefinition.HasCustomAttributes &&
                    (xamlcAttr =
                        assemblyDefinition.CustomAttributes.FirstOrDefault(
                            ca => ca.AttributeType.FullName == "Tizen.NUI.Xaml.XamlCompilationAttribute")) != null)
                {
                    var options = (XamlCompilationOptions)xamlcAttr.ConstructorArguments[0].Value;
                    if ((options & XamlCompilationOptions.Skip) == XamlCompilationOptions.Skip)
                        skipassembly = true;
                    if ((options & XamlCompilationOptions.Compile) == XamlCompilationOptions.Compile)
                        skipassembly = false;
                }

                foreach (var module in assemblyDefinition.Modules)
                {
                    var skipmodule = skipassembly;
                    if (module.HasCustomAttributes &&
                        (xamlcAttr =
                            module.CustomAttributes.FirstOrDefault(
                                ca => ca.AttributeType.FullName == "Tizen.NUI.Xaml.XamlCompilationAttribute")) != null)
                    {
                        var options = (XamlCompilationOptions)xamlcAttr.ConstructorArguments[0].Value;
                        if ((options & XamlCompilationOptions.Skip) == XamlCompilationOptions.Skip)
                            skipmodule = true;
                        if ((options & XamlCompilationOptions.Compile) == XamlCompilationOptions.Compile)
                            skipmodule = false;
                    }

                    LoggingHelper.LogMessage(Low, $"{new string(' ', 2)}Module: {module.Name}");
                    var resourcesToPrune = new List<EmbeddedResource>();
                    foreach (var resource in module.Resources.OfType<EmbeddedResource>())
                    {
                        LoggingHelper.LogMessage(Low, $"{new string(' ', 4)}Resource: {resource.Name}");
                        string classname;
                        if (!resource.IsXaml(module, out classname))
                        {
                            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}skipped.");
                            continue;
                        }
                        TypeDefinition typeDef = module.GetType(classname);
                        if (typeDef == null)
                        {
                            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}no type found... skipped.");
                            continue;
                        }
                        var skiptype = skipmodule;
                        if (typeDef.HasCustomAttributes &&
                            (xamlcAttr =
                                typeDef.CustomAttributes.FirstOrDefault(
                                    ca => ca.AttributeType.FullName == "Tizen.NUI.Xaml.XamlCompilationAttribute")) != null)
                        {
                            var options = (XamlCompilationOptions)xamlcAttr.ConstructorArguments[0].Value;
                            if ((options & XamlCompilationOptions.Skip) == XamlCompilationOptions.Skip)
                                skiptype = true;
                            if ((options & XamlCompilationOptions.Compile) == XamlCompilationOptions.Compile)
                                skiptype = false;
                        }

                        if (Type != null)
                            skiptype = !(Type == classname);

                        if (skiptype && !ForceCompile)
                        {
                            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}has XamlCompilationAttribute set to Skip and not Compile... skipped.");
                            continue;
                        }

                        bool currentRetOfType;
                        IList<Exception> currentExceptionsOfType;

                        if (UseInjection)
                        {
                            currentRetOfType = DoInjection(typeDef, resource, out currentExceptionsOfType);
                        }
                        else
                        {
                            currentRetOfType = GenerateEXaml(typeDef, resource, out currentExceptionsOfType);

                            if (currentRetOfType)
                            {
                                InjectionMethodGetEXamlPath(typeDef);
                            }
                        }

                        if (null != currentExceptionsOfType)
                        {
                            if (null == thrownExceptions)
                            {
                                thrownExceptions = new List<Exception>();
                            }

                            foreach (var e in currentExceptionsOfType)
                            {
                                thrownExceptions.Add(e);
                            }
                        }

                        if (false == currentRetOfType)
                        {
                            success = false;
                            continue;
                        }

                        resourcesToPrune.Add(resource);
                    }

                    if (hasCompiledXamlResources)
                    {
                        LoggingHelper.LogMessage(Low, $"{new string(' ', 4)}Changing the module MVID");
                        module.Mvid = Guid.NewGuid();
                        LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}done.");
                    }
                    if (!KeepXamlResources)
                    {
                        if (resourcesToPrune.Any())
                            LoggingHelper.LogMessage(Low, $"{new string(' ', 4)}Removing compiled xaml resources");
                        foreach (var resource in resourcesToPrune)
                        {
                            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Removing {resource.Name}");
                            module.Resources.Remove(resource);
                            LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}done.");
                        }
                    }
                }

                if (!hasCompiledXamlResources)
                {
                    LoggingHelper.LogMessage(Low, $"{new string(' ', 0)}No compiled resources. Skipping writing assembly.");
                    return success;
                }

                if (ReadOnly)
                    return success;

                LoggingHelper.LogMessage(Low, $"{new string(' ', 0)}Writing the assembly");
                try
                {
                    assemblyDefinition.Write(new WriterParameters
                    {
                        WriteSymbols = debug,
                    });
                    LoggingHelper.LogMessage(Low, $"{new string(' ', 2)}done.");
                }
                catch (Exception e)
                {
                    LoggingHelper.LogMessage(Low, $"{new string(' ', 2)}failed.");
                    LoggingHelper.LogErrorFromException(e);
                    (thrownExceptions = thrownExceptions ?? new List<Exception>()).Add(e);
                    LoggingHelper.LogMessage(Low, e.StackTrace);
                    success = false;
                }
            }
            return success;
        }

        bool DoInjection(TypeDefinition typeDef, EmbeddedResource resource, out IList<Exception> thrownExceptions)
        {
            thrownExceptions = null;

            var initComp = typeDef.Methods.FirstOrDefault(md => md.Name == "InitializeComponent");
            if (initComp == null)
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}no InitializeComponent found... skipped.");
                return false;
            }

            CustomAttribute xamlFilePathAttr;
            var xamlFilePath = typeDef.HasCustomAttributes && (xamlFilePathAttr = typeDef.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.FullName == "Tizen.NUI.Xaml.XamlFilePathAttribute")) != null ?
                                      (string)xamlFilePathAttr.ConstructorArguments[0].Value :
                                      resource.Name;

            var initCompRuntime = typeDef.Methods.FirstOrDefault(md => md.Name == "__InitComponentRuntime");
            if (initCompRuntime != null)
                LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}__InitComponentRuntime already exists... not creating");
            else
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Creating empty {typeDef.Name}.__InitComponentRuntime");
                initCompRuntime = new MethodDefinition("__InitComponentRuntime", initComp.Attributes, initComp.ReturnType);
                initCompRuntime.Body.InitLocals = true;
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}done.");
                LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Copying body of InitializeComponent to __InitComponentRuntime");
                initCompRuntime.Body = new MethodBody(initCompRuntime);
                var iCRIl = initCompRuntime.Body.GetILProcessor();
                foreach (var instr in initComp.Body.Instructions)
                    iCRIl.Append(instr);
                initComp.Body.Instructions.Clear();
                initComp.Body.GetILProcessor().Emit(OpCodes.Ret);
                initComp.Body.InitLocals = true;

                typeDef.Methods.Add(initCompRuntime);
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}done.");
            }

            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Parsing Xaml");
            var rootnode = ParseXaml(resource.GetResourceStream(), typeDef);
            if (rootnode == null)
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}failed.");
                return false;
            }
            LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}done.");

            hasCompiledXamlResources = true;

            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Replacing {0}.InitializeComponent ()");
            Exception e;
            if (!TryCoreCompile(initComp, rootnode, out e))
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}failed.");
                (thrownExceptions = thrownExceptions ?? new List<Exception>()).Add(e);
                if (e is XamlParseException xpe)
                    LoggingHelper.LogError(null, null, null, xamlFilePath, xpe.XmlInfo.LineNumber, xpe.XmlInfo.LinePosition, 0, 0, xpe.Message, xpe.HelpLink, xpe.Source);
                else if (e is XmlException xe)
                    LoggingHelper.LogError(null, null, null, xamlFilePath, xe.LineNumber, xe.LinePosition, 0, 0, xe.Message, xe.HelpLink, xe.Source);
                else
                    LoggingHelper.LogError(null, null, null, xamlFilePath, 0, 0, 0, 0, e.Message, e.HelpLink, e.Source);

                if (null != e.StackTrace)
                {
                    LoggingHelper.LogMessage(Low, e.StackTrace);
                }

                return false;
            }
            if (Type != null)
                InitCompForType = initComp;

            LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}done.");

            if (OptimizeIL)
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Optimizing IL");
                initComp.Body.Optimize();
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}done.");
            }

#pragma warning disable 0618
            if (OutputGeneratedILAsCode)
                LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Decompiling option has been removed. Use a 3rd party decompiler to admire the beauty of the IL generated");
#pragma warning restore 0618

            return true;
        }

        bool GenerateEXaml(TypeDefinition typeDef, EmbeddedResource resource, out IList<Exception> thrownExceptions)
        {
            thrownExceptions = null;

            ModuleDefinition module = typeDef.Module;

            CustomAttribute xamlFilePathAttr;
            var xamlFilePath = typeDef.HasCustomAttributes && (xamlFilePathAttr = typeDef.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.FullName == "Tizen.NUI.Xaml.XamlFilePathAttribute")) != null ?
                                      (string)xamlFilePathAttr.ConstructorArguments[0].Value :
                                      resource.Name;

            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Parsing Xaml");
            var rootnode = ParseXaml(resource.GetResourceStream(), typeDef);
            if (rootnode == null)
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}failed.");
                return false;
            }
            LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}done.");

            hasCompiledXamlResources = true;

            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Replacing {0}.InitializeComponent ()");
            Exception e;

            var visitorContext = new EXamlContext(typeDef, typeDef.Module);

            if (!TryCoreCompile(rootnode, visitorContext, out e))
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}failed.");
                (thrownExceptions = thrownExceptions ?? new List<Exception>()).Add(e);
                if (e is XamlParseException xpe)
                    LoggingHelper.LogError(null, null, null, xamlFilePath, xpe.XmlInfo.LineNumber, xpe.XmlInfo.LinePosition, 0, 0, xpe.Message, xpe.HelpLink, xpe.Source);
                else if (e is XmlException xe)
                    LoggingHelper.LogError(null, null, null, xamlFilePath, xe.LineNumber, xe.LinePosition, 0, 0, xe.Message, xe.HelpLink, xe.Source);
                else
                    LoggingHelper.LogError(null, null, null, xamlFilePath, 0, 0, 0, 0, e.Message, e.HelpLink, e.Source);

                if (null != e.StackTrace)
                {
                    LoggingHelper.LogMessage(Low, e.StackTrace);
                }

                return false;
            }
            else
            {
                var examlDir = outputRootPath + @"res/examl/";
                if (Directory.Exists(examlDir))
                {
                    Directory.CreateDirectory(examlDir);
                }

                var examlFilePath = examlDir + typeDef.FullName + ".examl";

                EXamlOperation.WriteOpertions(examlFilePath, visitorContext);
            }

            return true;
        }

        bool GenerateEXaml(string xamlFilePath, ModuleDefinition module, out IList<Exception> thrownExceptions)
        {
            thrownExceptions = null;

            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Parsing Xaml");
            Stream xamlStream = File.Open(xamlFilePath, FileMode.Open);

            string className;
            if (!CecilExtensions.IsXaml(xamlStream, module, out className))
            {
                thrownExceptions.Add(new Exception($"{xamlFilePath} is not xaml format file"));
            }

            xamlStream.Seek(0, SeekOrigin.Begin);
            var typeDef = module.GetTypeDefinition(className);

            if (null == typeDef)
            {
                throw new Exception($"Can't find type \"{className}\" in assembly \"{module.Assembly.FullName}\"");
            }

            var rootnode = ParseXaml(xamlStream, typeDef);

            xamlStream.Close();

            if (rootnode == null)
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}failed.");
                return false;
            }
            LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}done.");

            hasCompiledXamlResources = true;

            LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}Replacing {0}.InitializeComponent ()");
            Exception e;

            var visitorContext = new EXamlContext(typeDef, module);

            if (!TryCoreCompile(rootnode, visitorContext, out e))
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 8)}failed.");
                (thrownExceptions = thrownExceptions ?? new List<Exception>()).Add(e);
                if (e is XamlParseException xpe)
                    LoggingHelper.LogError(null, null, null, xamlFilePath, xpe.XmlInfo.LineNumber, xpe.XmlInfo.LinePosition, 0, 0, xpe.Message, xpe.HelpLink, xpe.Source);
                else if (e is XmlException xe)
                    LoggingHelper.LogError(null, null, null, xamlFilePath, xe.LineNumber, xe.LinePosition, 0, 0, xe.Message, xe.HelpLink, xe.Source);
                else
                    LoggingHelper.LogError(null, null, null, xamlFilePath, 0, 0, 0, 0, e.Message, e.HelpLink, e.Source);

                if (null != e.StackTrace)
                {
                    LoggingHelper.LogMessage(Low, e.StackTrace);
                }

                return false;
            }
            else
            {
                var examlDir = outputRootPath + @"res/examl/";
                if (Directory.Exists(examlDir))
                {
                    Directory.CreateDirectory(examlDir);
                }

                var examlFilePath = examlDir + typeDef.FullName + ".examl";

                EXamlOperation.WriteOpertions(examlFilePath, visitorContext);
            }

            return true;
        }


        bool InjectionMethodGetEXamlPath(TypeDefinition typeDef)
        {
            var getEXamlPathComp = typeDef.Methods.FirstOrDefault(md => md.Name == "GetEXamlPath");
            if (getEXamlPathComp == null)
            {
                LoggingHelper.LogMessage(Low, $"{new string(' ', 6)}no GetEXamlPath found... skipped.");
                return false;
            }

            var examlRelativePath = @"examl/" + typeDef.FullName + ".examl";
            getEXamlPathComp.Body.Instructions.Clear();
            getEXamlPathComp.Body.GetILProcessor().Emit(OpCodes.Ldstr, examlRelativePath);
            getEXamlPathComp.Body.GetILProcessor().Emit(OpCodes.Ret);

            return true;
        }

        bool TryCoreCompile(MethodDefinition initComp, ILRootNode rootnode, out Exception exception)
        {
            try
            {
                var body = new MethodBody(initComp);
                var module = body.Method.Module;
                var type = initComp.DeclaringType;

                MethodDefinition constructorOfRemoveEventsType;
                TypeDefinition typeOfRemoveEvents = CreateTypeForRemoveEvents(type, out constructorOfRemoveEventsType);

                var field = type.GetOrCreateField("___Info_Of_RemoveEvent___", FieldAttributes.Private, typeOfRemoveEvents);

                body.InitLocals = true;
                var il = body.GetILProcessor();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Newobj, constructorOfRemoveEventsType);
                il.Emit(OpCodes.Stfld, field);

                var resourcePath = GetPathForType(module, type);

                il.Emit(Nop);

                List<Instruction> insOfAddEvent = new List<Instruction>();

                var visitorContext = new ILContext(il, body, insOfAddEvent, module);

                rootnode.Accept(new XamlNodeVisitor((node, parent) => node.Parent = parent), null);
                rootnode.Accept(new ExpandMarkupsVisitor(visitorContext), null);
                rootnode.Accept(new PruneIgnoredNodesVisitor(), null);
                rootnode.Accept(new CreateObjectVisitor(visitorContext), null);

                Set(visitorContext, visitorContext.Variables[rootnode], "IsCreateByXaml", new ValueNode("true", rootnode.NamespaceResolver), null);

                rootnode.Accept(new SetNamescopesAndRegisterNamesVisitor(visitorContext), null);
                rootnode.Accept(new SetFieldVisitor(visitorContext), null);
                rootnode.Accept(new SetResourcesVisitor(visitorContext), null);
                rootnode.Accept(new SetPropertiesVisitor(visitorContext, true), null);

                AddInsOfRemoveEvent(il, visitorContext.InsOfAddEvent, typeOfRemoveEvents);

                il.Emit(Ret);
                initComp.Body = body;
                exception = null;
                return true;
            }
            catch (Exception e)
            {
                XamlParseException xamlParseException = e as XamlParseException;
                if (null != xamlParseException)
                {
                    XamlParseException ret = new XamlParseException(xamlParseException.Message + "\n" + ReferencePath, xamlParseException.XmlInfo, xamlParseException.InnerException);
                    exception = ret;
                }
                else
                {
                    exception = e;
                }

                return false;
            }
        }

        private void AddInsOfRemoveEvent(ILProcessor ilOfInit, List<Instruction> instructions, TypeDefinition typeDef)
        {
            MethodDefinition methodCall = typeDef.GetOrCreateMethod("Call", MethodAttributes.Public, typeof(void));
            methodCall.Body.Instructions.Clear();

            var fieldOfRemoveEvent = typeDef.DeclaringType.Fields.FirstOrDefault(a => a.Name == "___Info_Of_RemoveEvent___");

            var il = methodCall.Body.GetILProcessor();

            foreach (var ins in instructions)
            {
                if (ins.OpCode == OpCodes.Ldloc
                    &&
                    ins.Operand is VariableDefinition variable)
                {
                    var fieldName = "field" + variable.Index;
                    var field = typeDef.GetOrCreateField(fieldName, FieldAttributes.Public, variable.VariableType);

                    ilOfInit.Emit(OpCodes.Ldarg_0);
                    ilOfInit.Emit(OpCodes.Ldfld, fieldOfRemoveEvent);
                    ilOfInit.Emit(OpCodes.Ldloc, variable);
                    ilOfInit.Emit(OpCodes.Stfld, field);

                    methodCall.Body.Instructions.Add(Instruction.Create(Ldarg_0));
                    methodCall.Body.Instructions.Add(Instruction.Create(Ldfld, field));
                }
                else
                {
                    bool isReplaced = false;
                    if (ins.OpCode == OpCodes.Callvirt && ins.Operand is MethodReference method)
                    {
                        if (method.Name.StartsWith("add_"))
                        {
                            var eventName = method.Name.Substring("add_".Length);
                            TypeReference _;
                            var typeOfEvent = method.DeclaringType.GetEvent(a => a.Name == eventName, out _);

                            if (typeOfEvent is EventDefinition)
                            {
                                var methodOfRemoveEvent = typeDef.Module.ImportReference(method.DeclaringType.ResolveCached()?.Methods.FirstOrDefault(a => a.Name == "remove_" + eventName));
                                if (null != methodOfRemoveEvent)
                                {
                                    var newIns = Instruction.Create(ins.OpCode, methodOfRemoveEvent);
                                    methodCall.Body.Instructions.Add(newIns);

                                    isReplaced = true;
                                }
                            }
                        }
                    }

                    if (false == isReplaced)
                    {
                        methodCall.Body.Instructions.Add(ins);
                    }
                }
            }

            methodCall.Body.Instructions.Add(Instruction.Create(Ret));

            var removeEventMethod = typeDef.DeclaringType.Methods.FirstOrDefault(a => a.Name == "RemoveEventsInXaml");
            if (null != removeEventMethod)
            {
                removeEventMethod.Body.Instructions.Clear();
                var ilRemoveEvent = removeEventMethod.Body.GetILProcessor();

                ilRemoveEvent.Emit(Ldarg_0);
                ilRemoveEvent.Emit(Ldfld, fieldOfRemoveEvent);
                ilRemoveEvent.Emit(Dup);

                var insOfCall = Instruction.Create(Call, methodCall.Resolve());

                ilRemoveEvent.Emit(Brtrue_S, insOfCall);
                ilRemoveEvent.Emit(Pop);

                var endIns = Instruction.Create(Ret);

                ilRemoveEvent.Emit(Br_S, endIns);
                ilRemoveEvent.Append(insOfCall);

                ilRemoveEvent.Append(endIns);
            }
        }

        TypeDefinition CreateTypeForRemoveEvents(TypeDefinition typeDef, out MethodDefinition constructor)
        {
            var module = typeDef.Module;

            var name = "___Type___For___RemoveEvent___";
            var nestType = typeDef.NestedTypes.FirstOrDefault(a => a.Name == name);

            if (null == nestType)
            {
                nestType = new TypeDefinition(typeDef.Namespace, name, TypeAttributes.NestedPrivate | TypeAttributes.BeforeFieldInit | TypeAttributes.Sealed | TypeAttributes.AnsiClass);
                nestType.BaseType = module.ImportReference(typeof(object));
                typeDef.NestedTypes.Add(nestType);

                constructor = nestType.AddDefaultConstructor();
            }
            else
            {
                constructor = nestType.Methods.FirstOrDefault(a => a.IsConstructor);
            }

            return nestType;
        }

        bool TryCoreCompile(ILRootNode rootnode, EXamlContext visitorContext, out Exception exception)
        {
            try
            {
                XmlTypeExtensions.s_xmlnsDefinitions?.Clear();
                XmlTypeExtensions.s_xmlnsDefinitions = null;

                visitorContext.Values[rootnode] = new EXamlCreateObject(visitorContext, null, rootnode.TypeReference);

                rootnode.Accept(new XamlNodeVisitor((node, parent) => node.Parent = parent), null);
                rootnode.Accept(new EXamlExpandMarkupsVisitor(visitorContext), null);
                rootnode.Accept(new PruneIgnoredNodesVisitor(), null);
                rootnode.Accept(new EXamlCreateObjectVisitor(visitorContext), null);
                rootnode.Accept(new EXamlSetNamescopesAndRegisterNamesVisitor(visitorContext), null);
                rootnode.Accept(new EXamlSetFieldVisitor(visitorContext), null);
                rootnode.Accept(new EXamlSetResourcesVisitor(visitorContext), null);
                rootnode.Accept(new EXamlSetPropertiesVisitor(visitorContext, true), null);

                exception = null;
                return true;
            }
            catch (Exception e)
            {
                XamlParseException xamlParseException = e as XamlParseException;
                if (null != xamlParseException)
                {
                    XamlParseException ret = new XamlParseException(xamlParseException.Message + "\n" + ReferencePath, xamlParseException.XmlInfo, xamlParseException.InnerException);
                    exception = ret;
                }
                else
                {
                    exception = e;
                }

                return false;
            }
        }

        private void Set(ILContext Context, VariableDefinition parent, string localName, INode node, IXmlLineInfo iXmlLineInfo)
        {
            var module = Context.Body.Method.Module;
            TypeReference declaringTypeReference;
            var property = parent.VariableType.GetProperty(pd => pd.Name == localName, out declaringTypeReference);
            if (null == property)
            {
                return;
            }
            var propertySetter = property.SetMethod;

            module.ImportReference(parent.VariableType.ResolveCached());
            var propertySetterRef = module.ImportReference(module.ImportReference(propertySetter).ResolveGenericParameters(declaringTypeReference, module));
            propertySetterRef.ImportTypes(module);
            var propertyType = property.ResolveGenericPropertyType(declaringTypeReference, module);
            var valueNode = node as ValueNode;
            var elementNode = node as IElementNode;

            if (parent.VariableType.IsValueType)
                Context.IL.Emit(OpCodes.Ldloca, parent);
            else
                Context.IL.Emit(OpCodes.Ldloc, parent);

            if (valueNode != null)
            {
                foreach (var instruction in valueNode.PushConvertedValue(Context, propertyType, new ICustomAttributeProvider[] { property, propertyType.ResolveCached() }, valueNode.PushServiceProvider(Context, propertyRef: property), false, true))
                {
                    Context.IL.Append(instruction);
                }

                if (parent.VariableType.IsValueType)
                    Context.IL.Emit(OpCodes.Call, propertySetterRef);
                else
                    Context.IL.Emit(OpCodes.Callvirt, propertySetterRef);
            }
        }

        internal static string GetPathForType(ModuleDefinition module, TypeReference type)
        {
            foreach (var ca in type.Module.GetCustomAttributes())
            {
                if (!TypeRefComparer.Default.Equals(ca.AttributeType, module.ImportReference((xamlAssemblyName, xamlNameSpace, "XamlResourceIdAttribute"))))
                    continue;
                if (!TypeRefComparer.Default.Equals(ca.ConstructorArguments[2].Value as TypeReference, type))
                    continue;
                return ca.ConstructorArguments[1].Value as string;
            }
            return null;
        }

        internal static string GetResourceIdForPath(ModuleDefinition module, string path)
        {
            foreach (var ca in module.GetCustomAttributes())
            {
                if (!TypeRefComparer.Default.Equals(ca.AttributeType, module.ImportReference((xamlAssemblyName, xamlNameSpace, "XamlResourceIdAttribute"))))
                    continue;
                if (ca.ConstructorArguments[1].Value as string != path)
                    continue;
                return ca.ConstructorArguments[0].Value as string;
            }
            return null;
        }
    }
}
