---
# Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
#
# Licensed under the Apache License, Version 2.0 (the License);
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

uid: Tizen.Core
summary: Tizen Core (TCore) is a new main loop model that provides per thread loops, message and event transmission, uniquely named threads.
remarks: *content
---
## Overview
Tizen Core (TCore) is a new main loop that improves the existing main loop model. It supports creating and running the main loop in multiple threads. Tizen Core provides an API that supports secure communication between threads.

## Preparation
To use the Tizen Core API, you must define `using Tizen.Core`, as shown below:
```cs
using Tizen.Core;
```

## Initializing Tizen Core
Before using Tizen Core, Calls TizenCore.Initialize() as shown below:
```cs
TizenCore.Initialize();
```

## Shutting down Tizen Core
When Tizen Core is no longer needed, shut down Tizen Core with the code below:
```cs
TizenCore.Shutdown();
```

## Managing Tizen Core tasks
This section will cover creating, executing, and terminating the CoreTask objects, It will also cover adding idle jobs and timers to the main loop.

### Creating a task
Here` an example on how to create a Task object:
```cs
{
  TizenCore.Initialize();
  var task = new Task("task1");
}
```
`task` was created with the name "task1" and configured to use its own thread. The created `task` instance should be removed using `Dispose()` method when it is no longer needed.

### Running a task
In this example, we'll cover the code to execute a previously created task:
```cs
{
   task.Run();
}
```
`task` creates and runs a thread named "task1". After calling `Run()` method, the thread is created and the loop starts running.

### Checking if a task is running
An example of checking if a task is running using `Running` property:
```cs
{
   if (task.Running)
   {
      Log.Debug(LogTag, "task1 is running");
   }
   else
   {
      Log.Debug(LogTag, "task1 is not running");
   }
}
```

### Adding an timer job to Tizen Core
Here's an example of registering a timer that calls the handler every 100 ms.
```cs
{
   var timerId = task.AddTimer(100, () => {
      Log.Debug(LogTag, "timer handler is invoked");
   });
}
```

### Adding an action to Tizen Core
Let'w write an example that adds an action to `Task`.
```cs
{
   var task = TizenCore.Find("Test") ?? TizenCore.Spawn("Test");
   task.Post(() => {
      Log.Debug(LogTag, "Action is invoked");
   });
}
```
