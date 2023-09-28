using BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Services;

public interface IDbService
{
    Task<List<MovieDataModel>> GetMovieList();
}