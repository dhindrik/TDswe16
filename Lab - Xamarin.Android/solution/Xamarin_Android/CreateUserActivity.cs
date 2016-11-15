using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Xamarin_Android
{
    [Activity(Label = "Create user")]
    public class CreateUserActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateUser);

            var button = FindViewById<Button>(Resource.Id.Save);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var firstname = FindViewById<EditText>(Resource.Id.firstname);
            var lastname = FindViewById<EditText>(Resource.Id.lastname);

            var alert = new AlertDialog.Builder(this);
            alert.SetTitle("Hi " + firstname.Text + " " + lastname.Text + "!");
            alert.SetNeutralButton("OK", (s, args) =>
            {
                StartActivity(typeof(NewsActivity));
            });
            alert.Show();
        }
    }
}