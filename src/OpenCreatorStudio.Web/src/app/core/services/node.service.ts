import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Node, CreateNodeRequest } from '../models/node.model';

@Injectable({
  providedIn: 'root'
})
export class NodeService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  /**
   * Récupère tous les nœuds d'un projet.
   */
  getNodesByProject(projectId: number): Observable<Node[]> {
    return this.http.get<Node[]>(`${this.apiUrl}/projects/${projectId}/nodes`);
  }

  /**
   * Récupère un nœud par son ID.
   */
  getNodeById(projectId: number, nodeId: number): Observable<Node> {
    return this.http.get<Node>(`${this.apiUrl}/projects/${projectId}/nodes/${nodeId}`);
  }

  /**
   * Crée un nouveau nœud.
   */
  createNode(projectId: number, request: CreateNodeRequest): Observable<Node> {
    return this.http.post<Node>(`${this.apiUrl}/projects/${projectId}/nodes`, request);
  }

  /**
   * Met à jour un nœud existant.
   */
  updateNode(projectId: number, nodeId: number, node: Node): Observable<Node> {
    return this.http.put<Node>(`${this.apiUrl}/projects/${projectId}/nodes/${nodeId}`, node);
  }

  /**
   * Supprime un nœud.
   */
  deleteNode(projectId: number, nodeId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/projects/${projectId}/nodes/${nodeId}`);
  }

  /**
   * Récupère le script SQL généré d'un nœud.
   */
  getNodeScript(projectId: number, nodeId: number): Observable<{ script: string }> {
    return this.http.get<{ script: string }>(
      `${this.apiUrl}/projects/${projectId}/nodes/${nodeId}/script`
    );
  }
}
