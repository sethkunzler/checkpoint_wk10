<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container">
      <section class="row">
        <div class="col-md-12">
          <h1>Browse Recipes</h1>
        </div>
        <div class="col-md-4">
          <div class="card">
            <h2>Tacos</h2>
            <img class="recipe-card-img" src="https://images.unsplash.com/photo-1624300629298-e9de39c13be5?q=80&w=2500&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="mexican tacos">
            <div class="pt-2">
              <span class="">Mexican</span>
            </div>
            <div class="d-flex justify-content-end mb-1">
              <span v-if="isLiked" class="mdi mdi-heart text-danger selectable rounded fs-4 px-2 mx-2"></span>
              <span class="mdi mdi-heart-outline selectable rounded fs-4 px-2 mx-2"></span>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    const isLiked = false
    return {
      isLiked
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
  .mdi-heart-outline:hover {
    color: red;
  }
  .recipe-card-img {
    width: 100%;
    height: 40dvh;
    object-fit: cover;
    object-position: center;
  }
}
</style>
