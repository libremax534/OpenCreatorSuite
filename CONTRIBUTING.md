# 🤝 Guide de Contribution - OpenCreatorSuite

Merci de votre intérêt pour contribuer à OpenCreatorSuite !

## 📋 Table des Matières

- [Code de Conduite](#code-de-conduite)
- [Comment Contribuer](#comment-contribuer)
- [Standards de Code](#standards-de-code)
- [Process de Pull Request](#process-de-pull-request)
- [Conventions de Commit](#conventions-de-commit)

## 📜 Code de Conduite

Ce projet adhère à un code de conduite. En participant, vous vous engagez à respecter ce code.

### Nos Engagements

- Utiliser un langage accueillant et inclusif
- Respecter les différents points de vue et expériences
- Accepter gracieusement les critiques constructives
- Se concentrer sur ce qui est le mieux pour la communauté

## 🚀 Comment Contribuer

### Signaler un Bug

1. Vérifiez que le bug n'a pas déjà été signalé dans les [Issues](https://github.com/libremax534/OpenCreatorSuite/issues)
2. Créez une nouvelle issue avec:
   - Titre descriptif
   - Description détaillée
   - Étapes pour reproduire
   - Comportement attendu vs actuel
   - Captures d'écran si pertinent
   - Version de l'application

### Proposer une Fonctionnalité

1. Ouvrez une issue avec le label `enhancement`
2. Décrivez la fonctionnalité en détail
3. Expliquez pourquoi elle serait utile
4. Proposez une implémentation si possible

### Soumettre du Code

1. **Forkez** le repository
2. **Créez** une branche depuis `main`:
   ```bash
   git checkout -b feature/ma-nouvelle-fonctionnalite
   ```
3. **Commitez** vos changements avec des messages clairs
4. **Pushez** vers votre fork
5. **Ouvrez** une Pull Request

## 📝 Standards de Code

### Frontend (Angular/TypeScript)

#### Style

- Suivre le [Angular Style Guide](https://angular.io/guide/styleguide)
- Indentation: 2 espaces
- Utiliser les **signals** pour la gestion d'état
- Composants **standalone** uniquement
- Nommer les fichiers en **kebab-case**: `my-component.ts`

#### TypeScript

```typescript
// ✅ Bon
export interface User {
  id: number;
  username: string;
}

export class UserService {
  private http = inject(HttpClient);
  
  getUser(id: number): Observable<User> {
    return this.http.get<User>(`/api/users/${id}`);
  }
}

// ❌ Mauvais
export interface user {
  ID: number;
  UserName: string;
}
```

#### SCSS

- Utiliser les **variables** et **mixins** définis dans `_variables.scss` et `_mixins.scss`
- Ne pas utiliser de styles inline
- Préfixer les classes spécifiques au composant

```scss
// ✅ Bon
.user-card {
  @include glass-card;
  padding: $spacing-md;
}

// ❌ Mauvais
.card {
  background: rgba(30, 41, 59, 0.6);
  padding: 16px;
}
```

### Backend (.NET/C#)

#### Style

- Suivre les [conventions C#](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Indentation: 4 espaces
- Utiliser **PascalCase** pour les classes et méthodes
- Utiliser **camelCase** pour les paramètres
- Toujours ajouter des **commentaires XML** pour les API publiques

#### Architecture

```csharp
// ✅ Bon - Clean Architecture
namespace OpenCreatorStudio.Application.Services;

/// <summary>
/// Service de gestion des utilisateurs.
/// </summary>
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<User> GetUserAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}

// ❌ Mauvais - Dépendance directe au DbContext
public class UserService
{
    private readonly ApplicationDbContext _context;
    // ...
}
```

### Base de Données

- Utiliser **Entity Framework Core** pour toutes les opérations
- Créer des **migrations** pour chaque changement de schéma
- Nommer les tables en **snake_case**: `decision_nodes`
- Toujours ajouter des **index** sur les clés étrangères

## 🔄 Process de Pull Request

### Avant de Soumettre

- [ ] Le code compile sans erreurs
- [ ] Les tests passent
- [ ] Le code respecte les standards
- [ ] La documentation est à jour
- [ ] Les commits sont propres et descriptifs

### Template de Pull Request

```markdown
## Description
Brève description des changements.

## Type de Changement
- [ ] Bug fix
- [ ] Nouvelle fonctionnalité
- [ ] Breaking change
- [ ] Documentation

## Tests
Décrivez les tests effectués.

## Captures d'Écran
Si applicable, ajoutez des captures d'écran.

## Checklist
- [ ] Code compilé et testé
- [ ] Documentation mise à jour
- [ ] Tests unitaires ajoutés/mis à jour
```

## 📝 Conventions de Commit

Nous suivons la convention [Conventional Commits](https://www.conventionalcommits.org/).

### Format

```
<type>(<scope>): <description>

[corps optionnel]

[footer optionnel]
```

### Types

- **feat**: Nouvelle fonctionnalité
- **fix**: Correction de bug
- **docs**: Documentation uniquement
- **style**: Formatage, point-virgules manquants, etc.
- **refactor**: Refactoring du code
- **perf**: Amélioration des performances
- **test**: Ajout de tests
- **chore**: Maintenance, dépendances, etc.

### Exemples

```bash
# Nouvelle fonctionnalité
feat(graph-editor): ajout du drag & drop pour les nœuds

# Correction de bug
fix(auth): correction de la validation du token JWT

# Documentation
docs(readme): mise à jour du guide d'installation

# Refactoring
refactor(node-service): simplification de la logique de création
```

## ✨ Bonnes Pratiques

### Git

1. **Une fonctionnalité = Une branche**
2. **Commits fréquents** et atomiques
3. **Rebase** avant de merger
4. **Squash** les commits de fix

### Code Review

1. Soyez **constructif** et **respectueux**
2. Expliquez le **pourquoi**, pas seulement le **quoi**
3. Proposez des **alternatives** si nécessaire
4. Approuvez rapidement les bonnes PR

### Tests

1. **Tests unitaires** pour la logique métier
2. **Tests d'intégration** pour les API
3. **Tests E2E** pour les flux critiques
4. Viser **>80% de couverture**

## 📚 Ressources

- [Documentation Angular](https://angular.io/docs)
- [Documentation .NET](https://docs.microsoft.com/dotnet/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

## 📧 Contact

Pour toute question:

- Ouvrez une [Discussion GitHub](https://github.com/libremax534/OpenCreatorSuite/discussions)
- Contactez les mainteneurs via issue

---

Merci de contribuer à OpenCreatorSuite ! 🚀
