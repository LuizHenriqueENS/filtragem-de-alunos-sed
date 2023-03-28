using AuxiliarDoProatec.MVVC.View;
using AuxiliarDoProatec.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuxiliarDoProatec.MVVC.ViewModel
{
    public class StudentPageVM
    {

        private INavigationService NavigationService { get; set; }

        public ICommand BackToTheList { get; set; }

        public StudentPageVM()
        {
            NavigationService = DependencyService.Get<INavigationService>();

            BackToTheList = new Command(() => { NavigationService.NavigateBack(); });
        }
    }
}
