<template>
<div class="modal fade" id="createRecipeModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="createRecipeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-dialog-scrollable">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="createRecipeModalLabel">Create New Recipe</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <CreateRecipeForm />
      </div>
    </div>
  </div>
</div>
</template>

<!-- TODO on submit dismisses the modal -->

<script>
import CreateRecipeForm from "./CreateRecipeForm.vue";

export default {
setup(){
return{}
}
}
</script>


<style lang="scss" scoped>

</style>