using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Models
{
    public class CinemaRoomModel
    {
        public CinemaViewModel cinema { get; set; }
        public List<CinemaRoomViewModel> roomList { get; set; }
    }
}
