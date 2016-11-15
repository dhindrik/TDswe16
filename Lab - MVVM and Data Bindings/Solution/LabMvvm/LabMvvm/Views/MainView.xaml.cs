using LabMvvm.ViewModels;
using Xamarin.Forms;

namespace LabMvvm.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}
