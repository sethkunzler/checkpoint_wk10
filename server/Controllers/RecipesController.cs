using Microsoft.AspNetCore.Mvc.Infrastructure;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0provider;

    public RecipesController(RecipesService recipesService, Auth0Provider auth0provider)
    {
        _recipesService = recipesService;
        _auth0provider = auth0provider;
    }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.CreateRecipe(recipeData);
      return Ok(recipe);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Recipe>> GetRecipes()
  {
    try
    {
      List<Recipe> recipes = _recipesService.GetRecipes();
      return Ok(recipes);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
    try
    {
      Recipe recipe = _recipesService.GetRecipeById(recipeId);
      return Ok(recipe);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // ANCHOR 
  // TODO finish te put request here and in repo and service, run postman test to check
  [HttpPut("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Recipe recipe = _recipesService.UpdateRecipe(recipeId, userInfo.Id);
      return Ok(recipe);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
