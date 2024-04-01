import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService {
  async getAllRecipes() {
    const response = await api.get('api/recipes')
    AppState.recipes = response.data.map(pojo => new Recipe(pojo))
  }
}

export const recipesService = new RecipesService()