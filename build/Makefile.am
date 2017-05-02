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

CLEANFILES = ./dali-bindings/*.o *.so *.dll \
             ../examples/*.so ../examples/*.dll examples/*.exe

BUILT_SOURCES = ../dali-bindings/dali_wrap.cpp ../dali-bindings/dali_wrap.h

if HAVE_MCS
if BUILD_MCS

DALI_BINDINGS_DIR = ./dali-bindings

all-local: libNDalic.so NDali.dll

libNDalic.so: ./dali-bindings/dali_wrap.o ./dali-bindings/keyboard_focus_manager_wrap.o ./dali-bindings/view-wrapper-impl-wrap.o ./dali-bindings/event-thread-callback-wrap.o ./dali-bindings/devel-property-wrap.o
	g++ -shared ./dali-bindings/dali_wrap.o ./dali-bindings/keyboard_focus_manager_wrap.o ./dali-bindings/view-wrapper-impl-wrap.o ./dali-bindings/event-thread-callback-wrap.o ./dali-bindings/devel-property-wrap.o -o libNDalic.so $(DALICORE_LIBS) $(DALIADAPTOR_LIBS) $(DALITOOLKIT_LIBS)

$(DALI_BINDINGS_DIR):
	mkdir -p $@

./dali-bindings/dali_wrap.o: $(BUILT_SOURCES) $(DALI_BINDINGS_DIR)
	g++ -c -fpic $(CXXFLAGS) $(DALICORE_CFLAGS) $(DALIADAPTOR_CFLAGS) $(DALITOOLKIT_CFLAGS) ../dali-bindings/dali_wrap.cpp -o ./dali-bindings/dali_wrap.o

./dali-bindings/keyboard_focus_manager_wrap.o: $(BUILT_SOURCES) $(DALI_BINDINGS_DIR)
	g++ -c -fpic $(CXXFLAGS) $(DALICORE_CFLAGS) $(DALIADAPTOR_CFLAGS) $(DALITOOLKIT_CFLAGS) ../dali-bindings/keyboard_focus_manager_wrap.cpp -o ./dali-bindings/keyboard_focus_manager_wrap.o

./dali-bindings/view-wrapper-impl-wrap.o: $(BUILT_SOURCES) $(DALI_BINDINGS_DIR)
	g++ -c -fpic $(CXXFLAGS) $(DALICORE_CFLAGS) $(DALIADAPTOR_CFLAGS) $(DALITOOLKIT_CFLAGS) ../dali-bindings/view-wrapper-impl-wrap.cpp -o ./dali-bindings/view-wrapper-impl-wrap.o

./dali-bindings/event-thread-callback-wrap.o: $(BUILT_SOURCES) $(DALI_BINDINGS_DIR)
	g++ -c -fpic $(CXXFLAGS) $(DALICORE_CFLAGS) $(DALIADAPTOR_CFLAGS) $(DALITOOLKIT_CFLAGS) ../dali-bindings/event-thread-callback-wrap.cpp -o ./dali-bindings/event-thread-callback-wrap.o

./dali-bindings/devel-property-wrap.o: $(BUILT_SOURCES) $(DALI_BINDINGS_DIR)
	g++ -c -fpic $(CXXFLAGS) $(DALICORE_CFLAGS) $(DALIADAPTOR_CFLAGS) $(DALITOOLKIT_CFLAGS) ../dali-bindings/devel-property-wrap.cpp -o ./dali-bindings/devel-property-wrap.o

NDali.dll: $(BUILT_SOURCES)
	$(MCS) -nologo -target:library -out:NDali.dll ../sharp/internal/*.cs ../sharp/public/*.cs

check-local: examples/hello-world.exe \
             examples/scroll-view.exe \
             examples/control-dashboard.exe \
             examples/user-alphafunction.exe \
             examples/image-view.exe \
             examples/visuals-example.exe \
             examples/visuals-using-custom-view.exe \
             examples/libNDalic.so examples/NDali.dll

examples/hello-world.exe: ../examples/hello-world.cs
	$(MCS) -nologo -target:exe -out:../$@ -reference:NDali.dll $<

examples/scroll-view.exe: ../examples/scroll-view.cs
	$(MCS) -nologo -target:exe -out:../$@ -reference:NDali.dll $<

examples/control-dashboard.exe: ../examples/control-dashboard.cs
	$(MCS) -nologo -target:exe -out:../$@ -reference:NDali.dll $<

examples/user-alphafunction.exe: ../examples/user-alphafunction.cs
	$(MCS) -nologo -target:exe -out:../$@ -reference:NDali.dll $<

examples/image-view.exe: ../examples/image-view.cs
	$(MCS) -nologo -target:exe -out:../$@ -reference:NDali.dll $<

examples/visuals-example.exe: ../examples/visuals-example.cs
	$(MCS) -nologo -target:exe -out:../$@ -reference:NDali.dll $<

examples/visuals-using-custom-view.exe: ../examples/visuals-using-custom-view/*.cs
	$(MCS) -nologo -target:exe -out:../$@ -reference:NDali.dll $^

examples/libNDalic.so:
	cd ../examples && ln -sf ../build/libNDalic.so

examples/NDali.dll:
	cd ../examples && ln -sf ../build/NDali.dll

endif
endif


