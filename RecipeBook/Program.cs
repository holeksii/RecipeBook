using RecipeBook.Models;
using RecipeBook.Services;

// add samples to db

List<Ingredient> pastaIngridients = new()
{
    new Ingredient("Pasta", 1, "kg"),
    new Ingredient("Salt", 1, "tsp"),
    new Ingredient("Olive oil", 2, "tbsp"),
    new Ingredient("Garlic", 2, "cloves"),
    new Ingredient("Tomato", 1, "kg"),
    new Ingredient("Basil", 1, "handful"),
    new Ingredient("Parmesan", 1, "handful"),
};


List<Ingredient> pizzaIngridients = new()
{
    new Ingredient("Flour", 1, "Cups"),
    new Ingredient("Water", 2, "Cups"),
    new Ingredient("Salt", 3, "Tsp"),
    new Ingredient("Yeast", 4, "Tsp"),
    new Ingredient("Olive Oil", 5, "Tbsp"),
    new Ingredient("Tomato Sauce", 6, "Cups"),
    new Ingredient("Mozzarella Cheese", 7, "Cups"),
    new Ingredient("Pepperoni", 8, "Cups"),
    new Ingredient("Basil", 9, "Tbsp")
};

List<Ingredient> cingerCookiesIngridients = new()
{
    new Ingredient("Flour", 1, "Cups"),
    new Ingredient("Sugar", 2, "Cups"),
    new Ingredient("Salt", 3, "Tsp"),
    new Ingredient("Baking Soda", 4, "Tsp"),
    new Ingredient("Cinnamon", 5, "Tbsp"),
    new Ingredient("Butter", 6, "Cups"),
    new Ingredient("Egg", 7, "Cups"),
    new Ingredient("Vanilla", 8, "Cups"),
    new Ingredient("Sugar", 9, "Tbsp")
};


Recipe pasta = new("Pasta",
    @"https://images.immediate.co.uk/production/volatile/sites/30/2013/05/Puttanesca-fd5810c.jpg",
    "Cook pasta in a large pot of boiling salted water until al dente. Drain, reserving 1 cup pasta water. Heat oil in a large skillet over medium heat. Add garlic and cook, stirring, until fragrant, about 1 minute. Add tomatoes and cook, stirring occasionally, until tomatoes break down and release their juices, about 5 minutes. Add pasta, pasta water, and basil and toss to combine. Season with salt and pepper. Serve with Parmesan.",
    "Italian",
    30);
pasta.Ingredients = pastaIngridients;


Recipe pizza = new("Pizza",
    @"https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg",
    "Preheat oven to 450 degrees F (230 degrees C). Lightly grease a baking sheet. In a large bowl, combine flour, salt, sugar, and yeast. Mix in water, oil, and egg. Beat until smooth. Turn dough out onto a lightly floured surface and knead until smooth and elastic, about 8 minutes. Cover dough with a damp cloth and let rest for 10 minutes. Roll dough out into a 12 inch circle. Place dough on the prepared baking sheet. Spread with tomato sauce, leaving a 1/2 inch border. Sprinkle with mozzarella cheese, pepperoni, and basil. Bake in preheated oven for 15 to 20 minutes, or until crust is golden brown and cheese is bubbly.",
    "Italian",
    30);
pizza.Ingredients = pizzaIngridients;


Recipe cingerCookies = new("Cinger Cookies",
    @"https://www.chsugar.com/sites/chsugar_com/files/2022-09/GingerBreadCookies2_Description_600x400.jpg",
    "Preheat oven to 350 degrees F (175 degrees C). In a medium bowl, cream together the butter and sugar until smooth. Beat in the egg and vanilla. Combine the flour, baking soda, and cinnamon; stir into the creamed mixture until just blended. Roll rounded teaspoonfuls of dough into balls, and place onto ungreased cookie sheets. Bake 8 to 10 minutes in the preheated oven, or until golden. Cool on baking sheets for a few minutes before transferring to wire racks to cool completely.",
    "Italian",
    30);
cingerCookies.Ingredients = cingerCookiesIngridients;


RecipeService recipesService = new(RecipeBook.Config.DbConfig.GetDbContext());
UserService userService = new(RecipeBook.Config.DbConfig.GetDbContext());
userService.AddUser(new User("Liana","liana@gmail.com","1234Pass",""));
recipesService.AddRecipe(pasta, 1);
recipesService.AddRecipe(pizza, 1);
recipesService.AddRecipe(cingerCookies, 1);
