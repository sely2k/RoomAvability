namespace RoomAvability.ViewModels
{
    using Caliburn.Micro;
    using Tools.Dialogs;
    using Tools.Navigation;

    public class ViewModelBase : Screen
    {
        internal IPageNavigationService PageNavigationService;
        internal IUserNotificationService UserNotificationService;


        protected ViewModelBase(IPageNavigationService pageNavigationService)
        {
            PageNavigationService = pageNavigationService;
        }

        protected void NavigateTo<T>()
        {
            PageNavigationService.NavigateTo<T>();
        }
    }
}