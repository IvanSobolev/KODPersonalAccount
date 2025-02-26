using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces;

public interface IDirectionRepository
{
    Task<(IEnumerable<Direction> Directions, int TotalCount)> GetAllDirectionsAsync(int page, int pageSize);
    Task<Direction> GetDirectionByIdAsync(long id);
    Task<OperationResult> RenameAsync(long id, string newName);
    Task<OperationResult> RedescriptionAsync(long id, string newDescription);
    Task<OperationResult> DeleteAsync(long id);
}