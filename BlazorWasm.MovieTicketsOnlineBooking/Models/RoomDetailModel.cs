using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Models
{
    public class RoomDetailModel
    {
        public List<MovieScheduleViewModel>? ShowDate { get; set; }
        public List<RoomSeatViewModel>? RoomSeatData { get; set; }
        public List<SeatPriceViewModel>? SeatPriceData { get; set; }
        public List<string>? RowNameData { get; set; }
    }
}
