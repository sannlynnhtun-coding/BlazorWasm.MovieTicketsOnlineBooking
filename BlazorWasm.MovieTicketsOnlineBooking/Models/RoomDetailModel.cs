using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Models
{
    public class RoomDetailModel
    {
        public List<MovieScheduleViewModel>? showDate { get; set; }
        public List<RoomSeatViewModel>? roomSeatData { get; set; }
        public List<SeatPriceViewModel>? seatPriceData { get; set; }
        public List<string>? rowNameData { get; set; }
    }
}
