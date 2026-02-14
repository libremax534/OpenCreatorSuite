#!/bin/bash

# Script de démarrage du frontend Angular

echo "==========================================="
echo "  Démarrage Frontend OpenCreatorStudio"
echo "==========================================="
echo ""

# Vérifier que Node.js est installé
if ! command -v node &> /dev/null
then
    echo "❌ Erreur: Node.js n'est pas installé"
    echo "Téléchargez-le depuis: https://nodejs.org"
    exit 1
fi

echo "✅ Node.js détecté: $(node --version)"
echo "✅ npm détecté: $(npm --version)"
echo ""

# Aller dans le dossier Web
cd "$(dirname "$0")/../src/OpenCreatorStudio.Web" || exit

# Vérifier si node_modules existe
if [ ! -d "node_modules" ]; then
    echo "📦 Installation des dépendances npm..."
    npm install
    echo ""
fi

echo "🚀 Démarrage du serveur de développement Angular..."
echo "Application disponible sur: http://localhost:4200"
echo ""
echo "Appuyez sur Ctrl+C pour arrêter"
echo ""

npm start
