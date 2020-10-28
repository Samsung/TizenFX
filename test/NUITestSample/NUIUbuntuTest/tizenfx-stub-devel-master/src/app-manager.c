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

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <pthread.h>
#include "app_manager_internal.h"


struct app_context_s
{
  char *app_id;
  pid_t pid;
  char *pkg_id;
  app_state_e app_state;
  bool is_sub_app;
  char *instance_id;
};

typedef struct _foreach_context_
{
  app_manager_app_context_cb callback;
  void *user_data;
  bool iteration;
} foreach_context_s;

typedef struct _retrieval_context_
{
  const char *app_id;
  pid_t pid;
  char *pkg_id;
  app_state_e app_state;
  bool is_sub_app;
  bool matched;
  const char *instance_id;
} retrieval_context_s;

typedef void *pkgmgrinfo_appinfo_h;
typedef void *pkgmgrinfo_pkginfo_filter_h;
typedef void *pkgmgrinfo_appinfo_metadata_filter_h;
typedef void *pkgmgrinfo_appinfo_filter_h;

struct app_info_s
{
  char *app_id;
  pkgmgrinfo_appinfo_h pkg_app_info;
};

struct app_info_filter_s
{
  pkgmgrinfo_appinfo_filter_h pkg_app_info_filter;
};

struct app_info_metadata_filter_s
{
  pkgmgrinfo_appinfo_metadata_filter_h pkg_app_info_metadata_filter;
};

typedef struct _foreach_metada_context_
{
  app_info_metadata_cb callback;
  void *user_data;
} foreach_metadata_context_s;

typedef struct _foreach_category_
{
  app_info_category_cb callback;
  void *user_data;
} foreach_category_context_s;



int app_manager_set_app_context_event_cb( app_manager_app_context_event_cb callback, void * user_data)
{
  return 0;
}

void app_manager_unset_app_context_event_cb (void)
{
}

int app_manager_foreach_running_app_context(app_manager_app_context_cb callback, void *user_data)
{
  return 0;
}

int app_manager_foreach_app_context(app_manager_app_context_cb callback, void *user_data)
{
  return 0;
}

int app_manager_get_app_context(const char* app_id, app_context_h *app_context)
{
  return 0;
}

int app_manager_get_app_id (pid_t pid, char **appid)
{
  return 0;
}

int app_manager_is_running (const char *appid, bool *running)
{
  return 0;
}

int app_manager_resume_app (app_context_h handle)
{
  return 0;
}

int app_manager_request_terminate_bg_app (app_context_h handle)
{
  return 0;
}

int app_manager_foreach_app_info(app_manager_app_info_cb callback, void *user_data)
{
  return 0;
}

int app_manager_get_app_info(const char * app_id, app_info_h * app_info)
{
  return 0;
}

int app_manager_get_shared_data_path (const char *appid, char **path)
{
  return 0;
}

int app_manager_get_shared_resource_path (const char *appid, char **path)
{
  return 0;
}

int app_manager_get_shared_trusted_path (const char *appid, char **path)
{
  return 0;
}

int app_manager_get_external_shared_data_path (const char *appid, char **path)
{
  return 0;
}

int app_manager_event_create (app_manager_event_h *handle)
{
  return 0;
}

int app_manager_event_set_status (app_manager_event_h handle, int status_type)
{
  return 0;
}

int app_manager_set_event_cb (app_manager_event_h handle, app_manager_event_cb callback, void *user_data)
{
  return 0;
}

int app_manager_unset_event_cb (app_manager_event_h handle)
{
  return 0;
}

int app_manager_event_destroy (app_manager_event_h handle)
{
  return 0;
}

int app_manager_terminate_app (app_context_h app_context)
{
  return 0;
}

int app_manager_get_app_context_by_instance_id (const char *app_id, const char *instance_id, app_context_h *app_context)
{
  return 0;
}

int app_context_destroy(app_context_h app_context)
{
  return 0;
}

int app_context_get_app_id(app_context_h app_context, char **app_id)
{
  return 0;
}

int app_context_get_package_id(app_context_h app_context, char **package_id)
{
  return 0;
}

int app_context_get_pid (app_context_h app_context, pid_t *pid)
{
  return 0;
}

int app_context_get_app_state (app_context_h app_context, app_state_e *state)
{
  return 0;
}

int app_context_is_terminated (app_context_h app_context, bool *terminated)
{
  return 0;
}

int app_context_is_equal (app_context_h lhs, app_context_h rhs, bool *equal)
{
  return 0;
}

int app_context_is_sub_app (app_context_h app_context, bool *is_sub_app)
{
  return 0;
}

int app_context_clone (app_context_h *clone, app_context_h app_context)
{
  return 0;
}

int app_info_create (const char *app_id, app_info_h *app_info)
{
  return 0;
}

int app_info_destroy (app_info_h app_info)
{
  return 0;
}

int app_info_get_app_id (app_info_h app_info, char **app_id)
{
  return 0;
}

int app_info_get_exec (app_info_h app_info, char **exec)
{
  return 0;
}

int app_info_get_label (app_info_h app_info, char **label)
{
  return 0;
}

int app_info_get_localed_label (const char *app_id, const char *locale, char **label)
{
  return 0;
}

int app_info_get_icon (app_info_h app_info, char **path)
{
  return 0;
}

int app_info_get_package (app_info_h app_info, char **package)
{
  return 0;
}

int app_info_get_type (app_info_h app_info, char **type)
{
  return 0;
}

int app_info_foreach_metadata(app_info_h app_info, app_info_metadata_cb callback, void *user_data)
{
  return 0;
}

int app_info_is_nodisplay (app_info_h app_info, bool *nodisplay)
{
  return 0;
}

int app_info_is_equal (app_info_h lhs, app_info_h rhs, bool *equal)
{
  return 0;
}

int app_info_is_enabled (app_info_h app_info, bool *enabled)
{
  return 0;
}

int app_info_is_onboot (app_info_h app_info, bool *onboot)
{
  return 0;
}

int app_info_is_preload (app_info_h app_info, bool *preload)
{
  return 0;
}

int app_info_clone(app_info_h * clone, app_info_h app_info)
{
  return 0;
}

int app_info_filter_create(app_info_filter_h * handle)
{
  return 0;
}

int app_info_filter_destroy(app_info_filter_h handle)
{
  return 0;
}

int app_info_filter_add_bool(app_info_filter_h handle, const char *property, const bool value)
{
  return 0;
}

int app_info_filter_add_string(app_info_filter_h handle, const char *property, const char *value)
{
  return 0;
}

int app_info_filter_count_appinfo(app_info_filter_h handle, int *count)
{
  return 0;
}

int app_info_filter_foreach_appinfo(app_info_filter_h handle, app_info_filter_cb callback, void * user_data)
{
  return 0;
}

int app_info_metadata_filter_create (app_info_metadata_filter_h *handle)
{
  return 0;
}

int app_info_metadata_filter_destroy (app_info_metadata_filter_h handle)
{
  return 0;
}

int app_info_metadata_filter_add (app_info_metadata_filter_h handle, const char *key, const char *value)
{
  return 0;
}

int app_info_metadata_filter_foreach (app_info_metadata_filter_h handle, app_info_filter_cb callback, void *user_data)
{
  return 0;
}
