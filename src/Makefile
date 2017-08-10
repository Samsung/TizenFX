PROJ_DIR=$(shell pwd)
SRCS=\
	src/Interop/Interop.Libteec.cs \
	src/Interop/Interop.Types.cs \
	src/Interop/Interop.Libraries.cs \
	src/Interop/Interop.Errors.cs \
	src/Secure/Libteec.cs \
	src/Secure/Properties/AssemblyInfo.cs \
	Test.cs

test.exe: ${SRCS}
	mcs ${SRCS} -out:test.exe

.PHONY: build
build: test.exe

.PHONY: build-csuml
build-csuml:
	(cd ~/csapi/csuml && dotnet restore && dotnet build)

pack: ${SRCS}
	zip -r csapi-libteec.zip src

csapi-libteec.puml: build-csuml ${SRCS}
	@echo "create csapi-libteec.puml"
	(cd ~/csapi/csuml && dotnet run -- ${PROJ_DIR}/filelist.lst) > csapi-libteec.puml

csapi-libteec.png: csapi-libteec.puml
	java -jar ~/bin/plantuml.jar csapi-libteec.puml


# .phony is a target that is not a real file
.PHONY: diagram diagram-show
diagram: csapi-libteec.png
diagram-show: diagram
	xdg-open csapi-libteec.png

xbuild-hello:
	xbuild /p:Configuration=Release HelloWorld.csproj

