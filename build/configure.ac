# Copyright (c) 2017 Samsung Electronics Co., Ltd.

# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at

# http://www.apache.org/licenses/LICENSE-2.0

# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

# Process this file with autoconf to produce a configure script.
AC_INIT([Dali-SHARP], [0.1.1],
        [Dali-SHARP])
AC_PREREQ(2.50)
AC_CONFIG_AUX_DIR([config])
AM_INIT_AUTOMAKE([-Wall foreign])

# check target
AC_MSG_CHECKING([system])
target=`uname`
AC_MSG_RESULT([$target])

# check compiler
AC_LANG([C++])

# check for Dali libraries
PKG_CHECK_MODULES(DALICORE, dali-core)
PKG_CHECK_MODULES(DALIADAPTOR, dali-adaptor)
PKG_CHECK_MODULES(DALITOOLKIT, dali-toolkit)

AC_PATH_PROGS([MCS], [gmcs mcs gmcs2])
AM_CONDITIONAL(HAVE_MCS, test "x${MCS}" != "x")

AC_ARG_ENABLE([csharp],
              AC_HELP_STRING([--disable-csharp],
                             [If disabled, the C# module
                              will not be built]),
              [build_mcs=$enableval],
              [build_mcs=yes])
AM_CONDITIONAL(BUILD_MCS, test "$build_mcs" != "no")

# done, output the configured files
AC_CONFIG_FILES([Makefile])
AC_OUTPUT

