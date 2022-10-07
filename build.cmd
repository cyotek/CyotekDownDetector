@ECHO OFF

SETLOCAL

SET SCRIPTPATH=%~dp0
SET SCRIPTPATH=%SCRIPTPATH:~0,-1%

SET GUIBIN=..\gui\bin\release\

CD %SCRIPTPATH%

CALL %CTKBLDROOT%\SetupEnv.cmd

REM Build and sign the file
%msbuildexe% Cyotek.DownDetector.sln /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build

IF EXIST dist DEL dist\*.* /q /s

IF NOT EXIST dist MKDIR dist

PUSHD .\dist

copy /y ..\LICENSE.txt
copy /y ..\README.md
copy /y ..\CHANGELOG.md

copy /y %GUIBIN%ctkdd.exe
copy /y %GUIBIN%ctkdd.exe.config
copy /y %GUIBIN%ctkdd.pdb
copy /y %GUIBIN%Cyotek.DownDetector.dll
copy /y %GUIBIN%Cyotek.DownDetector.pdb
copy /y %GUIBIN%Cyotek.Windows.Forms.TabList.dll
copy /y %GUIBIN%TimeSpan2.dll

xcopy  /E /V /I %GUIBIN%ar ar
xcopy  /E /V /I %GUIBIN%da da
xcopy  /E /V /I %GUIBIN%de de
xcopy  /E /V /I %GUIBIN%es es
xcopy  /E /V /I %GUIBIN%fr fr
xcopy  /E /V /I %GUIBIN%it it
xcopy  /E /V /I %GUIBIN%ko ko
xcopy  /E /V /I %GUIBIN%nl nl
xcopy  /E /V /I %GUIBIN%pl pl
xcopy  /E /V /I %GUIBIN%pt pt
xcopy  /E /V /I %GUIBIN%ru ru
xcopy  /E /V /I %GUIBIN%se se
xcopy  /E /V /I %GUIBIN%zh-CN zh-CN


CALL sign-program ctkdd.exe
CALL sign-program Cyotek.DownDetector.dll

%zipexe% a DownDetector.1.0.x.zip -r

POPD

ENDLOCAL
