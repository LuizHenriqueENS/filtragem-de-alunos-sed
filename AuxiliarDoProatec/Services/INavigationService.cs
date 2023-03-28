using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuxiliarDoProatec.Services
{
    public interface INavigationService
    {

        void NavigateTo(Page page);

        void NavigateBack();
    }
}
