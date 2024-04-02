<template>
  <form>
  <div class="mb-3">
    <label for="title" class="form-label" >Title</label>
    <input type="text" class="form-control" id="title" required minlength="3" maxlength="50">
  </div>
  <div class="mb-3">
    <label for="img" class="form-label">Image</label>
    <input type="url" class="form-control" id="img" minlength="3" maxlength="">
  </div>
  <div class="form-floating">
    <textarea class="form-control" placeholder="Leave a comment here" id="instructions" style="height: 100px" required minlength="15" maxlength="1000"></textarea>
    <label for="instructions">Instructions</label>
  </div>
  <hr>
  <span class="pt-3 pb-2" for="category">Select a category</span>
  <div>
    <!-- TODO Check to make sure this works, I believe that it doesn't work like I want it to -->
    <div v-for="category in categories" class="form-check form-check-inline">
      <input class="form-check-input" type="checkbox" :id="category" :value="category">
      <label class="form-check-label me-2 text-capitalize" :for="category">{{category}}</label>
    </div>
  </div>
  <div class="d-flex justify-content-end">
      <button type="submit" class="btn btn-primary">Submit</button>
  </div>
</form>
</template>


<script>
export default {
setup(){
  const categories = ["breakfast", "lunch", "dinner", "meal", "entrees", "dessert", "appetizer", "snack", "salads", "soup", "pasta", "sandwich", "cheese", "coffee", "fish", "beef", "burger", "sausage", "french", "german", "russian", "mexican", "italian", "chinese", "japanese", "thai"]
  return{
    categories,
    
  }
}
}
</script>


<style lang="scss" scoped>

</style>