using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tizen.MachineLearning.Inference;

namespace Tizen.MachineLearning.Inference.Test
{
    class SingleShotTest
    {
        const string TAG = "ML.Inference.Test";
        private static string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        public static bool BasicSingleTest_Success00()
        {
            byte[] in_buffer = new byte[3 * 224 * 224 * 1];
            byte[] out_buffer;
            string model_path = ResourcePath + "models/mobilenet_v1_1.0_224_quant.tflite";

            TensorsInfo in_info;
            TensorsInfo out_info;
            TensorsData in_data;
            TensorsData out_data;

            /* Set input & output TensorsInfo */
            in_info = new TensorsInfo();
            in_info.AddTensorInfo(TensorType.UInt8, new int[4] { 3, 224, 224, 1 });

            out_info = new TensorsInfo();
            out_info.AddTensorInfo(TensorType.UInt8, new int[4] { 1001, 1, 1, 1 });

            /* Create single inference engine */
            SingleShot single = new SingleShot(model_path, in_info, out_info);

            /* Set input data */
            in_data = in_info.GetTensorsData();
            in_data.SetTensorData(0, in_buffer);

            /* Single shot invoke */
            out_data = single.Invoke(in_data);

            /* Get output data from TensorsData */
            out_buffer = out_data.GetTensorData(0);

            /* Release Single inference instance */
            single.Dispose();

            /* clean up */
            in_data.Dispose();
            out_data.Dispose();
            in_info.Dispose();
            out_info.Dispose();

            return true;
        }
    }
}
