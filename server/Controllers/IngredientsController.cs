[ApiController]
[Route("api/[controller]")]

public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _ingredientsService;


    private readonly Auth0Provider _auth0Provider;

    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
    {
        _ingredientsService = ingredientsService;
        _auth0Provider = auth0Provider;
    }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      ingredientData.CreatorId = userInfo.Id; 
      Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData);
      return Ok(ingredient);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
  
  // ANCHOR do this at some point
  // TODO 
  // [HttpDelete("{ingredientId}")]
}