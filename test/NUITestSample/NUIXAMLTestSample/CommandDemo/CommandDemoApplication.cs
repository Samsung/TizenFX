using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.Components;

namespace Tizen.NUI.Examples
{
    public class CommandDemoApplication : NUIApplication
    {
        protected override void OnCreate()
        {
            CommandDemo demo = new CommandDemo();
            Window.Instance.Add(demo);
        }
    }
}
