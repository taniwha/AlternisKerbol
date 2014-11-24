KSPDIR		:= ${HOME}/ksp/KSP_linux-alternis
MANAGED		:= ${KSPDIR}/KSP_Data/Managed
GAMEDATA	:= ${KSPDIR}/GameData
AKGAMEDATA  := ${GAMEDATA}/AlternisKerbol
PLUGINDIR	:= ${AKGAMEDATA}
TBGAMEDATA  := ${GAMEDATA}/000_Toolbar

RESGEN2	:= resgen2
GMCS	:= gmcs
GIT		:= git
TAR		:= tar
ZIP		:= zip

.PHONY: all clean info install

SUBDIRS=Source

all clean install:
	@for dir in ${SUBDIRS}; do \
		make -C $$dir $@ || exit 1; \
	done

info:
	@echo "Extraplanetary Launchpads Build Information"
	@echo "    resgen2:  ${RESGEN2}"
	@echo "    gmcs:     ${GMCS}"
	@echo "    git:      ${GIT}"
	@echo "    tar:      ${TAR}"
	@echo "    zip:      ${ZIP}"
	@echo "    KSP Data: ${KSPDIR}"
	@echo "    Plugin:   ${PLUGINDIR}"
