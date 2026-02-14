namespace OpenCreatorStudio.Domain.Enums;

/// <summary>
/// Types de nœuds disponibles dans l'éditeur graphique.
/// Représente les différents types de trames WCS.
/// </summary>
public enum FrameType
{
    /// <summary>PRQ - Print Request (Demande d'impression)</summary>
    PRQ,
    
    /// <summary>LBC - Label Check (Vérification d'étiquette)</summary>
    LBC,
    
    /// <summary>DRQ - Destination Request (Demande de destination)</summary>
    DRQ,
    
    /// <summary>SRE - Sort Report (Rapport de tri)</summary>
    SRE,
    
    /// <summary>IRQ - Information Request (Demande d'information)</summary>
    IRQ,
    
    /// <summary>PANEL - Panneau d'affichage</summary>
    PANEL,
    
    /// <summary>BAL - Balance (Pesée)</summary>
    BAL,
    
    /// <summary>IMP - Imprimante</summary>
    IMP,
    
    /// <summary>TEXT - Texte simple</summary>
    TEXT,
    
    /// <summary>TAB - Tableau</summary>
    TAB
}
