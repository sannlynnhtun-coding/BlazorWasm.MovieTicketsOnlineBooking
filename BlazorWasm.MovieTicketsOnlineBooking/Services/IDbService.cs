using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Services;

public interface IDbService
{
    Task<List<MovieViewModel>?> GetMovieList();
    Task<List<CinemaViewModel>?> GetCinemaList();
    Task<List<CinemaRoomViewModel>?> GetCinemaRoom();
    Task<List<MovieShowDateTimeViewModel>?> GetMovieShowDateTime();
    Task<List<CinemaRoomModel>?> GetCinemaAndRoom(int movieId);
    Task<RoomDetailModel> GetRoomDetail(int roomId);
    Task<MovieResponseModel?> GetMovieListByPagination(int pageNo, int pageSize);
    Task SetBookingList(RoomSeatViewModel model, DateTime date);
    Task<List<BookingModel>?> GetBookingList();
    Task<MovieSearchModel> SearchMovie(string title, int pageNo = 1,
        int pageSize = 3);
    Task<MovieViewModel> GetMovieByRoomId(int roomId);
    Task SetBookingVoucher();
    Task<List<BookingVoucherDetailViewModel>> GetBookingVoucherDetail();
    Task<List<BookingVoucherHeadDataModel>> GetBookingVoucherHead();
}