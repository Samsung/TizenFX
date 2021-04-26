/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Binding;

namespace Tizen.NUI.EXaml
{
    internal class GetValueAction : Action
    {
        public GetValueAction(char sign, Action parent)
        {
            this.sign = sign;
            this.parent = parent;
        }

        private char sign;
        private Action parent;

        private delegate object GetValueByString(string value);

        private static GetValueByString[] getValueByStrings = null;
        private static GetValueByString[] GetValueByStrings
        {
            get
            {
                if (null == getValueByStrings)
                {
                    getValueByStrings = new GetValueByString['p' - 'a' + 2];

                    getValueByStrings[0] = (string value) =>
                    {
                        return value;
                    };

                    //'a' -> 1 Ojbect
                    getValueByStrings[1] = (string value) =>
                    {
                        int index = int.Parse(value);
                        return new Instance(index);
                    };

                    //b SByte
                    getValueByStrings[2] = (string value) =>
                    {
                        return SByte.Parse(value);
                    };

                    //c Int16
                    getValueByStrings[3] = (string value) =>
                    {
                        return Int16.Parse(value);
                    };

                    //d Int32
                    getValueByStrings[4] = (string value) =>
                    {
                        return Int32.Parse(value);
                    };

                    //e Int64
                    getValueByStrings[5] = (string value) =>
                    {
                        return Int64.Parse(value);
                    };

                    //f Byte
                    getValueByStrings[6] = (string value) =>
                    {
                        return Byte.Parse(value);
                    };

                    //g UInt16
                    getValueByStrings[7] = (string value) =>
                    {
                        return UInt16.Parse(value);
                    };

                    //h UInt32
                    getValueByStrings[8] = (string value) =>
                    {
                        return UInt32.Parse(value);
                    };

                    //i UInt64
                    getValueByStrings[9] = (string value) =>
                    {
                        return UInt64.Parse(value);
                    };

                    //j Single
                    getValueByStrings[10] = (string value) =>
                    {
                        return Single.Parse(value);
                    };

                    //k Double
                    getValueByStrings[11] = (string value) =>
                    {
                        return Double.Parse(value);
                    };

                    //l Boolean
                    getValueByStrings[12] = (string value) =>
                    {
                        return Boolean.Parse(value);
                    };

                    //m TimeSpan
                    getValueByStrings[13] = (string value) =>
                    {
                        return TimeSpan.Parse(value);
                    };

                    //n decimal
                    getValueByStrings[14] = (string value) =>
                    {
                        return decimal.Parse(value);
                    };

                    //o enum
                    getValueByStrings[15] = (string value) =>
                    {
                        //Should be deal prev
                        return null;
                    };
                }

                return getValueByStrings;
            }
        }

        public Action DealChar(char c)
        {
            if (c == sign)
            {
                switch (sign)
                {
                    case '\"':
                        Value = GetValueByStrings[0](valueString);
                        break;

                    case 'z':
                        Value = null;
                        break;

                    default:
                        Value = GetValueByStrings[c - 'a' + 1](valueString);
                        break;
                }

                parent?.OnActive();
                return parent;
            }

            if ('\"' != sign)
            {
                switch (c)
                {
                    case ' ':
                    case '\n':
                    case '\r':
                        return this;

                    case '(':
                        getValueList = new GetValueListAction(')', this);
                        return getValueList;
                }
            }

            valueString += c;

            return this;
        }

        private string valueString;

        private GetValueListAction getValueList;

        public object Value
        {
            get;
            private set;
        }

        public void Init()
        {
            valueString = "";
        }

        public void OnActive()
        {
        }
    }
}
