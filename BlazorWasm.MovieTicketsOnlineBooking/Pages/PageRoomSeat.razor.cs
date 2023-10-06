using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;
using BlazorWasm.MovieTicketsOnlineBooking.Pages.Dialog;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageRoomSeat
{
    [Parameter] public CinemaRoomViewModel? Data { get; set; }
    [Parameter] public int MovideId { get; set; }

    [Parameter] public EventCallback<MovieViewModel> ShowCinema { get; set; }

    private List<BookingVoucherDetailViewModel> _voucherDetailLst { get; set; }

    private RoomDetailModel? _roomDetail = null;
    private SeatNoModel? Seat = new();
    private DateTime ShowDate { get; set; }
    private List<BookingModel>? _bookingData = new();
    private int seatId = 0;
    private string? selectedSingle;
    private string? selectedCouple;
    private string? singleSeat = "seat01.png";
    private string? coupleSeat = "seat02.png";

    protected override async Task OnParametersSetAsync()
    {
        if (Data is not null)
        {
            _roomDetail = await _dbService.GetRoomDetail(Data.RoomId, Data.CinemaId, MovideId);
            var parameters = new DialogParameters { { "_roomDetail", _roomDetail } };
            var dialog = await DialogService.ShowAsync<MovieShowTimeDialog>("", parameters);

            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var showDateTime = result.Data is DateTime dateTime ? dateTime : default;
                if (showDateTime != default)
                    ShowDate = showDateTime;
            }
        }

        var voucherDetailLst = await _dbService.GetBookingVoucherDetail();
        _voucherDetailLst = voucherDetailLst is not null ? voucherDetailLst : new();
    }

    private async Task ToBookingList(RoomSeatViewModel model)
    {
        var result = _bookingData
            .FirstOrDefault(v => v.SeatId == model.SeatId);
        if (result is not null) return;

        seatId = model.SeatId;
        var data = model;
        if (ShowDate != default(DateTime))
        {
            await _dbService.SetBookingList(data, ShowDate);
            _bookingData = await _dbService.GetBookingList();
        }
    }

    private void SelectedShowDate(DateTime showDate)
    {
        ShowDate = showDate;
    }

    private async Task SetBookingVoucher()
    {
        await _dbService.SetBookingVoucher();
        _bookingData = await _dbService.GetBookingList();
        StateContainer.CurrentPage = PageChangeEnum.PageBookingVoucher;
    }

    private async Task BackToCinemaRoom()
    {
        StateContainer.CurrentPage = PageChangeEnum.PageCinema;
        var model = await _dbService.GetMovieByRoomId(Data.RoomId);
        await ShowCinema.InvokeAsync(model);
    }

    private async Task DeleteBookingSeat(int seatId)
    {
        var dialog = await DialogService.ShowAsync<DeleteBookingSeat>();
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            if (seatId == default) return;
            await _dbService.DeleteBookingSeat(seatId);
            _bookingData = await _dbService.GetBookingList();
        }
    }
}