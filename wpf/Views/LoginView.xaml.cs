
using RecipeBook.Services;
using System.Windows;
using System.Windows.Controls;
using wpf.ViewModels;

using static RecipeBook.Config.DbConfig;

namespace wpf.Views;

/// <summary>
/// Interaction logic for LoginView.xaml
/// </summary>
public partial class LoginView : UserControl
{
    private UserService _userService;

    public LoginView()
    {
        InitializeComponent();
        _userService = new UserService(GetDbContext());
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
        if (_userService.GetUser(loginViewModel.Username, loginViewModel.Password) is null)
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
