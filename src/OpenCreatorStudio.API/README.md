# OpenCreatorStudio API (Backend .NET 9)

API backend ASP.NET Core 9 avec Clean Architecture pour OpenCreatorStudio.

## 🏛️ Architecture Clean Architecture

Le projet suit les principes de Clean Architecture avec 4 couches:

### 1. Domain (Couche Domaine)
- **Entités métier**: `DecisionNode`, `Connection`, `User`, `Project`
- **Enums**: `FrameType`, `ParameterDirection`
- **Interfaces du domaine**
- **Aucune dépendance externe**

### 2. Application (Couche Application)
- **Services métier**: `AuthenticationService`, `NodeService`, `ConnectionService`
- **DTOs**: Objets de transfert de données
- **Interfaces des services**
- **Use Cases**: Logique métier
- **Dépendances**: Domain uniquement

### 3. Infrastructure (Couche Infrastructure)
- **Accès aux données**: `ApplicationDbContext`, Repositories
- **Services externes**: MySQL, générateurs de procédures stockées
- **Implémentations**: Interfaces de Application
- **Dépendances**: Application, Domain, Entity Framework, MySQL

### 4. API (Couche Présentation)
- **Controllers**: Points d'entrée HTTP
- **Middlewares**: Gestion des erreurs, authentification
- **Configuration**: Startup, DI container
- **Dépendances**: Toutes les couches

## 🚀 Démarrage Rapide

```bash
# Restauration des packages
dotnet restore

# Configuration de la chaîne de connexion MySQL
# Editer appsettings.json

# Exécution de l'API
dotnet run --project API/OpenCreatorStudio.API.csproj

# API accessible sur https://localhost:5001
```

## 📚 Structure Complète

```
OpenCreatorStudio.API/
├── Domain/
│   ├── Entities/
│   │   ├── DecisionNode.cs          # Entité nœud
│   │   ├── Connection.cs            # Entité connexion
│   │   ├── User.cs                  # Entité utilisateur
│   │   └── Project.cs               # Entité projet
│   └── Enums/
│       └── FrameType.cs             # Types de nœuds
├── Application/
│   ├── Interfaces/
│   │   ├── IAuthenticationService.cs
│   │   ├── INodeService.cs
│   │   └── IConnectionService.cs
│   ├── Services/
│   │   ├── AuthenticationService.cs # Authentification BCrypt
│   │   ├── NodeService.cs           # Gestion des nœuds
│   │   ├── ConnectionService.cs     # Gestion des connexions
│   │   └── DeploymentService.cs     # Déploiement MySQL
│   └── DTOs/
│       ├── AuthRequest.cs
│       ├── AuthResponse.cs
│       └── NodeDto.cs
├── Infrastructure/
│   ├── Data/
│   │   ├── ApplicationDbContext.cs  # Contexte EF Core
│   │   └── Repositories/
│   │       ├── UserRepository.cs
│   │       ├── NodeRepository.cs
│   │       └── ProjectRepository.cs
│   └── MySQL/
│       └── StoredProcedureGenerator.cs # Générateur SQL
└── API/
    ├── Controllers/
    │   ├── AuthController.cs        # Authentification
    │   ├── NodesController.cs       # CRUD nœuds
    │   ├── ConnectionsController.cs # CRUD connexions
    │   └── ProjectsController.cs    # CRUD projets
    ├── Program.cs                   # Configuration startup
    └── appsettings.json             # Configuration
```

## 🛠️ Technologies

- **ASP.NET Core 9** - Framework Web API
- **Entity Framework Core** - ORM
- **MySQL 8.0+** - Base de données
- **BCrypt.Net** - Hachage des mots de passe
- **Swashbuckle** - Documentation Swagger

## 🔐 Sécurité

- **Authentification BCrypt** pour les mots de passe
- **JWT** pour les tokens (future implémentation)
- **HTTPS** obligatoire en production
- **CORS** configuré pour Angular frontend
- **Validation** sur tous les endpoints

## 📝 Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "MySql": "Server=localhost;Database=opencreator;User=root;Password=***;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## 📦 Packages NuGet

- `Microsoft.EntityFrameworkCore` - ORM
- `Pomelo.EntityFrameworkCore.MySql` - Provider MySQL
- `BCrypt.Net-Next` - Hachage BCrypt
- `Swashbuckle.AspNetCore` - Swagger/OpenAPI

## 📚 Scripts Disponibles

- `dotnet build` - Compilation du projet
- `dotnet run` - Exécution de l'API
- `dotnet test` - Exécution des tests
- `dotnet ef migrations add <Name>` - Création migration
- `dotnet ef database update` - Mise à jour base de données

## 🔗 Endpoints Principaux

### Authentification
- `POST /api/auth/login` - Connexion utilisateur
- `POST /api/auth/register` - Inscription (admin)

### Nœuds
- `GET /api/nodes` - Liste des nœuds
- `GET /api/nodes/{id}` - Détails d'un nœud
- `POST /api/nodes` - Création d'un nœud
- `PUT /api/nodes/{id}` - Mise à jour d'un nœud
- `DELETE /api/nodes/{id}` - Suppression d'un nœud

### Connexions
- `GET /api/connections` - Liste des connexions
- `POST /api/connections` - Création d'une connexion
- `DELETE /api/connections/{id}` - Suppression d'une connexion

### Projets
- `GET /api/projects` - Liste des projets
- `GET /api/projects/{id}` - Détails d'un projet
- `POST /api/projects` - Création d'un projet
- `POST /api/projects/{id}/deploy` - Déploiement MySQL

## 🔗 Liens

- Frontend Angular: `http://localhost:4200`
- Swagger UI: `https://localhost:5001/swagger`
- Documentation: `/Documentation`
