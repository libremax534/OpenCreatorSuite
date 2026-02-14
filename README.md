# OpenCreatorSuite

## 📋 Informations Générales

**Projet**: OpenCreatorStudio  
**Type**: Migration OpenCreator (WPF C#) vers Angular  
**Environnement**: Visual Studio 2022  
**Architecture**: Clean Code / Clean Architecture  
**Date**: Février 2026

## 🎯 Objectif

OpenCreatorStudio est une migration complète d'OpenCreator (application WPF/C#) vers une stack moderne Angular + .NET 9. Il s'agit d'un éditeur graphique de workflow WCS (Warehouse Control System) permettant de créer des graphes de processus métier via drag & drop et de générer automatiquement des procédures stockées MySQL.

## 🚀 Fonctionnalités Principales

- ✅ **Éditeur graphique de workflow** avec canvas infini (5000x5000px)
- ✅ **10 types de nœuds WCS** (PRQ, LBC, DRQ, SRE, IRQ, IMP, BAL, PANEL, TAB, TEXT)
- ✅ **Système de connexions conditionnelles** entre nœuds
- ✅ **Génération automatique de procédures stockées MySQL**
- ✅ **Authentification BCrypt** avec table utilisateurs MySQL
- ✅ **Éditeur SQL intégré** avec Monaco Editor
- ✅ **Système Undo/Redo** (20 niveaux)
- ✅ **Persistance JSON** locale et base de données
- ✅ **Déploiement et synchronisation MySQL**
- ✅ **Design Glass** (glassmorphism)

## 🛠️ Stack Technologique

### Frontend
- **Framework**: Angular 20
- **Bibliothèque graphes**: jsPlumb Community Edition
- **UI Components**: Angular Material
- **State Management**: NgRx
- **Styles**: SCSS avec thème Glass
- **Éditeur SQL**: Monaco Editor

### Backend
- **Framework**: ASP.NET Core 9 Web API
- **ORM**: Entity Framework Core
- **Base de données**: MySQL 8.0+
- **Authentification**: BCrypt.Net
- **Architecture**: Clean Architecture (Domain, Application, Infrastructure)

## 📁 Structure du Projet

```
OpenCreatorSuite/
├── Documentation/              # Documentation complète
│   ├── CAHIER-DES-CHARGES.md
│   ├── ARCHITECTURE-TECHNIQUE.md
│   ├── FONCTIONNALITES.md
│   └── ...
├── src/
│   ├── OpenCreatorStudio.Web/  # Application Angular
│   └── OpenCreatorStudio.API/  # Backend .NET 9
└── README.md
```

## 📚 Documentation

La documentation complète du projet se trouve dans le dossier `Documentation/` :

- **CAHIER-DES-CHARGES-COMPLET.md** - Spécifications complètes du projet
- **ARCHITECTURE-TECHNIQUE.md** - Architecture et stack technique
- **FONCTIONNALITES-DETAILLEES.md** - Description détaillée des fonctionnalités
- **DESIGN-SYSTEM.md** - Spécifications du design Glass
- **ROADMAP.md** - Planification du développement
- **POINTS-D-ATTENTION.md** - Recommandations et bonnes pratiques

## 🔧 Installation

### Prérequis
- Node.js 20+
- Angular CLI 20+
- .NET 9 SDK
- MySQL 8.0+
- Visual Studio 2022

### Configuration

```bash
# Clone du repository
git clone https://github.com/libremax534/OpenCreatorSuite.git
cd OpenCreatorSuite

# Installation Frontend
cd src/OpenCreatorStudio.Web
npm install

# Installation Backend
cd ../OpenCreatorStudio.API
dotnet restore
```

## 🏃 Démarrage

### Frontend Angular
```bash
cd src/OpenCreatorStudio.Web
ng serve
# Application accessible sur http://localhost:4200
```

### Backend .NET
```bash
cd src/OpenCreatorStudio.API
dotnet run
# API accessible sur https://localhost:5001
```

## 📝 Développement

### Philosophie de Code

Le projet suit les principes de **Clean Code** et **Clean Architecture** :

- **Séparation des responsabilités** : Domain, Application, Infrastructure
- **Code commenté** : Explications claires pour débutants
- **Commentaires alignés** : Lisibilité optimale
- **Tests unitaires** : Couverture minimale 80%

### Conventions de Commit

```
feat: Nouvelle fonctionnalité
fix: Correction de bug
docs: Documentation
style: Formatage, style
refactor: Refactoring
test: Ajout de tests
chore: Tâches de maintenance
```

## 🗓️ Roadmap

### ✅ Phase 1: POC (4 semaines)
- Architecture Angular + Backend
- Authentification BCrypt
- Canvas avec jsPlumb
- Création de nœuds basiques

### 🔨 Phase 2: Fonctionnalités Core (6 semaines)
- 10 types de nœuds complets
- Panneau propriétés
- Éditeur SQL Monaco
- Système Undo/Redo

### 🔨 Phase 3: Intégration MySQL (4 semaines)
- Déploiement vers MySQL
- Génération procédures stockées
- Synchronisation complète

## 👥 Contributeurs

- **Fournier Laurent** - Développeur principal - [libremax534](https://github.com/libremax534)

## 📄 Licence

Ce projet est sous licence privée.

## 📧 Contact

- Email: contact@fournierlaurent.com
- GitHub: [@libremax534](https://github.com/libremax534)

---

**Projet OpenCreatorSuite** - Migration OpenCreator WPF vers Angular 20 + .NET 9