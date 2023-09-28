﻿using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;
using BlazorWasm.MovieTicketsOnlineBooking.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.MovieTicketsOnlineBooking.Pages;

public partial class PageMoviesCard
{
    private List<MovieViewModel>? _movieLst { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var movieList = await _dbService.GetMovieList();
        //_movieLst = movieList.ToMovieViewModelLst();
        _movieLst = movieList;
    }
}