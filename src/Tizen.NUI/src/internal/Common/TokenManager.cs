/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal static class TokenManager
    {
        private static ITokenTable<UIColor> s_colorTable = new EmptyResourceTable<UIColor>();

        public static ITokenTable<UIColor> ColorTable => s_colorTable;

        public static void SetTable<T>(TokenType type, ITokenTable<T> table)
        {
            if (type == TokenType.Color && table is ITokenTable<UIColor> colorTable)
            {
                s_colorTable = colorTable;
            }
        }
    }
}
