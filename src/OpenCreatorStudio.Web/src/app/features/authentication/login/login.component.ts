import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  username = signal('');
  password = signal('');
  isLoading = signal(false);
  errorMessage = signal('');

  onSubmit(): void {
    if (!this.username() || !this.password()) {
      this.errorMessage.set('Veuillez remplir tous les champs');
      return;
    }

    this.isLoading.set(true);
    this.errorMessage.set('');

    this.authService.login(this.username(), this.password())
      .subscribe({
        next: (response) => {
          if (response.success) {
            this.router.navigate(['/editor']);
          } else {
            this.errorMessage.set(response.message || 'Erreur de connexion');
          }
          this.isLoading.set(false);
        },
        error: (error) => {
          console.error('Erreur login:', error);
          this.errorMessage.set('Identifiants incorrects');
          this.isLoading.set(false);
        }
      });
  }
}
