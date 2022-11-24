using RecipeBook.Data;
using RecipeBook.Models;
using RecipeBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using wpf.ViewModels;

namespace wpf.Views
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        private RecipeBookDbContext _dbContext = new RecipeBookDbContext();

        public SignUp()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            RegisterViewModel model = new RegisterViewModel();
            if(ValidateUserName(txtUsername.Text))
            {
                model.Username = txtUsername.Text;
            }
            else {
                ShowMessageBox_Click("Invalid Username", "error");
                return;
            }
            
            if (ValidatePassword(txtPassword.Password.ToString()))
            {
                model.Password = txtPassword.Password.ToString();
            }
            else {
                ShowMessageBox_Click("Invalid Password", "error");
                return;
            }
           
            if (txtPassword.Password.ToString() == txtRepeatPassword.Password.ToString())
            {
                model.ConfirmPassword = txtRepeatPassword.Password.ToString();
            }
            else {
                ShowMessageBox_Click("Passwords do not match", "error");
                return;
            }
            AddToDB(model);
            var mainWindow = new RecipeList();
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
            mainWindow.Show();

        }

        private void AddToDB(RegisterViewModel registerViewModel)
        {
            try
            {
                using RecipeBookDbContext _dbContext2 = new RecipeBookDbContext();

                UserService servise = new UserService(_dbContext2);

                servise.AddUser(new User(registerViewModel.Username, registerViewModel.Username, registerViewModel.Password, " "));
                
                ShowMessageBox_Click("Congratulations! Registration was successful!", "successful");
            }
            catch(Exception ex)
            {
                ShowMessageBox_Click("User with such Username already exists!", "error");
            }
            
        }

        private void ShowMessageBox_Click(string msgtext, string txt)
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(msgtext, txt, button);      
        }

        //private void ShowMessageBox_Click_Eror()
        //{
        //    string msgtext = "User with such Username already exists!";
        //    string txt = "error";
        //    MessageBoxButton button = MessageBoxButton.OK;
        //    MessageBoxResult result = MessageBox.Show(msgtext, txt, button);
        //}

        private bool ValidateUserName(string userName)
        {
            string pattern;
            // start with a letter, allow letter or number, length between 3 to 12.
            pattern = @"^[a-zA-Z][a-zA-Z0-9]{2,11}$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(userName );
        }

        private bool ValidatePassword(string pass)
        {
            string pattern;
            // at least one lower case letter, at least one upper case letter
            //not be lesser than 8 or greater than 15 characters, contain at least one numeric value
            pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(pass);
        }
    }
}
