import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Project, CreateProjectRequest } from '../models/project.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  /**
   * Récupère tous les projets d'un utilisateur.
   */
  getProjectsByUser(userId: number): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.apiUrl}/projects`, {
      params: { userId: userId.toString() }
    });
  }

  /**
   * Récupère un projet complet (avec nœuds et connexions).
   */
  getProjectById(projectId: number): Observable<Project> {
    return this.http.get<Project>(`${this.apiUrl}/projects/${projectId}`);
  }

  /**
   * Crée un nouveau projet.
   */
  createProject(userId: number, request: CreateProjectRequest): Observable<Project> {
    return this.http.post<Project>(`${this.apiUrl}/projects`, request, {
      params: { userId: userId.toString() }
    });
  }

  /**
   * Met à jour un projet.
   */
  updateProject(projectId: number, request: CreateProjectRequest): Observable<Project> {
    return this.http.put<Project>(`${this.apiUrl}/projects/${projectId}`, request);
  }

  /**
   * Supprime un projet.
   */
  deleteProject(projectId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/projects/${projectId}`);
  }
}
