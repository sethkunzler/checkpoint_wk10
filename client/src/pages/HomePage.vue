<template>
  <div class="flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container user-select-none">
      <section class="row">
        <div class="col-md-12">
          <h1>Browse Recipes</h1>
        </div>
        <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4">
          <div class="card my-2">
            <div class="selectable " title="Click to see recipe details">
              <h2 class="px-2">{{ recipe.title.substring(0,15) }} <span title="click to read more" class="text-primary">...</span></h2>
              <img class="recipe-card-img" :src="recipe.img" :alt="recipe.title">
            </div>
            <div class="bg-success p-1 border border-1 border-light rounded shadow m-1 opacity-50"></div> 
            <div class="d-flex justify-content-between align-items-center">
              <div class="pt-2 px-2 mb-2">
                <span>More Like: </span>
                <btn class="btn btn-success opacity-75 text-capitalize">{{recipe.category}}</btn>
              </div>
              <div class="d-flex justify-content-end">
                <span v-if="isLiked" class="mdi mdi-heart text-danger selectable rounded fs-4 px-2 mx-2"></span>
                <span class="mdi mdi-heart-outline selectable rounded fs-4 px-2 mx-2"></span>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from "vue"
import Pop from "../utils/Pop.js"
import {recipesService} from "../services/RecipesService.js"
import { AppState } from "../AppState.js"

export default {
  setup() {
    // TODO replace "isLiked" with recipe "favorite" relationship condition
    const isLiked = false
    onMounted(() => {getAllRecipes()})
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes()
      }
      catch (error){
        Pop.error(error);
      }
    }
    return {
      isLiked,
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
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
