using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Models;

public class MovieResponseModel
{
    public List<MovieViewModel> MovieList { get; set; }
    public int RowCount { get; set; }
}