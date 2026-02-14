using OpenCreatorStudio.Domain.Enums;

namespace OpenCreatorStudio.Domain.Entities;

/// <summary>
/// Définition d'une procédure stockée avec ses paramètres.
/// Utilisé pour générer le SQL et valider les scripts.
/// </summary>
public class StoredProcedureDefinition
{
    public required string Name { get; set; }
    
    public FrameType FrameType { get; set; }
    
    public IList<StoredProcedureParameter> Parameters { get; set; } = new List<StoredProcedureParameter>();
}

/// <summary>
/// Paramètre d'une procédure stockée.
/// </summary>
public class StoredProcedureParameter
{
    public required string Name { get; set; }
    
    public required string SqlType { get; set; }
    
    public ParameterDirection Direction { get; set; }
}
