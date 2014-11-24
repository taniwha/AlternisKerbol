KSPDIR		:= ${HOME}/ksp/KSP_linux-alternis
MANAGED		:= ${KSPDIR}/KSP_Data/Managed
GAMEDATA	:= ${KSPDIR}/GameData
AKGAMEDATA  := ${GAMEDATA}/AlternisKerbol
PLUGINDIR	:= ${AKGAMEDATA}
TBGAMEDATA  := ${GAMEDATA}/000_Toolbar
APIEXTDATA	:= ${PLUGINDIR}

TARGETS		:= AlternisKerbol.dll

AK_FILES := \
	AlternisConfigGUI.cs	\
	CometLogic.cs	\
	LightShifter.cs	\
	PlanetShifter.cs	\
	UtilityStash.cs	\
	$e

RESGEN2		:= resgen2
GMCS		:= gmcs
GMCSFLAGS	:= -optimize -warnaserror
GIT			:= git
TAR			:= tar
ZIP			:= zip

all: ${TARGETS}

.PHONY: version
version:
	@./git-version.sh

info:
	@echo "AlternisKerbol Build Information"
	@echo "    resgen2:    ${RESGEN2}"
	@echo "    gmcs:       ${GMCS}"
	@echo "    gmcs flags: ${GMCSFLAGS}"
	@echo "    git:        ${GIT}"
	@echo "    tar:        ${TAR}"
	@echo "    zip:        ${ZIP}"
	@echo "    KSP Data:   ${KSPDIR}"

AlternisKerbol.dll: ${AK_FILES}
	${GMCS} ${GMCSFLAGS} -t:library -lib:${APIEXTDATA},${MANAGED} \
		-r:Assembly-CSharp,Assembly-CSharp-firstpass,UnityEngine \
		-out:$@ $^

clean:
	rm -f ${TARGETS} AssemblyInfo.cs

install: all
	mkdir -p ${PLUGINDIR}
	cp ${TARGETS} ${PLUGINDIR}

.PHONY: all clean install
