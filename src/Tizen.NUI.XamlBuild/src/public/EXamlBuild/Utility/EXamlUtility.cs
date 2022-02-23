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
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.EXaml
{
    internal class EXamlUtility
    {
        internal static bool IsSameTypeReference(TypeReference typeReference1, TypeReference typeReference2)
        {
            if (null == typeReference1 || null == typeReference2)
            {
                return typeReference1 == typeReference2;
            }
            else if (typeReference1.Resolve() != typeReference2.Resolve())
            {
                return false;
            }
            else if (typeReference1 is GenericInstanceType)
            {
                if (typeReference2 is GenericInstanceType)
                {
                    var gType1 = typeReference1 as GenericInstanceType;
                    var gType2 = typeReference2 as GenericInstanceType;

                    if (gType1.GenericArguments.Count != gType2.GenericArguments.Count)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < gType1.GenericArguments.Count; i++)
                        {
                            if (false == IsSameTypeReference(gType1.GenericArguments[i], gType2.GenericArguments[i]))
                            {
                                return false;
                            }
                        }

                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return true;
            }
        }
    }
}
