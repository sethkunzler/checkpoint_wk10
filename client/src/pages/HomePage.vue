<template>
  <div class="flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container user-select-none">
      <section class="row">
        <div class="col-md-12">
          <h1>Browse Recipes</h1>
        </div>
        <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4">
          <!-- STUB -->
          <SimpleRecipeCard :recipe="recipe"/>
        </div>
      </section>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from "vue"
import Pop from "../utils/Pop.js"
import {recipesService} from "../services/RecipesService.js"
import SimpleRecipeCard from "../components/SimpleRecipeCard.vue"
import { AppState } from "../AppState.js"

export default {
  setup() {
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

</style>
