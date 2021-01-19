@ECHO OFF

SETLOCAL

SET SCRIPTPATH=%~dp0
SET SCRIPTPATH=%SCRIPTPATH:~0,-1%

CD %SCRIPTPATH%

CALL ..\..\..\build\set35vars.bat

%msbuildexe% Cyotek.DownDetector.sln /p:Configuration=Release /verbosity:minimal /nologo /t:Clean,Build

CALL signcmd .\gui\bin\Release\Cyotek.DownDetector.dll
CALL signcmd .\gui\bin\Release\ctkddtkd.exe

ENDLOCAL
