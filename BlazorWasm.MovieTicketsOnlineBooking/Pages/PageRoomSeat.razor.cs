using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageRoomSeat
{
    [Parameter]
    public CinemaRoomViewModel? Data { get; set; }

    private RoomDetailModel? _roomDetail = null;
    private SeatNoModel? Seat = new();
    private DateTime ShowDate { get; set; }
    private List<BookingModel>? _bookingData = new();

    protected override async Task OnParametersSetAsync()
    {
        if (Data is not null)
            _roomDetail = await _dbService.GetRoomDetail(Data.RoomId);
    }

    /*model = BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels.RoomSeatViewModel
    SeatId = 116
    RoomId = 2
    SeatNo = "28"
    RowName = "C"
    SeatType = "single"*/
    async Task ToBookingList(RoomSeatViewModel model)
    {
        var data = model;
        if (ShowDate == default(DateTime))
        {
            await _dbService.SetBookingList(data, ShowDate);
            _bookingData = await _dbService.GetBookingList();
        }
    }

    void SelectedShowDate(DateTime showDate)
    {
        ShowDate = showDate;
    }

    private async Task SetBookingVoucher()
    {
        await _dbService.SetBookingVoucher();
    }
}