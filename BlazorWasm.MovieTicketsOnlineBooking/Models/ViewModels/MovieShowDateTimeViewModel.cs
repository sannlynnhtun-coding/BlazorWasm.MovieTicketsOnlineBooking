namespace BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels
{
    public class MovieShowDateTimeViewModel
    {
        public int ShowDateId { get; set; }
        public int CinemaId { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
        public DateTime ShowDateTime { get; set; }
    }
}
