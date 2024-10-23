/*
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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public class PageManager
    {
        private List<Page> pages;
        private int currentPageIndex = 0;

        public PageManager()
        {
            pages = new List<Page>();
        }

        public void AddPage(Page newPage)
        {
            pages.Add(newPage);
        }

        public Page GetCurrentPage()
        {
            if (currentPageIndex >= 0 && currentPageIndex < pages.Count)
            {
                return pages[currentPageIndex];
            }
            return null;
        }

        public void SetCurrentPage(int pageIndex)
        {
            if (pageIndex >= 0 && pageIndex < pages.Count)
            {
                currentPageIndex = pageIndex;
                // 페이지 변경 시 추가 동작이 필요하면 처리
            }
        }

        public void RemovePage(int pageIndex)
        {
            if (pageIndex >= 0 && pageIndex < pages.Count)
            {
                pages.RemoveAt(pageIndex);
                currentPageIndex = Math.Min(currentPageIndex, pages.Count - 1);  // 인덱스가 초과되지 않도록 조정
            }
        }
    }
}