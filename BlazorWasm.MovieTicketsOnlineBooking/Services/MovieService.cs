using BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Services;

public class MovieService : IDbService
{
    public async Task<List<MovieDataModel>> GetMovieList()
    {
        return GetMovies();
    }

    private List<MovieDataModel> GetMovies()
    {
        return new List<MovieDataModel>
        {
            new() { MovieId = 1, MovieTitle = "The Nun", ReleaseDate = new DateTime(2023, 9, 26), Duration = "1:30", MoviePhoto = "the_nun.png" },
            new() { MovieId = 2, MovieTitle = "The Meg", ReleaseDate = new DateTime(2023, 9, 27), Duration = "2:00", MoviePhoto = "the_meg.png" },
            new() { MovieId = 3, MovieTitle = "Moana", ReleaseDate = new DateTime(2023, 9, 28), Duration = "1:30", MoviePhoto = "moana.png" },
            new() { MovieId = 4, MovieTitle = "Elemental", ReleaseDate = new DateTime(2023, 9, 29), Duration = "2:00", MoviePhoto = "elemental.png" }
        };
    }
}