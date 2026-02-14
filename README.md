# 🏛️ OpenCreatorSuite

**Migration d'OpenCreator WPF vers une architecture moderne Angular 20 + .NET 9**

[![Angular](https://img.shields.io/badge/Angular-20-red)](https://angular.io/)
[![.NET](https://img.shields.io/badge/.NET-9-purple)](https://dotnet.microsoft.com/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0-blue)](https://www.mysql.com/)
[![TypeScript](https://img.shields.io/badge/TypeScript-5.6-blue)](https://www.typescriptlang.org/)
[![License](https://img.shields.io/badge/License-Propriétaire-yellow)](LICENSE)

## 📝 Vue d'Ensemble

OpenCreatorSuite est une plateforme de création d'éditeurs visuels de graphes avec génération automatique de procédures stockées MySQL. Migration complète d'une application WPF existante vers une architecture web moderne.

### 🎯 Objectifs du Projet

- ✅ **Modernisation technologique** : Migration WPF → Angular 20 + .NET 9
- ✅ **Clean Architecture** : Séparation stricte en couches (Domain, Application, Infrastructure, API)
- ✅ **Design glassmorphism** : Interface utilisateur moderne et élégante
- ✅ **Éditeur graphique** : jsPlumb pour la manipulation visuelle de nœuds
- ✅ **Éditeur SQL avancé** : Monaco Editor avec coloration syntaxique
- ✅ **Génération automatique** : Procédures stockées MySQL depuis graphes

## 🚀 Démarrage Rapide

### Prérequis

- **Node.js** 20+ et npm
- **.NET 9 SDK**
- **MySQL 8.0+**
- **Git**

### Installation

```bash
# Cloner le repository
git clone https://github.com/libremax534/OpenCreatorSuite.git
cd OpenCreatorSuite

# Installation frontend (Angular)
cd src/OpenCreatorStudio.Web
npm install
npm start
# → http://localhost:4200

# Installation backend (.NET)
cd ../OpenCreatorStudio.API
dotnet restore
dotnet run --project API/OpenCreatorStudio.API.csproj
# → https://localhost:5001
```

### Configuration MySQL

```bash
# Créer la base de données
mysql -u root -p
CREATE DATABASE opencreator CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

# Configurer la chaîne de connexion dans appsettings.json
cd src/OpenCreatorStudio.API/API
# Editer appsettings.json
```

## 📚 Documentation

La documentation complète est disponible dans le dossier [`/Documentation`](./Documentation):

### Documents Principaux

1. **[Cahier des Charges Complet](./Documentation/CAHIER-DES-CHARGES-COMPLET.md)**
   - Spécifications fonctionnelles
   - Standards de développement
   - Méthodologie Clean Code

2. **[Architecture Technique](./Documentation/ARCHITECTURE-TECHNIQUE.md)**
   - Stack technologique détaillée
   - Structure des projets
   - Patterns et bonnes pratiques

3. **[Design System Glass](./Documentation/DESIGN-SYSTEM.md)**
   - Variables SCSS
   - Mixins réutilisables
   - Composants UI

4. **[Roadmap](./Documentation/ROADMAP.md)**
   - Phase 1: POC (4 semaines)
   - Phase 2: Fonctionnalités Core (6 semaines)
   - Phase 3: Intégration MySQL (4 semaines)

5. **[Points d'Attention & Recommandations](./Documentation/POINTS-ATTENTION-RECOMMANDATIONS.md)**
   - Choix techniques justifiés
   - Pièges à éviter
   - Optimisations performance

### Analyses Détaillées

- **Analyse SQL Editor** (36KB) - Éditeur de procédures stockées
- **Analyse StoredProcedureCatalog** (24KB) - Catalogue des procédures

## 🏛️ Architecture

### Frontend (Angular 20)

```
src/OpenCreatorStudio.Web/
├── src/
│   ├── app/
│   │   ├── core/              # Services, guards, interceptors
│   │   ├── features/          # Modules fonctionnels
│   │   │   ├── authentication/
│   │   │   ├── graph-editor/
│   │   │   └── sql-editor/
│   │   └── shared/           # Composants réutilisables
│   └── assets/
│       └── styles/           # Thème Glass SCSS
└── package.json
```

### Backend (.NET 9)

```
src/OpenCreatorStudio.API/
├── Domain/                  # Entités métier
│   ├── Entities/
│   └── Enums/
├── Application/             # Logique métier
│   ├── Interfaces/
│   ├── Services/
│   └── DTOs/
├── Infrastructure/          # Accès aux données
│   ├── Data/
│   └── MySQL/
└── API/                     # Controllers, Startup
```

## 🛠️ Technologies Clés

### Frontend
- **Angular 20** - Framework principal
- **jsPlumb Community** - Manipulation de graphes
- **Monaco Editor** - Éditeur SQL avec coloration syntaxique
- **Angular Material** - Composants UI
- **NgRx** - Gestion d'état
- **SCSS** - Styles avec thème Glass

### Backend
- **ASP.NET Core 9** - API REST
- **Entity Framework Core** - ORM
- **MySQL 8.0+** - Base de données
- **BCrypt.Net** - Sécurité des mots de passe
- **Swashbuckle** - Documentation Swagger

## 📊 Statut du Projet

### ✅ Phase 0 : Initialisation (Terminé)

- [x] Structure du repository
- [x] Documentation complète (5 documents principaux)
- [x] Configuration Angular 20
- [x] Configuration .NET 9 Clean Architecture
- [x] Thème Glass UI complet (SCSS)
- [x] Module d'authentification
- [x] Entités du domaine

### 🚧 Phase 1 : POC (En cours)

- [x] Composant de connexion avec design Glass
- [ ] Éditeur graphique de base (jsPlumb)
- [ ] CRUD nœuds et connexions
- [ ] Propriétés de nœuds
- [ ] Sauvegarde/Chargement de projets

### 📅 Phase 2 : Fonctionnalités Core (Planifié)

- [ ] Éditeur SQL avec Monaco
- [ ] Catalogue de procédures stockées
- [ ] Générateur de SQL
- [ ] Journal de projet
- [ ] Palette de composants

### 📅 Phase 3 : Intégration MySQL (Planifié)

- [ ] Déploiement procédures vers MySQL
- [ ] Exécution et test de procédures
- [ ] Historique des déploiements
- [ ] Rollback de versions

## 📖 Commit History

### Commits Récents

1. **Commit 1** - README principal
2. **Commit 2** - Documentation complète (5 fichiers)
3. **Commit 3** - Index documentation
4. **Commit 4** - Structure Angular (package.json, angular.json, tsconfig)
5. **Commit 5** - Structure .NET Solution
6. **Commit 6** - Styles SCSS Glass Theme + Environnements
7. **Commit 7** - Composants Angular (App, Auth, Guards, Interceptors)
8. **Commit 8** - Couche Domain .NET (Entités, Enums)

### Total : 30+ fichiers commités

## 👥 Équipe

- **Fournier Laurent** - Architecte / Développeur Principal
- **Projet source** : [OpenCreator WPF](https://github.com/libremax534/OpenCreator.git)

## 🔗 Liens Utiles

- **Frontend** : http://localhost:4200
- **Backend API** : https://localhost:5001
- **Swagger UI** : https://localhost:5001/swagger
- **Projet WPF original** : https://github.com/libremax534/OpenCreator.git

## 📝 Licence

Ce projet est sous licence propriétaire. Tous droits réservés.

## 📧 Contact

Pour toute question concernant le projet :
- **Email** : fournier.laurent@example.com
- **GitHub Issues** : [Créer une issue](https://github.com/libremax534/OpenCreatorSuite/issues)

---

**Dernière mise à jour** : 14 février 2026  
**Version** : 1.0.0-dev
