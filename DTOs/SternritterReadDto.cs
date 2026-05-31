// DTO (Data Transfer Object) for API responses (what enters and leaves the API)
// Used to control what data is sent to and from the API, preventing exposure of internal model details
// Any internal change (adding a column, renaming a property) in the model file breaks every client consuming your API.


namespace Wandenreich.Api.DTOs;

// mirror of Sternritter model (Models/Sternritter.cs)
/// only with properties we want to expose to the client
public class SternritterReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public string Epithet { get; set; } = string.Empty;
    public string Rank { get; set; } = string.Empty;
    public bool IsAlive { get; set; }
    public string Description { get; set; } = string.Empty;
}

