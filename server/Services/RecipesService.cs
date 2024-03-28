namespace checkpoint_wk10.Services;
public class RecipesService {
  private readonly RecipesRepository _repository;

  public RecipesService(RecipesRepository repository)
  {
    _repository = repository;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repository.CreateRecipe(recipeData);
    return recipe;
  }
  internal List<Recipe> GetRecipes()
  {
    List<Recipe> recipes = _repository.GetRecipes();
    return recipes;
  }
  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _repository.GetRecipeById(recipeId);
    if (recipe == null) 
    {
      throw new Exception($" Tried to find Recipe Id. Invalid Recipe Id: {recipeId}");
    }
    return recipe;
  }

  internal Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeData)
  {
    Recipe recipeToUpdate = GetRecipeById(recipeId);
    if (recipeToUpdate.CreatorId != userId) 
    {
      throw new Exception("Forbidden! This is not the recipe you are looking for. Access to Edit this recipe is restricted to the user.");
    }
    recipeToUpdate.Title = recipeData.Title ?? recipeToUpdate.Title;
    recipeToUpdate.Img = recipeData.Img ?? recipeToUpdate.Img;
    recipeToUpdate.Instructions = recipeData.Instructions ?? recipeToUpdate.Instructions;
    
    Recipe updatedRecipe = _repository.UpdateRecipe(recipeToUpdate);

    return updatedRecipe; 
  }

}