import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService {
  async getAllRecipes() {
    const response = await api.get('api/recipes')
    AppState.recipes = response.data.map(pojo => new Recipe(pojo))
  }
  
  async setActiveRecipe(recipeId) {
    AppState.activeRecipe = {}
    const response = await api.get(`api/recipes/${recipeId}`)
    // logger.log("This is the response from the Api ", response.data)
    const recipe = new Recipe(response.data)
    AppState.activeRecipe = recipe
    // logger.log('This is the new active recipe ',AppState.activeRecipe)
  }

  async getIngredients(recipeId) {
    AppState.ingredients = []
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log("this is the ingredients response from the api", res.data)
    const ingredients = res.data.map(pojo => new Ingredient(pojo))
    AppState.ingredients = ingredients
  }
  // TODO get recipes by creator ID
  // NOTE not included in the postman tests
}

export const recipesService = new RecipesService()