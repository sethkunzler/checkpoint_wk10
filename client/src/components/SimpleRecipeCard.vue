<template>
  <div class="card my-2">
    <div role="button" @click="setActiveRecipe(recipe.id)" class="selectable" data-bs-toggle="modal" data-bs-target="#recipeDetailsModal" title="Click to see recipe details">
      <h2 class="px-2">{{ recipe.title.substring(0,15) }} <span title="click to read more" class="text-primary">...</span></h2>
      <img class="recipe-card-img" :src="recipe.img" :alt="recipe.title">
    </div>
    <div class="bg-success p-1 border border-1 border-light rounded shadow m-1 opacity-50"></div> 
    <div class="d-flex justify-content-between align-items-center">
      <div class="pt-2 px-2 mb-2">
        <span>Explore Categories: </span>
        <button class="btn btn-success opacity-75 text-capitalize" :title="'click to see more ' +  recipe.category">{{recipe.category}}</button>
      </div>
      <div class="d-flex justify-content-end">
        <!-- TODO reactively saves to the favorites database -->
        <button type="button" v-if="isLiked" class="mdi mdi-heart btn text-danger selectable rounded fs-4 py-1 px-2 mx-2" title="Click to Remove from Favorites"></button>
        <button type="button" v-else class="mdi mdi-heart-outline btn selectable rounded fs-4 py-1 px-2 mx-2" title="Click to Save"></button>
      </div>
    </div>
  </div>
</template>


<script>
import { Recipe } from "../models/Recipe.js"
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
export default {
  props: {recipe : { type: Recipe, required : true}},
  setup(){
    // TODO replace "isLiked" with recipe "favorite" relationship condition
    const isLiked = false
    return{
      isLiked,
      async setActiveRecipe(recipeId) {
        try {
          await recipesService.setActiveRecipe(recipeId);
        }
        catch (error){
          Pop.error(error);
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>
.mdi-heart-outline:hover {
  color: red;
}
.recipe-card-img {
  width: 100%;
  height: 40dvh;
  object-fit: cover;
  object-position: center;
}
</style>