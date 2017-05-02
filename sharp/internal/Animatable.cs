/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

namespace Dali {

public class Animatable : BaseHandle {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal Animatable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Handle_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Animatable obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Animatable() {
    DisposeQueue.Instance.Add(this);
  }

  public override void Dispose() {
    if (!Window.IsInstalled()) {
      DisposeQueue.Instance.Add(this);
      return;
    }

    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_Handle(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }


  public Animatable () : this (NDalicPINVOKE.Handle_New(), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public Animatable(Animatable handle) : this(NDalicPINVOKE.new_Handle__SWIG_1(Animatable.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Supports(Animatable.Capability capability) {
    bool ret = NDalicPINVOKE.Handle_Supports(swigCPtr, (int)capability);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public uint GetPropertyCount() {
    uint ret = NDalicPINVOKE.Handle_GetPropertyCount(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetPropertyName(int index) {
    string ret = NDalicPINVOKE.Handle_GetPropertyName(swigCPtr, index);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetPropertyIndex(string name) {
    int ret = NDalicPINVOKE.Handle_GetPropertyIndex(swigCPtr, name);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsPropertyWritable(int index) {
    bool ret = NDalicPINVOKE.Handle_IsPropertyWritable(swigCPtr, index);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsPropertyAnimatable(int index) {
    bool ret = NDalicPINVOKE.Handle_IsPropertyAnimatable(swigCPtr, index);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsPropertyAConstraintInput(int index) {
    bool ret = NDalicPINVOKE.Handle_IsPropertyAConstraintInput(swigCPtr, index);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Property.Type GetPropertyType(int index) {
    Property.Type ret = (Property.Type)NDalicPINVOKE.Handle_GetPropertyType(swigCPtr, index);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetProperty(int index, Property.Value propertyValue)
  {
    Dali.Object.SetProperty( swigCPtr, index, propertyValue );
  }

  public int RegisterProperty(string name, Property.Value propertyValue) {
    int ret = NDalicPINVOKE.Handle_RegisterProperty__SWIG_0(swigCPtr, name, Property.Value.getCPtr(propertyValue));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int RegisterProperty(string name, Property.Value propertyValue, Property.AccessMode accessMode) {
    int ret = NDalicPINVOKE.Handle_RegisterProperty__SWIG_1(swigCPtr, name, Property.Value.getCPtr(propertyValue), (int)accessMode);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Property.Value GetProperty(int index)
  {
    Property.Value ret = Dali.Object.GetProperty( swigCPtr, index );
    return ret;
  }

  public void GetPropertyIndices(VectorInteger indices) {
    NDalicPINVOKE.Handle_GetPropertyIndices(swigCPtr, VectorInteger.getCPtr(indices));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public PropertyNotification AddPropertyNotification(int index, PropertyCondition condition) {
    PropertyNotification ret = new PropertyNotification(NDalicPINVOKE.Handle_AddPropertyNotification__SWIG_0(swigCPtr, index, PropertyCondition.getCPtr(condition)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public PropertyNotification AddPropertyNotification(int index, int componentIndex, PropertyCondition condition) {
    PropertyNotification ret = new PropertyNotification(NDalicPINVOKE.Handle_AddPropertyNotification__SWIG_1(swigCPtr, index, componentIndex, PropertyCondition.getCPtr(condition)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void RemovePropertyNotification(PropertyNotification propertyNotification) {
    NDalicPINVOKE.Handle_RemovePropertyNotification(swigCPtr, PropertyNotification.getCPtr(propertyNotification));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemovePropertyNotifications() {
    NDalicPINVOKE.Handle_RemovePropertyNotifications(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveConstraints() {
    NDalicPINVOKE.Handle_RemoveConstraints__SWIG_0(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveConstraints(uint tag) {
    NDalicPINVOKE.Handle_RemoveConstraints__SWIG_1(swigCPtr, tag);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public enum Capability {
    DYNAMIC_PROPERTIES = 0x01
  }

}

}
