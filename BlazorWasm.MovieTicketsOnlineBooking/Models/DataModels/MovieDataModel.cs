namespace BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;

public class MovieDataModel
{
    public int MovieId { get; set; }
    public string MovieTitle { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Duration { get; set; }
    public string MoviePhoto { get; set; }
}