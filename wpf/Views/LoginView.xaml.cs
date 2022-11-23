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
        if(!checkExistUser(model))
        {
            ShowMessageBox_Click();
        }
    }

    private bool checkExistUser(LoginViewModel loginViewModel)
    {
        UserService servise = new UserService(_dbContext);
        if (servise.GetUser(loginViewModel.Username, loginViewModel.Password) is null)
        {
            return false;
        }

        var mainWindow = new RecipeList();
        var myWindow = Window.GetWindow(this);
        myWindow.Close();
        mainWindow.Show();

        return true;
    }

    private void ShowMessageBox_Click()
    {
        string msgtext = "Invalid login or password! Try again!";
        string txt = "fail";
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxResult result = MessageBox.Show(msgtext, txt, button);
    }
}
