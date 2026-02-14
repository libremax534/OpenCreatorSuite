# CAHIER DES CHARGES COMPLET - OpenCreatorStudio

📋 INFORMATIONS GÉNÉRALES
Projet: OpenCreatorStudio
Type: Migration OpenCreator (WPF C#) vers Angular
Environnement: Visual Studio 2022
Architecture: Clean Code / Clean Architecture
Date: Février 2026

## 1. CONTEXTE ET OBJECTIFS
### 1.1 Projet Source : OpenCreator
OpenCreator est un éditeur graphique de workflow WCS (Warehouse Control System) développé en WPF/C# permettant de:

Créer des graphes de processus métier via drag & drop

Générer automatiquement des procédures stockées MySQL

Gérer des connexions conditionnelles entre nœuds

Déployer et synchroniser avec une base MySQL


### 1.2 Objectif de Migration
Recréer intégralement OpenCreator en Angular avec:

Style visuel: Effet Glass identique (glassmorphism)

Authentification: BCrypt avec table utilisateurs MySQL

Fonctionnalités: 100% des features d'origine

Architecture: Clean Code avec séparation des couches

Pour analyse le projet se trouve dans le dossier "OpenCreator" du github à l'adresse:
https://github.com/libremax534/OpenCreator.git

le nouveau projet se trouve dans le dossier "OpenCreatorSuite" du github à l'adresse:
https://github.com/libremax534/OpenCreatorSuite.git

l'ensemble des fichiers devront etre mise en place dans le dossier "OpenCreatorSuite" du github à l'adresse:
https://github.com/libremax534/OpenCreatorSuite.git



## 2. Documentations
La documentation du projet est constitué de plusieurs sections détaillant les aspects techniques, fonctionnels et de gestion du projet.
Chaque section est enregistré dans le fichier correspondant qui est placé dans le context du projet, à savoir:

- `ARCHITECTURE TECHNIQUE.md`: Détails techniques sur l'implémentation, les technologies utilisées, et les choix d'architecture.

- `FONCTIONNALITÉS DÉTAILLÉES.md`: Description détaillée de chaque fonctionnalité à implémenter, avec des exemples d'utilisation.

- `DESIGN SYSTEM.md`: Spécifications de design pour l'interface utilisateur, y compris les maquettes et les directives de style.

- `POINTS D'ATTENTION ET RECOMMANDATIONS.md`: Liste des points critiques à surveiller pendant le développement, tels que les performances, la sécurité, et la compatibilité.

- `ROADMAP.md`: Planification des étapes de développement, avec les jalons et les échéances.

- `MAPPING FONCTIONNEL.md`: Tableau de correspondance entre les fonctionnalités WPF et leur implémentation Angular, avec le statut de chaque fonctionnalité.

- `Analyse Complète - SQL Editor.md`: Analyse détaillée de la fonctionnalité d'éditeur SQL, y compris les composants nécessaires, les services backend, et les points d'attention spécifiques à cette fonctionnalité.

- `Analyse Complète - StoredProcedureCatalog.md`: Analyse détaillée de la fonctionnalité de catalogue de procédures stockées, avec les composants nécessaires, les services backend, et les points d'attention spécifiques à cette fonctionnalité.

- `SOLUTIONS DÉTAILLÉES - Problèmes Migration OpenCreator.md`: Document détaillant les solutions proposées pour les problèmes rencontrés lors de la migration, avec des exemples de code et des explications techniques.

## 3. Environnement de Développement

- IDE: Visual Studio 2022
- backend: .NET 9 Web API
- database: MySQL 8.0
- frontend: Angular 20
- langage: TypeScript pour Angular, C# pour backend

## 4. Méthodologie de Développement
La solution crée devra etre implémenté selon la philosophie de Clean Code et Clean Architecture.
Elle devra etre créer et executable sous visual studio 2022.
On dois pouvoir aussi l'ouvrir et l'executer sous vsCode si besoin.

Les fichiers générés devront etre obligatoirement commenté pour qu'un débutant puisse comprendre le code.

Les commentaires devront fournir des explications claires et concises des fonctionnalités.
Les commentaires de fonctions devront être au dessus de la fonction.
les commentaires de variables devront etre au 2/3 de l'écran, ils devront etre tous alignés les un par rapport aux autres pour avoir une lisibilité parfaite.

Les markdowns devront etre mis dans le dossier "Documentations".
Il faudra créer des fichiers markdowns pour expliquer le fonctionnement complet de la solution ainsi que pour charque grande fonctionalité de la suite.

## 5. Conclusion

Ce cahier des charges complet fournit une base solide pour la migration d'OpenCreator vers Angular, en détaillant les objectifs, les fonctionnalités, et les aspects techniques du projet. En suivant ce document, l'équipe de développement pourra assurer une transition fluide tout en maintenant la qualité et les performances de l'application.