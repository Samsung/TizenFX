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

namespace Dali {

public class Position : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Position(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Position obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Position() {
    DisposeQueue.Instance.Add(this);
  }

  public virtual void Dispose() {
    if (!Window.IsInstalled()) {
      DisposeQueue.Instance.Add(this);
      return;
    }

    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_Vector3(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }


  public static Position operator+(Position arg1, Position arg2) {
    return arg1.Add(arg2);
  }

  public static Position operator-(Position arg1, Position arg2) {
    return arg1.Subtract(arg2);
  }

  public static Position operator-(Position arg1) {
    return arg1.Subtract();
  }

  public static Position operator*(Position arg1, Position arg2) {
    return arg1.Multiply(arg2);
  }

  public static Position operator*(Position arg1, float arg2) {
    return arg1.Multiply(arg2);
  }

  public static Position operator/(Position arg1, Position arg2) {
    return arg1.Divide(arg2);
  }

  public static Position operator/(Position arg1, float arg2) {
    return arg1.Divide(arg2);
  }


  public float this[uint index]
  {
    get
    {
      return ValueOfIndex(index);
    }
  }

  public static Position GetPositionFromPtr(global::System.IntPtr cPtr) {
    Position ret = new Position(cPtr, false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
       return ret;
  }


  public Position() : this(NDalicPINVOKE.new_Vector3__SWIG_0(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Position(float x, float y, float z) : this(NDalicPINVOKE.new_Vector3__SWIG_1(x, y, z), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Position(Position2D position2d) : this(NDalicPINVOKE.new_Vector3__SWIG_3(Position2D.getCPtr(position2d)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }



  private Position Add(Position rhs) {
    Position ret = new Position(NDalicPINVOKE.Vector3_Add(swigCPtr, Position.getCPtr(rhs)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position Subtract(Position rhs) {
    Position ret = new Position(NDalicPINVOKE.Vector3_Subtract__SWIG_0(swigCPtr, Position.getCPtr(rhs)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position Multiply(Position rhs) {
    Position ret = new Position(NDalicPINVOKE.Vector3_Multiply__SWIG_0(swigCPtr, Position.getCPtr(rhs)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position Multiply(float rhs) {
    Position ret = new Position(NDalicPINVOKE.Vector3_Multiply__SWIG_1(swigCPtr, rhs), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position Divide(Position rhs) {
    Position ret = new Position(NDalicPINVOKE.Vector3_Divide__SWIG_0(swigCPtr, Position.getCPtr(rhs)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position Divide(float rhs) {
    Position ret = new Position(NDalicPINVOKE.Vector3_Divide__SWIG_1(swigCPtr, rhs), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private Position Subtract() {
    Position ret = new Position(NDalicPINVOKE.Vector3_Subtract__SWIG_1(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private float ValueOfIndex(uint index) {
    float ret = NDalicPINVOKE.Vector3_ValueOfIndex__SWIG_0(swigCPtr, index);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool EqualTo(Position rhs) {
    bool ret = NDalicPINVOKE.Vector3_EqualTo(swigCPtr, Position.getCPtr(rhs));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool NotEqualTo(Position rhs) {
    bool ret = NDalicPINVOKE.Vector3_NotEqualTo(swigCPtr, Position.getCPtr(rhs));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  public float X {
    set {
      NDalicPINVOKE.Vector3_X_set(swigCPtr, value);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      float ret = NDalicPINVOKE.Vector3_X_get(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  public float Y {
    set {
      NDalicPINVOKE.Vector3_Y_set(swigCPtr, value);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      float ret = NDalicPINVOKE.Vector3_Y_get(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  public float Z {
    set {
      NDalicPINVOKE.Vector3_Z_set(swigCPtr, value);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      float ret = NDalicPINVOKE.Vector3_Z_get(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  internal static float ParentOriginTop
  {
      get
      {
          float ret = NDalicPINVOKE.ParentOriginTop_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float ParentOriginBottom
  {
      get
      {
          float ret = NDalicPINVOKE.ParentOriginBottom_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float ParentOriginLeft
  {
      get
      {
          float ret = NDalicPINVOKE.ParentOriginLeft_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float ParentOriginRight
  {
      get
      {
          float ret = NDalicPINVOKE.ParentOriginRight_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float ParentOriginMiddle
  {
      get
      {
          float ret = NDalicPINVOKE.ParentOriginMiddle_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginTopLeft
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopLeft_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginTopCenter
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopCenter_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginTopRight
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopRight_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginCenterLeft
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenterLeft_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginCenter
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenter_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginCenterRight
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenterRight_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginBottomLeft
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomLeft_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginBottomCenter
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomCenter_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position ParentOriginBottomRight
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomRight_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float AnchorPointTop
  {
      get
      {
          float ret = NDalicPINVOKE.AnchorPointTop_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float AnchorPointBottom
  {
      get
      {
          float ret = NDalicPINVOKE.AnchorPointBottom_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float AnchorPointLeft
  {
      get
      {
          float ret = NDalicPINVOKE.AnchorPointLeft_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float AnchorPointRight
  {
      get
      {
          float ret = NDalicPINVOKE.AnchorPointRight_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static float AnchorPointMiddle
  {
      get
      {
          float ret = NDalicPINVOKE.AnchorPointMiddle_get();
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointTopLeft
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopLeft_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointTopCenter
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopCenter_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointTopRight
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopRight_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointCenterLeft
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenterLeft_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointCenter
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenter_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointCenterRight
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenterRight_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointBottomLeft
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomLeft_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointBottomCenter
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomCenter_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  internal static Position AnchorPointBottomRight
  {
      get
      {
          global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomRight_get();
          Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
          if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
          return ret;
      }
  }

  public static Position One {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_ONE_get();
      Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  internal static Position XAxis {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_XAXIS_get();
      Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  internal static Position YAxis {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_YAXIS_get();
      Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  internal static Position ZAxis {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_ZAXIS_get();
      Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  internal static Position NegativeXAxis {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_XAXIS_get();
      Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  internal static Position NegativeYAxis {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_YAXIS_get();
      Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  internal static Position NegativeZAxis {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_ZAXIS_get();
      Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  public static Position Zero {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_ZERO_get();
      Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  public static implicit operator Vector3(Position Position)
  {
    return new Vector3(Position.X, Position.Y, Position.Z);
  }

  public static implicit operator Position(Vector3 vec)
  {
    return new Position(vec.X, vec.Y, vec.Z);
  }

}

  public struct ParentOrigin
  {
      public static readonly float Top = Position.ParentOriginTop;
      public static readonly float Bottom = Position.ParentOriginBottom;
      public static readonly float Left = Position.ParentOriginLeft;
      public static readonly float Right = Position.ParentOriginRight;
      public static readonly float Middle = Position.ParentOriginMiddle;
      public static readonly Position TopLeft = Position.ParentOriginTopLeft;
      public static readonly Position TopCenter = Position.ParentOriginTopCenter;
      public static readonly Position TopRight = Position.ParentOriginTopRight;
      public static readonly Position CenterLeft = Position.ParentOriginCenterLeft;
      public static readonly Position Center = Position.ParentOriginCenter;
      public static readonly Position CenterRight = Position.ParentOriginCenterRight;
      public static readonly Position BottomLeft = Position.ParentOriginBottomLeft;
      public static readonly Position BottomCenter = Position.ParentOriginBottomCenter;
      public static readonly Position BottomRight = Position.ParentOriginBottomRight;
  }
  public struct AnchorPoint
  {
      public static readonly float Top = Position.AnchorPointTop;
      public static readonly float Bottom = Position.AnchorPointBottom;
      public static readonly float Left = Position.AnchorPointLeft;
      public static readonly float Right = Position.AnchorPointRight;
      public static readonly float Middle = Position.AnchorPointMiddle;
      public static readonly Position TopLeft = Position.AnchorPointTopLeft;
      public static readonly Position TopCenter = Position.AnchorPointTopCenter;
      public static readonly Position TopRight = Position.AnchorPointTopRight;
      public static readonly Position CenterLeft = Position.AnchorPointCenterLeft;
      public static readonly Position Center = Position.AnchorPointCenter;
      public static readonly Position CenterRight = Position.AnchorPointCenterRight;
      public static readonly Position BottomLeft = Position.AnchorPointBottomLeft;
      public static readonly Position BottomCenter = Position.AnchorPointBottomCenter;
      public static readonly Position BottomRight = Position.AnchorPointBottomRight;
  }
  public struct PositionAxis
  {
      public static readonly Position X = Position.XAxis;
      public static readonly Position Y = Position.YAxis;
      public static readonly Position Z = Position.ZAxis;
      public static readonly Position NegativeX = Position.NegativeXAxis;
      public static readonly Position NegativeY = Position.NegativeYAxis;
      public static readonly Position NegativeZ = Position.NegativeZAxis;
  }

}


