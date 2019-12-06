/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class BundledPipe : global::System.IDisposable
    {
        private class Pipe
        {
            private BindableObject srcObj;
            private BindableObject destObj;

            private BindableProperty srcProperty;
            private BindableProperty destProperty;

            public Pipe(BindableObject srcObj, BindableProperty srcProperty, BindableObject destObj, BindableProperty destProperty, BindingDirection bindingDirection)
            {
                if (null == srcObj || null == destObj)
                {
                    throw (new global::System.Exception("Src obj and dest obj can't be null"));
                }

                if (null == srcProperty || null == destProperty)
                {
                    throw (new global::System.Exception("Src property and dest property can't be null"));
                }

                this.srcObj = srcObj;
                this.destObj = destObj;

                this.srcProperty = srcProperty;
                this.destProperty = destProperty;

                srcObj.ListenPropertyChange(srcProperty, SrcObjPropertyChanged);

                if (BindingDirection.TwoWay == bindingDirection)
                {
                    destObj.ListenPropertyChange(destProperty, DestObjPropertyChanged);
                }
            }

            public void Clear()
            {
                srcObj.RemovePropertyChangeListener(srcProperty, SrcObjPropertyChanged);
                destObj.RemovePropertyChangeListener(destProperty, DestObjPropertyChanged);
            }

            private void DestObjPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (CurrentSetDirection.NoSet == currentSetDirection)
                {
                    currentSetDirection = CurrentSetDirection.DestToSrc;

                    object value = destObj.GetValue(destProperty);
                    srcProperty.PropertyChanged?.Invoke(srcObj, null, value);

                    currentSetDirection = CurrentSetDirection.NoSet;
                }
            }

            private void SrcObjPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (CurrentSetDirection.NoSet == currentSetDirection)
                {
                    currentSetDirection = CurrentSetDirection.SrcToDest;

                    object value = srcObj.GetValue(srcProperty);
                    destProperty.PropertyChanged?.Invoke(destObj, null, value);

                    currentSetDirection = CurrentSetDirection.NoSet;
                }
            }

            private CurrentSetDirection currentSetDirection = CurrentSetDirection.NoSet;
        }

        internal void Bind(BindableObject srcObj, BindableProperty srcProperty, BindableObject destObj, BindableProperty destProperty, BindingDirection bindingDirection)
        {
            if (null == srcObj || null == destObj)
            {
                throw (new global::System.Exception("Src obj and dest obj can't be null"));
            }

            if (null == srcProperty || null == destProperty)
            {
                throw (new global::System.Exception("Src property and dest property can't be null"));
            }

            if (!srcProperty.PropertyName.Equals(destProperty.PropertyName))
            {
                throw (new global::System.Exception("Src property is not same to dest property"));
            }

            Pipe pipe = new Pipe(srcObj, srcProperty, destObj, destProperty, bindingDirection);
            pipes.Add(pipe);
        }

        public void Dispose()
        {
            Clear();
        }

        public void Clear()
        {
            foreach (Pipe pipe in pipes)
            {
                pipe.Clear();
            }

            pipes.Clear();
        }

        private List<Pipe> pipes = new List<Pipe>();

        private enum CurrentSetDirection
        {
            NoSet = 0,
            SrcToDest,
            DestToSrc
        }
    }
}
