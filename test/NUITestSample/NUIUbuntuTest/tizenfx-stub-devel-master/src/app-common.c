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


#include <linux/limits.h>
#define _GNU_SOURCE
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#define TIZEN_PATH_MAX PATH_MAX


typedef enum
{
  APP_RESOURCE_TYPE_IMAGE = 0, /**<Image*/
  APP_RESOURCE_TYPE_LAYOUT, /**<Edje*/
  APP_RESOURCE_TYPE_SOUND, /**<Sound*/
  APP_RESOURCE_TYPE_BIN, /**<Bin*/
  APP_RESOURCE_TYPE_MIN = APP_RESOURCE_TYPE_IMAGE,
  APP_RESOURCE_TYPE_MAX = APP_RESOURCE_TYPE_BIN,
} app_resource_e;

typedef enum
{
  APP_DEVICE_ORIENTATION_0 = 0, /**< The device is oriented in a natural position */
  APP_DEVICE_ORIENTATION_90 = 90, /**< The device's left side is at the top */
  APP_DEVICE_ORIENTATION_180 = 180, /**< The device is upside down */
  APP_DEVICE_ORIENTATION_270 = 270, /**< The device's right side is at the top */
} app_device_orientation_e;

typedef enum
{
  APP_EVENT_LOW_MEMORY, /**< The low memory event */
  APP_EVENT_LOW_BATTERY, /**< The low battery event */
  APP_EVENT_LANGUAGE_CHANGED, /**< The system language changed event */
  APP_EVENT_DEVICE_ORIENTATION_CHANGED, /**< The device orientation changed event */
  APP_EVENT_REGION_FORMAT_CHANGED, /**< The region format changed event */
  APP_EVENT_SUSPENDED_STATE_CHANGED, /**< The suspended state changed event of the application*/
  APP_EVENT_UPDATE_REQUESTED, /**< The update requested event (Since 3.0)*/
} app_event_type_e;

typedef enum
{
  APP_ERROR_NONE = 0,
  APP_ERROR_INVALID_PARAMETER,
  APP_ERROR_OUT_OF_MEMORY,
  APP_ERROR_INVALID_CONTEXT,
  APP_ERROR_NO_SUCH_FILE,
  APP_ERROR_NOT_SUPPORTED,
  APP_ERROR_ALREADY_RUNNING,
  APP_ERROR_PERMISSION_DENIED
} app_error_e;

typedef enum
{
  APP_EVENT_LOW_MEMORY_NORMAL = 0x01, /**< Normal status */
  APP_EVENT_LOW_MEMORY_SOFT_WARNING = 0x02, /**< Soft warning status */
  APP_EVENT_LOW_MEMORY_HARD_WARNING = 0x04, /**< Hard warning status */
} app_event_low_memory_status_e;

typedef enum
{
  APP_EVENT_LOW_BATTERY_POWER_OFF = 1, /**< The battery status is under 1% */
  APP_EVENT_LOW_BATTERY_CRITICAL_LOW, /**< The battery status is under 5% */
} app_event_low_battery_status_e;

struct app_event_info
{
  app_event_type_e type;
  void *value;
};
typedef struct app_event_info *app_event_info_h;


int app_get_id(char **id)
{
  static char id_buf[TIZEN_PATH_MAX] = {'A','p','p','\0'};

  if( id != NULL )
  {
    *id = strdup(id_buf);
    return APP_ERROR_NONE;
  }
  return APP_ERROR_INVALID_PARAMETER;
}

int app_get_name(char **name)
{
  static char namebuf[TIZEN_PATH_MAX] = {'A','p','p','\0'};
  if( name != NULL )
  {
    *name = strdup(namebuf);
  }
  return APP_ERROR_INVALID_PARAMETER;
}

char* app_get_resource_path(void)
{
  const char* path=getenv("DESKTOP_PREFIX");
  char* out;
  int numChars = asprintf( &out, "%s/share/app", path );
  return out;
}

char* app_get_data_path(void)
{
  return app_get_resource_path();
}

char* app_get_cache_path(void)
{
  return app_get_resource_path();
}

char* app_get_shared_data_path(void)
{
  return app_get_resource_path();
}

char* app_get_shared_resource_path(void)
{
  return app_get_resource_path();
}

char* app_get_shared_trusted_path(void)
{
  return app_get_resource_path();
}

char* app_get_tep_resource_path(void)
{
  return app_get_resource_path();
}

char* app_get_external_cache_path(void)
{
  return app_get_resource_path();
}

char* app_get_external_data_path(void)
{
  return app_get_resource_path();
}

char* app_get_external_shared_data_path(void)
{
  return app_get_resource_path();
}

int app_get_version(char** version)
{
  *version = strdup("1.1.1");
  return APP_ERROR_NONE;
}

int app_event_get_low_memory_status(app_event_info_h event_info, app_event_low_memory_status_e *status)
{
  int ret;

  if (event_info == NULL || status == NULL)
    return APP_ERROR_INVALID_PARAMETER;

  if (event_info->type != APP_EVENT_LOW_MEMORY)
    return APP_ERROR_INVALID_PARAMETER;

  *status = APP_EVENT_LOW_MEMORY_NORMAL;
  return APP_ERROR_NONE;
}

int app_event_get_low_battery_status(app_event_info_h event_info, app_event_low_battery_status_e *status)
{
  int ret;

  if (event_info == NULL || status == NULL)
    return APP_ERROR_INVALID_PARAMETER;

  if (event_info->type != APP_EVENT_LOW_BATTERY)
    return APP_ERROR_INVALID_PARAMETER;

  *status = APP_EVENT_LOW_BATTERY_CRITICAL_LOW;;
  return APP_ERROR_NONE;
}

int app_event_get_language(app_event_info_h event_info, char **lang)
{
  if (event_info == NULL || event_info->value == NULL || lang == NULL)
    return APP_ERROR_INVALID_PARAMETER;

  if (event_info->type != APP_EVENT_LANGUAGE_CHANGED)
    return APP_ERROR_INVALID_CONTEXT;

  *lang = strdup( (const char*)event_info->value );

  return APP_ERROR_NONE;
}

int app_event_get_region_format(app_event_info_h event_info, char **region)
{
  if (event_info == NULL || event_info->value == NULL || region == NULL)
    return APP_ERROR_INVALID_PARAMETER;

  if (event_info->type != APP_EVENT_REGION_FORMAT_CHANGED)
    return APP_ERROR_INVALID_CONTEXT;

  *region = strdup((const char*)event_info->value);

  return APP_ERROR_NONE;
}

int app_resource_manager_get(app_resource_e type, const char *id, char **path)
{
  *path=strdup("/tmp/a");
  return APP_ERROR_NONE;
}

int app_event_get_device_orientation(app_event_info_h event_info, app_device_orientation_e *orientation)
{
  if (event_info == NULL || orientation == NULL)
    return APP_ERROR_INVALID_PARAMETER;

  if (event_info->type != APP_EVENT_DEVICE_ORIENTATION_CHANGED)
    return APP_ERROR_INVALID_CONTEXT;

  *orientation = APP_DEVICE_ORIENTATION_0;

  return APP_ERROR_NONE;
}
