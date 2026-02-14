import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Connection, CreateConnectionRequest } from '../models/connection.model';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  /**
   * Récupère toutes les connexions d'un projet.
   */
  getConnectionsByProject(projectId: number): Observable<Connection[]> {
    return this.http.get<Connection[]>(`${this.apiUrl}/projects/${projectId}/connections`);
  }

  /**
   * Crée une nouvelle connexion.
   */
  createConnection(projectId: number, request: CreateConnectionRequest): Observable<Connection> {
    return this.http.post<Connection>(
      `${this.apiUrl}/projects/${projectId}/connections`,
      request
    );
  }

  /**
   * Supprime une connexion.
   */
  deleteConnection(projectId: number, connectionId: number): Observable<void> {
    return this.http.delete<void>(
      `${this.apiUrl}/projects/${projectId}/connections/${connectionId}`
    );
  }
}
