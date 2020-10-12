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
    public partial class RegisterPage : ContentPage
    {

        private Entry _firstName;
        private Entry _lastName;
        private Entry _emailAddress;
        private Entry _idNumber;
        private Entry _phoneNumber;
        private Entry _businessAddress;
        private Entry _password;
        private Entry _confirmPassword;
        //private Entry _type;
        private Button _savebutton;
        public RegisterPage()
        {
            StackLayout stackLayout = new StackLayout();

            Label heading = new Label();
            heading.Text = "Register Page";
            heading.HorizontalTextAlignment = TextAlignment.Center;
            stackLayout.Children.Add(heading);

            _firstName = new Entry();
            _firstName.Keyboard = Keyboard.Text;
            _firstName.Placeholder = "First Name";
            stackLayout.Children.Add(_firstName);

            _lastName = new Entry();
            _lastName.Keyboard = Keyboard.Text;
            _lastName.Placeholder = "Last Name";
            stackLayout.Children.Add(_lastName);

            _emailAddress = new Entry();
            _emailAddress.Keyboard = Keyboard.Text;
            _emailAddress.Placeholder = "Email Address";
            stackLayout.Children.Add(_emailAddress);

            _idNumber = new Entry();
            _idNumber.Keyboard = Keyboard.Text;
            _idNumber.Placeholder = "Id Number";
            stackLayout.Children.Add(_idNumber);

            _phoneNumber = new Entry();
            _phoneNumber.Keyboard = Keyboard.Text;
            _phoneNumber.Placeholder = "Phone Number";
            stackLayout.Children.Add(_phoneNumber);

            _businessAddress = new Entry();
            _businessAddress.Keyboard = Keyboard.Text;
            _businessAddress.Placeholder = "Business Address";
            stackLayout.Children.Add(_businessAddress);

            _password = new Entry();
            _password.Keyboard = Keyboard.Text;
            _password.Placeholder = "Password";
            stackLayout.Children.Add(_password);

            _confirmPassword = new Entry();
            _confirmPassword.Keyboard = Keyboard.Text;
            _confirmPassword.Placeholder = "Confirm Password";
            stackLayout.Children.Add(_confirmPassword);

            _savebutton = new Button();
            _savebutton.Text = "Sign up";
            _savebutton.Clicked += Button_Clicked;
            stackLayout.Children.Add(_savebutton);

            Content = stackLayout;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}