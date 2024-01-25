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
using System.Linq;
using System.Reflection;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding
{
    internal static class DependencyResolver
    {
        static Func<Type, object[], object> Resolver { get; set; }

        public static void ResolveUsing(Func<Type, object[], object> resolver)
        {
            Resolver = resolver;
        }

        public static void ResolveUsing(Func<Type, object> resolver)
        {
            Resolver = (type, objects) => resolver.Invoke(type);
        }

        internal static object Resolve(Type type, params object[] args)
        {
            var result = Resolver?.Invoke(type, args);

            if (result != null)
            {
                if (!type.IsInstanceOfType(result))
                {
                    throw new InvalidCastException("Resolved instance is not of the correct type.");
                }
            }

            return result;
        }

        internal static object ResolveOrCreate(Type type, params object[] args)
        {
            var result = Resolve(type, args);

            if (result != null) return result;

            if (args.Length > 0)
            {
                // This is by no means a general solution to matching with the correct constructor, but it'll
                // do for finding Android renderers which need Context (vs older custom renderers which may still use
                // parameterless constructors)
                if (type.GetTypeInfo().DeclaredConstructors.Any(info => info.GetParameters().Length == args.Length))
                {
                    return Activator.CreateInstance(type, args);
                }
            }

            return Activator.CreateInstance(type);
        }
    }
}
