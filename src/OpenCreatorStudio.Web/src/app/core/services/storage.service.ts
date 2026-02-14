import { Injectable } from '@angular/core';

/**
 * Service de gestion du localStorage.
 * Fournit des méthodes typées pour stocker et récupérer des données.
 */
@Injectable({
  providedIn: 'root'
})
export class StorageService {
  /**
   * Sauvegarde une valeur dans le localStorage.
   */
  set<T>(key: string, value: T): void {
    try {
      const serialized = JSON.stringify(value);
      localStorage.setItem(key, serialized);
    } catch (error) {
      console.error(`Erreur sauvegarde localStorage [${key}]:`, error);
    }
  }

  /**
   * Récupère une valeur depuis le localStorage.
   */
  get<T>(key: string): T | null {
    try {
      const item = localStorage.getItem(key);
      if (!item) return null;
      return JSON.parse(item) as T;
    } catch (error) {
      console.error(`Erreur lecture localStorage [${key}]:`, error);
      return null;
    }
  }

  /**
   * Supprime une clé du localStorage.
   */
  remove(key: string): void {
    localStorage.removeItem(key);
  }

  /**
   * Vide complètement le localStorage.
   */
  clear(): void {
    localStorage.clear();
  }

  /**
   * Vérifie si une clé existe.
   */
  has(key: string): boolean {
    return localStorage.getItem(key) !== null;
  }
}
