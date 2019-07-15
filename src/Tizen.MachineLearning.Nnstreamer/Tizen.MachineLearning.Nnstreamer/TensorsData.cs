using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.MachineLearning.Nnstreamer
{
    public class TensorsData : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool disposed = false;

        public TensorsData(IntPtr handle)
        {
            _handle = handle;
        }

        ~TensorsData()
        {
            Dispose(false);
        }

        public void SetBuffer(int index, byte[] buffer)
        {
            NNStreamerError ret = NNStreamerError.None;

            ret = Interop.Util.SetTensorData(_handle, index, buffer, buffer.Length);
            NNStreamer.CheckException(ret, "unable to set the buffer of TensorsData: " + index.ToString());
        }

        public void GetBuffer(int index, out byte[] buffer)
        {
            byte[] retBuffer;
            int size;

            NNStreamerError ret = NNStreamerError.None;
            ret = Interop.Util.GetTensorData(_handle, index, out retBuffer, out size);
            NNStreamer.CheckException(ret, "unable to get the buffer of TensorsData: " + index.ToString());

            buffer = retBuffer;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                NNStreamerError ret = NNStreamerError.None;
                ret = Interop.Util.DestroyTensorData(_handle);
                if (ret != NNStreamerError.None)
                {
                    Log.Error(NNStreamer.TAG, "failed to destroy TensorsData object");
                }
            }
            disposed = true;
        }
    }
}
