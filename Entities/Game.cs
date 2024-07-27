namespace GameStore;

public class Game()
{
    public int Id { get; set; }
    public int GenreId { get; set; }
    public string? Name { get; set; }
    public Genre? Genre { get; set; } 

}
