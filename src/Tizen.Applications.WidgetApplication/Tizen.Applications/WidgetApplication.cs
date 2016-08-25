// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
        /// Initializes WidgetApplication class.
        /// </summary>
        /// <param name="typeInfo">map structure for derived class type and widget id</param>
        public WidgetApplication(IDictionary<Type, string> typeInfo) : base(new WidgetCoreBackend())
        {
            WidgetCoreBackend core = Backend as WidgetCoreBackend;

            core?.CreateWidgetTypes(typeInfo);
        }

        /// <summary>
        /// Initializes WidgetApplication class.
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
