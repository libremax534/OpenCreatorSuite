@echo off
REM Script de démarrage du frontend Angular pour Windows

echo ===========================================
echo   Démarrage Frontend OpenCreatorStudio
echo ===========================================
echo.

REM Vérifier que Node.js est installé
where node >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo [31mErreur: Node.js n'est pas installé[0m
    echo Téléchargez-le depuis: https://nodejs.org
    pause
    exit /b 1
)

echo [32mNode.js détecté:[0m
node --version
echo [32mnpm détecté:[0m
npm --version
echo.

REM Aller dans le dossier Web
cd /d "%~dp0..\src\OpenCreatorStudio.Web"

REM Vérifier si node_modules existe
if not exist "node_modules" (
    echo [36mInstallation des dépendances npm...[0m
    call npm install
    echo.
)

echo [32mDémarrage du serveur de développement Angular...[0m
echo Application disponible sur: http://localhost:4200
echo.
echo Appuyez sur Ctrl+C pour arrêter
echo.

call npm start
