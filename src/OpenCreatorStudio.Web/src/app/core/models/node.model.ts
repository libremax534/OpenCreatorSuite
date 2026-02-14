import { FrameType } from './frame-type.enum';

/**
 * Modèle représentant un nœud de décision.
 */
export interface Node {
  id: number;
  projectId: number;
  name: string;
  frameType: FrameType;
  storedProcedureName?: string;
  bodyScript?: string;
  positionX: number;
  positionY: number;
  width: number;
  height: number;
}

/**
 * Requête de création d'un nœud.
 */
export interface CreateNodeRequest {
  name: string;
  frameType: FrameType;
  positionX: number;
  positionY: number;
}
