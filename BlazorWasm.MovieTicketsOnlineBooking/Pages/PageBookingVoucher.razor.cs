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

        _voucherDetailLst = voucherDetailLst
            .Where(v => v.BookingVoucherHeadId == voucherHead.BookingVoucherHeadId)
            .ToList();
    }
}