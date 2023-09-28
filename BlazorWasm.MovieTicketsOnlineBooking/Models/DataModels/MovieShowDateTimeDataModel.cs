namespace BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels
{
    public class MovieShowDateTimeDataModel
    {
        public int ShowDateId { get; set; }
        public int CinemaId { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
        public DateTime ShowDateTime { get; set; }
    }
}
