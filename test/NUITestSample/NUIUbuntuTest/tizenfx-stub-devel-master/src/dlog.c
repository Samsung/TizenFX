/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#define _GNU_SOURCE
#include <stdio.h>
#include <stdarg.h>
#include <stdlib.h>
#include "dlog.h"


int dlog_print( log_priority prio, const char *tag, const char *fmt, ... )
{
  va_list arg;
  va_start(arg, fmt);
  int numChars = 0;

  char *format = NULL;
  if( asprintf(&format, "%s:\e[21m %s: %s\e[0m", prio==DLOG_INFO?"\e[1;34mINFO":prio==DLOG_WARN?"\e[1;33mWARN":prio==DLOG_ERROR?"\e[1;91mERROR":"", tag, fmt))
  {
    numChars = vfprintf(stderr, format, arg);
    free(format);
  }
  va_end(arg);
  return numChars;
}
