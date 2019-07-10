using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for supporting multi-components based application model.
    /// </summary>
    public class CBApplicationBase : Application
    {
        /// <summary>
        /// Runs the application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
        }

        /// <summary>
        /// Exits the main loop of the application.
        /// </summary>
        public override void Exit()
        {
        }

        /// <summary>
        /// Registers a component.
        /// </summary>
        /// <param name="compId">Component ID</param>
        /// <param name="compType">Class type</param>
        public virtual void RegisterComponent(string compId, Type compType)
        {
        }

        /// <summary>
        /// This method will be called before running main-loop
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnInit(string[] args)
        {
        }

        /// <summary>
        /// This method will be called after exiting main-loop
        /// </summary>
        protected virtual void OnFini()
        {
        }

        /// <summary>
        /// This method will be called to start main-loop
        /// </summary>
        protected virtual void OnRun()
        {
        }

        /// <summary>
        /// This method will be called to exit main-loop
        /// </summary>
        protected virtual void OnExit()
        {
        }

    }
}
