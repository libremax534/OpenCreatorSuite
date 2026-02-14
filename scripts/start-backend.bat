@echo off
REM Script de démarrage du backend .NET pour Windows

echo ===========================================
echo   Démarrage Backend OpenCreatorStudio
echo ===========================================
echo.

REM Vérifier que .NET 9 est installé
where dotnet >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo [31mErreur: .NET SDK n'est pas installé[0m
    echo Téléchargez-le depuis: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo [32m.NET SDK détecté:[0m
dotnet --version
echo.

REM Aller dans le dossier API
cd /d "%~dp0..\src\OpenCreatorStudio.API\API"

echo [36mRestauration des packages NuGet...[0m
dotnet restore

echo.
echo [36mCompilation du projet...[0m
dotnet build

echo.
echo [32mDémarrage de l'API...[0m
echo API disponible sur: https://localhost:5001
echo Swagger disponible sur: https://localhost:5001/swagger
echo.
echo Appuyez sur Ctrl+C pour arrêter
echo.

dotnet run
