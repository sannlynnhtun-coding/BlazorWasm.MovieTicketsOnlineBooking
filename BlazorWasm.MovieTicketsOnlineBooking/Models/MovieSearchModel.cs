using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Models
{
    public class MovieSearchModel
    {
        public List<MovieViewModel> Movies { get; set; }
        public int TotalPage { get; set; }
    }
}
