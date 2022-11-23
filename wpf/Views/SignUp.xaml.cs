using RecipeBook.Data;
using RecipeBook.Models;
using RecipeBook.Services;
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
            model.Username = txtUsername.Text;
            model.Password = txtPassword.Password.ToString();
            model.ConfirmPassword = txtRepeatPassword.Password.ToString();
            AddToDB(model);

        }

        private void AddToDB(RegisterViewModel registerViewModel)
        {
            UserService servise = new UserService(_dbContext);

            servise.AddUser(new User(registerViewModel.Username, registerViewModel.Username, registerViewModel.Password, " "));
            ShowMessageBox_Click();
        }

        private void ShowMessageBox_Click()
        {
            string msgtext = "Congratulations! Registration was successful!";
            string txt = "successful";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(msgtext, txt, button);

          
        }
    }
}
