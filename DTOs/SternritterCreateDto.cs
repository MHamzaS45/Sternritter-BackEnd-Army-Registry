using System.ComponentModel.DataAnnotations;

namespace Wandenreich.Api.DTOs;

// Reject missing or invalid data from the client before it reaches the controller
//  [ApiController] automatically validates incoming data against the rules defined in the DTO class
// If validation fails, a 400 response is sent

/// Mirror of Sternritter model attributes (Models/Sternritter.cs) 
///  properties from WandenreichDbContext Fluent API (Data/WandenreichDbContext.cs)
public class SternritterCreateDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Designation { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Epithet { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Rank { get; set; } = "Sternritter";

    [Required]
    public bool IsAlive { get; set; }

    [Required]
    [StringLength(250)]
    public string Description { get; set; } = string.Empty;
}