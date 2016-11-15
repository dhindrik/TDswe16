using PropertyChanged;
using System.ComponentModel;
using Xamarin.Forms;

namespace LabMvvm.ViewModels
{
    [ImplementPropertyChanged]
    public abstract class ViewModelBase 
    {
        public INavigation Navigation { get; set; }
    }
}
