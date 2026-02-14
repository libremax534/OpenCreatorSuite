/**
 * Types de nœuds disponibles dans l'éditeur graphique.
 * Représente les différents types de trames WCS.
 */
export enum FrameType {
  /** PRQ - Print Request (Demande d'impression) */
  PRQ = 'PRQ',
  
  /** LBC - Label Check (Vérification d'étiquette) */
  LBC = 'LBC',
  
  /** DRQ - Destination Request (Demande de destination) */
  DRQ = 'DRQ',
  
  /** SRE - Sort Report (Rapport de tri) */
  SRE = 'SRE',
  
  /** IRQ - Information Request (Demande d'information) */
  IRQ = 'IRQ',
  
  /** PANEL - Panneau d'affichage */
  PANEL = 'PANEL',
  
  /** BAL - Balance (Pesée) */
  BAL = 'BAL',
  
  /** IMP - Imprimante */
  IMP = 'IMP',
  
  /** TEXT - Texte simple */
  TEXT = 'TEXT',
  
  /** TAB - Tableau */
  TAB = 'TAB'
}

/**
 * Configuration visuelle par type de nœud.
 */
export interface FrameTypeConfig {
  color: string;
  icon: string;
  label: string;
}

/**
 * Catalogue de configuration visuelle des types de nœuds.
 */
export const FRAME_TYPE_CONFIG: Record<FrameType, FrameTypeConfig> = {
  [FrameType.PRQ]: {
    color: '#6366f1', // Indigo
    icon: 'print',
    label: 'Print Request'
  },
  [FrameType.LBC]: {
    color: '#8b5cf6', // Violet
    icon: 'label',
    label: 'Label Check'
  },
  [FrameType.DRQ]: {
    color: '#06b6d4', // Cyan
    icon: 'place',
    label: 'Destination Request'
  },
  [FrameType.SRE]: {
    color: '#10b981', // Vert
    icon: 'assessment',
    label: 'Sort Report'
  },
  [FrameType.IRQ]: {
    color: '#f59e0b', // Orange
    icon: 'info',
    label: 'Information Request'
  },
  [FrameType.PANEL]: {
    color: '#3b82f6', // Bleu
    icon: 'dashboard',
    label: 'Panel'
  },
  [FrameType.BAL]: {
    color: '#ec4899', // Rose
    icon: 'balance',
    label: 'Balance'
  },
  [FrameType.IMP]: {
    color: '#14b8a6', // Teal
    icon: 'print',
    label: 'Printer'
  },
  [FrameType.TEXT]: {
    color: '#64748b', // Slate
    icon: 'text_fields',
    label: 'Text'
  },
  [FrameType.TAB]: {
    color: '#78716c', // Stone
    icon: 'table_chart',
    label: 'Table'
  }
};
