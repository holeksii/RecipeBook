using RecipeBook.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf.ViewModels;

namespace wpf.Views;

/// <summary>
/// Interaction logic for LoginView.xaml
/// </summary>
public partial class LoginView : UserControl
{
    private RecipeBookDbContext _dbContext = new RecipeBookDbContext();

    public LoginView()
    {
        InitializeComponent();
    }

    private void loginBtn_Click(object sender, RoutedEventArgs e)
    {
        LoginViewModel model = new LoginViewModel();
        model.Username = txtUsername.Text;
        model.Password = txtPassword.Password.ToString();

    }

    private bool checkExistUser(LoginViewModel loginViewModel)
    {
        UserService servise = new UserService(_dbContext);
        if (servise.GetUser(loginViewModel.Username, loginViewModel.Password) is null)
        {
            return false;
        }
        return true;
    }
}
