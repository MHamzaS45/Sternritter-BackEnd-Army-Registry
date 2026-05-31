// Define Domain Models and Database Context for Sternritter API
/// Entity Model - Map directly to a database table

namespace Wandenreich.Api.Models;

public class Sternritter 
{ 
    // PRIMARY KEY - AUTOINCREMENTED BY DATABASE
    public int Id { get; set; }

    // Sternritter NAME (ex: "Jugram Haschwalth" )
    // string properties default to string.Empty as to avoid null reference issues throughout the API
    
    public string Name { get; set; } = string.Empty; 

    // Schrift Letter (ex: "B")
    public string Letter { get; set; } = string.Empty;

    // Schrift Name (ex: "The Balance")
    public string Schrift { get; set; } = string.Empty;

    // Position 
    public string Position { get; set; } = "Sternritter";
   

    // Sternritter Image Source (ex: "Images/jugram.jpg")
    public string Image { get; set; } = string.Empty;

    // Status of Living (ex: "Deceased - Killed by Yhwach's Auswahlen")
    /// true for alive, false for deceased
    public bool Status { get; set; } = true; 
    
    // Ability Description - brief summary of their abilities (ex: "Redirect fortune and misfortune to themselves or others")
    public string Ability { get; set; } = string.Empty;


}

public class RoyalGuard : Sternritter
{
    // Royal Guard Position (ex: "Royal Guard") 
    public new string Position { get; set; } = "Royal Guard";
}