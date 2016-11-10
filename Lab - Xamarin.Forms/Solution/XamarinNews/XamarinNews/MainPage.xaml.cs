﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinNews
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Children.Add(new NavigationPage(new HomePage()));
            Children.Add(new NavigationPage(new NewsPage()));
        }
    }
}
