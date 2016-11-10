using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinNews
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            Login.Clicked += Login_Clicked;
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Email.Text) && string.IsNullOrWhiteSpace(Password.Text))
            {
                Navigation.PushAsync(new WelcomePage());
            }
            else
            {
                DisplayAlert("Could not login", "You have enter a invalid email address or an invalid password!", "OK");
            }
        }
    }
}
