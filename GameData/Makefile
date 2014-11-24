KSPDIR		:= ${HOME}/ksp/KSP_linux-alternis
MANAGED		:= ${KSPDIR}/KSP_Data/Managed
GAMEDATA	:= ${KSPDIR}/GameData
AKGAMEDATA  := ${GAMEDATA}/AlternisKerbol
PLUGINDIR	:= ${AKGAMEDATA}

RESGEN2	:= resgen2
GMCS	:= gmcs
GIT		:= git
TAR		:= tar
ZIP		:= zip

all:

clean:

info:
	@echo "Alternis Kerbol Build Information"
	@echo "    resgen2:  ${RESGEN2}"
	@echo "    gmcs:     ${GMCS}"
	@echo "    git:      ${GIT}"
	@echo "    tar:      ${TAR}"
	@echo "    zip:      ${ZIP}"
	@echo "    KSP Data: ${KSPDIR}"
	@echo "    Plugin:   ${PLUGINDIR}"

install: all
	../tools/copy-files files ${GAMEDATA}

.PHONY: all clean info install
