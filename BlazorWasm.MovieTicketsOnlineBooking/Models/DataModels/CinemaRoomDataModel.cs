namespace BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels
{
    public class CinemaRoomDataModel
    {
        public int RoomId { get; set; }
        public int CinemaId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public int SeatingCapacity { get; set; }
    }
}
