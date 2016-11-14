using LabMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LabMvvm.Views
{
    public partial class EditOrderView : ContentPage
    {
        public EditOrderView()
        {
            InitializeComponent();
            var vm = new EditOrderViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}
