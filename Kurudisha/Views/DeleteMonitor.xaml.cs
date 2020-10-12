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
    public partial class DeleteMonitor : ContentPage
    {
        private ListView _listView;
        private Button _button;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");

        MonitorModel _monitor = new MonitorModel();

        public DeleteMonitor()
        {
            StackLayout stackLayout = new StackLayout();

            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<MonitorModel>();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<MonitorModel>().OrderBy(c => c.Comments).ToList();
            _listView.ItemSelected += _listView_ItemSelected; ;

            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<MonitorModel>().Delete(c => c.Id == _monitor.Id);
            await Navigation.PushAsync(new MonitoringPage());
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _monitor = (MonitorModel)e.SelectedItem;
        }
    }
}