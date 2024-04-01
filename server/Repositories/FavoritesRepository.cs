
namespace checkpoint_wk10.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Favorite EstablishFavorite(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO
    favorites(recipeId, accountId)
    VALUES(@RecipeId, @AccountId);

     SELECT * FROM favorites WHERE id = LAST_INSERT_ID();";

    Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();
    return favorite;
  }
}