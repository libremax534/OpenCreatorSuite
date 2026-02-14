import { Injectable, signal } from '@angular/core';

export interface Notification {
  id: string;
  type: 'success' | 'error' | 'warning' | 'info';
  message: string;
  duration?: number;
}

/**
 * Service de gestion des notifications toast.
 */
@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private notifications = signal<Notification[]>([]);
  public notifications$ = this.notifications.asReadonly();

  /**
   * Affiche une notification de succès.
   */
  success(message: string, duration: number = 3000): void {
    this.show('success', message, duration);
  }

  /**
   * Affiche une notification d'erreur.
   */
  error(message: string, duration: number = 5000): void {
    this.show('error', message, duration);
  }

  /**
   * Affiche une notification d'avertissement.
   */
  warning(message: string, duration: number = 4000): void {
    this.show('warning', message, duration);
  }

  /**
   * Affiche une notification d'information.
   */
  info(message: string, duration: number = 3000): void {
    this.show('info', message, duration);
  }

  /**
   * Affiche une notification générique.
   */
  private show(
    type: Notification['type'],
    message: string,
    duration: number
  ): void {
    const notification: Notification = {
      id: this.generateId(),
      type,
      message,
      duration
    };

    this.notifications.update(notifications => [...notifications, notification]);

    // Auto-suppression après la durée spécifiée
    if (duration > 0) {
      setTimeout(() => this.remove(notification.id), duration);
    }
  }

  /**
   * Supprime une notification.
   */
  remove(id: string): void {
    this.notifications.update(notifications =>
      notifications.filter(n => n.id !== id)
    );
  }

  /**
   * Supprime toutes les notifications.
   */
  clear(): void {
    this.notifications.set([]);
  }

  /**
   * Génère un ID unique pour la notification.
   */
  private generateId(): string {
    return `notif_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;
  }
}
