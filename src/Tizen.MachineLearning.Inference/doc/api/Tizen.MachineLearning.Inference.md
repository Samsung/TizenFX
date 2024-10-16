---
uid: Tizen.MachineLearning.Inference
summary: Machine learning features help you to handle machine learning frameworks, like TensorFlow-Lite and PyTorch, with the construction of a data pipeline. There are two main machine learning inference APIs. The first is the NNStreamer pipeline API, which provides interfaces to create and execute stream pipelines with neural networks and sensors. The second is the NNStreamer single API, which provides interfaces to invoke a neural network model with a single instance of input data.
remarks: *content
---
## Overview
There are two types of Machine Learning Inference API - Single API and Pipeline API.  
Single API is useful for a simple usage scenario of neural network models. It allows the direct invoking of a neural network model with a single instance of input data for the model. It is useful if you have the input data pre-processed with the application itself and there are no complex interactions between neural network models, data processors, or data stream paths.  Pipeline API allows developers to construct and execute pipelines with multiple neural network models, multiple inputs and output nodes, multiple data processors, pre-and-post processors, and various data path manipulators. Besides, if the input is online data or streamed data, Pipeline API simplifies your application and improves its performance.
 - Support various neural network frameworks (NNFW)  
  TensorFlow, TensorFlow-Lite, Caffe2, PyTorch, and NNTrainer are the supported neural network frameworks. Neural network model files trained by such frameworks can be imported as filters of pipelines directly. Custom Filters, which are neural network models implemented directly with programming languages including C/C++ and Python, maybe imported as filters of pipelines directly as well.

### Single API
This section shows how to load a model without the construction of pipelines:  
  1. Create single shot instance with model path:

      ```cs
      using Tizen.MachineLearning.Inference;

      private TensorsInfo in_info;
      private TensorsInfo out_info;
      ...
      var single = new SingleShot(_modelPath, in_info, out_info);
      var single = new SingleShot(_modelPath, in_info, out_info, NNFWType.TensorflowLite, HWType.CPU, false);
      var single = new SingleShot(_modelPath, NNFWType.Any, HWType.Any, true);
      ```

      The SingleShot instance can be created by using method overloading. If the given model has a dynamic input/output dimension, `in_info` and `out_info` are required. `in_info` contains the information of the input tensors, and `out_info` contains the information of the output tensors.

  2. Get the Tensors Information.
      After opening the model, use the following methods to get the information of the tensors:

      ```cs
      private TensorsInfo tensorsInfo;

      var count = tensorsInfo.Count;
      var type = tensorsInfo.GetTensorType(idx);
      var dim = tensorsInfo.GetDimension(idx)
      var size = tensorsInfo.GetTensorSize(idx);
      ```

3. Invoke the model with input and output tensors.

    The model can be invoked with input and output tensors data. The result is included in the output tensors data:

    ```cs
    using Tizen.MachineLearning.Inference;
    ...
    private TensorsInfo in_info;
    private TensorsInfo out_info;

    in_info = new TensorsInfo();
    in_info.AddTensorInfo(TensorType.UInt8, new int[4] { 3, 224, 224, 1 });

    out_info = new TensorsInfo();
    out_info.AddTensorInfo(TensorType.UInt8, new int[4] { 1001, 1, 1, 1 });

    var single = new SingleShot(_modelPath, in_info, out_info);

    var in_data = in_info.GetTensorsData();
    in_data.SetTensorData(0, in_buffer);

    var out_data = single.Invoke(in_data);
    ```

4. Close the opened handle:
    ```cs
    in_data.Dispose();
    single.Dispose();
    in_info.Dispose();
    out_info.Dispose();
    ```

### Pipeline API

This section shows how to create a pipeline.

### Basic usage

1. Construct a pipeline with the GStreamer elements.

    Different pipelines can be constructed using various GStreamer elements:

    ```cs
    using Tizen.MachineLearning.Inference;

    private readonly string pipeline_desc = "videotestsrc num_buffers=2 ! videoconvert ! videoscale ! video/x-raw,format=RGBx,width=224,height=224 ! tensor_converter ! fakesink";
    var pipeline_handle = new Pipeline (pipeline_desc);
    ```

2. Start the pipeline and get state:

    ```cs
    /* The pipeline could be started when the state is paused */
    pipeline_handle.Start();
    var retState = pipeline_handle.State;
    ```

3. Stop the pipeline and get state:

    ```cs
    pipeline_handle.Stop();
    var retState = pipeline_handle.State;
    ```

4. Destroy the pipeline.

    When no longer needed, destroy the pipeline:

    ```cs
    pipeline_handle.Dispose();
    ```
