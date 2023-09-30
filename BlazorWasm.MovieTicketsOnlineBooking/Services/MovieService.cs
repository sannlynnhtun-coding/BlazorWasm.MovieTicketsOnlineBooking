using BlazorWasm.MovieTicketsOnlineBooking.Models;
using BlazorWasm.MovieTicketsOnlineBooking.Models.DataModels;
using BlazorWasm.MovieTicketsOnlineBooking.Models.ViewModels;

namespace BlazorWasm.MovieTicketsOnlineBooking.Services;

public class MovieService : IDbService
{
    //public async Task<List<MovieDataModel>> GetMovieList()
    //{
    //    return GetMovies();
    //}

    //private List<MovieDataModel> GetMovies()
    //{
    //    return new List<MovieDataModel>
    //    {
    //        new() { MovieId = 1, MovieTitle = "The Nun", ReleaseDate = new DateTime(2023, 9, 26), Duration = "1:30", MoviePhoto = "the_nun.png" },
    //        new() { MovieId = 2, MovieTitle = "The Meg", ReleaseDate = new DateTime(2023, 9, 27), Duration = "2:00", MoviePhoto = "the_meg.png" },
    //        new() { MovieId = 3, MovieTitle = "Moana", ReleaseDate = new DateTime(2023, 9, 28), Duration = "1:30", MoviePhoto = "moana.png" },
    //        new() { MovieId = 4, MovieTitle = "Elemental", ReleaseDate = new DateTime(2023, 9, 29), Duration = "2:00", MoviePhoto = "elemental.png" }
    //    };
    //}

    
    // TODO: need to add pagination
    public async Task<List<MovieViewModel>?> GetMovieList()
    {
        var result = await GetDataList<MovieDataModel>(JsonData.Tbl_Movies);
        return result.Change();
    }

    // TODO: need to add pagination
    public async Task<List<CinemaViewModel>?> GetCinemaList()
    {
        var result = await GetDataList<CinemaDataModel>(JsonData.Tbl_Cinema);
        return result.Change();
    }

    // TODO: need to add pagination
    public async Task<List<CinemaRoomViewModel>?> GetCinemaRoom()
    {
        var result = await GetDataList<CinemaRoomDataModel>(JsonData.Tbl_CinemaRooms);
        return result.Change();
    }

    public async Task<List<MovieShowDateTimeViewModel>?> GetMovieShowDateTime()
    {
        var result = await GetDataList<MovieShowDateTimeDataModel>(JsonData.Tbl_MovieShowTime);
        return result.Change();
    }

    // TODO: need to add pagination
    public async Task<List<CinemaRoomModel>?> GetCinemaAndRoom(int movieId)
    {
        List<CinemaRoomModel> cinemaAndRoom = new();
        var result = await GetMovieShowDateTime();
        var cinemaLst = await GetCinemaList();
        var roomLst = await GetCinemaRoom();
        foreach (var item in result.Where(x => x.MovieId == movieId).ToList())
        {
            var cinema = cinemaLst.FirstOrDefault(x => x.CinemaId == item.CinemaId);
            var room = roomLst.Where(x => x.RoomId == item.RoomId).ToList();

            var cinemaIsAlreadyExit = cinemaAndRoom.FirstOrDefault(x => x.cinema.CinemaId == item.CinemaId);
            if (cinemaIsAlreadyExit is not null)
            {
                var additionalRoom = roomLst.FirstOrDefault(x => x.RoomId == item.RoomId);
                var index = cinemaAndRoom.FindIndex(x => x.cinema.CinemaId == item?.CinemaId);
                cinemaAndRoom[index].roomList.Add(additionalRoom);
            }

            cinemaAndRoom.Add(new CinemaRoomModel
            {
                cinema = cinema,
                roomList = room
            });
        }

        return cinemaAndRoom;
    }

    public async Task<List<MovieShowDateTimeViewModel>> GetMovieShowDate(int roomId)
    {
        var showDateLst = await GetMovieShowDateTime();
        var result = showDateLst?.Where(x => x.RoomId == roomId).ToList();
        if (result is null || result.Count == 0) return new List<MovieShowDateTimeViewModel>();
        return result;
    }

    public async Task<List<T>?> GetDataList<T>(string jsonStr)
    {
        var result = jsonStr.ToJsonObj<List<T>>();
        return await Task.FromResult(result);
    }
}

