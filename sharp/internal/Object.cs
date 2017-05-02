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

/**
 * Static Helper class for Property
 * Internal
 */

namespace Dali
{

public static class Object
{
  public static Property.Value GetProperty(global::System.Runtime.InteropServices.HandleRef handle, int index) {
    Property.Value ret = new Property.Value(NDalicPINVOKE.Handle_GetProperty(handle, index), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static void SetProperty( global::System.Runtime.InteropServices.HandleRef handle, int index, Property.Value propertyValue)
  {
    NDalicPINVOKE.Handle_SetProperty(handle, index, Property.Value.getCPtr(propertyValue));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }
}

}
