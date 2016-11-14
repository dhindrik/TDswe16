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
using Java.Lang;

namespace Xamarin_Android
{
    public class NewsAdapter : BaseAdapter
    {
        private Activity _activity;
        private List<Tuple<string, string>> _items;

        public NewsAdapter(Activity activity)
        {
            _activity = activity;

            _items = new List<Tuple<string, string>>();

            _items.Add(new Tuple<string, string>("Microsoft k�per Xamarin", "Nu �r det klart att Microsoft k�per det San Francisco baserade f�retaget Xamarin"));
            _items.Add(new Tuple<string, string>("Xamarin = native", "Xamarin �r native"));

            _items.Add(new Tuple<string, string>("TechDays", "Microsoft TechDays �r den 15-17 november"));
            _items.Add(new Tuple<string, string>("Xamarin �r gratis", "Xamarin �r nu gratis f�r alla"));
        }

        public override int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = _activity.LayoutInflater.Inflate(Resource.Layout.NewsItem, null);

            var header = view.FindViewById<TextView>(Resource.Id.header);
            var text = view.FindViewById<TextView>(Resource.Id.text);

            var item = _items[position];

            header.Text = item.Item1;
            text.Text = item.Item2;

            return view;

        }
    }
}