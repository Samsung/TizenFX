/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.MachineLearning.Inference
{
    /// <summary>
    /// The Pipeline class provides interfaces to create and execute stream pipelines with neural networks.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class Pipeline : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private IDictionary<string, NodeInfo> _nodeList;
        private Interop.Pipeline.StateChangedCallback _stateChangedCallback;

        /// <summary>
        /// Creates a new Pipeline instance with the given pipeline description
        /// </summary>
        /// <remarks>http://tizen.org/privilege/mediastorage is needed if pipeline description is relevant to media storage.</remarks>
        /// <remarks>http://tizen.org/privilege/externalstorage is needed if pipeline description is relevant to external storage.</remarks>
        /// <remarks>http://tizen.org/privilege/camera is needed if pipeline description accesses the camera device.</remarks>
        /// <remarks>http://tizen.org/privilege/recorder is needed if pipeline description accesses the recorder device.</remarks>
        /// <param name="description">The pipeline description. Refer to GStreamer manual or NNStreamer documentation for examples and the grammar.</param>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have the required privilege.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to the wrong pipeline description or internal error.</exception>
        /// <since_tizen> 8 </since_tizen>
        public Pipeline(string description)
        {
            NNStreamer.CheckNNStreamerSupport();

            if (string.IsNullOrEmpty(description))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "The pipeline description is invalid");

            _stateChangedCallback = (state, _) =>
            {
                StateChanged?.Invoke(this, new StateChangedEventArgs(state));
            };

            NNStreamerError ret = Interop.Pipeline.Construct(description, _stateChangedCallback, IntPtr.Zero, out _handle);
            NNStreamer.CheckException(ret, "Failed to create Pipeline instance");

            /* Init node list */
            _nodeList = new Dictionary<string, NodeInfo>();
        }

        /// <summary>
        /// Destructor of the Pipeline instance.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        ~Pipeline()
        {
            Dispose(false);
        }

        /// <summary>
        /// Internal method to get the native handle of pipeline.
        /// </summary>
        /// <returns>The native handle</returns>
        /// <since_tizen> 8 </since_tizen>
        internal IntPtr GetHandle()
        {
            return _handle;
        }

        /// <summary>
        /// The state of pipeline.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to get the pipeline state.</exception>
        /// <since_tizen> 8 </since_tizen>
        public PipelineState State
        {
            get
            {
                NNStreamer.CheckNNStreamerSupport();

                int state = 0;
                NNStreamerError ret = NNStreamerError.None;

                /* Check native handle is valid */
                if (_handle != IntPtr.Zero)
                {
                    ret = Interop.Pipeline.GetState(_handle, out state);
                    if (ret == NNStreamerError.None && state == 0)
                        ret = NNStreamerError.InvalidOperation;
                }
                else
                {
                    ret = NNStreamerError.InvalidOperation;
                }

                NNStreamer.CheckException(ret, "Failed to get the pipeline state because of internal error");
                return (PipelineState) state;
            }
        }

        /// <summary>
        /// Event to be invoked when the pipeline state is changed.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<StateChangedEventArgs> StateChanged;

        /// <summary>
        /// Starts the pipeline, asynchronously. (The state would be changed to PipelineState.Playing)
        /// </summary>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to start the pipeline.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Start()
        {
            NNStreamer.CheckNNStreamerSupport();

            NNStreamerError ret = Interop.Pipeline.Start(_handle);
            NNStreamer.CheckException(ret, "Failed to start the pipeline because of internal error");
        }

        /// <summary>
        /// Stops the pipeline, asynchronously. (The state would be changed to PipelineState.Paused)
        /// </summary>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed to stop the pipeline.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Stop()
        {
            NNStreamer.CheckNNStreamerSupport();

            NNStreamerError ret = Interop.Pipeline.Stop(_handle);
            NNStreamer.CheckException(ret, "Failed to stop the pipeline because of internal error");
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object including opened handle.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 8 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // release managed object
            }

            // release unmanaged objects
            if (_handle != IntPtr.Zero)
            {
                /* Note that, when destroying the pipeline, all node handles are released internally. */
                foreach (NodeInfo node in _nodeList.Values)
                    node.Valid = false;

                _nodeList.Clear();

                NNStreamerError ret = Interop.Pipeline.Destroy(_handle);
                if (ret != NNStreamerError.None)
                    Log.Error(NNStreamer.TAG, "Failed to destroy the pipeline handle");

                _handle = IntPtr.Zero;
            }

            _disposed = true;
        }

        /// <summary>
        /// Gets the sink node instance with given node name.
        /// </summary>
        /// <param name="name">The name of sink node</param>
        /// <returns>The sink node instance</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public SinkNode GetSink(string name)
        {
            NNStreamer.CheckNNStreamerSupport();

            /* Check the argument */
            if (string.IsNullOrEmpty(name))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Node name is invalid");

            SinkNode node;

            if (_nodeList.ContainsKey(name))
            {
                if (_nodeList[name].Type != NodeType.Sink)
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, name + " is not a sink node");

                node = (SinkNode) _nodeList[name];
            }
            else
            {
                node = new SinkNode(name, this);
                _nodeList.Add(name, node);
            }

            return node;
        }

        /// <summary>
        /// Gets the source node instance with given node name.
        /// </summary>
        /// <param name="name">The name of source node</param>
        /// <returns>The source node instance</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public SourceNode GetSource(string name)
        {
            NNStreamer.CheckNNStreamerSupport();

            /* Check the parameter */
            if (string.IsNullOrEmpty(name))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Node name is invalid");

            SourceNode node;

            if (_nodeList.ContainsKey(name))
            {
                if (_nodeList[name].Type != NodeType.Source)
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, name + " is not a source node");

                node = (SourceNode) _nodeList[name];
            }
            else
            {
                node = new SourceNode(name, this);
                _nodeList.Add(name, node);
            }

            return node;
        }

        /// <summary>
        /// Gets the valve node instance with given node name.
        /// </summary>
        /// <param name="name">The name of valve node</param>
        /// <returns>The valve node instance</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public ValveNode GetValve(string name)
        {
            NNStreamer.CheckNNStreamerSupport();

            /* Check the parameter */
            if (string.IsNullOrEmpty(name))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Node name is invalid");

            ValveNode node;

            if (_nodeList.ContainsKey(name))
            {
                if (_nodeList[name].Type != NodeType.Valve)
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, name + " is not a valve node");

                node = (ValveNode) _nodeList[name];
            }
            else
            {
                node = new ValveNode(name, this);
                _nodeList.Add(name, node);
            }

            return node;
        }

        /// <summary>
        /// Gets the switch node instance with given node name.
        /// </summary>
        /// <param name="name">The name of switch node.</param>
        /// <returns>The switch node instance</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public SwitchNode GetSwitch(string name)
        {
            NNStreamer.CheckNNStreamerSupport();

            /* Check the parameter */
            if (string.IsNullOrEmpty(name))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Node name is invalid");

            SwitchNode node;

            if (_nodeList.ContainsKey(name))
            {
                if (_nodeList[name].Type != NodeType.Switch)
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, name + " is not a switch node");

                node = (SwitchNode) _nodeList[name];
            }
            else
            {
                node = new SwitchNode(name, this);
                _nodeList.Add(name, node);
            }

            return node;
        }

        /// <summary>
        /// Gets the normal node instance with given node name.
        /// </summary>
        /// <param name="name">The name of normal node.</param>
        /// <returns>The normal node instance</returns>
        /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <since_tizen> 8 </since_tizen>
        public Node GetNormal(string name)
        {
            NNStreamer.CheckNNStreamerSupport();

            /* Check the parameter */
            if (string.IsNullOrEmpty(name))
                throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Node name is invalid");

            Node node;
            if (_nodeList.ContainsKey(name))
            {
                if (_nodeList[name].Type != NodeType.Normal)
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, name + " is not a normal node");

                node = (Node)_nodeList[name];
            }
            else
            {
                node = new Node(name, this);
                _nodeList.Add(name, node);
            }
            return node;
        }


        /// <summary>
        /// SwitchNode class to handle the switch node.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public class SwitchNode : NodeInfo
        {
            private SwitchType _type;

            internal SwitchNode(string name, Pipeline pipe) : base(NodeType.Switch, name, pipe)
            {
                IntPtr handle = IntPtr.Zero;

                NNStreamerError ret = Interop.Pipeline.GetSwitchHandle(pipe.GetHandle(), name, out _type, out handle);
                NNStreamer.CheckException(ret, "Failed to get the switch node handle: " + name);

                Handle = handle;
            }

            /// <summary>
            /// Selects input/output pad.
            /// </summary>
            /// <param name="padName">The pad name to be activated.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <exception cref="InvalidOperationException">Thrown when the node is invalid.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void Select(string padName)
            {
                if (string.IsNullOrEmpty(padName))
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Pad name is invalid");

                if (!Valid)
                    NNStreamer.CheckException(NNStreamerError.InvalidOperation, "Current node is invalid: " + Name);

                NNStreamerError ret = Interop.Pipeline.SelectSwitchPad(Handle, padName);
                NNStreamer.CheckException(ret, "Failed to select pad: " + padName);
            }
        }

        /// <summary>
        /// ValveNode class to handle the valve node.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public class ValveNode : NodeInfo
        {
            internal ValveNode(string name, Pipeline pipe) : base(NodeType.Valve, name, pipe)
            {
                IntPtr handle = IntPtr.Zero;

                NNStreamerError ret = Interop.Pipeline.GetValveHandle(pipe.GetHandle(), name, out handle);
                NNStreamer.CheckException(ret, "Failed to get the valve node handle: " + name);

                Handle = handle;
            }

            /// <summary>
            /// Controls the valve. Set the flag true to open (let the flow pass), false to close (stop the flow).
            /// </summary>
            /// <param name="open">The flag to control the flow</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="InvalidOperationException">Thrown when the node is invalid.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void Control(bool open)
            {
                if (!Valid)
                    NNStreamer.CheckException(NNStreamerError.InvalidOperation, "Current node is invalid: " + Name);

                NNStreamerError ret = Interop.Pipeline.OpenValve(Handle, open);
                NNStreamer.CheckException(ret, "Failed to set valve status: " + Name);
            }
        }

        /// <summary>
        /// SourceNode class to handle the source node.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public class SourceNode : NodeInfo
        {
            internal SourceNode(string name, Pipeline pipe) : base(NodeType.Source, name, pipe)
            {
                IntPtr handle = IntPtr.Zero;

                NNStreamerError ret = Interop.Pipeline.GetSrcHandle(pipe.GetHandle(), name, out handle);
                NNStreamer.CheckException(ret, "Failed to get the source node handle: " + name);

                Handle = handle;
            }

            /// <summary>
            /// Inputs tensor data to source node.
            /// </summary>
            /// <param name="data">The tensors data</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <exception cref="InvalidOperationException">Thrown when the node is invalid, or failed to input tensors data.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void Input(TensorsData data)
            {
                if (data == null)
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Given data is invalid");

                if (!Valid)
                    NNStreamer.CheckException(NNStreamerError.InvalidOperation, "Current node is invalid: " + Name);

                data.PrepareInvoke();

                NNStreamerError ret = Interop.Pipeline.InputSrcData(Handle, data.GetHandle(), PipelineBufferPolicy.NotFreed);
                NNStreamer.CheckException(ret, "Failed to input tensors data to source node: " + Name);
            }
        }

        /// <summary>
        /// SinkNode class to handle the sink node.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public class SinkNode : NodeInfo
        {
            private event EventHandler<DataReceivedEventArgs> _dataReceived;
            private Interop.Pipeline.NewDataCallback _dataCallback;

            internal SinkNode(string name, Pipeline pipe) : base(NodeType.Sink, name, pipe)
            {
                _dataCallback = (data_handle, Info_handle, _) =>
                {
                    if (Valid)
                    {
                        TensorsData data = TensorsData.CreateFromNativeHandle(data_handle, Info_handle, true, false);
                        _dataReceived?.Invoke(this, new DataReceivedEventArgs(data));
                    }
                };

                Register();
            }

            /// <summary>
            /// Event to be invoked when the sink node receives new data.
            /// </summary>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <exception cref="InvalidOperationException">Thrown when the node is invalid.</exception>
            /// <since_tizen> 8 </since_tizen>
            public event EventHandler<DataReceivedEventArgs> DataReceived
            {
                add
                {
                    if (value == null)
                        return;

                    if (!Valid)
                        NNStreamer.CheckException(NNStreamerError.InvalidOperation, "Current node is invalid: " + Name);

                    Register();
                    _dataReceived += value;
                }

                remove
                {
                    if (value == null)
                        return;

                    if (!Valid)
                        NNStreamer.CheckException(NNStreamerError.InvalidOperation, "Current node is invalid: " + Name);

                    _dataReceived -= value;

                    if (_dataReceived == null)
                        Unregister();
                }
            }

            private void Register()
            {
                if (Handle == IntPtr.Zero)
                {
                    IntPtr handle = IntPtr.Zero;

                    /* Register new data callback to sink node */
                    NNStreamerError ret = Interop.Pipeline.RegisterSinkCallback(Pipe.GetHandle(), Name, _dataCallback, IntPtr.Zero, out handle);
                    NNStreamer.CheckException(ret, "Failed to register sink node callback: " + Name);

                    Handle = handle;
                }
            }

            private void Unregister()
            {
                if (Handle != IntPtr.Zero)
                {
                    /* Unregister the data callback from sink node */
                    NNStreamerError ret = Interop.Pipeline.UnregisterSinkCallback(Handle);
                    NNStreamer.CheckException(ret, "Failed to unregister sink node callback: " + Name);

                    Handle = IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Node class to handle the properties of NNStreamer pipelines.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public class Node : NodeInfo
        {
            internal Node(string name, Pipeline pipe) : base(NodeType.Normal, name, pipe)
            {
                IntPtr handle = IntPtr.Zero;

                NNStreamerError ret = Interop.Pipeline.GetElementHandle(pipe.GetHandle(), name, out handle);
                NNStreamer.CheckException(ret, "Failed to get the pipeline node handle: " + name);

                Handle = handle;
            }
        }

        /// <summary>
        /// Node type of NNStreamer pipeline.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public enum NodeType
        {
            /// <summary>
            /// The source node.
            /// </summary>
            Source = 0,
            /// <summary>
            /// The sink node.
            /// </summary>
            Sink = 1,
            /// <summary>
            /// The valve node.
            /// </summary>
            Valve = 2,
            /// <summary>
            /// The switch node.
            /// </summary>
            Switch = 3,
            /// <summary>
            /// The normal node of the pipeline.
            /// </summary>
            Normal = 4,
        }

        /// <summary>
        /// NodeInfo class for node information in pipeline.
        /// Note that, node is depend on the pipeline. If the pipeline is closed, all the node information is invalid.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public abstract class NodeInfo
        {
            /// <summary>
            /// Creates a new NodeInfo instance with the given node information
            /// </summary>
            /// <param name="type">The node type.</param>
            /// <param name="name">The node name.</param>
            /// <param name="pipe">The Pipeline instance the node included.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <since_tizen> 8 </since_tizen>
            protected internal NodeInfo(NodeType type, string name, Pipeline pipe)
            {
                Pipe = pipe;
                Name = name;
                Type = type;
                Handle = IntPtr.Zero;
                Valid = true;
            }

            internal Pipeline Pipe { get; set; }
            internal IntPtr Handle { get; set; }

            /// <summary>
            /// The node type.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            public NodeType Type { get; internal set; }

            /// <summary>
            /// The node name.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            public string Name { get; internal set; }

            /// <summary>
            /// The flag to indicate valid state.
            /// </summary>
            /// <since_tizen> 8 </since_tizen>
            public bool Valid { get; internal set; }

            private void CheckGetParam(string propertyName)
            {
                NNStreamer.CheckNNStreamerSupport();

                if (string.IsNullOrEmpty(propertyName))
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Property name is invalid");
            }

            private void CheckSetParam(string propertyName, object value)
            {
                NNStreamer.CheckNNStreamerSupport();

                if (string.IsNullOrEmpty(propertyName))
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Property name is invalid");

                if (value is null)
                    throw NNStreamerExceptionFactory.CreateException(NNStreamerError.InvalidParameter, "Value is invalid");
            }

            /// <summary>
            /// Gets the boolean of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="retValue">On return, a boolean value.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void GetValue(string propertyName, out bool retValue)
            {
                CheckGetParam(propertyName);

                NNStreamerError ret = Interop.Pipeline.GetPropertyBool(Handle, propertyName, out int value);
                NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                retValue = value == 0 ? false : true;
            }

            /// <summary>
            /// Gets the string of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="retValue">On return, a string value.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void GetValue(string propertyName, out string retValue)
            {
                CheckGetParam(propertyName);

                NNStreamerError ret = Interop.Pipeline.GetPropertyString(Handle, propertyName, out string value);
                NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                retValue = value;
            }

            /// <summary>
            /// Gets the integer (i.e. System.Int32) of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="retValue">On return, a integer value.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void GetValue(string propertyName, out int retValue)
            {
                CheckGetParam(propertyName);

                NNStreamerError ret = Interop.Pipeline.GetPropertyInt32(Handle, propertyName, out int value);
                NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                retValue = value;
            }

            /// <summary>
            /// Gets the long integer (i.e. System.Int64) of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="retValue">On return, a long integer value.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void GetValue(string propertyName, out long retValue)
            {
                CheckGetParam(propertyName);

                NNStreamerError ret = Interop.Pipeline.GetPropertyInt64(Handle, propertyName, out long value);
                NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                retValue = value;
            }

            /// <summary>
            /// Gets the unsigned integer (i.e. System.UInt32) of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="retValue">On return, a unsigned integer value.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void GetValue(string propertyName, out uint retValue)
            {
                CheckGetParam(propertyName);

                NNStreamerError ret = Interop.Pipeline.GetPropertyUInt32(Handle, propertyName, out uint value);
                NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                retValue = value;
            }

            /// <summary>
            /// Gets the unsigned long integer (i.e. System.UInt64) of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="retValue">On return, a unsigned long integer value.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void GetValue(string propertyName, out ulong retValue)
            {
                CheckGetParam(propertyName);

                NNStreamerError ret = Interop.Pipeline.GetPropertyUInt64(Handle, propertyName, out ulong value);
                NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                retValue = value;
            }

            /// <summary>
            /// Gets the floating-point value of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="retValue">On return, a floating-point value.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void GetValue(string propertyName, out double retValue)
            {
                CheckGetParam(propertyName);

                NNStreamerError ret = Interop.Pipeline.GetPropertyDouble(Handle, propertyName, out double value);
                NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                retValue = value;
            }

            /// <summary>
            /// Get the value of node's property in NNStreamer pipelines.
            /// </summary>
            /// <typeparam name="T">The value type of given property.</typeparam>
            /// <param name="propertyName">The property name.</param>
            /// <returns>The value of given property.</returns>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public T GetValue<T>(string propertyName)
            {
                NNStreamerError ret;
                CheckGetParam(propertyName);

                if (typeof(bool).IsAssignableFrom(typeof(T)))
                {
                    ret = Interop.Pipeline.GetPropertyBool(Handle, propertyName, out int value);
                    NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                    return (T)Convert.ChangeType(value == 0 ? false : true, typeof(T));
                }
                else if (typeof(string).IsAssignableFrom(typeof(T)))
                {
                    ret = Interop.Pipeline.GetPropertyString(Handle, propertyName, out string value);
                    NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                    return (T)Convert.ChangeType(value, typeof(T));
                }
                else if (typeof(int).IsAssignableFrom(typeof(T)))
                {
                    ret = Interop.Pipeline.GetPropertyInt32(Handle, propertyName, out int value);
                    NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                    return (T)Convert.ChangeType(value, typeof(T));
                }
                else if (typeof(long).IsAssignableFrom(typeof(T)))
                {
                    ret = Interop.Pipeline.GetPropertyInt64(Handle, propertyName, out long value);
                    NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                    return (T)Convert.ChangeType(value, typeof(T));
                }
                else if (typeof(uint).IsAssignableFrom(typeof(T)))
                {
                    ret = Interop.Pipeline.GetPropertyUInt32(Handle, propertyName, out uint value);
                    NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                    return (T)Convert.ChangeType(value, typeof(T));
                }
                else if (typeof(ulong).IsAssignableFrom(typeof(T)))
                {
                    ret = Interop.Pipeline.GetPropertyUInt64(Handle, propertyName, out ulong value);
                    NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                    return (T)Convert.ChangeType(value, typeof(T));
                }
                else if (typeof(double).IsAssignableFrom(typeof(T)))
                {
                    ret = Interop.Pipeline.GetPropertyDouble(Handle, propertyName, out double value);
                    NNStreamer.CheckException(ret, string.Format("Failed to get {0} property.", propertyName));

                    return (T)Convert.ChangeType(value, typeof(T));
                }

                throw new ArgumentException("The Input data type is not valid.");
            }

            /// <summary>
            /// Sets the boolean of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="value">The boolean value of given property.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void SetValue(string propertyName, bool value)
            {
                CheckSetParam(propertyName, value);
                int setValue = value ? 1 : 0;

                NNStreamerError ret = Interop.Pipeline.SetPropertyBool(Handle, propertyName, setValue);
                NNStreamer.CheckException(ret, string.Format("Failed to set {0} property.", propertyName));
            }

            /// <summary>
            /// Sets the string of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="value">The string of given property.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void SetValue(string propertyName, string value)
            {
                CheckSetParam(propertyName, value);

                NNStreamerError ret = Interop.Pipeline.SetPropertyString(Handle, propertyName, value);
                NNStreamer.CheckException(ret, string.Format("Failed to set {0} property.", propertyName));
            }

            /// <summary>
            /// Sets the integer (i.e. System.Int32) of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="value">The integer value of given property.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void SetValue(string propertyName, int value)
            {
                CheckSetParam(propertyName, value);

                NNStreamerError ret = Interop.Pipeline.SetPropertyInt32(Handle, propertyName, value);
                NNStreamer.CheckException(ret, string.Format("Failed to set {0} property.", propertyName));
            }

            /// <summary>
            /// Sets the long integer (i.e. System.Int64) of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="value">The long integer value of given property.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void SetValue(string propertyName, long value)
            {
                CheckSetParam(propertyName, value);

                NNStreamerError ret = Interop.Pipeline.SetPropertyInt64(Handle, propertyName, value);
                NNStreamer.CheckException(ret, string.Format("Failed to set {0} property.", propertyName));
            }

            /// <summary>
            /// Sets the unsigned integer (i.e. System.UInt32) of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="value">The unsigned integer value of given property.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void SetValue(string propertyName, uint value)
            {
                CheckSetParam(propertyName, value);

                NNStreamerError ret = Interop.Pipeline.SetPropertyUInt32(Handle, propertyName, value);
                NNStreamer.CheckException(ret, string.Format("Failed to set {0} property.", propertyName));
            }

            /// <summary>
            /// Sets the unsigned long integer (i.e. System.UInt64) of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="value">The unsigned long integer value of given property.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void SetValue(string propertyName, ulong value)
            {
                CheckSetParam(propertyName, value);

                NNStreamerError ret = Interop.Pipeline.SetPropertyUInt64(Handle, propertyName, value);
                NNStreamer.CheckException(ret, string.Format("Failed to set {0} property.", propertyName));
            }

            /// <summary>
            /// Gets the floating-point value of node's property in NNStreamer pipelines.
            /// </summary>
            /// <param name="propertyName">The property name.</param>
            /// <param name="value">The floating-point value of given property.</param>
            /// <feature>http://tizen.org/feature/machine_learning.inference</feature>
            /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
            /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
            /// <since_tizen> 8 </since_tizen>
            public void SetValue(string propertyName, double value)
            {
                CheckSetParam(propertyName, value);

                NNStreamerError ret = Interop.Pipeline.SetPropertyDouble(Handle, propertyName, value);
                NNStreamer.CheckException(ret, string.Format("Failed to set {0} property.", propertyName));
            }
        }
    }
}
