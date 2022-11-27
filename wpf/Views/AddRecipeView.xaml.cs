using System;
using System.Collections.Generic;
using System.Windows;
using System.Text.RegularExpressions;
using static RecipeBook.Config.DbConfig;
using RecipeBook.Models;
using RecipeBook.Services;


namespace wpf.Views;
public partial class AddRecipeView : Window
{
    private RecipeService _recipeService;
    private User currentUser;
    private List<Ingredient> ingredients; 
    public AddRecipeView(User cu)
    {
        currentUser = cu;
        _recipeService = new RecipeService(GetDbContext());
        ingredients = new List<Ingredient>();
        InitializeComponent();
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
    private void addIngredientBtn_Click(object sender, RoutedEventArgs e){
        try{
            Ingredient ingredient = new Ingredient(txtIngredientNameXAML.Text,
                Int32.Parse(txtIngredientQuantityXAML.Text),
                txtIngredientMeasureXAML.Text);
            ingredients.Add(ingredient);
            txtIngredientNameXAML.Text ="";
            txtIngredientMeasureXAML.Text ="";
            txtIngredientQuantityXAML.Text ="";
            ShowMessageBox_Click("Ingredient added", "success");
        }
        catch(Exception ex){
            ShowMessageBox_Click("Invalid ingredient data", "error");
        }
    }
    private void addRecipeBtn_Click(object sender, RoutedEventArgs e){
        try{
            Recipe recipe = new Recipe(txtNameXAML.Text,"",
                txtInstructionsXAML.Text,txtCategoryXAML.Text,Int32.Parse(txtTimeXAML.Text));
            recipe.Ingredients=ingredients;
            _recipeService.AddRecipe(recipe,currentUser.Id);
            ShowMessageBox_Click("Recipe added", "success");
            var mainWindow = new RecipeView(currentUser, recipe);
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
            mainWindow.Show();
        }
        catch(Exception ex){
            ShowMessageBox_Click("Invalid ingredient data", "error");
        }
    }
        private void ShowMessageBox_Click(string msgtext, string txt)
    {
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxResult result = MessageBox.Show(msgtext, txt, button);      
    }

}