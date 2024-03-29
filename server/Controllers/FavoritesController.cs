namespace checkpoint_wk10.Controllers;

public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0Provider;

  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
  {
    _favoritesService = favoritesService;
    _auth0Provider = auth0Provider;
  }

  
}