# OpenCreatorStudio Web (Frontend Angular)

Application frontend Angular 20 pour OpenCreatorStudio.

## 🚀 Démarrage Rapide

```bash
# Installation des dépendances
npm install

# Démarrage du serveur de développement
npm start

# Application accessible sur http://localhost:4200
```

## 📚 Structure du Projet

```
src/
├── app/
│   ├── core/                 # Services, guards, interceptors
│   │   ├── models/           # Modèles de données
│   │   ├── services/         # Services métier
│   │   ├── guards/           # Guards d'authentification
│   │   └── interceptors/     # HTTP interceptors
│   ├── features/             # Modules fonctionnels
│   │   ├── authentication/   # Module de connexion
│   │   ├── graph-editor/     # Éditeur graphique
│   │   ├── node-palette/     # Palette de composants
│   │   ├── properties-panel/ # Panneau propriétés
│   │   ├── project-log/      # Journal de projet
│   │   └── sql-editor/       # Éditeur SQL
│   ├── shared/               # Composants partagés
│   │   ├── components/       # Composants réutilisables
│   │   ├── directives/       # Directives custom
│   │   └── pipes/            # Pipes custom
│   └── app.component.ts
├── assets/
│   ├── images/              # Logos, icônes, fond
│   └── styles/              # Styles globaux SCSS
└── environments/            # Configuration environnements
```

## 🛠️ Technologies

- **Angular 20** - Framework principal
- **Angular Material** - Composants UI
- **jsPlumb** - Bibliothèque de graphes
- **Monaco Editor** - Éditeur SQL
- **NgRx** - Gestion d'état
- **SCSS** - Styles avec thème Glass

## 📝 Scripts Disponibles

- `npm start` - Démarrage du serveur de développement
- `npm run build` - Build de production
- `npm test` - Exécution des tests
- `npm run watch` - Build en mode watch

## 🎨 Design System

Le projet utilise un thème **glassmorphism** avec:
- Variables SCSS dans `assets/styles/_variables.scss`
- Mixins dans `assets/styles/_mixins.scss`
- Styles globaux dans `assets/styles/styles.scss`

## 🔗 Liens

- Documentation complète: `/Documentation`
- API Backend: `http://localhost:5001`
