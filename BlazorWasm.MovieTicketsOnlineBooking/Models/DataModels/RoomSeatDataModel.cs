namespace BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels
{
    public class RoomSeatDataModel
    {
        public int SeatId { get; set; }
        public int RomId { get; set; }
        public int SeatNo { get; set; }
        public string RowName { get; set; }
        public string SeatType { get; set; }
        public List<int> RowDetail { get; set; }
    }
}
