namespace checkpoint_wk10.Services;

public class FavoritesService 
{
  private readonly FavoritesRepository _repository;

  public FavoritesService(FavoritesRepository repository)
  {
    _repository = repository;
  }
}