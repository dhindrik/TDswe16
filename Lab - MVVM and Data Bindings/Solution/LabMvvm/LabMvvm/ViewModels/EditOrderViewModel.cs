using LabMvvm.Core.Models;
using LabMvvm.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMvvm.ViewModels
{
    public class EditOrderViewModel : ViewModelBase
    {
        public async Task LoadData(int orderId)
        {
            var repository = new OrderRepository();
            Order = await repository.GetOrderAsync(orderId);
        }

        public Order Order { get; set; }
    }
}
