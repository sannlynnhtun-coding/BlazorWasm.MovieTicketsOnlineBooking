using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Models
{
    public class CinemaRoomModel
    {
        public CinemaViewModel Cinema { get; set; }
        public List<CinemaRoomViewModel> RoomList { get; set; }
    }
    public class CinemaRoomPaginationModel
    {
        public List<CinemaRoomModel> CinemaAndRoomData { get; set; }
        public int TotalPage { get; set; }
    }
}
