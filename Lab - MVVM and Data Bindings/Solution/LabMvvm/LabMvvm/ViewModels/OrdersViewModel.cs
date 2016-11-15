using LabMvvm.Core.Models;
using LabMvvm.Core.Repositories;
using LabMvvm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LabMvvm.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private OrderRepository _orderRepository;

        public OrdersViewModel()
        {
            _orderRepository = new Core.Repositories.OrderRepository();
        }

        public async Task LoadData()
        {
            if(Orders == null)
            {
                Orders = new ObservableCollection<Order>();
            }
            
            foreach (var order in await _orderRepository.GetOrdersAsync())
            {
                if(!Orders.Any(e=>e.Id == order.Id))
                {
                    Orders.Add(order);
                }
            }
        }

        public ObservableCollection<Order> Orders { get; set; }

        public ICommand AddOrder
        {
            get
            {
                return new Command(async () =>
                {
                    var view = new AddOrderView();
                    await Navigation.PushAsync(view);
                });
            }
        }

        public Order SelectedOrder
        {
            set
            {
                if(value!=null)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var view = new EditOrderView();
                        var vm = view.BindingContext as EditOrderViewModel;
                        await Navigation.PushAsync(view);
                        await vm.LoadData(value.Id);
                    });
                }
            }
        }

        public ICommand Refresh
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await LoadData();
                    IsRefreshing = false;
                });
            }
        }

        public bool IsRefreshing { get; set; }

    }
}
