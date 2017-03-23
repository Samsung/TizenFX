/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI {

public class Position2D : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Position2D(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Position2D obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Position2D() {
    DisposeQueue.Instance.Add(this);
  }

  public virtual void Dispose() {
    if (!Stage.IsInstalled()) {
      DisposeQueue.Instance.Add(this);
      return;
    }

    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_Vector2(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }


  public static Position2D operator+(Position2D arg1, Position2D arg2) {
    return arg1.Add(arg2);
  }

  public static Position2D operator-(Position2D arg1, Position2D arg2) {
    return arg1.Subtract(arg2);
  }

  public static Position2D operator-(Position2D arg1) {
    return arg1.Subtract();
  }

  public static Position2D operator*(Position2D arg1, Position2D arg2) {
    return arg1.Multiply(arg2);
  }

  public static Position2D operator*(Position2D arg1, int arg2) {
    return arg1.Multiply(arg2);
  }

  public static Position2D operator/(Position2D arg1, Position2D arg2) {
    return arg1.Divide(arg2);
  }

  public static Position2D operator/(Position2D arg1, int arg2) {
    return arg1.Divide(arg2);
  }

  public float this[uint index]
  {
    get
    {
      return ValueOfIndex(index);
    }
  }

  internal static Position2D GetPosition2DFromPtr(global::System.IntPtr cPtr) {
    Position2D ret = new Position2D(cPtr, false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
       return ret;
  }


  public Position2D() : this(NDalicPINVOKE.new_Vector2__SWIG_0(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Position2D(int x, int y) : this(NDalicPINVOKE.new_Vector2__SWIG_1((float)x, (float)y), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Position2D(Position position) : this(NDalicPINVOKE.new_Vector2__SWIG_3(Position.getCPtr(position)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  private Position2D Add(Position2D rhs) {
    Position2D ret = new Position2D(NDalicPINVOKE.Vector2_Add(swigCPtr, Position2D.getCPtr(rhs)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position2D Subtract(Position2D rhs) {
    Position2D ret = new Position2D(NDalicPINVOKE.Vector2_Subtract__SWIG_0(swigCPtr, Position2D.getCPtr(rhs)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  private Position2D Multiply(Position2D rhs) {
    Position2D ret = new Position2D(NDalicPINVOKE.Vector2_Multiply__SWIG_0(swigCPtr, Position2D.getCPtr(rhs)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position2D Multiply(int rhs) {
    Position2D ret = new Position2D(NDalicPINVOKE.Vector2_Multiply__SWIG_1(swigCPtr, (float)rhs), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  private Position2D Divide(Position2D rhs) {
    Position2D ret = new Position2D(NDalicPINVOKE.Vector2_Divide__SWIG_0(swigCPtr, Position2D.getCPtr(rhs)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position2D Divide(int rhs) {
    Position2D ret = new Position2D(NDalicPINVOKE.Vector2_Divide__SWIG_1(swigCPtr, (float)rhs), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position2D Subtract() {
    Position2D ret = new Position2D(NDalicPINVOKE.Vector2_Subtract__SWIG_1(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool EqualTo(Position2D rhs) {
    bool ret = NDalicPINVOKE.Vector2_EqualTo(swigCPtr, Position2D.getCPtr(rhs));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool NotEqualTo(Position2D rhs) {
    bool ret = NDalicPINVOKE.Vector2_NotEqualTo(swigCPtr, Position2D.getCPtr(rhs));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private int ValueOfIndex(uint index) {
    int ret = (int)NDalicPINVOKE.Vector2_ValueOfIndex__SWIG_0(swigCPtr, index);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  public int X {
    set {
      NDalicPINVOKE.Vector2_X_set(swigCPtr, (float)value);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      float ret = NDalicPINVOKE.Vector2_X_get(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return (int)ret;
    }
  }

  public int Y {
    set {
      NDalicPINVOKE.Vector2_Y_set(swigCPtr, (float)value);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      float ret = NDalicPINVOKE.Vector2_Y_get(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return (int)ret;
    }
  }

  public static implicit operator Vector2(Position2D position2d)
  {
    return new Vector2((float)position2d.X, (float)position2d.Y);
  }

  public static implicit operator Position2D(Vector2 vec)
  {
    return new Position2D((int)vec.X, (int)vec.Y);
  }

}

}


