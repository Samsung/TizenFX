/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    [Preserve(AllMembers = true)]
    internal class PerformanceProvider : IPerformanceProvider
    {
        internal class Statistic
        {
            public readonly List<Tuple<string, long>> StartTimes = new List<Tuple<string, long>>();
            public int CallCount;
            public long TotalTime;
            public bool IsDetail;
        }

        readonly Dictionary<string, Statistic> _Statistics = new Dictionary<string, Statistic>();

        public Dictionary<string, Statistic> Statistics {
            get { return _Statistics; }
        }

        public void Clear()
        {
            Statistics.Clear();
        }

        public void Start(string reference, string tag = null, [CallerFilePath] string path = null, [CallerMemberName] string member = null)
        {
            string id = GetId(tag, path, member);

            Statistic stats = GetStat(id);

            if (tag != null)
                stats.IsDetail = true;

            stats.CallCount++;
            stats.StartTimes.Add(new Tuple<string, long>(reference, Stopwatch.GetTimestamp()));
        }

        public void Stop(string reference, string tag = null, [CallerFilePath] string path = null, [CallerMemberName] string member = null)
        {
            string id = GetId(tag, path, member);
            long stop = Stopwatch.GetTimestamp();

            Statistic stats = GetStat(id);

            if (!stats.StartTimes.Any())
                return;

            long start = stats.StartTimes.Single(s => s.Item1 == reference).Item2;
            stats.TotalTime += stop - start;
        }

        public IEnumerable<string> GetStats()
        {
            yield return "ID                                                                                 | Call Count | Total Time | Avg Time";
            foreach (KeyValuePair<string, Statistic> kvp in Statistics.OrderBy(kvp => kvp.Key)) {
                string key = ShortenPath(kvp.Key);
                double total = TimeSpan.FromTicks(kvp.Value.TotalTime).TotalMilliseconds;
                double avg = total / kvp.Value.CallCount;
                yield return string.Format("{0,-80} | {1,-10} | {2,-10}ms | {3,-8}ms", key, kvp.Value.CallCount, total, avg);
            }
        }

        static string ShortenPath(string path)
        {
            int index = path.IndexOf("Tizen.NUI.Xaml.");
            if (index > -1)
                path = path.Substring(index + 14);

            return path;
        }

        static string GetId(string tag, string path, string member)
        {
            return string.Format("{0}:{1}{2}", path, member, (tag != null ? "-" + tag : string.Empty));
        }

        Statistic GetStat(string id)
        {
            Statistic stats;
            if (!Statistics.TryGetValue(id, out stats)) {
                Statistics[id] = stats = new Statistic();
            }
            return stats;
        }
    }
}
 
