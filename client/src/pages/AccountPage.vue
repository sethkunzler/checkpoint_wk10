<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>

  <div class="container">
    <section id="createdRecipes" class="row">
      <div class="col-md-12">
        <div class="d-flex justify-content-between">
          <h2>My Recipes</h2>
          <button type="button" data-bs-toggle="modal" data-bs-target="#createRecipeModal" class="btn btn-success fs-5" alt="Create New Recipe" title="Click to Create a New Recipe"> + New Recipe </button>
        </div>
      </div>

    </section>
    <section id="favorites" class="row">
      <div class="col-md-12">
        <h2>My Favorite Recipes</h2>
      </div>
    </section>
  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
