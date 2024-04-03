export class Ingredient {
  constructor(data) {
    this.id = data.id
    this.quantity = data.quantity 
    this.name = data.name
    this.recipeId = data.recipeId
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    
  }
}