namespace checkpoint_wk10.Models;

public class Ingredient 
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string Quantity { get; set; }
  public int RecipeId { get; set; }
  public Recipe Recipe { get; set; }
}