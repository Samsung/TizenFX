ASM_DIRS := Tizen Tizen.Internals
ASM_DLLS := $(addsuffix .dll,$(ASM_DIRS))

ALL: $(ASM_DLLS)

define make-dll
$(eval SRC = $(shell find $1 -path $1/obj -prune -o -name '*.cs' -print))
$1.dll: $(SRC)
	@echo "[BUILD] $$@"
	@mcs /nologo /out:$$@ /t:library /keyfile:$1/$1.snk $(SRC)
	@echo "[CHECK] $$@"
	@RET=`mono-shlib-cop $$@`; \
  CNT=`echo $$$$RET | grep -e '^error:' | wc -l`; \
  if [ $$$$CNT -gt 0 ]; then echo $$$$RET; rm -f $$@ exit 1; fi
endef

$(eval $(call make-dll,Tizen))
$(eval $(call make-dll,Tizen.Internals))

clean:
	@rm -f $(ASM_DLLS)
