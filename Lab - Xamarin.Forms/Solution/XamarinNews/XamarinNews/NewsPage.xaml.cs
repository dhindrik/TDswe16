using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinNews.Core;

namespace XamarinNews
{
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();

            Initialize();
        }

        public async Task Initialize()
        {
            var data = await XamarinService.Get();

            News.ItemsSource = data;
        }
    }
}
