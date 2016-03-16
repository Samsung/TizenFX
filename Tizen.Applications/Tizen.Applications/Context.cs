using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Context
    {
        /// <summary>
        /// 
        /// </summary>
        public string ApplicationId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ApplicationVersion
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyDictionary<string, string> ApplicationPath
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
