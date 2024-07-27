namespace GameStore;

public static class EndPoints
{

    private static readonly List<GameDTO> gameDTOs = [

        new GameDTO(1,"Mario","Playing",20.00M, new DateOnly(2024, 07, 24)),
        new GameDTO(2, "Mario1", "Playing1", 20.00M, new DateOnly(2024, 08, 24)),
        new GameDTO(3,
                        "Mario2",
                        "Playing2",
                        20.00M,
                        new DateOnly(2024, 9, 1)),
        new GameDTO(4, "Mario4", "Playing4", 50.00M, new DateOnly(2024, 09, 18))

    ];
    public static RouteGroupBuilder MapGetgamesEndPoint(this WebApplication app)
    {           
           
           var group = app.MapGroup("games").WithParameterValidation();
           
            //GET games
            group.MapGet("/", ()=>gameDTOs);

            //GET games/{id}

            group.MapGet("/{id}", (int id) =>
            {
             GameDTO? game = gameDTOs.Find(gameDTOs => gameDTOs.id == id);

              return game is null ? Results.NotFound() : Results.Ok(game);
            });

            //GET games/{genre}
            group.MapGet("/genre/{genre}", (string genre) =>
            {
              gameDTOs.Find(gameDTOs => gameDTOs.genre == genre);

            }); 

            //POST game
            group.MapPost("/", (CreateGameDTO game) => 
            {

                GameDTO dt = new (gameDTOs.Count + 1, game.name, game.Genre, game.price, game.ReleaseDate) ;
                gameDTOs.Add(dt);

                Results.CreatedAtRoute("/", new {id = dt.id}, game);   
            

            });

            group.MapPut("/{id}",  (int id, UpdateGameDTO updategame) =>
            {
            var index = gameDTOs.FindIndex( game => game.id == id);

            if (index > 0)
            {
                GameDTO ud = new GameDTO( updategame.id, updategame.name, updategame.genre, updategame.price, updategame.ReleaseDate);
                gameDTOs.Add(ud);
                Results.CreatedAtRoute("/", new {id = ud.id}, updategame);
            }
            else{
                Results.BadRequest("Not a valid game");
            }

            });
                    
        return group;
    
    }

}
