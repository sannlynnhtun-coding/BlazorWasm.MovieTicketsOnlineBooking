namespace BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

public class BookingVoucherDetailViewModel
{
    public Guid BookingVoucherDetailId { get; set; }
    public Guid BookingVoucherHeadId { get; set; }
    public string BuildingName { get; set; }
    public string MovieName { get; set; }
    public string RoomName { get; set; }
    public string Seat { get; set; }
    public int SeatPrice { get; set; }
    public DateTime ShowDate { get; set; }
    public DateTime BookingDate { get; set; }
}