
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuxiliarDoProatec.MVVC.View
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            
        }

        private void StudentList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.SelectedItem = null;
        }
    }
}