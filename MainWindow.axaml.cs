using Avalonia.Controls;
using MsBox.Avalonia;
using subenok23.Models;
using System;
using System.IO;

namespace subenok23
{
    public partial class MainWindow : Window
    {
        public string loginUs;
        public string passwordUs;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            bool found = false;
            loginUs = login.Text;
            passwordUs = passwd.Text;
            foreach (User user in Helper.user724Context.Users)
            {
                if (user.Login == loginUs && user.Password == passwordUs)
                { 
                    found = true;
                    Helper.currUser.IdUser = user.IdUser;
                    Helper.currUser.SurnameUser = user.SurnameUser;
                    Helper.currUser.NameUser = user.NameUser;   
                    Helper.currUser.Login = user.Login;
                    Helper.currUser.Password = user.Password;
                    
                  break;
                }
            }

           
            if (found == false)
            {
                var msg = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Такого пользователя не существует");
                msg.ShowAsync();
            }
            else 
            {
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Helper.vhod = 1;
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();


        }
    }
}