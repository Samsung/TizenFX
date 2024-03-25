
namespace Tizen.AIAvatar
{
    internal interface ISingleShotModel
    {

        public void SetTensorData(int index, byte[] buffer);
        public byte[] GetTensorData(int index);
        public void Invoke();
    }
}
