# 🚀 Guide de Démarrage Rapide - OpenCreatorSuite

Guide pas à pas pour installer et lancer OpenCreatorSuite en moins de 10 minutes.

## 📚 Prérequis

### Obligatoires

- **Node.js 20+** et npm - [Télécharger](https://nodejs.org/)
- **.NET 9 SDK** - [Télécharger](https://dotnet.microsoft.com/download)
- **MySQL 8.0+** - [Télécharger](https://dev.mysql.com/downloads/mysql/)
- **Git** - [Télécharger](https://git-scm.com/)

### Recommandés

- **Visual Studio Code** - [Télécharger](https://code.visualstudio.com/)
- **MySQL Workbench** - Pour gérer la base de données

## 📦 Installation

### 1. Cloner le repository

```bash
git clone https://github.com/libremax534/OpenCreatorSuite.git
cd OpenCreatorSuite
```

### 2. Configurer MySQL

```bash
# Créer la base de données
mysql -u root -p < scripts/setup-database.sql

# Exécuter la migration initiale
mysql -u root -p opencreator < src/OpenCreatorStudio.API/Infrastructure/Data/Migrations/001_InitialCreate.sql
```

### 3. Générer le hash BCrypt pour l'utilisateur admin

Ouvrez une console C# interactive:

```bash
cd src/OpenCreatorStudio.API/API
dotnet script
```

Exécutez:

```csharp
#r "nuget: BCrypt.Net-Next, 4.0.3"
using BCrypt.Net;
var hash = BCrypt.HashPassword("admin123");
Console.WriteLine(hash);
```

Copiez le hash généré.

### 4. Mettre à jour la migration SQL

Ouvrez `src/OpenCreatorStudio.API/Infrastructure/Data/Migrations/001_InitialCreate.sql`

Remplacez `$2a$11$YourBCryptHashHere` par le hash généré.

Ré-exécutez la migration:

```bash
mysql -u root -p opencreator < src/OpenCreatorStudio.API/Infrastructure/Data/Migrations/001_InitialCreate.sql
```

### 5. Configurer la chaîne de connexion

Éditez `src/OpenCreatorStudio.API/API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "MySql": "Server=localhost;Port=3306;Database=opencreator;User=root;Password=VOTRE_MOT_DE_PASSE;"
  }
}
```

### 6. Installer les dépendances

**Frontend:**

```bash
cd src/OpenCreatorStudio.Web
npm install
```

**Backend:**

```bash
cd src/OpenCreatorStudio.API/API
dotnet restore
```

## 🚀 Lancement

### Méthode 1: Scripts automatiques

**Linux/Mac:**

```bash
# Terminal 1 - Backend
chmod +x scripts/start-backend.sh
./scripts/start-backend.sh

# Terminal 2 - Frontend
chmod +x scripts/start-frontend.sh
./scripts/start-frontend.sh
```

**Windows:**

```cmd
REM Terminal 1 - Backend
scripts\start-backend.bat

REM Terminal 2 - Frontend
scripts\start-frontend.bat
```

### Méthode 2: Manuelle

**Terminal 1 - Backend:**

```bash
cd src/OpenCreatorStudio.API/API
dotnet run
```

**Terminal 2 - Frontend:**

```bash
cd src/OpenCreatorStudio.Web
npm start
```

### Méthode 3: VS Code (Recommandé)

1. Ouvrir le projet dans VS Code
2. Appuyer sur `F5`
3. Sélectionner **"Full Stack"**
4. Les deux serveurs démarrent automatiquement

## ✅ Vérification

### Backend

- **API**: https://localhost:5001
- **Swagger**: https://localhost:5001/swagger

Testez avec curl:

```bash
curl -k https://localhost:5001/api/projects
```

### Frontend

- **Application**: http://localhost:4200

Ouvrez votre navigateur et accédez à http://localhost:4200

## 🔑 Connexion

**Identifiants par défaut:**

- **Nom d'utilisateur**: `admin`
- **Mot de passe**: `admin123`

## 🛠️ Commandes Utiles

### Frontend

```bash
# Démarrage
npm start

# Build production
npm run build

# Tests
npm test

# Linting
ng lint
```

### Backend

```bash
# Démarrage
dotnet run

# Build
dotnet build

# Tests
dotnet test

# Créer une migration EF Core
dotnet ef migrations add NomDeLaMigration

# Appliquer les migrations
dotnet ef database update
```

### Base de données

```bash
# Connexion MySQL
mysql -u root -p opencreator

# Voir les tables
SHOW TABLES;

# Voir les utilisateurs
SELECT * FROM users;
```

## 🐞 Dépannage

### Erreur de connexion MySQL

**Problème**: `Unable to connect to MySQL server`

**Solution**:

1. Vérifiez que MySQL est démarré: `sudo systemctl status mysql` (Linux)
2. Vérifiez la chaîne de connexion dans `appsettings.json`
3. Testez la connexion: `mysql -u root -p`

### Erreur npm install

**Problème**: `EACCES: permission denied`

**Solution**:

```bash
sudo chown -R $USER:$USER ~/.npm
sudo chown -R $USER:$USER node_modules
```

### Port déjà utilisé

**Problème**: `Port 5001 is already in use`

**Solution**:

```bash
# Linux/Mac
lsof -ti:5001 | xargs kill -9

# Windows
netstat -ano | findstr :5001
taskkill /PID <PID> /F
```

### Angular ne compile pas

**Problème**: `Module not found` ou erreurs TypeScript

**Solution**:

```bash
# Supprimer node_modules et cache
rm -rf node_modules .angular
npm install
```

## 📚 Documentation Complète

Pour plus de détails, consultez:

- [Documentation complète](./Documentation/README-DOCUMENTATION.md)
- [Cahier des charges](./Documentation/CAHIER-DES-CHARGES-COMPLET.md)
- [Architecture technique](./Documentation/ARCHITECTURE-TECHNIQUE.md)
- [Design System](./Documentation/DESIGN-SYSTEM.md)

## ❓ Aide

Si vous rencontrez des problèmes:

1. Consultez les [Issues GitHub](https://github.com/libremax534/OpenCreatorSuite/issues)
2. Créez une nouvelle issue avec:
   - Description du problème
   - Messages d'erreur complets
   - Versions (Node, .NET, MySQL)
   - Système d'exploitation

## 🎉 Félicitations !

Vous êtes maintenant prêt à développer avec OpenCreatorSuite ! 🚀

Prochaines étapes suggérées:

1. Explorez l'éditeur graphique
2. Créez votre premier nœud PRQ
3. Générez une procédure stockée
4. Consultez la documentation pour les fonctionnalités avancées
