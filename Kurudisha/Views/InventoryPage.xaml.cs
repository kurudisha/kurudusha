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
    public partial class Stock_Management_Page : ContentPage
    {
        private Button _addStock;
        private Button _orderStock;
        public Stock_Management_Page()
        {
            StackLayout stackLayout = new StackLayout();

            Label heading = new Label();
            heading.Text = "Inventory Management";
            heading.HorizontalTextAlignment = TextAlignment.Center;
            stackLayout.Children.Add(heading);

            
            _addStock = new Button();
            _addStock.Text = "Add Stock";
            _addStock.Clicked += Add_Stock_Clicked;
            stackLayout.Children.Add(_addStock);

            _orderStock = new Button();
            _orderStock.Text = "Order Stock";
            _orderStock.Clicked += Order_Stock_Clicked;
            stackLayout.Children.Add(_orderStock);

            Content = stackLayout;
        }

        private void Add_Stock_Clicked(object sender, EventArgs e)
        {

        }

        private void Order_Stock_Clicked(object sender, EventArgs e)
        {

        }
    }
}