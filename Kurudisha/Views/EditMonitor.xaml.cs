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
    public partial class EditMonitor : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _commentEntry;
        private DateTime _date;
        private Boolean _isNew;
        private Button _button;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");

        MonitorModel _monitor = new MonitorModel();

        public EditMonitor()
        {
            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<MonitorModel>().OrderBy(c => c.Comments).ToList();
            _listView.ItemSelected += _listView_ItemSelected; ;

            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _commentEntry = new Entry();
            _commentEntry.Placeholder = "Enter Comments";
            _commentEntry.Keyboard = Keyboard.Text;
            stackLayout.Children.Add(_commentEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            MonitorModel monitor = new MonitorModel()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Comments = _commentEntry.Text,
                Date = DateTime.Now,
                isNew = false
            };

            db.Update(monitor);
            await Navigation.PushAsync(new MonitoringPage());

        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _monitor = (MonitorModel)e.SelectedItem;
            _idEntry.Text = _monitor.Id.ToString();
            _commentEntry.Text = _monitor.Comments;
            _date = _monitor.Date;
            _isNew = _monitor.isNew;
        }
    }
}