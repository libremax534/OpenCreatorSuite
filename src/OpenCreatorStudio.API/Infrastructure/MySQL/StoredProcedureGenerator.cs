using System.Text;
using OpenCreatorStudio.Domain.Entities;
using OpenCreatorStudio.Domain.Enums;

namespace OpenCreatorStudio.Infrastructure.MySQL;

/// <summary>
/// Générateur de scripts SQL pour les procédures stockées.
/// </summary>
public static class StoredProcedureGenerator
{
    /// <summary>
    /// Génère le script SQL complet d'une procédure stockée.
    /// </summary>
    public static string GenerateProcedureScript(DecisionNode node)
    {
        var definition = StoredProcedureCatalog.GetByFrameType(node.FrameType);
        var sb = new StringBuilder();

        // DROP IF EXISTS
        sb.AppendLine($"DROP PROCEDURE IF EXISTS {node.StoredProcedureName};");
        sb.AppendLine();

        // CREATE PROCEDURE
        sb.AppendLine($"CREATE PROCEDURE {node.StoredProcedureName} (");

        // Paramètres
        for (int i = 0; i < definition.Parameters.Count; i++)
        {
            var param = definition.Parameters[i];
            var direction = param.Direction switch
            {
                ParameterDirection.In => "IN",
                ParameterDirection.Out => "OUT",
                ParameterDirection.InOut => "INOUT",
                _ => "IN"
            };

            sb.Append($"    {direction} {param.Name} {param.SqlType}");
            
            if (i < definition.Parameters.Count - 1)
                sb.AppendLine(",");
            else
                sb.AppendLine();
        }

        sb.AppendLine(")");
        sb.AppendLine("BEGIN");
        sb.AppendLine();

        // Corps de la procédure (script utilisateur)
        if (!string.IsNullOrWhiteSpace(node.BodyScript))
        {
            sb.AppendLine("    " + node.BodyScript.Replace("\n", "\n    "));
        }
        else
        {
            sb.AppendLine("    -- Script SQL à implémenter");
        }

        sb.AppendLine();
        sb.AppendLine("END;");

        return sb.ToString();
    }

    /// <summary>
    /// Génère les scripts pour tous les nœuds d'un projet.
    /// </summary>
    public static string GenerateProjectScripts(List<DecisionNode> nodes)
    {
        var sb = new StringBuilder();
        sb.AppendLine("-- =============================================");
        sb.AppendLine("-- Scripts générés par OpenCreatorStudio");
        sb.AppendLine($"-- Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine("-- =============================================");
        sb.AppendLine();

        foreach (var node in nodes)
        {
            sb.AppendLine("-- " + new string('-', 60));
            sb.AppendLine($"-- Nœud: {node.Name} ({node.FrameType})");
            sb.AppendLine("-- " + new string('-', 60));
            sb.AppendLine(GenerateProcedureScript(node));
            sb.AppendLine();
        }

        return sb.ToString();
    }
}
