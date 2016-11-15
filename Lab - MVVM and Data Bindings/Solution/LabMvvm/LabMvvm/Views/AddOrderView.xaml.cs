using LabMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LabMvvm.Views
{
    public partial class AddOrderView : ContentPage
    {
        public AddOrderView()
        {
            InitializeComponent();
            var vm = new AddOrderViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}
