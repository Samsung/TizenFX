/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;
using System.Collections.Generic;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a widget application.
    /// </summary>
    public class WidgetApplication : CoreApplication
    {
        /// <summary>
        /// Initializes WidgetApplication class with Type and application id.
        /// </summary>
        /// <param name="typeInfo">map structure for derived class type and widget id</param>
        public WidgetApplication(IDictionary<Type, string> typeInfo) : base(new WidgetCoreBackend())
        {
            WidgetCoreBackend core = Backend as WidgetCoreBackend;

            core?.CreateWidgetTypes(typeInfo);
        }

        /// <summary>
        /// Initializes WidgetApplication class with Type.
        /// </summary>
        /// <remarks> Widget id will be replaced as application id</remarks>
        /// <param name="type">derived class type</param>
        public WidgetApplication(Type type) : base(new WidgetCoreBackend())
        {
            WidgetCoreBackend core = Backend as WidgetCoreBackend;

            core?.CreateWidgetTypes(new Dictionary<Type, string>() { {type, ApplicationInfo.ApplicationId } });
        }

        /// <summary>
        /// Gets all instances of the widget associated with the type
        /// </summary>
        /// <param name="type">Class type for the widget</param>
        public IEnumerable<WidgetBase> GetInstances(Type type)
        {
            WidgetCoreBackend core = Backend as WidgetCoreBackend;

            if (core == null)
                return null;

            foreach (WidgetType w in core.WidgetTypes)
            {
                if (w.ClassType == type)
                {
                    return w.WidgetInstances;
                }
            }

            return null;
        }

        /// <summary>
        /// Runs the widget application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            base.Run(args);
        }
    }
}
