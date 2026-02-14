using OpenCreatorStudio.Domain.Entities;
using OpenCreatorStudio.Domain.Enums;

namespace OpenCreatorStudio.Infrastructure.MySQL;

/// <summary>
/// Catalogue des définitions de procédures stockées par FrameType.
/// Source de vérité pour la génération SQL.
/// </summary>
public static class StoredProcedureCatalog
{
    private static readonly Dictionary<FrameType, StoredProcedureDefinition> _definitions = new()
    {
        [FrameType.PRQ] = new StoredProcedureDefinition
        {
            Name = "SP_Aut_PrintRequest",
            FrameType = FrameType.PRQ,
            Parameters = new List<StoredProcedureParameter>
            {
                // Paramètres IN (16)
                new() { Name = "P_Message", SqlType = "VARCHAR(200)", Direction = ParameterDirection.In },
                new() { Name = "P_Expediteur", SqlType = "VARCHAR(45)", Direction = ParameterDirection.In },
                new() { Name = "P_Destinataire", SqlType = "VARCHAR(45)", Direction = ParameterDirection.In },
                new() { Name = "P_Localisation", SqlType = "VARCHAR(45)", Direction = ParameterDirection.In },
                new() { Name = "P_TypeMessage", SqlType = "VARCHAR(45)", Direction = ParameterDirection.In },
                new() { Name = "P_NumeroSequence", SqlType = "VARCHAR(45)", Direction = ParameterDirection.In },
                new() { Name = "P_PIC", SqlType = "VARCHAR(4)", Direction = ParameterDirection.In },
                new() { Name = "P_HostPIC", SqlType = "VARCHAR(6)", Direction = ParameterDirection.In },
                new() { Name = "P_Cab", SqlType = "VARCHAR(80)", Direction = ParameterDirection.In },
                new() { Name = "P_CABTransport", SqlType = "VARCHAR(50)", Direction = ParameterDirection.In },
                new() { Name = "P_Poids", SqlType = "VARCHAR(6)", Direction = ParameterDirection.In },
                new() { Name = "P_Volume", SqlType = "VARCHAR(6)", Direction = ParameterDirection.In },
                new() { Name = "P_Longueur", SqlType = "VARCHAR(6)", Direction = ParameterDirection.In },
                new() { Name = "P_Largeur", SqlType = "VARCHAR(6)", Direction = ParameterDirection.In },
                new() { Name = "P_Hauteur", SqlType = "VARCHAR(6)", Direction = ParameterDirection.In },
                new() { Name = "P_DESTINATION", SqlType = "VARCHAR(45)", Direction = ParameterDirection.In },
                // Paramètre OUT (1)
                new() { Name = "P_ConfirmationImpression", SqlType = "VARCHAR(6)", Direction = ParameterDirection.Out },
                // Paramètres INOUT (4)
                new() { Name = "P_Retour", SqlType = "VARCHAR(45)", Direction = ParameterDirection.InOut },
                new() { Name = "P_EtiquetteTransportAImprimer", SqlType = "VARCHAR(45)", Direction = ParameterDirection.InOut },
                new() { Name = "P_PrixImprime", SqlType = "VARCHAR(45)", Direction = ParameterDirection.InOut },
                new() { Name = "P_BLAImprimer", SqlType = "VARCHAR(45)", Direction = ParameterDirection.InOut },
                // Paramètre OUT (1)
                new() { Name = "P_ZPL", SqlType = "LONGTEXT", Direction = ParameterDirection.Out }
            }
        },
        
        [FrameType.DRQ] = new StoredProcedureDefinition
        {
            Name = "SP_Aut_DestinationRequest",
            FrameType = FrameType.DRQ,
            Parameters = new List<StoredProcedureParameter>
            {
                // Paramètres IN (10)
                new() { Name = "P_Message", SqlType = "VARCHAR(400)", Direction = ParameterDirection.In },
                new() { Name = "P_Expediteur", SqlType = "VARCHAR(3)", Direction = ParameterDirection.In },
                new() { Name = "P_Destinataire", SqlType = "VARCHAR(3)", Direction = ParameterDirection.In },
                new() { Name = "P_Localisation", SqlType = "VARCHAR(8)", Direction = ParameterDirection.In },
                new() { Name = "P_TypeMessage", SqlType = "VARCHAR(3)", Direction = ParameterDirection.In },
                new() { Name = "P_NumeroSequence", SqlType = "VARCHAR(2)", Direction = ParameterDirection.In },
                new() { Name = "P_PIC", SqlType = "VARCHAR(4)", Direction = ParameterDirection.In },
                new() { Name = "P_HostPIC", SqlType = "VARCHAR(6)", Direction = ParameterDirection.In },
                new() { Name = "P_Cab", SqlType = "VARCHAR(80)", Direction = ParameterDirection.In },
                new() { Name = "P_CABTransport", SqlType = "VARCHAR(100)", Direction = ParameterDirection.In },
                // Paramètre INOUT (1)
                new() { Name = "P_Poids", SqlType = "VARCHAR(6)", Direction = ParameterDirection.InOut },
                // Paramètre OUT (1)
                new() { Name = "P_Destination", SqlType = "VARCHAR(8)", Direction = ParameterDirection.Out },
                // Paramètre INOUT (1)
                new() { Name = "P_Retour", SqlType = "VARCHAR(45)", Direction = ParameterDirection.InOut }
            }
        },
        
        // Autres FrameTypes avec définitions vides
        [FrameType.LBC] = new StoredProcedureDefinition { Name = "SP_Aut_LabelCheck", FrameType = FrameType.LBC },
        [FrameType.SRE] = new StoredProcedureDefinition { Name = "SP_Aut_SortReport", FrameType = FrameType.SRE },
        [FrameType.IRQ] = new StoredProcedureDefinition { Name = "SP_Aut_InformationRequest", FrameType = FrameType.IRQ },
        [FrameType.PANEL] = new StoredProcedureDefinition { Name = "", FrameType = FrameType.PANEL },
        [FrameType.BAL] = new StoredProcedureDefinition { Name = "", FrameType = FrameType.BAL },
        [FrameType.IMP] = new StoredProcedureDefinition { Name = "", FrameType = FrameType.IMP },
        [FrameType.TEXT] = new StoredProcedureDefinition { Name = "", FrameType = FrameType.TEXT },
        [FrameType.TAB] = new StoredProcedureDefinition { Name = "", FrameType = FrameType.TAB }
    };

    /// <summary>
    /// Récupère la définition d'une procédure stockée par FrameType.
    /// </summary>
    public static StoredProcedureDefinition GetByFrameType(FrameType frameType)
    {
        return _definitions.TryGetValue(frameType, out var definition)
            ? definition
            : throw new ArgumentException($"Aucune définition pour FrameType {frameType}");
    }
}
