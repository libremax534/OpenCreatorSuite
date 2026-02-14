# Documentation OpenCreatorSuite

Ce dossier contient la documentation complète du projet de migration OpenCreator vers Angular 20 + .NET 9.

## 📚 Table des Matières

### Documents Principaux
1. **CAHIER-DES-CHARGES-COMPLET.md** - Spécifications complètes du projet
2. **ARCHITECTURE-TECHNIQUE.md** - Détails de l'architecture technique
3. **DESIGN-SYSTEM.md** - Système de design Glass
4. **ROADMAP.md** - Planning de développement
5. **POINTS-ATTENTION-RECOMMANDATIONS.md** - Points critiques et bonnes pratiques

### Analyses Fonctionnelles
6. **Analyse-SQL-Editor.md** - Analyse détaillée de l'éditeur SQL
7. **Analyse-StoredProcedureCatalog.md** - Catalogue des procédures stockées

## 📄 Description des Documents

### CAHIER-DES-CHARGES-COMPLET.md
Document de référence définissant:
- Contexte et objectifs de migration
- Environnement de développement
- Méthodologie Clean Code
- Standards de documentation

### ARCHITECTURE-TECHNIQUE.md
Détaille la stack technologique:
- **Frontend**: Angular 20, jsPlumb, Monaco Editor
- **Backend**: ASP.NET Core 9, Entity Framework, MySQL
- Structure complète des projets

### DESIGN-SYSTEM.md
Spécifications du design glassmorphism:
- Variables SCSS globales
- Mixins pour composants
- Styles et thèmes

### ROADMAP.md
Planification en 3 phases:
- **Phase 1**: POC (4 semaines)
- **Phase 2**: Fonctionnalités Core (6 semaines)
- **Phase 3**: Intégration MySQL (4 semaines)

### POINTS-ATTENTION-RECOMMANDATIONS.md
Recommandations sur:
- Choix des bibliothèques
- Optimisations performance
- Sécurité
- Tests

### Analyse-SQL-Editor.md
Analyse complète (36KB) de l'éditeur SQL WPF:
- Architecture 3 colonnes
- AvalonEdit → Monaco Editor
- Recherche/Remplacement
- Formatage SQL
- Test de procédures
- Chat IA intégré

### Analyse-StoredProcedureCatalog.md
Documentation du catalogue central (24KB):
- Architecture hybride Mémoire + MySQL
- 5 types de trames WCS (PRQ, LBC, DRQ, SRE, IRQ)
- 76 paramètres au total
- Synchronisation automatique

## 🛠️ Utilisation

### Pour les Développeurs
1. Lire d'abord le **CAHIER-DES-CHARGES-COMPLET.md**
2. Consulter l'**ARCHITECTURE-TECHNIQUE.md** pour comprendre la structure
3. Référer au **DESIGN-SYSTEM.md** lors du développement UI
4. Suivre la **ROADMAP.md** pour les priorités

### Pour la Migration de Composants
- Consulter les analyses détaillées (SQL Editor, StoredProcedureCatalog)
- Chaque analyse contient:
  - Architecture WPF d'origine
  - Plan de migration Angular
  - Exemples de code
  - Points d'attention spécifiques

## 📝 Standards de Documentation

Tous les documents suivent:
- Format Markdown
- Exemples de code commentés
- Diagrammes ASCII pour architecture
- Tableaux de récapitulatif

## 🔗 Liens Utiles

- Projet source WPF: https://github.com/libremax534/OpenCreator.git
- Projet Angular: https://github.com/libremax534/OpenCreatorSuite.git

---

**Mise à jour**: Février 2026  
**Auteur**: Fournier Laurent