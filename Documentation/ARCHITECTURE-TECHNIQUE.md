## 2. ARCHITECTURE TECHNIQUE
2.1 Stack Technologique
Frontend Angular
Framework: Angular 17+ (dernière version stable)

Bibliothèque de graphes: jsPlumb Community Edition ou GoJS (alternative commerciale)

Gestion du drag & drop

Rendu des nœuds et connexions

Zoom et pan sur canvas

UI Components: Angular Material ou PrimeNG (pour dialogues, menus)

Styles: SCSS avec variables pour thème Glass

State Management: NgRx ou Services avec RxJS

HTTP Client: HttpClient pour API calls

Backend .NET
Framework: ASP.NET Core 8+ Web API

ORM: Entity Framework Core

Base de données: MySQL 8+

Authentification: BCrypt.Net pour hachage

Architecture: Clean Architecture (3 couches)

Domain: Entités métier

Application: Services et Use Cases

Infrastructure: Accès données, MySQL


## 2.2 Structure du Projet Angular
```
OpenCreatorStudio/
├── src/
│   ├── app/
│   │   ├── core/
│   │   │   ├── models/           # Modèles de données
│   │   │   ├── services/         # Services métier
│   │   │   ├── guards/           # Guards d'authentification
│   │   │   └── interceptors/     # HTTP interceptors
│   │   ├── features/
│   │   │   ├── authentication/   # Module de connexion
│   │   │   ├── graph-editor/     # Éditeur graphique
│   │   │   ├── node-palette/     # Palette de composants
│   │   │   ├── properties-panel/ # Panneau propriétés
│   │   │   ├── project-log/      # Journal de projet
│   │   │   └── sql-editor/       # Éditeur SQL
│   │   ├── shared/
│   │   │   ├── components/       # Composants réutilisables
│   │   │   ├── directives/       # Directives custom
│   │   │   └── pipes/            # Pipes custom
│   │   └── app.component.ts
│   ├── assets/
│   │   ├── images/              # Logos, icônes, fond
│   │   └── styles/              # Styles globaux
│   └── environments/            # Configuration env
```

2.3 Structure Backend .NET
```
OpenCreatorStudio.API/
├── Domain/
│   ├── Entities/
│   │   ├── DecisionNode.cs
│   │   ├── Connection.cs
│   │   ├── User.cs
│   │   └── Project.cs
│   └── Enums/
│       └── FrameType.cs
├── Application/
│   ├── Interfaces/
│   ├── Services/
│   │   ├── AuthenticationService.cs
│   │   ├── NodeService.cs
│   │   ├── ConnectionService.cs
│   │   └── DeploymentService.cs
│   └── DTOs/
├── Infrastructure/
│   ├── Data/
│   │   ├── ApplicationDbContext.cs
│   │   └── Repositories/
│   └── MySQL/
│       └── StoredProcedureGenerator.cs
└── API/
    ├── Controllers/
    │   ├── AuthController.cs
    │   ├── NodesController.cs
    │   ├── ConnectionsController.cs
    │   └── ProjectsController.cs
    └── Program.cs
```