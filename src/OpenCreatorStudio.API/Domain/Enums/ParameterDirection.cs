namespace OpenCreatorStudio.Domain.Enums;

/// <summary>
/// Direction d'un paramètre de procédure stockée.
/// </summary>
public enum ParameterDirection
{
    /// <summary>Paramètre d'entrée uniquement</summary>
    In,
    
    /// <summary>Paramètre de sortie uniquement</summary>
    Out,
    
    /// <summary>Paramètre d'entrée/sortie</summary>
    InOut
}
