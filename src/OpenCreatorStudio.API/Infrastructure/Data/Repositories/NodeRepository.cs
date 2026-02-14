using Microsoft.EntityFrameworkCore;
using OpenCreatorStudio.Domain.Entities;

namespace OpenCreatorStudio.Infrastructure.Data.Repositories;

/// <summary>
/// Repository pour les opérations CRUD sur les nœuds.
/// </summary>
public class NodeRepository
{
    private readonly ApplicationDbContext _context;

    public NodeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DecisionNode>> GetByProjectIdAsync(int projectId)
    {
        return await _context.Nodes
            .Where(n => n.ProjectId == projectId)
            .ToListAsync();
    }

    public async Task<DecisionNode?> GetByIdAsync(int nodeId)
    {
        return await _context.Nodes
            .FirstOrDefaultAsync(n => n.Id == nodeId);
    }

    public async Task<DecisionNode> CreateAsync(DecisionNode node)
    {
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();
        return node;
    }

    public async Task<DecisionNode> UpdateAsync(DecisionNode node)
    {
        node.UpdatedAt = DateTime.UtcNow;
        _context.Nodes.Update(node);
        await _context.SaveChangesAsync();
        return node;
    }

    public async Task<bool> DeleteAsync(int nodeId)
    {
        var node = await _context.Nodes.FindAsync(nodeId);
        if (node == null)
            return false;

        _context.Nodes.Remove(node);
        await _context.SaveChangesAsync();
        return true;
    }
}
