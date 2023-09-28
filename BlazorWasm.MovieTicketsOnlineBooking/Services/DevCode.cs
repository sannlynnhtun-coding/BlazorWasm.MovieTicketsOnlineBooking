using BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Services;

public static class DevCode
{
    public static List<MovieViewModel> ToMovieViewModelLst(this List<MovieDataModel> dataModels)
    {
        List<MovieViewModel> viewModels = dataModels.Select(dataModel => new MovieViewModel
        {
            MovieId = dataModel.MovieId,
            MovieTitle = dataModel.MovieTitle,
            ReleaseDate = dataModel.ReleaseDate,
            Duration = dataModel.Duration,
            MoviePhoto = dataModel.MoviePhoto
        }).ToList();
        return viewModels;
    }
}