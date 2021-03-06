﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace Xamarin_Android
{
    [Activity(Label = "Welcome", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var button = FindViewById<Button>(Resource.Id.LetsGo);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(CreateUserActivity));
        }
    }
}

