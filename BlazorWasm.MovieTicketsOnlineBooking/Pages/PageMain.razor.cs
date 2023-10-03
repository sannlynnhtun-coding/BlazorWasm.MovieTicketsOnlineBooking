using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageMain
{
    private PageChangeEnum _currentPage = PageChangeEnum.PageMovie;
    private List<CinemaRoomModel>? _data = null;
    private CinemaRoomViewModel? _roomData = null;

    protected override void OnInitialized()
    {
        StateContainer.OnChange += StateHasChanged;
    }

    async Task ShowCinemaClick(MovieViewModel model)
    {
        _data = await _dbService.GetCinemaAndRoom(model.MovieId);
        _currentPage = StateContainer.CurrentPage; 
    }

    private void ShowRoomSeatClick(CinemaRoomViewModel model)
    {
        _roomData = model;
        _currentPage = StateContainer.CurrentPage;
    }
    private void MainPageClick()
    {
        _currentPage = StateContainer.CurrentPage;
    }

    public void Dispose()
    {
        StateContainer.OnChange -= StateHasChanged;
    }
}