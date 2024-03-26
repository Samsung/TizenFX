
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    internal interface ISingleShotModel
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTensorData(int index, byte[] buffer);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] GetTensorData(int index);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Invoke();
    }
}
