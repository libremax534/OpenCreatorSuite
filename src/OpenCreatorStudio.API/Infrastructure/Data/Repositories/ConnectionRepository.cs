using Microsoft.EntityFrameworkCore;
using OpenCreatorStudio.Domain.Entities;

namespace OpenCreatorStudio.Infrastructure.Data.Repositories;

/// <summary>
/// Repository pour les opérations CRUD sur les connexions.
/// </summary>
public class ConnectionRepository
{
    private readonly ApplicationDbContext _context;

    public ConnectionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Connection>> GetByProjectIdAsync(int projectId)
    {
        return await _context.Connections
            .Where(c => c.ProjectId == projectId)
            .ToListAsync();
    }

    public async Task<Connection> CreateAsync(Connection connection)
    {
        _context.Connections.Add(connection);
        await _context.SaveChangesAsync();
        return connection;
    }

    public async Task<bool> DeleteAsync(int connectionId)
    {
        var connection = await _context.Connections.FindAsync(connectionId);
        if (connection == null)
            return false;

        _context.Connections.Remove(connection);
        await _context.SaveChangesAsync();
        return true;
    }
}
