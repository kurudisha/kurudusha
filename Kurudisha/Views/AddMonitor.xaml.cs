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
    public partial class AddMonitor : ContentPage
    {
        private Entry _comment;
        private Button _savebutton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDB.db3");
        public AddMonitor()
        {
            StackLayout stackLayout = new StackLayout();

            _comment = new Entry();
            _comment.Keyboard = Keyboard.Text;
            _comment.Placeholder = "Enter Comments";
            stackLayout.Children.Add(_comment);

            _savebutton = new Button();
            _savebutton.Text = "Save";
            _savebutton.Clicked += _savebutton_Clicked;
            stackLayout.Children.Add(_savebutton);

            Content = stackLayout;

        }

        private async void _savebutton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<MonitorModel>();

            var maxPk = db.Table<MonitorModel>().OrderByDescending(c => c.Id).FirstOrDefault();

            MonitorModel monitor = new MonitorModel
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Comments = _comment.Text,
                Date = DateTime.Now,
                isNew = true
            };

            db.Insert(monitor);
            await DisplayAlert(null,"Comments Saved Successfully","OK");
            await Navigation.PushAsync(new MonitoringPage());
        }
    }
}