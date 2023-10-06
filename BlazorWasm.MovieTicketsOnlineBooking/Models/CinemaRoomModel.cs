using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Models
{
    public class CinemaRoomModel
    {
        public CinemaViewModel cinema { get; set; }
        public List<CinemaRoomViewModel> roomList { get; set; }
    }
    public class CinemaRoomPaginationModel
    {
        public List<CinemaRoomModel> data { get; set; }
        public int totalPage { get; set; }
    }
}
