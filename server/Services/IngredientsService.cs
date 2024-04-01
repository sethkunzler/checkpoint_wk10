namespace checkpoint_wk10.Services;

public class IngredientsService {
  private readonly IngredientsRepository _repository;

    public IngredientsService(IngredientsRepository repository)
    {
      _repository = repository;
    }
  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient ingredient = _repository.CreateIngredient(ingredientData);
    return ingredient; 
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }

  internal Ingredient GetIngredientById(int ingredientId) 
  {
    Ingredient ingredient = _repository.GetIngredientById(ingredientId);
    if (ingredient == null)
    {
      throw new Exception($"Tried to find Ingredient Id. Invalid Ingredient Id: {ingredientId}");
    }
    return ingredient;
  }

  internal string RemoveIngredient(int ingredientId, string userId)
  {
    Ingredient ingredientToRemove = GetIngredientById(ingredientId);
    // FIXME Does not validate that the recipe's creator id matches the current user, just that the ingredient's creator ID does
    if (ingredientToRemove.CreatorId != userId)
    {
      throw new Exception("RESTRICTED!! Access to Remove Ingredients is restricted to the creator of the ingredient only");
    }
    _repository.RemoveIngredient(ingredientId);
    return $"It sure is a good thing that no one else will add {ingredientToRemove.Name}!";
  }
}