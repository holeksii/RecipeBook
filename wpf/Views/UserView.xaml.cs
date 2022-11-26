using System;
using System.Windows;
using System.Text.RegularExpressions;
using static RecipeBook.Config.DbConfig;
using RecipeBook.Models;
using RecipeBook.Services;

namespace wpf.Views;
public partial class UserView : Window
{
    private UserService _userService;
    private User currentUser;
    private User user;
    public UserView(User cu, User u)
    {
        InitializeComponent();
        currentUser = cu;
        user=u;
        _userService = new UserService(GetDbContext());

        UsernameXAML.Text=u.Username;
        if(u.Email==u.Username){
            EmailXAML.Text = "No email here yet";
        }
        else{
            EmailXAML.Text = $"Email: {u.Email}";
        }
        NumberXAML.Text = $"{u.Recipes.Count}";
        if(u.Id!=cu.Id){
            emailChangePanel.Visibility = System.Windows.Visibility.Hidden;
            addPanel.Visibility = System.Windows.Visibility.Hidden;
        }
    }
    private void allRecipesBtn_Click(object sender, RoutedEventArgs e){
        var mainWindow = new RecipeList(currentUser);
        var myWindow = Window.GetWindow(this);
        myWindow.Close();
        mainWindow.Show();
    }
    private void userRecipesBtn_Click(object sender, RoutedEventArgs e){


    }
    private void addRecipeBtn_Click(object sender, RoutedEventArgs e){


    }
    private void confirmEmailBtn_Click(object sender, RoutedEventArgs e){
        if(ValidateEmail(txtEmailXAML.Text)){
            try
            {
                currentUser.Email = txtEmailXAML.Text;
                _userService.UpdateUser(currentUser);
                ShowMessageBox_Click("Congratulations! Email successfully changed!", "successful");
                var mainWindow = new UserView(currentUser,user);
                var myWindow = Window.GetWindow(this);
                myWindow.Close();
                mainWindow.Show();
            }
            catch(Exception ex)
            {
                ShowMessageBox_Click("Something went wrong!", "error");
            }
        }
                else 
        {
            ShowMessageBox_Click("Invalid Username", "error");
            return;
        }
    }
    private void ShowMessageBox_Click(string msgtext, string txt)
    {
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxResult result = MessageBox.Show(msgtext, txt, button);      
    }
    private bool ValidateEmail(string userName)
    {
        string pattern;
        pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(userName );
    }

}
