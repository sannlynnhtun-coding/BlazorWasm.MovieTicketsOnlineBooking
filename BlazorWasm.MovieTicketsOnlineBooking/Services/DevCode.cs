using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;
using Newtonsoft.Json;

namespace BlazorWasm.MovieTicketsOnlineBooking.Services;

public static class DevCode
{
    public static List<MovieViewModel>? Change(this List<MovieDataModel>? dataModels)
    {
        if(dataModels is null || dataModels.Count == 0) return default;
        List<MovieViewModel> viewModels = dataModels.Select(dataModel => new MovieViewModel
        {
            MovieId = dataModel.MovieId,
            MovieTitle = dataModel.MovieTitle,
            ReleaseDate = dataModel.ReleaseDate,
            Duration = dataModel.Duration,
            MoviePhoto = dataModel.MoviePhoto
        }).ToList();
        return viewModels;
    }

    public static List<CinemaViewModel>? Change(this List<CinemaDataModel>? dataModels)
    {
        if (dataModels is null || dataModels.Count == 0) return default;
        List<CinemaViewModel> viewModels = dataModels.Select(dataModel => new CinemaViewModel
        {
            CinemaId = dataModel.CinemaId,
            CinemaName = dataModel.CinemaName,
            CinemaLocation = dataModel.CinemaLocation
        }).ToList();
        return viewModels;
    }

    public static List<CinemaRoomViewModel>? Change(this List<CinemaRoomDataModel>? dataModels)
    {
        if (dataModels is null || dataModels.Count == 0) return default;
        List<CinemaRoomViewModel> viewModels = dataModels.Select(dataModel => new CinemaRoomViewModel
        {
            RoomId = dataModel.RoomId,
            CinemaId = dataModel.CinemaId,
            RoomName = dataModel.RoomName,
            RoomNumber = dataModel.RoomNumber,
            SeatingCapacity = dataModel.SeatingCapacity
        }).ToList();
        return viewModels;
    }
    public static List<MovieShowDateTimeViewModel>? Change(this List<MovieShowDateTimeDataModel>? 
        dataModels)
    {
        if (dataModels is null || dataModels.Count == 0) return default;
        List<MovieShowDateTimeViewModel> viewModels = dataModels.Select(dataModel => 
        new MovieShowDateTimeViewModel
        {
            ShowDateId = dataModel.ShowDateId,
            CinemaId = dataModel.CinemaId,
            MovieId = dataModel.MovieId,
            ShowDateTime = dataModel.ShowDateTime,
            RoomId = dataModel.RoomId
        }).ToList();
        return viewModels;
    }

    public static List<BookingVoucherDetailViewModel>? Change(this List<BookingVoucherDetailDataModel>? dataModels)
    {
        if (dataModels is null || dataModels.Count is 0) return default;
        List<BookingVoucherDetailViewModel> viewModels = dataModels.Select(dm =>
            new BookingVoucherDetailViewModel
            {
                BookingVoucherDetailId = dm.BookingVoucherDetailId,
                BookingVoucherHeadId = dm.BookingVoucherDetailId,
                ShowDate = dm.ShowDate,
                BookingDate = dm.BookingDate,
                BuildingName = dm.BuildingName,
                RoomName = dm.RoomName,
                Seat = dm.Seat,
                MovieName = dm.MovieName,
                SeatPrice = dm.SeatPrice
            }).ToList();
        return viewModels;
    }

    public static int getTotalPages(this MovieResponseModel movieModel, int pageSize)
    {
        int totalPages = movieModel.RowCount / pageSize;
        if (movieModel.RowCount % pageSize > 0)
        {
            totalPages++;
        }
        return totalPages;
    }

    public static T? ToJsonObj<T>(this string jsonStr)
    {
        return JsonConvert.DeserializeObject<T>(jsonStr);
    }

    public static string ToJsonStr(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}