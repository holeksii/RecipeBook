using RecipeBook.Models;
using RecipeBook.Services;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

using static RecipeBook.Config.DbConfig;

namespace wpf.Views;

/// <summary>
/// Interaction logic for RecipeList.xaml
/// </summary>
public partial class RecipeListView : Window
{
    private RecipeService _recipeService;
    private List<Recipe> _recipes;

    private User currentUser;
    
    public RecipeListView(User cu, User? author = null)
    {
        InitializeComponent();
        RecipesGridXAML.BeginningEdit += (s, ss) => ss.Cancel = true;
        _recipeService = new RecipeService(GetDbContext());
        if(author == null){
            _recipes = _recipeService.GetRecipes();
        }
        else{
            _recipes = _recipeService.GetRecipes(author.Id);
        }
        currentUser = cu;
        foreach (var recipe in _recipes)
        {
            RecipesGridXAML.Items.Add(recipe);
        }
    }
    public void showDetailsbtn_click(object sender, RoutedEventArgs e){
        var cell = RecipesGridXAML.CurrentCell;
        var item = cell.Item;
        Recipe recipe = (Recipe)item;
        //Recipe recipe = _recipeService.GetRecipe(recipeId);
        var mainWindow = new RecipeView(currentUser,recipe.Id);
        var myWindow = Window.GetWindow(this);
        myWindow.Close();
        mainWindow.Show();
    }
    private void allRecipesBtn_Click(object sender, RoutedEventArgs e){
        var mainWindow = new RecipeListView(currentUser);
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

}
