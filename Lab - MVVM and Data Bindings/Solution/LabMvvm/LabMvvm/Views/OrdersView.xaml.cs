using LabMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LabMvvm.Views
{
    public partial class OrdersView : ContentPage
    {
        public OrdersView()
        {
            InitializeComponent();
            var vm = new OrdersViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;

            Device.BeginInvokeOnMainThread(async () => await vm.LoadData());

            OrderListView.ItemSelected += (s, e) => OrderListView.SelectedItem = null;
        }
    }
}
