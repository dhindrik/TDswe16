using LabMvvm.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LabMvvm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public string Greeting { get; set;  }

        public ICommand SayHi
        {
            get
            {
                return new Command(
                    () => Greeting = $"Hi {Name}");
            }
        }

        public ICommand NavigateToOrders
        {
            get
            {
                return new Command(
                    async () =>
                    {
                        await Navigation.PushAsync(new OrdersView());
                    });
            }
        }
    }
}
