using BlazorWasm.MovieTicketsOnlineBooking.Models;

namespace BlazorWasm.MovieTicketsOnlineBooking.Services
{
    public class PageChangeStateContainer
    {
        private PageChangeEnum? pageChange;

        public PageChangeEnum CurrentPage
        {
            get => pageChange ?? PageChangeEnum.PageMovie;
            set
            {
                pageChange = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
