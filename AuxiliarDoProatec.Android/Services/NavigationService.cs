using AuxiliarDoProatec.Services.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(NavigationService))]
namespace AuxiliarDoProatec.Services.Droid
{
    public class NavigationService : INavigationService
    {
        public async void NavigateBack()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public async void NavigateTo(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }
    }
}