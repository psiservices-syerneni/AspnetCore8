using System.ComponentModel.DataAnnotations;

namespace GameStore;
public record class GameDTO (int id, string name, string genre, decimal price, DateOnly releaseDate);
public record class CreateGameDTO(
     int id,
      [Required] [StringLength (50)]                      
      string name,
      [Required] [StringLength (50)]
      string Genre,
      [Range(1, 100)]
      decimal price,
      DateOnly ReleaseDate);

public record class UpdateGameDTO(
    int id, 
    [Required]
    string name, 
    [Required]
    string genre, 
    [Range (1, 100)]
    decimal price, 
    DateOnly ReleaseDate);

