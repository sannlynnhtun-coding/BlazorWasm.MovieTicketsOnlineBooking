using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;
using BlazorWasm.MovieTicketsOnlineBooking.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageMoviesCard
{
    private MovieResponseModel? _movieModel { get; set; }
    private List<MovieViewModel>? _movieLst { get; set; }
    private string? title { get; set; }


    private int _pageCount = 0;
    private int _pageSize = 3;

    [Parameter] public EventCallback<MovieViewModel?> ShowCinema { get; set; }

    /*protected override void OnInitializedAsync()
    {
        StateContainer.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        StateContainer.OnChange -= StateHasChanged;
    }*/
    
    protected override async Task OnInitializedAsync()
    {
        _movieModel = await _dbService.GetMovieListByPagination(1, 3);
        _movieLst = _movieModel.MovieList;
        _pageCount = _movieModel.getTotalPages(_pageSize);
    }

    private async Task MovieData(MovieViewModel model)
    {
        StateContainer.CurrentPage = PageChangeEnum.PageCinema;
        await ShowCinema.InvokeAsync(model);
    }
    async Task SearchMovie(int pageNo = 1)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            var searchMoveLst = await _dbService.SearchMovie(title, pageNo);
            _movieLst = searchMoveLst.Movies;
            _pageCount = searchMoveLst.TotalPage;
        }
    }
    async Task PageChanged(int pageNo = 1)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            _movieModel = await _dbService.GetMovieListByPagination(pageNo, 3);
            _movieLst = _movieModel.MovieList;
            _pageCount = _movieModel.getTotalPages(_pageSize);
        }
        else
        {
            await SearchMovie(pageNo);
        }
        
    }
}