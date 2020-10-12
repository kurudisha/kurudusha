using Kurudisha.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kurudisha.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonitoringPage : ContentPage
    {
        public int count = 0;
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");

        public MonitoringPage()
        {
            var db = new SQLiteConnection(_dbPath);
            _listView = new ListView();
            _listView.ItemsSource = db.Table<MonitorModel>().OrderBy(c => c.Comments).ToList();

            count = db.Table<MonitorModel>().Count();

            _listView.IsEnabled = false;

            StackLayout stackLayout = new StackLayout();

            stackLayout.Children.Add(_listView);

            Button button = new Button();
            button.Text = "Add";
            button.Clicked += AddButton_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Edit";
            button.Clicked += EditButton_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete";
            button.Clicked += DeleteButton_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            count = db.Table<MonitorModel>().Count();
            if (count > 0)
            {
                await Navigation.PushAsync(new EditMonitor());
            }
            else
            {
                await DisplayAlert(null, "Nothing to edit", "Ok");
            }

        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            count = db.Table<MonitorModel>().Count();
            if (count > 0)
            {
                await Navigation.PushAsync(new DeleteMonitor());
            }
            else
            {
                await DisplayAlert(null, "Nothing to Delete", "Ok");
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMonitor());
        }
    }
}