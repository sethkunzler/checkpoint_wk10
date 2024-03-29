namespace checkpoint_wk10.Repositories; 

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
    INSERT INTO 
    ingredients(name, quantity, recipeId, creatorId)
    VALUES(@Name, @Quantity, @RecipeId, @CreatorId);

    SELECT 
    ingredient.*,
    account.*
    FROM ingredients ingredient 
    JOIN accounts account ON ingredient.creatorId = account.Id
    WHERE ingredient.id = LAST_INSERT_ID();";
    Ingredient ingredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
    {
      ingredient.Creator = account; 
      return ingredient;
    }, ingredientData).FirstOrDefault();

    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
    SELECT 
    ingredient.*,
    account.*
    FROM ingredients ingredient
    JOIN accounts account ON ingredient.creatorId = account.id
    WHERE ingredient.recipeId = @RecipeId;";

    List<Ingredient> ingredients = _db.Query<Ingredient, Account, Ingredient>(sql, _populateCreator, new {recipeId}).ToList();
    return ingredients;
  }

  private Ingredient _populateCreator(Ingredient ingredient, Account account)
  {
    ingredient.Creator = account;
    return ingredient;
  }
}