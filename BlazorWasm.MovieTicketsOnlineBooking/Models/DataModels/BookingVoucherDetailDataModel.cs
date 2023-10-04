namespace BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;

public class BookingVoucherDetailDataModel
{
    public Guid BookingVoucherDetailId { get; set; }
    public Guid BookingVoucherHeadId { get; set; }
    public string BuildingName { get; set; }
    public string MovieName { get; set; }
    public string RoomName { get; set; }
    public int SeatId { get; set; }
    public string Seat { get; set; }    // RowName + SeatNo
    public int SeatPrice { get; set; }
    public DateTime ShowDate { get; set; }
    public DateTime BookingDate { get; set; }
}