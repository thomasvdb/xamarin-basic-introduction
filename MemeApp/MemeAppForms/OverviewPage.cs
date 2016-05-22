using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace MemeAppForms
{
    public class OverviewPage : ContentPage
    {
        List<MemeModel> memes;

        public OverviewPage()
        {

            memes = new List<MemeModel>()
            {
                new MemeModel()
                {
                    DisplayName = "F*** your photo",
                    ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/f4/2d/db/f42ddb019bbd7dd42f4a26cad33cf644.jpg"
                },
                new MemeModel()
                {
                    DisplayName = "Shoo dino, shoo!",
                    ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/43/b0/44/43b04440726ecb43765358d58d908f74.jpg"
                },
                new MemeModel()
                {
                    DisplayName = "Pew, pew, pew!",
                    ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/7f/0c/88/7f0c88b92a4606fa04d4e09991879b6d.jpg"
                },
                new MemeModel()
                {
                    DisplayName = "Parkour",
                    ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/60/be/82/60be82518f049723467ace754be468eb.jpg"
                },
                new MemeModel()
                {
                    DisplayName = "Evil plan",
                    ImageUrl = "https://s-media-cache-ak0.pinimg.com/564x/5e/c9/23/5ec92387bf4b8546fb9693f3c3310b7c.jpg"
                }
            };

            var listView = new ListView() { ItemsSource = memes.Select(m => m.DisplayName) };
            listView.ItemTapped += ListView_ItemSelected;

            Content = new StackLayout
            { 
                Children =
                {
                    listView
                }
            };
        }

        async void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new DetailPage(memes.First(m => m.DisplayName == e.Item.ToString())));
        }
    }
}


