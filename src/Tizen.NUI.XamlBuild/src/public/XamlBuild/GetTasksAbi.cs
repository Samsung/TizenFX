using System.ComponentModel;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GetTasksAbi : Task
    {
        [Output]
        public string AbiVersion { get; } = "4";

        public override bool Execute()
            => true;
    }
}