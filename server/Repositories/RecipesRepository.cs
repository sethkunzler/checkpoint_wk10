namespace checkpoint_wk10.Repositories;

public class RecipesRepository 
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
  
  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO 
    recipes(title, instructions, img, category, creatorId)
    VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);

    SELECT
    recipe.*,
    account.*
    FROM recipes recipe 
    JOIN accounts account ON recipe.creatorId = account.Id
    WHERE recipe.id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) => 
    {
      recipe.Creator = account;
      return recipe;
    }, recipeData).FirstOrDefault();

    return recipe;
  }
  internal List<Recipe> GetRecipes()
  {
    string sql = @"
    SELECT 
    recipe.*,
    account.*
    FROM recipes recipe
    JOIN accounts account ON recipe.creatorId = account.id;";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account; 
      return recipe;
    }).ToList();
    return recipes;
  }
  internal Recipe GetRecipeById(int recipeId)
  {
    string sql = @"
    SELECT 
    recipe.*,
    account.*
    FROM recipes recipe 
    JOIN accounts account ON recipe.creatorId = account.id
    WHERE recipe.id = @RecipeId;";
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) => 
    {
      recipe.Creator = account;
      return recipe;
    }, new {recipeId}).FirstOrDefault();
    return recipe; 
  }

  internal Recipe UpdateRecipe(Recipe recipeToUpdate)
  {
    string sql= @"
      UPDATE recipes 
      SET 
      title = @Title,
      img = @Img,
      instructions = @Instructions
      WHERE id = @Id
      Limit 1;
      
      SELECT * FROM recipes WHERE id = @Id;";
    Recipe recipe = _db.Query<Recipe>(sql, recipeToUpdate).FirstOrDefault();
    return recipe;
  }

  internal void DeleteRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
    _db.Execute(sql, new {recipeId}); 
  }
}