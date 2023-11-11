using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaryDinerCalculator
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Password;
        public event EventHandler LoginSuccessful;
        public LoginUserControl()
        {
            InitializeComponent();
            this.btnSignIn.Click += OnSignIn;
        }
        private void OnSignIn(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Password;

            if (username == "Mary" && password == "Din")
            {
                MessageBox.Show("Login successful!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                
                
            }
            else
            {
                MessageBox.Show("Invalid credentials!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}