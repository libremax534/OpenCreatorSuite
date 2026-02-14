# Scripts OpenCreatorStudio

Ce dossier contient des scripts utilitaires pour faciliter le développement.

## 🚀 Scripts de Démarrage

### Linux/Mac

```bash
# Démarrer le backend
chmod +x scripts/start-backend.sh
./scripts/start-backend.sh

# Démarrer le frontend
chmod +x scripts/start-frontend.sh
./scripts/start-frontend.sh
```

### Windows

```cmd
REM Démarrer le backend
scripts\start-backend.bat

REM Démarrer le frontend
scripts\start-frontend.bat
```

## 📊 Configuration MySQL

```bash
# Exécuter le script de configuration
mysql -u root -p < scripts/setup-database.sql

# Exécuter la migration initiale
mysql -u root -p opencreator < src/OpenCreatorStudio.API/Infrastructure/Data/Migrations/001_InitialCreate.sql
```

## 🔑 Génération Hash BCrypt

Pour générer un hash de mot de passe pour l'utilisateur admin:

### Option 1: Avec C# (dotnet script)

```bash
cd src/OpenCreatorStudio.API/API
dotnet run --project ../Application/OpenCreatorStudio.Application.csproj
```

Puis dans le code:

```csharp
using BCrypt.Net;
var hash = BCrypt.HashPassword("admin123");
Console.WriteLine(hash);
```

### Option 2: En ligne

Utiliser un générateur BCrypt en ligne (bcrypt-generator.com)

## 🛠️ Scripts Disponibles

| Script | Description | Plateforme |
|--------|-------------|------------|
| `start-backend.sh` | Démarre l'API .NET | Linux/Mac |
| `start-backend.bat` | Démarre l'API .NET | Windows |
| `start-frontend.sh` | Démarre Angular | Linux/Mac |
| `start-frontend.bat` | Démarre Angular | Windows |
| `setup-database.sql` | Configure MySQL | Tous |

## 📝 Notes

- Les scripts backend vérifient la présence de .NET 9
- Les scripts frontend installent automatiquement les dépendances npm si nécessaire
- Le backend démarre sur `https://localhost:5001`
- Le frontend démarre sur `http://localhost:4200`