public class JsonData
{
    public static string Tbl_Cinema = @"[
 {
  ""CinemaId"": 1,
  ""CinemaName"": ""Cinema1"",
  ""CinemaLocation"": ""21.954510, 96.093292""
 },
 {
  ""CinemaId"": 2,
  ""CinemaName"": ""Cinema2"",
  ""CinemaLocation"": ""16.871311,96.199379""
 },
 {
  ""CinemaId"": 3,
  ""CinemaName"": ""Cinema3"",
  ""CinemaLocation"": ""20.876802, 95.856987""
 },
 {
  ""CinemaId"": 4,
  ""CinemaName"": ""Cinema4"",
  ""CinemaLocation"": ""20.144444, 92.896942""
 }
]";

    public static string Tbl_Movies = @"[
 {
  ""MovieId"": 1,
  ""MovieTitle"": ""The Nun"",
  ""ReleaseDate"": ""9\/26\/2023"",
  ""Duration"": ""01:30"",
""MoviePhoto"":""The Nun.jpg""
 },
 {
  ""MovieId"": 2,
  ""MovieTitle"": ""The Meg"",
  ""ReleaseDate"": ""9\/27\/2023"",
  ""Duration"": ""02:00"",
""MoviePhoto"":""The Meg.jpg""
 },
 {
  ""MovieId"": 3,
  ""MovieTitle"": ""Moana"",
  ""ReleaseDate"": ""9\/28\/2023"",
  ""Duration"": ""01:30"",
""MoviePhoto"":""Moana.jpg""
 },
 {
  ""MovieId"": 4,
  ""MovieTitle"": ""Elemental"",
  ""ReleaseDate"": ""9\/29\/2023"",
  ""Duration"": ""02:00"",
""MoviePhoto"":""Elemental.jpg""
 }
]";

    public static string Tbl_CinemaRooms = @"[
 {
  ""RoomId"": 1,
  ""CinemaId"": 1,
  ""RoomNumber"": 1,
  ""RoomName"": ""Room1"",
  ""SeatingCapacity"": 40
 },
 {
  ""RoomId"": 2,
  ""CinemaId"": 1,
  ""RoomNumber"": 2,
  ""RoomName"": ""Room2"",
  ""SeatingCapacity"": 30
 },
 {
  ""RoomId"": 3,
  ""CinemaId"": 1,
  ""RoomNumber"": 3,
  ""RoomName"": ""Room3"",
  ""SeatingCapacity"": 50
 },
 {
  ""RoomId"": 4,
  ""CinemaId"": 1,
  ""RoomNumber"": 4,
  ""RoomName"": ""Room4"",
  ""SeatingCapacity"": 40
 },
 {
  ""RoomId"": 5,
  ""CinemaId"": 2,
  ""RoomNumber"": 1,
  ""RoomName"": ""Room1"",
  ""SeatingCapacity"": 40
 },
 {
  ""RoomId"": 6,
  ""CinemaId"": 2,
  ""RoomNumber"": 2,
  ""RoomName"": ""Room2"",
  ""SeatingCapacity"": 30
 },
 {
  ""RoomId"": 7,
  ""CinemaId"": 2,
  ""RoomNumber"": 3,
  ""RoomName"": ""Room3"",
  ""SeatingCapacity"": 50
 },
 {
  ""RoomId"": 8,
  ""CinemaId"": 2,
  ""RoomNumber"": 4,
  ""RoomName"": ""Room4"",
  ""SeatingCapacity"": 40
 },
 {
  ""RoomId"": 9,
  ""CinemaId"": 3,
  ""RoomNumber"": 1,
  ""RoomName"": ""Room1"",
  ""SeatingCapacity"": 40
 },
 {
  ""RoomId"": 10,
  ""CinemaId"": 3,
  ""RoomNumber"": 2,
  ""RoomName"": ""Room2"",
  ""SeatingCapacity"": 30
 },
 {
  ""RoomId"": 11,
  ""CinemaId"": 3,
  ""RoomNumber"": 3,
  ""RoomName"": ""Room3"",
  ""SeatingCapacity"": 50
 },
 {
  ""RoomId"": 12,
  ""CinemaId"": 3,
  ""RoomNumber"": 4,
  ""RoomName"": ""Room4"",
  ""SeatingCapacity"": 40
 },
 {
  ""RoomId"": 13,
  ""CinemaId"": 4,
  ""RoomNumber"": 1,
  ""RoomName"": ""Room1"",
  ""SeatingCapacity"": 40
 },
 {
  ""RoomId"": 14,
  ""CinemaId"": 4,
  ""RoomNumber"": 2,
  ""RoomName"": ""Room2"",
  ""SeatingCapacity"": 30
 },
 {
  ""RoomId"": 15,
  ""CinemaId"": 4,
  ""RoomNumber"": 3,
  ""RoomName"": ""Room3"",
  ""SeatingCapacity"": 50
 },
 {
  ""RoomId"": 16,
  ""CinemaId"": 4,
  ""RoomNumber"": 4,
  ""RoomName"": ""Room4"",
  ""SeatingCapacity"": 40
 }
]";

    public static string Tbl_MovieShowTime = @"[
 {
  ""ShowDateId"": 1,
  ""CinemaId"": 1,
  ""RoomId"": 2,
  ""MovieId"": 1,
  ""ShowDateTime"": ""09-26-2023 9:30:00""
 },
 {
  ""ShowDateId"": 2,
  ""CinemaId"": 1,
  ""RoomId"": 3,
  ""MovieId"": 3,
  ""ShowDateTime"": ""09-27-2023 12:00:00""
 },
 {
  ""ShowDateId"": 3,
  ""CinemaId"": 2,
  ""RoomId"": 6,
  ""MovieId"": 4,
  ""ShowDateTime"": ""09-28-2023 15:00:00""
 },
 {
  ""ShowDateId"": 4,
  ""CinemaId"": 2,
  ""RoomId"": 7,
  ""MovieId"": 2,
  ""ShowDateTime"": ""09-26-2023 10:45:00""
 },
 {
  ""ShowDateId"": 5,
  ""CinemaId"": 3,
  ""RoomId"": 10,
  ""MovieId"": 2,
  ""ShowDateTime"": ""09-29-2023 16:45:00""
 },
 {
  ""ShowDateId"": 6,
  ""CinemaId"": 3,
  ""RoomId"": 11,
  ""MovieId"": 1,
  ""ShowDateTime"": ""09-26-2023 20:00:00""
 },
 {
  ""ShowDateId"": 7,
  ""CinemaId"": 4,
  ""RoomId"": 14,
  ""MovieId"": 3,
  ""ShowDateTime"": ""09-26-2023 15:45:00""
 },
 {
  ""ShowDateId"": 8,
  ""CinemaId"": 4,
  ""RoomId"": 15,
  ""MovieId"": 4,
  ""ShowDateTime"": ""09-29-2023 21:00:00""
 }
]";
}