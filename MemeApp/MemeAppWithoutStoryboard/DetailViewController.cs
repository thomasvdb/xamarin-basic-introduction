using System;
using UIKit;
using FFImageLoading;
using Foundation;

namespace MemeAppWithoutStoryboard
{
    public class DetailViewController : UIViewController
    {
        private MemeModel _model;

        public DetailViewController(MemeModel model)
        {
            _model = model;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
    
            var imageView = new UIImageView();
            imageView.Image = FromUrl(_model.ImageUrl);
            imageView.TranslatesAutoresizingMaskIntoConstraints = false;
//
  
            View.BackgroundColor = UIColor.White;
            View.Add(imageView);
            View.AddConstraints(new[]
                {
                    NSLayoutConstraint.Create(imageView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1f, 20f),
                    NSLayoutConstraint.Create(imageView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1f, 0f),
                    NSLayoutConstraint.Create(imageView, NSLayoutAttribute.Width, NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1f, 0f),
                    NSLayoutConstraint.Create(imageView, NSLayoutAttribute.Height, NSLayoutRelation.Equal, View, NSLayoutAttribute.Height, 1f, 0f)
                });
        }

        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}

