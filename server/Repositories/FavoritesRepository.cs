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

  // FIXME Favorite.Recipe comes back null
  // TODO I have the "Favorite" relationship, what I need is to return the recipe. I don't need my account, and just the creator profile, instead of the whole account. Favorite id is also the same as recipeId (maybe that needs to be fixed).
  // it's a mess so I am going to work on frontend. 
  internal List<Favorite> GetMyFavoriteRecipes(string accountId)
  {
    string sql = @"
    SELECT 
    favorite.*,
    recipe.*,
    account.*
    FROM favorites favorite 
    JOIN recipes recipe ON recipe.id = favorite.RecipeId
    JOIN accounts account ON account.id = favorite.AccountId
    WHERE accountId = @accountId
    ;";
    List<Favorite> recipes = _db.Query<Favorite, Account, Favorite>(sql, (favorite, account) => {
      favorite.Account = account;
      return favorite;
    }, new {accountId}).ToList();
    return recipes;
  }
}