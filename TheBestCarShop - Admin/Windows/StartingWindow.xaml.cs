﻿using System.Windows;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.IN_PROGRESS;

namespace TheBestCarShop___Admin.Windows
{
    /// <summary>
    /// Interaction logic for StartingWindow.xaml
    /// </summary>
    public partial class StartingWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();

        public StartingWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = @usernameTextBox.Text;
            string password = @actualPasswordBox.Password;

            bool validationResult =
                databaseHandler.CheckLoginData(username, password);


            if (validationResult)
            {
                LoggedInWindow loggedInWindow = new LoggedInWindow(databaseHandler.GetClientDetails(username));
                loggedInWindow.Show();
                this.Close();
            }
            else
            {
                infoLabel.Content = "                    Failed to log in.     \n" +
                                    "Please check your login and password.";
                infoLabel.Visibility = Visibility.Visible;
            }
        }

        private void clearFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            usernameTextBox.Text = "Login";
            passwordTextBox.Text = "Password";
            passwordTextBox.Visibility = Visibility.Visible;
            infoLabel.Visibility = Visibility.Hidden;
            actualPasswordBox.Password = "";
        }

        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Visibility = Visibility.Hidden;
            actualPasswordBox.Focus();
        }

        private void actualPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (actualPasswordBox.Password == "")
            {
                passwordTextBox.Visibility = Visibility.Visible;
            }
        }

        private void usernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == "Login")
                usernameTextBox.Clear();
        }

        private void usernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == "")
                usernameTextBox.Text = "Login";
        }
    }
}
