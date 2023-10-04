namespace BlazorWasm.MovieTicketsOnlineBooking.Models
{
    public class BookingModel
    {
        public Guid BookingId { get; set; }
        public int RoomId { get; set; }
        public int SeatId { get; set; }
        public string SeatNo { get; set; }
        public string RowName { get; set; }
        public string SeatType { get; set; }
        public int SeatPrice { get; set; }
        public DateTime ShowDate { get; set; }
    }
}
