namespace BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;

public class BookingVoucherDetailDataModel
{
    public Guid BookingVoucherDetailId { get; set; }
    public Guid Booking_Voucher_Head_Id { get; set; }
    public string BuildingName { get; set; }
    public string MovieName { get; set; }
    public string RoomName { get; set; }    // RowName + SeatNo
    public string Seat { get; set; }
    public int SeatPrice { get; set; }
    public DateTime ShowDate { get; set; }
    public DateTime BookingDate { get; set; }
}