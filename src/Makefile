ASM_DIRS := Tizen.Network.IoTConnectivity
ASM_DLLS := $(addsuffix .dll,$(ASM_DIRS))

FLAGS := /unsafe

ALL: $(ASM_DLLS)

define make-dll
$(eval ASM = $(strip $1))
$(eval SRC = $(shell find $(ASM) -path $(ASM)/obj -prune -o -name '*.cs' -print))
$(eval PKG = $(shell echo $2 | tr ' ' ','))
$(ASM).dll: $(SRC)
	@echo "[BUILD] $$@"
	@mcs /nologo /out:$$@ /t:library /keyfile:$(ASM)/$(ASM).snk $(addprefix /pkg:,$(PKG)) $(FLAGS) $(SRC)
	@echo "[CHECK] $$@"
	@RET=`mono-shlib-cop $$@`; \
  CNT=`echo $$$$RET | grep -e '^error:' | wc -l`; \
  if [ $$$$CNT -gt 0 ]; then echo $$$$RET; rm -f $$@ exit 1; fi
endef

$(eval $(call make-dll, Tizen.Network.IoTConnectivity, csapi-tizen))

clean:
	@rm -f $(ASM_DLLS)
