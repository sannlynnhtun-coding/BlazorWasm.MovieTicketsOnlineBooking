using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageBookingVoucher : IDisposable
{
    private List<BookingVoucherDetailViewModel>? _voucherDetail { get; set; }

    protected override void OnInitialized()
    {
        StateContainer.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        StateContainer.OnChange -= StateHasChanged;
    }
    
    protected override async Task OnInitializedAsync()
    {
        var voucherDetailLst = await _dbService.GetBookingVoucherDetail();
        var voucherHeadLst = await _dbService.GetBookingVoucherHead();
        var voucherHead = voucherHeadLst
            .OrderByDescending(v => v.BookingVoucherHeadId)
            .FirstOrDefault();

        _voucherDetail = voucherDetailLst
            .Where(v => v.BookingVoucherHeadId == voucherHead.BookingVoucherHeadId)
            .ToList();

        foreach (var item in _voucherDetail)
        {
            Console.WriteLine($"BookingVoucherDetailId: {item.BookingVoucherDetailId}");
            Console.WriteLine($"BookingVoucherHeadId: {item.BookingVoucherHeadId}");
            Console.WriteLine($"BuildingName: {item.BuildingName}");
            Console.WriteLine($"MovieName: {item.MovieName}");
            Console.WriteLine($"RoomName: {item.RoomName}");
            Console.WriteLine($"Seat: {item.Seat}");
            Console.WriteLine($"SeatPrice: {item.SeatPrice}");
            Console.WriteLine($"ShowDate: {item.ShowDate}");
            Console.WriteLine($"BookingDate: {item.BookingDate}");
            Console.WriteLine();
        }
    }
}