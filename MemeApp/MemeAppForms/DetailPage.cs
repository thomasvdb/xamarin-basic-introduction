using System;

using Xamarin.Forms;

namespace MemeAppForms
{
    public class DetailPage : ContentPage
    {
        public DetailPage(MemeModel model)
        {
            var image = new Image();
            image.Source = ImageSource.FromUri(new Uri(model.ImageUrl));

            Content = new StackLayout
            { 
                Children =
                {
                    image
                }
            };
        }
    }
}


