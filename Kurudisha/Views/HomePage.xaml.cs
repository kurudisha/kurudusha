using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kurudisha.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            StackLayout stackLayout = new StackLayout();
           
            Label welcome = new Label
            {
                Text= "Welcome to Kurudusha App",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            stackLayout.Children.Add(welcome);

            Content = stackLayout;


            //InitializeComponent();
        }
    }
}