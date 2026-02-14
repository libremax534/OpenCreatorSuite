# Migrations MySQL

Ce dossier contient les scripts de migration MySQL pour OpenCreatorStudio.

## Ordre d'exécution

1. **001_InitialCreate.sql** - Création des tables principales
   - users
   - projects
   - decision_nodes
   - connections

## Application des migrations

### Méthode 1 : Ligne de commande MySQL

```bash
mysql -u root -p opencreator < 001_InitialCreate.sql
```

### Méthode 2 : Entity Framework Core

```bash
cd src/OpenCreatorStudio.API/API
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Création d'un utilisateur admin

Pour créer un mot de passe BCrypt:

```csharp
using BCrypt.Net;

var hash = BCrypt.HashPassword("admin123");
Console.WriteLine(hash);
```

Puis remplacer `$2a$11$YourBCryptHashHere` dans le script SQL.

## Structure de la base

```
opencreator
├── users
│   ├── Id (PK)
│   ├── Username (UNIQUE)
│   ├── PasswordHash
│   ├── Email
│   ├── CreatedAt
│   └── LastLoginAt
├── projects
│   ├── Id (PK)
│   ├── Name
│   ├── Description
│   ├── UserId (FK)
│   ├── CreatedAt
│   └── UpdatedAt
├── decision_nodes
│   ├── Id (PK)
│   ├── ProjectId (FK)
│   ├── Name
│   ├── FrameType
│   ├── StoredProcedureName
│   ├── BodyScript
│   ├── PositionX/Y
│   ├── Width/Height
│   ├── CreatedAt
│   └── UpdatedAt
└── connections
    ├── Id (PK)
    ├── ProjectId (FK)
    ├── SourceNodeId (FK)
    ├── TargetNodeId (FK)
    ├── Label
    └── CreatedAt
```
