using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageRoomSeat
{
    [Parameter]
    public CinemaRoomViewModel? Data { get; set; }
    
    [Parameter]
    public EventCallback<MovieViewModel> ShowCinema { get; set; }

    private RoomDetailModel? _roomDetail = null;
    private SeatNoModel? Seat = new();
    private DateTime ShowDate { get; set; }
    private List<BookingModel>? _bookingData = new();
    private int seatId = 0;
    private string? selectedSingle;
    private string? selectedCouple;

    protected override void OnInitialized()
    {
        StateContainer.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        StateContainer.OnChange -= StateHasChanged;
    }
    
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
        seatId = model.SeatId;
        var data = model;
        if (ShowDate != default(DateTime))
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
        _bookingData = await _dbService.GetBookingList();
        StateContainer.CurrentPage = PageChangeEnum.PageBookingVoucher;
    }
    
    async Task BackToCinemaRoom()
    {
        StateContainer.CurrentPage = PageChangeEnum.PageCinema;
        var model = await _dbService.GetMovieByRoomId(Data.RoomId);
        await ShowCinema.InvokeAsync(model);
    }
}