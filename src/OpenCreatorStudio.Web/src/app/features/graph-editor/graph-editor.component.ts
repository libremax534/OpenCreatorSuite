import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { ProjectService } from '../../core/services/project.service';
import { NodeService } from '../../core/services/node.service';
import { ConnectionService } from '../../core/services/connection.service';
import { Project } from '../../core/models/project.model';
import { Node } from '../../core/models/node.model';
import { Connection } from '../../core/models/connection.model';

@Component({
  selector: 'app-graph-editor',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './graph-editor.component.html',
  styleUrl: './graph-editor.component.scss'
})
export class GraphEditorComponent implements OnInit {
  private authService = inject(AuthService);
  private projectService = inject(ProjectService);
  private nodeService = inject(NodeService);
  private connectionService = inject(ConnectionService);
  private router = inject(Router);

  // Signals pour la gestion d'état
  currentProject = signal<Project | null>(null);
  nodes = signal<Node[]>([]);
  connections = signal<Connection[]>([]);
  selectedNode = signal<Node | null>(null);
  isLoading = signal(false);
  errorMessage = signal('');

  ngOnInit(): void {
    this.loadUserProjects();
  }

  /**
   * Charge les projets de l'utilisateur connecté.
   */
  private loadUserProjects(): void {
    const user = this.authService.getCurrentUser();
    if (!user) {
      this.router.navigate(['/login']);
      return;
    }

    this.isLoading.set(true);
    this.projectService.getProjectsByUser(user.id)
      .subscribe({
        next: (projects) => {
          if (projects.length > 0) {
            // Charger le premier projet par défaut
            this.loadProject(projects[0].id);
          } else {
            // Créer un projet par défaut
            this.createDefaultProject(user.id);
          }
        },
        error: (error) => {
          console.error('Erreur chargement projets:', error);
          this.errorMessage.set('Impossible de charger les projets');
          this.isLoading.set(false);
        }
      });
  }

  /**
   * Charge un projet avec ses nœuds et connexions.
   */
  private loadProject(projectId: number): void {
    this.projectService.getProjectById(projectId)
      .subscribe({
        next: (project) => {
          this.currentProject.set(project);
          this.nodes.set(project.nodes || []);
          this.connections.set(project.connections || []);
          this.isLoading.set(false);
        },
        error: (error) => {
          console.error('Erreur chargement projet:', error);
          this.errorMessage.set('Impossible de charger le projet');
          this.isLoading.set(false);
        }
      });
  }

  /**
   * Crée un projet par défaut.
   */
  private createDefaultProject(userId: number): void {
    this.projectService.createProject(userId, {
      name: 'Nouveau Projet',
      description: 'Projet créé automatiquement'
    }).subscribe({
      next: (project) => {
        this.currentProject.set(project);
        this.nodes.set([]);
        this.connections.set([]);
        this.isLoading.set(false);
      },
      error: (error) => {
        console.error('Erreur création projet:', error);
        this.errorMessage.set('Impossible de créer un projet');
        this.isLoading.set(false);
      }
    });
  }

  /**
   * Déconnexion de l'utilisateur.
   */
  logout(): void {
    this.authService.logout();
  }
}
