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
    public partial class LoginPage : ContentPage
    {
        private Entry _username;
        private Entry _password;
        private Button _login;
        private Button _register;
        public LoginPage()
        {

            StackLayout stackLayout = new StackLayout();

            Label heading = new Label();
            heading.Text = "Login Page";
            heading.HorizontalTextAlignment = TextAlignment.Center;
            stackLayout.Children.Add(heading);

            _username = new Entry();
            _username.Keyboard = Keyboard.Text;
            _username.Placeholder = "username";
            stackLayout.Children.Add(_username);

            _password = new Entry();
            _password.Keyboard = Keyboard.Text;
            _password.Placeholder = "password";
            stackLayout.Children.Add(_password);

            _login = new Button();
            _login.Text = "Sign In";
            _login.Clicked += Button_Clicked;
            stackLayout.Children.Add(_login);

            _register = new Button();
            _register.Text = "Register";
            _register.Clicked += Button_Clicked;
            stackLayout.Children.Add(_register);

            Content = stackLayout;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Login", "Hello", "Hello world");

        }
    }
}