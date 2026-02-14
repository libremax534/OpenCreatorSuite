## 6. POINTS D'ATTENTION ET RECOMMANDATIONS
### 6.1 Bibliothèque de Graphes
Recommandation: jsPlumb Community Edition

✅ Gratuit et open-source

✅ Support drag & drop natif

✅ Gestion automatique des connexions

✅ Anchors configurables par côté

✅ Overlays (flèches, labels)

✅ Bonne documentation

Alternative: GoJS (payante mais plus puissante)

### 6.2 Éditeur SQL
Recommandation: Monaco Editor (VS Code)

✅ Coloration syntaxique SQL

✅ Autocomplétion

✅ Thèmes sombres

✅ Intégration Angular simple

Alternative: CodeMirror 6

### 6.3 Performance
Optimisations critiques:

Virtual Scrolling: Pour grandes listes de nœuds (CDK Virtual Scroll)

OnPush Change Detection: Tous les composants de nœuds

TrackBy Functions: Dans les *ngFor

Lazy Loading: Modules par fonctionnalité

Web Workers: Pour calculs de géométrie de flèches

Debounce: Sur les événements de déplacement

### 6.4 Sécurité
Mesures impératives:

JWT avec refresh tokens

HTTPS obligatoire en production

CORS correctement configuré

SQL Injection Prevention: Requêtes paramétrées

Rate Limiting: Sur API d'authentification

Input Validation: Frontend ET backend

XSS Protection: Sanitization des inputs


### 6.5 Tests
Couverture minimale:

Unit Tests: Services (≥ 80%)

Integration Tests: API Controllers

E2E Tests: Parcours critiques (création nœud, connexion, déploiement)

Visual Regression: Composants UI avec Percy/Chromatic