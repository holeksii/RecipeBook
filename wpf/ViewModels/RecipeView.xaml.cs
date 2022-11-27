using System;
using System.Windows;
using System.Text.RegularExpressions;
using static RecipeBook.Config.DbConfig;
using RecipeBook.Models;
using RecipeBook.Services;

namespace wpf.Views;
public partial class RecipeView : Window
{
    private RecipeService _recipeService;
    private LikeService _likeService;
    private CommentService _commentService;
    private User currentUser;
    private Recipe recipe;
    public RecipeView(User cu, Recipe r)
    {
        InitializeComponent();
        currentUser = cu;
        recipe=r;
        _recipeService = new RecipeService(GetDbContext());
        _commentService = new CommentService(GetDbContext());
        _likeService = new LikeService(GetDbContext());
        RecipeNameXAML.Text = recipe.Name;
        UsernameXAML.Text = $" By {recipe.User.Username}";
        CategoryXAML.Text = recipe.Category;
        TimeXAML.Text = $"Time to cook: {recipe.TimeToCook}";
        likesNumberXAML.Text = $"{recipe.Likes.Count}";
        commentsNumberXAML.Text = $"{recipe.Comments.Count}";
        foreach (var i in recipe.Ingredients)
        {
            IngredientsGridXAML.Items.Add(i);
        }
        foreach (var c in recipe.Comments)
        {
            CommentsGridXAML.Items.Add(c);
        }
        InstructionsXAML.Text = recipe.Instructions;
    }
    private void allRecipesBtn_Click(object sender, RoutedEventArgs e){
        var mainWindow = new RecipeList(currentUser);
        var myWindow = Window.GetWindow(this);
        myWindow.Close();
        mainWindow.Show();
    }
    private void myProfileBtn_Click(object sender, RoutedEventArgs e){
        var mainWindow = new UserView(currentUser,currentUser);
        var myWindow = Window.GetWindow(this);
        myWindow.Close();
        mainWindow.Show();
    }
    private void authorProfileBtn_Click(object sender, RoutedEventArgs e){
        var mainWindow = new UserView(currentUser,recipe.User);
        var myWindow = Window.GetWindow(this);
        myWindow.Close();
        mainWindow.Show();
    }
    private void likeBtn_Click(object sender, RoutedEventArgs e){
        if(_likeService.GetLike(currentUser.Id,recipe.Id)==null && currentUser.Id!=recipe.User.Id)
        {
            try
            {
                _likeService.AddLikeForRecipe(recipe.Id,currentUser.Id);
                ShowMessageBox_Click("Thanks for leaving like here!", "successful");
                var mainWindow = new RecipeView(currentUser, recipe);
                var myWindow = Window.GetWindow(this);
                myWindow.Close();
                mainWindow.Show();
            }
            catch(Exception ex)
            {
                ShowMessageBox_Click("Something went wrong!", "error");
            }
        }
        ShowMessageBox_Click("You can not leave like here!", "error");
    }
    private void confirmCommentBtn_Click(object sender, RoutedEventArgs e){
        try
        {
            _commentService.AddComment(txtCommentXAML.Text, recipe.Id);
            ShowMessageBox_Click("Congratulations! Your comment was saved!", "successful");
            var mainWindow = new RecipeView(currentUser,recipe);
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
            mainWindow.Show();
        }
        catch(Exception ex)
        {
            ShowMessageBox_Click("Something went wrong!", "error");
        }
    }
    private void ShowMessageBox_Click(string msgtext, string txt)
    {
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxResult result = MessageBox.Show(msgtext, txt, button);      
    }

}