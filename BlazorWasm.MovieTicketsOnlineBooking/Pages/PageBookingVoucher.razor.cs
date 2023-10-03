using BlazorWasm.MovieTicketsOnlineBooking.Models;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageBookingVoucher
{
    private List<BookingModel>? _bookingModels { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _bookingModels = await _dbService.GetBookingList();
    }
}