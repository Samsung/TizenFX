﻿/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.AIAvatar
{
    internal struct UtteranceText : IEquatable<UtteranceText>
    {
        private string text;
        private int uttID;

        public string Text { get => text; set => text = value; }
        public int UttID { get => uttID; set => uttID = value; }

        public override bool Equals(object obj) => obj is VoiceInfo other && this.Equals(other);

        public bool Equals(UtteranceText other) => Text == other.Text && UttID == other.UttID;

        public static bool operator ==(UtteranceText lhsUtternaceText, UtteranceText rhsUtternaceText) => lhsUtternaceText.Equals(rhsUtternaceText);

        public static bool operator !=(UtteranceText lhsUtternaceText, UtteranceText rhsVoiceInfo) => !lhsUtternaceText.Equals(rhsVoiceInfo);

        public override int GetHashCode() => (Text, UttID).GetHashCode();
    }
}
