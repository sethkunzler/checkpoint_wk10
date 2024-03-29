

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

  internal Ingredient GetIngredientById(int ingredientId)
  {
    string sql = "SELECT * FROM ingredients WHERE id = @ingredientId;";
    Ingredient ingredient = _db.Query<Ingredient>(sql, new {ingredientId}).FirstOrDefault();
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

    internal void RemoveIngredient(int ingredientId)
    {
      string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new {ingredientId});
      if (rowsAffected == 0)
      {
        throw new Exception("Nothing was Deleted. Check your sql and ingredient Id");
      }
      if (rowsAffected > 1)
      {
        throw new Exception("Digame que ya te resignas porque es bien probable que borraste TODO en tu tabla!");
      }

    }

    private Ingredient _populateCreator(Ingredient ingredient, Account account)
  {
    ingredient.Creator = account;
    return ingredient;
  }
}