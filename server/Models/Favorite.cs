namespace checkpoint_wk10.Models;

public class Favorite 
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int RecipeId { get; set; }
  public int AccountId { get; set; }
  public Recipe Recipe { get; set; }
  public Account Account { get; set; }
}