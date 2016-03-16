using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.UI
{
    /// <summary>
    /// 
    /// </summary>
    interface IUIContext
    {
        /// <summary>
        /// 
        /// </summary>
        Window Window { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        string ResolveResourcePath(string res);
    }
}
