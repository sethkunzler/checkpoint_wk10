namespace checkpoint_wk10.Services;

public class FavoritesService 
{
  private readonly FavoritesRepository _repository;

  public FavoritesService(FavoritesRepository repository)
  {
    _repository = repository;
  }

  internal Favorite EstablishFavorite(Favorite favoriteData)
  {
    Favorite favorite = _repository.EstablishFavorite(favoriteData);
    return favorite;
  }
}