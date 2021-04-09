using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.EXaml
{
    internal static class LoadEXaml
    {
        internal static void Load(object view, string xaml)
        {
            CreateObjectAction.Root = view;

            int index = 0;

            var createObject = new CreateObjectAction(null);
            var addExistInstance = new AddExistInstanceAction(null);
            var registerXName = new RegisterXNameAction(null);
            var setProperty = new SetPropertyAction(null);
            var addObject = new CallAddMethodAction(null);
            var setDynamicResourceAction = new SetDynamicResourceAction(null);
            var addToResourceDictionaryAction = new AddToResourceDictionaryAction(null);
            var setBindingAction = new SetBindingAction(null);

            foreach (char c in xaml)
            {
                //Console.Write(c);
                if (null == currentOp)
                {
                    switch (c)
                    {
                        case '<':
                            if (0 == index)
                            {
                                currentOp = new GatherAssembliesAction(null);
                                currentOp.Init();
                                index++;
                            }
                            else if (1 == index)
                            {
                                currentOp = new GatherTypesAction(null);
                                currentOp.Init();
                                index++;
                            }
                            else if (2 == index)
                            {
                                currentOp = new GatherPropertiesAction(null);
                                currentOp.Init();
                                index++;
                            }
                            else if (3 == index)
                            {
                                currentOp = new GatherMethodsAction(null);
                                currentOp.Init();
                                index++;
                            }
                            else if (4 == index)
                            {
                                currentOp = new GatherBindablePropertiesAction(null);
                                currentOp.Init();
                                index++;
                            }
                            break;

                        case '{':
                            currentOp = createObject;
                            currentOp.Init();
                            break;

                        case '@':
                            currentOp = addExistInstance;
                            currentOp.Init();
                            break;

                        case '&':
                            currentOp = registerXName;
                            currentOp.Init();
                            break;

                        case '[':
                            currentOp = setProperty;
                            currentOp.Init();
                            break;

                        case '$':
                            currentOp = setDynamicResourceAction;
                            currentOp.Init();
                            break;

                        case '^':
                            currentOp = addObject;
                            currentOp.Init();
                            break;

                        case '*':
                            currentOp = addToResourceDictionaryAction;
                            currentOp.Init();
                            break;

                        case '%':
                            currentOp = setBindingAction;
                            currentOp.Init();
                            break;
                    }
                }
                else
                {
                    currentOp = currentOp.DealChar(c);
                }
            }

            foreach (var op in Operations)
            {
                op.Do();
            }
        }

        internal static List<object> GatheredInstances
        {
            get;
        } = new List<object>();

        internal static List<Operation> Operations
        {
            get;
        } = new List<Operation>();

        private static Action currentOp = null;
    }
}
