import { Node } from './node.model';
import { Connection } from './connection.model';

/**
 * Modèle représentant un projet.
 */
export interface Project {
  id: number;
  name: string;
  description?: string;
  userId: number;
  createdAt: Date;
  updatedAt: Date;
  nodes: Node[];
  connections: Connection[];
}

/**
 * Requête de création d'un projet.
 */
export interface CreateProjectRequest {
  name: string;
  description?: string;
}
