
ifndef config
	config=debug
endif

ifndef verbose
	SILENT = @
endif

PROJECTS := tct-applications-tizen-tests

CSC = mcs

.PHONY: all clean help $(PROJECTS) prebuild prelink

ifeq ($(config),debug)
	FLAGS = /debug /noconfig /d:DEBUG
endif

ifeq ($(config),release)
	FLAGS = /optimize /noconfig /d:NDEBUG
endif

FLAGS += /t:exe

TARGETDIR = bin
OBJDIR = obj
TARGET = $(TARGETDIR)/$(PROJECTS).exe
SOURCES = $(wildcard src/**/*.cs src/*.cs)
null :=
space := $(null) #
comma := ,
DLLS = $(wildcard lib/*.dll)
ifneq ("$(DLLS)", "")
	REFERENCE = "/reference:$(subst $(space),$(comma),$(DLLS))"
endif

all: $(TARGETDIR) $(TARGET)

$(TARGET): $(SOURCES) $(DLLS)
	@echo "=== Building $(PROJECTS) ($(config))"
	$(SILENT) $(CSC) /nologo /out:$@ $(REFERENCE) $(FLAGS) $(SOURCES)

$(TARGETDIR):
	$(SILENT) mkdir -p $(TARGETDIR)

clean:
	$(SILENT) rm -rf $(TARGETDIR)
