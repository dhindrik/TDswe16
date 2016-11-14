using LabMvvm.Core.Repositories;
using System.Windows.Input;
using Xamarin.Forms;

namespace LabMvvm.ViewModels
{
    public class AddOrderViewModel : ViewModelBase
    {
        private OrderRepository _orderRepository;

        public string Customer { get; set; }
        public string OrderText { get; set;  }

        public AddOrderViewModel()
        {
            _orderRepository = new Core.Repositories.OrderRepository();
        }

        public ICommand CreateOrder
        {
            get
            {
                return new Command(async () =>
                {
                    await _orderRepository.Create(Customer, OrderText);
                    await Navigation.PopAsync();
                });
            }
        }
    }
}
