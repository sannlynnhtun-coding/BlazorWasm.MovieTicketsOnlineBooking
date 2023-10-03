using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageBookingVoucher : IDisposable
{
    private List<BookingVoucherDetailViewModel>? _voucherDetailLst { get; set; }

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
        var voucherHead = voucherHeadLst.MaxBy(x => x.BookingDate);
        Console.WriteLine(voucherHead.BookingVoucherHeadId);

        foreach (var item in voucherDetailLst)
        {
            Console.WriteLine(
                $"current booking voucher head id => ${item.BookingVoucherHeadId} and voucher head id is ${voucherHead.BookingVoucherHeadId}");
            Console.WriteLine(item.BookingVoucherHeadId == voucherHead.BookingVoucherHeadId);
            Console.WriteLine();
        }

        _voucherDetailLst = voucherDetailLst
            .Where(v => v.BookingVoucherHeadId == voucherHead.BookingVoucherHeadId)
            .ToList();

        foreach (var item in _voucherDetailLst)
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