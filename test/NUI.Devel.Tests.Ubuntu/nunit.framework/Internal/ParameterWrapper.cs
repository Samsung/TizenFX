// ***********************************************************************
// Copyright (c) 2015 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************
#define PORTABLE
#define TIZEN
#define NUNIT_FRAMEWORK
#define NUNITLITE
#define NET_4_5
#define PARALLEL
using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Compatibility;
using NUnit.Framework.Interfaces;
using System.IO;
using NUnit.Framework.TUnit;

#if PORTABLE
using System.Linq;
#endif

namespace NUnit.Framework.Internal
{
    /// <summary>
    /// The ParameterWrapper class wraps a ParameterInfo so that it may
    /// be used in a platform-independent manner.
    /// </summary>
    public class ParameterWrapper : IParameterInfo
    {
        /// <summary>
        /// Construct a ParameterWrapper for a given method and parameter
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameterInfo"></param>
        public ParameterWrapper(IMethodInfo method, ParameterInfo parameterInfo)
        {
            Method = method;
            ParameterInfo = parameterInfo;
        }

        #region Properties

#if !NETCF
        /// <summary>
        /// Gets a value indicating whether the parameter is optional
        /// </summary>
        public bool IsOptional
        {
            get { return ParameterInfo.IsOptional; }
        }
#endif

        /// <summary>
        /// Gets an IMethodInfo representing the method for which this is a parameter.
        /// </summary>
        public IMethodInfo Method { get; private set; }

        /// <summary>
        /// Gets the underlying ParameterInfo
        /// </summary>
        public ParameterInfo ParameterInfo { get; private set; }

        /// <summary>
        /// Gets the Type of the parameter
        /// </summary>
        public Type ParameterType
        {
            get { return ParameterInfo.ParameterType; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns an array of custom attributes of the specified type applied to this method
        /// </summary>
        public T[] GetCustomAttributes<T>(bool inherit) where T : class
        {
#if PORTABLE
            var allAttributes = ParameterInfo.GetCustomAttributes();
            List<string> attributeDic = new List<string>();
            foreach (Attribute atb in allAttributes)
            {
                attributeDic.Add(atb.GetType().FullName);
            }
            var assembly = ParameterInfo.ParameterType.GetTypeInfo().Assembly;
            List<T> objects = new List<T>();

            string path = System.IO.Path.GetDirectoryName(assembly.Location);
            if (!Directory.Exists(path))
            {
                TLogger.WriteError(TLogger.ExceptionTag, "" + path + " - not a directory");
                return objects.ToArray();
            }
            foreach (var assemblyPath in Directory.GetFiles(path, "*.Tests.dll"))
            {
                IEnumerable<Type> types;
                try
                {
                    Assembly please = AssemblyHelper.Load(assemblyPath);
                    if (please == null) continue;
                    types = please.GetTypes().Where(p => !p.GetTypeInfo().IsAbstract && p.GetTypeInfo().IsClass && p.GetTypeInfo().ImplementedInterfaces.Contains(typeof(T)));
                }
                catch (Exception)
                {
                    //TLogger.Write(TLogger.ExceptionTag, ex.ToString());
                    continue;
                }
                for (int i = 0; i < types.Count(); i++)
                {
                    try
                    {
                        if (attributeDic.Contains(types.ElementAt(i).FullName))
                        {
                            objects.Add((T)Activator.CreateInstance(types.ElementAt(i)));
                        }
                    }
                    catch (Exception)
                    {
                        //TLogger.Write(TLogger.ExceptionTag, ex.ToString());
                    }
                }
            }

            return objects.ToArray();
#else
            return (T[])ParameterInfo.GetCustomAttributes(typeof(T), inherit);
#endif
        }

        /// <summary>
        /// Gets a value indicating whether one or more attributes of the specified type are defined on the parameter.
        /// </summary>
        public bool IsDefined<T>(bool inherit)
        {
#if PORTABLE
            return ParameterInfo.GetCustomAttributes(inherit).Any(a => typeof(T).IsAssignableFrom(a.GetType()));
#else
            return ParameterInfo.IsDefined(typeof(T), inherit);
#endif
        }

        #endregion

        #region extra
        private string GetAssemblyName(string assemblyFullPath)
        {

            string[] delimiter1 = { "\\" };
            string[] delimiter2 = { "/" };
            string[] delimiterDot = { "." };
            string[] strAry;
            string returnValue = "";
            try
            {
                strAry = assemblyFullPath.Split(delimiter1, StringSplitOptions.None);

                if (strAry.Length < 2)
                    strAry = assemblyFullPath.Split(delimiter2, StringSplitOptions.None);

                foreach (string str in strAry)
                {
                    if (str.Contains("Tests.dll"))
                    {
                        string[] strSplit = str.Split(delimiterDot, StringSplitOptions.None);
                        returnValue = strSplit[0];
                        //                      LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, "check : "+ returnValue);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                LogUtils.Write(LogUtils.ERROR, LogUtils.TAG, e.ToString());
            }

            return returnValue;
        }
        #endregion
    }
}
