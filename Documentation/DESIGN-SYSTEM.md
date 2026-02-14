## 4. DESIGN SYSTEM - EFFET GLASS
### 4.1 Variables SCSS Globales
Fichier: src/assets/styles/_variables.scss
```
text
// === COULEURS GLASS THEME ===

// Fonds sombres
$bg-primary: #0F0F23;
$bg-secondary: #111827;
$bg-glass: rgba(26, 17, 24, 0.1);

// Bordures
$border-glass: #334155;
$border-glass-light: #4B5563;

// Textes
$text-primary: #F9FAFB;
$text-secondary: #E5E7EB;
$text-muted: #9CA3AF;
$text-disabled: #6B7280;

// Accents
$accent-blue: #3B82F6;
$accent-blue-dark: #1E3A8A;
$accent-orange: #F59E0B;
$accent-green: #10B981;
$accent-red: #DC2626;
$accent-purple: #8524d4;

// Dégradés
$gradient-primary: linear-gradient(135deg, #1E3A8A 0%, #3B82F6 100%);

// Ombres
$shadow-glass: 0 8px 32px 0 rgba(0, 0, 0, 0.37);
$shadow-node: 0 4px 16px 0 rgba(0, 0, 0, 0.25);

// Effets
$blur-amount: 10px;
$border-radius: 14px;
$border-radius-small: 8px;

// Transitions
$transition-fast: 0.2s ease;
$transition-normal: 0.3s ease;
```

### 4.2 Mixins SCSS
Fichier: src/assets/styles/_mixins.scss
```
text
// Mixin panneau glass
@mixin glass-panel {
  background: $bg-glass;
  backdrop-filter: blur($blur-amount);
  -webkit-backdrop-filter: blur($blur-amount);
  border: 1px solid $border-glass;
  border-radius: $border-radius;
  box-shadow: $shadow-glass;
}

// Mixin bouton glass
@mixin glass-button {
  background: $bg-secondary;
  border: 1px solid $border-glass-light;
  border-radius: $border-radius-small;
  color: $text-secondary;
  padding: 8px 16px;
  font-size: 12px;
  cursor: pointer;
  transition: all $transition-fast;
  
  &:hover {
    background: #374151;
    transform: translateY(-1px);
  }
  
  &:active {
    transform: translateY(0);
  }
  
  &:disabled {
    opacity: 0.5;
    cursor: not-allowed;
  }
}

// Mixin input glass
@mixin glass-input {
  background: #020617;
  border: 1px solid $border-glass-light;
  border-radius: 6px;
  color: $text-primary;
  padding: 8px 12px;
  font-size: 13px;
  transition: border-color $transition-fast;
  
  &:focus {
    outline: none;
    border-color: $accent-blue;
  }
  
  &::placeholder {
    color: $text-disabled;
  }
  
  &:disabled, &.readonly {
    background: #1F2937;
    color: $text-muted;
    cursor: not-allowed;
  }
}
```

### 4.3 Styles Globaux
Fichier: src/assets/styles/styles.scss
```
text
@import 'variables';
@import 'mixins';

// Reset et base
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif;
  background: $bg-primary;
  color: $text-primary;
  overflow: hidden;
}

// Classes utilitaires
.glass-panel {
  @include glass-panel;
}

.glass-button {
  @include glass-button;
}

.glass-input {
  @include glass-input;
}

// Header gradient
.app-header {
  background: $gradient-primary;
  box-shadow: $shadow-glass;
  padding: 16px 24px;
}

// Scrollbar personnalisée
::-webkit-scrollbar {
  width: 8px;
  height: 8px;
}

::-webkit-scrollbar-track {
  background: $bg-secondary;
}

::-webkit-scrollbar-thumb {
  background: $border-glass-light;
  border-radius: 4px;
  
  &:hover {
    background: #6B7280;
  }
}
```