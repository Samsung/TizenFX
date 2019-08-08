using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// This is a base class for components
    /// </summary>
    public abstract class BaseComponent
    {
        internal IntPtr Handle;

        /// <summary>
        /// ID for this component instance.
        /// It will be created after OnCreate method is invoked.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Id { get; private set; }

        /// <summary>
        /// Component ID
        /// </summary>
        public string ComponentId { get; }

        /// <summary>
        /// Parent object
        /// </summary>
        public CBApplicationBase Parent { get; internal set; }

        /// <summary>
        /// Finish current component
        /// </summary>
        public virtual void Finish()
        {
        }

        internal void Bind(IntPtr handle, string id)
        {
            Handle = handle;
            Id = id;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior to restore the previous status.
        /// </summary>
        /// <param name="c">Contents</param>
        public virtual void OnRestoreContents(Bundle c)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior to save current status.
        /// </summary>
        /// <param name="c">Contents</param>
        public virtual void OnSaveContent(Bundle c)
        {
        }
    }
}
