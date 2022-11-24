using RecipeBook.Models;
using RecipeBook.Services;
using System.Windows;
using System.Collections.Generic;

using static RecipeBook.Config.DbConfig;

namespace wpf;

/// <summary>
/// Interaction logic for RecipeList.xaml
/// </summary>
public partial class RecipeList : Window
{
    private RecipeService _recipeService;
    private List<Recipe> _recipes;
    
    public RecipeList()
    {
        InitializeComponent();
        _recipeService = new RecipeService(GetDbContext());
        _recipes = _recipeService.GetRecipes();
        foreach (var recipe in _recipes)
        {
            RecipesGridXAML.Items.Add(recipe);
        }
    }
}
