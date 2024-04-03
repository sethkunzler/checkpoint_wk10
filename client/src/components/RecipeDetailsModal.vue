<template>
<!-- Modal -->
<div class="modal fade" id="recipeDetailsModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="recipeDetailsModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-fullscreen">
    <div v-if="recipe.creator && user" class="modal-content">
      <div class="modal-header">
        <div class="d-flex align-items-center">
          <h1 class="modal-title mx-2" id="recipeDetailsModalLabel">{{ recipe.title }} <span class="fs-5">by {{ recipe.creator.name }}</span></h1>
          <div class="mx-2">
             
          <!-- TODO creator Profile -->
          <img class="creator-profile-picture border border-success border-2" :src="recipe.creator.picture" :alt="recipe.creator.name">
          </div>
        </div>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <!-- TODO displays img, title and other recipe info -->
        <div class="container-fluid">
          <section class="row">
            <div class="col-md-4">
              <div class="d-flex justify-content-center align-items-center bg-success p-1 rounded bg-opacity-75">
                <img class="img-fluid shadow rounded recipe-img" :src="recipe.img" :alt="recipe.title">
              </div>
            </div>
            <div class="col-md-4">
              <h4>Intructions</h4>
              <div>
                <div v-if="user.id == recipe.creatorId" class="form-floating">
                  <textarea class="form-control" placeholder="Leave a comment here" id="floatingTextarea2" style="height: 55dvh"></textarea>
                  <label for="floatingTextarea2"> Editable Instructions</label>
                </div>
                <div>
                  <p>{{ recipe.instructions }}</p>
                </div>
              </div>
            </div>
            <div class="col-md-4">
              <h4>Ingredients</h4>
              <div v-if="ingredients.">
                {{ ingredients }}
              </div>
            </div>
          </section>
        </div>
        <!-- TODO conditionally displays a form to edit instructions, img, ingredients and other recipe info -->
        <!-- STUB FORM description -->
        <!-- STUB FORM ingredients and ingredients list - displays conditionally based on logged in user -->
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
</template>


<script>
import { computed, watch } from "vue";
import { AppState } from "../AppState.js"
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";

export default {
  setup(){
    const recipe = computed(() => AppState.activeRecipe)
    watch(recipe, () => {
      if (recipe.id != undefined)  {
        getIngredients(recipe.value.id) 
      }
    })
    async function getIngredients(recipeId) {
        try {
          console.log('am I even calling get Ingredients')
          await recipesService.getIngredients(recipeId)
        }
        catch (error){
          Pop.error(error);
        }
      }
    return{
      recipe,
      user: computed(() => AppState.user),
      ingredients: computed(() => AppState.ingredients),
      
    }
  }
}
</script>


<style lang="scss" scoped>
.recipe-img {
  max-height: 70dvh;
}
.creator-profile-picture{
  height: 48px;
  width: 48px;
  border-radius: 50%;
}
</style>