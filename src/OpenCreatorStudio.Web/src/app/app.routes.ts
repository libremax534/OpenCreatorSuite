import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadComponent: () => import('./features/authentication/login/login.component')
      .then(m => m.LoginComponent)
  },
  {
    path: 'editor',
    canActivate: [authGuard],
    loadComponent: () => import('./features/graph-editor/graph-editor.component')
      .then(m => m.GraphEditorComponent)
  },
  {
    path: '**',
    redirectTo: 'login'
  }
];
