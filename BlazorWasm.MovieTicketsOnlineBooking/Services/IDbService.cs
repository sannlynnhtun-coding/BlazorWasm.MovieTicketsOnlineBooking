using BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Services;

public interface IDbService
{
    Task<List<MovieViewModel>?> GetMovieList();
    Task<List<CinemaViewModel>?> GetCinemaList();
    Task<List<CinemaRoomViewModel>?> GetCinemaRoom();
    Task<List<MovieShowDateTimeViewModel>?> GetMovieShowDateTime();
}