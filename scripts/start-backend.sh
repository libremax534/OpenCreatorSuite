#!/bin/bash

# Script de démarrage du backend .NET

echo "==========================================="
echo "  Démarrage Backend OpenCreatorStudio"
echo "==========================================="
echo ""

# Vérifier que .NET 9 est installé
if ! command -v dotnet &> /dev/null
then
    echo "❌ Erreur: .NET SDK n'est pas installé"
    echo "Téléchargez-le depuis: https://dotnet.microsoft.com/download"
    exit 1
fi

echo "✅ .NET SDK détecté: $(dotnet --version)"
echo ""

# Aller dans le dossier API
cd "$(dirname "$0")/../src/OpenCreatorStudio.API/API" || exit

echo "📦 Restauration des packages NuGet..."
dotnet restore

echo ""
echo "🔨 Compilation du projet..."
dotnet build

echo ""
echo "🚀 Démarrage de l'API..."
echo "API disponible sur: https://localhost:5001"
echo "Swagger disponible sur: https://localhost:5001/swagger"
echo ""
echo "Appuyez sur Ctrl+C pour arrêter"
echo ""

dotnet run
