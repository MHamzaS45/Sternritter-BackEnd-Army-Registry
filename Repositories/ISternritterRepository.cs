// Repository Interface Layer 
// Declares what methods exist
/// Describe data operations for API 
/// Defines methods for CRUD operations on Sternritter entities
/// Abstracts data access logic from controllers, promotes separation of concerns and testability
/// Implement with async EF core methods

using Wandenreich.Api.Models;

namespace Wandenreich.Api.Repositories;

public interface ISternritterRepository
{
    // Task represents an asynchronous operation
    Task<IEnumerable<Sternritter>> GetAllAsync();
    /// Return a single record (sternritter) by id OR null if not existing
    Task<Sternritter?> GetByIdAsync(int id);
    /// CRUD (without the R) operations
    Task<Sternritter> CreateAsync(Sternritter sternritter);
    Task UpdateAsync(Sternritter sternritter);
    Task DeleteAsync(Sternritter sternritter);
}