/**
 * Modèle représentant une connexion entre deux nœuds.
 */
export interface Connection {
  id: number;
  projectId: number;
  sourceNodeId: number;
  targetNodeId: number;
  label?: string;
}

/**
 * Requête de création d'une connexion.
 */
export interface CreateConnectionRequest {
  sourceNodeId: number;
  targetNodeId: number;
  label?: string;
}
